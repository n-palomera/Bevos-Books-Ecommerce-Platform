using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Group13_Final_Project.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReportsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reports
        public IActionResult Index()
        {
            return View();
        }

        // Report A: All Books Sold
        public async Task<IActionResult> BooksSold(string sortOrder)
        {
            ViewData["TitleSort"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["QuantitySort"] = sortOrder == "quantity" ? "quantity_desc" : "quantity";
            ViewData["RevenueSort"] = sortOrder == "revenue" ? "revenue_desc" : "revenue";
            ViewData["ProfitSort"] = sortOrder == "profit" ? "profit_desc" : "profit";
            ViewData["CurrentSort"] = sortOrder;

            var orderDetails = await _context.OrderDetails
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Where(od => od.Order.OrderStatus != OrderStatusEnum.Cancelled)
                .ToListAsync();

            var report = orderDetails
                .GroupBy(od => od.Book)
                .Select(g => new BookSoldReportViewModel
                {
                    BookID = g.Key.BookID,
                    Title = g.Key.Title,
                    Author = g.Key.Authors,
                    QuantitySold = g.Sum(od => od.Quantity),
                    Revenue = g.Sum(od => od.Price * od.Quantity),
                    Cost = g.Sum(od => od.Cost * od.Quantity)
                })
                .ToList();

            report = sortOrder switch
            {
                "title_desc" => report.OrderByDescending(r => r.Title).ToList(),
                "quantity" => report.OrderBy(r => r.QuantitySold).ToList(),
                "quantity_desc" => report.OrderByDescending(r => r.QuantitySold).ToList(),
                "revenue" => report.OrderBy(r => r.Revenue).ToList(),
                "revenue_desc" => report.OrderByDescending(r => r.Revenue).ToList(),
                "profit" => report.OrderBy(r => r.Profit).ToList(),
                "profit_desc" => report.OrderByDescending(r => r.Profit).ToList(),
                _ => report.OrderBy(r => r.Title).ToList()
            };

            ViewBag.RecordCount = $"Showing {report.Count} Books";
            ViewBag.TotalRevenue = (decimal)report.Sum(r => r.Revenue);
            ViewBag.TotalProfit = (decimal)report.Sum(r => r.Profit);
            ViewBag.TotalQuantity = (int)report.Sum(r => r.QuantitySold);

            return View(report);
        }

        // Report B: All Orders
        public async Task<IActionResult> AllOrders(string sortOrder, string statusFilter)
        {
            ViewData["DateSort"] = string.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewData["TotalSort"] = sortOrder == "total" ? "total_desc" : "total";
            ViewData["CustomerSort"] = sortOrder == "customer" ? "customer_desc" : "customer";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentStatus"] = statusFilter;

            var ordersQuery = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .Include(o => o.Coupon)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                if (Enum.TryParse<OrderStatusEnum>(statusFilter, out var status))
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderStatus == status);
                }
            }

            var orders = await ordersQuery.ToListAsync();

            var report = orders.Select(o => new OrderReportViewModel
            {
                OrderID = o.OrderID,
                OrderNumber = o.OrderNumber.ToString(),
                OrderDate = o.OrderDate,
                CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}",
                CustomerEmail = o.Customer.Email ?? "",
                ItemCount = o.TotalItems,
                Subtotal = o.Subtotal,
                Shipping = o.ShippingFee,
                Discount = CalculateDiscount(o),
                Tax = 0,
                Total = o.Total,
                Status = o.OrderStatus.ToString()
            }).ToList();

            report = sortOrder switch
            {
                "date_asc" => report.OrderBy(r => r.OrderDate).ToList(),
                "total" => report.OrderBy(r => r.Total).ToList(),
                "total_desc" => report.OrderByDescending(r => r.Total).ToList(),
                "customer" => report.OrderBy(r => r.CustomerName).ToList(),
                "customer_desc" => report.OrderByDescending(r => r.CustomerName).ToList(),
                _ => report.OrderByDescending(r => r.OrderDate).ToList()
            };

            ViewBag.RecordCount = $"Showing {report.Count} Orders";
            ViewBag.TotalRevenue = report.Sum(r => r.Total);

            return View(report);
        }

        private decimal CalculateDiscount(Order order)
        {
            if (order.Coupon == null || !order.Coupon.Status)
                return 0;

            if (order.Coupon.CouponType == CouponTypeEnum.PercentOff && order.Coupon.DiscountPercent.HasValue)
            {
                return order.Subtotal * (order.Coupon.DiscountPercent.Value / 100);
            }
            return 0;
        }

        // Report C: All Customers
        public async Task<IActionResult> AllCustomers(string sortOrder)
        {
            ViewData["NameSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["OrdersSort"] = sortOrder == "orders" ? "orders_desc" : "orders";
            ViewData["RevenueSort"] = sortOrder == "revenue" ? "revenue_desc" : "revenue";
            ViewData["CurrentSort"] = sortOrder;

            var allUsers = await _userManager.Users.ToListAsync();
            var customers = new List<AppUser>();

            foreach (var user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer"))
                {
                    customers.Add(user);
                }
            }

            var customerIds = customers.Select(c => c.Id).ToList();

            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => customerIds.Contains(o.CustomerID) && o.OrderStatus != OrderStatusEnum.Cancelled)
                .ToListAsync();

            var report = customers.Select(c =>
            {
                var customerOrders = orders.Where(o => o.CustomerID == c.Id).ToList();
                return new CustomerReportViewModel
                {
                    CustomerID = c.Id,
                    CustomerNumber = c.CustomerNumber,
                    CustomerName = $"{c.FirstName} {c.LastName}",
                    Email = c.Email ?? "",
                    OrderCount = customerOrders.Count,
                    TotalRevenue = customerOrders.Sum(o => o.Total),
                    TotalProfit = customerOrders.Sum(o => o.OrderDetails.Sum(od => od.LineProfit))
                };
            }).ToList();

            report = sortOrder switch
            {
                "name_desc" => report.OrderByDescending(r => r.CustomerName).ToList(),
                "orders" => report.OrderBy(r => r.OrderCount).ToList(),
                "orders_desc" => report.OrderByDescending(r => r.OrderCount).ToList(),
                "revenue" => report.OrderBy(r => r.TotalRevenue).ToList(),
                "revenue_desc" => report.OrderByDescending(r => r.TotalRevenue).ToList(),
                _ => report.OrderBy(r => r.CustomerName).ToList()
            };

            ViewBag.RecordCount = $"Showing {report.Count} Customers";
            ViewBag.TotalRevenue = report.Sum(r => r.TotalRevenue);
            ViewBag.TotalProfit = report.Sum(r => r.TotalProfit);

            return View(report);
        }

        // Report D: Totals
        public async Task<IActionResult> Totals()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Customer)
                .Where(o => o.OrderStatus != OrderStatusEnum.Cancelled)
                .ToListAsync();

            var report = new TotalsReportViewModel
            {
                TotalRevenue = orders.Sum(o => o.Total),
                TotalCost = orders.Sum(o => o.OrderDetails.Sum(od => od.Cost * od.Quantity)),
                TotalOrders = orders.Count,
                TotalCustomers = orders.Select(o => o.CustomerID).Distinct().Count(),
                TotalBooksSold = orders.Sum(o => o.OrderDetails.Sum(od => od.Quantity))
            };

            return View(report);
        }

        // Report E: Current Inventory
        public async Task<IActionResult> CurrentInventory(string sortOrder, string filter)
        {
            ViewData["TitleSort"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["QuantitySort"] = sortOrder == "quantity" ? "quantity_desc" : "quantity";
            ViewData["ValueSort"] = sortOrder == "value" ? "value_desc" : "value";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = filter;

            var booksQuery = _context.Books.AsQueryable();

            if (filter == "active")
            {
                booksQuery = booksQuery.Where(b => b.BookStatus == BookStatusEnum.Active);
            }
            else if (filter == "discontinued")
            {
                booksQuery = booksQuery.Where(b => b.BookStatus == BookStatusEnum.Discontinued);
            }
            else if (filter == "reorder")
            {
                booksQuery = booksQuery.Where(b => b.InventoryQuantity <= b.ReorderPoint && b.BookStatus == BookStatusEnum.Active);
            }

            var books = await booksQuery.Include(b => b.Genre).ToListAsync();

            var report = books.Select(b => new InventoryReportViewModel
            {
                BookID = b.BookID,
                Title = b.Title,
                Author = b.Authors,
                Genre = b.Genre?.GenreName ?? "Unknown",
                Quantity = b.InventoryQuantity,
                Price = b.Price,
                Cost = b.Cost,
                IsDiscontinued = b.BookStatus == BookStatusEnum.Discontinued,
                NeedsReorder = b.InventoryQuantity <= b.ReorderPoint && b.BookStatus == BookStatusEnum.Active
            }).ToList();

            report = sortOrder switch
            {
                "title_desc" => report.OrderByDescending(r => r.Title).ToList(),
                "quantity" => report.OrderBy(r => r.Quantity).ToList(),
                "quantity_desc" => report.OrderByDescending(r => r.Quantity).ToList(),
                "value" => report.OrderBy(r => r.InventoryValue).ToList(),
                "value_desc" => report.OrderByDescending(r => r.InventoryValue).ToList(),
                _ => report.OrderBy(r => r.Title).ToList()
            };

            ViewBag.RecordCount = $"Showing {report.Count} Books";
            ViewBag.TotalInventoryValue = (decimal)report.Sum(r => r.InventoryValue);
            ViewBag.TotalPotentialRevenue = (decimal)report.Sum(r => r.PotentialRevenue);
            ViewBag.TotalUnits = (int)report.Sum(r => r.Quantity);

            return View(report);
        }

        // Report F: Review Activity by Employee
        public async Task<IActionResult> ReviewActivity(string sortOrder)
        {
            ViewData["NameSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ApprovedSort"] = sortOrder == "approved" ? "approved_desc" : "approved";
            ViewData["RejectedSort"] = sortOrder == "rejected" ? "rejected_desc" : "rejected";
            ViewData["TotalSort"] = sortOrder == "total" ? "total_desc" : "total";
            ViewData["CurrentSort"] = sortOrder;

            // Get all employees and admins
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

            // Get all reviews with approvers
            var reviews = await _context.Reviews
                .Where(r => r.DisputeStatus == DisputeStatusEnum.Approved || r.DisputeStatus == DisputeStatusEnum.Rejected)
                .ToListAsync();

            var report = employees.Select(e =>
            {
                var approvedCount = reviews.Count(r => r.ApproverID == e.User.Id && r.DisputeStatus == DisputeStatusEnum.Approved);
                var rejectedCount = reviews.Count(r => r.ApproverID == e.User.Id && r.DisputeStatus == DisputeStatusEnum.Rejected);

                return new ReviewActivityReportViewModel
                {
                    EmployeeID = e.User.Id,
                    EmployeeName = $"{e.User.FirstName} {e.User.LastName}",
                    Email = e.User.Email ?? "",
                    Role = e.Role,
                    ReviewsApproved = approvedCount,
                    ReviewsRejected = rejectedCount
                };
            }).ToList();

            report = sortOrder switch
            {
                "name_desc" => report.OrderByDescending(r => r.EmployeeName).ToList(),
                "approved" => report.OrderBy(r => r.ReviewsApproved).ToList(),
                "approved_desc" => report.OrderByDescending(r => r.ReviewsApproved).ToList(),
                "rejected" => report.OrderBy(r => r.ReviewsRejected).ToList(),
                "rejected_desc" => report.OrderByDescending(r => r.ReviewsRejected).ToList(),
                "total" => report.OrderBy(r => r.TotalReviewsProcessed).ToList(),
                "total_desc" => report.OrderByDescending(r => r.TotalReviewsProcessed).ToList(),
                _ => report.OrderBy(r => r.EmployeeName).ToList()
            };

            ViewBag.RecordCount = $"Showing {report.Count} Employees";
            ViewBag.TotalApproved = report.Sum(r => r.ReviewsApproved);
            ViewBag.TotalRejected = report.Sum(r => r.ReviewsRejected);

            return View(report);
        }
    }
}
