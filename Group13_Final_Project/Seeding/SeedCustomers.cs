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
    public static class SeedCustomers
    {
        public static async Task SeedAllCustomers(UserManager<AppUser> userManager, AppDbContext db)
        {
            List<AddUserModel> Customers = new List<AddUserModel>();

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "cbaker@example.com",
                    Email = "cbaker@example.com",
                    FirstName = "Christopher",
                    LastName = "Baker",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "1898 Schurz Alley",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    PhoneNumber = "5725458641",
                    Status = true
                },
                Password = "bookworm",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "banker@longhorn.net",
                    Email = "banker@longhorn.net",
                    FirstName = "Michelle",
                    LastName = "Banks",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "97 Elmside Pass",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "9867048435",
                    Status = true
                },
                Password = "potato",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "franco@example.com",
                    Email = "franco@example.com",
                    FirstName = "Franco",
                    LastName = "Broccolo",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "88 Crowley Circle",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78786",
                    PhoneNumber = "6836109514",
                    Status = true
                },
                Password = "painting",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "wchang@example.com",
                    Email = "wchang@example.com",
                    FirstName = "Wendy",
                    LastName = "Chang",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "56560 Sage Junction",
                    City = "Eagle Pass",
                    State = "TX",
                    ZipCode = "78852",
                    PhoneNumber = "7070911071",
                    Status = true
                },
                Password = "texas1",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "limchou@gogle.com",
                    Email = "limchou@gogle.com",
                    FirstName = "Lim",
                    LastName = "Chou",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "60 Lunder Point",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78729",
                    PhoneNumber = "1488907687",
                    Status = true
                },
                Password = "Anchorage",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "shdixon@aoll.com",
                    Email = "shdixon@aoll.com",
                    FirstName = "Shan",
                    LastName = "Dixon",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "9448 Pleasure Avenue",
                    City = "Georgetown",
                    State = "TX",
                    ZipCode = "78628",
                    PhoneNumber = "6899701824",
                    Status = true
                },
                Password = "aggies",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "j.b.evans@aheca.org",
                    Email = "j.b.evans@aheca.org",
                    FirstName = "Jim Bob",
                    LastName = "Evans",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "51 Emmet Parkway",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    PhoneNumber = "9986825917",
                    Status = true
                },
                Password = "hampton1",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "feeley@penguin.org",
                    Email = "feeley@penguin.org",
                    FirstName = "Lou Ann",
                    LastName = "Feeley",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "65 Darwin Crossing",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78704",
                    PhoneNumber = "3464121966",
                    Status = true
                },
                Password = "longhorns",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "tfreeley@minnetonka.ci.us",
                    Email = "tfreeley@minnetonka.ci.us",
                    FirstName = "Tesa",
                    LastName = "Freeley",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "7352 Loftsgordon Court",
                    City = "College Station",
                    State = "TX",
                    ZipCode = "77840",
                    PhoneNumber = "6581357270",
                    Status = true
                },
                Password = "mustangs",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "mgarcia@gogle.com",
                    Email = "mgarcia@gogle.com",
                    FirstName = "Margaret",
                    LastName = "Garcia",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "7 International Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78756",
                    PhoneNumber = "3767347949",
                    Status = true
                },
                Password = "onetime",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "chaley@thug.com",
                    Email = "chaley@thug.com",
                    FirstName = "Charles",
                    LastName = "Haley",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "8 Warrior Trail",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    PhoneNumber = "2198604221",
                    Status = true
                },
                Password = "pepperoni",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "jeffh@sonic.com",
                    Email = "jeffh@sonic.com",
                    FirstName = "Jeffrey",
                    LastName = "Hampton",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "9107 Lighthouse Bay Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78756",
                    PhoneNumber = "1222185888",
                    Status = true
                },
                Password = "raiders",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "wjhearniii@umich.org",
                    Email = "wjhearniii@umich.org",
                    FirstName = "John",
                    LastName = "Hearn",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "59784 Pierstorff Center",
                    City = "Liberty",
                    State = "TX",
                    ZipCode = "77575",
                    PhoneNumber = "5123071976",
                    Status = true
                },
                Password = "jhearn22",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "ahick@yaho.com",
                    Email = "ahick@yaho.com",
                    FirstName = "Anthony",
                    LastName = "Hicks",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "932 Monica Way",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78203",
                    PhoneNumber = "1211949601",
                    Status = true
                },
                Password = "hickhickup",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "ingram@jack.com",
                    Email = "ingram@jack.com",
                    FirstName = "Brad",
                    LastName = "Ingram",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "4 Lukken Court",
                    City = "New Braunfels",
                    State = "TX",
                    ZipCode = "78132",
                    PhoneNumber = "1372121569",
                    Status = true
                },
                Password = "ingram2015",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "toddj@yourmom.com",
                    Email = "toddj@yourmom.com",
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "7 Susan Junction",
                    City = "New York",
                    State = "NY",
                    ZipCode = "10101",
                    PhoneNumber = "8543163836",
                    Status = true
                },
                Password = "toddy25",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "thequeen@aska.net",
                    Email = "thequeen@aska.net",
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "669 Oak Junction",
                    City = "Lockhart",
                    State = "TX",
                    ZipCode = "78644",
                    PhoneNumber = "3214163359",
                    Status = true
                },
                Password = "something",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "linebacker@gogle.com",
                    Email = "linebacker@gogle.com",
                    FirstName = "Erik",
                    LastName = "Lineback",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "099 Luster Point",
                    City = "Kingwood",
                    State = "TX",
                    ZipCode = "77325",
                    PhoneNumber = "2505265350",
                    Status = true
                },
                Password = "Password1",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "elowe@netscare.net",
                    Email = "elowe@netscare.net",
                    FirstName = "Ernest",
                    LastName = "Lowe",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "35473 Hansons Hill",
                    City = "Beverly Hills",
                    State = "CA",
                    ZipCode = "90210",
                    PhoneNumber = "4070619503",
                    Status = true
                },
                Password = "aclfest2017",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "cluce@gogle.com",
                    Email = "cluce@gogle.com",
                    FirstName = "Chuck",
                    LastName = "Luce",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "4 Emmet Junction",
                    City = "Navasota",
                    State = "TX",
                    ZipCode = "77868",
                    PhoneNumber = "7358436110",
                    Status = true
                },
                Password = "nothinggood",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "mackcloud@george.com",
                    Email = "mackcloud@george.com",
                    FirstName = "Jennifer",
                    LastName = "MacLeod",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "3 Orin Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "7240178229",
                    Status = true
                },
                Password = "whatever",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "cmartin@beets.com",
                    Email = "cmartin@beets.com",
                    FirstName = "Elizabeth",
                    LastName = "Markham",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "8171 Commercial Crossing",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "2495200223",
                    Status = true
                },
                Password = "snowsnow",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "clarence@yoho.com",
                    Email = "clarence@yoho.com",
                    FirstName = "Clarence",
                    LastName = "Martin",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "96 Anthes Place",
                    City = "Schenectady",
                    State = "NY",
                    ZipCode = "12345",
                    PhoneNumber = "4086179161",
                    Status = true
                },
                Password = "whocares",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "gregmartinez@drdre.com",
                    Email = "gregmartinez@drdre.com",
                    FirstName = "Gregory",
                    LastName = "Martinez",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "10 Northridge Plaza",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78717",
                    PhoneNumber = "9371927523",
                    Status = true
                },
                Password = "xcellent",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "cmiller@bob.com",
                    Email = "cmiller@bob.com",
                    FirstName = "Charles",
                    LastName = "Miller",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "87683 Schmedeman Circle",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78727",
                    PhoneNumber = "5954063857",
                    Status = true
                },
                Password = "mydogspot",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "knelson@aoll.com",
                    Email = "knelson@aoll.com",
                    FirstName = "Kelly",
                    LastName = "Nelson",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "3244 Ludington Court",
                    City = "Beaumont",
                    State = "TX",
                    ZipCode = "77720",
                    PhoneNumber = "8929209512",
                    Status = true
                },
                Password = "spotmydog",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "joewin@xfactor.com",
                    Email = "joewin@xfactor.com",
                    FirstName = "Joe",
                    LastName = "Nguyen",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "4780 Talisman Court",
                    City = "San Marcos",
                    State = "TX",
                    ZipCode = "78667",
                    PhoneNumber = "9226301774",
                    Status = true
                },
                Password = "joejoejoe",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "orielly@foxnews.cnn",
                    Email = "orielly@foxnews.cnn",
                    FirstName = "Bill",
                    LastName = "O'Reilly",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "4154 Delladonna Plaza",
                    City = "Bergheim",
                    State = "TX",
                    ZipCode = "78004",
                    PhoneNumber = "2537646912",
                    Status = true
                },
                Password = "billyboy",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "ankaisrad@gogle.com",
                    Email = "ankaisrad@gogle.com",
                    FirstName = "Anka",
                    LastName = "Radkovich",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "72361 Bayside Drive",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78789",
                    PhoneNumber = "2182889379",
                    Status = true
                },
                Password = "radgirl",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "megrhodes@freserve.co.uk",
                    Email = "megrhodes@freserve.co.uk",
                    FirstName = "Megan",
                    LastName = "Rhodes",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "76875 Hoffman Point",
                    City = "Orlando",
                    State = "FL",
                    ZipCode = "32830",
                    PhoneNumber = "9532396075",
                    Status = true
                },
                Password = "meganr34",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "erynrice@aoll.com",
                    Email = "erynrice@aoll.com",
                    FirstName = "Eryn",
                    LastName = "Rice",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "048 Elmside Park",
                    City = "South Padre Island",
                    State = "TX",
                    ZipCode = "78597",
                    PhoneNumber = "7303815953",
                    Status = true
                },
                Password = "ricearoni",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "jorge@noclue.com",
                    Email = "jorge@noclue.com",
                    FirstName = "Jorge",
                    LastName = "Rodriguez",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "01 Browning Pass",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78744",
                    PhoneNumber = "3677322422",
                    Status = true
                },
                Password = "alaskaboy",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "mrrogers@lovelyday.com",
                    Email = "mrrogers@lovelyday.com",
                    FirstName = "Allen",
                    LastName = "Rogers",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "844 Anderson Alley",
                    City = "Canyon Lake",
                    State = "TX",
                    ZipCode = "78133",
                    PhoneNumber = "3911705385",
                    Status = true
                },
                Password = "bunnyhop",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "stjean@athome.com",
                    Email = "stjean@athome.com",
                    FirstName = "Olivier",
                    LastName = "Saint-Jean",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "1891 Docker Point",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78779",
                    PhoneNumber = "7351610920",
                    Status = true
                },
                Password = "dustydusty",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "saunders@pen.com",
                    Email = "saunders@pen.com",
                    FirstName = "Sarah",
                    LastName = "Saunders",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "1469 Upham Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78720",
                    PhoneNumber = "5269661692",
                    Status = true
                },
                Password = "jrod2017",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "willsheff@email.com",
                    Email = "willsheff@email.com",
                    FirstName = "William",
                    LastName = "Sewell",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "1672 Oak Valley Circle",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    PhoneNumber = "1875727246",
                    Status = true
                },
                Password = "martin1234",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "sheffiled@gogle.com",
                    Email = "sheffiled@gogle.com",
                    FirstName = "Martin",
                    LastName = "Sheffield",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "816 Kennedy Place",
                    City = "Round Rock",
                    State = "TX",
                    ZipCode = "78680",
                    PhoneNumber = "1394323615",
                    Status = true
                },
                Password = "penguin12",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "johnsmith187@aoll.com",
                    Email = "johnsmith187@aoll.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "0745 Golf Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78760",
                    PhoneNumber = "6645937874",
                    Status = true
                },
                Password = "rogerthat",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "dustroud@mail.com",
                    Email = "dustroud@mail.com",
                    FirstName = "Dustin",
                    LastName = "Stroud",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "505 Dexter Plaza",
                    City = "Sweet Home",
                    State = "TX",
                    ZipCode = "77987",
                    PhoneNumber = "6470254680",
                    Status = true
                },
                Password = "smitty444",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "estuart@anchor.net",
                    Email = "estuart@anchor.net",
                    FirstName = "Eric",
                    LastName = "Stuart",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "585 Claremont Drive",
                    City = "Corpus Christi",
                    State = "TX",
                    ZipCode = "78412",
                    PhoneNumber = "7701621022",
                    Status = true
                },
                Password = "stewball",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "peterstump@noclue.com",
                    Email = "peterstump@noclue.com",
                    FirstName = "Peter",
                    LastName = "Stump",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "89035 Welch Circle",
                    City = "Pflugerville",
                    State = "TX",
                    ZipCode = "78660",
                    PhoneNumber = "2181960061",
                    Status = true
                },
                Password = "slowwind",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "jtanner@mustang.net",
                    Email = "jtanner@mustang.net",
                    FirstName = "Jeremy",
                    LastName = "Tanner",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "4 Stang Trail",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78702",
                    PhoneNumber = "9908469499",
                    Status = true
                },
                Password = "tanner5454",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "taylordjay@aoll.com",
                    Email = "taylordjay@aoll.com",
                    FirstName = "Allison",
                    LastName = "Taylor",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "726 Twin Pines Avenue",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78713",
                    PhoneNumber = "7011918647",
                    Status = true
                },
                Password = "allyrally",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "rtaylor@gogle.com",
                    Email = "rtaylor@gogle.com",
                    FirstName = "Rachel",
                    LastName = "Taylor",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "06605 Sugar Drive",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "8937910053",
                    Status = true
                },
                Password = "taylorbaylor",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "teefrank@noclue.com",
                    Email = "teefrank@noclue.com",
                    FirstName = "Frank",
                    LastName = "Tee",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "3567 Dawn Plaza",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78786",
                    PhoneNumber = "6394568913",
                    Status = true
                },
                Password = "teeoff22",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "ctucker@alphabet.co.uk",
                    Email = "ctucker@alphabet.co.uk",
                    FirstName = "Clent",
                    LastName = "Tucker",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "704 Northland Alley",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78279",
                    PhoneNumber = "2676838676",
                    Status = true
                },
                Password = "tucksack1",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "avelasco@yoho.com",
                    Email = "avelasco@yoho.com",
                    FirstName = "Allen",
                    LastName = "Velasco",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "72 Harbort Point",
                    City = "Navasota",
                    State = "TX",
                    ZipCode = "77868",
                    PhoneNumber = "3452909754",
                    Status = true
                },
                Password = "meow88",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "vinovino@grapes.com",
                    Email = "vinovino@grapes.com",
                    FirstName = "Janet",
                    LastName = "Vino",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "1 Oak Valley Place",
                    City = "Boston",
                    State = "MA",
                    ZipCode = "2114",
                    PhoneNumber = "8567089194",
                    Status = true
                },
                Password = "vinovino",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "westj@pioneer.net",
                    Email = "westj@pioneer.net",
                    FirstName = "Jake",
                    LastName = "West",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "48743 Banding Parkway",
                    City = "Marble Falls",
                    State = "TX",
                    ZipCode = "78654",
                    PhoneNumber = "6260784394",
                    Status = true
                },
                Password = "gowest",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "winner@hootmail.com",
                    Email = "winner@hootmail.com",
                    FirstName = "Louis",
                    LastName = "Winthorpe",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "96850 Summit Crossing",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78730",
                    PhoneNumber = "3733971174",
                    Status = true
                },
                Password = "louielouie",
                RoleName = "Customer"
            });

            Customers.Add(new AddUserModel
            {
                User = new AppUser
                {
                    UserName = "rwood@voyager.net",
                    Email = "rwood@voyager.net",
                    FirstName = "Reagan",
                    LastName = "Wood",
                    Birthday = new DateTime(1970, 1, 1),
                    Address = "18354 Bluejay Street",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    PhoneNumber = "8433359800",
                    Status = true
                },
                Password = "woodyman1",
                RoleName = "Customer"
            });

            // UPSERT: Add or update each customer
            foreach (AddUserModel customerToAdd in Customers)
            {
                AppUser dbUser = await userManager.FindByEmailAsync(customerToAdd.User.Email);

                if (dbUser == null)
                {
                    var result = await userManager.CreateAsync(customerToAdd.User, customerToAdd.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(customerToAdd.User, customerToAdd.RoleName);
                    }
                }
                else
                {
                    // Update existing user
                    dbUser.FirstName = customerToAdd.User.FirstName;
                    dbUser.LastName = customerToAdd.User.LastName;
                    dbUser.Birthday = customerToAdd.User.Birthday;
                    dbUser.Address = customerToAdd.User.Address;
                    dbUser.City = customerToAdd.User.City;
                    dbUser.State = customerToAdd.User.State;
                    dbUser.ZipCode = customerToAdd.User.ZipCode;
                    dbUser.PhoneNumber = customerToAdd.User.PhoneNumber;
                    await userManager.UpdateAsync(dbUser);
                }
            }
        }
    }
}
