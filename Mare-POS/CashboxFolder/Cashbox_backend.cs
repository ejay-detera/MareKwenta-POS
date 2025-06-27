using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Mare_POS
{
    public class Cashbox_backend
    {
        private string connectionString;

        public Cashbox_backend()
        {
            // Get connection string from App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in App.config");
            }
        }

        public Cashbox_backend(string customConnectionString)
        {
            connectionString = customConnectionString;
        }

        public bool AddExpense(string expenseName, decimal expenseAmount, string category)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO expense (ExpenseName, ExpenseAmount, Category, Date) 
                                   VALUES (@ExpenseName, @ExpenseAmount, @Category, @Date)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExpenseName", expenseName);
                        command.Parameters.AddWithValue("@ExpenseAmount", expenseAmount);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding expense: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetAllTicket()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Fixed query - use DATE() function to extract just the date part
                    string query = "SELECT * FROM ticket WHERE DATE(Date) = CURDATE() ORDER BY Date DESC;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving tickets: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public DataTable GetAllExpenses()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM expense WHERE Date = CURDATE() ORDER BY Date DESC;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving expenses: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public bool DeleteExpense(int expenseId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM expense WHERE ExpenseID = @ExpenseID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExpenseID", expenseId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting expense: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateExpense(int expenseId, string expenseName, decimal expenseAmount, string category)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE expense 
                                   SET ExpenseName = @ExpenseName, 
                                       ExpenseAmount = @ExpenseAmount, 
                                       Category = @Category 
                                   WHERE ExpenseID = @ExpenseID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExpenseID", expenseId);
                        command.Parameters.AddWithValue("@ExpenseName", expenseName);
                        command.Parameters.AddWithValue("@ExpenseAmount", expenseAmount);
                        command.Parameters.AddWithValue("@Category", category);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating expense: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public decimal GetTotalExpensesByCategory(string category)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT SUM(ExpenseAmount) FROM expense WHERE Category = @Category";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);

                        object result = command.ExecuteScalar();
                        return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total expenses: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Database Connection Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}