using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;

namespace Group13_Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CouponsController : Controller
    {
        private readonly AppDbContext _context;

        public CouponsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Coupons
        public async Task<IActionResult> Index(string searchString, string typeFilter, string statusFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentType"] = typeFilter;
            ViewData["CurrentStatus"] = statusFilter;

            var couponsQuery = _context.Coupons.AsQueryable();

            // Search by coupon code
            if (!string.IsNullOrEmpty(searchString))
            {
                couponsQuery = couponsQuery.Where(c => c.CouponCode.Contains(searchString));
            }

            // Filter by type
            if (!string.IsNullOrEmpty(typeFilter) && Enum.TryParse<CouponTypeEnum>(typeFilter, out var couponType))
            {
                couponsQuery = couponsQuery.Where(c => c.CouponType == couponType);
            }

            // Filter by status
            if (!string.IsNullOrEmpty(statusFilter))
            {
                bool isActive = statusFilter == "Active";
                couponsQuery = couponsQuery.Where(c => c.Status == isActive);
            }

            var coupons = await couponsQuery.OrderBy(c => c.CouponCode).ToListAsync();

            // Get usage counts for each coupon
            var usageCounts = await _context.Orders
                .Where(o => o.CouponID != null)
                .GroupBy(o => o.CouponID)
                .Select(g => new { CouponID = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.CouponID ?? 0, x => x.Count);

            ViewBag.UsageCounts = usageCounts;
            ViewBag.RecordCount = $"Showing {coupons.Count} Coupons";

            return View(coupons);
        }

        // GET: Coupons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            // Check if coupon code already exists
            if (await _context.Coupons.AnyAsync(c => c.CouponCode == coupon.CouponCode))
            {
                ModelState.AddModelError("CouponCode", "A coupon with this code already exists.");
            }

            // Validate coupon type specific fields
            if (coupon.CouponType == CouponTypeEnum.PercentOff)
            {
                if (!coupon.DiscountPercent.HasValue || coupon.DiscountPercent <= 0 || coupon.DiscountPercent > 100)
                {
                    ModelState.AddModelError("DiscountPercent", "Discount percent must be between 1 and 100.");
                }
                // Clear free threshold for percent off coupons
                coupon.FreeThreshold = null;
            }
            else if (coupon.CouponType == CouponTypeEnum.FreeShipping)
            {
                // Free threshold can be null (free shipping for all orders) or a positive value
                if (coupon.FreeThreshold.HasValue && coupon.FreeThreshold < 0)
                {
                    ModelState.AddModelError("FreeThreshold", "Free shipping threshold must be positive or empty for all orders.");
                }
                // Clear discount percent for free shipping coupons
                coupon.DiscountPercent = null;
            }

            if (!ModelState.IsValid)
            {
                return View(coupon);
            }

            coupon.Status = true; // New coupons are active by default
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Coupon '{coupon.CouponCode}' created successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Coupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .Include(c => c.Orders)
                    .ThenInclude(o => o.Customer)
                .FirstOrDefaultAsync(c => c.CouponID == id);

            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Coupons/ToggleStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }

            coupon.Status = !coupon.Status;
            await _context.SaveChangesAsync();

            string statusText = coupon.Status ? "enabled" : "disabled";
            TempData["Success"] = $"Coupon '{coupon.CouponCode}' has been {statusText}.";

            return RedirectToAction(nameof(Index));
        }
    }
}
