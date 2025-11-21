using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Group13_Final_Project.Controllers
{
    public class CardsController : Controller
    {
        private readonly AppDbContext _context;

        public CardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index(string searchString, string typeFilter)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentType"] = typeFilter;

            var cards = _context.Cards
                .Include(c => c.Customer)
                .AsQueryable();

            // Search by customer name or card number
            if (!String.IsNullOrEmpty(searchString))
            {
                cards = cards.Where(c =>
                    (c.Customer.FirstName + " " + c.Customer.LastName).Contains(searchString)
                    || c.CardNumber.Contains(searchString));
            }

            // Filter by card type
            if (!String.IsNullOrEmpty(typeFilter))
            {
                switch (typeFilter.ToLower())
                {
                    case "visa":
                        cards = cards.Where(c => c.CardType == CardTypeEnum.Visa);
                        break;
                    case "mastercard":
                        cards = cards.Where(c => c.CardType == CardTypeEnum.MasterCard);
                        break;
                    case "americanexpress":
                        cards = cards.Where(c => c.CardType == CardTypeEnum.AmericanExpress);
                        break;
                    case "discover":
                        cards = cards.Where(c => c.CardType == CardTypeEnum.Discover);
                        break;
                }
            }

            // Order by customer name
            cards = cards.OrderBy(c => c.Customer.LastName).ThenBy(c => c.Customer.FirstName);

            var cardList = await cards.ToListAsync();

            // Record count for display
            ViewBag.RecordCount = $"Showing {cardList.Count} Cards";

            return View(cardList);
        }
    }
}
