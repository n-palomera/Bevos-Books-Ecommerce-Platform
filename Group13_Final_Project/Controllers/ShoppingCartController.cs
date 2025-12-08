using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Group13_Final_Project.Utilities;
using Group13_Final_Project.Services;

namespace Group13_Final_Project.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public ShoppingCartController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: ShoppingCart
        public async Task<IActionResult> Index()
        {
            // Check if user is Admin or Employee - they cannot buy books
            if (User.IsInRole("Admin") || User.IsInRole("Employee"))
            {
                TempData["Error"] = "Administrators and employees cannot purchase books.";
                return RedirectToAction("Index", "Home");
            }

            var cart = HttpContext.Session.GetCart();
            var messages = new List<string>();
            var itemsToRemove = new List<int>();
            bool cartModified = false;

            // Check each item in cart for price updates, out-of-stock, and discontinued
            foreach (var item in cart.Items.ToList())
            {
                var book = await _context.Books.FindAsync(item.BookID);

                if (book == null)
                {
                    // Book no longer exists
                    itemsToRemove.Add(item.BookID);
                    messages.Add($"\"{item.Title}\" is no longer available and was removed from your cart.");
                    continue;
                }

                // Check if discontinued
                if (book.BookStatus == BookStatusEnum.Discontinued)
                {
                    itemsToRemove.Add(item.BookID);
                    messages.Add($"\"{book.Title}\" has been discontinued and was removed from your cart.");
                    continue;
                }

                // Check if out of stock
                if (!book.InStock || book.InventoryQuantity <= 0)
                {
                    itemsToRemove.Add(item.BookID);
                    messages.Add($"\"{book.Title}\" is out of stock and was removed from your cart.");
                    continue;
                }

                // Update to current price if changed
                if (item.Price != book.Price)
                {
                    item.Price = book.Price;
                    cartModified = true;
                }

                // Update title/author if changed
                if (item.Title != book.Title || item.Authors != book.Authors)
                {
                    item.Title = book.Title;
                    item.Authors = book.Authors;
                    cartModified = true;
                }

                // Adjust quantity if it exceeds available inventory
                if (item.Quantity > book.InventoryQuantity)
                {
                    messages.Add($"Quantity for \"{book.Title}\" adjusted to {book.InventoryQuantity} (maximum available).");
                    item.Quantity = book.InventoryQuantity;
                    cartModified = true;
                }
            }

            // Remove items that are discontinued or out of stock
            foreach (var bookId in itemsToRemove)
            {
                cart.RemoveItem(bookId);
                cartModified = true;
            }

            // Save cart if modified
            if (cartModified)
            {
                HttpContext.Session.SetCart(cart);
            }

            // Show messages to user
            if (messages.Any())
            {
                TempData["CartMessages"] = messages;
            }

            var viewModel = new CartViewModel
            {
                Cart = cart,
                Shipping = cart.CalculateShipping()
            };
            return View(viewModel);
        }

        // POST: ShoppingCart/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddToCart(int bookId, int quantity = 1)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                TempData["Error"] = "Book not found.";
                return RedirectToAction("Index", "Books");
            }

            if (!book.InStock)
            {
                TempData["Error"] = "This book is currently out of stock.";
                return RedirectToAction("Details", "Books", new { id = bookId });
            }

            // Check if requested quantity exceeds available inventory
            var cart = HttpContext.Session.GetCart();
            var existingItem = cart.Items.FirstOrDefault(i => i.BookID == bookId);
            int currentInCart = existingItem?.Quantity ?? 0;

            if (currentInCart + quantity > book.InventoryQuantity)
            {
                TempData["Error"] = $"Only {book.InventoryQuantity} copies available. You already have {currentInCart} in your cart.";
                return RedirectToAction("Details", "Books", new { id = bookId });
            }

            cart.AddItem(bookId, book.Title, book.Authors, book.Price, quantity);
            HttpContext.Session.SetCart(cart);

            TempData["Success"] = $"\"{book.Title}\" has been added to your cart!";
            return RedirectToAction("Index");
        }

        // POST: ShoppingCart/UpdateQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateQuantity(int bookId, int quantity)
        {
            var cart = HttpContext.Session.GetCart();

            if (quantity <= 0)
            {
                cart.RemoveItem(bookId);
                HttpContext.Session.SetCart(cart);
                TempData["Success"] = "Item removed from cart.";
                return RedirectToAction("Index");
            }

            // Validate against inventory
            var book = await _context.Books.FindAsync(bookId);
            if (book != null && quantity > book.InventoryQuantity)
            {
                TempData["Error"] = $"Only {book.InventoryQuantity} copies available.";
                return RedirectToAction("Index");
            }

            cart.UpdateQuantity(bookId, quantity);
            HttpContext.Session.SetCart(cart);
            TempData["Success"] = "Cart updated.";
            return RedirectToAction("Index");
        }

        // POST: ShoppingCart/RemoveItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public IActionResult RemoveItem(int bookId)
        {
            var cart = HttpContext.Session.GetCart();
            cart.RemoveItem(bookId);
            HttpContext.Session.SetCart(cart);
            TempData["Success"] = "Item removed from cart.";
            return RedirectToAction("Index");
        }

        // POST: ShoppingCart/Clear
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public IActionResult Clear()
        {
            HttpContext.Session.ClearCart();
            TempData["Success"] = "Cart cleared.";
            return RedirectToAction("Index");
        }

        // GET: ShoppingCart/Checkout
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetCart();

            if (cart.Items.Count == 0)
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index");
            }

            // Validate inventory for all items
            foreach (var item in cart.Items)
            {
                var book = await _context.Books.FindAsync(item.BookID);
                if (book == null || !book.InStock)
                {
                    TempData["Error"] = $"\"{item.Title}\" is no longer available.";
                    return RedirectToAction("Index");
                }
                if (item.Quantity > book.InventoryQuantity)
                {
                    TempData["Error"] = $"Only {book.InventoryQuantity} copies of \"{item.Title}\" are available.";
                    return RedirectToAction("Index");
                }
            }

            // Get current user's saved cards
            var username = User.Identity?.Name;
            var user = await _context.Users
                .Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Calculate shipping and discount based on coupon
            decimal shipping = cart.CalculateShipping();
            decimal discount = 0;

            // Check for applied coupon
            int? couponId = HttpContext.Session.GetInt32("AppliedCouponID");
            if (couponId.HasValue)
            {
                var coupon = await _context.Coupons.FindAsync(couponId.Value);
                if (coupon != null && coupon.Status)
                {
                    if (coupon.CouponType == CouponTypeEnum.PercentOff && coupon.DiscountPercent.HasValue)
                    {
                        discount = cart.Subtotal * (coupon.DiscountPercent.Value / 100);
                    }
                    else if (coupon.CouponType == CouponTypeEnum.FreeShipping)
                    {
                        if (coupon.FreeThreshold == null || cart.Subtotal >= coupon.FreeThreshold.Value)
                        {
                            shipping = 0;
                        }
                    }
                }
            }

            var viewModel = new CheckoutViewModel
            {
                Cart = cart,
                Shipping = shipping,
                Discount = discount,
                SavedCards = user.Cards ?? new List<Card>()
            };

            return View(viewModel);
        }

        // POST: ShoppingCart/ApplyCoupon
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ApplyCoupon(string couponCode)
        {
            var cart = HttpContext.Session.GetCart();

            if (string.IsNullOrWhiteSpace(couponCode))
            {
                TempData["CouponError"] = "Please enter a coupon code.";
                return RedirectToAction("Checkout");
            }

            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(c => c.CouponCode == couponCode && c.Status);

            if (coupon == null)
            {
                TempData["CouponError"] = "Invalid or expired coupon code.";
                return RedirectToAction("Checkout");
            }

            // Check if customer has already used this coupon
            var username = User.Identity?.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user != null)
            {
                var alreadyUsed = await _context.Orders
                    .AnyAsync(o => o.CustomerID == user.Id && o.CouponID == coupon.CouponID);
                if (alreadyUsed)
                {
                    TempData["CouponError"] = "You have already used this coupon code.";
                    return RedirectToAction("Checkout");
                }
            }

            // Store coupon ID in session for checkout
            HttpContext.Session.SetInt32("AppliedCouponID", coupon.CouponID);

            // Calculate discount preview
            decimal discount = 0;
            if (coupon.CouponType == CouponTypeEnum.PercentOff && coupon.DiscountPercent.HasValue)
            {
                discount = cart.Subtotal * (coupon.DiscountPercent.Value / 100);
                TempData["CouponSuccess"] = $"Coupon applied! {coupon.DiscountPercent}% discount (${discount:F2} off)";
            }
            else if (coupon.CouponType == CouponTypeEnum.FreeShipping)
            {
                if (coupon.FreeThreshold == null || cart.Subtotal >= coupon.FreeThreshold.Value)
                {
                    TempData["CouponSuccess"] = "Coupon applied! Free shipping!";
                }
                else
                {
                    TempData["CouponError"] = $"Free shipping requires order of ${coupon.FreeThreshold:F2} or more.";
                    HttpContext.Session.Remove("AppliedCouponID");
                }
            }

            return RedirectToAction("Checkout");
        }

        // POST: ShoppingCart/RemoveCoupon
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public IActionResult RemoveCoupon()
        {
            HttpContext.Session.Remove("AppliedCouponID");
            TempData["Success"] = "Coupon removed.";
            return RedirectToAction("Checkout");
        }

        // POST: ShoppingCart/PlaceOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> PlaceOrder(int? selectedCardId, string? newCardNumber, CardTypeEnum? newCardType)
        {
            var cart = HttpContext.Session.GetCart();

            if (cart.Items.Count == 0)
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index");
            }

            // Get current user
            var username = User.Identity?.Name;
            var user = await _context.Users
                .Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Validate card selection - must have either existing card or new card
            int? cardId = null;
            if (selectedCardId.HasValue && selectedCardId.Value > 0)
            {
                // Using existing card
                var existingCard = user.Cards?.FirstOrDefault(c => c.CardID == selectedCardId.Value);
                if (existingCard == null)
                {
                    TempData["Error"] = "Invalid card selected.";
                    return RedirectToAction("Checkout");
                }
                cardId = existingCard.CardID;
            }
            else if (!string.IsNullOrEmpty(newCardNumber))
            {
                // Creating new card - check max 3 cards limit
                int currentCardCount = user.Cards?.Count ?? 0;
                if (currentCardCount >= 3)
                {
                    TempData["Error"] = "You can only have a maximum of 3 credit cards. Please remove one before adding a new card.";
                    return RedirectToAction("Checkout");
                }

                if (newCardNumber.Length != 16 || !newCardNumber.All(char.IsDigit))
                {
                    TempData["Error"] = "Card number must be 16 digits.";
                    return RedirectToAction("Checkout");
                }

                if (!newCardType.HasValue)
                {
                    TempData["Error"] = "Please select a card type.";
                    return RedirectToAction("Checkout");
                }

                var newCard = new Card
                {
                    CardNumber = newCardNumber,
                    CardType = newCardType.Value,
                    CustomerID = user.Id
                };
                _context.Cards.Add(newCard);
                await _context.SaveChangesAsync();
                cardId = newCard.CardID;
            }
            else
            {
                // No card selected and no new card provided
                TempData["Error"] = "Please select a payment method or enter a new card.";
                return RedirectToAction("Checkout");
            }

            // Validate inventory one more time
            foreach (var item in cart.Items)
            {
                var book = await _context.Books.FindAsync(item.BookID);
                if (book == null || !book.InStock || item.Quantity > book.InventoryQuantity)
                {
                    TempData["Error"] = $"Inventory issue with \"{item.Title}\". Please review your cart.";
                    return RedirectToAction("Index");
                }
            }

            // Get coupon if applied
            int? couponId = HttpContext.Session.GetInt32("AppliedCouponID");
            Coupon? coupon = null;
            if (couponId.HasValue)
            {
                coupon = await _context.Coupons.FindAsync(couponId.Value);
            }

            // Generate order number
            int nextOrderNumber = 1;
            if (await _context.Orders.AnyAsync())
            {
                nextOrderNumber = await _context.Orders.MaxAsync(o => o.OrderNumber) + 1;
            }

            // Create order
            var order = new Order
            {
                OrderNumber = nextOrderNumber,
                OrderDate = DateTime.Now,
                OrderStatus = OrderStatusEnum.Pending,
                CustomerID = user.Id,
                CardID = cardId,
                CouponID = couponId
            };

            // Calculate shipping
            order.ShippingFee = cart.CalculateShipping();

            // Apply free shipping coupon if applicable
            if (coupon != null && coupon.CouponType == CouponTypeEnum.FreeShipping)
            {
                if (coupon.FreeThreshold == null || cart.Subtotal >= coupon.FreeThreshold.Value)
                {
                    order.ShippingFee = 0;
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Create order details and update inventory
            foreach (var item in cart.Items)
            {
                var book = await _context.Books.FindAsync(item.BookID);
                if (book != null)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderID = order.OrderID,
                        BookID = item.BookID,
                        Price = item.Price,
                        Cost = book.Cost,
                        Quantity = item.Quantity
                    };
                    _context.OrderDetails.Add(orderDetail);

                    // Deduct inventory
                    book.InventoryQuantity -= item.Quantity;
                }
            }

            await _context.SaveChangesAsync();

            // Clear cart and coupon
            HttpContext.Session.ClearCart();
            HttpContext.Session.Remove("AppliedCouponID");

            return RedirectToAction("Confirmation", new { orderId = order.OrderID });
        }

        // GET: ShoppingCart/Confirmation
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Confirmation(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.Genre)
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);

            if (order == null)
            {
                return NotFound();
            }

            // Verify the order belongs to the current user
            var username = User.Identity?.Name;
            if (order.Customer.UserName != username)
            {
                return Forbid();
            }

            // Get recommendations based on purchased books
            var purchasedBookIds = order.OrderDetails.Select(od => od.BookID).ToList();
            var purchasedGenreIds = order.OrderDetails
                .Where(od => od.Book != null)
                .Select(od => od.Book.GenreID)
                .Distinct()
                .ToList();

            var recommendations = await _context.Books
                .Include(b => b.Reviews)
                .Where(b => !purchasedBookIds.Contains(b.BookID)
                    && purchasedGenreIds.Contains(b.GenreID)
                    && b.BookStatus == BookStatusEnum.Active
                    && b.InventoryQuantity > 0)
                .OrderByDescending(b => b.Reviews.Any() ? b.Reviews.Average(r => r.Rating) : 0)
                .Take(3)
                .ToListAsync();

            var viewModel = new OrderConfirmationViewModel
            {
                Order = order,
                RecommendedBooks = recommendations
            };

            // Send order confirmation email with recommendations
            await _emailService.SendOrderConfirmationEmailAsync(
                order.Customer.Email,
                order.Customer.FirstName,
                order,
                recommendations
            );

            return View(viewModel);
        }

        // Helper method to get cart item count for navbar
        public static int GetCartItemCount(ISession session)
        {
            return session.GetCart().TotalItems;
        }
    }
}
