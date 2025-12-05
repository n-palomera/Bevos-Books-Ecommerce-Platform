using System.ComponentModel.DataAnnotations;
using Group13_Final_Project.Utilities;

namespace Group13_Final_Project.Models
{
    // View model for shopping cart display
    public class CartViewModel
    {
        public ShoppingCart Cart { get; set; } = new ShoppingCart();
        public decimal Shipping { get; set; }
        public decimal Total => Cart.Subtotal + Shipping;
    }

    // View model for checkout process
    public class CheckoutViewModel
    {
        public ShoppingCart Cart { get; set; } = new ShoppingCart();
        public decimal Shipping { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => Cart.Subtotal + Shipping - Discount;

        // Customer's saved cards
        public List<Card> SavedCards { get; set; } = new List<Card>();

        // Selected card for payment
        [Display(Name = "Select Payment Card")]
        public int? SelectedCardID { get; set; }

        // New card option
        public bool UseNewCard { get; set; }

        [Display(Name = "Card Number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be 16 digits")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be 16 digits")]
        public string? NewCardNumber { get; set; }

        [Display(Name = "Card Type")]
        public CardTypeEnum? NewCardType { get; set; }

        // Coupon code
        [Display(Name = "Coupon Code")]
        public string? CouponCode { get; set; }

        // Applied coupon details
        public Coupon? AppliedCoupon { get; set; }

        // Validation message
        public string? CouponMessage { get; set; }
    }

    // View model for order confirmation
    public class OrderConfirmationViewModel
    {
        public Order Order { get; set; } = null!;
        public List<Book> RecommendedBooks { get; set; } = new List<Book>();
    }
}
