using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    [Authorize(Roles = "Employee,Admin")]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        // ENHANCED: Added date range filtering and sorting
        public async Task<IActionResult> Index(string searchString, string statusFilter, DateTime? startDate, DateTime? endDate, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = statusFilter;
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;
            ViewData["CurrentSort"] = sortOrder;

            // Sorting parameters
            ViewData["OrderIDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "orderid_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CustomerSortParm"] = sortOrder == "Customer" ? "customer_desc" : "Customer";
            ViewData["TotalSortParm"] = sortOrder == "Total" ? "total_desc" : "Total";
            ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";

            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .AsQueryable();

            // Search by customer name or order ID
            if (!String.IsNullOrEmpty(searchString))
            {
                if (int.TryParse(searchString, out int orderId))
                {
                    orders = orders.Where(o => o.OrderID == orderId
                        || (o.Customer.FirstName + " " + o.Customer.LastName).Contains(searchString)
                        || o.Customer.Email.Contains(searchString));
                }
                else
                {
                    orders = orders.Where(o => (o.Customer.FirstName + " " + o.Customer.LastName).Contains(searchString)
                        || o.Customer.Email.Contains(searchString));
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

            // NEW: Filter by date range
            if (startDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate <= endDate.Value);
            }

            // NEW: Sorting
            switch (sortOrder)
            {
                case "orderid_desc":
                    orders = orders.OrderByDescending(o => o.OrderID);
                    break;
                case "Date":
                    orders = orders.OrderBy(o => o.OrderDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(o => o.OrderDate);
                    break;
                case "Customer":
                    orders = orders.OrderBy(o => o.Customer.LastName).ThenBy(o => o.Customer.FirstName);
                    break;
                case "customer_desc":
                    orders = orders.OrderByDescending(o => o.Customer.LastName).ThenByDescending(o => o.Customer.FirstName);
                    break;
                case "Status":
                    orders = orders.OrderBy(o => o.OrderStatus);
                    break;
                case "status_desc":
                    orders = orders.OrderByDescending(o => o.OrderStatus);
                    break;
                default:
                    // Default: Order by most recent first
                    orders = orders.OrderByDescending(o => o.OrderDate).ThenByDescending(o => o.OrderID);
                    break;
            }

            var orderList = await orders.ToListAsync();

            // Record count for display
            ViewBag.RecordCount = $"Showing {orderList.Count} Orders";

            return View(orderList);
        }

        // GET: Orders/Details/5
        // ENHANCED: Added Card, Coupon, and Genre includes
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
                        .ThenInclude(b => b.Genre)
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // ==================== NEW ACTIONS BELOW ====================

        // GET: Orders/Ship/5
        public async Task<IActionResult> Ship(int? id)
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

            // Check if order can be shipped
            if (order.OrderStatus == OrderStatusEnum.Cancelled)
            {
                TempData["Error"] = "Cannot ship a cancelled order.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            if (order.OrderStatus == OrderStatusEnum.Delivered)
            {
                TempData["Error"] = "This order has already been delivered.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            if (order.OrderStatus == OrderStatusEnum.Shipped)
            {
                TempData["Error"] = "This order has already been shipped.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            return View(order);
        }

        // POST: Orders/Ship/5
        [HttpPost, ActionName("Ship")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShipConfirmed(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Validate order can be shipped
            if (order.OrderStatus == OrderStatusEnum.Cancelled)
            {
                TempData["Error"] = "Cannot ship a cancelled order.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            if (order.OrderStatus == OrderStatusEnum.Delivered)
            {
                TempData["Error"] = "This order has already been delivered.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            // Update order status to Shipped
            order.OrderStatus = OrderStatusEnum.Shipped;

            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();

                TempData["Success"] = $"Order #{order.OrderID} has been marked as Shipped.";

                // TODO: Send shipping confirmation email to customer
                // EmailService.SendShippingConfirmation(order);

                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while shipping the order: " + ex.Message;
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }
        }

        // GET: Orders/Cancel/5
        public async Task<IActionResult> Cancel(int? id)
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

            // Check if order can be cancelled (only Pending orders)
            if (order.OrderStatus == OrderStatusEnum.Shipped)
            {
                TempData["Error"] = "Cannot cancel an order that has already been shipped.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            if (order.OrderStatus == OrderStatusEnum.Delivered)
            {
                TempData["Error"] = "Cannot cancel an order that has already been delivered.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            if (order.OrderStatus == OrderStatusEnum.Cancelled)
            {
                TempData["Error"] = "This order is already cancelled.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            return View(order);
        }

        // POST: Orders/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Validate order can be cancelled (only Pending orders)
            if (order.OrderStatus == OrderStatusEnum.Shipped)
            {
                TempData["Error"] = "Cannot cancel an order that has already been shipped.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            if (order.OrderStatus == OrderStatusEnum.Delivered)
            {
                TempData["Error"] = "Cannot cancel an order that has already been delivered.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            // Update order status to Cancelled
            order.OrderStatus = OrderStatusEnum.Cancelled;

            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();

                TempData["Success"] = $"Order #{order.OrderID} has been cancelled.";

                // TODO: Send cancellation email to customer
                // EmailService.SendCancellationNotification(order);

                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while cancelling the order: " + ex.Message;
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }
        }

        // GET: Orders/MarkDelivered/5
        public async Task<IActionResult> MarkDelivered(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Check if order can be marked as delivered
            if (order.OrderStatus != OrderStatusEnum.Shipped)
            {
                TempData["Error"] = "Only shipped orders can be marked as delivered.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            return View(order);
        }

        // POST: Orders/MarkDelivered/5
        [HttpPost, ActionName("MarkDelivered")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDeliveredConfirmed(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Validate order can be marked as delivered
            if (order.OrderStatus != OrderStatusEnum.Shipped)
            {
                TempData["Error"] = "Only shipped orders can be marked as delivered.";
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }

            // Update order status to Delivered
            order.OrderStatus = OrderStatusEnum.Delivered;

            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();

                TempData["Success"] = $"Order #{order.OrderID} has been marked as Delivered.";

                // TODO: Send delivery confirmation email to customer
                // EmailService.SendDeliveryConfirmation(order);

                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while updating the order: " + ex.Message;
                return RedirectToAction(nameof(Details), new { id = order.OrderID });
            }
        }
    }
}