using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Group13_Final_Project.Seeding
{
    public static class SeedCards
    {
        public static void SeedAllCards(UserManager<AppUser> userManager, AppDbContext db)
        {
            // Check if cards already seeded
            if (db.Cards.Any())
            {
                return;
            }

            List<(string CustomerEmail, string CardNumber, CardTypeEnum CardType)> CardData = new List<(string, string, CardTypeEnum)>();

            CardData.Add(("cbaker@example.com", "3517193267072490", CardTypeEnum.Visa));
            CardData.Add(("cbaker@example.com", "5653264624505624", CardTypeEnum.MasterCard));
            CardData.Add(("franco@example.com", "2340139018242888", CardTypeEnum.MasterCard));
            CardData.Add(("wchang@example.com", "4888561830797648", CardTypeEnum.Visa));
            CardData.Add(("limchou@gogle.com", "7874839329412510", CardTypeEnum.AmericanExpress));
            CardData.Add(("jeffh@sonic.com", "8882933892564410", CardTypeEnum.Visa));
            CardData.Add(("cmiller@bob.com", "9577230402048890", CardTypeEnum.MasterCard));
            CardData.Add(("elowe@netscare.net", "3391194669212420", CardTypeEnum.AmericanExpress));
            CardData.Add(("knelson@aoll.com", "4186773703003410", CardTypeEnum.Visa));

            // Add cards and link to customers
            foreach (var data in CardData)
            {
                var customer = db.Users.FirstOrDefault(u => u.Email == data.Item1);

                if (customer != null)
                {
                    Card card = new Card
                    {
                        CustomerID = customer.Id,
                        CardNumber = data.Item2,
                        CardType = data.Item3
                    };
                    db.Cards.Add(card);
                }
            }

            db.SaveChanges();
        }
    }
}
