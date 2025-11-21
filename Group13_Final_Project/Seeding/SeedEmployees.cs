using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Group13_Final_Project.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group13_Final_Project.Seeding
{
    public static class SeedEmployees
    {
        public static async Task SeedAllEmployees(UserManager<AppUser> userManager, AppDbContext db)
        {
            List<AddUserModel> Employees = new List<AddUserModel>();

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "c.baker@bevosbooks.com",
                    Email = "c.baker@bevosbooks.com",
                    FirstName = "Christopher",
                    LastName = "Baker",
                    Address = "1245 Lake Libris Dr.",
                    City = "Cedar Park",
                    State = "TX",
                    ZipCode = "78613",
                    PhoneNumber = "3395325649",
                    Status = true
                },
                Password = "dewey4",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "s.barnes@bevosbooks.com",
                    Email = "s.barnes@bevosbooks.com",
                    FirstName = "Susan",
                    LastName = "Barnes",
                    Address = "888 S. Main",
                    City = "Kyle",
                    State = "TX",
                    ZipCode = "78640",
                    PhoneNumber = "9636389416",
                    Status = true
                },
                Password = "smitty",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "h.garcia@bevosbooks.com",
                    Email = "h.garcia@bevosbooks.com",
                    FirstName = "Hector",
                    LastName = "Garcia",
                    Address = "777 PBR Drive",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "4547135738",
                    Status = true
                },
                Password = "squirrel",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "b.ingram@bevosbooks.com",
                    Email = "b.ingram@bevosbooks.com",
                    FirstName = "Brad",
                    LastName = "Ingram",
                    Address = "6548 La Posada Ct.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    PhoneNumber = "5817343315",
                    Status = true
                },
                Password = "changalang",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "j.jackson@bevosbooks.com",
                    Email = "j.jackson@bevosbooks.com",
                    FirstName = "Jack",
                    LastName = "Jackson",
                    Address = "222 Main",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78760",
                    PhoneNumber = "8241915317",
                    Status = true
                },
                Password = "rhythm",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "t.jacobs@bevosbooks.com",
                    Email = "t.jacobs@bevosbooks.com",
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    Address = "4564 Elm St.",
                    City = "Georgetown",
                    State = "TX",
                    ZipCode = "78628",
                    PhoneNumber = "2477822475",
                    Status = true
                },
                Password = "approval",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "l.jones@bevosbooks.com",
                    Email = "l.jones@bevosbooks.com",
                    FirstName = "Lester",
                    LastName = "Jones",
                    Address = "999 LeBlat",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78747",
                    PhoneNumber = "4764966462",
                    Status = true
                },
                Password = "society",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "b.larson@bevosbooks.com",
                    Email = "b.larson@bevosbooks.com",
                    FirstName = "Bill",
                    LastName = "Larson",
                    Address = "1212 N. First Ave",
                    City = "Round Rock",
                    State = "TX",
                    ZipCode = "78665",
                    PhoneNumber = "3355258855",
                    Status = true
                },
                Password = "tanman",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "v.lawrence@bevosbooks.com",
                    Email = "v.lawrence@bevosbooks.com",
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    Address = "6639 Bookworm Ln.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "7511273054",
                    Status = true
                },
                Password = "longhorns",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "m.lopez@bevosbooks.com",
                    Email = "m.lopez@bevosbooks.com",
                    FirstName = "Marshall",
                    LastName = "Lopez",
                    Address = "90 SW North St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78729",
                    PhoneNumber = "7477907070",
                    Status = true
                },
                Password = "swansong",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "j.macleod@bevosbooks.com",
                    Email = "j.macleod@bevosbooks.com",
                    FirstName = "Jennifer",
                    LastName = "MacLeod",
                    Address = "2504 Far West Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    PhoneNumber = "2621216845",
                    Status = true
                },
                Password = "fungus",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "e.markham@bevosbooks.com",
                    Email = "e.markham@bevosbooks.com",
                    FirstName = "Elizabeth",
                    LastName = "Markham",
                    Address = "7861 Chevy Chase",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78785",
                    PhoneNumber = "5028075807",
                    Status = true
                },
                Password = "median",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "g.martinez@bevosbooks.com",
                    Email = "g.martinez@bevosbooks.com",
                    FirstName = "Gregory",
                    LastName = "Martinez",
                    Address = "8295 Sunset Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "1994708542",
                    Status = true
                },
                Password = "decorate",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "j.mason@bevosbooks.com",
                    Email = "j.mason@bevosbooks.com",
                    FirstName = "Jack",
                    LastName = "Mason",
                    Address = "444 45th St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78701",
                    PhoneNumber = "1748136441",
                    Status = true
                },
                Password = "rankmary",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "c.miller@bevosbooks.com",
                    Email = "c.miller@bevosbooks.com",
                    FirstName = "Charles",
                    LastName = "Miller",
                    Address = "8962 Main St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78709",
                    PhoneNumber = "8999319585",
                    Status = true
                },
                Password = "kindly",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "m.nguyen@bevosbooks.com",
                    Email = "m.nguyen@bevosbooks.com",
                    FirstName = "Mary",
                    LastName = "Nguyen",
                    Address = "465 N. Bear Cub",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78734",
                    PhoneNumber = "8716746381",
                    Status = true
                },
                Password = "ricearoni",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "s.rankin@bevosbooks.com",
                    Email = "s.rankin@bevosbooks.com",
                    FirstName = "Suzie",
                    LastName = "Rankin",
                    Address = "23 Dewey Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "5239029525",
                    Status = true
                },
                Password = "walkamile",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "m.rhodes@bevosbooks.com",
                    Email = "m.rhodes@bevosbooks.com",
                    FirstName = "Megan",
                    LastName = "Rhodes",
                    Address = "4587 Enfield Rd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78729",
                    PhoneNumber = "1232139514",
                    Status = true
                },
                Password = "ingram45",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "e.rice@bevosbooks.com",
                    Email = "e.rice@bevosbooks.com",
                    FirstName = "Eryn",
                    LastName = "Rice",
                    Address = "3405 Rio Grande",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    PhoneNumber = "2706602803",
                    Status = true
                },
                Password = "arched",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "a.rogers@bevosbooks.com",
                    Email = "a.rogers@bevosbooks.com",
                    FirstName = "Allen",
                    LastName = "Rogers",
                    Address = "4965 Oak Hill",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    PhoneNumber = "4139645586",
                    Status = true
                },
                Password = "lottery",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "s.saunders@bevosbooks.com",
                    Email = "s.saunders@bevosbooks.com",
                    FirstName = "Sarah",
                    LastName = "Saunders",
                    Address = "332 Avenue C",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78733",
                    PhoneNumber = "9036349587",
                    Status = true
                },
                Password = "nostalgic",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "w.sewell@bevosbooks.com",
                    Email = "w.sewell@bevosbooks.com",
                    FirstName = "William",
                    LastName = "Sewell",
                    Address = "2365 51st St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78755",
                    PhoneNumber = "7224308314",
                    Status = true
                },
                Password = "offbeat",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "m.sheffield@bevosbooks.com",
                    Email = "m.sheffield@bevosbooks.com",
                    FirstName = "Martin",
                    LastName = "Sheffield",
                    Address = "3886 Avenue A",
                    City = "San Marcos",
                    State = "TX",
                    ZipCode = "78666",
                    PhoneNumber = "9349192978",
                    Status = true
                },
                Password = "evanescent",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "c.silva@bevosbooks.com",
                    Email = "c.silva@bevosbooks.com",
                    FirstName = "Cindy",
                    LastName = "Silva",
                    Address = "900 4th St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78758",
                    PhoneNumber = "4874328170",
                    Status = true
                },
                Password = "stewboy",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "e.stuart@bevosbooks.com",
                    Email = "e.stuart@bevosbooks.com",
                    FirstName = "Eric",
                    LastName = "Stuart",
                    Address = "5576 Toro Ring",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78758",
                    PhoneNumber = "1967846827",
                    Status = true
                },
                Password = "instrument",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "j.tanner@bevosbooks.com",
                    Email = "j.tanner@bevosbooks.com",
                    FirstName = "Jeremy",
                    LastName = "Tanner",
                    Address = "4347 Almstead",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "5923026779",
                    Status = true
                },
                Password = "hecktour",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "a.taylor@bevosbooks.com",
                    Email = "a.taylor@bevosbooks.com",
                    FirstName = "Allison",
                    LastName = "Taylor",
                    Address = "467 Nueces St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78727",
                    PhoneNumber = "7246195827",
                    Status = true
                },
                Password = "countryrhodes",
                RoleName = "Employee"
            });

            Employees.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "r.taylor@bevosbooks.com",
                    Email = "r.taylor@bevosbooks.com",
                    FirstName = "Rachel",
                    LastName = "Taylor",
                    Address = "345 Longview Dr.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    PhoneNumber = "9071236087",
                    Status = true
                },
                Password = "landus",
                RoleName = "Employee"
            });

            // UPSERT: Add or update each employee
            foreach (AddUserModel employeeToAdd in Employees)
            {
                AppUser dbUser = await userManager.FindByEmailAsync(employeeToAdd.User.Email);

                if (dbUser == null)
                {
                    var result = await userManager.CreateAsync(employeeToAdd.User, employeeToAdd.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(employeeToAdd.User, employeeToAdd.RoleName);
                    }
                }
                else
                {
                    // Update existing user
                    dbUser.FirstName = employeeToAdd.User.FirstName;
                    dbUser.LastName = employeeToAdd.User.LastName;
                    dbUser.Address = employeeToAdd.User.Address;
                    dbUser.City = employeeToAdd.User.City;
                    dbUser.State = employeeToAdd.User.State;
                    dbUser.ZipCode = employeeToAdd.User.ZipCode;
                    dbUser.PhoneNumber = employeeToAdd.User.PhoneNumber;
                    await userManager.UpdateAsync(dbUser);
                }
            }
        }
    }
}
