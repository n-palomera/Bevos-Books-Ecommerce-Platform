using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public ReviewsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reviews (Employee/Admin view all reviews)
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Index(string searchString, string statusFilter, string tab)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = statusFilter;
            ViewData["ActiveTab"] = tab ?? "all";

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

            // Get current user's approval history for the "My Approvals" tab
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var myApprovals = await _context.Reviews
                    .Include(r => r.Book)
                    .Include(r => r.Reviewer)
                    .Where(r => r.ApproverID == currentUser.Id &&
                        (r.DisputeStatus == DisputeStatusEnum.Approved || r.DisputeStatus == DisputeStatusEnum.Rejected))
                    .OrderByDescending(r => r.ReviewID)
                    .ToListAsync();

                ViewBag.MyApprovals = myApprovals;
                ViewBag.MyApprovedCount = myApprovals.Count(r => r.DisputeStatus == DisputeStatusEnum.Approved);
                ViewBag.MyRejectedCount = myApprovals.Count(r => r.DisputeStatus == DisputeStatusEnum.Rejected);
            }
            else
            {
                ViewBag.MyApprovals = new List<Review>();
                ViewBag.MyApprovedCount = 0;
                ViewBag.MyRejectedCount = 0;
            }

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

        // POST: Reviews/Approve/5 (Employee approves a review)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            // Get current employee
            var username = User.Identity.Name;
            var employee = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            review.DisputeStatus = DisputeStatusEnum.Approved;
            review.ApproverID = employee?.Id;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Review has been approved.";
            return RedirectToAction(nameof(Index));
        }

        // POST: Reviews/Reject/5 (Employee rejects a review)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            // Get current employee
            var username = User.Identity.Name;
            var employee = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            review.DisputeStatus = DisputeStatusEnum.Rejected;
            review.ApproverID = employee?.Id;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Review has been rejected.";
            return RedirectToAction(nameof(Index));
        }

        // GET: Reviews/Edit/5 (Employee edits review text - NOT rating)
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Book)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            var viewModel = new EditReviewViewModel
            {
                ReviewID = review.ReviewID,
                BookTitle = review.Book?.Title,
                BookAuthor = review.Book?.Authors,
                ReviewerName = $"{review.Reviewer?.FirstName} {review.Reviewer?.LastName}",
                Rating = review.Rating,
                ReviewText = review.ReviewText,
                DisputeStatus = review.DisputeStatus
            };

            return View(viewModel);
        }

        // POST: Reviews/Edit/5 (Employee submits edited review text)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> Edit(int id, EditReviewViewModel viewModel)
        {
            if (id != viewModel.ReviewID)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Get current employee
                var username = User.Identity.Name;
                var employee = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

                // Only update the review text - NOT the rating
                review.ReviewText = viewModel.ReviewText;
                review.DisputeStatus = viewModel.DisputeStatus;
                review.ApproverID = employee?.Id;

                await _context.SaveChangesAsync();

                TempData["Success"] = "Review has been updated.";
                return RedirectToAction(nameof(Index));
            }

            // Reload book/reviewer info if validation fails
            var fullReview = await _context.Reviews
                .Include(r => r.Book)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            viewModel.BookTitle = fullReview?.Book?.Title;
            viewModel.BookAuthor = fullReview?.Book?.Authors;
            viewModel.ReviewerName = $"{fullReview?.Reviewer?.FirstName} {fullReview?.Reviewer?.LastName}";
            viewModel.Rating = fullReview?.Rating ?? 0;

            return View(viewModel);
        }

        // GET: Reviews/ApprovalHistory (Shows reviews approved/rejected by current employee/admin)
        [Authorize(Roles = "Employee,Admin")]
        public async Task<IActionResult> ApprovalHistory(string statusFilter, string sortOrder)
        {
            ViewData["CurrentStatus"] = statusFilter;
            ViewData["DateSort"] = string.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewData["BookSort"] = sortOrder == "book" ? "book_desc" : "book";
            ViewData["CurrentSort"] = sortOrder;

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var reviewsQuery = _context.Reviews
                .Include(r => r.Book)
                .Include(r => r.Reviewer)
                .Where(r => r.ApproverID == currentUser.Id)
                .AsQueryable();

            // Filter by status
            if (!string.IsNullOrEmpty(statusFilter))
            {
                if (statusFilter == "Approved")
                {
                    reviewsQuery = reviewsQuery.Where(r => r.DisputeStatus == DisputeStatusEnum.Approved);
                }
                else if (statusFilter == "Rejected")
                {
                    reviewsQuery = reviewsQuery.Where(r => r.DisputeStatus == DisputeStatusEnum.Rejected);
                }
            }
            else
            {
                // By default, show only approved or rejected (not pending)
                reviewsQuery = reviewsQuery.Where(r =>
                    r.DisputeStatus == DisputeStatusEnum.Approved ||
                    r.DisputeStatus == DisputeStatusEnum.Rejected);
            }

            var reviews = await reviewsQuery.ToListAsync();

            // Apply sorting
            reviews = sortOrder switch
            {
                "date_asc" => reviews.OrderBy(r => r.ReviewID).ToList(),
                "book" => reviews.OrderBy(r => r.Book?.Title).ToList(),
                "book_desc" => reviews.OrderByDescending(r => r.Book?.Title).ToList(),
                _ => reviews.OrderByDescending(r => r.ReviewID).ToList() // Default: most recent first
            };

            ViewBag.RecordCount = $"Showing {reviews.Count} Reviews";
            ViewBag.ApprovedCount = reviews.Count(r => r.DisputeStatus == DisputeStatusEnum.Approved);
            ViewBag.RejectedCount = reviews.Count(r => r.DisputeStatus == DisputeStatusEnum.Rejected);

            return View(reviews);
        }
    }
}