using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Mare_POS.TicketFolder.Database
{
    public static class InventoryDataAccess
    {
        public static int GetInventoryQuantity(int inventoryId)
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
)
                {
                    connection.Open();
                    string query = "SELECT Quantity FROM Inventory WHERE InventoryID = @InventoryID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InventoryID", inventoryId);
                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting inventory quantity: {ex.Message}", "Database Error");
                return 0;
            }
        }

        public static string GetInventoryName(int inventoryId)
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
)
                {
                    connection.Open();
                    string query = "SELECT InventoryName FROM Inventory WHERE InventoryID = @InventoryID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InventoryID", inventoryId);
                        var result = command.ExecuteScalar();
                        return result?.ToString() ?? "Unknown Item";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting inventory name: {ex.Message}", "Database Error");
                return "Unknown Item";
            }
        }

        public static bool DeductInventoryQuantity(int inventoryId, int quantityToDeduct)
        {
            try
            {
                using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
)
                {
                    connection.Open();
                    string query = "UPDATE Inventory SET Quantity = Quantity - @QuantityToDeduct WHERE InventoryID = @InventoryID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InventoryID", inventoryId);
                        command.Parameters.AddWithValue("@QuantityToDeduct", quantityToDeduct);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deducting inventory: {ex.Message}", "Database Error");
                return false;
            }
        }
    }

}
