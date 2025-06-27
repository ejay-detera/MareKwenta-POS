using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Mare_POS.TicketFolder.Models;

namespace Mare_POS.TicketFolder.Database
{
    public class ProductDataAccess
    {
        private static string connectionString = "server=localhost;user=root;password=ejaydetera12;database=marepos-db;";

        // Get base price of product by ID, size, type
        public static decimal GetBasePrice(int productId, string size, string type)
        {
            decimal price = 0;
            string columnName = "";

            // Map Size + Type to column
            if (size == "Grande" && type == "Hot") columnName = "GrandeHotPrice";
            else if (size == "Venti" && type == "Hot") columnName = "VentiHotPrice";
            else if (size == "Grande" && type == "Cold") columnName = "GrandeIcedPrice";
            else if (size == "Venti" && type == "Cold") columnName = "VentiIcedPrice";

           //essageBox.Show($"Looking for: Size={size}, Type={type}, Column={columnName}");

            if (string.IsNullOrEmpty(columnName))
                return 0;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT `{columnName}` FROM product WHERE ProductID = @ProductID";

                // ADD THIS - to see the actual query being executed
               //essageBox.Show($"Query: {query}\nProductID: {productId}");

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    var result = cmd.ExecuteScalar();

                    // ADD THIS - to see what the database returned
                   // MessageBox.Show($"Database result: {result ?? "NULL"}");

                    if (result != null && result != DBNull.Value)
                        price = Convert.ToDecimal(result);
                }
            }

            // ADD THIS - to see the final price
           //essageBox.Show($"Final price: {price}");

            return price;
        }

        public static List<ProductIngredient> GetProductIngredients(int productId, string categoryCode)
        {
            var ingredients = new List<ProductIngredient>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT InventoryID, ProductID, Quantity FROM ProductIngredient WHERE ProductID = @ProductID AND Category = @CategoryCode";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ProductID", productId);
                        command.Parameters.AddWithValue("@CategoryCode", categoryCode);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ingredients.Add(new ProductIngredient
                                {
                                    InventoryID = reader.GetInt32("InventoryID"),
                                    ProductID = reader.GetInt32("ProductID"),
                                    Quantity = reader.GetInt32("Quantity")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting product ingredients: {ex.Message}", "Database Error");
            }
            return ingredients;
        }        // For food or items without size/type
        public static decimal GetBasePrice(int productId)
        {
            decimal price = 0;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SellingPrice FROM product WHERE ProductID = @ProductID LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        price = Convert.ToDecimal(result);
                }
            }

            return price;
        }

        // Get prices of extras by name
        public static decimal GetExtrasTotal(List<string> extraNames)
        {
            decimal total = 0;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                foreach (var extra in extraNames)
                {
                    string query = @"SELECT SellingPrice FROM product WHERE ProductName = @ExtraName";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ExtraName", extra);

                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            total += Convert.ToDecimal(result);
                    }
                }
            }

            return total;
        }


        public static int GetProductId(string productName)
        {
            int productId = 0;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ProductID FROM product WHERE ProductName = @ProductName LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        productId = Convert.ToInt32(result);
                }
            }

            return productId;
        }
    }
}