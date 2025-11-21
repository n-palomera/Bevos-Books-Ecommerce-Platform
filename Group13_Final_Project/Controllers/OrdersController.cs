using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string searchString, string statusFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = statusFilter;

            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .AsQueryable();

            // Search by customer name or order ID
            if (!String.IsNullOrEmpty(searchString))
            {
                if (int.TryParse(searchString, out int orderId))
                {
                    orders = orders.Where(o => o.OrderID == orderId
                        || (o.Customer.FirstName + " " + o.Customer.LastName).Contains(searchString));
                }
                else
                {
                    orders = orders.Where(o => (o.Customer.FirstName + " " + o.Customer.LastName).Contains(searchString));
                }
            }

            // Filter by status
            if (!String.IsNullOrEmpty(statusFilter))
            {
                switch (statusFilter.ToLower())
                {
                    case "pending":
                        orders = orders.Where(o => o.OrderStatus == OrderStatusEnum.Pending);
                        break;
                    case "shipped":
                        orders = orders.Where(o => o.OrderStatus == OrderStatusEnum.Shipped);
                        break;
                    case "delivered":
                        orders = orders.Where(o => o.OrderStatus == OrderStatusEnum.Delivered);
                        break;
                    case "cancelled":
                        orders = orders.Where(o => o.OrderStatus == OrderStatusEnum.Cancelled);
                        break;
                }
            }

            // Order by most recent first
            orders = orders.OrderByDescending(o => o.OrderDate);

            var orderList = await orders.ToListAsync();

            // Record count for display
            ViewBag.RecordCount = $"Showing {orderList.Count} Orders";

            return View(orderList);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
