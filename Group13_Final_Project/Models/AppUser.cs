using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Customer Number")]
        public Int32? CustomerNumber { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public String LastName { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Street address is required")]
        public String Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public String City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public String State { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip code is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zip code")]
        public String ZipCode { get; set; }

        [Display(Name = "Account Status")]
        public Boolean Status { get; set; } = true; // true = active, false = disabled

        // Navigation properties
        public List<Card> Cards { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }

        public AppUser()
        {
            Cards = new List<Card>();
            Orders = new List<Order>();
            Reviews = new List<Review>();
        }
    }
}
