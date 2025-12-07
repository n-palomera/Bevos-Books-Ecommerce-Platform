using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;

namespace Group13_Final_Project.Seeding
{
    public static class SeedCoupons
    {
        public static void SeedAllCoupons(AppDbContext db)
        {
            // Check if coupons already seeded
            if (db.Coupons.Any())
            {
                return;
            }

            var coupons = new List<Coupon>
            {
                new Coupon
                {
                    CouponCode = "SAVE10",
                    CouponType = CouponTypeEnum.PercentOff,
                    DiscountPercent = 10,
                    Status = true
                },
                new Coupon
                {
                    CouponCode = "SAVE15",
                    CouponType = CouponTypeEnum.PercentOff,
                    DiscountPercent = 15,
                    Status = true
                },
                new Coupon
                {
                    CouponCode = "FREESHIP",
                    CouponType = CouponTypeEnum.FreeShipping,
                    FreeThreshold = null, // Free shipping on all orders
                    Status = true
                },
                new Coupon
                {
                    CouponCode = "FREESHIP50",
                    CouponType = CouponTypeEnum.FreeShipping,
                    FreeThreshold = 50.00m, // Free shipping on orders $50+
                    Status = true
                },
                new Coupon
                {
                    CouponCode = "HOLIDAY20",
                    CouponType = CouponTypeEnum.PercentOff,
                    DiscountPercent = 20,
                    Status = false // Disabled coupon for testing
                }
            };

            db.Coupons.AddRange(coupons);
            db.SaveChanges();
        }
    }
}
