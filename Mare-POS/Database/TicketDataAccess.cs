using Mare_POS.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Mare_POS.Database
{
    public class TicketDataAccess
    {
        private static string connectionString = "server=localhost;database=marepos-db;user=root;password=IyahMikaela_23";

        public static int GetNextTransactionNo()
        {
            int transactionNo = 1;
            using MySqlConnection conn = new MySqlConnection(connectionString);
            {
                conn.Open();
                string query = "SELECT ISNULL(MAX(TransactionNo), 0) + 1 FROM ticket";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                {
                    transactionNo = (int)cmd.ExecuteScalar();
                }
            }
            return transactionNo;
        }

        public static void SaveOrder(List<Item> items, decimal totalAmount, decimal payment, decimal change,
                                     decimal discountRate, string paymentType, string discountType,
                                     decimal cashAmount, decimal gcashAmount, decimal mayaAmount,
                                     int employeeID)
        {
            int transactionNo = GetNextTransactionNo();

            MySqlConnection conn = new MySqlConnection(connectionString);
            {
                conn.Open();

                foreach (var item in items)
                {
                    string query = @"
                    INSERT INTO ticket
                    (TransactionNo, EmployeeID, ProductID, ProductQuantity, TotalAmount, PaymentAmount, `Change`,
                     DiscountRate, PaymentType, DiscountType, Date, Category, Size, Type,
                     CashAmount, GcashAmount, MayaAmount, Subtotal)
                    VALUES
                    (@TransactionNo, @EmployeeID, @ProductID, @ProductQuantity, @TotalAmount, @PaymentAmount, @Change,
                     @DiscountRate, @PaymentType, @DiscountType, @Date, @Category, @Size, @Type,
                     @CashAmount, @GcashAmount, @MayaAmount, @Subtotal)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    {
                        cmd.Parameters.AddWithValue("@TransactionNo", transactionNo);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmd.Parameters.AddWithValue("@ProductQuantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@PaymentAmount", payment);
                        cmd.Parameters.AddWithValue("@Change", change);
                        cmd.Parameters.AddWithValue("@DiscountRate", discountRate);
                        cmd.Parameters.AddWithValue("@PaymentType", paymentType);
                        cmd.Parameters.AddWithValue("@DiscountType", discountType);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Category", item.Category);
                        cmd.Parameters.AddWithValue("@Size", item.ProductSize);
                        cmd.Parameters.AddWithValue("@Type", item.ProductType);
                        cmd.Parameters.AddWithValue("@CashAmount", cashAmount);
                        cmd.Parameters.AddWithValue("@GcashAmount", gcashAmount);
                        cmd.Parameters.AddWithValue("@MayaAmount", mayaAmount);
                        cmd.Parameters.AddWithValue("@Subtotal", item.Amount);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show($"Transaction #{transactionNo} completed.");
        }
    }
}
