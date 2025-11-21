import pandas as pd
from datetime import datetime
import os

# Read the Excel file
excel_file = "Bevos Bookstore Data v3.xlsx"

print("Generating seeding files with UPSERT logic...")
print("="*80)

# Create Seeding folder if it doesn't exist
os.makedirs("Group13_Final_Project/Seeding", exist_ok=True)

# ============================================================================
# 1. CUSTOMERS SEEDING
# ============================================================================
print("\n1. Generating SeedCustomers.cs...")
df_customers = pd.read_excel(excel_file, sheet_name='Customers')
df_customers = df_customers.fillna('')

cs_customers = """using Group13_Final_Project.DAL;
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

"""

for index, row in df_customers.iterrows():
    email = str(row['Email']).strip()
    password = str(row['Password']).strip()
    first_name = str(row['First Name']).strip()
    last_name = str(row['Last Name']).strip()
    street = str(row['Street']).strip()
    city = str(row['City']).strip()
    state = str(row['State']).strip()
    zip_code = str(row['Zip']).strip()
    phone = str(row['Phone']).strip()

    birthday_str = 'null'
    if pd.notna(row['Birthday']) and str(row['Birthday']).strip() != '':
        try:
            bday = pd.to_datetime(row['Birthday'])
            birthday_str = f'new DateTime({bday.year}, {bday.month}, {bday.day})'
        except:
            birthday_str = 'null'

    cs_customers += f"""            Customers.Add(new AddUserModel
            {{
                User = new AppUser
                {{
                    UserName = "{email}",
                    Email = "{email}",
                    FirstName = "{first_name}",
                    LastName = "{last_name}",
                    Birthday = {birthday_str},
                    Address = "{street}",
                    City = "{city}",
                    State = "{state}",
                    ZipCode = "{zip_code}",
                    PhoneNumber = "{phone}",
                    Status = true
                }},
                Password = "{password}",
                RoleName = "Customer"
            }});

"""

cs_customers += """            // UPSERT: Add or update each customer
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
"""

with open("Group13_Final_Project/Seeding/SeedCustomers.cs", 'w', encoding='utf-8') as f:
    f.write(cs_customers)
print(f"   ✓ Created SeedCustomers.cs ({len(df_customers)} customers)")

# ============================================================================
# 2. EMPLOYEES SEEDING
# ============================================================================
print("\n2. Generating SeedEmployees.cs...")
df_employees = pd.read_excel(excel_file, sheet_name='Employees')
df_employees = df_employees.fillna('')

cs_employees = """using Group13_Final_Project.DAL;
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

"""

for index, row in df_employees.iterrows():
    email = str(row['Email']).strip()
    password = str(row['PSW']).strip()
    first_name = str(row['FirstName']).strip()
    last_name = str(row['LastName']).strip()
    address = str(row['Address']).strip()
    city = str(row['City']).strip()
    state = str(row['State']).strip()
    zip_code = str(row['Zip']).strip()
    phone = str(row['Phone']).strip()
    emp_type = str(row['EmpType']).strip()

    # Determine role based on EmpType
    role = "Employee" if emp_type.lower() != "manager" else "Manager"

    cs_employees += f"""            Employees.Add(new AddUserModel
            {{
                User = new AppUser
                {{
                    UserName = "{email}",
                    Email = "{email}",
                    FirstName = "{first_name}",
                    LastName = "{last_name}",
                    Address = "{address}",
                    City = "{city}",
                    State = "{state}",
                    ZipCode = "{zip_code}",
                    PhoneNumber = "{phone}",
                    Status = true
                }},
                Password = "{password}",
                RoleName = "{role}"
            }});

"""

cs_employees += """            // UPSERT: Add or update each employee
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
"""

with open("Group13_Final_Project/Seeding/SeedEmployees.cs", 'w', encoding='utf-8') as f:
    f.write(cs_employees)
print(f"   ✓ Created SeedEmployees.cs ({len(df_employees)} employees)")

# ============================================================================
# 3. CARDS SEEDING
# ============================================================================
print("\n3. Generating SeedCards.cs...")
df_cards = pd.read_excel(excel_file, sheet_name='Cards')
df_cards = df_cards.fillna('')

cs_cards = """using Group13_Final_Project.DAL;
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

            List<Card> Cards = new List<Card>();

"""

for index, row in df_cards.iterrows():
    customer_num = int(row['Customer #'])
    card_number = str(row['CardNumber']).strip()

    # Map Excel card types to C# enum values
    card_type_raw = str(row['CardType']).strip()
    if card_type_raw.lower() == "mastercard":
        card_type = "MasterCard"
    elif card_type_raw.lower() == "american express":
        card_type = "AmericanExpress"
    else:
        card_type = card_type_raw  # Visa, Discover

    cs_cards += f"""            Cards.Add(new Card
            {{
                CardNumber = "{card_number}",
                CardType = CardTypeEnum.{card_type},
                CustomerID = "{customer_num}"  // Will be updated with actual UserID
            }});

"""

cs_cards += """            // Add cards and link to customers
            foreach (Card cardToAdd in Cards)
            {
                // Find customer by their customer number in email (e.g., "9010" in email)
                // This is a placeholder - you may need to adjust based on how you identify customers
                var customer = db.Users.FirstOrDefault(u => u.Email.Contains(cardToAdd.CustomerID));

                if (customer != null)
                {
                    cardToAdd.CustomerID = customer.Id;
                    db.Cards.Add(cardToAdd);
                }
            }

            db.SaveChanges();
        }
    }
}
"""

with open("Group13_Final_Project/Seeding/SeedCards.cs", 'w', encoding='utf-8') as f:
    f.write(cs_cards)
print(f"   ✓ Created SeedCards.cs ({len(df_cards)} cards)")

# ============================================================================
# 4. REVIEWS SEEDING
# ============================================================================
print("\n4. Generating SeedReviews.cs...")
df_reviews = pd.read_excel(excel_file, sheet_name='Reviews')
df_reviews = df_reviews.fillna('')

cs_reviews = """using Group13_Final_Project.DAL;
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

            List<(string ReviewerName, string BookTitle, int Rating, string ReviewText, string DisputeStatus)> ReviewData = new List<(string, string, int, string, string)>();

"""

for index, row in df_reviews.iterrows():
    reviewer_name = str(row['Reviewer']).strip().replace('"', '\\"')
    book_title = str(row['Book']).strip().replace('"', '\\"')
    rating = int(row['Rating']) if pd.notna(row['Rating']) else 0
    review_text = str(row['ReviewText']).strip().replace('"', '\\"') if pd.notna(row['ReviewText']) else ""
    dispute_status = str(row['DisputeStatus']).strip()

    cs_reviews += f"""            ReviewData.Add(("{reviewer_name}", "{book_title}", {rating}, "{review_text}", "{dispute_status}"));
"""

cs_reviews += """
            // Create reviews
            foreach (var data in ReviewData)
            {
                // Find reviewer by name
                var reviewer = db.Users.FirstOrDefault(u =>
                    (u.FirstName + " " + u.LastName) == data.Item1);

                // Find book by title
                var book = db.Books.FirstOrDefault(b => b.Title == data.Item2);

                if (reviewer != null && book != null)
                {
                    DisputeStatusEnum status;
                    switch (data.Item5.ToLower())
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
                        Rating = data.Item3,
                        ReviewText = data.Item4,
                        DisputeStatus = status
                    };

                    db.Reviews.Add(review);
                }
            }

            db.SaveChanges();
        }
    }
}
"""

with open("Group13_Final_Project/Seeding/SeedReviews.cs", 'w', encoding='utf-8') as f:
    f.write(cs_reviews)
print(f"   ✓ Created SeedReviews.cs ({len(df_reviews)} reviews)")

# ============================================================================
# 5. ORDERS AND ORDER DETAILS SEEDING
# ============================================================================
print("\n5. Generating SeedOrders.cs...")
df_orders = pd.read_excel(excel_file, sheet_name='Orders')
df_orders = df_orders.fillna('')

cs_orders = """using Group13_Final_Project.DAL;
using Group13_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Group13_Final_Project.Seeding
{
    public static class SeedOrders
    {
        public static void SeedAllOrders(UserManager<AppUser> userManager, AppDbContext db)
        {
            // Check if orders already seeded
            if (db.Orders.Any())
            {
                return;
            }

            // Group order items by OrderId
            List<(int OrderId, string CustomerName, DateTime OrderDate, decimal ShippingFee, string OrderStatus, List<(string BookTitle, decimal Price, decimal Cost, int Quantity)> Items)> OrderData = new List<(int, string, DateTime, decimal, string, List<(string, decimal, decimal, int)>)>();

"""

# Group orders by OrderId
order_groups = df_orders.groupby('OrderId')

for order_id, group in order_groups:
    first_row = group.iloc[0]
    customer_name = str(first_row['Customer']).strip().replace('"', '\\"')

    # Handle OrderDate - check for NaT (Not a Time)
    if pd.isna(first_row['OrderDate']):
        # Use a default date for orders with no date
        date_str = "new DateTime(2025, 1, 1)"
    else:
        order_date = pd.to_datetime(first_row['OrderDate'])
        date_str = f"new DateTime({order_date.year}, {order_date.month}, {order_date.day})"

    # Handle ShippingFee - check for empty string
    shipping_fee_val = str(first_row['ShippingFee']).strip()
    shipping_fee = float(shipping_fee_val) if shipping_fee_val and shipping_fee_val != '' and pd.notna(first_row['ShippingFee']) else 0.0

    order_status = str(first_row['OrderStatus']).strip()

    cs_orders += f"""            // Order {order_id}
            OrderData.Add(({order_id}, "{customer_name}", {date_str}, {shipping_fee}m, "{order_status}", new List<(string, decimal, decimal, int)>
            {{
"""

    for index, row in group.iterrows():
        book_title = str(row['Book']).strip().replace('"', '\\"')

        # Handle numeric fields - check for NaN BEFORE string conversion
        if pd.isna(row['Price']):
            price = 0.0
        else:
            price = float(row['Price'])

        if pd.isna(row['Cost']):
            cost = 0.0
        else:
            cost = float(row['Cost'])

        if pd.isna(row['Quantity']):
            quantity = 1
        else:
            quantity = int(float(row['Quantity']))

        cs_orders += f"""                ("{book_title}", {price}m, {cost}m, {quantity}),
"""

    cs_orders += """            }));

"""

cs_orders += """            // Create orders and order details
            foreach (var orderData in OrderData)
            {
                // Find customer by name
                var customer = db.Users.FirstOrDefault(u =>
                    (u.FirstName + " " + u.LastName) == orderData.Item2);

                if (customer != null)
                {
                    // Determine order status
                    OrderStatusEnum status;
                    switch (orderData.Item5.ToLower())
                    {
                        case "shipped":
                            status = OrderStatusEnum.Shipped;
                            break;
                        case "delivered":
                            status = OrderStatusEnum.Delivered;
                            break;
                        case "pending":
                            status = OrderStatusEnum.Pending;
                            break;
                        case "cancelled":
                            status = OrderStatusEnum.Cancelled;
                            break;
                        default:
                            status = OrderStatusEnum.Shipped;
                            break;
                    }

                    Order order = new Order
                    {
                        CustomerID = customer.Id,
                        OrderDate = orderData.Item3,
                        ShippingFee = orderData.Item4,
                        OrderStatus = status,
                        OrderDetails = new List<OrderDetail>()
                    };

                    // Add order details
                    foreach (var item in orderData.Item6)
                    {
                        var book = db.Books.FirstOrDefault(b => b.Title == item.Item1);
                        if (book != null)
                        {
                            OrderDetail detail = new OrderDetail
                            {
                                BookID = book.BookID,
                                Quantity = item.Item4,
                                Price = item.Item2,
                                Cost = item.Item3
                            };
                            order.OrderDetails.Add(detail);
                        }
                    }

                    db.Orders.Add(order);
                }
            }

            db.SaveChanges();
        }
    }
}
"""

with open("Group13_Final_Project/Seeding/SeedOrders.cs", 'w', encoding='utf-8') as f:
    f.write(cs_orders)
print(f"   ✓ Created SeedOrders.cs ({len(order_groups)} orders with {len(df_orders)} order details)")

print("\n" + "="*80)
print("✓ All seeding files generated successfully!")
print("\nNext steps:")
print("1. Update SeedController.cs to call all new seeding methods")
print("2. Run the seeding from /Seed/SeedAll")
