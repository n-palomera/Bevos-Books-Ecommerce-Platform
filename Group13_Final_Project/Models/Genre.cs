using System.ComponentModel.DataAnnotations;

namespace Group13_Final_Project.Models
{
    public class Genre
    {
        [Key]
        public Int32 GenreID { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        [Display(Name = "Genre Name")]
        public String GenreName { get; set; }

        // Navigation property
        public List<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
