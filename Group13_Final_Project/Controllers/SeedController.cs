using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Group13_Final_Project.Models;
using Group13_Final_Project.DAL;
using System;

namespace Group13_Final_Project.Controllers
{
    public class SeedController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedController(AppDbContext db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _context = db;
            _userManager = um;
            _roleManager = rm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ClearAndReseed()
        {
            try
            {
                // Clear all data in reverse order of dependencies
                // Using raw SQL for efficiency and to avoid EF tracking issues

                // 1. Clear OrderDetails first (depends on Orders and Books)
                _context.OrderDetails.RemoveRange(_context.OrderDetails);
                await _context.SaveChangesAsync();

                // 2. Clear Orders (depends on Users)
                _context.Orders.RemoveRange(_context.Orders);
                await _context.SaveChangesAsync();

                // 3. Clear Reviews (depends on Users and Books)
                _context.Reviews.RemoveRange(_context.Reviews);
                await _context.SaveChangesAsync();

                // 4. Clear Cards (depends on Users)
                _context.Cards.RemoveRange(_context.Cards);
                await _context.SaveChangesAsync();

                // 5. Clear Reorders (depends on Books)
                _context.Reorders.RemoveRange(_context.Reorders);
                await _context.SaveChangesAsync();

                // 6. Clear Books (depends on Genres)
                _context.Books.RemoveRange(_context.Books);
                await _context.SaveChangesAsync();

                // 7. Clear Coupons
                _context.Coupons.RemoveRange(_context.Coupons);
                await _context.SaveChangesAsync();

                // 8. Clear Genres
                _context.Genres.RemoveRange(_context.Genres);
                await _context.SaveChangesAsync();

                // 9. Clear all users
                var allUsers = _userManager.Users.ToList();
                foreach (var user in allUsers)
                {
                    await _userManager.DeleteAsync(user);
                }

                // 10. Clear roles
                var allRoles = _roleManager.Roles.ToList();
                foreach (var role in allRoles)
                {
                    await _roleManager.DeleteAsync(role);
                }

                // Now reseed everything
                await Seeding.SeedRoles.AddAllRoles(_roleManager);
                await Seeding.SeedEmployees.SeedAllEmployees(_userManager, _context);
                await Seeding.SeedCustomers.SeedAllCustomers(_userManager, _context);
                Seeding.SeedGenres.SeedAllGenres(_context);
                Seeding.SeedBooks.SeedAllBooks(_context);
                Seeding.SeedCards.SeedAllCards(_userManager, _context);
                Seeding.SeedReviews.SeedAllReviews(_userManager, _context);
                Seeding.SeedOrders.SeedAllOrders(_userManager, _context);
                Seeding.SeedCoupons.SeedAllCoupons(_context);
            }
            catch (Exception ex)
            {
                List<String> errorList = new List<String>();
                errorList.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }
                return View("Error", errorList);
            }

            return View("Confirm");
        }

        public async Task<IActionResult> SeedAll()
        {
            try
            {
                // Seed in the correct order:
                // 1. Roles
                // 2. Employees
                // 3. Customers
                // 4. Genres
                // 5. Books
                // 6. Cards
                // 7. Reviews
                // 8. Orders
                await Seeding.SeedRoles.AddAllRoles(_roleManager);
                await Seeding.SeedEmployees.SeedAllEmployees(_userManager, _context);
                await Seeding.SeedCustomers.SeedAllCustomers(_userManager, _context);
                Seeding.SeedGenres.SeedAllGenres(_context);
                Seeding.SeedBooks.SeedAllBooks(_context);
                Seeding.SeedCards.SeedAllCards(_userManager, _context);
                Seeding.SeedReviews.SeedAllReviews(_userManager, _context);
                Seeding.SeedOrders.SeedAllOrders(_userManager, _context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }
        public async Task<IActionResult> SeedRoles()
        {
            try
            {
                //call the method to seed the roles
                await Seeding.SeedRoles.AddAllRoles(_roleManager);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                //Add the message from the inner exception
                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }
        public async Task<IActionResult> SeedPeople()
        {
            try
            {
                //call the method to seed the users
                await Seeding.SeedUsers.SeedAllUsers(_userManager, _context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }

        public IActionResult SeedGenres()
        {
            try
            {
                //call the method to seed the genres
                Seeding.SeedGenres.SeedAllGenres(_context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }

        public IActionResult SeedBooks()
        {
            try
            {
                //call the method to seed the books
                Seeding.SeedBooks.SeedAllBooks(_context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            
            return View("Confirm");
        }
    }
}
