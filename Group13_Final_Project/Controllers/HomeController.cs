using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;

namespace Group13_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Home/
        public async Task<IActionResult> Index()
        {
            // Get active coupons to display on home page
            var activeCoupons = await _context.Coupons
                .Where(c => c.Status == true)
                .ToListAsync();

            // Get featured books (top rated, in stock)
            var featuredBooks = await _context.Books
                .Include(b => b.Reviews)
                .Include(b => b.Genre)
                .Where(b => b.BookStatus == BookStatusEnum.Active && b.InventoryQuantity > 0)
                .ToListAsync();

            // Sort by average rating in memory (since AverageRating is computed)
            var topRatedBooks = featuredBooks
                .OrderByDescending(b => b.AverageRating)
                .Take(6)
                .ToList();

            // Get newest arrivals
            var newArrivals = await _context.Books
                .Include(b => b.Genre)
                .Where(b => b.BookStatus == BookStatusEnum.Active && b.InventoryQuantity > 0)
                .OrderByDescending(b => b.PublishDate)
                .Take(6)
                .ToListAsync();

            ViewBag.ActiveCoupons = activeCoupons;
            ViewBag.FeaturedBooks = topRatedBooks;
            ViewBag.NewArrivals = newArrivals;

            return View();
        }
    }
}
