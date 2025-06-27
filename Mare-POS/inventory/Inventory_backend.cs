using CuoreUI;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using static Mare_POS.inventory.LinkIngredients;

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

                serverConnectionString = "server=localhost;uid=root;pwd=ejaydetera12;";
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
                            `isDeleted` BOOLEAN NOT NULL DEFAULT FALSE,
                            `DateAdded` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            `LastUpdated` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            INDEX `idx_ingredient_name` (`IngredientName`),
                            INDEX `idx_is_deleted` (`isDeleted`)
                        ) ENGINE=InnoDB;";

                        using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Inventory table created or already exists.");
                        }

                        // Check if isDeleted column exists, if not add it (for existing databases)
                        string checkColumnQuery = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_SCHEMA = 'marepos-db' 
                        AND TABLE_NAME = 'inventory' 
                        AND COLUMN_NAME = 'isDeleted'";

                        using (MySqlCommand checkCmd = new MySqlCommand(checkColumnQuery, connection))
                        {
                            int columnExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (columnExists == 0)
                            {
                                string addColumnQuery = @"
                                ALTER TABLE `inventory` 
                                ADD COLUMN `isDeleted` BOOLEAN NOT NULL DEFAULT FALSE,
                                ADD INDEX `idx_is_deleted` (`isDeleted`)";

                                using (MySqlCommand addCmd = new MySqlCommand(addColumnQuery, connection))
                                {
                                    addCmd.ExecuteNonQuery();
                                    Console.WriteLine("isDeleted column added to inventory table.");
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception($"Error creating inventory table: {ex.Message}");
                    }
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

                    string query = "INSERT INTO inventory (IngredientName, Quantity, IngredientMeasurement, IngredientCost, isDeleted) VALUES (@IngredientName, @Quantity, @IngredientMeasurement, @IngredientCost, FALSE)";

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

        public void CheckLowInventory()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT IngredientName, Quantity FROM inventory WHERE Quantity < 10 AND (isDeleted IS NULL OR isDeleted = 0)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ingredientName = reader["IngredientName"].ToString();
                            decimal quantity = Convert.ToDecimal(reader["Quantity"]);
                            // Display or log the low inventory item
                            MessageBox.Show($"Low inventory alert: {ingredientName} - Quantity: {quantity}", "Low Inventory Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string query = "SELECT * FROM inventory WHERE (isDeleted IS NULL OR isDeleted = 0)";
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

        public List<string> GetIngredientNamesForDropDown()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT IngredientName FROM inventory WHERE (isDeleted IS NULL OR isDeleted = 0) ORDER BY IngredientName";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<string> ingredientNames = new List<string>();
                    while (reader.Read())
                    {
                        ingredientNames.Add(reader["IngredientName"].ToString());
                    }
                    return ingredientNames;
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

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE inventory SET IngredientName = @IngredientName, Quantity = @Quantity, IngredientMeasurement = @IngredientMeasurement WHERE InventoryID = @id AND (isDeleted IS NULL OR isDeleted = 0)";

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

        public bool DeleteInventoryItem(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Start a transaction to keep things safe
                    using (MySqlTransaction transaction = con.BeginTransaction())
                    {

                        string deleteProductIngredientQuery = "DELETE FROM productingredient WHERE InventoryID = @id";
                        using (MySqlCommand cmd1 = new MySqlCommand(deleteProductIngredientQuery, con, transaction))
                        {
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.ExecuteNonQuery();
                        }

                        // Soft delete from inventory - set isDeleted = TRUE
                        string softDeleteInventoryQuery = "UPDATE inventory SET isDeleted = TRUE WHERE InventoryID = @id";
                        using (MySqlCommand cmd2 = new MySqlCommand(softDeleteInventoryQuery, con, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@id", id);
                            int rowsAffected = cmd2.ExecuteNonQuery();

                            // Commit the transaction if successful
                            transaction.Commit();
                            return rowsAffected > 0;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
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

                    // First, get the current quantity (only from non-deleted items)
                    string selectQuery = "SELECT Quantity FROM inventory WHERE InventoryID = @inventoryId AND (isDeleted IS NULL OR isDeleted = 0)";
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
                            // Inventory item not found or is deleted
                            return false;
                        }
                    }

                    // Calculate the new quantity and round it
                    decimal newQuantity = Math.Round(currentQuantity + quantityToAdd, 2);

                    // Update the inventory with the new quantity (only non-deleted items)
                    string updateQuery = "UPDATE inventory SET Quantity = @newQuantity WHERE InventoryID = @inventoryId AND (isDeleted IS NULL OR isDeleted = 0)";

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

        public bool InsertIngredientsToDatabase(List<IngredientData> ingredients)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (IngredientData ingredient in ingredients)
                            {
                                // Get ProductID based on product name and category
                                int productId = GetProductNameByID(ingredient.ProductName, ingredient.Category, connection, transaction);

                                // Get InventoryID based on ingredient name (only non-deleted items)
                                int inventoryId = GetInventoryIdByIngredientName(ingredient.IngredientName, connection, transaction);

                                if (productId > 0 && inventoryId > 0)
                                {
                                    // Insert into productingredient table with category
                                    string insertQuery = @"
                               INSERT INTO productingredient (ProductID, InventoryID, Quantity, Category) 
                               VALUES (@productID, @inventoryID, @quantity, @category)";

                                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@productID", productId);
                                        cmd.Parameters.AddWithValue("@inventoryID", inventoryId);
                                        cmd.Parameters.AddWithValue("@quantity", ingredient.Quantity);
                                        cmd.Parameters.AddWithValue("@category", ingredient.Category);

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    throw new Exception($"Could not find ProductID or InventoryID for: {ingredient.ProductName} - {ingredient.IngredientName} in category {ingredient.Category}");
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int GetProductNameByID(string productName, string category, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "SELECT ProductID FROM product WHERE ProductName = @productName";

            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@category", category);
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int productId))
                {
                    return productId;
                }
            }

            return 0;
        }

        public int GetInventoryIdByIngredientName(string ingredientName, MySqlConnection connection, MySqlTransaction transaction)
        {
            // Only get non-deleted inventory items
            string query = "SELECT InventoryID FROM inventory WHERE IngredientName = @ingredientName AND (isDeleted IS NULL OR isDeleted = 0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inventoryId))
                {
                    return inventoryId;
                }
            }

            return 0;
        }

        public List<IngredientData> GetExistingIngredientsForProduct(string productName, string category)
        {
            List<IngredientData> ingredients = new List<IngredientData>();

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // Only get ingredients from non-deleted inventory items
                    string query = @"
               SELECT i.IngredientName, pi.Quantity, pi.Category
               FROM productingredient pi
               INNER JOIN product p ON pi.ProductID = p.ProductID
               INNER JOIN inventory i ON pi.InventoryID = i.InventoryID
               WHERE p.ProductName = @productName AND pi.Category = @category AND (i.isDeleted IS NULL OR i.isDeleted = 0)
               ORDER BY pi.ProductIngredientID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productName", productName);
                        cmd.Parameters.AddWithValue("@category", category);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ingredients.Add(new IngredientData
                                {
                                    IngredientName = reader["IngredientName"].ToString(),
                                    Quantity = reader["Quantity"].ToString(),
                                    ProductName = productName,
                                    Category = reader["Category"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving existing ingredients: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ingredients;
        }

        public bool InsertOrUpdateIngredientsToDatabase(List<IngredientData> ingredients)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (IngredientData ingredient in ingredients)
                            {
                                // Get ProductID based on product name and category
                                int productId = GetProductNameByID(ingredient.ProductName, ingredient.Category, connection, transaction);

                                // Get InventoryID based on ingredient name (only non-deleted items)
                                int inventoryId = GetInventoryIdByIngredientName(ingredient.IngredientName, connection, transaction);

                                if (productId > 0 && inventoryId > 0)
                                {
                                    // Check if this combination already exists with category
                                    if (ProductIngredientExists(productId, inventoryId, ingredient.Category, connection, transaction))
                                    {
                                        // Update existing record
                                        string updateQuery = @"
                                   UPDATE productingredient 
                                   SET Quantity = @quantity 
                                   WHERE ProductID = @productID AND InventoryID = @inventoryID AND Category = @category";

                                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection, transaction))
                                        {
                                            cmd.Parameters.AddWithValue("@quantity", ingredient.Quantity);
                                            cmd.Parameters.AddWithValue("@productID", productId);
                                            cmd.Parameters.AddWithValue("@inventoryID", inventoryId);
                                            cmd.Parameters.AddWithValue("@category", ingredient.Category);

                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        // Insert new record with category
                                        string insertQuery = @"
                                   INSERT INTO productingredient (ProductID, InventoryID, Quantity, Category) 
                                   VALUES (@productID, @inventoryID, @quantity, @category)";

                                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection, transaction))
                                        {
                                            cmd.Parameters.AddWithValue("@productID", productId);
                                            cmd.Parameters.AddWithValue("@inventoryID", inventoryId);
                                            cmd.Parameters.AddWithValue("@quantity", ingredient.Quantity);
                                            cmd.Parameters.AddWithValue("@category", ingredient.Category);

                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception($"Could not find ProductID or InventoryID for: {ingredient.ProductName} - {ingredient.IngredientName} in category {ingredient.Category}");
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ProductIngredientExists(int productId, int inventoryId, string category, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "SELECT COUNT(*) FROM productingredient WHERE ProductID = @productID AND InventoryID = @inventoryID AND Category = @category";

            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@productID", productId);
                cmd.Parameters.AddWithValue("@inventoryID", inventoryId);
                cmd.Parameters.AddWithValue("@category", category);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;uid=root;pwd=ejaydetera12;database=marepos-db;";
            return new MySqlConnection(connectionString);
        }

    }
}