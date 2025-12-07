using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Group13_Final_Project.Utilities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    [Authorize(Roles = "Employee,Admin")]
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
        public async Task<IActionResult> Index(string searchString, string statusFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = statusFilter;

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

            // Filter by status
            if (!string.IsNullOrEmpty(statusFilter))
            {
                bool isActive = statusFilter == "Active";
                customers = customers.Where(c => c.Status == isActive).ToList();
            }

            // Search by name or email
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c =>
                    (c.FirstName + " " + c.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || (c.Email != null && c.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            // Order by last name
            customers = customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            // Record count for display
            ViewBag.RecordCount = $"Showing {customers.Count} Customers";

            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var customer = await _context.Users
                .Include(u => u.Cards)
                .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderDetails)
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            // Verify this is a customer
            if (!await _userManager.IsInRoleAsync(customer, "Customer"))
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
                return View(model);
            }

            // Create the new customer
            var customer = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Birthday = model.Birthday,
                Status = true
            };

            var result = await _userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(customer, "Customer");
                TempData["Success"] = $"Customer {model.FirstName} {model.LastName} created successfully!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Verify this is a customer
            if (!await _userManager.IsInRoleAsync(customer, "Customer"))
            {
                return NotFound();
            }

            var model = new EditProfileViewModel
            {
                UserID = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                ZipCode = customer.ZipCode,
                Birthday = customer.Birthday,
                Email = customer.Email // Read-only
            };

            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditProfileViewModel model)
        {
            if (id != model.UserID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Update allowed fields (email cannot be changed per requirements)
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.State = model.State;
            customer.ZipCode = model.ZipCode;
            customer.Birthday = model.Birthday;

            var result = await _userManager.UpdateAsync(customer);

            if (result.Succeeded)
            {
                TempData["Success"] = $"Customer {customer.FirstName} {customer.LastName} updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // POST: Customers/ToggleStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Verify this is a customer
            if (!await _userManager.IsInRoleAsync(customer, "Customer"))
            {
                return NotFound();
            }

            // Toggle status
            customer.Status = !customer.Status;
            var result = await _userManager.UpdateAsync(customer);

            if (result.Succeeded)
            {
                string statusText = customer.Status ? "enabled" : "disabled";
                TempData["Success"] = $"Customer {customer.FirstName} {customer.LastName}'s account has been {statusText}.";
            }
            else
            {
                TempData["Error"] = "Failed to update customer status.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
