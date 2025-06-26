using Mare_POS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mare_POS.Database
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

                string query = @"SELECT * FROM ticket WHERE TransactionNo = @TransactionNo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TransactionNo", transactionNo);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket item = new Ticket
                        {
                            ProductName = reader["ProductName"].ToString(),
                            Size = reader["Size"].ToString(),
                            Type = reader["Type"].ToString(),
                            ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                            CashAmount = Convert.ToDecimal(reader["CashAmount"]),
                            GcashAmount = Convert.ToDecimal(reader["GcashAmount"]),
                            MayaAmount = Convert.ToDecimal(reader["MayaAmount"]),
                            Change = Convert.ToDecimal(reader["Change"]),
                            Date = Convert.ToDateTime(reader["Date"])
                        };
                        ticketItems.Add(item);
                    }
                }
            }

            return ticketItems;
        }
    }
}