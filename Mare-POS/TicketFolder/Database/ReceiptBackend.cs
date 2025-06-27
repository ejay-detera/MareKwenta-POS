using Mare_POS.TicketFolder.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mare_POS.TicketFolder.Database
{
    public static class ReceiptBackend
    {
        private static string connectionString = "server=localhost;database=marepos-db;user=root;password=ejaydetera12";

        public static List<Ticket> GetReceiptItems(int transactionNo)
        {
            List<Ticket> ticketItems = new List<Ticket>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // Join ticket with product table using ProductId
                string query = @"
                    SELECT 
                        t.TransactionNo, 
                        t.ProductID,
                        t.CashAmount, 
                        t.GCashAmount, 
                        t.MayaAmount, 
                        t.`Change`, 
                        t.PaymentType,
                        t.ProductQuantity,
                        t.Subtotal,
                        t.TotalAmount,
                        t.DiscountRate,
                        t.Date,
                        p.ProductName,
                        t.Size,
                        t.Type
                    FROM ticket t
                    INNER JOIN product p ON t.ProductID = p.ProductID
                    WHERE t.TransactionNo = @TransactionNo";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TransactionNo", transactionNo);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket item = new Ticket
                        {
                            TransactionNo = reader["TransactionNo"] != DBNull.Value ? Convert.ToInt32(reader["TransactionNo"]) : 0,
                            ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                            CashAmount = reader["CashAmount"] != DBNull.Value ? Convert.ToDecimal(reader["CashAmount"]) : 0,
                            GcashAmount = reader["GCashAmount"] != DBNull.Value ? Convert.ToDecimal(reader["GCashAmount"]) : 0,
                            MayaAmount = reader["MayaAmount"] != DBNull.Value ? Convert.ToDecimal(reader["MayaAmount"]) : 0,
                            Change = reader["Change"] != DBNull.Value ? Convert.ToDecimal(reader["Change"]) : 0,
                            PaymentType = reader["PaymentType"] != DBNull.Value ? reader["PaymentType"].ToString() : null,
                            ProductQuantity = reader["ProductQuantity"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantity"]) : 0,
                            SubTotal = reader["Subtotal"] != DBNull.Value ? Convert.ToDecimal(reader["Subtotal"]) : 0,
                            TotalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0,
                            DiscountRate = reader["DiscountRate"] != DBNull.Value ? Convert.ToDecimal(reader["DiscountRate"]) : 0,
                            Date = reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]) : DateTime.MinValue,
                            // Product details from joined table
                            ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : null,
                            Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : null,
                            Type = reader["Type"] != DBNull.Value ? reader["Type"].ToString() : null
                        };

                        // Calculate unit price based on product, size, and type
                        item.UnitPrice = GetUnitPrice(item.ProductID, item.Size, item.Type);

                        ticketItems.Add(item);
                    }
                }
            }
            return ticketItems;
        }

        private static decimal GetUnitPrice(int productId, string size, string type)
        {
            decimal price = 0;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        SellingPrice,
                        GrandeHotPrice,
                        VentiHotPrice,
                        GrandeIcedPrice,
                        VentiIcedPrice
                    FROM product
                    WHERE ProductID = @ProductID";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["SellingPrice"] != DBNull.Value)
                                price = Convert.ToDecimal(reader["SellingPrice"]);

                            if (size == "Grande" && type == "Hot")
                                price = reader["GrandeHotPrice"] != DBNull.Value ? Convert.ToDecimal(reader["GrandeHotPrice"]) : price;
                            else if (size == "Venti" && type == "Hot")
                                price = reader["VentiHotPrice"] != DBNull.Value ? Convert.ToDecimal(reader["VentiHotPrice"]) : price;
                            else if (size == "Grande" && type == "Iced")
                                price = reader["GrandeIcedPrice"] != DBNull.Value ? Convert.ToDecimal(reader["GrandeIcedPrice"]) : price;
                            else if (size == "Venti" && type == "Iced")
                                price = reader["VentiIcedPrice"] != DBNull.Value ? Convert.ToDecimal(reader["VentiIcedPrice"]) : price;
                        }
                    }
                }
            }

            return price;
        }
    }
}