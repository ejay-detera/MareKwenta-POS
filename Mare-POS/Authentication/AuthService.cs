using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic; // Added missing using statement
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Mare_POS.Authentication
{
    public class AuthService
    {
        private string connectionString;

        public AuthService()
        {
            // Try to get connection string from app.config first
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            // If not found in config, use the hardcoded connection string as fallback
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "server=localhost;uid=root;pwd=ejaydetera12;database=marepos-db;";
            }
        }

        public DataTable GetAllEmployee()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT EmployeeID, LastName, FirstName, MiddleName, Role, Password, Username, TimeIn, TimeOut FROM employees";

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


        // Overload constructor for custom connection string
        public AuthService(string customConnectionString)
        {
            this.connectionString = customConnectionString;
        }

        // Hash password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Authenticate user credentials against database
        public EmployeeInfo ValidateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            try
            {
                string hashedPassword = HashPassword(password);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT EmployeeID, LastName, FirstName, MiddleName, Role, Password, Username, OwnerID 
                           FROM employees
                           WHERE Username = @Username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Password"].ToString();

                                // Debug output - remove this line after testing
                                System.Diagnostics.Debug.WriteLine($"Stored: {storedPassword}, Hashed: {hashedPassword}");

                                // Verify password hash
                                if (storedPassword == hashedPassword)
                                {
                                    return new EmployeeInfo
                                    {
                                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                        LastName = reader["LastName"].ToString(),
                                        FirstName = reader["FirstName"].ToString(),
                                        MiddleName = reader["MiddleName"]?.ToString() ?? "",
                                        Role = reader["Role"].ToString(),
                                        Username = reader["Username"].ToString(),
                                        OwnerID = reader["OwnerID"] != DBNull.Value ? Convert.ToInt32(reader["OwnerID"]) : (int?)null
                                    };
                                }
                                else
                                {
                                    // Password doesn't match
                                    System.Diagnostics.Debug.WriteLine("Password mismatch");
                                    return null;
                                }
                            }
                            else
                            {
                                // Username not found
                                System.Diagnostics.Debug.WriteLine("Username not found");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                throw new Exception($"Database error during authentication: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Authentication error: {ex.Message}");
            }
        }

        // Get employee by ID
        public EmployeeInfo GetEmployeeById(int employeeId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT EmployeeID, LastName, FirstName, MiddleName, Role, Username, OwnerID 
                                   FROM employees 
                                   WHERE EmployeeID = @EmployeeID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new EmployeeInfo
                                {
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    LastName = reader["LastName"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"]?.ToString() ?? "",
                                    Role = reader["Role"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    OwnerID = reader["OwnerID"] != DBNull.Value ? Convert.ToInt32(reader["OwnerID"]) : (int?)null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employee: {ex.Message}");
            }

            return null;
        }

        // Get employees under a specific owner (for managers/supervisors)
        public List<EmployeeInfo> GetEmployeesByOwner(int ownerID)
        {
            List<EmployeeInfo> employees = new List<EmployeeInfo>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT EmployeeID, LastName, FirstName, MiddleName, Role, Username, OwnerID 
                                   FROM employees 
                                   WHERE OwnerID = @OwnerID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OwnerID", ownerID);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new EmployeeInfo
                                {
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    LastName = reader["LastName"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"]?.ToString() ?? "",
                                    Role = reader["Role"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    OwnerID = reader["OwnerID"] != DBNull.Value ? Convert.ToInt32(reader["OwnerID"]) : (int?)null
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employees by owner: {ex.Message}");
            }

            return employees;
        }

        // Check database connection
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
            catch
            {
                return false;
            }
        }


        public bool CreateEmployee(string lastName, string firstName, string middleName, string role, string username, string password, int? ownerID = null)
        {
            try
            {
                string hashedPassword = HashPassword(password);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO employees (LastName, FirstName, MiddleName, Role, Username, Password, OwnerID) 
                                   VALUES (@LastName, @FirstName, @MiddleName, @Role, @Username, @Password, @OwnerID)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@MiddleName", middleName ?? "");
                        command.Parameters.AddWithValue("@Role", role);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.Parameters.AddWithValue("@OwnerID", ownerID.HasValue ? (object)ownerID.Value : DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating employee: {ex.Message}");
            }
        }

        public bool ResetPassword(string username, string newPassword)
        {
            try
            {
                string hashedPassword = HashPassword(newPassword);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE employees SET Password = @Password WHERE Username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error resetting password: {ex.Message}");
            }
        }

    }

    public class EmployeeInfo
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? OwnerID { get; set; }

        // Computed property for full name
        public string FullName
        {
            get
            {
                string fullName = $"{FirstName} {LastName}";
                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    fullName = $"{FirstName} {MiddleName} {LastName}";
                }
                return fullName.Trim();
            }
        }
    }
}