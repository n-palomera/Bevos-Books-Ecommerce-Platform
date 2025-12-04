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

            // Order 10001
            var customer10001 = db.Users.FirstOrDefault(u => u.Email == "cbaker@example.com");
            if (customer10001 != null)
            {
                Order order10001 = new Order
                {
                    OrderNumber = 10001,
                    CustomerID = customer10001.Id,
                    OrderDate = DateTime.Now,
                    ShippingFee = 0.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10001_0 = db.Books.FirstOrDefault(b => b.Title == "The Art Of Racing In The Rain");
                if (book10001_0 != null)
                {
                    order10001.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10001_0.BookID,
                        Quantity = 2,
                        Price = 23.95m,
                        Cost = 10.3m
                    });
                }

                var book10001_1 = db.Books.FirstOrDefault(b => b.Title == "The Host");
                if (book10001_1 != null)
                {
                    order10001.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10001_1.BookID,
                        Quantity = 1,
                        Price = 25.99m,
                        Cost = 13.25m
                    });
                }

                db.Orders.Add(order10001);
            }

            // Order 10002
            var customer10002 = db.Users.FirstOrDefault(u => u.Email == "toddj@yourmom.com");
            if (customer10002 != null)
            {
                Order order10002 = new Order
                {
                    OrderNumber = 10002,
                    CustomerID = customer10002.Id,
                    OrderDate = DateTime.Now,
                    ShippingFee = 0.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10002_2 = db.Books.FirstOrDefault(b => b.Title == "Roses");
                if (book10002_2 != null)
                {
                    order10002.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10002_2.BookID,
                        Quantity = 2,
                        Price = 24.99m,
                        Cost = 20.99m
                    });
                }

                db.Orders.Add(order10002);
            }

            // Order 10003
            var customer10003 = db.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");
            if (customer10003 != null)
            {
                Order order10003 = new Order
                {
                    OrderNumber = 10003,
                    CustomerID = customer10003.Id,
                    OrderDate = DateTime.Now,
                    ShippingFee = 0.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10003_3 = db.Books.FirstOrDefault(b => b.Title == "Altar of Eden");
                if (book10003_3 != null)
                {
                    order10003.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10003_3.BookID,
                        Quantity = 1,
                        Price = 27.99m,
                        Cost = 25.75m
                    });
                }

                db.Orders.Add(order10003);
            }

            // Order 10004
            var customer10004 = db.Users.FirstOrDefault(u => u.Email == "wchang@example.com");
            if (customer10004 != null)
            {
                Order order10004 = new Order
                {
                    OrderNumber = 10004,
                    CustomerID = customer10004.Id,
                    OrderDate = new DateTime(2025, 10, 31),
                    ShippingFee = 3.5m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10004_4 = db.Books.FirstOrDefault(b => b.Title == "The Professional");
                if (book10004_4 != null)
                {
                    order10004.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10004_4.BookID,
                        Quantity = 1,
                        Price = 26.95m,
                        Cost = 7.01m
                    });
                }

                db.Orders.Add(order10004);
            }

            // Order 10005
            var customer10005 = db.Users.FirstOrDefault(u => u.Email == "cbaker@example.com");
            if (customer10005 != null)
            {
                Order order10005 = new Order
                {
                    OrderNumber = 10005,
                    CustomerID = customer10005.Id,
                    OrderDate = new DateTime(2025, 10, 1),
                    ShippingFee = 9.5m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10005_5 = db.Books.FirstOrDefault(b => b.Title == "Say Goodbye");
                if (book10005_5 != null)
                {
                    order10005.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10005_5.BookID,
                        Quantity = 5,
                        Price = 25.0m,
                        Cost = 11.25m
                    });
                }

                var book10005_6 = db.Books.FirstOrDefault(b => b.Title == "Chasing Darkness");
                if (book10005_6 != null)
                {
                    order10005.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10005_6.BookID,
                        Quantity = 1,
                        Price = 25.95m,
                        Cost = 9.08m
                    });
                }

                db.Orders.Add(order10005);
            }

            // Order 10006
            var customer10006 = db.Users.FirstOrDefault(u => u.Email == "limchou@gogle.com");
            if (customer10006 != null)
            {
                Order order10006 = new Order
                {
                    OrderNumber = 10006,
                    CustomerID = customer10006.Id,
                    OrderDate = new DateTime(2025, 10, 5),
                    ShippingFee = 107.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10006_7 = db.Books.FirstOrDefault(b => b.Title == "The Other Queen");
                if (book10006_7 != null)
                {
                    order10006.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10006_7.BookID,
                        Quantity = 70,
                        Price = 25.95m,
                        Cost = 23.61m
                    });
                }

                var book10006_8 = db.Books.FirstOrDefault(b => b.Title == "Wrecked");
                if (book10006_8 != null)
                {
                    order10006.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10006_8.BookID,
                        Quantity = 10,
                        Price = 25.0m,
                        Cost = 18.0m
                    });
                }

                var book10006_9 = db.Books.FirstOrDefault(b => b.Title == "Reckless");
                if (book10006_9 != null)
                {
                    order10006.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10006_9.BookID,
                        Quantity = 23,
                        Price = 22.0m,
                        Cost = 9.46m
                    });
                }

                db.Orders.Add(order10006);
            }

            // Order 10007
            var customer10007 = db.Users.FirstOrDefault(u => u.Email == "wchang@example.com");
            if (customer10007 != null)
            {
                Order order10007 = new Order
                {
                    OrderNumber = 10007,
                    CustomerID = customer10007.Id,
                    OrderDate = new DateTime(2025, 10, 30),
                    ShippingFee = 3.5m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10007_10 = db.Books.FirstOrDefault(b => b.Title == "The Professional");
                if (book10007_10 != null)
                {
                    order10007.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10007_10.BookID,
                        Quantity = 1,
                        Price = 26.95m,
                        Cost = 7.01m
                    });
                }

                db.Orders.Add(order10007);
            }

            // Order 10008
            var customer10008 = db.Users.FirstOrDefault(u => u.Email == "jeffh@sonic.com");
            if (customer10008 != null)
            {
                Order order10008 = new Order
                {
                    OrderNumber = 10008,
                    CustomerID = customer10008.Id,
                    OrderDate = new DateTime(2025, 11, 1),
                    ShippingFee = 5.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10008_11 = db.Books.FirstOrDefault(b => b.Title == "The Professional");
                if (book10008_11 != null)
                {
                    order10008.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10008_11.BookID,
                        Quantity = 2,
                        Price = 26.95m,
                        Cost = 7.01m
                    });
                }

                db.Orders.Add(order10008);
            }

            // Order 10009
            var customer10009 = db.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");
            if (customer10009 != null)
            {
                Order order10009 = new Order
                {
                    OrderNumber = 10009,
                    CustomerID = customer10009.Id,
                    OrderDate = new DateTime(2025, 11, 3),
                    ShippingFee = 3.5m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10009_12 = db.Books.FirstOrDefault(b => b.Title == "Say Goodbye");
                if (book10009_12 != null)
                {
                    order10009.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10009_12.BookID,
                        Quantity = 1,
                        Price = 25.0m,
                        Cost = 11.25m
                    });
                }

                db.Orders.Add(order10009);
            }

            // Order 10010
            var customer10010 = db.Users.FirstOrDefault(u => u.Email == "elowe@netscare.net");
            if (customer10010 != null)
            {
                Order order10010 = new Order
                {
                    OrderNumber = 10010,
                    CustomerID = customer10010.Id,
                    OrderDate = new DateTime(2025, 11, 2),
                    ShippingFee = 6.5m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10010_13 = db.Books.FirstOrDefault(b => b.Title == "Wrecked");
                if (book10010_13 != null)
                {
                    order10010.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10010_13.BookID,
                        Quantity = 3,
                        Price = 25.0m,
                        Cost = 18.0m
                    });
                }

                var book10010_14 = db.Books.FirstOrDefault(b => b.Title == "Reckless");
                if (book10010_14 != null)
                {
                    order10010.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10010_14.BookID,
                        Quantity = 11,
                        Price = 22.0m,
                        Cost = 9.46m
                    });
                }

                db.Orders.Add(order10010);
            }

            // Order 10011
            var customer10011 = db.Users.FirstOrDefault(u => u.Email == "knelson@aoll.com");
            if (customer10011 != null)
            {
                Order order10011 = new Order
                {
                    OrderNumber = 10011,
                    CustomerID = customer10011.Id,
                    OrderDate = DateTime.Now,
                    ShippingFee = 0.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10011_15 = db.Books.FirstOrDefault(b => b.Title == "The Cast");
                if (book10011_15 != null)
                {
                    order10011.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10011_15.BookID,
                        Quantity = 1,
                        Price = 21.95m,
                        Cost = 12.95m
                    });
                }

                db.Orders.Add(order10011);
            }

            // Order 10012
            var customer10012 = db.Users.FirstOrDefault(u => u.Email == "cluce@gogle.com");
            if (customer10012 != null)
            {
                Order order10012 = new Order
                {
                    OrderNumber = 10012,
                    CustomerID = customer10012.Id,
                    OrderDate = DateTime.Now,
                    ShippingFee = 0.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10012_16 = db.Books.FirstOrDefault(b => b.Title == "Brooklyn");
                if (book10012_16 != null)
                {
                    order10012.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10012_16.BookID,
                        Quantity = 1,
                        Price = 18.95m,
                        Cost = 3.6m
                    });
                }

                db.Orders.Add(order10012);
            }

            // Order 10013
            var customer10013 = db.Users.FirstOrDefault(u => u.Email == "erynrice@aoll.com");
            if (customer10013 != null)
            {
                Order order10013 = new Order
                {
                    OrderNumber = 10013,
                    CustomerID = customer10013.Id,
                    OrderDate = DateTime.Now,
                    ShippingFee = 0.0m,
                    OrderStatus = OrderStatusEnum.Pending,
                    OrderDetails = new List<OrderDetail>()
                };

                var book10013_17 = db.Books.FirstOrDefault(b => b.Title == "Dexter By Design");
                if (book10013_17 != null)
                {
                    order10013.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10013_17.BookID,
                        Quantity = 1,
                        Price = 25.0m,
                        Cost = 2.75m
                    });
                }

                var book10013_18 = db.Books.FirstOrDefault(b => b.Title == "The Midnight House");
                if (book10013_18 != null)
                {
                    order10013.OrderDetails.Add(new OrderDetail
                    {
                        BookID = book10013_18.BookID,
                        Quantity = 3,
                        Price = 25.95m,
                        Cost = 3.11m
                    });
                }

                db.Orders.Add(order10013);
            }

            db.SaveChanges();
        }
    }
}
