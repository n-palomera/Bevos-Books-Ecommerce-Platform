using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string searchString, int? genreId, string sortOrder, bool inStockOnly = false)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentGenre"] = genreId;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["InStockOnly"] = inStockOnly;

            var books = _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reviews)
                .Include(b => b.OrderDetails)
                .AsQueryable();

            // Get total count before filtering
            int totalBooks = await _context.Books.CountAsync();

            // Search by title, author, unique number, or genre
            if (!String.IsNullOrEmpty(searchString))
            {
                // Try to parse as BookNumber (unique number)
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

            // Filter by in stock only
            if (inStockOnly)
            {
                books = books.Where(b => b.InStock);
            }

            // Sorting
            switch (sortOrder)
            {
                case "title":
                    books = books.OrderBy(b => b.Title);
                    break;
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "author":
                    books = books.OrderBy(b => b.Authors);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(b => b.Authors);
                    break;
                case "popular":
                    // Most popular = total number of times purchased
                    books = books.OrderByDescending(b => b.OrderDetails.Sum(od => od.Quantity));
                    break;
                case "newest":
                    // Newest first based on publication date
                    books = books.OrderByDescending(b => b.PublishDate);
                    break;
                case "oldest":
                    // Oldest first based on publication date
                    books = books.OrderBy(b => b.PublishDate);
                    break;
                case "rating":
                    // Highest rated
                    books = books.OrderByDescending(b => b.AverageRating);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            var bookList = await books.ToListAsync();

            // Record count for display
            ViewBag.RecordCount = $"Showing {bookList.Count} of {totalBooks} Books";

            // Get all genres for filter dropdown
            ViewBag.Genres = await _context.Genres.OrderBy(g => g.GenreName).ToListAsync();

            return View(bookList);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.Reviewer)
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // Check if logged-in user can write a review
            ViewData["CanReview"] = false;
            ViewData["HasReviewed"] = false;
            ViewData["HasPurchased"] = false;

            if (User.Identity?.IsAuthenticated == true && User.IsInRole("Customer"))
            {
                var username = User.Identity.Name;
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

                if (user != null)
                {
                    // Check if user has purchased this book
                    var hasPurchased = await _context.OrderDetails
                        .AnyAsync(od => od.BookID == id && od.Order.CustomerID == user.Id);
                    ViewData["HasPurchased"] = hasPurchased;

                    // Check if user has already reviewed this book
                    var hasReviewed = await _context.Reviews
                        .AnyAsync(r => r.BookID == id && r.ReviewerID == user.Id);
                    ViewData["HasReviewed"] = hasReviewed;

                    // User can review if purchased and not yet reviewed
                    ViewData["CanReview"] = hasPurchased && !hasReviewed;
                }
            }

            return View(book);
        }

        // GET: Books/Create (Admin only)
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            // Get next book number (must be consecutive starting from 222001)
            var maxBookNumber = await _context.Books.MaxAsync(b => (int?)b.BookNumber) ?? 222000;
            ViewBag.NextBookNumber = maxBookNumber + 1;

            // Get genres for dropdown
            ViewData["GenreID"] = new SelectList(await _context.Genres.OrderBy(g => g.GenreName).ToListAsync(), "GenreID", "GenreName");

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Title,Description,Price,Cost,PublishDate,InventoryQuantity,ReorderPoint,Authors,GenreID")] Book book, string newGenre)
        {
            // Handle new genre creation
            if (!string.IsNullOrWhiteSpace(newGenre))
            {
                var existingGenre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreName == newGenre);
                if (existingGenre == null)
                {
                    var genre = new Genre { GenreName = newGenre };
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync();
                    book.GenreID = genre.GenreID;
                }
                else
                {
                    book.GenreID = existingGenre.GenreID;
                }
            }

            if (ModelState.IsValid)
            {
                // Set consecutive book number
                var maxBookNumber = await _context.Books.MaxAsync(b => (int?)b.BookNumber) ?? 222000;
                book.BookNumber = maxBookNumber + 1;

                // Set default status
                book.BookStatus = BookStatusEnum.Active;

                _context.Add(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Book '{book.Title}' has been added successfully with Book Number {book.BookNumber}.";
                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdown on error
            ViewData["GenreID"] = new SelectList(await _context.Genres.OrderBy(g => g.GenreName).ToListAsync(), "GenreID", "GenreName", book.GenreID);
            return View(book);
        }

        // GET: Books/Edit/5 (Admin only)
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Reorders)
                .Include(b => b.OrderDetails)
                .FirstOrDefaultAsync(b => b.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // Calculate last cost paid and profit margin for display
            var lastReorder = book.Reorders.OrderByDescending(r => r.Date).FirstOrDefault();
            ViewBag.LastCostPaid = lastReorder?.Cost ?? book.Cost;

            var orderDetails = book.OrderDetails.ToList();
            ViewBag.AverageProfitMargin = orderDetails.Any()
                ? orderDetails.Average(od => od.Price - od.Cost)
                : 0m;

            ViewData["GenreID"] = new SelectList(await _context.Genres.OrderBy(g => g.GenreName).ToListAsync(), "GenreID", "GenreName", book.GenreID);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,BookNumber,Title,Description,Price,Cost,PublishDate,InventoryQuantity,ReorderPoint,Authors,BookStatus,GenreID")] Book book, string newGenre)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            // Handle new genre creation
            if (!string.IsNullOrWhiteSpace(newGenre))
            {
                var existingGenre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreName == newGenre);
                if (existingGenre == null)
                {
                    var genre = new Genre { GenreName = newGenre };
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync();
                    book.GenreID = genre.GenreID;
                }
                else
                {
                    book.GenreID = existingGenre.GenreID;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Book '{book.Title}' has been updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["GenreID"] = new SelectList(await _context.Genres.OrderBy(g => g.GenreName).ToListAsync(), "GenreID", "GenreName", book.GenreID);
            return View(book);
        }

        // GET: Books/Discontinue/5 (Admin only)
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Discontinue(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Discontinue/5
        [HttpPost, ActionName("Discontinue")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DiscontinueConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.BookStatus = BookStatusEnum.Discontinued;
                _context.Update(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Book '{book.Title}' has been discontinued.";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Books/Reactivate/5 (Admin only)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reactivate(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.BookStatus = BookStatusEnum.Active;
                _context.Update(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Book '{book.Title}' has been reactivated.";
            }
            return RedirectToAction(nameof(Index));
        }

        // Helper method
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
