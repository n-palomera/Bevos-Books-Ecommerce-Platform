using Microsoft.AspNetCore.Identity;
using Group13_Final_Project.Utilities;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;

namespace Group13_Final_Project.Seeding
{
    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            // Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();

            // TODO: Add seed users here when seed data is provided
            // Example structure:
            /*
            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    PhoneNumber = "(512)555-1234",
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Main St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78701",
                    Status = true
                },
                Password = "Password123",
                RoleName = "Admin"
            });
            */

            // Create flag to help with errors
            String errorFlag = "Start";

            // Create an identity result
            IdentityResult result = new IdentityResult();

            // Call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: "
                    + errorFlag, ex);
            }

            return result;
        }
    }
}
