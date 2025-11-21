using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public enum CardTypeEnum
    {
        Visa,
        MasterCard,
        [Display(Name = "American Express")]
        AmericanExpress,
        Discover
    }

    public class Card
    {
        [Key]
        public Int32 CardID { get; set; }

        [Required(ErrorMessage = "Card number is required")]
        [Display(Name = "Card Number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be 16 digits")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be 16 digits")]
        public String CardNumber { get; set; }

        [Required(ErrorMessage = "Card type is required")]
        [Display(Name = "Card Type")]
        public CardTypeEnum CardType { get; set; }

        // Foreign key
        [Display(Name = "Customer")]
        public String CustomerID { get; set; }

        // Navigation properties
        public AppUser Customer { get; set; }
        public List<Order> Orders { get; set; }

        public Card()
        {
            Orders = new List<Order>();
        }

        // Property to display masked card number (showing only last 4 digits)
        public String MaskedCardNumber
        {
            get
            {
                if (string.IsNullOrEmpty(CardNumber) || CardNumber.Length != 16)
                {
                    return "****";
                }
                return "************" + CardNumber.Substring(12, 4);
            }
        }
    }
}
