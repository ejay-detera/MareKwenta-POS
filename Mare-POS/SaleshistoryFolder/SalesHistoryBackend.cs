using MareKwenta.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace Mare_POS.SaleshistoryFolder
{
    public class SalesHistoryBackend
    {
        private string connectionString = "server=localhost;database=marepos-db;user=root;password=IyahMikaela_23;";

        public Ticket? GetTicketDetails(int ticketId)
        {
            Ticket? ticket = null;

            try
            {
                Debug.WriteLine($"Connecting to database with TicketID: {ticketId}");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    Debug.WriteLine("Database connection opened successfully.");

                    string query = @"SELECT t.*, e.FirstName, e.LastName, p.ProductName, t.Size, t.Type, p.SellingPrice, 
                                    p.GrandeHotPrice, p.VentiHotPrice, p.GrandeIcedPrice, p.VentiIcedPrice, 
                                    t.Change, t.DiscountRate, t.PaymentType, t.DiscountType, t.Date, 
                                    t.Category, t.Subtotal, t.CashAmount, t.GcashAmount, t.MayaAmount
                             FROM ticket t
                             JOIN employee e ON t.EmployeeID = e.EmployeeID
                             JOIN product p ON t.ProductID = p.ProductID
                             WHERE t.TicketID = @TicketID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TicketID", ticketId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Debug.WriteLine("Ticket found in database.");

                                string size = reader["Size"]?.ToString() ?? "";
                                string type = reader["Type"]?.ToString() ?? "";
                                decimal unitPrice = 0;

                                if (size == "Grande" && type == "Hot")
                                    unitPrice = reader.IsDBNull(reader.GetOrdinal("GrandeHotPrice")) ? 0 : reader.GetDecimal("GrandeHotPrice");
                                else if (size == "Venti" && type == "Hot")
                                    unitPrice = reader.IsDBNull(reader.GetOrdinal("VentiHotPrice")) ? 0 : reader.GetDecimal("VentiHotPrice");
                                else if (size == "Grande" && type == "Iced")
                                    unitPrice = reader.IsDBNull(reader.GetOrdinal("GrandeIcedPrice")) ? 0 : reader.GetDecimal("GrandeIcedPrice");
                                else if (size == "Venti" && type == "Iced")
                                    unitPrice = reader.IsDBNull(reader.GetOrdinal("VentiIcedPrice")) ? 0 : reader.GetDecimal("VentiIcedPrice");
                                else
                                    unitPrice = reader.IsDBNull(reader.GetOrdinal("SellingPrice")) ? 0 : reader.GetDecimal("SellingPrice");

                                int quantity = reader.GetInt32(reader.GetOrdinal("ProductQuantity"));
                                decimal Subtotal = reader.IsDBNull(reader.GetOrdinal("Subtotal"))
                                    ? 0
                                    : reader.GetDecimal("Subtotal");

                                ticket = new Ticket
                                {
                                    TicketID = reader.GetInt32("TicketID"),
                                    EmployeeName = reader["FirstName"] + " " + reader["LastName"],
                                    ProductName = reader["ProductName"]?.ToString() ?? "",
                                    ProductQuantity = quantity,
                                    UnitPrice = unitPrice,
                                    Subtotal = Subtotal,
                                    Size = size,
                                    Type = type,
                                    TotalAmount = reader.GetDecimal("TotalAmount"),
                                    PaymentAmount = reader.GetDecimal("PaymentAmount"),
                                    Change = reader.GetDecimal("Change"),
                                    DiscountRate = reader.GetDecimal("DiscountRate"),
                                    PaymentType = reader["PaymentType"].ToString(),
                                    DiscountType = reader["DiscountType"].ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Category = reader["Category"]?.ToString() ?? "",
                                    CashAmount = reader.IsDBNull(reader.GetOrdinal("CashAmount")) ? 0 : reader.GetDecimal("CashAmount"),
                                    GcashAmount = reader.IsDBNull(reader.GetOrdinal("GcashAmount")) ? 0 : reader.GetDecimal("GcashAmount"),
                                    MayaAmount = reader.IsDBNull(reader.GetOrdinal("MayaAmount")) ? 0 : reader.GetDecimal("MayaAmount")
                                };
                            }
                            else
                            {
                                Debug.WriteLine("No ticket found for the provided TicketID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during database operation: " + ex.Message);
            }

            return ticket;
        }
    }
}
