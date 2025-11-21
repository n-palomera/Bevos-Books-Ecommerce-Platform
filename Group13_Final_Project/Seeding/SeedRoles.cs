using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Group13_Final_Project.Seeding
{
    public class SeedRoles
    {
        public static async Task AddAllRoles(RoleManager<IdentityRole> roleManager)
        {
            // Add Admin role
            if (await roleManager.RoleExistsAsync("Admin") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Add Employee role
            if (await roleManager.RoleExistsAsync("Employee") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            // Add Customer role
            if (await roleManager.RoleExistsAsync("Customer") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }
        }
    }
}
