using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Group13_Final_Project.Models
{
    //NOTE: This is the view model used to allow the user to login
    //The user only needs the email and password to login
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //NOTE: This is the view model used to register a user
    //When the user registers, they only need to specify the
    //properties listed in this model
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [Display(Name = "Street Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zip code format")]
        public String ZipCode { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to allow the user to 
    //change their password
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to display basic user information
    //on the index page
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public DateTime? Birthday { get; set; }
        public int CardCount { get; set; }
    }

    // View model for editing profile
    public class EditProfileViewModel
    {
        public String UserID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [Display(Name = "Street Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zip code format")]
        public String ZipCode { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        // Email is readonly
        [Display(Name = "Email")]
        public String Email { get; set; }
    }

    // View model for order history with filtering
    public class OrderHistoryViewModel
    {
        public List<Order> Orders { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String StatusFilter { get; set; }
    }

    // View model for creating a review
    public class CreateReviewViewModel
    {
        public Int32 BookID { get; set; }

        // Display-only fields - not submitted with form, so must be nullable
        public String? BookTitle { get; set; }
        public String? BookAuthor { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Display(Name = "Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public Int32 Rating { get; set; }

        [Display(Name = "Review (Optional)")]
        [StringLength(100, ErrorMessage = "Review cannot exceed 100 characters")]
        public String? ReviewText { get; set; }
    }

    // View model for book recommendations
    public class RecommendationsViewModel
    {
        public Int32 OrderID { get; set; }
        public List<Book> RecommendedBooks { get; set; }
    }

    // View model for employee editing a review (text only, not rating)
    public class EditReviewViewModel
    {
        public Int32 ReviewID { get; set; }

        // Display-only fields - not submitted with form, so must be nullable
        public String? BookTitle { get; set; }
        public String? BookAuthor { get; set; }
        public String? ReviewerName { get; set; }

        [Display(Name = "Rating")]
        public Int32 Rating { get; set; } // Display only - cannot be changed

        [Display(Name = "Review Text")]
        [StringLength(100, ErrorMessage = "Review text cannot exceed 100 characters")]
        public String? ReviewText { get; set; }

        [Display(Name = "Status")]
        public DisputeStatusEnum DisputeStatus { get; set; }
    }
}