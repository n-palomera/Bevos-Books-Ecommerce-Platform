using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
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

        // GET: Reviews
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
    }
}
