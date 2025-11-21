using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CustomersController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            // Get all users with Customer role
            var allUsers = await _userManager.Users.ToListAsync();
            var customers = new List<AppUser>();

            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer"))
                {
                    customers.Add(user);
                }
            }

            // Search by name or email
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c =>
                    (c.FirstName + " " + c.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || c.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Order by last name
            customers = customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            // Record count for display
            ViewBag.RecordCount = $"Showing {customers.Count} Customers";

            return View(customers);
        }
    }
}
