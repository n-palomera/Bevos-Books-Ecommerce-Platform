using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using System;
using System.Linq;

namespace Group13_Final_Project.Seeding
{
    public static class SeedGenres
    {
        public static void SeedAllGenres(AppDbContext db)
        {
            // Check if genres have already been seeded
            if (db.Genres.Any())
            {
                return; // Genres already seeded
            }

            // Create a list of genres from the CSV data
            String[] genreNames = new String[]
            {
                "Adventure",
                "Contemporary Fiction",
                "Fantasy",
                "Historical Fiction",
                "Horror",
                "Humor",
                "Mystery",
                "Poetry",
                "Romance",
                "Science Fiction",
                "Shakespeare",
                "Suspense",
                "Thriller"
            };

            // Add each genre to the database
            foreach (String genreName in genreNames)
            {
                Genre genre = new Genre
                {
                    GenreName = genreName
                };
                db.Genres.Add(genre);
            }

            // Save changes to the database
            db.SaveChanges();
        }
    }
}
