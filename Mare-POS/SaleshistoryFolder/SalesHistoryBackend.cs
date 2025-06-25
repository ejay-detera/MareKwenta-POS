using MareKwenta.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mare_POS.SaleshistoryFolder
{
    public class SalesHistoryBackend
    {
        private string connectionString = "server=localhost;database=marepos-db;user=root;password=IyahMikaela_23;";

        // Get all ticket summaries (one per transaction)
        public List<Ticket> GetAllTicketSummaries()
        {
            var ticketSummaries = new List<Ticket>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        MIN(TicketID) AS TicketID, 
                        TransactionNo, 
                        Date, 
                        SUM(TotalAmount) AS TotalAmount
                    FROM ticket
                    GROUP BY TransactionNo, Date
                    ORDER BY Date DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ticketSummaries.Add(new Ticket
                        {
                            TicketID = Convert.ToInt32(reader["TicketID"]),
                            TransactionNo = Convert.ToInt32(reader["TransactionNo"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            TotalAmount = reader["TotalAmount"] != DBNull.Value
                                            ? Convert.ToDecimal(reader["TotalAmount"])
                                            : 0
                        });

                    }
                }
            }

            return ticketSummaries;
        }

        // Get full receipt info using TicketID (finds TransactionNo first)
        public List<Ticket> GetReceiptByTicketID(int ticketID)
        {
            List<Ticket> ticketItems = new List<Ticket>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Step 1: Find the TransactionNo
                string getTransactionNoQuery = "SELECT TransactionNo FROM ticket WHERE TicketID = @TicketID";
                int transactionNo = 0;

                using (MySqlCommand cmd = new MySqlCommand(getTransactionNoQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    object? result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        transactionNo = Convert.ToInt32(result);
                    }
                    else
                    {
                        return ticketItems;
                    }
                }

                // Step 2: Retrieve all items in the same transaction
                string query = @"
            SELECT 
                t.TicketID,
                t.TransactionNo,
                t.ProductID,
                t.ProductQuantity,
                t.Size,
                t.Type,
                t.Subtotal,
                t.TotalAmount,
                t.PaymentAmount,
                t.CashAmount,
                t.GCashAmount,
                t.MayaAmount,
                t.`Change`,
                t.DiscountRate,
                t.PaymentType,
                t.DiscountType,
                t.EmployeeID,
                t.Date,
                p.ProductName,
                CONCAT(e.FirstName, ' ', LEFT(e.MiddleName, 1), '. ', e.LastName) AS EmployeeName
            FROM ticket t
            LEFT JOIN product p ON p.ProductID = t.ProductID
            LEFT JOIN employee e ON e.EmployeeID = t.EmployeeID
            WHERE t.TransactionNo = @TransactionNo
            ORDER BY t.TicketID ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionNo", transactionNo);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ticket = new Ticket
                            {
                                TicketID = Convert.ToInt32(reader["TicketID"]),
                                TransactionNo = Convert.ToInt32(reader["TransactionNo"]),
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]),
                                Size = reader["Size"]?.ToString(),
                                Type = reader["Type"]?.ToString(),
                                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                                TotalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0,
                                PaymentAmount = reader["PaymentAmount"] != DBNull.Value ? Convert.ToDecimal(reader["PaymentAmount"]) : 0,
                                CashAmount = reader["CashAmount"] != DBNull.Value ? Convert.ToDecimal(reader["CashAmount"]) : 0,
                                GcashAmount = reader["GCashAmount"] != DBNull.Value ? Convert.ToDecimal(reader["GCashAmount"]) : 0,
                                MayaAmount = reader["MayaAmount"] != DBNull.Value ? Convert.ToDecimal(reader["MayaAmount"]) : 0,
                                Change = reader["Change"] != DBNull.Value ? Convert.ToDecimal(reader["Change"]) : 0,
                                DiscountRate = reader["DiscountRate"] != DBNull.Value ? Convert.ToDecimal(reader["DiscountRate"]) : 0,
                                PaymentType = reader["PaymentType"]?.ToString(),
                                DiscountType = reader["DiscountType"]?.ToString(),
                                Date = reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]) : DateTime.MinValue,
                                ProductName = reader["ProductName"]?.ToString(),
                                EmployeeName = reader["EmployeeName"]?.ToString()
                            };
                            ticket.UnitPrice = GetUnitPrice(ticket.ProductID, ticket.Size, ticket.Type);
                            ticketItems.Add(ticket);
                        }
                    }
                }
            }

            return ticketItems;
        }
        private decimal GetUnitPrice(int productId, string size, string type)
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
                                price = Convert.ToDecimal(reader["GrandeHotPrice"]);
                            else if (size == "Venti" && type == "Hot")
                                price = Convert.ToDecimal(reader["VentiHotPrice"]);
                            else if (size == "Grande" && type == "Iced")
                                price = Convert.ToDecimal(reader["GrandeIcedPrice"]);
                            else if (size == "Venti" && type == "Iced")
                                price = Convert.ToDecimal(reader["VentiIcedPrice"]);
                        }
                    }
                }
            }

            return price;
        }
        public int GetFirstTicketIDByTransactionNo(int transactionNo)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MIN(TicketID) FROM ticket WHERE TransactionNo = @TransactionNo";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TransactionNo", transactionNo);
                    object? result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
            }
        }

    }
}
