using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Group13_Final_Project.Utilities;
using System;
using System.Linq;

namespace Group13_Final_Project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid == false)
            {
                return View(rvm);
            }

            // Map RegisterViewModel to AppUser
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                Address = rvm.Address,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                Birthday = rvm.Birthday,
                Status = true
            };

            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,
                RoleName = "Customer"
            };

            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded)
            {
                // TODO: Send welcome email here

                // Sign in the new user
                Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(rvm);
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                return View(lvm);
            }

            // Check if user account is disabled
            AppUser user = await _userManager.FindByEmailAsync(lvm.Email);
            if (user != null && !user.Status)
            {
                ModelState.AddModelError("", "Your account has been disabled. Please contact support.");
                return View(lvm);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(lvm);
            }
        }

        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        // GET: Account/Index
        public async Task<IActionResult> Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            String id = User.Identity.Name;
            AppUser user = await _context.Users
                .Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.UserName == id);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.PhoneNumber = user.PhoneNumber;
            ivm.Address = user.Address;
            ivm.City = user.City;
            ivm.State = user.State;
            ivm.ZipCode = user.ZipCode;
            ivm.Birthday = user.Birthday;
            ivm.CardCount = user.Cards?.Count ?? 0;

            return View(ivm);
        }

        // GET: Account/Edit
        public async Task<IActionResult> Edit()
        {
            String id = User.Identity.Name;
            AppUser user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == id);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            EditProfileViewModel epvm = new EditProfileViewModel
            {
                UserID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                State = user.State,
                ZipCode = user.ZipCode,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday,
                Email = user.Email
            };

            return View(epvm);
        }

        // POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileViewModel epvm)
        {
            if (ModelState.IsValid == false)
            {
                return View(epvm);
            }

            AppUser user = await _context.Users.FirstOrDefaultAsync(u => u.Id == epvm.UserID);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Update allowed fields (email cannot be changed per requirements)
            user.FirstName = epvm.FirstName;
            user.LastName = epvm.LastName;
            user.Address = epvm.Address;
            user.City = epvm.City;
            user.State = epvm.State;
            user.ZipCode = epvm.ZipCode;
            user.PhoneNumber = epvm.PhoneNumber;
            user.Birthday = epvm.Birthday;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            if (result.Succeeded)
            {
                // TODO: Send password change confirmation email here

                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(cpvm);
            }
        }

        // GET: Account/OrderHistory
        public async Task<IActionResult> OrderHistory(DateTime? startDate, DateTime? endDate, string statusFilter)
        {
            String username = User.Identity.Name;
            AppUser user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var ordersQuery = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .Where(o => o.CustomerID == user.Id);

            // Apply date filters
            if (startDate.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.OrderDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.OrderDate <= endDate.Value);
            }

            // Apply status filter
            if (!string.IsNullOrEmpty(statusFilter) && Enum.TryParse<OrderStatusEnum>(statusFilter, out var status))
            {
                ordersQuery = ordersQuery.Where(o => o.OrderStatus == status);
            }

            var orders = await ordersQuery.OrderByDescending(o => o.OrderDate).ToListAsync();

            OrderHistoryViewModel ohvm = new OrderHistoryViewModel
            {
                Orders = orders,
                StartDate = startDate,
                EndDate = endDate,
                StatusFilter = statusFilter
            };

            return View(ohvm);
        }

        // GET: Account/MyCards
        public async Task<IActionResult> MyCards()
        {
            String username = User.Identity.Name;
            AppUser user = await _context.Users
                .Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user.Cards);
        }

        // GET: Account/Recommendations
        public async Task<IActionResult> Recommendations(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.Genre)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);

            if (order == null)
            {
                return NotFound();
            }

            // Get the first book from the order for recommendations
            var purchasedBook = order.OrderDetails.FirstOrDefault()?.Book;

            if (purchasedBook == null)
            {
                return RedirectToAction("OrderHistory");
            }

            // Get customer's purchase history
            String username = User.Identity.Name;
            AppUser user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            var customerBookIds = await _context.OrderDetails
                .Where(od => od.Order.CustomerID == user.Id)
                .Select(od => od.BookID)
                .Distinct()
                .ToListAsync();

            List<Book> recommendations = new List<Book>();

            // 1. Same author, same genre, not purchased
            var sameAuthorGenre = await _context.Books
                .Include(b => b.Reviews)
                .Where(b => b.Authors == purchasedBook.Authors
                    && b.GenreID == purchasedBook.GenreID
                    && b.BookID != purchasedBook.BookID
                    && !customerBookIds.Contains(b.BookID)
                    && b.BookStatus == BookStatusEnum.Active)
                .OrderByDescending(b => b.AverageRating)
                .FirstOrDefaultAsync();

            if (sameAuthorGenre != null)
            {
                recommendations.Add(sameAuthorGenre);
            }

            // 2. Highly rated books in same genre (rating >= 4.0)
            int needed = 3 - recommendations.Count;
            if (needed > 0)
            {
                var highlyRated = await _context.Books
                    .Include(b => b.Reviews)
                    .Where(b => b.GenreID == purchasedBook.GenreID
                        && b.BookID != purchasedBook.BookID
                        && !customerBookIds.Contains(b.BookID)
                        && !recommendations.Select(r => r.BookID).Contains(b.BookID)
                        && b.BookStatus == BookStatusEnum.Active)
                    .ToListAsync();

                var highRatedFiltered = highlyRated
                    .Where(b => b.AverageRating >= 4.0m)
                    .GroupBy(b => b.Authors)
                    .Select(g => g.OrderByDescending(b => b.AverageRating).First())
                    .Take(needed)
                    .ToList();

                recommendations.AddRange(highRatedFiltered);
            }

            // 3. Low/no rating in same genre
            needed = 3 - recommendations.Count;
            if (needed > 0)
            {
                var lowRated = await _context.Books
                    .Include(b => b.Reviews)
                    .Where(b => b.GenreID == purchasedBook.GenreID
                        && b.BookID != purchasedBook.BookID
                        && !customerBookIds.Contains(b.BookID)
                        && !recommendations.Select(r => r.BookID).Contains(b.BookID)
                        && b.BookStatus == BookStatusEnum.Active)
                    .OrderBy(b => b.AverageRating)
                    .Take(needed)
                    .ToListAsync();

                recommendations.AddRange(lowRated);
            }

            // 4. Highest rated books overall
            needed = 3 - recommendations.Count;
            if (needed > 0)
            {
                var anyHighRated = await _context.Books
                    .Include(b => b.Reviews)
                    .Where(b => b.BookID != purchasedBook.BookID
                        && !customerBookIds.Contains(b.BookID)
                        && !recommendations.Select(r => r.BookID).Contains(b.BookID)
                        && b.BookStatus == BookStatusEnum.Active)
                    .ToListAsync();

                var topRated = anyHighRated
                    .OrderByDescending(b => b.AverageRating)
                    .Take(needed)
                    .ToList();

                recommendations.AddRange(topRated);
            }

            RecommendationsViewModel rvm = new RecommendationsViewModel
            {
                OrderID = orderId,
                RecommendedBooks = recommendations.Take(3).ToList()
            };

            return View(rvm);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}