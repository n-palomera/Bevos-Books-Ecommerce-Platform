using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public enum OrderStatusEnum
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }

    public class Order
    {
        private const Decimal FIRST_BOOK_SHIPPING = 3.50m;
        private const Decimal ADDITIONAL_BOOK_SHIPPING = 1.50m;

        [Key]
        public Int32 OrderID { get; set; }

        [Display(Name = "Order Number")]
        public Int32 OrderNumber { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Shipping fee is required")]
        [Display(Name = "Shipping Fee")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ShippingFee { get; set; }

        [Display(Name = "Order Status")]
        public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Shipped;

        // Foreign keys
        [Display(Name = "Customer")]
        public String CustomerID { get; set; }

        [Display(Name = "Card")]
        public Int32? CardID { get; set; }

        [Display(Name = "Coupon")]
        public Int32? CouponID { get; set; }

        // Navigation properties
        public AppUser Customer { get; set; }
        public Card? Card { get; set; }
        public Coupon? Coupon { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
            OrderDate = DateTime.Now;
        }

        // Calculated property for subtotal (before shipping, before coupon)
        public Decimal Subtotal
        {
            get
            {
                if (OrderDetails == null || OrderDetails.Count == 0)
                {
                    return 0m;
                }
                return OrderDetails.Sum(od => od.Price * od.Quantity);
            }
        }

        // Calculated property for total number of items
        public Int32 TotalItems
        {
            get
            {
                if (OrderDetails == null || OrderDetails.Count == 0)
                {
                    return 0;
                }
                return OrderDetails.Sum(od => od.Quantity);
            }
        }

        // Method to calculate shipping based on number of books
        public Decimal CalculateShipping()
        {
            Int32 totalBooks = TotalItems;
            if (totalBooks == 0)
            {
                return 0m;
            }
            return FIRST_BOOK_SHIPPING + ((totalBooks - 1) * ADDITIONAL_BOOK_SHIPPING);
        }

        // Calculated property for total after coupon discount and shipping
        public Decimal Total
        {
            get
            {
                Decimal subtotal = Subtotal;
                Decimal shippingFee = ShippingFee;
                Decimal discount = 0m;

                if (Coupon != null && Coupon.Status)
                {
                    if (Coupon.CouponType == CouponTypeEnum.PercentOff && Coupon.DiscountPercent.HasValue)
                    {
                        discount = subtotal * (Coupon.DiscountPercent.Value / 100);
                    }
                    else if (Coupon.CouponType == CouponTypeEnum.FreeShipping)
                    {
                        if (Coupon.FreeThreshold == null || subtotal >= Coupon.FreeThreshold.Value)
                        {
                            shippingFee = 0m;
                        }
                    }
                }

                return subtotal - discount + shippingFee;
            }
        }
    }
}
