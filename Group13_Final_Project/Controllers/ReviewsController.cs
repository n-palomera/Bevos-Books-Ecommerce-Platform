using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reviews (Employee/Admin view all reviews)
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Index(string searchString, string statusFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = statusFilter;

            var reviews = _context.Reviews
                .Include(r => r.Reviewer)
                .Include(r => r.Book)
                .AsQueryable();

            // Search by reviewer name or book title
            if (!String.IsNullOrEmpty(searchString))
            {
                reviews = reviews.Where(r =>
                    (r.Reviewer.FirstName + " " + r.Reviewer.LastName).Contains(searchString)
                    || r.Book.Title.Contains(searchString));
            }

            // Filter by dispute status
            if (!String.IsNullOrEmpty(statusFilter))
            {
                switch (statusFilter.ToLower())
                {
                    case "approved":
                        reviews = reviews.Where(r => r.DisputeStatus == DisputeStatusEnum.Approved);
                        break;
                    case "pending":
                        reviews = reviews.Where(r => r.DisputeStatus == DisputeStatusEnum.Pending);
                        break;
                    case "rejected":
                        reviews = reviews.Where(r => r.DisputeStatus == DisputeStatusEnum.Rejected);
                        break;
                }
            }

            // Order by most recent first
            reviews = reviews.OrderByDescending(r => r.ReviewID);

            var reviewList = await reviews.ToListAsync();

            // Record count for display
            ViewBag.RecordCount = $"Showing {reviewList.Count} Reviews";

            return View(reviewList);
        }

        // GET: Reviews/Create/5 (Customer writes review)
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // Get current user
            var username = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if user has purchased this book
            var hasPurchased = await _context.OrderDetails
                .AnyAsync(od => od.BookID == id && od.Order.CustomerID == user.Id);

            if (!hasPurchased)
            {
                TempData["Error"] = "You can only review books you have purchased.";
                return RedirectToAction("Details", "Books", new { id = id });
            }

            // Check if user has already reviewed this book
            var existingReview = await _context.Reviews
                .AnyAsync(r => r.BookID == id && r.ReviewerID == user.Id);

            if (existingReview)
            {
                TempData["Error"] = "You have already reviewed this book.";
                return RedirectToAction("Details", "Books", new { id = id });
            }

            CreateReviewViewModel crvm = new CreateReviewViewModel
            {
                BookID = book.BookID,
                BookTitle = book.Title,
                BookAuthor = book.Authors
            };

            return View(crvm);
        }

        // POST: Reviews/Create (Customer submits review)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(CreateReviewViewModel crvm)
        {
            // Get current user
            var username = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Verify user has purchased the book
            var hasPurchased = await _context.OrderDetails
                .AnyAsync(od => od.BookID == crvm.BookID && od.Order.CustomerID == user.Id);

            if (!hasPurchased)
            {
                ModelState.AddModelError("", "You can only review books you have purchased.");
            }

            // Check if user has already reviewed this book
            var existingReview = await _context.Reviews
                .AnyAsync(r => r.BookID == crvm.BookID && r.ReviewerID == user.Id);

            if (existingReview)
            {
                ModelState.AddModelError("", "You have already reviewed this book.");
            }

            if (ModelState.IsValid)
            {
                Review review = new Review
                {
                    BookID = crvm.BookID,
                    ReviewerID = user.Id,
                    Rating = crvm.Rating,
                    ReviewText = crvm.ReviewText,
                    DisputeStatus = DisputeStatusEnum.Pending
                };

                _context.Add(review);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Your review has been submitted and is pending approval!";
                return RedirectToAction("Details", "Books", new { id = crvm.BookID });
            }

            // Reload book info for the view
            var book = await _context.Books.FindAsync(crvm.BookID);
            crvm.BookTitle = book?.Title;
            crvm.BookAuthor = book?.Authors;

            return View(crvm);
        }

        // GET: Reviews/MyReviews (Customer views their own reviews)
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> MyReviews()
        {
            var username = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var reviews = await _context.Reviews
                .Include(r => r.Book)
                .Include(r => r.Approver)
                .Where(r => r.ReviewerID == user.Id)
                .OrderByDescending(r => r.ReviewID)
                .ToListAsync();

            return View(reviews);
        }
    }
}