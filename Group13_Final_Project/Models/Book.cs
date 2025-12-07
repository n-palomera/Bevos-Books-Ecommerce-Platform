using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public enum BookStatusEnum
    {
        Active,
        Discontinued
    }

    public class Book
    {
        [Key]
        public Int32 BookID { get; set; }

        [Required(ErrorMessage = "Book number is required")]
        [Display(Name = "Book Number")]
        public Int32 BookNumber { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Display(Name = "Description")]
        public String? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [Display(Name = "Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost { get; set; }

        [Required(ErrorMessage = "Publish date is required")]
        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Inventory quantity is required")]
        [Display(Name = "Inventory Quantity")]
        public Int32 InventoryQuantity { get; set; }

        [Required(ErrorMessage = "Reorder point is required")]
        [Display(Name = "Reorder Point")]
        public Int32 ReorderPoint { get; set; }

        [Required(ErrorMessage = "Authors are required")]
        [Display(Name = "Authors")]
        public String Authors { get; set; }

        [Display(Name = "Book Status")]
        public BookStatusEnum BookStatus { get; set; } = BookStatusEnum.Active;

        // Foreign key
        [Display(Name = "Genre")]
        public Int32 GenreID { get; set; }

        // Navigation properties (nullable for EF Core)
        public Genre? Genre { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<Reorder>? Reorders { get; set; }

        public Book()
        {
            Reviews = new List<Review>();
            OrderDetails = new List<OrderDetail>();
            Reorders = new List<Reorder>();
        }

        // Calculated property for average rating
        public Decimal AverageRating
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0 || Reviews.All(r => r.DisputeStatus != DisputeStatusEnum.Approved))
                {
                    return 0;
                }
                var approvedReviews = Reviews.Where(r => r.DisputeStatus == DisputeStatusEnum.Approved).ToList();
                if (approvedReviews.Count == 0)
                {
                    return 0;
                }
                return Convert.ToDecimal(Math.Round(approvedReviews.Average(r => r.Rating), 1));
            }
        }

        // Calculated property for in stock status
        public Boolean InStock
        {
            get
            {
                return InventoryQuantity > 0 && BookStatus == BookStatusEnum.Active;
            }
        }
    }
}
