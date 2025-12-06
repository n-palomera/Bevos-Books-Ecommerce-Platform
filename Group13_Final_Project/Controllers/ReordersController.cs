using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;

namespace Group13_Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReordersController : Controller
    {
        private readonly AppDbContext _context;

        public ReordersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reorders/OrderMethod - Choose manual or automatic ordering
        public IActionResult Index()
        {
            return View();
        }

        //  MANUAL ORDERING 

        // GET: Reorders/ManualOrder - Manual book ordering
        public async Task<IActionResult> ManualOrder(string searchString, int? genreId, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentGenre"] = genreId;
            ViewData["CurrentSort"] = sortOrder;

            var books = _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reorders)
                .Include(b => b.OrderDetails)
                .AsQueryable();

            int totalBooks = await _context.Books.CountAsync();

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                if (int.TryParse(searchString, out int bookNumber))
                {
                    books = books.Where(b => b.Title.Contains(searchString)
                        || b.Authors.Contains(searchString)
                        || b.BookNumber == bookNumber);
                }
                else
                {
                    books = books.Where(b => b.Title.Contains(searchString)
                        || b.Authors.Contains(searchString));
                }
            }

            // Filter by genre
            if (genreId.HasValue)
            {
                books = books.Where(b => b.GenreID == genreId.Value);
            }

            // Sorting
            switch (sortOrder)
            {
                case "title":
                    books = books.OrderBy(b => b.Title);
                    break;
                case "author":
                    books = books.OrderBy(b => b.Authors);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            var bookList = await books.ToListAsync();

            ViewBag.RecordCount = $"Showing {bookList.Count} of {totalBooks} Books";
            ViewBag.Genres = await _context.Genres.OrderBy(g => g.GenreName).ToListAsync();

            return View(bookList);
        }

        // GET: Reorders/CreateManual/5
        public async Task<IActionResult> CreateManual(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reorders)
                .Include(b => b.OrderDetails)
                .FirstOrDefaultAsync(b => b.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // Get last cost paid
            var lastReorder = book.Reorders.OrderByDescending(r => r.Date).FirstOrDefault();
            var defaultCost = lastReorder?.Cost ?? book.Cost;

            // Calculate average profit margin
            var orderDetails = book.OrderDetails.ToList();
            ViewBag.AverageProfitMargin = orderDetails.Any()
                ? orderDetails.Average(od => od.Price - od.Cost)
                : 0m;

            ViewBag.Book = book;
            ViewBag.DefaultCost = defaultCost;

            var reorder = new Reorder
            {
                BookID = book.BookID,
                Cost = defaultCost,
                Quantity = 5,
                Date = DateTime.Now
            };

            return View(reorder);
        }

        // POST: Reorders/CreateManual
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateManual([Bind("BookID,Cost,Quantity")] Reorder reorder)
        {
            if (reorder.Cost <= 0)
            {
                ModelState.AddModelError("Cost", "Cost must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                reorder.Date = DateTime.Now;
                reorder.ReorderStatus = ReorderStatusEnum.Pending;
                reorder.QuantityReceived = 0;

                _context.Add(reorder);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Reorder placed successfully.";
                return RedirectToAction(nameof(ViewOrders));
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.BookID == reorder.BookID);
            ViewBag.Book = book;

            return View(reorder);
        }

        // AUTOMATIC ORDERING

        // GET: Reorders/AutomaticOrder
        public async Task<IActionResult> AutomaticOrder()
        {
            var books = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reorders)
                .ToListAsync();

            var booksBelowReorder = new List<ReorderViewModel>();

            foreach (var book in books)
            {
                // Calculate pending order quantity
                var pendingQuantity = book.Reorders
                    .Where(r => r.ReorderStatus == ReorderStatusEnum.Pending ||
                               r.ReorderStatus == ReorderStatusEnum.PartiallyReceived)
                    .Sum(r => r.RemainingQuantity);

                // Effective inventory = current + pending orders
                var effectiveInventory = book.InventoryQuantity + pendingQuantity;

                // If below reorder point, add to list
                if (effectiveInventory < book.ReorderPoint)
                {
                    var lastCost = book.Reorders.OrderByDescending(r => r.Date).FirstOrDefault()?.Cost ?? book.Cost;

                    booksBelowReorder.Add(new ReorderViewModel
                    {
                        BookID = book.BookID,
                        BookTitle = book.Title,
                        BookNumber = book.BookNumber,
                        Authors = book.Authors,
                        GenreName = book.Genre.GenreName,
                        CurrentInventory = book.InventoryQuantity,
                        ReorderPoint = book.ReorderPoint,
                        PendingQuantity = pendingQuantity,
                        Quantity = 5,
                        Cost = lastCost
                    });
                }
            }

            return View(booksBelowReorder);
        }

        // POST: Reorders/ProcessAutomatic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessAutomatic(List<ReorderViewModel> reorders)
        {
            if (reorders == null || !reorders.Any())
            {
                TempData["ErrorMessage"] = "No books selected for reorder.";
                return RedirectToAction(nameof(AutomaticOrder));
            }

            int ordersPlaced = 0;

            foreach (var reorderVM in reorders)
            {
                if (reorderVM.Quantity > 0 && reorderVM.Cost > 0)
                {
                    var reorder = new Reorder
                    {
                        BookID = reorderVM.BookID,
                        Cost = reorderVM.Cost,
                        Quantity = reorderVM.Quantity,
                        Date = DateTime.Now,
                        ReorderStatus = ReorderStatusEnum.Pending,
                        QuantityReceived = 0
                    };

                    _context.Reorders.Add(reorder);
                    ordersPlaced++;
                }
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"{ordersPlaced} automatic reorder(s) placed successfully.";
            return RedirectToAction(nameof(ViewOrders));
        }

        // VIEW & RECEIVE ORDERS 

        // GET: Reorders/ViewOrders
        public async Task<IActionResult> ViewOrders()
        {
            var reorders = await _context.Reorders
                .Include(r => r.Book)
                    .ThenInclude(b => b.Genre)
                .Where(r => r.ReorderStatus == ReorderStatusEnum.Pending ||
                           r.ReorderStatus == ReorderStatusEnum.PartiallyReceived)
                .OrderByDescending(r => r.Date)
                .ToListAsync();

            return View(reorders);
        }

        // GET: Reorders/Receive
        public async Task<IActionResult> Receive()
        {
            var reorders = await _context.Reorders
                .Include(r => r.Book)
                    .ThenInclude(b => b.Genre)
                .Where(r => r.ReorderStatus == ReorderStatusEnum.Pending ||
                           r.ReorderStatus == ReorderStatusEnum.PartiallyReceived)
                .OrderByDescending(r => r.Date)
                .ToListAsync();

            return View(reorders);
        }

        // GET: Reorders/ReceiveBook/5
        public async Task<IActionResult> ReceiveBook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorder = await _context.Reorders
                .Include(r => r.Book)
                    .ThenInclude(b => b.Genre)
                .FirstOrDefaultAsync(r => r.ReorderID == id);

            if (reorder == null)
            {
                return NotFound();
            }

            return View(reorder);
        }

        // POST: Reorders/ReceiveBook/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReceiveBook(int id, int quantityReceived)
        {
            var reorder = await _context.Reorders
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.ReorderID == id);

            if (reorder == null)
            {
                return NotFound();
            }

            // Validate quantity
            if (quantityReceived <= 0)
            {
                ModelState.AddModelError("", "Quantity received must be greater than zero.");
                return View(reorder);
            }

            // Only allow up to the ordered quantity (per requirements)
            if (quantityReceived > reorder.RemainingQuantity)
            {
                quantityReceived = reorder.RemainingQuantity;
            }

            // Update reorder
            reorder.QuantityReceived += quantityReceived;

            // Update book inventory
            reorder.Book.InventoryQuantity += quantityReceived;

            // Update reorder status
            if (reorder.QuantityReceived >= reorder.Quantity)
            {
                reorder.ReorderStatus = ReorderStatusEnum.Received;
            }
            else
            {
                reorder.ReorderStatus = ReorderStatusEnum.PartiallyReceived;
            }

            _context.Update(reorder);
            _context.Update(reorder.Book);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Received {quantityReceived} copies of '{reorder.Book.Title}'. Inventory updated.";
            return RedirectToAction(nameof(Receive));
        }
    }

    // ViewModel for automatic reorder
    public class ReorderViewModel
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public int BookNumber { get; set; }
        public string Authors { get; set; }
        public string GenreName { get; set; }
        public int CurrentInventory { get; set; }
        public int ReorderPoint { get; set; }
        public int PendingQuantity { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}