using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public class OrderDetail
    {
        [Key]
        public Int32 OrderDetailsID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [Display(Name = "Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public Int32 Quantity { get; set; }

        // Foreign keys
        [Display(Name = "Order")]
        public Int32 OrderID { get; set; }

        [Display(Name = "Book")]
        public Int32 BookID { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Book Book { get; set; }

        // Calculated property for line total
        public Decimal LineTotal
        {
            get
            {
                return Price * Quantity;
            }
        }

        // Calculated property for line profit
        public Decimal LineProfit
        {
            get
            {
                return (Price - Cost) * Quantity;
            }
        }
    }
}
