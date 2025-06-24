using Mare_POS.Authentication;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

public class DatabaseSeeder
{
    private string connectionString;

    public DatabaseSeeder()
    {
        this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }

    private AuthService authService;

    public void SeedDatabase()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // Check if database has already been seeded
            if (IsDatabaseSeeded(connection))
            {
                Console.WriteLine("Database has already been seeded. Skipping seeding process.");
                return;
            }

            // Clear existing data (optional - uncomment if you want to reset)
            // ClearTables(connection);

            SeedEmployees(connection);
            SeedInventory(connection);
            SeedExpenses(connection);
            SeedProducts(connection);

            Console.WriteLine("Database seeding completed successfully!");
        }
    }

    private bool IsDatabaseSeeded(MySqlConnection connection)
    {
        // Check if any employees exist (you can check any table)
        string checkQuery = "SELECT COUNT(*) FROM employees";
        using (MySqlCommand cmd = new MySqlCommand(checkQuery, connection))
        {
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    private void SeedProducts(MySqlConnection connection)
    {
        string productQuery = @"
        INSERT INTO product (ProductName, UnitPrice, SellingPrice)
        VALUES (@ProductName, @UnitPrice, @SellingPrice)";

        var products = new[]
        {
        // Coffee - Hot & Iced
        new { Name = "Americano", UnitPrice = 25.00m, SellingPrice = 75.00m },
        new { Name = "Cafe Latte", UnitPrice = 35.00m, SellingPrice = 95.00m },
        new { Name = "Caramel Macchiato", UnitPrice = 45.00m, SellingPrice = 110.00m },
        new { Name = "Mocha", UnitPrice = 45.00m, SellingPrice = 110.00m },
        new { Name = "Cappuccino", UnitPrice = 35.00m, SellingPrice = 95.00m },

        // Non-Coffee - Hot & Iced
        new { Name = "Matcha Latte", UnitPrice = 40.00m, SellingPrice = 105.00m },
        new { Name = "Chocolate", UnitPrice = 35.00m, SellingPrice = 100.00m },
        new { Name = "Strawberry Frappe", UnitPrice = 50.00m, SellingPrice = 120.00m },
        new { Name = "Caramel Frappe", UnitPrice = 50.00m, SellingPrice = 120.00m },
        new { Name = "Chocolate Chip Frappe", UnitPrice = 55.00m, SellingPrice = 125.00m },

        // Food
        new { Name = "Tosilog", UnitPrice = 35.00m, SellingPrice = 90.00m },
        new { Name = "Garlic Rice", UnitPrice = 10.00m, SellingPrice = 25.00m },
        new { Name = "Pork Siomai Rice", UnitPrice = 25.00m, SellingPrice = 70.00m },
        new { Name = "Beef Pares", UnitPrice = 40.00m, SellingPrice = 95.00m }
    };

        foreach (var product in products)
        {
            using (MySqlCommand cmd = new MySqlCommand(productQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ProductName", product.Name);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                cmd.ExecuteNonQuery();
            }
        }

    }

    private void SeedEmployees(MySqlConnection connection)
    {
        string employeeQuery = @"
        INSERT INTO employees (LastName, FirstName, MiddleName, Role, Password, Username, OwnerID)
        VALUES (@LastName, @FirstName, @MiddleName, @Role, @Password, @Username, @OwnerID)";

        int ownerId;

        // Insert Admin (E-jay P. Detera)
        using (MySqlCommand cmd = new MySqlCommand(employeeQuery, connection))
        {
            cmd.Parameters.AddWithValue("@LastName", "Detera");
            cmd.Parameters.AddWithValue("@FirstName", "E-jay");
            cmd.Parameters.AddWithValue("@MiddleName", "P.");
            cmd.Parameters.AddWithValue("@Role", "Admin");
            cmd.Parameters.AddWithValue("@Password", HashPassword("admin123"));
            cmd.Parameters.AddWithValue("@Username", "ejay.detera");
            cmd.Parameters.AddWithValue("@OwnerID", null);
            cmd.ExecuteNonQuery();
        }

        // Get OwnerID
        using (MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", connection))
        {
            ownerId = Convert.ToInt32(cmd.ExecuteScalar());
        }

        // List of employees
        var employees = new[]
        {
        new { First = "Aliah", Middle = "IDK", Last = "Del Rosario", Username = "aya.delrosario" },
        new { First = "Rheana", Middle = "IDK", Last = "Aquino", Username = "rheana.aquino" },
        new { First = "Angela", Middle = "IDK", Last = "Raquedan", Username = "angela.raquedan" },
        new { First = "Liberty", Middle = "IDK", Last = "Canares", Username = "liberty.canares" },
        new { First = "Iyah", Middle = "IDK", Last = "Puso", Username = "iyah.puso" },
    };

        foreach (var emp in employees)
        {
            using (MySqlCommand cmd = new MySqlCommand(employeeQuery, connection))
            {
                cmd.Parameters.AddWithValue("@LastName", emp.Last);
                cmd.Parameters.AddWithValue("@FirstName", emp.First);
                cmd.Parameters.AddWithValue("@MiddleName", emp.Middle);
                cmd.Parameters.AddWithValue("@Role", "Employee");
                cmd.Parameters.AddWithValue("@Password", HashPassword("employee123"));
                cmd.Parameters.AddWithValue("@Username", emp.Username);
                cmd.Parameters.AddWithValue("@OwnerID", null);
                cmd.ExecuteNonQuery();
            }
        }
    }


    private void SeedInventory(MySqlConnection connection)
    {
        string inventoryQuery = @"
            INSERT INTO inventory (IngredientName, Quantity, IngredientCost, IngredientMeasurement)
            VALUES (@IngredientName, @Quantity, @IngredientCost, @IngredientMeasurement)";

        // Coffee shop inventory items
        var inventoryItems = new[]
        {
        // Coffee Ingredients
        new { Name = "Coffee Beans", Quantity = 1000m, Cost = 800.00m, Measurement = "grams" },
        new { Name = "Water", Quantity = 5000m, Cost = 50.00m, Measurement = "ml" },
        new { Name = "Milk", Quantity = 3000m, Cost = 250.00m, Measurement = "ml" },
        new { Name = "Caramel Syrup", Quantity = 1000m, Cost = 120.00m, Measurement = "ml" },
        new { Name = "Chocolate Sauce", Quantity = 1000m, Cost = 150.00m, Measurement = "ml" },
        new { Name = "Ice", Quantity = 2000m, Cost = 30.00m, Measurement = "oz" },

        // Non-Coffee Ingredients
        new { Name = "Matcha Powder", Quantity = 500m, Cost = 400.00m, Measurement = "grams" },
        new { Name = "Strawberry Jam", Quantity = 800m, Cost = 100.00m, Measurement = "ml" },
        new { Name = "Sweetener", Quantity = 500m, Cost = 80.00m, Measurement = "ml" },
        new { Name = "Chocolate Syrup", Quantity = 1000m, Cost = 150.00m, Measurement = "ml" },
        new { Name = "Chocolate Chip", Quantity = 500m, Cost = 200.00m, Measurement = "grams" },
        new { Name = "Whipped Cream", Quantity = 1000m, Cost = 180.00m, Measurement = "ml" },

        // Food Ingredients
        new { Name = "Tocino", Quantity = 1000m, Cost = 300.00m, Measurement = "grams" },
        new { Name = "Cooking Oil", Quantity = 1000m, Cost = 90.00m, Measurement = "ml" },
        new { Name = "Rice", Quantity = 10000m, Cost = 500.00m, Measurement = "grams" },
        new { Name = "Egg", Quantity = 100m, Cost = 120.00m, Measurement = "pcs" },
        new { Name = "Garlic Clove", Quantity = 100m, Cost = 60.00m, Measurement = "pcs" },
        new { Name = "Pork Siomai", Quantity = 100m, Cost = 300.00m, Measurement = "pcs" }
        };

        foreach (var item in inventoryItems)
        {
            using (MySqlCommand cmd = new MySqlCommand(inventoryQuery, connection))
            {
                cmd.Parameters.AddWithValue("@IngredientName", item.Name);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@IngredientCost", item.Cost);
                cmd.Parameters.AddWithValue("@IngredientMeasurement", item.Measurement);
                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Inventory seeded successfully!");
    }

    private void SeedExpenses(MySqlConnection connection)
    {
        string expenseQuery = @"
            INSERT INTO expense (ExpenseName, ExpenseAmount, Category, Date)
            VALUES (@ExpenseName, @ExpenseAmount, @Category, @Date)";

        DateTime today = DateTime.Today;

        // Coffee shop expenses
        var expenses = new[]
        {
            new { Name = "Internet Service", Amount = 89.99m, Category = "Non-Cash" },
            new { Name = "Coffee Bean Supplier", Amount = 450.75m, Category = "Cash" },
            new { Name = "Milk & Dairy Products", Amount = 125.80m, Category = "Non-Cash" },
            new { Name = "Disposable Cups & Supplies", Amount = 89.45m, Category = "Cash" },
            new { Name = "Cleaning Supplies", Amount = 45.60m, Category = "Non-Cash" },
            new { Name = "Equipment Maintenance", Amount = 150.00m, Category = "Cash" },
            new { Name = "Business Insurance", Amount = 275.00m, Category = "Non-Cash" },
            new { Name = "Pastry Supplier", Amount = 180.25m, Category = "Cash" }
        };

        foreach (var expense in expenses)
        {
            using (MySqlCommand cmd = new MySqlCommand(expenseQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ExpenseName", expense.Name);
                cmd.Parameters.AddWithValue("@ExpenseAmount", expense.Amount);
                cmd.Parameters.AddWithValue("@Category", expense.Category);
                cmd.Parameters.AddWithValue("@Date", today);
                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Expenses seeded successfully!");
    }
}