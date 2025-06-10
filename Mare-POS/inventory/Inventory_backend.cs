using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Mare_POS
{
    public class Inventory_backend
    {
        private readonly string connectionString;
        public class DatabaseSetup
        {
            private readonly string serverConnectionString;
            private readonly string databaseConnectionString;

            public DatabaseSetup()
            {
                // Connection string without database specified (for creating database)
                serverConnectionString = "server=localhost;uid=root;pwd=ejaydetera12;";
                // Connection string with database specified (for creating tables)
                databaseConnectionString = "server=localhost;uid=root;pwd=ejaydetera12;database=marepos-db;";
            }

            public void InitializeDatabase()
            {
                try
                {
                    CreateDatabaseIfNotExists();
                    CreateInventoryTableIfNotExists();
                    Console.WriteLine("Database and table initialization completed successfully.");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Database initialization failed: {ex.Message}");
                }
            }

            private void CreateDatabaseIfNotExists()
            {
                using (MySqlConnection connection = new MySqlConnection(serverConnectionString))
                {
                    try
                    {
                        connection.Open();

                        string createDatabaseQuery = @"
                        CREATE DATABASE IF NOT EXISTS `marepos-db` 
                        CHARACTER SET utf8mb4 
                        COLLATE utf8mb4_unicode_ci;";

                        using (MySqlCommand command = new MySqlCommand(createDatabaseQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Database 'marepos-db' created or already exists.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception($"Error creating database: {ex.Message}");
                    }
                }
            }

            private void CreateInventoryTableIfNotExists()
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
                {
                    try
                    {
                        connection.Open();

                        string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS `inventory` (
                            `InventoryID` INT AUTO_INCREMENT PRIMARY KEY,
                            `IngredientName` VARCHAR(255) NOT NULL,
                            `Quantity` Decimal(10,2) NOT NULL DEFAULT 0,
                            `IngredientCost` DECIMAL(10,2) NOT NULL DEFAULT 0,
                            `IngredientMeasurement` VARCHAR(5) NOT NULL,
                            `DateAdded` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            `LastUpdated` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            INDEX `idx_ingredient_name` (`IngredientName`)
                        ) ENGINE=InnoDB;";

                        using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Inventory table created or already exists.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception($"Error creating inventory table: {ex.Message}");
                    }
                }
            }


            public void CreateIngredientUsageLogTable()
            {
                using (MySqlConnection connection = new MySqlConnection(databaseConnectionString))
                {
                    try
                    {
                        connection.Open();

                        string createLogTableQuery = @"
                        CREATE TABLE IF NOT EXISTS `ingredient_usage_log` (
                            `LogID` INT AUTO_INCREMENT PRIMARY KEY,
                            `ingredient_id` INT NOT NULL,
                            `quantity_used` DECIMAL(10,2) NOT NULL,
                            `reason` VARCHAR(255),
                            `date_used` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (`ingredient_id`) REFERENCES `inventory`(`InventoryID`) ON DELETE CASCADE
                        ) ENGINE=InnoDB;";

                        using (MySqlCommand command = new MySqlCommand(createLogTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Ingredient usage log table created or already exists.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception($"Error creating ingredient usage log table: {ex.Message}");
                    }
                }
            }

            // Method to initialize everything including the log table
            public void InitializeCompleteDatabase()
            {
                try
                {
                    CreateDatabaseIfNotExists();
                    CreateInventoryTableIfNotExists();
                    CreateIngredientUsageLogTable();
                    Console.WriteLine("Complete database initialization completed successfully.");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Complete database initialization failed: {ex.Message}");
                }
            }
        }

        public Inventory_backend()
        {
            connectionString = "server=localhost;uid=root;pwd=ejaydetera12;database=marepos-db;";
        }

        public void AddIngredientToInventory(string ingredientName, decimal quantity, string measurement, decimal cost)
        {
            // Round to 2 decimal places before inserting
            quantity = Math.Round(quantity, 2);
            cost = Math.Round(cost, 2);

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO inventory (IngredientName, Quantity, IngredientMeasurement, IngredientCost) VALUES (@IngredientName, @Quantity, @IngredientMeasurement, @IngredientCost)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@IngredientMeasurement", measurement);
                        cmd.Parameters.AddWithValue("@IngredientCost", cost);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("No rows were inserted. Please check your database connection and table structure.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error: {ex.Message}");
                }
            }
        }

        public DataTable GetInventoryData()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM inventory";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error: {ex.Message}");
                }
            }
        }

        public bool UpdateInventoryItem(int id, string ingredientName, decimal quantity, string measurement)
        {
            // Round to 2 decimal places
            quantity = Math.Round(quantity, 2);

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE inventory SET IngredientName = @IngredientName, Quantity = @Quantity, IngredientMeasurement = @IngredientMeasurement WHERE InventoryID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@IngredientMeasurement", measurement);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
            }
        }

        // Fixed DeleteInventoryItem method
        public bool DeleteInventoryItem(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM inventory WHERE InventoryID = @id"; // Changed from 'id' to 'InventoryID'

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
            }
        }
        public void UpdateIngredientQuantity(int ingredientId, decimal quantityToAdd)
        {
            // Round to 2 decimal places
            quantityToAdd = Math.Round(quantityToAdd, 2);

            string query = "UPDATE inventory SET Quantity = ROUND(Quantity + @quantityToAdd, 2) WHERE InventoryID = @ingredientId";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quantityToAdd", quantityToAdd);
                    command.Parameters.AddWithValue("@ingredientId", ingredientId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeductIngredientQuantity(int ingredientId, decimal quantityToDeduct, string reason)
        {
            // Round to 2 decimal places
            quantityToDeduct = Math.Round(quantityToDeduct, 2);

            string updateQuery = "UPDATE inventory SET Quantity = ROUND(Quantity - @quantityToDeduct, 2) WHERE InventoryID = @ingredientId";
            string logQuery = "INSERT INTO ingredient_usage_log (ingredient_id, quantity_used, reason, date_used) VALUES (@ingredientId, @quantityUsed, @reason, @dateUsed)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Update inventory
                        using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@quantityToDeduct", quantityToDeduct);
                            updateCommand.Parameters.AddWithValue("@ingredientId", ingredientId);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Log the usage
                        using (MySqlCommand logCommand = new MySqlCommand(logQuery, connection, transaction))
                        {
                            logCommand.Parameters.AddWithValue("@ingredientId", ingredientId);
                            logCommand.Parameters.AddWithValue("@quantityUsed", quantityToDeduct);
                            logCommand.Parameters.AddWithValue("@reason", reason);
                            logCommand.Parameters.AddWithValue("@dateUsed", DateTime.Now);
                            logCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public bool AddQuantityToInventoryItem(int inventoryId, decimal quantityToAdd)
        {
            try
            {
                // Round to 2 decimal places
                quantityToAdd = Math.Round(quantityToAdd, 2);

                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // First, get the current quantity
                    string selectQuery = "SELECT Quantity FROM inventory WHERE InventoryID = @inventoryId";
                    decimal currentQuantity = 0;

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
                    {
                        selectCmd.Parameters.AddWithValue("@inventoryId", inventoryId);
                        object result = selectCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            currentQuantity = Convert.ToDecimal(result);
                        }
                        else
                        {
                            // Inventory item not found
                            return false;
                        }
                    }

                    // Calculate the new quantity and round it
                    decimal newQuantity = Math.Round(currentQuantity + quantityToAdd, 2);

                    // Update the inventory with the new quantity
                    string updateQuery = "UPDATE inventory SET Quantity = @newQuantity WHERE InventoryID = @inventoryId";

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                        updateCmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding quantity to inventory: {ex.Message}");
                return false;
            }
        }
        private MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;uid=root;pwd=ejaydetera12;database=marepos-db;";
            return new MySqlConnection(connectionString);
        }
    }
}