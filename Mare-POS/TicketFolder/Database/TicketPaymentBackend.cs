using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Mare_POS.TicketFolder.Models;

namespace Mare_POS.TicketFolder.Database
{
    public static class TicketPaymentBackend
    {
        private static string connectionString = "server=localhost;database=marepos-db;user=root;password=ejaydetera12";

        public static void SavePayment(int transactionNo, List<Item> orderItems, decimal subtotal,
            decimal discountAmount, string discountType, decimal discountRate,
            decimal cashAmount, decimal gcashAmount, decimal mayaAmount,
            decimal totalAmount, decimal paymentAmount, decimal change)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {

                    try
                    { 

                        // Determine payment methods
                        List<string> methods = new List<string>();
                        if (cashAmount > 0) methods.Add("Cash");
                        if (gcashAmount > 0) methods.Add("GCash");
                        if (mayaAmount > 0) methods.Add("Maya");
                        string paymentType = methods.Count > 0 ? string.Join("+", methods) : "Cash";

                        // Insert a record for each item in the order
                        string ticketQuery = @"
                    INSERT INTO ticket 
                    (TransactionNo, TotalAmount, PaymentAmount, `Change`, DiscountRate, 
                     DiscountType, Date, Category, CashAmount, MayaAmount, GCashAmount, 
                     PaymentType, Subtotal, EmployeeID, ProductID, Size, Type, ProductQuantity) 
                    VALUES 
                    (@transactionNo, @totalAmount, @paymentAmount, @change, @discountRate, 
                     @discountType, NOW(), @category, @cashAmount, @mayaAmount, 
                     @gcashAmount, @paymentType, @subtotal, @employeeId, @productId, @size, @type, @quantity)";

                        // Insert each item separately
                        foreach (var item in orderItems)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(ticketQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@transactionNo", transactionNo);
                                cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                                cmd.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                                cmd.Parameters.AddWithValue("@change", change);
                                cmd.Parameters.AddWithValue("@discountRate", discountRate);
                                cmd.Parameters.AddWithValue("@discountType", string.IsNullOrEmpty(discountType) ? "None" : discountType);
                                cmd.Parameters.AddWithValue("@category", item.Category ?? GetOrderCategory(orderItems));
                                cmd.Parameters.AddWithValue("@cashAmount", cashAmount);
                                cmd.Parameters.AddWithValue("@mayaAmount", mayaAmount);
                                cmd.Parameters.AddWithValue("@gcashAmount", gcashAmount);
                                cmd.Parameters.AddWithValue("@paymentType", paymentType);
                                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                                cmd.Parameters.AddWithValue("@employeeId", item.EmployeeID);

                                // ✅ Now these values come from the actual item
                                cmd.Parameters.AddWithValue("@productId", item.ProductID);
                                cmd.Parameters.AddWithValue("@size", item.ProductSize ?? "Grande");
                                cmd.Parameters.AddWithValue("@type", item.ProductType ?? "Hot");
                                cmd.Parameters.AddWithValue("@quantity", item.Quantity);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error saving transaction: {ex.Message}", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }

        public static int GetNextTransactionNo()
        {
            int transactionNo = 1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COALESCE(MAX(TransactionNo), 0) + 1 FROM ticket";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        transactionNo = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting next transaction number: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return transactionNo;
        }
        private static string GetOrderCategory(List<Item> orderItems)
        {
            if (orderItems == null || orderItems.Count == 0) return "Mixed";

            var categories = orderItems.Select(i => i.Category).Distinct().ToList();

            if (categories.Count == 1)
                return categories[0];
            else
                return "Mixed";
        }
        // Helper method to validate payment data
        public static bool ValidatePaymentData(decimal totalAmount, decimal paymentAmount,
            decimal cashAmount, decimal gcashAmount, decimal mayaAmount)
        {
            decimal totalPayments = cashAmount + gcashAmount + mayaAmount;

            if (Math.Abs(totalPayments - paymentAmount) > 0.01m)
            {
                MessageBox.Show("Payment amounts don't match the total payment!", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (paymentAmount < totalAmount)
            {
                MessageBox.Show("Payment amount is less than total amount!", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}