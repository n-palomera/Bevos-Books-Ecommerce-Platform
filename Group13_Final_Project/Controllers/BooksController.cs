using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
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
    }
}
