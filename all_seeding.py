import pandas as pd
from datetime import datetime
import os

# Read the Excel file - UPDATED to v3.1
excel_file = "Bevos Bookstore Data v3.1.xlsx"

print("Generating seeding files with UPSERT logic from v3.1...")
print("="*80)

# Create Seeding folder if it doesn't exist
os.makedirs("Group13_Final_Project/Seeding", exist_ok=True)

# Read all dataframes
df_customers = pd.read_excel(excel_file, sheet_name='Customers')
df_employees = pd.read_excel(excel_file, sheet_name='Employees')
df_books = pd.read_excel(excel_file, sheet_name='Books')
df_cards = pd.read_excel(excel_file, sheet_name='Cards')
df_reviews = pd.read_excel(excel_file, sheet_name='Reviews')
df_orders = pd.read_excel(excel_file, sheet_name='Orders')

# Create customer email lookup
customer_num_to_email = dict(zip(df_customers['Customer #'], df_customers['Email']))
customer_name_to_email = {}
for _, row in df_customers.iterrows():
    full_name = f"{row['First Name']} {row['Last Name']}"
    customer_name_to_email[full_name] = row['Email']

# ============================================================================
# 1. CUSTOMERS SEEDING - with CustomerNumber and Street
# ============================================================================
print("\n1. Generating SeedCustomers.cs...")

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
    email = str(row['Email']).strip() if pd.notna(row['Email']) else ""
    password = str(row['Password']).strip() if pd.notna(row['Password']) else "password"
    first_name = str(row['First Name']).strip() if pd.notna(row['First Name']) else ""
    last_name = str(row['Last Name']).strip() if pd.notna(row['Last Name']) else ""
    customer_num = int(row['Customer #']) if pd.notna(row['Customer #']) else 9000 + index
    street = str(row['Street']).strip().replace('"', '\\"') if pd.notna(row['Street']) else ""
    city = str(row['City']).strip() if pd.notna(row['City']) else "Austin"
    state = str(row['State']).strip() if pd.notna(row['State']) else "TX"
    zip_code = str(row['Zip']).strip() if pd.notna(row['Zip']) else "78701"
    phone = str(row['Phone']).strip() if pd.notna(row['Phone']) else ""

    cs_customers += f"""            Customers.Add(new AddUserModel
            {{
                User = new AppUser
                {{
                    UserName = "{email}",
                    Email = "{email}",
                    CustomerNumber = {customer_num},
                    FirstName = "{first_name}",
                    LastName = "{last_name}",
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
                    dbUser.CustomerNumber = customerToAdd.User.CustomerNumber;
                    dbUser.FirstName = customerToAdd.User.FirstName;
                    dbUser.LastName = customerToAdd.User.LastName;
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
# 2. EMPLOYEES SEEDING - with full Address
# ============================================================================
print("\n2. Generating SeedEmployees.cs...")

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
    email = str(row['Email']).strip() if pd.notna(row['Email']) else ""
    password = str(row['PSW']).strip() if pd.notna(row['PSW']) else "password"
    first_name = str(row['FirstName']).strip() if pd.notna(row['FirstName']) else ""
    last_name = str(row['LastName']).strip() if pd.notna(row['LastName']) else ""
    address = str(row['Address']).strip().replace('"', '\\"') if pd.notna(row['Address']) else ""
    city = str(row['City']).strip() if pd.notna(row['City']) else "Austin"
    state = str(row['State']).strip() if pd.notna(row['State']) else "TX"
    zip_code = str(row['Zip']).strip() if pd.notna(row['Zip']) else "78701"
    phone = str(row['Phone']).strip() if pd.notna(row['Phone']) else ""
    emp_type = str(row['EmpType']).strip() if pd.notna(row['EmpType']) else "Employee"

    # Determine role based on EmpType - Admin becomes Manager
    role = "Manager" if emp_type.lower() == "admin" else "Employee"

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
# 3. BOOKS SEEDING - with Cost, Reorder, Copies on Hand
# ============================================================================
print("\n3. Generating SeedBooks.cs...")

cs_books = """using Group13_Final_Project.DAL;
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
            // Check if books already seeded
            if (db.Books.Any())
            {
                return;
            }

            List<(int UniqueID, string Title, string Author, string Genre, string Description, decimal Price, decimal Cost, int Reorder, int Copies, DateTime PublishDate)> BookData = new List<(int, string, string, string, string, decimal, decimal, int, int, DateTime)>();

"""

for index, row in df_books.iterrows():
    unique_id = int(row['UniqueID']) if pd.notna(row['UniqueID']) else 222001 + index
    title = str(row['Title']).strip().replace('"', '\\"').replace("'", "\\'") if pd.notna(row['Title']) else ""
    author = str(row['Author']).strip().replace('"', '\\"') if pd.notna(row['Author']) else ""
    genre = str(row['Genre']).strip() if pd.notna(row['Genre']) else "Contemporary Fiction"
    description = str(row['Description']).strip().replace('"', '\\"').replace('\n', ' ').replace('\r', '') if pd.notna(row['Description']) else ""
    price = float(row['Price']) if pd.notna(row['Price']) else 0.0
    cost = float(row['Cost']) if pd.notna(row['Cost']) else 0.0
    reorder = int(row['Reorder']) if pd.notna(row['Reorder']) else 5
    copies = int(row['Copies on Hand']) if pd.notna(row['Copies on Hand']) else 0

    # Handle publish date
    if pd.notna(row['Published Date']):
        pub_date = pd.to_datetime(row['Published Date'])
        date_str = f"new DateTime({pub_date.year}, {pub_date.month}, {pub_date.day})"
    else:
        date_str = "new DateTime(2020, 1, 1)"

    cs_books += f"""            BookData.Add(({unique_id}, "{title}", "{author}", "{genre}", "{description}", {price}m, {cost}m, {reorder}, {copies}, {date_str}));
"""

cs_books += """
            // Create books
            foreach (var data in BookData)
            {
                var genre = db.Genres.FirstOrDefault(g => g.GenreName == data.Item4);
                if (genre != null)
                {
                    Book book = new Book
                    {
                        BookNumber = data.Item1,
                        Title = data.Item2,
                        Authors = data.Item3,
                        GenreID = genre.GenreID,
                        Description = data.Item5,
                        Price = data.Item6,
                        Cost = data.Item7,
                        ReorderPoint = data.Item8,
                        InventoryQuantity = data.Item9,
                        PublishDate = data.Item10,
                        BookStatus = BookStatusEnum.Active
                    };
                    db.Books.Add(book);
                }
            }

            db.SaveChanges();
        }
    }
}
"""

with open("Group13_Final_Project/Seeding/SeedBooks.cs", 'w', encoding='utf-8') as f:
    f.write(cs_books)
print(f"   ✓ Created SeedBooks.cs ({len(df_books)} books)")

# ============================================================================
# 4. CARDS SEEDING - using customer email mapping
# ============================================================================
print("\n4. Generating SeedCards.cs...")

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

            List<(string CustomerEmail, string CardNumber, CardTypeEnum CardType)> CardData = new List<(string, string, CardTypeEnum)>();

"""

for index, row in df_cards.iterrows():
    customer_num = int(row['Customer #']) if pd.notna(row['Customer #']) else 0
    card_number = str(row['CardNumber']).strip() if pd.notna(row['CardNumber']) else ""

    # Get customer email from mapping
    customer_email = str(customer_num_to_email.get(customer_num, "")).strip()

    # Map Excel card types to C# enum values
    card_type_raw = str(row['CardType']).strip() if pd.notna(row['CardType']) else "Visa"
    if card_type_raw.lower() == "mastercard":
        card_type = "MasterCard"
    elif card_type_raw.lower() == "american express":
        card_type = "AmericanExpress"
    else:
        card_type = card_type_raw  # Visa, Discover

    cs_cards += f"""            CardData.Add(("{customer_email}", "{card_number}", CardTypeEnum.{card_type}));
"""

cs_cards += """
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
"""

with open("Group13_Final_Project/Seeding/SeedCards.cs", 'w', encoding='utf-8') as f:
    f.write(cs_cards)
print(f"   ✓ Created SeedCards.cs ({len(df_cards)} cards)")

# ============================================================================
# 5. REVIEWS SEEDING - with Approver and DisputeStatus
# ============================================================================
print("\n5. Generating SeedReviews.cs...")

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

            List<(string ReviewerFirstName, string ReviewerLastName, string BookTitle, string ApproverFirstName, string ApproverLastName, int Rating, string ReviewText, string DisputeStatus)> ReviewData = new List<(string, string, string, string, string, int, string, string)>();

"""

for index, row in df_reviews.iterrows():
    reviewer_name = str(row['Reviewer']).strip() if pd.notna(row['Reviewer']) else ""
    book_title = str(row['Book']).strip().replace('"', '\\"') if pd.notna(row['Book']) else ""
    approver_name = str(row['Approver']).strip() if pd.notna(row['Approver']) else ""
    rating = int(row['Rating']) if pd.notna(row['Rating']) else 3
    review_text = str(row['ReviewText']).strip().replace('"', '\\"')[:100] if pd.notna(row['ReviewText']) else ""
    dispute_status = str(row['DisputeStatus']).strip() if pd.notna(row['DisputeStatus']) else "Pending"

    # Parse reviewer name
    reviewer_parts = reviewer_name.split()
    reviewer_first = reviewer_parts[0] if len(reviewer_parts) > 0 else ""
    reviewer_last = reviewer_parts[-1] if len(reviewer_parts) > 1 else ""

    # Parse approver name
    approver_parts = approver_name.split()
    approver_first = approver_parts[0] if len(approver_parts) > 0 else ""
    approver_last = approver_parts[-1] if len(approver_parts) > 1 else ""

    cs_reviews += f"""            ReviewData.Add(("{reviewer_first}", "{reviewer_last}", "{book_title}", "{approver_first}", "{approver_last}", {rating}, "{review_text}", "{dispute_status}"));
"""

cs_reviews += """
            // Create reviews
            foreach (var data in ReviewData)
            {
                // Find reviewer by name
                var reviewer = db.Users.FirstOrDefault(u =>
                    u.FirstName == data.Item1 && u.LastName == data.Item2);

                // Find book by title
                var book = db.Books.FirstOrDefault(b => b.Title == data.Item3);

                // Find approver by name (employee)
                AppUser approver = null;
                if (!string.IsNullOrEmpty(data.Item4))
                {
                    approver = db.Users.FirstOrDefault(u =>
                        u.FirstName == data.Item4 && u.LastName == data.Item5);
                }

                if (reviewer != null && book != null)
                {
                    DisputeStatusEnum status;
                    switch (data.Item8.ToLower())
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
                        Rating = data.Item6,
                        ReviewText = data.Item7,
                        DisputeStatus = status,
                        ApproverID = approver?.Id
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
# 6. ORDERS AND ORDER DETAILS SEEDING - with updated quantities
# ============================================================================
print("\n6. Generating SeedOrders.cs...")

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

"""

# Group orders by OrderId
order_groups = df_orders.groupby('OrderId')

for order_id, group in order_groups:
    first_row = group.iloc[0]
    customer_name = str(first_row['Customer']).strip() if pd.notna(first_row['Customer']) else ""
    customer_email = customer_name_to_email.get(customer_name, "")

    # Handle OrderDate
    if pd.isna(first_row['OrderDate']):
        date_str = "DateTime.Now"
    else:
        order_date = pd.to_datetime(first_row['OrderDate'])
        date_str = f"new DateTime({order_date.year}, {order_date.month}, {order_date.day})"

    # Handle ShippingFee
    shipping_fee = float(first_row['ShippingFee']) if pd.notna(first_row['ShippingFee']) else 0.0

    order_status = str(first_row['OrderStatus']).strip() if pd.notna(first_row['OrderStatus']) else "Pending"

    # Map status
    if order_status.lower() == "incart":
        status_enum = "OrderStatusEnum.Pending"
    elif order_status.lower() == "shipped":
        status_enum = "OrderStatusEnum.Shipped"
    elif order_status.lower() == "delivered":
        status_enum = "OrderStatusEnum.Delivered"
    elif order_status.lower() == "cancelled":
        status_enum = "OrderStatusEnum.Cancelled"
    else:
        status_enum = "OrderStatusEnum.Pending"

    cs_orders += f"""            // Order {order_id}
            var customer{order_id} = db.Users.FirstOrDefault(u => u.Email == "{customer_email}");
            if (customer{order_id} != null)
            {{
                Order order{order_id} = new Order
                {{
                    OrderNumber = {int(order_id)},
                    CustomerID = customer{order_id}.Id,
                    OrderDate = {date_str},
                    ShippingFee = {shipping_fee}m,
                    OrderStatus = {status_enum},
                    OrderDetails = new List<OrderDetail>()
                }};

"""

    # Add order details
    for idx, detail_row in group.iterrows():
        book_title = str(detail_row['Book']).strip().replace('"', '\\"') if pd.notna(detail_row['Book']) else ""
        price = float(detail_row['Price']) if pd.notna(detail_row['Price']) else 0.0
        cost = float(detail_row['Cost']) if pd.notna(detail_row['Cost']) else 0.0
        quantity = int(detail_row['Quantity']) if pd.notna(detail_row['Quantity']) else 1

        cs_orders += f"""                var book{order_id}_{idx} = db.Books.FirstOrDefault(b => b.Title == "{book_title}");
                if (book{order_id}_{idx} != null)
                {{
                    order{order_id}.OrderDetails.Add(new OrderDetail
                    {{
                        BookID = book{order_id}_{idx}.BookID,
                        Quantity = {quantity},
                        Price = {price}m,
                        Cost = {cost}m
                    }});
                }}

"""

    cs_orders += f"""                db.Orders.Add(order{order_id});
            }}

"""

cs_orders += """            db.SaveChanges();
        }
    }
}
"""

with open("Group13_Final_Project/Seeding/SeedOrders.cs", 'w', encoding='utf-8') as f:
    f.write(cs_orders)
print(f"   ✓ Created SeedOrders.cs ({len(order_groups)} orders with {len(df_orders)} order details)")

print("\n" + "="*80)
print("✓ All seeding files generated successfully from v3.1!")
print(f"\nSummary:")
print(f"   - Customers: {len(df_customers)} (with CustomerNumber and Street)")
print(f"   - Employees: {len(df_employees)} (with full Address)")
print(f"   - Books: {len(df_books)} (with Cost, Reorder, Copies)")
print(f"   - Cards: {len(df_cards)}")
print(f"   - Reviews: {len(df_reviews)} (with Approver and DisputeStatus)")
print(f"   - Orders: {len(order_groups)} orders")
