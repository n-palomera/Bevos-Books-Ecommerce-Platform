using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public enum CouponTypeEnum
    {
        [Display(Name = "Percent Off")]
        PercentOff,
        [Display(Name = "Free Shipping")]
        FreeShipping
    }

    public class Coupon
    {
        [Key]
        public Int32 CouponID { get; set; }

        [Required(ErrorMessage = "Coupon code is required")]
        [Display(Name = "Coupon Code")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Coupon code must be between 1-20 characters")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Coupon code can only contain letters and numbers")]
        public String CouponCode { get; set; }

        [Required(ErrorMessage = "Coupon type is required")]
        [Display(Name = "Coupon Type")]
        public CouponTypeEnum CouponType { get; set; }

        [Display(Name = "Discount Percent")]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100")]
        public Decimal? DiscountPercent { get; set; }

        [Display(Name = "Free Shipping Threshold")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? FreeThreshold { get; set; }

        [Display(Name = "Status")]
        public Boolean Status { get; set; } = true; // true = enabled, false = disabled

        // Navigation property
        public List<Order> Orders { get; set; }

        public Coupon()
        {
            Orders = new List<Order>();
        }
    }
}
