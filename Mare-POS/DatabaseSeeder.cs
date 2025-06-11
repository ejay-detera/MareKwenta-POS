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

    private void SeedEmployees(MySqlConnection connection)
    {
        // Admin/Owner
        string employeeQuery = @"
            INSERT INTO employees (LastName, FirstName, MiddleName, Role, Password, Username, OwnerID, TimeIn, TimeOut)
            VALUES (@LastName, @FirstName, @MiddleName, @Role, @Password, @Username, @OwnerID, @TimeIn, @TimeOut)";

        using (MySqlCommand cmd = new MySqlCommand(employeeQuery, connection))
        {
            cmd.Parameters.AddWithValue("@LastName", "Johnson");
            cmd.Parameters.AddWithValue("@FirstName", "Sarah");
            cmd.Parameters.AddWithValue("@MiddleName", "Marie");
            cmd.Parameters.AddWithValue("@Role", "Admin");
            cmd.Parameters.AddWithValue("@Password", HashPassword("admin123"));
            cmd.Parameters.AddWithValue("@Username", "sarah.johnson");
            cmd.Parameters.AddWithValue("@OwnerID", null);
            cmd.Parameters.AddWithValue("@TimeIn", null);
            cmd.Parameters.AddWithValue("@TimeOut", null);
            cmd.ExecuteNonQuery();
        }

        // Get the actual OwnerID that was just inserted
        string getOwnerIdQuery = "SELECT LAST_INSERT_ID()";
        int ownerId;
        using (MySqlCommand cmd = new MySqlCommand(getOwnerIdQuery, connection))
        {
            ownerId = Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Employee 1
        using (MySqlCommand cmd = new MySqlCommand(employeeQuery, connection))
        {
            cmd.Parameters.AddWithValue("@LastName", "Rodriguez");
            cmd.Parameters.AddWithValue("@FirstName", "Miguel");
            cmd.Parameters.AddWithValue("@MiddleName", "Antonio");
            cmd.Parameters.AddWithValue("@Role", "Employee");
            cmd.Parameters.AddWithValue("@Password", HashPassword("employee123"));
            cmd.Parameters.AddWithValue("@Username", "miguel.rodriguez");
            cmd.Parameters.AddWithValue("@OwnerID", ownerId);
            cmd.Parameters.AddWithValue("@TimeIn", null);
            cmd.Parameters.AddWithValue("@TimeOut", null);
            cmd.ExecuteNonQuery();
        }

        // Employee 2
        using (MySqlCommand cmd = new MySqlCommand(employeeQuery, connection))
        {
            cmd.Parameters.AddWithValue("@LastName", "Chen");
            cmd.Parameters.AddWithValue("@FirstName", "Li");
            cmd.Parameters.AddWithValue("@MiddleName", "Wei");
            cmd.Parameters.AddWithValue("@Role", "Employee");
            cmd.Parameters.AddWithValue("@Password", HashPassword("employee123"));
            cmd.Parameters.AddWithValue("@Username", "li.chen");
            cmd.Parameters.AddWithValue("@OwnerID", ownerId);
            cmd.Parameters.AddWithValue("@TimeIn", null);
            cmd.Parameters.AddWithValue("@TimeOut", null);
            cmd.ExecuteNonQuery();
        }

        // Employee 3
        using (MySqlCommand cmd = new MySqlCommand(employeeQuery, connection))
        {
            cmd.Parameters.AddWithValue("@LastName", "Williams");
            cmd.Parameters.AddWithValue("@FirstName", "Emma");
            cmd.Parameters.AddWithValue("@MiddleName", "Grace");
            cmd.Parameters.AddWithValue("@Role", "Employee");
            cmd.Parameters.AddWithValue("@Password", HashPassword("employee123"));
            cmd.Parameters.AddWithValue("@Username", "emma.williams");
            cmd.Parameters.AddWithValue("@OwnerID", ownerId);
            cmd.Parameters.AddWithValue("@TimeIn", null);
            cmd.Parameters.AddWithValue("@TimeOut", null);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Employees seeded successfully!");
    }

    private void SeedInventory(MySqlConnection connection)
    {
        string inventoryQuery = @"
            INSERT INTO inventory (IngredientName, Quantity, IngredientCost, IngredientMeasurement)
            VALUES (@IngredientName, @Quantity, @IngredientCost, @IngredientMeasurement)";

        // Coffee shop inventory items
        var inventoryItems = new[]
        {
            new { Name = "Arabica Coffee Beans", Quantity = 25.50m, Cost = 12.99m, Measurement = "grams" },
            new { Name = "Robusta Coffee Beans", Quantity = 15.75m, Cost = 8.99m, Measurement = "grams" },
            new { Name = "Whole Milk", Quantity = 20.00m, Cost = 3.49m, Measurement = "ml" },
            new { Name = "Oat Milk", Quantity = 12.50m, Cost = 4.99m, Measurement = "ml" },
            new { Name = "Almond Milk", Quantity = 8.25m, Cost = 4.79m, Measurement = "ml" },
            new { Name = "Heavy Cream", Quantity = 6.00m, Cost = 5.99m, Measurement = "ml" },
            new { Name = "Vanilla Syrup", Quantity = 4.50m, Cost = 8.99m, Measurement = "oz" },
            new { Name = "Caramel Syrup", Quantity = 3.75m, Cost = 8.99m, Measurement = "oz" },
            new { Name = "Hazelnut Syrup", Quantity = 2.25m, Cost = 8.99m, Measurement = "oz" },
            new { Name = "Sugar", Quantity = 10.00m, Cost = 2.99m, Measurement = "grams" },
            new { Name = "Brown Sugar", Quantity = 5.50m, Cost = 3.49m, Measurement = "grams" },
            new { Name = "Artificial Sweetener", Quantity = 200.00m, Cost = 12.99m, Measurement = "oz" },
            new { Name = "Paper Cups 12oz", Quantity = 500.00m, Cost = 45.99m, Measurement = "pcs" },
            new { Name = "Paper Cups 16oz", Quantity = 400.00m, Cost = 52.99m, Measurement = "pcs" },
            new { Name = "Coffee Lids", Quantity = 1000.00m, Cost = 25.99m, Measurement = "pcs" },
            new { Name = "Napkins", Quantity = 2000.00m, Cost = 15.99m, Measurement = "pcs" },
            new { Name = "Stirrers", Quantity = 1500.00m, Cost = 8.99m, Measurement = "pcs" },
            new { Name = "Croissants", Quantity = 24.00m, Cost = 18.99m, Measurement = "pcs" },
            new { Name = "Muffins", Quantity = 18.00m, Cost = 22.50m, Measurement = "pcs" },
            new { Name = "Bagels", Quantity = 30.00m, Cost = 15.99m, Measurement = "pcs" }
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
            new { Name = "Monthly Rent", Amount = 2500.00m, Category = "Rent" },
            new { Name = "Electricity Bill", Amount = 185.50m, Category = "Utilities" },
            new { Name = "Water Bill", Amount = 75.25m, Category = "Utilities" },
            new { Name = "Internet Service", Amount = 89.99m, Category = "Utilities" },
            new { Name = "Coffee Bean Supplier", Amount = 450.75m, Category = "Inventory" },
            new { Name = "Milk & Dairy Products", Amount = 125.80m, Category = "Inventory" },
            new { Name = "Disposable Cups & Supplies", Amount = 89.45m, Category = "Supplies" },
            new { Name = "Cleaning Supplies", Amount = 45.60m, Category = "Supplies" },
            new { Name = "Equipment Maintenance", Amount = 150.00m, Category = "Maintenance" },
            new { Name = "Business Insurance", Amount = 275.00m, Category = "Insurance" },
            new { Name = "Marketing & Advertising", Amount = 125.00m, Category = "Marketing" },
            new { Name = "Staff Training", Amount = 200.00m, Category = "Training" },
            new { Name = "Point of Sale System", Amount = 49.99m, Category = "Software" },
            new { Name = "Business License Renewal", Amount = 85.00m, Category = "Legal" },
            new { Name = "Pastry Supplier", Amount = 180.25m, Category = "Inventory" }
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