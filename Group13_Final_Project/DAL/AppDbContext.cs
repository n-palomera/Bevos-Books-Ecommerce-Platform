using System;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Group13_Final_Project.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this code makes sure the database is re-created on the $5/month Azure tier
            builder.HasPerformanceLevel("Basic");
            builder.HasServiceTier("Basic");
            base.OnModelCreating(builder);

            // Configure relationships for Review with multiple AppUser foreign keys
            builder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.ReviewerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(r => r.Approver)
                .WithMany()
                .HasForeignKey(r => r.ApproverID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        // DbSets for all models
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Reorder> Reorders { get; set; }
    }
}
