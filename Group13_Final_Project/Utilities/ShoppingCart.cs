using System.Text.Json;

namespace Group13_Final_Project.Utilities
{
    // Represents a single item in the shopping cart
    public class CartItem
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal LineTotal => Price * Quantity;
    }

    // Shopping cart stored in session
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Subtotal => Items.Sum(i => i.LineTotal);
        public int TotalItems => Items.Sum(i => i.Quantity);

        public void AddItem(int bookId, string title, string authors, decimal price, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.BookID == bookId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    BookID = bookId,
                    Title = title,
                    Authors = authors,
                    Price = price,
                    Quantity = quantity
                });
            }
        }

        public void UpdateQuantity(int bookId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.BookID == bookId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    Items.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }
        }

        public void RemoveItem(int bookId)
        {
            var item = Items.FirstOrDefault(i => i.BookID == bookId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        // Calculate shipping: $3.50 for first book, $1.50 for each additional
        public decimal CalculateShipping()
        {
            if (TotalItems == 0) return 0;
            return 3.50m + (TotalItems - 1) * 1.50m;
        }
    }

    // Session extension methods for storing/retrieving the shopping cart
    public static class SessionExtensions
    {
        private const string CartKey = "ShoppingCart";

        public static void SetCart(this ISession session, ShoppingCart cart)
        {
            var json = JsonSerializer.Serialize(cart);
            session.SetString(CartKey, json);
        }

        public static ShoppingCart GetCart(this ISession session)
        {
            var json = session.GetString(CartKey);
            if (string.IsNullOrEmpty(json))
            {
                return new ShoppingCart();
            }
            return JsonSerializer.Deserialize<ShoppingCart>(json) ?? new ShoppingCart();
        }

        public static void ClearCart(this ISession session)
        {
            session.Remove(CartKey);
        }
    }
}
