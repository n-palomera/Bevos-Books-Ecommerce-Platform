using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployeesController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString, string roleFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentRole"] = roleFilter;

            // Get all users with Employee or Manager role
            var allUsers = await _userManager.Users.ToListAsync();
            var employees = new List<(AppUser User, string Role)>();

            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Employee"))
                {
                    employees.Add((user, "Employee"));
                }
                else if (await _userManager.IsInRoleAsync(user, "Manager"))
                {
                    employees.Add((user, "Manager"));
                }
            }

            // Search by name or email
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                    (e.User.FirstName + " " + e.User.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || e.User.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter by role
            if (!String.IsNullOrEmpty(roleFilter))
            {
                employees = employees.Where(e => e.Role.Equals(roleFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Order by last name
            employees = employees.OrderBy(e => e.User.LastName).ThenBy(e => e.User.FirstName).ToList();

            // Record count for display
            ViewBag.RecordCount = $"Showing {employees.Count} Employees";

            return View(employees);
        }
    }
}
