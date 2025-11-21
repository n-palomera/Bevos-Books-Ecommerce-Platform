using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Group13_Final_Project.Seeding
{
    public static class SeedOrders
    {
        public static void SeedAllOrders(UserManager<AppUser> userManager, AppDbContext db)
        {
            // Check if orders already seeded
            if (db.Orders.Any())
            {
                return;
            }

            // Group order items by OrderId
            List<(int OrderId, string CustomerName, DateTime OrderDate, decimal ShippingFee, string OrderStatus, List<(string BookTitle, decimal Price, decimal Cost, int Quantity)> Items)> OrderData = new List<(int, string, DateTime, decimal, string, List<(string, decimal, decimal, int)>)>();

            // Order 10001
            OrderData.Add((10001, "Christopher Baker", new DateTime(2025, 1, 1), 0.0m, "InCart", new List<(string, decimal, decimal, int)>
            {
                ("The Art Of Racing In The Rain", 23.95m, 10.3m, 3),
                ("The Host", 25.99m, 13.25m, 1),
            }));

            // Order 10002
            OrderData.Add((10002, "Todd Jacobs", new DateTime(2025, 1, 1), 0.0m, "InCart", new List<(string, decimal, decimal, int)>
            {
                ("Roses", 24.99m, 20.99m, 2),
            }));

            // Order 10003
            OrderData.Add((10003, "Charles Miller", new DateTime(2025, 1, 1), 0.0m, "InCart", new List<(string, decimal, decimal, int)>
            {
                ("Altar of Eden", 27.99m, 25.75m, 2),
            }));

            // Order 10004
            OrderData.Add((10004, "Wendy Chang", new DateTime(2025, 10, 31), 3.5m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("The Professional", 26.95m, 7.01m, 1),
            }));

            // Order 10005
            OrderData.Add((10005, "Christopher Baker", new DateTime(2025, 10, 1), 9.5m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("Say Goodbye", 25.0m, 11.25m, 5),
                ("Chasing Darkness", 25.95m, 9.08m, 1),
            }));

            // Order 10006
            OrderData.Add((10006, "Lim Chou", new DateTime(2025, 10, 5), 107.0m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("The Other Queen", 25.95m, 23.61m, 70),
                ("Wrecked", 25.0m, 18.0m, 10),
                ("Reckless", 22.0m, 9.46m, 23),
            }));

            // Order 10007
            OrderData.Add((10007, "Wendy Chang", new DateTime(2025, 10, 30), 3.5m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("The Professional", 26.95m, 7.01m, 1),
            }));

            // Order 10008
            OrderData.Add((10008, "Jeffrey Hampton", new DateTime(2025, 11, 1), 5.0m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("The Professional", 26.95m, 7.01m, 2),
            }));

            // Order 10009
            OrderData.Add((10009, "Charles Miller", new DateTime(2025, 11, 3), 3.5m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("Say Goodbye", 25.0m, 11.25m, 1),
            }));

            // Order 10010
            OrderData.Add((10010, "Ernest Lowe", new DateTime(2025, 11, 2), 6.5m, "Ordered", new List<(string, decimal, decimal, int)>
            {
                ("Wrecked", 25.0m, 18.0m, 3),
                ("Reckless", 22.0m, 9.46m, 11),
            }));

            // Order 10011
            OrderData.Add((10011, "Kelly Nelson", new DateTime(2025, 1, 1), 0.0m, "InCart", new List<(string, decimal, decimal, int)>
            {
                ("The Cast", 21.95m, 12.95m, 1),
            }));

            // Order 10012
            OrderData.Add((10012, "Chuck Luce", new DateTime(2025, 1, 1), 0.0m, "InCart", new List<(string, decimal, decimal, int)>
            {
                ("Brooklyn", 18.95m, 3.6m, 4),
            }));

            // Order 10013
            OrderData.Add((10013, "Eryn Rice", new DateTime(2025, 1, 1), 0.0m, "InCart", new List<(string, decimal, decimal, int)>
            {
                ("Dexter By Design", 25.0m, 2.75m, 1),
                ("The Midnight House", 25.95m, 3.11m, 3),
            }));

            // Create orders and order details
            foreach (var orderData in OrderData)
            {
                // Find customer by name
                var customer = db.Users.FirstOrDefault(u =>
                    (u.FirstName + " " + u.LastName) == orderData.Item2);

                if (customer != null)
                {
                    // Determine order status
                    OrderStatusEnum status;
                    switch (orderData.Item5.ToLower())
                    {
                        case "shipped":
                            status = OrderStatusEnum.Shipped;
                            break;
                        case "delivered":
                            status = OrderStatusEnum.Delivered;
                            break;
                        case "pending":
                            status = OrderStatusEnum.Pending;
                            break;
                        case "cancelled":
                            status = OrderStatusEnum.Cancelled;
                            break;
                        default:
                            status = OrderStatusEnum.Shipped;
                            break;
                    }

                    Order order = new Order
                    {
                        CustomerID = customer.Id,
                        OrderDate = orderData.Item3,
                        ShippingFee = orderData.Item4,
                        OrderStatus = status,
                        OrderDetails = new List<OrderDetail>()
                    };

                    // Add order details
                    foreach (var item in orderData.Item6)
                    {
                        var book = db.Books.FirstOrDefault(b => b.Title == item.Item1);
                        if (book != null)
                        {
                            OrderDetail detail = new OrderDetail
                            {
                                BookID = book.BookID,
                                Quantity = item.Item4,
                                Price = item.Item2,
                                Cost = item.Item3
                            };
                            order.OrderDetails.Add(detail);
                        }
                    }

                    db.Orders.Add(order);
                }
            }

            db.SaveChanges();
        }
    }
}
