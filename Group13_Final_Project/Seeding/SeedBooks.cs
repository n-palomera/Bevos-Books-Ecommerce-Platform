using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Group13_Final_Project.Seeding
{
    public static class SeedBooks
    {
        public static void SeedAllBooks(AppDbContext db)
        {
            // PART 1: Create list to hold books
            List<Book> Books = new List<Book>();

            // PART 2: Add all books to the list

            // The Art Of Racing In The Rain
            Books.Add(new Book
            {
                BookNumber = 789001,
                Title = "The Art Of Racing In The Rain",
                Description = "A Lab-terrier mix with great insight into the human condition helps his owner, a struggling race car driver.",
                Price = 23.95M,
                Cost = 10.30M,
                PublishDate = new DateTime(2008, 5, 24),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Garth Stein",
                BookStatus = BookStatusEnum.Active
            });

            // The Host
            Books.Add(new Book
            {
                BookNumber = 789002,
                Title = "The Host",
                Description = "Aliens have taken control of the minds and bodies of most humans, but one woman won’t surrender.",
                Price = 25.99M,
                Cost = 13.25M,
                PublishDate = new DateTime(2008, 5, 24),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                Authors = "Stephenie Meyer",
                BookStatus = BookStatusEnum.Active
            });

            // Chasing Darkness
            Books.Add(new Book
            {
                BookNumber = 789003,
                Title = "Chasing Darkness",
                Description = "The Los Angeles private eye Elvis Cole responsible for the release of a serial killer?",
                Price = 25.95M,
                Cost = 9.08M,
                PublishDate = new DateTime(2008, 7, 5),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                Authors = "Robert Crais",
                BookStatus = BookStatusEnum.Active
            });

            // Say Goodbye
            Books.Add(new Book
            {
                BookNumber = 789004,
                Title = "Say Goodbye",
                Description = "An F.B.I. agent tracks a serial killer who uses spiders as a weapon.",
                Price = 25.00M,
                Cost = 11.25M,
                PublishDate = new DateTime(2008, 7, 19),
                InventoryQuantity = 5,
                ReorderPoint = 2,
                Authors = "Lisa Gardner",
                BookStatus = BookStatusEnum.Active
            });

            // The Gargoyle
            Books.Add(new Book
            {
                BookNumber = 789005,
                Title = "The Gargoyle",
                Description = "A hideously burned man is cared for by a sculptress who claims they were lovers seven centuries ago.",
                Price = 25.95M,
                Cost = 16.09M,
                PublishDate = new DateTime(2008, 8, 9),
                InventoryQuantity = 5,
                ReorderPoint = 3,
                Authors = "Andrew Davidson",
                BookStatus = BookStatusEnum.Active
            });

            // Foreign Body
            Books.Add(new Book
            {
                BookNumber = 789006,
                Title = "Foreign Body",
                Description = "A medical student investigates a rising number of deaths among medical tourists at foreign hospitals.",
                Price = 25.95M,
                Cost = 24.65M,
                PublishDate = new DateTime(2008, 8, 9),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                Authors = "Robin Cook",
                BookStatus = BookStatusEnum.Active
            });

            // Acheron
            Books.Add(new Book
            {
                BookNumber = 789007,
                Title = "Acheron",
                Description = "Book 12 of the Dark-Hunter paranormal series.",
                Price = 24.95M,
                Cost = 13.72M,
                PublishDate = new DateTime(2008, 8, 9),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                Authors = "Sherrilyn Kenyon",
                BookStatus = BookStatusEnum.Active
            });

            // Being Elizabeth
            Books.Add(new Book
            {
                BookNumber = 789008,
                Title = "Being Elizabeth",
                Description = "A 25-year-old newly in control of her family’s corporate empire faces tough choices in business and in love.",
                Price = 27.95M,
                Cost = 21.80M,
                PublishDate = new DateTime(2008, 8, 23),
                InventoryQuantity = 9,
                ReorderPoint = 5,
                Authors = "Barbara Taylor Bradford",
                BookStatus = BookStatusEnum.Active
            });

            // Just Breathe
            Books.Add(new Book
            {
                BookNumber = 789009,
                Title = "Just Breathe",
                Description = "Her marriage broken, the author of a syndicated comic strip flees to California, where romance and surprise await.",
                Price = 25.95M,
                Cost = 5.45M,
                PublishDate = new DateTime(2008, 8, 30),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                Authors = "Susan Wiggs",
                BookStatus = BookStatusEnum.Active
            });

            // The Gypsy Morph
            Books.Add(new Book
            {
                BookNumber = 789010,
                Title = "The Gypsy Morph",
                Description = "In the third volume of the Genesis of Shannara series, champions of the Word and the Void clash.",
                Price = 27.00M,
                Cost = 6.75M,
                PublishDate = new DateTime(2008, 8, 30),
                InventoryQuantity = 6,
                ReorderPoint = 6,
                Authors = "Terry Brooks",
                BookStatus = BookStatusEnum.Active
            });

            // The Other Queen
            Books.Add(new Book
            {
                BookNumber = 789011,
                Title = "The Other Queen",
                Description = "The story of Mary, Queen of Scots, in captivity under Queen Elizabeth.",
                Price = 25.95M,
                Cost = 23.61M,
                PublishDate = new DateTime(2008, 9, 20),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                Authors = "Philippa Gregory",
                BookStatus = BookStatusEnum.Active
            });

            // One Fifth Avenue
            Books.Add(new Book
            {
                BookNumber = 789012,
                Title = "One Fifth Avenue",
                Description = "The worlds of gossip, theater and hedge funds have one address in common.",
                Price = 25.95M,
                Cost = 17.65M,
                PublishDate = new DateTime(2008, 9, 27),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Candace Bushnell",
                BookStatus = BookStatusEnum.Active
            });

            // The Given Day
            Books.Add(new Book
            {
                BookNumber = 789013,
                Title = "The Given Day",
                Description = "A policman, a fugitive and their families persevere in the turbulence of Boston at the end of World War I.",
                Price = 27.95M,
                Cost = 6.99M,
                PublishDate = new DateTime(2008, 9, 27),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                Authors = "Dennis Lehane",
                BookStatus = BookStatusEnum.Active
            });

            // A Cedar Cove Christmas
            Books.Add(new Book
            {
                BookNumber = 789014,
                Title = "A Cedar Cove Christmas",
                Description = "A pregnant woman shows up in Cedar Cove on Christmas Eve and goes into labor in a room above a stable.",
                Price = 16.95M,
                Cost = 4.75M,
                PublishDate = new DateTime(2008, 10, 4),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // The Pirate King
            Books.Add(new Book
            {
                BookNumber = 789015,
                Title = "The Pirate King",
                Description = "In Book 2 of the Transitions fantasy series, Drizzt returns to Luskan, a city dominated by dangerous pirates.",
                Price = 27.95M,
                Cost = 14.25M,
                PublishDate = new DateTime(2008, 10, 11),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                Authors = "R A Salvatore",
                BookStatus = BookStatusEnum.Active
            });

            // Bones
            Books.Add(new Book
            {
                BookNumber = 789016,
                Title = "Bones",
                Description = "The psychologist-detective Alex Delaware is called in when women’s bodies keep turning up in a Los Angeles marsh.",
                Price = 27.00M,
                Cost = 14.85M,
                PublishDate = new DateTime(2008, 10, 25),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                Authors = "Jonathan Kellerman",
                BookStatus = BookStatusEnum.Active
            });

            // Rough Weather
            Books.Add(new Book
            {
                BookNumber = 789017,
                Title = "Rough Weather",
                Description = "The Boston private eye Spenser gets involved when a gunman kidnaps the bride from her wedding on a private island.",
                Price = 26.95M,
                Cost = 20.75M,
                PublishDate = new DateTime(2008, 10, 25),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                Authors = "Robert B Parker",
                BookStatus = BookStatusEnum.Active
            });

            // Extreme Measures
            Books.Add(new Book
            {
                BookNumber = 789018,
                Title = "Extreme Measures",
                Description = "Mitch Rapp teams up with a C.I.A. colleague to fight a terrorist cell — and the politicians who would rein them in.",
                Price = 27.95M,
                Cost = 15.09M,
                PublishDate = new DateTime(2008, 10, 25),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "Vince Flynn",
                BookStatus = BookStatusEnum.Active
            });

            // A Good Woman
            Books.Add(new Book
            {
                BookNumber = 789019,
                Title = "A Good Woman",
                Description = "An American society girl who made a new life as a doctor in World War I France returns to New York.",
                Price = 27.00M,
                Cost = 10.53M,
                PublishDate = new DateTime(2008, 11, 1),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                Authors = "Danielle Steel",
                BookStatus = BookStatusEnum.Active
            });

            // Midnight
            Books.Add(new Book
            {
                BookNumber = 789020,
                Title = "Midnight",
                Description = "A boy from Sudan struggles to protect his mother and sister and remain true to his Islamic principles in a Brooklyn housing project.",
                Price = 26.95M,
                Cost = 21.29M,
                PublishDate = new DateTime(2008, 11, 8),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                Authors = "Sister Souljah",
                BookStatus = BookStatusEnum.Active
            });

            // Scarpetta
            Books.Add(new Book
            {
                BookNumber = 789021,
                Title = "Scarpetta",
                Description = "The forensic pathologist Kay Scarpetta takes an assignment in New York City.",
                Price = 27.95M,
                Cost = 13.14M,
                PublishDate = new DateTime(2008, 12, 6),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Patricia Cornwell",
                BookStatus = BookStatusEnum.Active
            });

            // A Darker Place
            Books.Add(new Book
            {
                BookNumber = 789022,
                Title = "A Darker Place",
                Description = "A Russian defector becomes a counterspy.",
                Price = 26.95M,
                Cost = 11.86M,
                PublishDate = new DateTime(2009, 1, 31),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                Authors = "Jack Higgins",
                BookStatus = BookStatusEnum.Active
            });

            // Fatally Flaky
            Books.Add(new Book
            {
                BookNumber = 789023,
                Title = "Fatally Flaky",
                Description = "The caterer Goldy Schulz tries to outwit a killer on the grounds of an Aspen spa.",
                Price = 25.99M,
                Cost = 22.09M,
                PublishDate = new DateTime(2009, 4, 11),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                Authors = "Diane Mott Davidson",
                BookStatus = BookStatusEnum.Active
            });

            // Turn Coat
            Books.Add(new Book
            {
                BookNumber = 789024,
                Title = "Turn Coat",
                Description = "Book 11 of the Dresden Files series about a wizard detective in Chicago.",
                Price = 25.95M,
                Cost = 9.34M,
                PublishDate = new DateTime(2009, 4, 11),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                Authors = "Jim Butcher",
                BookStatus = BookStatusEnum.Active
            });

            // Borderline
            Books.Add(new Book
            {
                BookNumber = 789025,
                Title = "Borderline",
                Description = "Off duty and on vacation in Big Bend National Park, Anna Pigeon rescues a baby and is drawn into cross-border intrigue.",
                Price = 25.95M,
                Cost = 3.11M,
                PublishDate = new DateTime(2009, 4, 11),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                Authors = "Nevada Barr",
                BookStatus = BookStatusEnum.Active
            });

            // Summer On Blossom Street
            Books.Add(new Book
            {
                BookNumber = 789026,
                Title = "Summer On Blossom Street",
                Description = "More stories of life and love from a Seattle knitting class.",
                Price = 24.95M,
                Cost = 7.24M,
                PublishDate = new DateTime(2009, 5, 2),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // Dead And Gone
            Books.Add(new Book
            {
                BookNumber = 789027,
                Title = "Dead And Gone",
                Description = "Sookie Stackhouse searches for the killer of a werepanther.",
                Price = 25.95M,
                Cost = 24.65M,
                PublishDate = new DateTime(2009, 5, 9),
                InventoryQuantity = 10,
                ReorderPoint = 5,
                Authors = "Charlaine Harris",
                BookStatus = BookStatusEnum.Active
            });

            // Brooklyn
            Books.Add(new Book
            {
                BookNumber = 789028,
                Title = "Brooklyn",
                Description = "An unsophisticated young Irishwoman leaves her home for New York in the 1950s. Originally published in 2009 and the basis of the 2015 movie.",
                Price = 18.95M,
                Cost = 3.60M,
                PublishDate = new DateTime(2009, 5, 9),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                Authors = "Colm Toibin",
                BookStatus = BookStatusEnum.Active
            });

            // The Last Child
            Books.Add(new Book
            {
                BookNumber = 789029,
                Title = "The Last Child",
                Description = "A teenager searches for his inexplicably vanished twin sister.",
                Price = 24.95M,
                Cost = 15.72M,
                PublishDate = new DateTime(2009, 5, 16),
                InventoryQuantity = 5,
                ReorderPoint = 2,
                Authors = "John Hart",
                BookStatus = BookStatusEnum.Active
            });

            // Heartless
            Books.Add(new Book
            {
                BookNumber = 789030,
                Title = "Heartless",
                Description = "A woman‘s secret makes it hard for her to accept her stepbrother‘s love.",
                Price = 24.95M,
                Cost = 21.46M,
                PublishDate = new DateTime(2009, 5, 30),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Diana Palmer",
                BookStatus = BookStatusEnum.Active
            });

            // Shanghai Girls
            Books.Add(new Book
            {
                BookNumber = 789031,
                Title = "Shanghai Girls",
                Description = "Two Chinese sisters in the 1930s are sold as wives to men from California, and leave their war-torn country to join them.",
                Price = 25.00M,
                Cost = 2.50M,
                PublishDate = new DateTime(2009, 5, 30),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Lisa See",
                BookStatus = BookStatusEnum.Active
            });

            // Skin Trade
            Books.Add(new Book
            {
                BookNumber = 789032,
                Title = "Skin Trade",
                Description = "Investigating some killings in Las Vegas, the vampire hunter Anita Blake must contend with the power of the weretigers.",
                Price = 26.95M,
                Cost = 2.70M,
                PublishDate = new DateTime(2009, 6, 6),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                Authors = "Laurell K Hamilton",
                BookStatus = BookStatusEnum.Active
            });

            // Roadside Crosses
            Books.Add(new Book
            {
                BookNumber = 789033,
                Title = "Roadside Crosses",
                Description = "A California kinesics expert pursues a killer who stalks victims using information they’ve posted online.",
                Price = 26.95M,
                Cost = 7.82M,
                PublishDate = new DateTime(2009, 6, 13),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Jeffery Deaver",
                BookStatus = BookStatusEnum.Active
            });

            // Finger Lickin’ Fifteen
            Books.Add(new Book
            {
                BookNumber = 789034,
                Title = "Finger Lickin’ Fifteen",
                Description = "The bounty hunter Stephanie Plum hunts a celebrity chef’s killer.",
                Price = 27.95M,
                Cost = 3.63M,
                PublishDate = new DateTime(2009, 6, 27),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                Authors = "Janet Evanovich",
                BookStatus = BookStatusEnum.Active
            });

            // Return To Sullivans Island
            Books.Add(new Book
            {
                BookNumber = 789035,
                Title = "Return To Sullivans Island",
                Description = "A recent college graduate returns to her family’s home on an island in the South Carolina Lowcountry and wrestles with tragedy and betrayal in the company of her appealing relatives.",
                Price = 25.99M,
                Cost = 13.25M,
                PublishDate = new DateTime(2009, 7, 4),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Dorothea Benton Frank",
                BookStatus = BookStatusEnum.Active
            });

            // The Castaways
            Books.Add(new Book
            {
                BookNumber = 789036,
                Title = "The Castaways",
                Description = "A Nantucket couple drowns, raising questions and precipitating conflicts among their group of friends.",
                Price = 24.99M,
                Cost = 16.99M,
                PublishDate = new DateTime(2009, 7, 11),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                Authors = "Elin Hilderbrand",
                BookStatus = BookStatusEnum.Active
            });

            // Rain Gods
            Books.Add(new Book
            {
                BookNumber = 789037,
                Title = "Rain Gods",
                Description = "A Texas sheriff investigates a mass murder of illegal aliens and tries to find the young Iraq war veteran who may have been involved — before the F.B.I. can.",
                Price = 25.99M,
                Cost = 21.05M,
                PublishDate = new DateTime(2009, 7, 18),
                InventoryQuantity = 6,
                ReorderPoint = 2,
                Authors = "James Lee Burke",
                BookStatus = BookStatusEnum.Active
            });

            // Undone
            Books.Add(new Book
            {
                BookNumber = 789038,
                Title = "Undone",
                Description = "Dr. Sara Linton works with agents of the Georgia Bureau of Investigation to stop a killer who tortures his victims.",
                Price = 26.00M,
                Cost = 7.28M,
                PublishDate = new DateTime(2009, 7, 18),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "Karin Slaughter",
                BookStatus = BookStatusEnum.Active
            });

            // Guardian Of Lies
            Books.Add(new Book
            {
                BookNumber = 789039,
                Title = "Guardian Of Lies",
                Description = "The lawyer Paul Madriani unravels a mystery involving gold coins, the C.I.A., and a weapon forgotten since the Cuban missile crisis.",
                Price = 26.99M,
                Cost = 18.62M,
                PublishDate = new DateTime(2009, 7, 18),
                InventoryQuantity = 6,
                ReorderPoint = 2,
                Authors = "Steve Martini",
                BookStatus = BookStatusEnum.Active
            });

            // Dreamfever
            Books.Add(new Book
            {
                BookNumber = 789040,
                Title = "Dreamfever",
                Description = "MacKlaya finds herself under the erotic spell of a Fae master.",
                Price = 26.00M,
                Cost = 21.06M,
                PublishDate = new DateTime(2009, 8, 22),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "Karen Marie Moning",
                BookStatus = BookStatusEnum.Active
            });

            // Resurrecting Midnight
            Books.Add(new Book
            {
                BookNumber = 789041,
                Title = "Resurrecting Midnight",
                Description = "Gideon, an international assassin, travels to Argentina in pursuit of a dangerous assignment.",
                Price = 26.95M,
                Cost = 14.55M,
                PublishDate = new DateTime(2009, 8, 29),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                Authors = "Eric Jerome Dickey",
                BookStatus = BookStatusEnum.Active
            });

            // Dexter By Design
            Books.Add(new Book
            {
                BookNumber = 789042,
                Title = "Dexter By Design",
                Description = "A serial killer who arranges victims in artful poses challenges the Miami Police Department and its blood splatter analyst, Dexter.",
                Price = 25.00M,
                Cost = 2.75M,
                PublishDate = new DateTime(2009, 9, 12),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Jeff Lindsay",
                BookStatus = BookStatusEnum.Active
            });

            // The Professional
            Books.Add(new Book
            {
                BookNumber = 789043,
                Title = "The Professional",
                Description = "Rich women are turning up dead, and the Boston P.I. Spenser investigates.",
                Price = 26.95M,
                Cost = 7.01M,
                PublishDate = new DateTime(2009, 10, 10),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                Authors = "Robert B Parker",
                BookStatus = BookStatusEnum.Active
            });

            // The Unseen Academicals
            Books.Add(new Book
            {
                BookNumber = 789044,
                Title = "The Unseen Academicals",
                Description = "In this Discworld fantasy, the benevolent tyrant of Ankh-Morpork suggests that Unseen University put together a football team.",
                Price = 25.99M,
                Cost = 3.12M,
                PublishDate = new DateTime(2009, 10, 10),
                InventoryQuantity = 14,
                ReorderPoint = 9,
                Authors = "Terry Pratchett",
                BookStatus = BookStatusEnum.Active
            });

            // Pursuit Of Honor
            Books.Add(new Book
            {
                BookNumber = 789045,
                Title = "Pursuit Of Honor",
                Description = "The counterterrorism operative Mitch Rapp must teach politicians about national security following a new Qaeda attack.",
                Price = 27.99M,
                Cost = 5.04M,
                PublishDate = new DateTime(2009, 10, 17),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Vince Flynn",
                BookStatus = BookStatusEnum.Active
            });

            // No Less Than Victory
            Books.Add(new Book
            {
                BookNumber = 789046,
                Title = "No Less Than Victory",
                Description = "The final volume of a trilogy of novels about World War II focuses on the final years of the war, including the Battle of the Bulge and the American sweep through Germany.",
                Price = 28.00M,
                Cost = 20.72M,
                PublishDate = new DateTime(2009, 11, 7),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                Authors = "Jeff Shaara",
                BookStatus = BookStatusEnum.Active
            });

            // Ford County
            Books.Add(new Book
            {
                BookNumber = 789047,
                Title = "Ford County",
                Description = "Stories set in rural Mississippi.",
                Price = 24.00M,
                Cost = 14.88M,
                PublishDate = new DateTime(2009, 11, 7),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                Authors = "John Grisham",
                BookStatus = BookStatusEnum.Active
            });

            // Wishin' And Hopin'
            Books.Add(new Book
            {
                BookNumber = 789048,
                Title = "Wishin' And Hopin'",
                Description = "A fifth-grader in 1964 gets ready for Christmas.",
                Price = 15.00M,
                Cost = 13.95M,
                PublishDate = new DateTime(2009, 11, 14),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                Authors = "Wally Lamb",
                BookStatus = BookStatusEnum.Active
            });

            // First Lord’S Fury
            Books.Add(new Book
            {
                BookNumber = 789049,
                Title = "First Lord’S Fury",
                Description = "With their survival at stake, Alerans prepare for a final battle in the sixth book of the Alera fantasy cycle.",
                Price = 25.95M,
                Cost = 13.23M,
                PublishDate = new DateTime(2009, 11, 28),
                InventoryQuantity = 4,
                ReorderPoint = 1,
                Authors = "Jim Butcher",
                BookStatus = BookStatusEnum.Active
            });

            // Altar Of Eden
            Books.Add(new Book
            {
                BookNumber = 789050,
                Title = "Altar Of Eden",
                Description = "A Louisiana veterinarian discovers a wrecked fishing trawler filled with genetically altered animals.",
                Price = 27.99M,
                Cost = 25.75M,
                PublishDate = new DateTime(2010, 1, 2),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                Authors = "James Rollins",
                BookStatus = BookStatusEnum.Active
            });

            // Deeper Than The Dead
            Books.Add(new Book
            {
                BookNumber = 789051,
                Title = "Deeper Than The Dead",
                Description = "An F.B.I. investigator and a teacher track a series of murders in California in 1985.",
                Price = 26.95M,
                Cost = 9.70M,
                PublishDate = new DateTime(2010, 1, 2),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Tami Hoag",
                BookStatus = BookStatusEnum.Active
            });

            // Roses
            Books.Add(new Book
            {
                BookNumber = 789052,
                Title = "Roses",
                Description = "Three generations in a small East Texas town.",
                Price = 24.99M,
                Cost = 20.99M,
                PublishDate = new DateTime(2010, 1, 16),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                Authors = "Leila Meacham",
                BookStatus = BookStatusEnum.Active
            });

            // Blood Ties
            Books.Add(new Book
            {
                BookNumber = 789053,
                Title = "Blood Ties",
                Description = "The F.B.I. agent Noah Bishop and his special crimes unit  pursue a brutal enemy.",
                Price = 26.00M,
                Cost = 5.20M,
                PublishDate = new DateTime(2010, 1, 30),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                Authors = "Kay Hooper",
                BookStatus = BookStatusEnum.Active
            });

            // The Midnight House
            Books.Add(new Book
            {
                BookNumber = 789054,
                Title = "The Midnight House",
                Description = "Who is killing members of a secret unit that interrogated terrorists? The C.I.A. agent John Wells is on the case.",
                Price = 25.95M,
                Cost = 3.11M,
                PublishDate = new DateTime(2010, 2, 13),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                Authors = "Alex Berenson",
                BookStatus = BookStatusEnum.Active
            });

            // Poor Little Bitch Girl
            Books.Add(new Book
            {
                BookNumber = 789055,
                Title = "Poor Little Bitch Girl",
                Description = "Hollywood murder, three beautiful 20-something high school friends, a hot New York club owner.",
                Price = 26.99M,
                Cost = 17.54M,
                PublishDate = new DateTime(2010, 2, 13),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                Authors = "Jackie Collins",
                BookStatus = BookStatusEnum.Active
            });

            // Deep Shadow
            Books.Add(new Book
            {
                BookNumber = 789056,
                Title = "Deep Shadow",
                Description = "Murderers want Doc Ford to help them dive for the remains of a wrecked plane supposedly laden with Cuban gold.",
                Price = 25.95M,
                Cost = 5.45M,
                PublishDate = new DateTime(2010, 3, 13),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                Authors = "Randy Wayne White",
                BookStatus = BookStatusEnum.Active
            });

            // Think Twice
            Books.Add(new Book
            {
                BookNumber = 789057,
                Title = "Think Twice",
                Description = "A woman takes over her twin sister’s life.",
                Price = 26.99M,
                Cost = 21.86M,
                PublishDate = new DateTime(2010, 3, 20),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "Lisa Scottoline",
                BookStatus = BookStatusEnum.Active
            });

            // The Girl Who Chased The Moon
            Books.Add(new Book
            {
                BookNumber = 789058,
                Title = "The Girl Who Chased The Moon",
                Description = "Mysteries and magic in a quirky North Carolina town.",
                Price = 25.00M,
                Cost = 11.25M,
                PublishDate = new DateTime(2010, 3, 20),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                Authors = "Sarah Addison Allen",
                BookStatus = BookStatusEnum.Active
            });

            // Without Mercy
            Books.Add(new Book
            {
                BookNumber = 789059,
                Title = "Without Mercy",
                Description = "Students are dying at an Oregon boarding school for wayward kids, and the concerned new teacher may be the next target.",
                Price = 25.00M,
                Cost = 4.25M,
                PublishDate = new DateTime(2010, 4, 3),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                Authors = "Lisa Jackson",
                BookStatus = BookStatusEnum.Active
            });

            // Wrecked
            Books.Add(new Book
            {
                BookNumber = 789060,
                Title = "Wrecked",
                Description = "In the 13th mystery in this series, the suspicious disappearance of a neighbor interrupts a romantic weekend on Cape Cod for the P.I. Regan Reilly and her husband.",
                Price = 25.00M,
                Cost = 18.00M,
                PublishDate = new DateTime(2010, 4, 17),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "Carol Higgins Clark",
                BookStatus = BookStatusEnum.Active
            });

            // Reckless
            Books.Add(new Book
            {
                BookNumber = 789061,
                Title = "Reckless",
                Description = "A close friend from the investigator Ty Hauck's past has been brutally murdered, and he will risk everything he loves to avenge her death.",
                Price = 22.00M,
                Cost = 9.46M,
                PublishDate = new DateTime(2010, 5, 1),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "Andrew Gross",
                BookStatus = BookStatusEnum.Active
            });

            // Executive Intent
            Books.Add(new Book
            {
                BookNumber = 789062,
                Title = "Executive Intent",
                Description = "With the United States unleashing a missile-launching satellite that can strike anywhere in seconds, China and Russia respond swiftly and brutally.",
                Price = 27.95M,
                Cost = 22.64M,
                PublishDate = new DateTime(2010, 5, 15),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                Authors = "Dale Brown",
                BookStatus = BookStatusEnum.Active
            });

            // Heart Of The Matter
            Books.Add(new Book
            {
                BookNumber = 789063,
                Title = "Heart Of The Matter",
                Description = "The lives of two women — one married to a pediatric plastic surgeon, the other a lawyer and single mother — converge after an accident involving the lawyer’s son.",
                Price = 26.99M,
                Cost = 6.21M,
                PublishDate = new DateTime(2010, 5, 15),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                Authors = "Emily Giffin",
                BookStatus = BookStatusEnum.Active
            });

            // That Perfect Someone
            Books.Add(new Book
            {
                BookNumber = 789064,
                Title = "That Perfect Someone",
                Description = "To avoid falling into a ruthless nobleman's trap, an heiress enters into a risky, intimate charade with a man she was once bound to wed.",
                Price = 25.00M,
                Cost = 18.25M,
                PublishDate = new DateTime(2010, 6, 19),
                InventoryQuantity = 9,
                ReorderPoint = 9,
                Authors = "Johanna Lindsey",
                BookStatus = BookStatusEnum.Active
            });

            // Mission Of Honor
            Books.Add(new Book
            {
                BookNumber = 789065,
                Title = "Mission Of Honor",
                Description = "Honor Harrington defends the Star Kingdom of Manticore as it is besieged by many enemies.",
                Price = 27.00M,
                Cost = 6.75M,
                PublishDate = new DateTime(2010, 6, 26),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                Authors = "David Weber",
                BookStatus = BookStatusEnum.Active
            });

            // Sizzling Sixteen
            Books.Add(new Book
            {
                BookNumber = 789066,
                Title = "Sizzling Sixteen",
                Description = "The bounty hunter Stephanie Plum comes to the aid of a cousin with gambling debts.",
                Price = 27.99M,
                Cost = 12.32M,
                PublishDate = new DateTime(2010, 6, 26),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Janet Evanovich",
                BookStatus = BookStatusEnum.Active
            });

            // The Thousand Autumns Of Jacob De Zoet
            Books.Add(new Book
            {
                BookNumber = 789067,
                Title = "The Thousand Autumns Of Jacob De Zoet",
                Description = "Forbidden love in Edo-era Japan.",
                Price = 26.00M,
                Cost = 9.62M,
                PublishDate = new DateTime(2010, 7, 3),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "David Mitchell",
                BookStatus = BookStatusEnum.Active
            });

            // The Search
            Books.Add(new Book
            {
                BookNumber = 789068,
                Title = "The Search",
                Description = "The only survivor of a serial killer has found peace in the Pacific Northwest, but her life is shaken by the appearance of a new man and a copycat murderer.",
                Price = 26.95M,
                Cost = 8.62M,
                PublishDate = new DateTime(2010, 7, 10),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Nora Roberts",
                BookStatus = BookStatusEnum.Active
            });

            // Death On The D-List
            Books.Add(new Book
            {
                BookNumber = 789069,
                Title = "Death On The D-List",
                Description = "Fading celebrities who appear on Hailey Dean’s TV show are being murdered.",
                Price = 25.99M,
                Cost = 5.98M,
                PublishDate = new DateTime(2010, 8, 14),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                Authors = "Nancy Grace",
                BookStatus = BookStatusEnum.Active
            });

            // No Mercy
            Books.Add(new Book
            {
                BookNumber = 789070,
                Title = "No Mercy",
                Description = "Book 19 of the Dark-Hunter paranormal series.",
                Price = 24.99M,
                Cost = 5.25M,
                PublishDate = new DateTime(2010, 9, 11),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                Authors = "Sherrilyn Kenyon",
                BookStatus = BookStatusEnum.Active
            });

            // The Fall
            Books.Add(new Book
            {
                BookNumber = 789071,
                Title = "The Fall",
                Description = "A war erupts between Old and New World vampires. Book 2 of the Strain trilogy.",
                Price = 26.99M,
                Cost = 13.23M,
                PublishDate = new DateTime(2010, 9, 25),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                Authors = "Guillermo del Toro and Chuck Hogan",
                BookStatus = BookStatusEnum.Active
            });

            // Legacy
            Books.Add(new Book
            {
                BookNumber = 789072,
                Title = "Legacy",
                Description = "A writer’s stunning family discovery leads to Paris, the French aristocracy and a mysterious Sioux ancestor.",
                Price = 28.00M,
                Cost = 6.44M,
                PublishDate = new DateTime(2010, 10, 2),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                Authors = "Danielle Steel",
                BookStatus = BookStatusEnum.Active
            });

            // Call Me Mrs. Miracle
            Books.Add(new Book
            {
                BookNumber = 789073,
                Title = "Call Me Mrs. Miracle",
                Description = "Working in the toy section of a department store, Emily Merkle is called upon to engineer some Christmas miracles.",
                Price = 16.95M,
                Cost = 8.31M,
                PublishDate = new DateTime(2010, 10, 2),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // Promise Me
            Books.Add(new Book
            {
                BookNumber = 789074,
                Title = "Promise Me",
                Description = "On Christmas Day, a woman with family problems meets a handsome, mysterious stranger.",
                Price = 19.99M,
                Cost = 10.79M,
                PublishDate = new DateTime(2010, 10, 9),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Richard Paul Evans",
                BookStatus = BookStatusEnum.Active
            });

            // Crescent Dawn
            Books.Add(new Book
            {
                BookNumber = 789075,
                Title = "Crescent Dawn",
                Description = "Dirk Pitt seeks a tie between a trove of ancient Roman artifacts and a series of mosque explosions.",
                Price = 27.95M,
                Cost = 20.12M,
                PublishDate = new DateTime(2010, 11, 20),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                Authors = "Clive Cussler and Dirk Cussler",
                BookStatus = BookStatusEnum.Active
            });

            // An Object Of Beauty
            Books.Add(new Book
            {
                BookNumber = 789076,
                Title = "An Object Of Beauty",
                Description = "A young, beautiful and ambitious woman ruthlessly ascends the heights of the Manhattan art world.",
                Price = 26.99M,
                Cost = 8.91M,
                PublishDate = new DateTime(2010, 11, 27),
                InventoryQuantity = 6,
                ReorderPoint = 6,
                Authors = "Steve Martin",
                BookStatus = BookStatusEnum.Active
            });

            // Dead Or Alive
            Books.Add(new Book
            {
                BookNumber = 789077,
                Title = "Dead Or Alive",
                Description = "Many characters from Clancy’s previous novels make an appearance as an intelligence group tracks a vicious terrorist called the Emir.",
                Price = 28.95M,
                Cost = 24.03M,
                PublishDate = new DateTime(2010, 12, 11),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                Authors = "Tom Clancy with Grant Blackwood",
                BookStatus = BookStatusEnum.Active
            });

            // Damage
            Books.Add(new Book
            {
                BookNumber = 789078,
                Title = "Damage",
                Description = "The San Francisco detective Abe Glitsky faces a scion of wealth who’s seeking revenge against those who sent him to prison a decade ago.",
                Price = 26.95M,
                Cost = 24.26M,
                PublishDate = new DateTime(2011, 1, 8),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                Authors = "John Lescroart",
                BookStatus = BookStatusEnum.Active
            });

            // The Inner Circle
            Books.Add(new Book
            {
                BookNumber = 789079,
                Title = "The Inner Circle",
                Description = "An archivist discovers a book that once belonged to George Washington and conceals a deadly secret.",
                Price = 26.99M,
                Cost = 11.61M,
                PublishDate = new DateTime(2011, 1, 15),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "Brad Meltzer",
                BookStatus = BookStatusEnum.Active
            });

            // Shadowfever
            Books.Add(new Book
            {
                BookNumber = 789080,
                Title = "Shadowfever",
                Description = "Hunting for her sister’s murderer, MacKayla Lane is caught up in the struggle between humans and the Fae.",
                Price = 26.00M,
                Cost = 13.78M,
                PublishDate = new DateTime(2011, 1, 22),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Karen Marie Moning",
                BookStatus = BookStatusEnum.Active
            });

            // Call Me Irresistible
            Books.Add(new Book
            {
                BookNumber = 789081,
                Title = "Call Me Irresistible",
                Description = "In a small town in Texas, characters from Phillips’s earlier novels reappear as a woman persuades a friend to call off her wedding to the town’s popular mayor.",
                Price = 25.99M,
                Cost = 11.44M,
                PublishDate = new DateTime(2011, 1, 22),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                Authors = "Susan Elizabeth Phillips",
                BookStatus = BookStatusEnum.Active
            });

            // A Discovery Of Witches
            Books.Add(new Book
            {
                BookNumber = 789082,
                Title = "A Discovery Of Witches",
                Description = "The recovery of a lost ancient manuscript in a library at Oxford sets a fantastical underworld stirring.",
                Price = 28.95M,
                Cost = 3.76M,
                PublishDate = new DateTime(2011, 2, 12),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                Authors = "Deborah Harkness",
                BookStatus = BookStatusEnum.Active
            });

            // Gideon’s Sword
            Books.Add(new Book
            {
                BookNumber = 789083,
                Title = "Gideon’s Sword",
                Description = "Gideon Crew avenges his father’s death and is sent on a mission by a government contractor.",
                Price = 26.99M,
                Cost = 19.70M,
                PublishDate = new DateTime(2011, 2, 26),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                Authors = "Douglas Preston and Lincoln Child",
                BookStatus = BookStatusEnum.Active
            });

            // Treachery In Death
            Books.Add(new Book
            {
                BookNumber = 789084,
                Title = "Treachery In Death",
                Description = "Eve Dallas and her partner, Peabody, investigate a grocer’s murder.",
                Price = 26.95M,
                Cost = 5.93M,
                PublishDate = new DateTime(2011, 2, 26),
                InventoryQuantity = 8,
                ReorderPoint = 5,
                Authors = "J D Robb",
                BookStatus = BookStatusEnum.Active
            });

            // Live Wire
            Books.Add(new Book
            {
                BookNumber = 789085,
                Title = "Live Wire",
                Description = "Myron Bolitar’s search for a missing rock star leads to questions about his own missing brother.",
                Price = 27.95M,
                Cost = 13.98M,
                PublishDate = new DateTime(2011, 3, 26),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Harlan Coben",
                BookStatus = BookStatusEnum.Active
            });

            // A Lesson In Secrets
            Books.Add(new Book
            {
                BookNumber = 789086,
                Title = "A Lesson In Secrets",
                Description = "In the summer of 1932, Maisie Dobbs’s first assignment for the British secret service takes her undercover to Cambridge as a professor.",
                Price = 25.99M,
                Cost = 12.22M,
                PublishDate = new DateTime(2011, 3, 26),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                Authors = "Jacqueline Winspear",
                BookStatus = BookStatusEnum.Active
            });

            // Crunch Time
            Books.Add(new Book
            {
                BookNumber = 789087,
                Title = "Crunch Time",
                Description = "The caterer and sleuth Goldy Schulz tries to help a friend whose rental house has been destroyed by arson.",
                Price = 26.99M,
                Cost = 3.78M,
                PublishDate = new DateTime(2011, 4, 9),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "Diane Mott Davidson",
                BookStatus = BookStatusEnum.Active
            });

            // I’Ll Walk Alone
            Books.Add(new Book
            {
                BookNumber = 789088,
                Title = "I’Ll Walk Alone",
                Description = "A woman haunted by the disappearance of her young son discovers that someone has stolen her identity.",
                Price = 25.99M,
                Cost = 3.90M,
                PublishDate = new DateTime(2011, 4, 9),
                InventoryQuantity = 14,
                ReorderPoint = 9,
                Authors = "Mary Higgins Clark",
                BookStatus = BookStatusEnum.Active
            });

            // The Fifth Witness
            Books.Add(new Book
            {
                BookNumber = 789089,
                Title = "The Fifth Witness",
                Description = "The defense lawyer Mickey Haller represents a woman facing home foreclosure who is accused of killing a banker.",
                Price = 27.99M,
                Cost = 6.16M,
                PublishDate = new DateTime(2011, 4, 9),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Michael Connelly",
                BookStatus = BookStatusEnum.Active
            });

            // Save Me
            Books.Add(new Book
            {
                BookNumber = 789090,
                Title = "Save Me",
                Description = "A mother’s action during a school emergency causes an uproar in a Philadelphia suburb.",
                Price = 27.99M,
                Cost = 11.20M,
                PublishDate = new DateTime(2011, 4, 16),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "Lisa Scottoline",
                BookStatus = BookStatusEnum.Active
            });

            // Quicksilver
            Books.Add(new Book
            {
                BookNumber = 789091,
                Title = "Quicksilver",
                Description = "In this Arcane Society novel set in Victorian London, two paranormal talents must find a murderer before they become the next victims.",
                Price = 25.95M,
                Cost = 23.10M,
                PublishDate = new DateTime(2011, 4, 23),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Amanda Quick",
                BookStatus = BookStatusEnum.Active
            });

            // The Sixth Man
            Books.Add(new Book
            {
                BookNumber = 789092,
                Title = "The Sixth Man",
                Description = "The lawyer for an alleged serial killer is murdered, and two former Secret Service agents are on the case.",
                Price = 27.99M,
                Cost = 20.15M,
                PublishDate = new DateTime(2011, 4, 23),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                Authors = "David Baldacci",
                BookStatus = BookStatusEnum.Active
            });

            // Those In Peril
            Books.Add(new Book
            {
                BookNumber = 789093,
                Title = "Those In Peril",
                Description = "A private security agent battles pirates who have kidnapped a woman from a yacht in the Indian Ocean.",
                Price = 27.99M,
                Cost = 16.23M,
                PublishDate = new DateTime(2011, 5, 14),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                Authors = "Wilbur Smith",
                BookStatus = BookStatusEnum.Active
            });

            // The Jefferson Key
            Books.Add(new Book
            {
                BookNumber = 789094,
                Title = "The Jefferson Key",
                Description = "The former government operative Cotton Malone foils an assassination attempt on the president and finds himself at dangerous odds with a secret society.",
                Price = 26.00M,
                Cost = 18.20M,
                PublishDate = new DateTime(2011, 5, 21),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "Steve Berry",
                BookStatus = BookStatusEnum.Active
            });

            // Summer Rental
            Books.Add(new Book
            {
                BookNumber = 789095,
                Title = "Summer Rental",
                Description = "Three friends in their mid-30s spend a month on North Carolina’s Outer Banks.",
                Price = 25.99M,
                Cost = 9.62M,
                PublishDate = new DateTime(2011, 6, 11),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                Authors = "Mary Kay Andrews",
                BookStatus = BookStatusEnum.Active
            });

            // One Summer
            Books.Add(new Book
            {
                BookNumber = 789096,
                Title = "One Summer",
                Description = "As Christmas nears, a terminally ill man is preparing his family for his death when another tragedy strikes.",
                Price = 25.99M,
                Cost = 20.01M,
                PublishDate = new DateTime(2011, 6, 18),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "David Baldacci",
                BookStatus = BookStatusEnum.Active
            });

            // Before I Go To Sleep
            Books.Add(new Book
            {
                BookNumber = 789097,
                Title = "Before I Go To Sleep",
                Description = "After a mysterious accident, an amnesiac cannot remember her past or form new memories.",
                Price = 14.99M,
                Cost = 6.00M,
                PublishDate = new DateTime(2011, 6, 18),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                Authors = "S J Watson",
                BookStatus = BookStatusEnum.Active
            });

            // Now You See Her
            Books.Add(new Book
            {
                BookNumber = 789098,
                Title = "Now You See Her",
                Description = "Nina Bloom, who years ago changed her identity to save her life, is forced to confront the past and the killer she thought she had escaped.",
                Price = 27.99M,
                Cost = 8.40M,
                PublishDate = new DateTime(2011, 7, 2),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "James Patterson and Michael Ledwidge",
                BookStatus = BookStatusEnum.Active
            });

            // Full Black
            Books.Add(new Book
            {
                BookNumber = 789099,
                Title = "Full Black",
                Description = "The covert counterterrorism operative Scot Harvath has a plan to stop a terrorist group that wants to take down the United States.",
                Price = 26.99M,
                Cost = 5.67M,
                PublishDate = new DateTime(2011, 7, 30),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                Authors = "Brad Thor",
                BookStatus = BookStatusEnum.Active
            });

            // Ghost Story
            Books.Add(new Book
            {
                BookNumber = 789100,
                Title = "Ghost Story",
                Description = "Harry Dresden, the wizard detective in Chicago, has been murdered. But that doesn’t stop him when his friends are in danger.",
                Price = 27.95M,
                Cost = 12.02M,
                PublishDate = new DateTime(2011, 7, 30),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Jim Butcher",
                BookStatus = BookStatusEnum.Active
            });

            // Back Of Beyond
            Books.Add(new Book
            {
                BookNumber = 789101,
                Title = "Back Of Beyond",
                Description = "Cody Hoyt, a brilliant cop and an alcoholic struggling with two months of sobriety, is determined to find his mentor’s killer.",
                Price = 25.99M,
                Cost = 24.69M,
                PublishDate = new DateTime(2011, 8, 6),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "C J Box",
                BookStatus = BookStatusEnum.Active
            });

            // The Omen Machine
            Books.Add(new Book
            {
                BookNumber = 789102,
                Title = "The Omen Machine",
                Description = "A return to the lives of Richard Rahl and Kahlan Amnell, in a tale of a new threat to their world.",
                Price = 29.99M,
                Cost = 17.69M,
                PublishDate = new DateTime(2011, 8, 20),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                Authors = "Terry Goodkind",
                BookStatus = BookStatusEnum.Active
            });

            // The Measure Of The Magic
            Books.Add(new Book
            {
                BookNumber = 789103,
                Title = "The Measure Of The Magic",
                Description = "With the land on edge, Panterra is destined to confront a menace who seeks to claim the last black staff, and the life of the one who wields it.",
                Price = 27.00M,
                Cost = 15.39M,
                PublishDate = new DateTime(2011, 8, 27),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                Authors = "Terry Brooks",
                BookStatus = BookStatusEnum.Active
            });

            // How Firm A Foundation
            Books.Add(new Book
            {
                BookNumber = 789104,
                Title = "How Firm A Foundation",
                Description = "The island empire of Charis fights to survive.",
                Price = 27.99M,
                Cost = 23.79M,
                PublishDate = new DateTime(2011, 9, 17),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                Authors = "David Weber",
                BookStatus = BookStatusEnum.Active
            });

            // Reamde
            Books.Add(new Book
            {
                BookNumber = 789105,
                Title = "Reamde",
                Description = "A virus invades a multiplayer online role-playing game and sets off a violent struggle.",
                Price = 35.00M,
                Cost = 14.70M,
                PublishDate = new DateTime(2011, 9, 24),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                Authors = "Neal Stephenson",
                BookStatus = BookStatusEnum.Active
            });

            // Nightwoods
            Books.Add(new Book
            {
                BookNumber = 789106,
                Title = "Nightwoods",
                Description = "When a young woman inherits her murdered sister’s troubled twins, her solitary life becomes filled with mystery and action.",
                Price = 26.00M,
                Cost = 10.92M,
                PublishDate = new DateTime(2011, 10, 1),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                Authors = "Charles Frazier",
                BookStatus = BookStatusEnum.Active
            });

            // The Affair
            Books.Add(new Book
            {
                BookNumber = 789107,
                Title = "The Affair",
                Description = "For Jack Reacher, an elite military police officer, it all started in 1997. A lonely railroad track. A crime scene. A cover-up.",
                Price = 28.00M,
                Cost = 8.68M,
                PublishDate = new DateTime(2011, 10, 1),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                Authors = "Lee Child",
                BookStatus = BookStatusEnum.Active
            });

            // A Lawman's Christmas
            Books.Add(new Book
            {
                BookNumber = 789108,
                Title = "A Lawman's Christmas",
                Description = "The death of the town marshal leaves Blue River, Texas, without a lawman, and Dara Rose Nolan without a husband. Clay McKettrick steps in, and when he and Dara Rose agree to a marriage of convenience, the temporary lawman’s Christmas wish is to make her his permanent wife.",
                Price = 28.00M,
                Cost = 15.96M,
                PublishDate = new DateTime(2011, 10, 1),
                InventoryQuantity = 10,
                ReorderPoint = 5,
                Authors = "Linda Lael Miller",
                BookStatus = BookStatusEnum.Active
            });

            // Bonnie
            Books.Add(new Book
            {
                BookNumber = 789109,
                Title = "Bonnie",
                Description = "The forensic sculptor Eve Duncan learns more about her daughter’s disappearance and the girl’s father‘s possible involvement.",
                Price = 27.99M,
                Cost = 24.07M,
                PublishDate = new DateTime(2011, 10, 22),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Iris Johansen",
                BookStatus = BookStatusEnum.Active
            });

            // The Christmas Wedding
            Books.Add(new Book
            {
                BookNumber = 789110,
                Title = "The Christmas Wedding",
                Description = "A widow keeps the identity of the new man she is about to marry a secret as her children gather for Christmas.",
                Price = 25.99M,
                Cost = 23.65M,
                PublishDate = new DateTime(2011, 10, 22),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                Authors = "James Patterson and Richard DiLallo",
                BookStatus = BookStatusEnum.Active
            });

            // Zero Day
            Books.Add(new Book
            {
                BookNumber = 789111,
                Title = "Zero Day",
                Description = "A military investigator uncovers a conspiracy.",
                Price = 27.99M,
                Cost = 18.47M,
                PublishDate = new DateTime(2011, 11, 5),
                InventoryQuantity = 12,
                ReorderPoint = 9,
                Authors = "David Baldacci",
                BookStatus = BookStatusEnum.Active
            });

            // The Scottish Prisoner
            Books.Add(new Book
            {
                BookNumber = 789112,
                Title = "The Scottish Prisoner",
                Description = "Jamie Fraser, a paroled Jacobite prisoner, and Lord John Grey collaborate uneasily on a mission to Ireland.",
                Price = 28.00M,
                Cost = 24.92M,
                PublishDate = new DateTime(2011, 12, 3),
                InventoryQuantity = 6,
                ReorderPoint = 2,
                Authors = "Diana Gabaldon",
                BookStatus = BookStatusEnum.Active
            });

            // 77 Shadow Street
            Books.Add(new Book
            {
                BookNumber = 789113,
                Title = "77 Shadow Street",
                Description = "A 19th-century tycoon’s mansion has been turned into luxury apartments, but it remains in the grip of evil forces.",
                Price = 28.00M,
                Cost = 14.56M,
                PublishDate = new DateTime(2011, 12, 31),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                Authors = "Dean Koontz",
                BookStatus = BookStatusEnum.Active
            });

            // Love In A Nutshell
            Books.Add(new Book
            {
                BookNumber = 789114,
                Title = "Love In A Nutshell",
                Description = "A former magazine editor attempts to turn her parents’ summer house into a bed-and-breakfast.",
                Price = 27.99M,
                Cost = 22.95M,
                PublishDate = new DateTime(2012, 1, 7),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                Authors = "Janet Evanovich and Dorien Kelly",
                BookStatus = BookStatusEnum.Active
            });

            // The Hunter
            Books.Add(new Book
            {
                BookNumber = 789115,
                Title = "The Hunter",
                Description = "A San Francisco private investigator discovers chilling facts about his birth family.",
                Price = 26.95M,
                Cost = 5.66M,
                PublishDate = new DateTime(2012, 1, 7),
                InventoryQuantity = 7,
                ReorderPoint = 6,
                Authors = "John Lescroart",
                BookStatus = BookStatusEnum.Active
            });

            // Copper Beach
            Books.Add(new Book
            {
                BookNumber = 789116,
                Title = "Copper Beach",
                Description = "Amy Radwell, whose psychic talent enables her to understand the paranormal secrets in rare books, becomes the target of a blackmailer. The first book in a new series about rare books and psychic codes.",
                Price = 25.95M,
                Cost = 16.09M,
                PublishDate = new DateTime(2012, 1, 14),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                Authors = "Jayne Ann Krentz",
                BookStatus = BookStatusEnum.Active
            });

            // Left For Dead
            Books.Add(new Book
            {
                BookNumber = 789117,
                Title = "Left For Dead",
                Description = "Ali Reynolds seeks justice for an old friend and an unidentified woman, both victims of brutal attacks.",
                Price = 25.99M,
                Cost = 20.01M,
                PublishDate = new DateTime(2012, 2, 11),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                Authors = "J A Jance",
                BookStatus = BookStatusEnum.Active
            });

            // Robert Ludlum’S The Janson Command
            Books.Add(new Book
            {
                BookNumber = 789118,
                Title = "Robert Ludlum’S The Janson Command",
                Description = "A former American operative builds a network to help him resolve crises without torture or civilian casualties.",
                Price = 27.99M,
                Cost = 7.28M,
                PublishDate = new DateTime(2012, 2, 18),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Paul Garrison",
                BookStatus = BookStatusEnum.Active
            });

            // Victims
            Books.Add(new Book
            {
                BookNumber = 789119,
                Title = "Victims",
                Description = "The Los Angeles psychologist-detective Alex Delaware and the detective Milo Sturgis track down a homicidal maniac.",
                Price = 28.00M,
                Cost = 16.52M,
                PublishDate = new DateTime(2012, 3, 3),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                Authors = "Jonathan Kellerman",
                BookStatus = BookStatusEnum.Active
            });

            // Another Piece Of My Heart
            Books.Add(new Book
            {
                BookNumber = 789120,
                Title = "Another Piece Of My Heart",
                Description = "A woman in her late 30s marries the man of her dreams and reaches out to his daughters by his previous marriage, but one of them is determined to destroy her.",
                Price = 25.99M,
                Cost = 20.27M,
                PublishDate = new DateTime(2012, 3, 17),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                Authors = "Jane Green",
                BookStatus = BookStatusEnum.Active
            });

            // Unnatural Acts
            Books.Add(new Book
            {
                BookNumber = 789121,
                Title = "Unnatural Acts",
                Description = "The New York lawyer Stone Barrington becomes involved in the family problems of a billionaire hedge fund manager.",
                Price = 26.95M,
                Cost = 16.71M,
                PublishDate = new DateTime(2012, 4, 21),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                Authors = "Stuart Woods",
                BookStatus = BookStatusEnum.Active
            });

            // Mission To Paris
            Books.Add(new Book
            {
                BookNumber = 789122,
                Title = "Mission To Paris",
                Description = "In Paris in 1938, an actor stumbles into the clutches of Nazi conspirators who want to exploit his celebrity.",
                Price = 27.00M,
                Cost = 19.17M,
                PublishDate = new DateTime(2012, 6, 16),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "Alan Furst",
                BookStatus = BookStatusEnum.Active
            });

            // Shadow Of Night
            Books.Add(new Book
            {
                BookNumber = 789123,
                Title = "Shadow Of Night",
                Description = "An Oxford scholar/witch and a vampire geneticist pursue history, secrets and each other in Elizabethan London.",
                Price = 28.95M,
                Cost = 21.13M,
                PublishDate = new DateTime(2012, 7, 14),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "Deborah Harkness",
                BookStatus = BookStatusEnum.Active
            });

            // Where We Belong
            Books.Add(new Book
            {
                BookNumber = 789124,
                Title = "Where We Belong",
                Description = "A woman’s successful life is disrupted by the appearance of an 18-year-old girl with a link to her past.",
                Price = 27.99M,
                Cost = 8.12M,
                PublishDate = new DateTime(2012, 7, 28),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                Authors = "Emily Giffin",
                BookStatus = BookStatusEnum.Active
            });

            // Judgment Call
            Books.Add(new Book
            {
                BookNumber = 789125,
                Title = "Judgment Call",
                Description = "Joanna Brady, an Arizona sheriff, must function as both a law officer and a mother when her daughter’s high school principal is murdered.",
                Price = 25.99M,
                Cost = 8.84M,
                PublishDate = new DateTime(2012, 7, 28),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                Authors = "J A Jance",
                BookStatus = BookStatusEnum.Active
            });

            // Broken Harbor
            Books.Add(new Book
            {
                BookNumber = 789126,
                Title = "Broken Harbor",
                Description = "In French’s fourth Dublin murder squad novel, a detective’s investigation of a crime in a seaside town evokes memories of his disturbing childhood there.",
                Price = 27.95M,
                Cost = 24.04M,
                PublishDate = new DateTime(2012, 7, 28),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Tana French",
                BookStatus = BookStatusEnum.Active
            });

            // Odd Apocalypse
            Books.Add(new Book
            {
                BookNumber = 789127,
                Title = "Odd Apocalypse",
                Description = "Odd Thomas, who can communicate with the dead, explores the mysteries of an old estate now owned by a billionaire.",
                Price = 28.00M,
                Cost = 14.28M,
                PublishDate = new DateTime(2012, 8, 4),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                Authors = "Dean Koontz",
                BookStatus = BookStatusEnum.Active
            });

            // Haven
            Books.Add(new Book
            {
                BookNumber = 789128,
                Title = "Haven",
                Description = "The F.B.I. agent Noah Bishop and his special crimes unit help two sisters probe the secrets of a North Carolina town.",
                Price = 26.95M,
                Cost = 14.82M,
                PublishDate = new DateTime(2012, 8, 4),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                Authors = "Kay Hooper",
                BookStatus = BookStatusEnum.Active
            });

            // The Inn At Rose Harbor
            Books.Add(new Book
            {
                BookNumber = 789129,
                Title = "The Inn At Rose Harbor",
                Description = "A young widow buys a bed-and-breakfast.",
                Price = 26.00M,
                Cost = 24.18M,
                PublishDate = new DateTime(2012, 8, 18),
                InventoryQuantity = 8,
                ReorderPoint = 5,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // Wards Of Faerie
            Books.Add(new Book
            {
                BookNumber = 789130,
                Title = "Wards Of Faerie",
                Description = "In the first book of a new fantasy series, the Dark Legacy of Shannara, Druids, Elves and humans unite to try to capture the Elfstones and rescue the troubled Four Lands.",
                Price = 28.00M,
                Cost = 4.20M,
                PublishDate = new DateTime(2012, 8, 25),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                Authors = "Terry Brooks",
                BookStatus = BookStatusEnum.Active
            });

            // A Sunless Sea
            Books.Add(new Book
            {
                BookNumber = 789131,
                Title = "A Sunless Sea",
                Description = "A murder case for William Monk of the Thames River Police culminates in a government minister’s corruption trial.",
                Price = 26.00M,
                Cost = 22.62M,
                PublishDate = new DateTime(2012, 9, 1),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                Authors = "Anne Perry",
                BookStatus = BookStatusEnum.Active
            });

            // Last To Die
            Books.Add(new Book
            {
                BookNumber = 789132,
                Title = "Last To Die",
                Description = "The detective Jane Rizzoli and the medical examiner Maura Isles protect a boy whose family and foster family have all been murdered.",
                Price = 27.00M,
                Cost = 9.99M,
                PublishDate = new DateTime(2012, 9, 1),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                Authors = "Tess Gerritsen",
                BookStatus = BookStatusEnum.Active
            });

            // Telegraph Avenue
            Books.Add(new Book
            {
                BookNumber = 789133,
                Title = "Telegraph Avenue",
                Description = "Fathers and sons in Berkeley and Oakland, Calif.",
                Price = 27.99M,
                Cost = 11.20M,
                PublishDate = new DateTime(2012, 9, 15),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                Authors = "Michael Chabon",
                BookStatus = BookStatusEnum.Active
            });

            // Midst Toil And Tribulation
            Books.Add(new Book
            {
                BookNumber = 789134,
                Title = "Midst Toil And Tribulation",
                Description = "In Book 6 of the Safehold science fiction series, the republic of Siddamark descends into chaos.",
                Price = 27.99M,
                Cost = 10.08M,
                PublishDate = new DateTime(2012, 9, 22),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                Authors = "David Weber",
                BookStatus = BookStatusEnum.Active
            });

            // Sleep No More
            Books.Add(new Book
            {
                BookNumber = 789135,
                Title = "Sleep No More",
                Description = "The forensic sculptor Eve Duncan investigates when her mother’s friend disappears from a mental hospital.",
                Price = 27.99M,
                Cost = 4.48M,
                PublishDate = new DateTime(2012, 10, 20),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                Authors = "Iris Johansen",
                BookStatus = BookStatusEnum.Active
            });

            // Sweet Tooth
            Books.Add(new Book
            {
                BookNumber = 789136,
                Title = "Sweet Tooth",
                Description = "A British woman working for MI5 in 1972 falls in love with a writer the service is clandestinely supporting.",
                Price = 26.95M,
                Cost = 16.17M,
                PublishDate = new DateTime(2012, 11, 17),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                Authors = "Ian McEwan",
                BookStatus = BookStatusEnum.Active
            });

            // Merry Christmas, Alex Cross
            Books.Add(new Book
            {
                BookNumber = 789137,
                Title = "Merry Christmas, Alex Cross",
                Description = "Detective Alex Cross confronts both a hostage situation and a terrorist act at Christmas.",
                Price = 28.99M,
                Cost = 8.99M,
                PublishDate = new DateTime(2012, 11, 17),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                Authors = "James Patterson",
                BookStatus = BookStatusEnum.Active
            });

            // Threat Vector
            Books.Add(new Book
            {
                BookNumber = 789138,
                Title = "Threat Vector",
                Description = "As China threatens to invade Taiwan, the covert intelligence expert Jack Ryan Jr. aids his father’s administration  — but his agency is no longer secret.",
                Price = 28.95M,
                Cost = 10.71M,
                PublishDate = new DateTime(2012, 12, 8),
                InventoryQuantity = 12,
                ReorderPoint = 9,
                Authors = "Tom Clancy with Mark Greaney",
                BookStatus = BookStatusEnum.Active
            });

            // Two Graves
            Books.Add(new Book
            {
                BookNumber = 789139,
                Title = "Two Graves",
                Description = "Special Agent Aloysius Pendergast pursues a serial killer as well as his abducted wife.",
                Price = 26.99M,
                Cost = 13.23M,
                PublishDate = new DateTime(2012, 12, 15),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Douglas Preston and Lincoln Child",
                BookStatus = BookStatusEnum.Active
            });

            // The Husband List
            Books.Add(new Book
            {
                BookNumber = 789140,
                Title = "The Husband List",
                Description = "In New York City in 1894, a wealthy young woman yearns for adventure and the love of an Irish-American with new money, rather than the titled Britons to whom her mother hopes to marry her off.",
                Price = 27.99M,
                Cost = 23.51M,
                PublishDate = new DateTime(2013, 1, 12),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                Authors = "Janet Evanovich and Dorien Kelly",
                BookStatus = BookStatusEnum.Active
            });

            // Collateral Damage
            Books.Add(new Book
            {
                BookNumber = 789141,
                Title = "Collateral Damage",
                Description = "Back in New York, the lawyer Stone Barrington joins his former partner Holly Barker in pursuing a dangerous case.",
                Price = 26.95M,
                Cost = 19.40M,
                PublishDate = new DateTime(2013, 1, 12),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "Stuart Woods",
                BookStatus = BookStatusEnum.Active
            });

            // Kinsey And Me
            Books.Add(new Book
            {
                BookNumber = 789142,
                Title = "Kinsey And Me",
                Description = "Stories about Grafton’s character Kinsey Millhone as well as explorations of Grafton’s own past.",
                Price = 27.95M,
                Cost = 25.43M,
                PublishDate = new DateTime(2013, 1, 12),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                Authors = "Sue Grafton",
                BookStatus = BookStatusEnum.Active
            });

            // The Third Bullet
            Books.Add(new Book
            {
                BookNumber = 789143,
                Title = "The Third Bullet",
                Description = "The veteran sniper Bob Lee Swagger investigates the assassination of John F. Kennedy. ",
                Price = 26.99M,
                Cost = 15.11M,
                PublishDate = new DateTime(2013, 1, 19),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                Authors = "Stephen Hunter",
                BookStatus = BookStatusEnum.Active
            });

            // The Night Ranger
            Books.Add(new Book
            {
                BookNumber = 789144,
                Title = "The Night Ranger",
                Description = "The former C.I.A. operative John Wells pitches in when four young Americans who work at a refugee camp in Somalia are hijacked by bandits. ",
                Price = 27.95M,
                Cost = 6.71M,
                PublishDate = new DateTime(2013, 2, 16),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                Authors = "Alex Berenson",
                BookStatus = BookStatusEnum.Active
            });

            // Sweet Tea Revenge
            Books.Add(new Book
            {
                BookNumber = 789145,
                Title = "Sweet Tea Revenge",
                Description = "Theodosia Browning, owner of Indigo Tea Shop, is a bridesmaid in her friend's wedding. But the bridegroom is found dead on the big day.",
                Price = 29.00M,
                Cost = 13.92M,
                PublishDate = new DateTime(2013, 3, 9),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                Authors = "Laura Childs",
                BookStatus = BookStatusEnum.Active
            });

            // The Last Threshold
            Books.Add(new Book
            {
                BookNumber = 789146,
                Title = "The Last Threshold",
                Description = "Book 4 of the fantasy Neverwinter Saga.",
                Price = 27.95M,
                Cost = 2.80M,
                PublishDate = new DateTime(2013, 3, 9),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "R A Salvatore",
                BookStatus = BookStatusEnum.Active
            });

            // The Supremes At Earl's All-You-Can-Eat
            Books.Add(new Book
            {
                BookNumber = 789147,
                Title = "The Supremes At Earl's All-You-Can-Eat",
                Description = "Four decades in the friendship of three middle-class black women in a small  southern Indiana town.",
                Price = 24.95M,
                Cost = 7.49M,
                PublishDate = new DateTime(2013, 3, 16),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                Authors = "Edward Kelsey Moore",
                BookStatus = BookStatusEnum.Active
            });

            // Lover At Last
            Books.Add(new Book
            {
                BookNumber = 789148,
                Title = "Lover At Last",
                Description = "Book 11 of the Black Dagger Brotherhood series.",
                Price = 27.95M,
                Cost = 12.86M,
                PublishDate = new DateTime(2013, 3, 30),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                Authors = "J R Ward",
                BookStatus = BookStatusEnum.Active
            });

            // Leaving Everything Most Loved
            Books.Add(new Book
            {
                BookNumber = 789149,
                Title = "Leaving Everything Most Loved",
                Description = "In 1933, the private investigator Maisie Dobbs helps an Indian man whose sister’s murder has been ignored by Scotland Yard.",
                Price = 26.99M,
                Cost = 2.97M,
                PublishDate = new DateTime(2013, 3, 30),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Jacqueline Winspear",
                BookStatus = BookStatusEnum.Active
            });

            // All That Is
            Books.Add(new Book
            {
                BookNumber = 789150,
                Title = "All That Is",
                Description = "A veteran makes a career in publishing in postwar New York and struggles to achieve romantic success.",
                Price = 26.95M,
                Cost = 14.01M,
                PublishDate = new DateTime(2013, 4, 6),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "James Salter",
                BookStatus = BookStatusEnum.Active
            });

            // Unintended Consequences
            Books.Add(new Book
            {
                BookNumber = 789151,
                Title = "Unintended Consequences",
                Description = "The New York lawyer Stone Barrington discovers a shadowy network beneath the world of European wealth.",
                Price = 26.95M,
                Cost = 11.32M,
                PublishDate = new DateTime(2013, 4, 13),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                Authors = "Stuart Woods",
                BookStatus = BookStatusEnum.Active
            });

            // Nos4A2
            Books.Add(new Book
            {
                BookNumber = 789152,
                Title = "Nos4A2",
                Description = "In a creepy battle between real and imaginary worlds, a brave biker chick is pitted against a ghoulish villain who lures children to a place where it is always Christmas.",
                Price = 34.00M,
                Cost = 28.56M,
                PublishDate = new DateTime(2013, 5, 4),
                InventoryQuantity = 14,
                ReorderPoint = 9,
                Authors = "Joe Hill",
                BookStatus = BookStatusEnum.Active
            });

            // Zero Hour
            Books.Add(new Book
            {
                BookNumber = 789153,
                Title = "Zero Hour",
                Description = "Kurt Austin, Joe Zavala and the rest of the Numa team search for a physicist's machine, buried in an ocean trench, that can cause deadly earthquakes in the 11th Numa Files novel.",
                Price = 28.95M,
                Cost = 25.19M,
                PublishDate = new DateTime(2013, 6, 1),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Clive Cussler and Graham Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The Son
            Books.Add(new Book
            {
                BookNumber = 789154,
                Title = "The Son",
                Description = "More than 150 years in a Texas family, from Comanche raids to the present, and its rise to money and power in the cattle and oil industries.",
                Price = 22.00M,
                Cost = 19.58M,
                PublishDate = new DateTime(2013, 6, 1),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                Authors = "Philipp Meyer",
                BookStatus = BookStatusEnum.Active
            });

            // Red Sparrow
            Books.Add(new Book
            {
                BookNumber = 789155,
                Title = "Red Sparrow",
                Description = "A Russian intelligence officer trained in the art of seduction becomes entangled with a young C.I.A. officer.",
                Price = 26.95M,
                Cost = 11.59M,
                PublishDate = new DateTime(2013, 6, 8),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Jason Matthews",
                BookStatus = BookStatusEnum.Active
            });

            // The Silver Star
            Books.Add(new Book
            {
                BookNumber = 789156,
                Title = "The Silver Star",
                Description = "When their irresponsible mother takes off, a 12-year-old California girl and her sister join the rest of their family in Virginia. ",
                Price = 23.95M,
                Cost = 8.38M,
                PublishDate = new DateTime(2013, 6, 15),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                Authors = "Jeannette Walls",
                BookStatus = BookStatusEnum.Active
            });

            // Sisterland
            Books.Add(new Book
            {
                BookNumber = 789157,
                Title = "Sisterland",
                Description = "Twins with psychic abilities share a devastating secret.",
                Price = 27.99M,
                Cost = 20.71M,
                PublishDate = new DateTime(2013, 6, 29),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                Authors = "Curtis Sittenfeld",
                BookStatus = BookStatusEnum.Active
            });

            // The English Girl
            Books.Add(new Book
            {
                BookNumber = 789158,
                Title = "The English Girl",
                Description = "Gabriel Allon, an art restorer and occasional spy for the Israeli secret service, steps in to help the British prime minister, whose lover has been kidnapped. ",
                Price = 17.95M,
                Cost = 2.33M,
                PublishDate = new DateTime(2013, 7, 20),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                Authors = "Daniel Silva",
                BookStatus = BookStatusEnum.Active
            });

            // Hunting Eve
            Books.Add(new Book
            {
                BookNumber = 789159,
                Title = "Hunting Eve",
                Description = "In the second book of a trilogy, the forensic sculptor Eve Duncan struggles to outwit a kidnapper in the Colorado wilderness.",
                Price = 35.99M,
                Cost = 28.07M,
                PublishDate = new DateTime(2013, 7, 20),
                InventoryQuantity = 5,
                ReorderPoint = 3,
                Authors = "Iris Johansen",
                BookStatus = BookStatusEnum.Active
            });

            // Light Of The World
            Books.Add(new Book
            {
                BookNumber = 789160,
                Title = "Light Of The World",
                Description = "A savage killer follows the detective Dave Robicheaux and his family to a Montana ranch. ",
                Price = 32.00M,
                Cost = 10.88M,
                PublishDate = new DateTime(2013, 7, 27),
                InventoryQuantity = 7,
                ReorderPoint = 5,
                Authors = "James Lee Burke",
                BookStatus = BookStatusEnum.Active
            });

            // The Kill List
            Books.Add(new Book
            {
                BookNumber = 789161,
                Title = "The Kill List",
                Description = "An Arabic-speaking Marine major known as the Tracker pursues a terrorist who radicalizes young Muslims living abroad.",
                Price = 23.95M,
                Cost = 10.78M,
                PublishDate = new DateTime(2013, 8, 24),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                Authors = "Frederick Forsyth",
                BookStatus = BookStatusEnum.Active
            });

            // Songs Of Willow Frost
            Books.Add(new Book
            {
                BookNumber = 789162,
                Title = "Songs Of Willow Frost",
                Description = "A 12-year-old Seattle orphan during the Depression becomes convinced that a movie star is really his vanished mother. ",
                Price = 18.00M,
                Cost = 6.30M,
                PublishDate = new DateTime(2013, 9, 14),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                Authors = "Jamie Ford",
                BookStatus = BookStatusEnum.Active
            });

            // W Is For Wasted
            Books.Add(new Book
            {
                BookNumber = 789163,
                Title = "W Is For Wasted",
                Description = "A homeless man inexplicably leaves $600,000 to Kinsey Millhone.",
                Price = 16.00M,
                Cost = 7.04M,
                PublishDate = new DateTime(2013, 9, 14),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                Authors = "Sue Grafton",
                BookStatus = BookStatusEnum.Active
            });

            // Deadly Heat
            Books.Add(new Book
            {
                BookNumber = 789164,
                Title = "Deadly Heat",
                Description = "The N.Y.P.D. homicide detective Nikki Heat and the journalist Jameson Rook search for the former C.I.A. station chief who ordered her mother’s execution.\nThe N.Y.P.D. homicide detective Nikki Heat and the journalist Jameson Rook search for the former C.I.A. station chief who ordered her mother’s execution.",
                Price = 16.00M,
                Cost = 3.36M,
                PublishDate = new DateTime(2013, 9, 21),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Richard Castle",
                BookStatus = BookStatusEnum.Active
            });

            // Deadline
            Books.Add(new Book
            {
                BookNumber = 789165,
                Title = "Deadline",
                Description = "A journalist who pursues a story about a former marine, the son of terrorists from 40 years ago,becomes a suspect in the death of his ex-wife.",
                Price = 16.00M,
                Cost = 4.48M,
                PublishDate = new DateTime(2013, 9, 28),
                InventoryQuantity = 7,
                ReorderPoint = 6,
                Authors = "Sandra Brown",
                BookStatus = BookStatusEnum.Active
            });

            // Silencing Eve
            Books.Add(new Book
            {
                BookNumber = 789166,
                Title = "Silencing Eve",
                Description = "The final book of a trilogy about the forensic sculptor Eve Duncan. ",
                Price = 19.00M,
                Cost = 7.03M,
                PublishDate = new DateTime(2013, 10, 5),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                Authors = "Iris Johansen",
                BookStatus = BookStatusEnum.Active
            });

            // Starry Night
            Books.Add(new Book
            {
                BookNumber = 789167,
                Title = "Starry Night",
                Description = "At Christmastime, a big-city columnist sets out to interview a reclusive author in Alaska. ",
                Price = 24.95M,
                Cost = 17.96M,
                PublishDate = new DateTime(2013, 10, 12),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // Bridget Jones: Mad About The Boy
            Books.Add(new Book
            {
                BookNumber = 789168,
                Title = "Bridget Jones: Mad About The Boy",
                Description = "Bridget, now 51 and a mother and widow, is once again looking for love.",
                Price = 29.95M,
                Cost = 18.57M,
                PublishDate = new DateTime(2013, 10, 19),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                Authors = "Helen Fielding",
                BookStatus = BookStatusEnum.Active
            });

            // The Last Dark
            Books.Add(new Book
            {
                BookNumber = 789169,
                Title = "The Last Dark",
                Description = "The 10th and final installment of the sprawling fantasy series about Thomas Covenant the Unbeliever.",
                Price = 16.00M,
                Cost = 10.88M,
                PublishDate = new DateTime(2013, 10, 19),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                Authors = "Stephen R Donaldson",
                BookStatus = BookStatusEnum.Active
            });

            // Aimless Love
            Books.Add(new Book
            {
                BookNumber = 789170,
                Title = "Aimless Love",
                Description = "More than 50 new poems as well as selections from previous books from the two-term poet laureate of the Untied States.",
                Price = 30.99M,
                Cost = 25.41M,
                PublishDate = new DateTime(2013, 10, 26),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                Authors = "Billy Collins",
                BookStatus = BookStatusEnum.Active
            });

            // Tatiana
            Books.Add(new Book
            {
                BookNumber = 789171,
                Title = "Tatiana",
                Description = "A dead translator’s coded notebook may hold the key to the murders of a muckraking journalist and an oligarch in the former Soviet Union. Arkady Renko, a senior investigator in the Moscow prosecutor’s office, is on the case.",
                Price = 20.99M,
                Cost = 18.68M,
                PublishDate = new DateTime(2013, 11, 16),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                Authors = "Martin Cruz Smith",
                BookStatus = BookStatusEnum.Active
            });

            // Dust
            Books.Add(new Book
            {
                BookNumber = 789172,
                Title = "Dust",
                Description = "The murder of a computer engineer at M.I.T. leads the Massachusetts Chief Medical Examiner Kay Scarpetta in unexpected directions.",
                Price = 23.99M,
                Cost = 18.23M,
                PublishDate = new DateTime(2013, 11, 16),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Patricia Cornwell",
                BookStatus = BookStatusEnum.Active
            });

            // The Supreme Macaroni Company
            Books.Add(new Book
            {
                BookNumber = 789173,
                Title = "The Supreme Macaroni Company",
                Description = "Tensions arise when Valentine Roncalli, a Greenwich Village shoe designer, marries a handsome Italian, and the two must balance careers, countries and families. The final book in the Valentine trilogy. ",
                Price = 34.99M,
                Cost = 7.00M,
                PublishDate = new DateTime(2013, 11, 30),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                Authors = "Adriana Trigiani",
                BookStatus = BookStatusEnum.Active
            });

            // Innocence
            Books.Add(new Book
            {
                BookNumber = 789174,
                Title = "Innocence",
                Description = "A grotesque man living in exile beneath the city encounters a teenage girl hiding from dangerous enemies.",
                Price = 21.00M,
                Cost = 13.44M,
                PublishDate = new DateTime(2013, 12, 14),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                Authors = "Dean Koontz",
                BookStatus = BookStatusEnum.Active
            });

            // Hunting Shadows
            Books.Add(new Book
            {
                BookNumber = 789175,
                Title = "Hunting Shadows",
                Description = "In the aftermath of World War I, a Scotland Yard detective with a heavy burden of guilt, investigates two murders in Cambridgeshire that may be linked.",
                Price = 32.99M,
                Cost = 18.47M,
                PublishDate = new DateTime(2014, 1, 25),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                Authors = "Charles Todd",
                BookStatus = BookStatusEnum.Active
            });

            // Confessions Of A Wild Child
            Books.Add(new Book
            {
                BookNumber = 789176,
                Title = "Confessions Of A Wild Child",
                Description = "The early years of Collins’s recurring character Lucky Santangelo.",
                Price = 30.95M,
                Cost = 17.95M,
                PublishDate = new DateTime(2014, 2, 8),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                Authors = "Jackie Collins",
                BookStatus = BookStatusEnum.Active
            });

            // The Counterfeit Agent
            Books.Add(new Book
            {
                BookNumber = 789177,
                Title = "The Counterfeit Agent",
                Description = "John Wells is sent on a mission to find the truth about a mysterious Iranian package said to be bound for the United States.",
                Price = 16.99M,
                Cost = 9.68M,
                PublishDate = new DateTime(2014, 2, 15),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                Authors = "Alex Berenson",
                BookStatus = BookStatusEnum.Active
            });

            // Like A Mighty Army
            Books.Add(new Book
            {
                BookNumber = 789178,
                Title = "Like A Mighty Army",
                Description = "In Book 7 of the Safehold science fiction series, the empire of Charis fights for self-determination. ",
                Price = 22.00M,
                Cost = 17.60M,
                PublishDate = new DateTime(2014, 2, 22),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                Authors = "David Weber",
                BookStatus = BookStatusEnum.Active
            });

            // Cavendon Hall
            Books.Add(new Book
            {
                BookNumber = 789179,
                Title = "Cavendon Hall",
                Description = "In Edwardian England, an aristocratic family and the family who serve them share an ancestral home. ",
                Price = 26.00M,
                Cost = 8.06M,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                Authors = "Barbara Taylor Bradford",
                BookStatus = BookStatusEnum.Active
            });

            // Frog Music
            Books.Add(new Book
            {
                BookNumber = 789180,
                Title = "Frog Music",
                Description = "A murder mystery set in San Francisco in 1876, when the city is in the grip of a smallpox epidemic and a heat wave.",
                Price = 16.95M,
                Cost = 4.92M,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 10,
                ReorderPoint = 5,
                Authors = "Emma Donoghue",
                BookStatus = BookStatusEnum.Active
            });

            // Destroyer Angel
            Books.Add(new Book
            {
                BookNumber = 789181,
                Title = "Destroyer Angel",
                Description = "The National Park Service Ranger Anna Pigeon must rescue friends who are kidnapped while camping in Minnesota.",
                Price = 32.00M,
                Cost = 3.52M,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 5,
                ReorderPoint = 3,
                Authors = "Nevada Barr",
                BookStatus = BookStatusEnum.Active
            });

            // Warriors
            Books.Add(new Book
            {
                BookNumber = 789182,
                Title = "Warriors",
                Description = "The counterspy Alex Hawke must rescue a kidnapped scientist. ",
                Price = 33.99M,
                Cost = 5.44M,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                Authors = "Ted Bell",
                BookStatus = BookStatusEnum.Active
            });

            // Live To See Tomorrow
            Books.Add(new Book
            {
                BookNumber = 789183,
                Title = "Live To See Tomorrow",
                Description = "The C.I.A. operative Catherine Ling must spearhead the rescue of an American journalist kidnapped in Tibet. ",
                Price = 34.00M,
                Cost = 6.46M,
                PublishDate = new DateTime(2014, 5, 3),
                InventoryQuantity = 9,
                ReorderPoint = 5,
                Authors = "Iris Johansen",
                BookStatus = BookStatusEnum.Active
            });

            // All The Light We Cannot See
            Books.Add(new Book
            {
                BookNumber = 789184,
                Title = "All The Light We Cannot See",
                Description = "The lives of a blind French girl and a gadget-obsessed German boy before and during World War II, when their paths eventually cross. ",
                Price = 23.95M,
                Cost = 10.30M,
                PublishDate = new DateTime(2014, 5, 10),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                Authors = "Anthony Doerr",
                BookStatus = BookStatusEnum.Active
            });

            // The Kraken Project
            Books.Add(new Book
            {
                BookNumber = 789185,
                Title = "The Kraken Project",
                Description = "The former C.I.A. agent Wyman Ford must stop Dorothy, a powerful artificial intelligence that has gone rogue.",
                Price = 35.00M,
                Cost = 28.00M,
                PublishDate = new DateTime(2014, 5, 17),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Douglas Preston",
                BookStatus = BookStatusEnum.Active
            });

            // The Vacationers
            Books.Add(new Book
            {
                BookNumber = 789186,
                Title = "The Vacationers",
                Description = "Well-heeled New Yorkers and their friends spend two weeks in Majorca, a time when rivalries and secrets come to light.",
                Price = 33.00M,
                Cost = 5.94M,
                PublishDate = new DateTime(2014, 5, 31),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Emma Straub",
                BookStatus = BookStatusEnum.Active
            });

            // The Hurricane Sisters
            Books.Add(new Book
            {
                BookNumber = 789187,
                Title = "The Hurricane Sisters",
                Description = "Three generations of women endure a stormy summer in South Carolina's Lowcountry.",
                Price = 16.00M,
                Cost = 9.60M,
                PublishDate = new DateTime(2014, 6, 7),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                Authors = "Dorothea Benton Frank",
                BookStatus = BookStatusEnum.Active
            });

            // The Matchmaker
            Books.Add(new Book
            {
                BookNumber = 789188,
                Title = "The Matchmaker",
                Description = "A Nantucket resident’s life is shaken by a diagnosis and the return to the island of her high school sweetheart. ",
                Price = 25.00M,
                Cost = 11.00M,
                PublishDate = new DateTime(2014, 6, 14),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Elin Hilderbrand",
                BookStatus = BookStatusEnum.Active
            });

            // Terminal City
            Books.Add(new Book
            {
                BookNumber = 789189,
                Title = "Terminal City",
                Description = "Alexandra Cooper, a Manhattan assistant district attorney, hunts for a killer in Grand Central’s underground tunnels.",
                Price = 32.95M,
                Cost = 16.48M,
                PublishDate = new DateTime(2014, 6, 21),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                Authors = "Linda Fairstein",
                BookStatus = BookStatusEnum.Active
            });

            // Landline
            Books.Add(new Book
            {
                BookNumber = 789190,
                Title = "Landline",
                Description = "A woman in a troubled marriage finds a way to communicate with her husband in the past. ",
                Price = 29.00M,
                Cost = 5.80M,
                PublishDate = new DateTime(2014, 7, 12),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Rainbow Rowell",
                BookStatus = BookStatusEnum.Active
            });

            // The Book Of Life
            Books.Add(new Book
            {
                BookNumber = 789191,
                Title = "The Book Of Life",
                Description = "In the conclusion to the All Souls trilogy, the Oxford scholar/witch Diana Bishop and the vampire geneticist Matthew Clairmont return from Elizabethan London to the present.",
                Price = 27.95M,
                Cost = 8.66M,
                PublishDate = new DateTime(2014, 7, 19),
                InventoryQuantity = 9,
                ReorderPoint = 9,
                Authors = "Deborah Harkness",
                BookStatus = BookStatusEnum.Active
            });

            // Magic Breaks
            Books.Add(new Book
            {
                BookNumber = 789192,
                Title = "Magic Breaks",
                Description = "In the seventh Kate Daniels novel, Kate deals with paranormal politics in Atlanta as she prepares the Pack for an attack.",
                Price = 32.00M,
                Cost = 16.96M,
                PublishDate = new DateTime(2014, 8, 2),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "Ilona Andrews",
                BookStatus = BookStatusEnum.Active
            });

            // Big Little Lies
            Books.Add(new Book
            {
                BookNumber = 789193,
                Title = "Big Little Lies",
                Description = "Who will end up dead, and how, when three mothers with children in the same school become friends?",
                Price = 17.00M,
                Cost = 5.10M,
                PublishDate = new DateTime(2014, 8, 2),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                Authors = "Liane Moriarty",
                BookStatus = BookStatusEnum.Active
            });

            // Dark Skye
            Books.Add(new Book
            {
                BookNumber = 789194,
                Title = "Dark Skye",
                Description = "Will a scarred warrior and the beautiful sorceress with the power to heal him overcome the challenges of their warring families and the chaotic battles around them? Book 15 in the Immortals After Dark series.",
                Price = 20.00M,
                Cost = 4.00M,
                PublishDate = new DateTime(2014, 8, 9),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Kresley Cole",
                BookStatus = BookStatusEnum.Active
            });

            // The Magician's Land
            Books.Add(new Book
            {
                BookNumber = 789195,
                Title = "The Magician's Land",
                Description = "Quentin, an exiled magician, tries a risky heist in the final installment of a trilogy.",
                Price = 28.95M,
                Cost = 5.50M,
                PublishDate = new DateTime(2014, 8, 9),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Lev Grossman",
                BookStatus = BookStatusEnum.Active
            });

            // Mean Streak
            Books.Add(new Book
            {
                BookNumber = 789196,
                Title = "Mean Streak",
                Description = "A North Carolina pediatrician is held captive by a mysterious man who forces her to question her life. ",
                Price = 29.95M,
                Cost = 26.66M,
                PublishDate = new DateTime(2014, 8, 23),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "Sandra Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The King's Curse
            Books.Add(new Book
            {
                BookNumber = 789197,
                Title = "The King's Curse",
                Description = "As chief lady-in-waiting to Katherine of Aragon, Margaret Pole is torn between the queen and her husband, Henry VIII.",
                Price = 18.99M,
                Cost = 3.99M,
                PublishDate = new DateTime(2014, 9, 13),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Philippa Gregory",
                BookStatus = BookStatusEnum.Active
            });

            // Bones Never Lie
            Books.Add(new Book
            {
                BookNumber = 789198,
                Title = "Bones Never Lie",
                Description = "A child murderer who eluded capture years ago has resurfaced, giving the forensic anthropologist Temperance Brennan another chance to stop her.",
                Price = 14.95M,
                Cost = 9.42M,
                PublishDate = new DateTime(2014, 9, 27),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                Authors = "Kathy Reichs",
                BookStatus = BookStatusEnum.Active
            });

            // Nora Webster
            Books.Add(new Book
            {
                BookNumber = 789199,
                Title = "Nora Webster",
                Description = "In the 1970s, an Irish widow struggles to find her identity.",
                Price = 30.99M,
                Cost = 4.65M,
                PublishDate = new DateTime(2014, 10, 11),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                Authors = "Colm Toibin",
                BookStatus = BookStatusEnum.Active
            });

            // Winter Street
            Books.Add(new Book
            {
                BookNumber = 789200,
                Title = "Winter Street",
                Description = "Complications ensue when the owner of Nantucket’s Winter Street Inn gathers his four children and their families for Christmas.",
                Price = 20.95M,
                Cost = 2.30M,
                PublishDate = new DateTime(2014, 10, 18),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Elin Hilderbrand",
                BookStatus = BookStatusEnum.Active
            });

            // The Narrow Road To The Deep North
            Books.Add(new Book
            {
                BookNumber = 789201,
                Title = "The Narrow Road To The Deep North",
                Description = "The hero of the Man Booker Prize-winning novel about love, good and evil is a P.O.W. working on the Thai-Burma Death Railway during World War II.",
                Price = 34.00M,
                Cost = 20.74M,
                PublishDate = new DateTime(2014, 10, 18),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Richard Flanagan",
                BookStatus = BookStatusEnum.Active
            });

            // The Handsome Man's De Luxe Café
            Books.Add(new Book
            {
                BookNumber = 789202,
                Title = "The Handsome Man's De Luxe Café",
                Description = "The 15th book in the No. 1 Ladies’ Detective Agency series.",
                Price = 25.95M,
                Cost = 17.91M,
                PublishDate = new DateTime(2014, 11, 1),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                Authors = "Alexander McCall Smith",
                BookStatus = BookStatusEnum.Active
            });

            // The Burning Room
            Books.Add(new Book
            {
                BookNumber = 789203,
                Title = "The Burning Room",
                Description = "The Los Angeles detective Harry Bosch and his new partner investigate two long-unsolved cases.",
                Price = 36.99M,
                Cost = 17.39M,
                PublishDate = new DateTime(2014, 11, 8),
                InventoryQuantity = 9,
                ReorderPoint = 7,
                Authors = "Michael Connelly",
                BookStatus = BookStatusEnum.Active
            });

            // The Job
            Books.Add(new Book
            {
                BookNumber = 789204,
                Title = "The Job",
                Description = "The F.B.I. special agent Kate O’Hare works with Nicolas Fox, a handsome con man, to pursue a drug kingpin.",
                Price = 28.95M,
                Cost = 20.27M,
                PublishDate = new DateTime(2014, 11, 22),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Janet Evanovich and Lee Goldberg",
                BookStatus = BookStatusEnum.Active
            });

            // The Cinderella Murder
            Books.Add(new Book
            {
                BookNumber = 789205,
                Title = "The Cinderella Murder",
                Description = "A  TV producer plans a show about a cold case — the murder of a U.C.L.A. student who was found with one shoe missing.",
                Price = 25.95M,
                Cost = 5.97M,
                PublishDate = new DateTime(2014, 11, 22),
                InventoryQuantity = 4,
                ReorderPoint = 1,
                Authors = "Mary Higgins Clark and Alafair Burke",
                BookStatus = BookStatusEnum.Active
            });

            // The Mistletoe Promise
            Books.Add(new Book
            {
                BookNumber = 789206,
                Title = "The Mistletoe Promise",
                Description = "A divorced woman enters into a contract with a strange man to pretend to be a couple until Christmas.",
                Price = 23.99M,
                Cost = 12.23M,
                PublishDate = new DateTime(2014, 11, 22),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                Authors = "Richard Paul Evans",
                BookStatus = BookStatusEnum.Active
            });

            // Hope To Die
            Books.Add(new Book
            {
                BookNumber = 789207,
                Title = "Hope To Die",
                Description = "Detective Alex Cross’s family is kidnapped by a madman who wants to turn Cross into a perfect killer.",
                Price = 31.95M,
                Cost = 3.51M,
                PublishDate = new DateTime(2014, 11, 29),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                Authors = "James Patterson",
                BookStatus = BookStatusEnum.Active
            });

            // Trust No One
            Books.Add(new Book
            {
                BookNumber = 789208,
                Title = "Trust No One",
                Description = "A woman who is being stalked is aided by an unlikely ally.",
                Price = 17.95M,
                Cost = 12.39M,
                PublishDate = new DateTime(2015, 1, 10),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                Authors = "Jayne Ann Krentz",
                BookStatus = BookStatusEnum.Active
            });

            // Private Vegas
            Books.Add(new Book
            {
                BookNumber = 789209,
                Title = "Private Vegas",
                Description = "Jack Morgan, the head of an investigative firm, uncovers a murder ring in Las Vegas.",
                Price = 32.00M,
                Cost = 25.92M,
                PublishDate = new DateTime(2015, 1, 31),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                Authors = "James Patterson and Maxine Paetro",
                BookStatus = BookStatusEnum.Active
            });

            // Trigger Warning
            Books.Add(new Book
            {
                BookNumber = 789210,
                Title = "Trigger Warning",
                Description = "Stories and poems about the power of imagination.",
                Price = 17.95M,
                Cost = 10.41M,
                PublishDate = new DateTime(2015, 2, 7),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                Authors = "Neil Gaiman",
                BookStatus = BookStatusEnum.Active
            });

            // Twelve Days
            Books.Add(new Book
            {
                BookNumber = 789211,
                Title = "Twelve Days",
                Description = "The former C.I.A. operative John Wells discovers a plot to trick the president into invading Iran.",
                Price = 25.00M,
                Cost = 18.50M,
                PublishDate = new DateTime(2015, 2, 14),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                Authors = "Alex Berenson",
                BookStatus = BookStatusEnum.Active
            });

            // A Spool Of Blue Thread
            Books.Add(new Book
            {
                BookNumber = 789212,
                Title = "A Spool Of Blue Thread",
                Description = "Four generations of a family are drawn to a house in the Baltimore suburbs.",
                Price = 15.95M,
                Cost = 1.75M,
                PublishDate = new DateTime(2015, 2, 14),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                Authors = "Anne Tyler",
                BookStatus = BookStatusEnum.Active
            });

            // Holy Cow
            Books.Add(new Book
            {
                BookNumber = 789213,
                Title = "Holy Cow",
                Description = "A light-hearted fable by the actor.",
                Price = 19.99M,
                Cost = 11.79M,
                PublishDate = new DateTime(2015, 2, 14),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                Authors = "David Duchovny",
                BookStatus = BookStatusEnum.Active
            });

            // Prodigal Son
            Books.Add(new Book
            {
                BookNumber = 789214,
                Title = "Prodigal Son",
                Description = "Twins, one good and one bad, reunite after 20 years when one of them returns to their hometown. But it is no longer clear who the good and who the bad one is.",
                Price = 18.95M,
                Cost = 9.10M,
                PublishDate = new DateTime(2015, 2, 28),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                Authors = "Danielle Steel",
                BookStatus = BookStatusEnum.Active
            });

            // Last One Home
            Books.Add(new Book
            {
                BookNumber = 789215,
                Title = "Last One Home",
                Description = "Three estranged sisters work to resolve their differences",
                Price = 20.00M,
                Cost = 15.60M,
                PublishDate = new DateTime(2015, 3, 14),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // The Lady From Zagreb
            Books.Add(new Book
            {
                BookNumber = 789216,
                Title = "The Lady From Zagreb",
                Description = "The former Berlin homicide detective Bernie Gunther is sent to Croatia by Joseph Goebbels to persuade a film star to appear in a movie.",
                Price = 20.95M,
                Cost = 19.27M,
                PublishDate = new DateTime(2015, 4, 11),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Philip Kerr",
                BookStatus = BookStatusEnum.Active
            });

            // 14Th Deadly Sin
            Books.Add(new Book
            {
                BookNumber = 789217,
                Title = "14Th Deadly Sin",
                Description = "A video of a shocking crime surfaces, casting suspicion on a San Francisco detective's colleagues.",
                Price = 24.99M,
                Cost = 6.25M,
                PublishDate = new DateTime(2015, 5, 9),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "James Patterson and Maxine Paetro",
                BookStatus = BookStatusEnum.Active
            });

            // The Fateful Lightning
            Books.Add(new Book
            {
                BookNumber = 789218,
                Title = "The Fateful Lightning",
                Description = "The fourth and final volume in a series of Civil War novels describes the war's last months through multiple perspectives.",
                Price = 28.95M,
                Cost = 5.50M,
                PublishDate = new DateTime(2015, 6, 6),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Jeff Shaara",
                BookStatus = BookStatusEnum.Active
            });

            // In The Unlikely Event
            Books.Add(new Book
            {
                BookNumber = 789219,
                Title = "In The Unlikely Event",
                Description = "Secrets are revealed and love stories play out against the backdrop of a series of panic-inducing plane crashes in 1950s New Jersey.",
                Price = 18.95M,
                Cost = 16.87M,
                PublishDate = new DateTime(2015, 6, 6),
                InventoryQuantity = 12,
                ReorderPoint = 9,
                Authors = "Judy Blume",
                BookStatus = BookStatusEnum.Active
            });

            // The Little Paris Bookshop
            Books.Add(new Book
            {
                BookNumber = 789220,
                Title = "The Little Paris Bookshop",
                Description = "A bookseller with a knack for finding just the right book for making others feel better embarks on a journey in pursuit of his own happiness.",
                Price = 34.00M,
                Cost = 5.78M,
                PublishDate = new DateTime(2015, 7, 4),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                Authors = "Nina George",
                BookStatus = BookStatusEnum.Active
            });

            // Friction
            Books.Add(new Book
            {
                BookNumber = 789221,
                Title = "Friction",
                Description = "A Texas Ranger fights for custody of his daughter amid complications stemming from his attraction to the judge.",
                Price = 18.99M,
                Cost = 2.85M,
                PublishDate = new DateTime(2015, 8, 22),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                Authors = "Sandra Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The Solomon Curse
            Books.Add(new Book
            {
                BookNumber = 789222,
                Title = "The Solomon Curse",
                Description = "The wealthy couple Sam and Remi Fargo investigate a dangerous legend in the Solomon Islands.",
                Price = 26.95M,
                Cost = 18.06M,
                PublishDate = new DateTime(2015, 9, 5),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                Authors = "Clive Cussler and Russell Blake",
                BookStatus = BookStatusEnum.Active
            });

            // One Year After
            Books.Add(new Book
            {
                BookNumber = 789223,
                Title = "One Year After",
                Description = "A New Regime imposes tyranny in the aftermath of a nuclear attack.",
                Price = 23.95M,
                Cost = 3.59M,
                PublishDate = new DateTime(2015, 9, 19),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "William R Forstchen",
                BookStatus = BookStatusEnum.Active
            });

            // The Murder House
            Books.Add(new Book
            {
                BookNumber = 789224,
                Title = "The Murder House",
                Description = "When bodies are found at a Hamptons estate where a series of grisly murders once occurred, a local detective and former New York City cop investigates.",
                Price = 23.95M,
                Cost = 17.72M,
                PublishDate = new DateTime(2015, 10, 3),
                InventoryQuantity = 6,
                ReorderPoint = 6,
                Authors = "James Patterson and David Ellis",
                BookStatus = BookStatusEnum.Active
            });

            // All The Stars In The Heavens
            Books.Add(new Book
            {
                BookNumber = 789225,
                Title = "All The Stars In The Heavens",
                Description = "A fictional treatment of the life of the actress Loretta Young focuses on her rumored affair with the married Clark Gable and her subsequent pregnancy.",
                Price = 26.95M,
                Cost = 19.94M,
                PublishDate = new DateTime(2015, 10, 17),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "Adriana Trigiani",
                BookStatus = BookStatusEnum.Active
            });

            // The Lake House
            Books.Add(new Book
            {
                BookNumber = 789226,
                Title = "The Lake House",
                Description = "A London detective investigating a missing-persons case becomes curious about an unsolved 1933 kidnapping in Cornwall.",
                Price = 16.95M,
                Cost = 10.17M,
                PublishDate = new DateTime(2015, 10, 24),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                Authors = "Kate Morton",
                BookStatus = BookStatusEnum.Active
            });

            // The Japanese Lover
            Books.Add(new Book
            {
                BookNumber = 789227,
                Title = "The Japanese Lover",
                Description = "A young refugee from the Nazis and the son of her family’s Japanese gardener must hide their love, although it lasts a lifetime.",
                Price = 33.99M,
                Cost = 8.16M,
                PublishDate = new DateTime(2015, 11, 7),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                Authors = "Isabel Allende",
                BookStatus = BookStatusEnum.Active
            });

            // The Promise
            Books.Add(new Book
            {
                BookNumber = 789228,
                Title = "The Promise",
                Description = "The Los Angeles P.I. Elvis Cole joins forces with the K-9 officer Scott James of the L.A.P.D. and his German shepherd, Maggie, as well as his partner, Joe Pike, to foil a criminal mastermind.",
                Price = 27.95M,
                Cost = 18.73M,
                PublishDate = new DateTime(2015, 11, 14),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                Authors = "Robert Crais",
                BookStatus = BookStatusEnum.Active
            });

            // The Pharaoh's Secret
            Books.Add(new Book
            {
                BookNumber = 789229,
                Title = "The Pharaoh's Secret",
                Description = "Kurt Austin and Joe Zavala must save the NUMA crew from a mysterious toxin deployed by a villain who wants to build a new Egyptian empire.",
                Price = 31.95M,
                Cost = 12.46M,
                PublishDate = new DateTime(2015, 11, 21),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                Authors = "Clive Cussler and Graham Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The Guilty
            Books.Add(new Book
            {
                BookNumber = 789230,
                Title = "The Guilty",
                Description = "The government hit man Will Robie investigates murder charges against his estranged father in their Mississippi hometown.",
                Price = 19.95M,
                Cost = 17.16M,
                PublishDate = new DateTime(2015, 11, 21),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                Authors = "David Baldacci",
                BookStatus = BookStatusEnum.Active
            });

            // The Mistletoe Inn
            Books.Add(new Book
            {
                BookNumber = 789231,
                Title = "The Mistletoe Inn",
                Description = "An aspiring romance writer with a broken heart meets a complicated man at a Christmas writers’ retreat.",
                Price = 36.95M,
                Cost = 11.09M,
                PublishDate = new DateTime(2015, 11, 21),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                Authors = "Richard Paul Evans",
                BookStatus = BookStatusEnum.Active
            });

            // Find Her
            Books.Add(new Book
            {
                BookNumber = 789232,
                Title = "Find Her",
                Description = "The Boston detective D.D. Warren hunts for a missing woman who was kidnapped and abused as a college student and may have become a vigilante.",
                Price = 28.95M,
                Cost = 10.71M,
                PublishDate = new DateTime(2016, 2, 13),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Lisa Gardner",
                BookStatus = BookStatusEnum.Active
            });

            // Wedding Cake Murder
            Books.Add(new Book
            {
                BookNumber = 789233,
                Title = "Wedding Cake Murder",
                Description = "The Lake Eden, Minn., baker Hannah Swensen is about to get married, but first she must solve the murder of a visiting celebrity chef. Recipes included.",
                Price = 23.95M,
                Cost = 17.72M,
                PublishDate = new DateTime(2016, 2, 27),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Joanne Fluke",
                BookStatus = BookStatusEnum.Active
            });

            // The Gangster
            Books.Add(new Book
            {
                BookNumber = 789234,
                Title = "The Gangster",
                Description = "n the ninth book in this series, set in 1906, the New York detective Isaac Bell contends with a crime boss passing as a respectable businessman and a tycoon’s plot against President Theodore Roosevelt.",
                Price = 30.95M,
                Cost = 7.12M,
                PublishDate = new DateTime(2016, 3, 5),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Clive Cussler and Justin Scott",
                BookStatus = BookStatusEnum.Active
            });

            // Fool Me Once
            Books.Add(new Book
            {
                BookNumber = 789235,
                Title = "Fool Me Once",
                Description = "A retired Army helicopter pilot faces combat-related nightmares and mysteries concerning the deaths of her husband and sister.",
                Price = 24.95M,
                Cost = 12.72M,
                PublishDate = new DateTime(2016, 3, 26),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                Authors = "Harlan Coben",
                BookStatus = BookStatusEnum.Active
            });

            // Robert B. Parker's Slow Burn
            Books.Add(new Book
            {
                BookNumber = 789236,
                Title = "Robert B. Parker's Slow Burn",
                Description = "Spenser is back, leaving a trail of antagonism as he investigates a series of suspicious Boston fires.",
                Price = 22.99M,
                Cost = 10.58M,
                PublishDate = new DateTime(2016, 5, 7),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Ace Atkins",
                BookStatus = BookStatusEnum.Active
            });

            // Zero K
            Books.Add(new Book
            {
                BookNumber = 789237,
                Title = "Zero K",
                Description = "A billionaire and his son meet at a remote desert compound dedicated to preserving bodies until they can be returned to life in the future.",
                Price = 20.00M,
                Cost = 15.20M,
                PublishDate = new DateTime(2016, 5, 7),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                Authors = "Don DeLillo",
                BookStatus = BookStatusEnum.Active
            });

            // The Second Life Of Nick Mason
            Books.Add(new Book
            {
                BookNumber = 789238,
                Title = "The Second Life Of Nick Mason",
                Description = "A deal with a fellow inmate, a crime boss, springs Nick Mason from prison, but he must become an assassin.",
                Price = 19.99M,
                Cost = 3.20M,
                PublishDate = new DateTime(2016, 5, 21),
                InventoryQuantity = 5,
                ReorderPoint = 2,
                Authors = "Steve Hamilton",
                BookStatus = BookStatusEnum.Active
            });

            // The Weekenders
            Books.Add(new Book
            {
                BookNumber = 789239,
                Title = "The Weekenders",
                Description = "On the North Carolina island of Belle Isle, a woman investigates her husband’s shady financial affairs after his mysterious death.",
                Price = 20.95M,
                Cost = 12.78M,
                PublishDate = new DateTime(2016, 5, 21),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Mary Kay Andrews",
                BookStatus = BookStatusEnum.Active
            });

            // The Emperor's Revenge
            Books.Add(new Book
            {
                BookNumber = 789240,
                Title = "The Emperor's Revenge",
                Description = "Juan Cabrillo teams up with a former C.I.A. colleague to thwart a plan involving the death of millions and international economic meltdown.",
                Price = 27.99M,
                Cost = 20.43M,
                PublishDate = new DateTime(2016, 6, 4),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                Authors = "Clive Cussler and Boyd Morrison",
                BookStatus = BookStatusEnum.Active
            });

            // Homegoing
            Books.Add(new Book
            {
                BookNumber = 789241,
                Title = "Homegoing",
                Description = "This Ghanaian-American writer’s first novel traces the lives in West Africa and America of seven generations of the descendants of two half sisters.",
                Price = 26.95M,
                Cost = 2.70M,
                PublishDate = new DateTime(2016, 6, 11),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                Authors = "Yaa Gyasi",
                BookStatus = BookStatusEnum.Active
            });

            // Here's To Us
            Books.Add(new Book
            {
                BookNumber = 789242,
                Title = "Here's To Us",
                Description = "Sparks fly as a celebrity chef’s ex-wives pile into a small cabin in Nantucket to join his widow for the reading of his will.",
                Price = 26.95M,
                Cost = 8.62M,
                PublishDate = new DateTime(2016, 6, 18),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                Authors = "Elin Hilderbrand",
                BookStatus = BookStatusEnum.Active
            });

            // The Pursuit
            Books.Add(new Book
            {
                BookNumber = 789243,
                Title = "The Pursuit",
                Description = "The F.B.I. agent Kate O’Hare and her con man partner, Nick Fox, face off against a dangerous ex-Serbian military officer.",
                Price = 25.99M,
                Cost = 18.45M,
                PublishDate = new DateTime(2016, 6, 25),
                InventoryQuantity = 8,
                ReorderPoint = 5,
                Authors = "Janet Evanovich and Lee Goldberg",
                BookStatus = BookStatusEnum.Active
            });

            // Among The Wicked
            Books.Add(new Book
            {
                BookNumber = 789244,
                Title = "Among The Wicked",
                Description = "Chief of Police Kate Burkholder goes undercover as a widow in a reclusive Amish community to investigate a girl's death.",
                Price = 24.00M,
                Cost = 6.72M,
                PublishDate = new DateTime(2016, 7, 16),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                Authors = "Linda Castillo",
                BookStatus = BookStatusEnum.Active
            });

            // The Woman In Cabin 10
            Books.Add(new Book
            {
                BookNumber = 789245,
                Title = "The Woman In Cabin 10",
                Description = "A travel writer on a cruise is certain she has heard a body thrown overboard, but no one believes her.",
                Price = 32.00M,
                Cost = 3.52M,
                PublishDate = new DateTime(2016, 7, 23),
                InventoryQuantity = 9,
                ReorderPoint = 7,
                Authors = "Ruth Ware",
                BookStatus = BookStatusEnum.Active
            });

            // Truly Madly Guilty
            Books.Add(new Book
            {
                BookNumber = 789246,
                Title = "Truly Madly Guilty",
                Description = "Tense turning points for three couples at a backyard barbecue gone wrong.",
                Price = 14.99M,
                Cost = 10.04M,
                PublishDate = new DateTime(2016, 7, 30),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "Liane Moriarty",
                BookStatus = BookStatusEnum.Active
            });

            // The Underground Railroad
            Books.Add(new Book
            {
                BookNumber = 789247,
                Title = "The Underground Railroad",
                Description = "A slave girl heads toward freedom on the network, envisioned as actual tracks and tunnels.",
                Price = 32.00M,
                Cost = 3.20M,
                PublishDate = new DateTime(2016, 8, 6),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                Authors = "Colson Whitehead",
                BookStatus = BookStatusEnum.Active
            });

            // Dragonmark
            Books.Add(new Book
            {
                BookNumber = 789248,
                Title = "Dragonmark",
                Description = "The first book of a new trilogy featuring Illarion, a dragon made into a human  against his will. A Dark-Hunter novel.",
                Price = 29.95M,
                Cost = 3.29M,
                PublishDate = new DateTime(2016, 8, 6),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                Authors = "Sherrilyn Kenyon",
                BookStatus = BookStatusEnum.Active
            });

            // Another Brooklyn
            Books.Add(new Book
            {
                BookNumber = 789249,
                Title = "Another Brooklyn",
                Description = "An adult novel by an award-winning children's book author centers on memories of growing up and the close friendship of four girls.",
                Price = 36.00M,
                Cost = 9.72M,
                PublishDate = new DateTime(2016, 8, 13),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                Authors = "Jacqueline Woodson",
                BookStatus = BookStatusEnum.Active
            });

            // Sting
            Books.Add(new Book
            {
                BookNumber = 789250,
                Title = "Sting",
                Description = "A hired killer and a woman he kidnapped join forces to elude the F.B.I. agents and others who are searching for her corrupt brother.",
                Price = 27.00M,
                Cost = 8.91M,
                PublishDate = new DateTime(2016, 8, 20),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                Authors = "Sandra Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The Kept Woman
            Books.Add(new Book
            {
                BookNumber = 789251,
                Title = "The Kept Woman",
                Description = "Will Trent of the Georgia Bureau of Investigation and his lover, the medical examiner Sara Linton, pursue a case involving a dirty Atlanta cop.",
                Price = 16.95M,
                Cost = 15.26M,
                PublishDate = new DateTime(2016, 9, 24),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                Authors = "Karin Slaughter",
                BookStatus = BookStatusEnum.Active
            });

            // Twelve Days Of Christmas
            Books.Add(new Book
            {
                BookNumber = 789252,
                Title = "Twelve Days Of Christmas",
                Description = "A woman starts a blog about her attempt to reach out to a grumpy neighbor at Christmastime, and finds herself falling for him.",
                Price = 25.99M,
                Cost = 23.13M,
                PublishDate = new DateTime(2016, 10, 8),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                Authors = "Debbie Macomber",
                BookStatus = BookStatusEnum.Active
            });

            // Winter Storms
            Books.Add(new Book
            {
                BookNumber = 789253,
                Title = "Winter Storms",
                Description = "In the final book of the Winter Street trilogy, a huge snowstorm bearing down on Nantucket threatens the Quinn family’s Christmas, after a year of significant events.",
                Price = 29.00M,
                Cost = 24.94M,
                PublishDate = new DateTime(2016, 10, 8),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                Authors = "Elin Hilderbrand",
                BookStatus = BookStatusEnum.Active
            });

            // Vince Flynn: Order To Kill
            Books.Add(new Book
            {
                BookNumber = 789254,
                Title = "Vince Flynn: Order To Kill",
                Description = "Flynn’s character, the C.I.A. operative Mitch Rapp, uncovers a dangerous Russian plot. Flynn died in 2013.",
                Price = 16.95M,
                Cost = 13.73M,
                PublishDate = new DateTime(2016, 10, 15),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                Authors = "Kyle Mills",
                BookStatus = BookStatusEnum.Active
            });

            // Crimson Death
            Books.Add(new Book
            {
                BookNumber = 789255,
                Title = "Crimson Death",
                Description = "The vampire hunter Anita Blake, her friend Edward and her servant Damian travel to Ireland to battle an unusual vampire infestation.",
                Price = 16.99M,
                Cost = 7.65M,
                PublishDate = new DateTime(2016, 10, 15),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Laurell K Hamilton",
                BookStatus = BookStatusEnum.Active
            });

            // The Obsidian Chamber
            Books.Add(new Book
            {
                BookNumber = 789256,
                Title = "The Obsidian Chamber",
                Description = "While the F.B.I. agent Aloysius Pendergast is believed dead, his ward is kidnapped.",
                Price = 17.00M,
                Cost = 3.57M,
                PublishDate = new DateTime(2016, 10, 22),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                Authors = "Douglas Preston and Lincoln Child",
                BookStatus = BookStatusEnum.Active
            });

            // Escape Clause
            Books.Add(new Book
            {
                BookNumber = 789257,
                Title = "Escape Clause",
                Description = "Virgil Flowers of the Minnesota Bureau of Criminal Apprehension must deal with the theft of tigers from the local zoo.",
                Price = 35.95M,
                Cost = 7.19M,
                PublishDate = new DateTime(2016, 10, 22),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                Authors = "John Sandford",
                BookStatus = BookStatusEnum.Active
            });

            // The Whistler
            Books.Add(new Book
            {
                BookNumber = 789258,
                Title = "The Whistler",
                Description = "A whistleblower alerts a Florida investigator to judicial corruption involving the Mob and Indian casinos.",
                Price = 26.95M,
                Cost = 13.48M,
                PublishDate = new DateTime(2016, 10, 29),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "John Grisham",
                BookStatus = BookStatusEnum.Active
            });

            // The Whole Town's Talking
            Books.Add(new Book
            {
                BookNumber = 789259,
                Title = "The Whole Town's Talking",
                Description = "A century of life in small-town Elmwood Springs, Mo.",
                Price = 31.99M,
                Cost = 21.11M,
                PublishDate = new DateTime(2016, 12, 3),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Fannie Flagg",
                BookStatus = BookStatusEnum.Active
            });

            // Rogue One: A Star Wars Story
            Books.Add(new Book
            {
                BookNumber = 789260,
                Title = "Rogue One: A Star Wars Story",
                Description = "A novelization of the new movie, including additional scenes.",
                Price = 33.95M,
                Cost = 23.77M,
                PublishDate = new DateTime(2016, 12, 24),
                InventoryQuantity = 7,
                ReorderPoint = 6,
                Authors = "Alexander Freed",
                BookStatus = BookStatusEnum.Active
            });

            // The Mistress
            Books.Add(new Book
            {
                BookNumber = 789261,
                Title = "The Mistress",
                Description = "The beautiful mistress of a Russian oligarch falls in love with an artist and yearns for freedom.",
                Price = 36.95M,
                Cost = 15.52M,
                PublishDate = new DateTime(2017, 1, 7),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                Authors = "Danielle Steel",
                BookStatus = BookStatusEnum.Active
            });

            // Ring Of Fire
            Books.Add(new Book
            {
                BookNumber = 789262,
                Title = "Ring Of Fire",
                Description = "Pike Logan, a member of a secret counterterrorist unit called the Taskforce, investigates a Saudi-backed Moroccan terrorist cell.",
                Price = 22.00M,
                Cost = 19.58M,
                PublishDate = new DateTime(2017, 1, 14),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                Authors = "Brad Taylor",
                BookStatus = BookStatusEnum.Active
            });

            // Death's Mistress
            Books.Add(new Book
            {
                BookNumber = 789263,
                Title = "Death's Mistress",
                Description = "The first book of a new series, the Nicci Chronicles, centers on a character from the Sword of Truth fantasy series.",
                Price = 20.00M,
                Cost = 12.00M,
                PublishDate = new DateTime(2017, 1, 28),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                Authors = "Terry Goodkind",
                BookStatus = BookStatusEnum.Active
            });

            // 4 3 2 1
            Books.Add(new Book
            {
                BookNumber = 789264,
                Title = "4 3 2 1",
                Description = "Four versions of the formative years of a Jewish boy born in Newark in 1947.",
                Price = 20.95M,
                Cost = 5.87M,
                PublishDate = new DateTime(2017, 2, 4),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                Authors = "Paul Auster",
                BookStatus = BookStatusEnum.Active
            });

            // Gunmetal Gray
            Books.Add(new Book
            {
                BookNumber = 789265,
                Title = "Gunmetal Gray",
                Description = "Court Gentry, now working for the C.I.A., pursues a Chinese hacker who is on the run.",
                Price = 21.95M,
                Cost = 16.24M,
                PublishDate = new DateTime(2017, 2, 18),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Mark Greaney",
                BookStatus = BookStatusEnum.Active
            });

            // Banana Cream Pie Murder
            Books.Add(new Book
            {
                BookNumber = 789266,
                Title = "Banana Cream Pie Murder",
                Description = "Hannah Swensen, the bakery owner and amateur sleuth of Lake Eden, Minn., returns from her honeymoon to confront an actress’s mysterious death.",
                Price = 36.95M,
                Cost = 14.41M,
                PublishDate = new DateTime(2017, 3, 4),
                InventoryQuantity = 7,
                ReorderPoint = 5,
                Authors = "Joanne Fluke",
                BookStatus = BookStatusEnum.Active
            });

            // Silence Fallen
            Books.Add(new Book
            {
                BookNumber = 789267,
                Title = "Silence Fallen",
                Description = "The shape-shifter Mercy Thompson finds herself in the clutches of the world’s most powerful vampire.",
                Price = 36.00M,
                Cost = 10.08M,
                PublishDate = new DateTime(2017, 3, 11),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                Authors = "Patricia Briggs",
                BookStatus = BookStatusEnum.Active
            });

            // Without Warning
            Books.Add(new Book
            {
                BookNumber = 789268,
                Title = "Without Warning",
                Description = "A journalist pursues the head of ISIS after an attack on the Capitol when the administration fails to take action.",
                Price = 27.95M,
                Cost = 12.02M,
                PublishDate = new DateTime(2017, 3, 18),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                Authors = "Joel C Rosenberg",
                BookStatus = BookStatusEnum.Active
            });

            // Song Of The Lion
            Books.Add(new Book
            {
                BookNumber = 789269,
                Title = "Song Of The Lion",
                Description = "The third Southwestern mystery featuring the Navajo police officer Bernadette Manuelito and her husband, Jim Chee.",
                Price = 31.99M,
                Cost = 24.63M,
                PublishDate = new DateTime(2017, 4, 15),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                Authors = "Anne Hillerman",
                BookStatus = BookStatusEnum.Active
            });

            // The Burial Hour
            Books.Add(new Book
            {
                BookNumber = 789270,
                Title = "The Burial Hour",
                Description = "Lincoln Rhyme travels to Italy to investigate a case.",
                Price = 16.00M,
                Cost = 1.60M,
                PublishDate = new DateTime(2017, 4, 15),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                Authors = "Jeffery Deaver",
                BookStatus = BookStatusEnum.Active
            });

            // Nighthawk
            Books.Add(new Book
            {
                BookNumber = 789271,
                Title = "Nighthawk",
                Description = "The NUMA crew races the Russians and Chinese in a hunt for a missing American aircraft.",
                Price = 30.00M,
                Cost = 21.60M,
                PublishDate = new DateTime(2017, 6, 3),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                Authors = "Clive Cussler and Graham Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The Identicals
            Books.Add(new Book
            {
                BookNumber = 789272,
                Title = "The Identicals",
                Description = "Complications in the lives of identical twins who were raised by their divorced parents, one on Nantucket, one on Martha’s Vineyard.",
                Price = 33.95M,
                Cost = 4.41M,
                PublishDate = new DateTime(2017, 6, 17),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Elin Hilderbrand",
                BookStatus = BookStatusEnum.Active
            });

            // House Of Spies
            Books.Add(new Book
            {
                BookNumber = 789273,
                Title = "House Of Spies",
                Description = "Gabriel Allon, the Israeli art restorer and spy, now the head of Israel’s secret intelligence service, pursues an ISIS mastermind.",
                Price = 33.95M,
                Cost = 17.31M,
                PublishDate = new DateTime(2017, 7, 15),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                Authors = "Daniel Silva",
                BookStatus = BookStatusEnum.Active
            });

            // Two Nights
            Books.Add(new Book
            {
                BookNumber = 789274,
                Title = "Two Nights",
                Description = "Sunday Night, the heroine of a new series from the creator of Temperance Brennan, searches for a girl who may have been kidnapped by a cult.",
                Price = 17.95M,
                Cost = 15.98M,
                PublishDate = new DateTime(2017, 7, 15),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                Authors = "Kathy Reichs",
                BookStatus = BookStatusEnum.Active
            });

            // Meddling Kids
            Books.Add(new Book
            {
                BookNumber = 789275,
                Title = "Meddling Kids",
                Description = "Four old friends return to the site of their teenage adventures.",
                Price = 30.95M,
                Cost = 3.71M,
                PublishDate = new DateTime(2017, 7, 22),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                Authors = "Edgar Cantero",
                BookStatus = BookStatusEnum.Active
            });

            // Watch Me Disappear
            Books.Add(new Book
            {
                BookNumber = 789276,
                Title = "Watch Me Disappear",
                Description = "When a Berkeley woman vanishes after a hiking trip, her husband and daughter discover disturbing secrets.",
                Price = 32.95M,
                Cost = 30.64M,
                PublishDate = new DateTime(2017, 7, 22),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                Authors = "Janelle Brown",
                BookStatus = BookStatusEnum.Active
            });

            // The Store
            Books.Add(new Book
            {
                BookNumber = 789277,
                Title = "The Store",
                Description = "Two New York writers go undercover to expose the secrets of a powerful retailer.",
                Price = 31.00M,
                Cost = 15.19M,
                PublishDate = new DateTime(2017, 8, 19),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                Authors = "James Patterson and Richard DiLallo",
                BookStatus = BookStatusEnum.Active
            });

            // I Know A Secret
            Books.Add(new Book
            {
                BookNumber = 789278,
                Title = "I Know A Secret",
                Description = "Rizzoli and Isles investigate two separate homicides and uncover other dangerous mysteries.",
                Price = 32.95M,
                Cost = 26.36M,
                PublishDate = new DateTime(2017, 8, 19),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                Authors = "Tess Gerritsen",
                BookStatus = BookStatusEnum.Active
            });

            // Sulfur Springs
            Books.Add(new Book
            {
                BookNumber = 789279,
                Title = "Sulfur Springs",
                Description = "A newly married couple search for the wife's missing son, which leads them to a border town in the middle of a drug war.",
                Price = 32.95M,
                Cost = 17.79M,
                PublishDate = new DateTime(2017, 8, 26),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "William Kent Krueger",
                BookStatus = BookStatusEnum.Active
            });

            // Enemy Of The State
            Books.Add(new Book
            {
                BookNumber = 789280,
                Title = "Enemy Of The State",
                Description = "Vince Flynn's character Mitch Rapp leaves the C.I.A. to go on a manhunt when the nephew of a Saudi King finances a terrorist group.",
                Price = 20.95M,
                Cost = 4.19M,
                PublishDate = new DateTime(2017, 9, 9),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                Authors = "Kyle Mills",
                BookStatus = BookStatusEnum.Active
            });

            // Little Fires Everywhere
            Books.Add(new Book
            {
                BookNumber = 789281,
                Title = "Little Fires Everywhere",
                Description = "An artist with a mysterious past and a disregard for the status quo upends a quiet town outside Cleveland.",
                Price = 16.00M,
                Cost = 12.00M,
                PublishDate = new DateTime(2017, 9, 16),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                Authors = "Celeste Ng",
                BookStatus = BookStatusEnum.Active
            });

            // Twin Peaks: The Final Dossier
            Books.Add(new Book
            {
                BookNumber = 789282,
                Title = "Twin Peaks: The Final Dossier",
                Description = "Updated profiles on the residents of Twin Peaks are assembled by special agent Tamara Preston.",
                Price = 27.95M,
                Cost = 8.66M,
                PublishDate = new DateTime(2017, 11, 4),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                Authors = "Mark Frost",
                BookStatus = BookStatusEnum.Active
            });

            // The House Of Unexpected Sisters
            Books.Add(new Book
            {
                BookNumber = 789283,
                Title = "The House Of Unexpected Sisters",
                Description = "During an investigation, Precious Ramotswe encounters a man from her past and a nurse who has her last name.",
                Price = 29.95M,
                Cost = 16.47M,
                PublishDate = new DateTime(2017, 11, 11),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                Authors = "Alexander McCall Smith",
                BookStatus = BookStatusEnum.Active
            });

            // Artemis
            Books.Add(new Book
            {
                BookNumber = 789284,
                Title = "Artemis",
                Description = "A small-time smuggler living in a lunar colony schemes to pay off an old debt by pulling off a challenging heist.",
                Price = 31.00M,
                Cost = 18.91M,
                PublishDate = new DateTime(2017, 11, 18),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                Authors = "Andy Weir",
                BookStatus = BookStatusEnum.Active
            });

            // Robicheaux
            Books.Add(new Book
            {
                BookNumber = 789285,
                Title = "Robicheaux",
                Description = "A bereaved detective confronts his past and works to clear his name when he becomes a suspect during an investigation into the murder of the man who killed his wife.",
                Price = 17.95M,
                Cost = 15.98M,
                PublishDate = new DateTime(2018, 1, 6),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                Authors = "James Lee Burke",
                BookStatus = BookStatusEnum.Active
            });

            // Unbound
            Books.Add(new Book
            {
                BookNumber = 789286,
                Title = "Unbound",
                Description = "The 44th book in the Stone Barrington series.",
                Price = 16.00M,
                Cost = 11.36M,
                PublishDate = new DateTime(2018, 1, 6),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                Authors = "Stuart Woods",
                BookStatus = BookStatusEnum.Active
            });

            // The Immortalists
            Books.Add(new Book
            {
                BookNumber = 789287,
                Title = "The Immortalists",
                Description = "Four adolescents learn the dates of their deaths from a psychic and their lives go on different courses.",
                Price = 31.00M,
                Cost = 22.32M,
                PublishDate = new DateTime(2018, 1, 13),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                Authors = "Chloe Benjamin",
                BookStatus = BookStatusEnum.Active
            });

            // Blood Fury
            Books.Add(new Book
            {
                BookNumber = 789288,
                Title = "Blood Fury",
                Description = "The third book in the Black Dagger Legacy series.",
                Price = 30.95M,
                Cost = 21.05M,
                PublishDate = new DateTime(2018, 1, 13),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                Authors = "JR Ward",
                BookStatus = BookStatusEnum.Active
            });

            // The Grave's A Fine And Private Place
            Books.Add(new Book
            {
                BookNumber = 789289,
                Title = "The Grave's A Fine And Private Place",
                Description = "Flavia de Luce, a young British sleuth, gets involved in solving a murder after experiencing a family tragedy.",
                Price = 26.95M,
                Cost = 21.83M,
                PublishDate = new DateTime(2018, 2, 3),
                InventoryQuantity = 7,
                ReorderPoint = 5,
                Authors = "Alan Bradley",
                BookStatus = BookStatusEnum.Active
            });

            // An American Marriage
            Books.Add(new Book
            {
                BookNumber = 789290,
                Title = "An American Marriage",
                Description = "A newlywed couple's relationship is tested when the husband is sentenced to 12 years in prison.",
                Price = 22.95M,
                Cost = 12.16M,
                PublishDate = new DateTime(2018, 2, 10),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                Authors = "Tayari Jones",
                BookStatus = BookStatusEnum.Active
            });

            // Fifty Fifty
            Books.Add(new Book
            {
                BookNumber = 789291,
                Title = "Fifty Fifty",
                Description = "Detective Harriet Blue tries to clear her brother's name and save a small Australian town from being massacred.",
                Price = 35.99M,
                Cost = 28.07M,
                PublishDate = new DateTime(2018, 2, 24),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                Authors = "James Patterson and Candice Fox",
                BookStatus = BookStatusEnum.Active
            });

            // Star Wars: The Last Jedi
            Books.Add(new Book
            {
                BookNumber = 789292,
                Title = "Star Wars: The Last Jedi",
                Description = "An adaptation of the film, written with input from its director, Rian Johnson, which includes scenes from alternate versions of the script.",
                Price = 28.99M,
                Cost = 24.64M,
                PublishDate = new DateTime(2018, 3, 10),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                Authors = "Jason Fry",
                BookStatus = BookStatusEnum.Active
            });

            // Caribbean Rim
            Books.Add(new Book
            {
                BookNumber = 789293,
                Title = "Caribbean Rim",
                Description = "The 25th book in the Doc Ford series. The marine biologist searches for a state agency official and rare Spanish coins.",
                Price = 15.00M,
                Cost = 9.45M,
                PublishDate = new DateTime(2018, 3, 17),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                Authors = "Randy Wayne White",
                BookStatus = BookStatusEnum.Active
            });

            // To Die But Once
            Books.Add(new Book
            {
                BookNumber = 789294,
                Title = "To Die But Once",
                Description = "In 1940, months after Britain declared war on Germany, Maisie Dobbs investigates the disappearance of an apprentice working on a government contract.",
                Price = 24.95M,
                Cost = 19.21M,
                PublishDate = new DateTime(2018, 3, 31),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                Authors = "Jacqueline Winspear",
                BookStatus = BookStatusEnum.Active
            });

            // Macbeth
            Books.Add(new Book
            {
                BookNumber = 789295,
                Title = "Macbeth",
                Description = "In this adaptation of Shakespeare's tragedy, police in a 1970s industrial town take on a pair of drug lords.",
                Price = 28.95M,
                Cost = 7.53M,
                PublishDate = new DateTime(2018, 4, 14),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                Authors = "Jo Nesbo",
                BookStatus = BookStatusEnum.Active
            });

            // The High Tide Club
            Books.Add(new Book
            {
                BookNumber = 789296,
                Title = "The High Tide Club",
                Description = "An eccentric millionaire enlists the attorney Brooke Trappnell to fix old wrongs, which sets up a potential scandal and murder.",
                Price = 23.95M,
                Cost = 14.13M,
                PublishDate = new DateTime(2018, 5, 12),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                Authors = "Mary Kay Andrews",
                BookStatus = BookStatusEnum.Active
            });

            // Warlight
            Books.Add(new Book
            {
                BookNumber = 789297,
                Title = "Warlight",
                Description = "In Britain after World War II, a pair of teenage siblings are taken under the tutelage of a mysterious man and his cronies who served during the war.",
                Price = 26.00M,
                Cost = 20.28M,
                PublishDate = new DateTime(2018, 5, 12),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                Authors = "Michael Ondaatje",
                BookStatus = BookStatusEnum.Active
            });

            // The Cast
            Books.Add(new Book
            {
                BookNumber = 789298,
                Title = "The Cast",
                Description = "A magazine columnist meets an array of Hollywood professionals when a producer turns a story about her grandmother into a TV series.",
                Price = 21.95M,
                Cost = 12.95M,
                PublishDate = new DateTime(2018, 5, 19),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                Authors = "Danielle Steel",
                BookStatus = BookStatusEnum.Active
            });

            // Beach House Reunion
            Books.Add(new Book
            {
                BookNumber = 789299,
                Title = "Beach House Reunion",
                Description = "Three generations of a family gather one summer in South Carolina.",
                Price = 32.95M,
                Cost = 6.59M,
                PublishDate = new DateTime(2018, 5, 26),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                Authors = "Mary Alice Monroe",
                BookStatus = BookStatusEnum.Active
            });

            // Turbulence
            Books.Add(new Book
            {
                BookNumber = 789300,
                Title = "Turbulence",
                Description = "The 46th book in the Stone Barrington series.",
                Price = 15.95M,
                Cost = 6.06M,
                PublishDate = new DateTime(2018, 6, 9),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                Authors = "Stuart Woods",
                BookStatus = BookStatusEnum.Active
            });

            // PART 3: UPSERT logic - check each book and add/update
            Int32 bookNumber = 0;
            try
            {
                foreach (Book bookToAdd in Books)
                {
                    // Set error flag to current book number
                    bookNumber = bookToAdd.BookNumber;

                    // Look up the genre by name
                    Genre dbGenre = db.Genres.FirstOrDefault(g => g.GenreName == GetGenreNameForBook(bookToAdd.BookNumber));
                    if (dbGenre == null)
                    {
                        throw new Exception($"Genre not found for book {bookToAdd.BookNumber}. Make sure genres are seeded first!");
                    }
                    bookToAdd.Genre = dbGenre;

                    // Check if book already exists in database by BookNumber
                    Book dbBook = db.Books.FirstOrDefault(b => b.BookNumber == bookToAdd.BookNumber);

                    if (dbBook == null) // Book doesn't exist - ADD
                    {
                        db.Books.Add(bookToAdd);
                        db.SaveChanges();
                    }
                    else // Book exists - UPDATE
                    {
                        dbBook.Title = bookToAdd.Title;
                        dbBook.Description = bookToAdd.Description;
                        dbBook.Price = bookToAdd.Price;
                        dbBook.Cost = bookToAdd.Cost;
                        dbBook.PublishDate = bookToAdd.PublishDate;
                        dbBook.InventoryQuantity = bookToAdd.InventoryQuantity;
                        dbBook.ReorderPoint = bookToAdd.ReorderPoint;
                        dbBook.Authors = bookToAdd.Authors;
                        dbBook.BookStatus = bookToAdd.BookStatus;
                        dbBook.Genre = dbGenre;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a problem adding the book with book number: {bookNumber}", ex);
            }
        }

        // Helper method to get genre name for each book
        private static string GetGenreNameForBook(int bookNumber)
        {
            var genreMap = new Dictionary<int, string>
            {
                { 789001, "Contemporary Fiction" },
                { 789002, "Science Fiction" },
                { 789003, "Mystery" },
                { 789004, "Suspense" },
                { 789005, "Romance" },
                { 789006, "Thriller" },
                { 789007, "Fantasy" },
                { 789008, "Contemporary Fiction" },
                { 789009, "Romance" },
                { 789010, "Fantasy" },
                { 789011, "Historical Fiction" },
                { 789012, "Romance" },
                { 789013, "Historical Fiction" },
                { 789014, "Romance" },
                { 789015, "Fantasy" },
                { 789016, "Mystery" },
                { 789017, "Mystery" },
                { 789018, "Suspense" },
                { 789019, "Romance" },
                { 789020, "Contemporary Fiction" },
                { 789021, "Mystery" },
                { 789022, "Suspense" },
                { 789023, "Mystery" },
                { 789024, "Fantasy" },
                { 789025, "Suspense" },
                { 789026, "Romance" },
                { 789027, "Mystery" },
                { 789028, "Historical Fiction" },
                { 789029, "Mystery" },
                { 789030, "Romance" },
                { 789031, "Historical Fiction" },
                { 789032, "Fantasy" },
                { 789033, "Mystery" },
                { 789034, "Mystery" },
                { 789035, "Contemporary Fiction" },
                { 789036, "Contemporary Fiction" },
                { 789037, "Thriller" },
                { 789038, "Suspense" },
                { 789039, "Mystery" },
                { 789040, "Fantasy" },
                { 789041, "Suspense" },
                { 789042, "Mystery" },
                { 789043, "Mystery" },
                { 789044, "Fantasy" },
                { 789045, "Suspense" },
                { 789046, "Historical Fiction" },
                { 789047, "Contemporary Fiction" },
                { 789048, "Humor" },
                { 789049, "Fantasy" },
                { 789050, "Thriller" },
                { 789051, "Mystery" },
                { 789052, "Historical Fiction" },
                { 789053, "Mystery" },
                { 789054, "Thriller" },
                { 789055, "Romance" },
                { 789056, "Mystery" },
                { 789057, "Contemporary Fiction" },
                { 789058, "Romance" },
                { 789059, "Mystery" },
                { 789060, "Mystery" },
                { 789061, "Thriller" },
                { 789062, "Thriller" },
                { 789063, "Romance" },
                { 789064, "Romance" },
                { 789065, "Science Fiction" },
                { 789066, "Mystery" },
                { 789067, "Historical Fiction" },
                { 789068, "Suspense" },
                { 789069, "Mystery" },
                { 789070, "Fantasy" },
                { 789071, "Fantasy" },
                { 789072, "Romance" },
                { 789073, "Romance" },
                { 789074, "Romance" },
                { 789075, "Adventure" },
                { 789076, "Contemporary Fiction" },
                { 789077, "Suspense" },
                { 789078, "Mystery" },
                { 789079, "Mystery" },
                { 789080, "Fantasy" },
                { 789081, "Romance" },
                { 789082, "Fantasy" },
                { 789083, "Suspense" },
                { 789084, "Mystery" },
                { 789085, "Mystery" },
                { 789086, "Historical Fiction" },
                { 789087, "Mystery" },
                { 789088, "Mystery" },
                { 789089, "Mystery" },
                { 789090, "Contemporary Fiction" },
                { 789091, "Romance" },
                { 789092, "Mystery" },
                { 789093, "Suspense" },
                { 789094, "Suspense" },
                { 789095, "Contemporary Fiction" },
                { 789096, "Romance" },
                { 789097, "Mystery" },
                { 789098, "Mystery" },
                { 789099, "Suspense" },
                { 789100, "Fantasy" },
                { 789101, "Mystery" },
                { 789102, "Fantasy" },
                { 789103, "Fantasy" },
                { 789104, "Science Fiction" },
                { 789105, "Science Fiction" },
                { 789106, "Mystery" },
                { 789107, "Suspense" },
                { 789108, "Romance" },
                { 789109, "Mystery" },
                { 789110, "Romance" },
                { 789111, "Suspense" },
                { 789112, "Romance" },
                { 789113, "Horror" },
                { 789114, "Romance" },
                { 789115, "Mystery" },
                { 789116, "Suspense" },
                { 789117, "Mystery" },
                { 789118, "Suspense" },
                { 789119, "Mystery" },
                { 789120, "Romance" },
                { 789121, "Mystery" },
                { 789122, "Historical Fiction" },
                { 789123, "Fantasy" },
                { 789124, "Romance" },
                { 789125, "Mystery" },
                { 789126, "Mystery" },
                { 789127, "Horror" },
                { 789128, "Mystery" },
                { 789129, "Romance" },
                { 789130, "Fantasy" },
                { 789131, "Mystery" },
                { 789132, "Mystery" },
                { 789133, "Contemporary Fiction" },
                { 789134, "Science Fiction" },
                { 789135, "Mystery" },
                { 789136, "Suspense" },
                { 789137, "Suspense" },
                { 789138, "Suspense" },
                { 789139, "Suspense" },
                { 789140, "Romance" },
                { 789141, "Mystery" },
                { 789142, "Mystery" },
                { 789143, "Thriller" },
                { 789144, "Thriller" },
                { 789145, "Mystery" },
                { 789146, "Fantasy" },
                { 789147, "Humor" },
                { 789148, "Fantasy" },
                { 789149, "Suspense" },
                { 789150, "Historical Fiction" },
                { 789151, "Mystery" },
                { 789152, "Fantasy" },
                { 789153, "Thriller" },
                { 789154, "Historical Fiction" },
                { 789155, "Suspense" },
                { 789156, "Contemporary Fiction" },
                { 789157, "Contemporary Fiction" },
                { 789158, "Suspense" },
                { 789159, "Mystery" },
                { 789160, "Thriller" },
                { 789161, "Suspense" },
                { 789162, "Historical Fiction" },
                { 789163, "Mystery" },
                { 789164, "Mystery" },
                { 789165, "Suspense" },
                { 789166, "Mystery" },
                { 789167, "Romance" },
                { 789168, "Romance" },
                { 789169, "Fantasy" },
                { 789170, "Poetry" },
                { 789171, "Suspense" },
                { 789172, "Mystery" },
                { 789173, "Romance" },
                { 789174, "Horror" },
                { 789175, "Historical Fiction" },
                { 789176, "Romance" },
                { 789177, "Thriller" },
                { 789178, "Science Fiction" },
                { 789179, "Historical Fiction" },
                { 789180, "Mystery" },
                { 789181, "Suspense" },
                { 789182, "Suspense" },
                { 789183, "Mystery" },
                { 789184, "Historical Fiction" },
                { 789185, "Science Fiction" },
                { 789186, "Contemporary Fiction" },
                { 789187, "Contemporary Fiction" },
                { 789188, "Contemporary Fiction" },
                { 789189, "Mystery" },
                { 789190, "Fantasy" },
                { 789191, "Fantasy" },
                { 789192, "Fantasy" },
                { 789193, "Contemporary Fiction" },
                { 789194, "Fantasy" },
                { 789195, "Fantasy" },
                { 789196, "Suspense" },
                { 789197, "Historical Fiction" },
                { 789198, "Mystery" },
                { 789199, "Historical Fiction" },
                { 789200, "Contemporary Fiction" },
                { 789201, "Historical Fiction" },
                { 789202, "Mystery" },
                { 789203, "Mystery" },
                { 789204, "Mystery" },
                { 789205, "Mystery" },
                { 789206, "Romance" },
                { 789207, "Suspense" },
                { 789208, "Suspense" },
                { 789209, "Mystery" },
                { 789210, "Poetry" },
                { 789211, "Thriller" },
                { 789212, "Contemporary Fiction" },
                { 789213, "Humor" },
                { 789214, "Romance" },
                { 789215, "Romance" },
                { 789216, "Suspense" },
                { 789217, "Mystery" },
                { 789218, "Historical Fiction" },
                { 789219, "Historical Fiction" },
                { 789220, "Romance" },
                { 789221, "Mystery" },
                { 789222, "Thriller" },
                { 789223, "Science Fiction" },
                { 789224, "Mystery" },
                { 789225, "Historical Fiction" },
                { 789226, "Historical Fiction" },
                { 789227, "Romance" },
                { 789228, "Mystery" },
                { 789229, "Thriller" },
                { 789230, "Mystery" },
                { 789231, "Romance" },
                { 789232, "Suspense" },
                { 789233, "Mystery" },
                { 789234, "Thriller" },
                { 789235, "Suspense" },
                { 789236, "Mystery" },
                { 789237, "Science Fiction" },
                { 789238, "Suspense" },
                { 789239, "Mystery" },
                { 789240, "Suspense" },
                { 789241, "Contemporary Fiction" },
                { 789242, "Contemporary Fiction" },
                { 789243, "Mystery" },
                { 789244, "Mystery" },
                { 789245, "Thriller" },
                { 789246, "Contemporary Fiction" },
                { 789247, "Historical Fiction" },
                { 789248, "Fantasy" },
                { 789249, "Contemporary Fiction" },
                { 789250, "Mystery" },
                { 789251, "Suspense" },
                { 789252, "Romance" },
                { 789253, "Contemporary Fiction" },
                { 789254, "Suspense" },
                { 789255, "Fantasy" },
                { 789256, "Suspense" },
                { 789257, "Mystery" },
                { 789258, "Suspense" },
                { 789259, "Historical Fiction" },
                { 789260, "Science Fiction" },
                { 789261, "Romance" },
                { 789262, "Suspense" },
                { 789263, "Fantasy" },
                { 789264, "Historical Fiction" },
                { 789265, "Suspense" },
                { 789266, "Mystery" },
                { 789267, "Fantasy" },
                { 789268, "Suspense" },
                { 789269, "Mystery" },
                { 789270, "Mystery" },
                { 789271, "Thriller" },
                { 789272, "Contemporary Fiction" },
                { 789273, "Suspense" },
                { 789274, "Mystery" },
                { 789275, "Mystery" },
                { 789276, "Mystery" },
                { 789277, "Thriller" },
                { 789278, "Mystery" },
                { 789279, "Mystery" },
                { 789280, "Suspense" },
                { 789281, "Contemporary Fiction" },
                { 789282, "Mystery" },
                { 789283, "Mystery" },
                { 789284, "Science Fiction" },
                { 789285, "Thriller" },
                { 789286, "Mystery" },
                { 789287, "Fantasy" },
                { 789288, "Fantasy" },
                { 789289, "Mystery" },
                { 789290, "Contemporary Fiction" },
                { 789291, "Mystery" },
                { 789292, "Science Fiction" },
                { 789293, "Mystery" },
                { 789294, "Suspense" },
                { 789295, "Shakespeare" },
                { 789296, "Mystery" },
                { 789297, "Historical Fiction" },
                { 789298, "Romance" },
                { 789299, "Contemporary Fiction" },
                { 789300, "Mystery" },
            };

            return genreMap.ContainsKey(bookNumber) ? genreMap[bookNumber] : "Contemporary Fiction";
        }
    }
}
