using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Index(string searchString, string roleFilter, string statusFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentRole"] = roleFilter;
            ViewData["CurrentStatus"] = statusFilter;

            // Get all users with Employee or Admin role
            var allUsers = await _userManager.Users.ToListAsync();
            var employees = new List<(AppUser User, string Role)>();

            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    employees.Add((user, "Admin"));
                }
                else if (await _userManager.IsInRoleAsync(user, "Employee"))
                {
                    employees.Add((user, "Employee"));
                }
            }

            // Filter by status
            if (!string.IsNullOrEmpty(statusFilter))
            {
                bool isActive = statusFilter == "Active";
                employees = employees.Where(e => e.User.Status == isActive).ToList();
            }

            // Search by name or email
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                    (e.User.FirstName + " " + e.User.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    || (e.User.Email != null && e.User.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();
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

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var employee = await _context.Users
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            // Verify this is an employee or admin
            bool isEmployee = await _userManager.IsInRoleAsync(employee, "Employee");
            bool isAdmin = await _userManager.IsInRoleAsync(employee, "Admin");
            if (!isEmployee && !isAdmin)
            {
                return NotFound();
            }

            ViewBag.Role = isAdmin ? "Admin" : "Employee";

            // Get review approval stats
            var approvedReviews = employee.Reviews?.Count(r => r.DisputeStatus == DisputeStatusEnum.Approved && r.ApproverID == id) ?? 0;
            var rejectedReviews = employee.Reviews?.Count(r => r.DisputeStatus == DisputeStatusEnum.Rejected && r.ApproverID == id) ?? 0;

            // Actually get reviews where this employee is the approver
            var reviewsApproved = await _context.Reviews
                .Where(r => r.ApproverID == id && r.DisputeStatus == DisputeStatusEnum.Approved)
                .CountAsync();
            var reviewsRejected = await _context.Reviews
                .Where(r => r.ApproverID == id && r.DisputeStatus == DisputeStatusEnum.Rejected)
                .CountAsync();

            ViewBag.ReviewsApproved = reviewsApproved;
            ViewBag.ReviewsRejected = reviewsRejected;

            return View(employee);
        }

        // GET: Employees/Create (Hire)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create (Hire)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model, string role = "Employee")
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

            // Validate role
            if (role != "Employee" && role != "Admin")
            {
                role = "Employee";
            }

            // Create the new employee
            var employee = new AppUser
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

            var result = await _userManager.CreateAsync(employee, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(employee, role);
                TempData["Success"] = $"{role} {model.FirstName} {model.LastName} hired successfully!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Verify this is an employee or admin
            bool isEmployee = await _userManager.IsInRoleAsync(employee, "Employee");
            bool isAdmin = await _userManager.IsInRoleAsync(employee, "Admin");
            if (!isEmployee && !isAdmin)
            {
                return NotFound();
            }

            var model = new EditProfileViewModel
            {
                UserID = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                City = employee.City,
                State = employee.State,
                ZipCode = employee.ZipCode,
                Birthday = employee.Birthday,
                Email = employee.Email // Read-only
            };

            return View(model);
        }

        // POST: Employees/Edit/5
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

            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Update allowed fields (email cannot be changed per requirements)
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.PhoneNumber = model.PhoneNumber;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.State = model.State;
            employee.ZipCode = model.ZipCode;
            employee.Birthday = model.Birthday;

            var result = await _userManager.UpdateAsync(employee);

            if (result.Succeeded)
            {
                TempData["Success"] = $"Employee {employee.FirstName} {employee.LastName} updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // POST: Employees/Fire/5 (Toggle Status - Fire/Rehire)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Fire(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Verify this is an employee or admin
            bool isEmployee = await _userManager.IsInRoleAsync(employee, "Employee");
            bool isAdmin = await _userManager.IsInRoleAsync(employee, "Admin");
            if (!isEmployee && !isAdmin)
            {
                return NotFound();
            }

            // Prevent firing yourself
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser?.Id == id)
            {
                TempData["Error"] = "You cannot fire yourself!";
                return RedirectToAction(nameof(Index));
            }

            // Toggle status (Fire = false, Rehire = true)
            employee.Status = !employee.Status;
            var result = await _userManager.UpdateAsync(employee);

            if (result.Succeeded)
            {
                string action = employee.Status ? "rehired" : "fired";
                TempData["Success"] = $"{employee.FirstName} {employee.LastName} has been {action}.";
            }
            else
            {
                TempData["Error"] = "Failed to update employee status.";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Employees/Promote/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Promote(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Only employees can be promoted to admin
            bool isEmployee = await _userManager.IsInRoleAsync(employee, "Employee");
            if (!isEmployee)
            {
                TempData["Error"] = "Only employees can be promoted to Admin.";
                return RedirectToAction(nameof(Index));
            }

            // Remove Employee role and add Admin role
            await _userManager.RemoveFromRoleAsync(employee, "Employee");
            await _userManager.AddToRoleAsync(employee, "Admin");

            TempData["Success"] = $"{employee.FirstName} {employee.LastName} has been promoted to Admin!";
            return RedirectToAction(nameof(Index));
        }

        // POST: Employees/Demote/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Demote(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Only admins can be demoted to employee
            bool isAdmin = await _userManager.IsInRoleAsync(employee, "Admin");
            if (!isAdmin)
            {
                TempData["Error"] = "Only admins can be demoted to Employee.";
                return RedirectToAction(nameof(Index));
            }

            // Prevent demoting yourself
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser?.Id == id)
            {
                TempData["Error"] = "You cannot demote yourself!";
                return RedirectToAction(nameof(Index));
            }

            // Remove Admin role and add Employee role
            await _userManager.RemoveFromRoleAsync(employee, "Admin");
            await _userManager.AddToRoleAsync(employee, "Employee");

            TempData["Success"] = $"{employee.FirstName} {employee.LastName} has been demoted to Employee.";
            return RedirectToAction(nameof(Index));
        }
    }
}
