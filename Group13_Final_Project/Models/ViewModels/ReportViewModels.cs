using System;
using System.Collections.Generic;

namespace Group13_Final_Project.Models.ViewModels
{
    // Report A: All Books Sold
    public class BookSoldReportViewModel
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
        public decimal Cost { get; set; }
        public decimal Profit => Revenue - Cost;
        public decimal ProfitMargin => Revenue > 0 ? (Profit / Revenue) * 100 : 0;
    }

    // Report B: All Orders
    public class OrderReportViewModel
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    // Report C: All Customers
    public class CustomerReportViewModel
    {
        public string CustomerID { get; set; } = string.Empty;
        public int? CustomerNumber { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int OrderCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }
    }

    // Report D: Totals Summary
    public class TotalsReportViewModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit => TotalRevenue - TotalCost;
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalBooksSold { get; set; }
    }

    // Report E: Current Inventory
    public class InventoryReportViewModel
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal InventoryValue => Quantity * Cost;
        public decimal PotentialRevenue => Quantity * Price;
        public bool IsDiscontinued { get; set; }
        public bool NeedsReorder { get; set; }
    }

    // Report F: Review Activity by Employee
    public class ReviewActivityReportViewModel
    {
        public string EmployeeID { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int ReviewsApproved { get; set; }
        public int ReviewsRejected { get; set; }
        public int TotalReviewsProcessed => ReviewsApproved + ReviewsRejected;
    }
}
