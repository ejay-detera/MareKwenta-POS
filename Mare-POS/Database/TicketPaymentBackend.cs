using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Mare_POS.Models;

namespace Mare_POS.Database
{
    public static class TicketPaymentBackend
    {
        private static string connectionString = "server=localhost;database=marepos-db;user=root;password=IyahMikaela_23";

        public static void SavePayment(int transactionNo, decimal cash, decimal gcash, decimal maya, decimal change)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                List<string> methods = new List<string>();
                if (cash > 0) methods.Add("Cash");
                if (gcash > 0) methods.Add("GCash");
                if (maya > 0) methods.Add("Maya");

                string paymentType = string.Join("+", methods);

                string query = @"
                    UPDATE ticket 
                    SET 
                        CashAmount = @cash, 
                        GCashAmount = @gcash, 
                        MayaAmount = @maya,  
                        `Change` = @change, 
                        PaymentType = @paymentType 
                    WHERE TransactionNo = @transactionNo 
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cash", cash);
                    cmd.Parameters.AddWithValue("@gcash", gcash);
                    cmd.Parameters.AddWithValue("@maya", maya);
                    cmd.Parameters.AddWithValue("@change", change);
                    cmd.Parameters.AddWithValue("@paymentType", paymentType);
                    cmd.Parameters.AddWithValue("@transactionNo", transactionNo);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static int GetNextTransactionNo()
        {
            int transactionNo = 1;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COALESCE(MAX(TransactionNo), 0) + 1 FROM ticket";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    transactionNo = Convert.ToInt32(result);
                }
            }

            return transactionNo;
        }


    }
}
