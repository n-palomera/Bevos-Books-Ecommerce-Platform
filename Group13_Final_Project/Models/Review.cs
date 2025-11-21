using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public enum DisputeStatusEnum
    {
        Pending,
        Approved,
        Rejected
    }

    public class Review
    {
        [Key]
        public Int32 ReviewID { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Display(Name = "Rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public Int32 Rating { get; set; }

        [Display(Name = "Review Text")]
        [StringLength(100, ErrorMessage = "Review text cannot exceed 100 characters")]
        public String? ReviewText { get; set; }

        [Display(Name = "Status")]
        public DisputeStatusEnum DisputeStatus { get; set; } = DisputeStatusEnum.Pending;

        // Foreign keys
        [Display(Name = "Reviewer")]
        public String ReviewerID { get; set; }

        [Display(Name = "Book")]
        public Int32 BookID { get; set; }

        [Display(Name = "Approver")]
        public String? ApproverID { get; set; }

        // Navigation properties
        public AppUser Reviewer { get; set; }
        public Book Book { get; set; }
        public AppUser? Approver { get; set; }
    }
}
