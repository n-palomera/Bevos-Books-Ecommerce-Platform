using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Group13_Final_Project.Seeding
{
    public static class SeedReviews
    {
        public static void SeedAllReviews(UserManager<AppUser> userManager, AppDbContext db)
        {
            // Check if reviews already seeded
            if (db.Reviews.Any())
            {
                return;
            }

            List<(string ReviewerFirstName, string ReviewerLastName, string BookTitle, string ApproverFirstName, string ApproverLastName, int Rating, string ReviewText, string DisputeStatus)> ReviewData = new List<(string, string, string, string, string, int, string, string)>();

            ReviewData.Add(("Christopher", "Baker", "Say Goodbye", "Susan", "Barnes", 5, "“Incredible pacing and tension throughout—couldn’t stop reading!”", "Approve"));
            ReviewData.Add(("Christopher", "Baker", "Chasing Darkness", "Jack", "Mason", 4, "“Tight mystery with solid twists; a bit slow in the middle.”", "Reject"));
            ReviewData.Add(("Wendy", "Chang", "The Professional", "Cindy", "Silva", 4, "“Classic Spenser. Sharp dialogue and old-school charm.”", "Approve"));
            ReviewData.Add(("Lim", "Chou", "The Other Queen", "Eric", "Stuart", 3, "“Rich historical detail, but pacing drags at times.”", "Approve"));
            ReviewData.Add(("Lim", "Chou", "Wrecked", "Allen", "Rogers", 5, "“Fast-moving and witty. Loved the Cape Cod setting.”", "Approve"));
            ReviewData.Add(("Lim", "Chou", "Reckless", "Hector", "Garcia", 4, "“Emotional and thrilling. Hauck’s motives feel real.”", "Approve"));
            ReviewData.Add(("Jeffrey", "Hampton", "The Professional", "Cindy", "Silva", 5, "“Lean, witty Spenser case—couldn’t put it down.”", "Approve"));
            ReviewData.Add(("Charles", "Miller", "Say Goodbye", "Allen", "Rogers", 4, "“Creepy, clever, and tightly plotted.”", "Reject"));
            ReviewData.Add(("Ernest", "Lowe", "Wrecked", "Eric", "Stuart", 4, "“Light, fun mystery with brisk pacing.”", "Approve"));
            ReviewData.Add(("Ernest", "Lowe", "Reckless", "Eric", "Stuart", 3, "“Gritty and tense, but a bit uneven.”", "Approve"));

            // Create reviews
            foreach (var data in ReviewData)
            {
                // Find reviewer by name
                var reviewer = db.Users.FirstOrDefault(u =>
                    u.FirstName == data.Item1 && u.LastName == data.Item2);

                // Find book by title
                var book = db.Books.FirstOrDefault(b => b.Title == data.Item3);

                // Find approver by name (employee)
                AppUser approver = null;
                if (!string.IsNullOrEmpty(data.Item4))
                {
                    approver = db.Users.FirstOrDefault(u =>
                        u.FirstName == data.Item4 && u.LastName == data.Item5);
                }

                if (reviewer != null && book != null)
                {
                    DisputeStatusEnum status;
                    switch (data.Item8.ToLower())
                    {
                        case "approve":
                        case "approved":
                            status = DisputeStatusEnum.Approved;
                            break;
                        case "reject":
                        case "rejected":
                            status = DisputeStatusEnum.Rejected;
                            break;
                        default:
                            status = DisputeStatusEnum.Pending;
                            break;
                    }

                    Review review = new Review
                    {
                        ReviewerID = reviewer.Id,
                        BookID = book.BookID,
                        Rating = data.Item6,
                        ReviewText = data.Item7,
                        DisputeStatus = status,
                        ApproverID = approver?.Id
                    };

                    db.Reviews.Add(review);
                }
            }

            db.SaveChanges();
        }
    }
}
