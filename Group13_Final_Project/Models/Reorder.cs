using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public enum ReorderStatusEnum
    {
        Pending,
        Received,
        PartiallyReceived,
        Cancelled
    }

    public class Reorder
    {
        [Key]
        public Int32 ReorderID { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [Display(Name = "Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be 0 or greater")]
        public Int32 Quantity { get; set; }

        [Display(Name = "Quantity Received")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity received must be 0 or greater")]
        public Int32 QuantityReceived { get; set; } = 0;

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Reorder Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Reorder Status")]
        public ReorderStatusEnum ReorderStatus { get; set; } = ReorderStatusEnum.Pending;

        // Foreign key
        [Display(Name = "Book")]
        public Int32 BookID { get; set; }

        // Navigation property
        public Book Book { get; set; }

        public Reorder()
        {
            Date = DateTime.Now;
        }

        // Calculated property for total cost
        public Decimal TotalCost
        {
            get
            {
                return Cost * Quantity;
            }
        }

        // Calculated property for remaining quantity to receive
        public Int32 RemainingQuantity
        {
            get
            {
                return Quantity - QuantityReceived;
            }
        }
    }
}
