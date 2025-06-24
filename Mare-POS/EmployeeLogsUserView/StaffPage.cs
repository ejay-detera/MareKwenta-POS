using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mare_POS.Authentication;
using MySql.Data.MySqlClient;

namespace Mare_POS
{
    public partial class StaffPage : UserControl
    {
        private AuthService authService;
        private string connectionString;

        public StaffPage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += EmployeeLogs_Load;

            // Initialize AuthService
            authService = new AuthService();

            // Get connection string (same as AuthService)
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "server=localhost;uid=root;pwd=ejaydetera12;database=marepos-db;";
            }
        }

        private CuoreUI.Controls.cuiButton? selectedDateButton = null;
        private bool initialCardsLoaded = false;
        private DateTime selectedDate = DateTime.Now.Date;

        // Add SHA256 hashing method
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

        private void EmployeeLogs_Load(object? sender, EventArgs e)
        {
            dateHeader.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            selectedDate = DateTime.Now.Date;

            panelDates.Controls.Clear();

            int days = 15;
            int buttonHeight = 70;
            int buttonSpacing = 15;

            DateTime today = DateTime.Now.Date;

            for (int i = 0; i < days; i++)
            {
                var btnDate = today.AddDays(-i);
                var day = btnDate.ToString("ddd", System.Globalization.CultureInfo.InvariantCulture).ToUpper();
                var rest = btnDate.ToString(", MMM dd", System.Globalization.CultureInfo.InvariantCulture);

                var btn = new CuoreUI.Controls.cuiButton
                {
                    Content = day + rest,
                    Width = panelDates.Width - 16,
                    Height = buttonHeight,
                    Left = 8,
                    Top = i * (buttonHeight + buttonSpacing),
                    Font = new Font("Unbounded Medium", 14F, FontStyle.Regular),
                    NormalBackground = Color.White,
                    NormalForeColor = Color.FromArgb(78, 45, 24),
                    Rounding = new Padding(16),
                    Tag = btnDate,
                    TextAlignment = StringAlignment.Center,
                    OutlineThickness = 0f,
                    Padding = new Padding(0, 10, 0, 10),
                };

                btn.Click += DateButton_Click;
                panelDates.Controls.Add(btn);

                // Select today's date without calling LoadEmployeeCards here
                if (i == 0)
                {
                    StyleSelectedButton(btn);
                    selectedDateButton = btn;
                }
            }

            // Manually simulate click once to load the cards for today
            if (!initialCardsLoaded && selectedDateButton != null)
            {
                DateButton_Click(selectedDateButton, EventArgs.Empty);
                initialCardsLoaded = true;
            }
        }

        private void DateButton_Click(object? sender, EventArgs e)
        {
            if (sender is CuoreUI.Controls.cuiButton btn)
            {
                // Unstyle previous selection
                if (selectedDateButton != null)
                    StyleUnselectedButton(selectedDateButton);

                // Style new selection
                StyleSelectedButton(btn);
                selectedDateButton = btn;

                // Update the main date header
                if (btn.Tag is DateTime dateValue)
                {
                    selectedDate = dateValue;
                    dateHeader.Content = dateValue.ToString("MMMM dd, yyyy");
                    LoadEmployeeCards(dateValue);
                }
            }
        }

        private void StyleSelectedButton(CuoreUI.Controls.cuiButton btn)
        {
            btn.NormalBackground = Color.FromArgb(110, 80, 60);
            btn.NormalForeColor = Color.White;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
        }

        private void StyleUnselectedButton(CuoreUI.Controls.cuiButton btn)
        {
            btn.NormalBackground = Color.White;
            btn.NormalForeColor = Color.FromArgb(78, 45, 24);
            btn.Font = new Font(btn.Font, FontStyle.Regular);
        }

        public class EmployeeTimeLog
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public DateTime? TimeIn { get; set; }
            public DateTime? TimeOut { get; set; }
            public DateTime Date { get; set; }

            public string DisplayName => $"Employee {FirstName}";
            public string WorkStatusTime => TimeIn?.ToString("hh:mm tt") ?? TimeOut?.ToString("hh:mm tt") ?? "Not logged";
        }

        private void LoadEmployeeCards(DateTime date)
        {
            PanelEmployeeCards.Controls.Clear();

            try
            {
                var employees = GetEmployeesWithTimeLog(date);

                foreach (var emp in employees)
                {
                    var card = new EmployeeCard
                    {
                        EmployeeName = emp.DisplayName,
                        WorkStatusTime = emp.WorkStatusTime,
                        EmployeePassword = emp.Password,
                        Width = PanelEmployeeCards.Width - 20,
                        Margin = new Padding(10),
                        Tag = emp // Store employee data in Tag
                    };

                    // Hook up IN/OUT logic
                    card.InClicked -= Card_InClicked;
                    card.InClicked += Card_InClicked;

                    card.OutClicked -= Card_OutClicked;
                    card.OutClicked += Card_OutClicked;

                    PanelEmployeeCards.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<EmployeeTimeLog> GetEmployeesWithTimeLog(DateTime date)
        {
            var employees = new List<EmployeeTimeLog>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            e.EmployeeID, 
                            e.FirstName, 
                            e.LastName, 
                            e.Username, 
                            e.Password,
                            e.Role,
                            tl.TimeIn,
                            tl.TimeOut,
                            tl.Date
                        FROM employees e
                        LEFT JOIN timelog tl ON e.EmployeeID = tl.EmployeeID AND DATE(tl.Date) = @Date WHERE e.Role = 'Employee'
                        ORDER BY e.FirstName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", date.Date);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? timeIn = null;
                                DateTime? timeOut = null;

                                // Handle TimeIn conversion
                                if (reader["TimeIn"] != DBNull.Value)
                                {
                                    var timeInValue = reader["TimeIn"];
                                    if (timeInValue is TimeSpan timeInSpan)
                                    {
                                        timeIn = date.Date.Add(timeInSpan);
                                    }
                                    else if (timeInValue is DateTime timeInDateTime)
                                    {
                                        timeIn = timeInDateTime;
                                    }
                                }

                                // Handle TimeOut conversion
                                if (reader["TimeOut"] != DBNull.Value)
                                {
                                    var timeOutValue = reader["TimeOut"];
                                    if (timeOutValue is TimeSpan timeOutSpan)
                                    {
                                        timeOut = date.Date.Add(timeOutSpan);
                                    }
                                    else if (timeOutValue is DateTime timeOutDateTime)
                                    {
                                        timeOut = timeOutDateTime;
                                    }
                                }

                                employees.Add(new EmployeeTimeLog
                                {
                                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    TimeIn = timeIn,
                                    TimeOut = timeOut,
                                    Date = date
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database error: {ex.Message}");
            }

            return employees;
        }

        private void Card_InClicked(object? sender, EventArgs e)
        {
            if (sender is EmployeeCard card && card.Tag is EmployeeTimeLog employee)
            {
                using var prompt = new PasswordPrompt(card.EmployeeName);
                var result = prompt.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Hash the entered password and compare with stored hash
                    string hashedEnteredPassword = HashPassword(prompt.EnteredPassword);

                    if (hashedEnteredPassword.Equals(card.EmployeePassword, StringComparison.OrdinalIgnoreCase))
                    {
                        // Record time in to database
                        if (RecordTimeIn(employee.EmployeeID, selectedDate))
                        {
                            card.LoadStatus(true, false);
                            MessageBox.Show($"{card.EmployeeName} clocked IN at {DateTime.Now:hh:mm tt}",
                                "Clock In Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the cards to show updated time
                            LoadEmployeeCards(selectedDate);
                        }
                        else
                        {
                            MessageBox.Show("Failed to record clock in time.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password.", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Card_OutClicked(object? sender, EventArgs e)
        {
            if (sender is EmployeeCard card && card.Tag is EmployeeTimeLog employee)
            {
                using var prompt = new PasswordPrompt(card.EmployeeName);
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    // Hash the entered password and compare with stored hash
                    string hashedEnteredPassword = HashPassword(prompt.EnteredPassword);

                    if (hashedEnteredPassword.Equals(card.EmployeePassword, StringComparison.OrdinalIgnoreCase))
                    {
                        // Record time out to database
                        if (RecordTimeOut(employee.EmployeeID, selectedDate))
                        {
                            card.LoadStatus(false, true);
                            MessageBox.Show($"{card.EmployeeName} clocked OUT at {DateTime.Now:hh:mm tt}",
                                "Clock Out Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the cards to show updated time
                            LoadEmployeeCards(selectedDate);
                        }
                        else
                        {
                            MessageBox.Show("Failed to record clock out time.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password.", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private bool RecordTimeIn(int employeeID, DateTime date)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if there's already a record for today
                    string checkQuery = @"
                        SELECT COUNT(*) FROM timelog 
                        WHERE EmployeeID = @EmployeeID AND DATE(Date) = @Date";

                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                        checkCommand.Parameters.AddWithValue("@Date", date.Date);

                        int existingRecords = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingRecords > 0)
                        {
                            // Update existing record
                            string updateQuery = @"
                                UPDATE timelog 
                                SET TimeIn = @TimeIn 
                                WHERE EmployeeID = @EmployeeID AND DATE(Date) = @Date";

                            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@TimeIn", DateTime.Now);
                                updateCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                updateCommand.Parameters.AddWithValue("@Date", date.Date);

                                return updateCommand.ExecuteNonQuery() > 0;
                            }
                        }
                        else
                        {
                            // Insert new record
                            string insertQuery = @"
                                INSERT INTO timelog (EmployeeID, Date, TimeIn) 
                                VALUES (@EmployeeID, @Date, @TimeIn)";

                            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                insertCommand.Parameters.AddWithValue("@Date", date.Date);
                                insertCommand.Parameters.AddWithValue("@TimeIn", DateTime.Now);

                                return insertCommand.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording time in: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool RecordTimeOut(int employeeID, DateTime date)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if there's already a record for today
                    string checkQuery = @"
                        SELECT COUNT(*) FROM timelog 
                        WHERE EmployeeID = @EmployeeID AND DATE(Date) = @Date";

                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                        checkCommand.Parameters.AddWithValue("@Date", date.Date);

                        int existingRecords = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingRecords > 0)
                        {
                            // Update existing record
                            string updateQuery = @"
                                UPDATE timelog 
                                SET TimeOut = @TimeOut 
                                WHERE EmployeeID = @EmployeeID AND DATE(Date) = @Date";

                            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@TimeOut", DateTime.Now);
                                updateCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                updateCommand.Parameters.AddWithValue("@Date", date.Date);

                                return updateCommand.ExecuteNonQuery() > 0;
                            }
                        }
                        else
                        {
                            // Insert new record with TimeOut only
                            string insertQuery = @"
                                INSERT INTO timelog (EmployeeID, Date, TimeOut) 
                                VALUES (@EmployeeID, @Date, @TimeOut)";

                            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                insertCommand.Parameters.AddWithValue("@Date", date.Date);
                                insertCommand.Parameters.AddWithValue("@TimeOut", DateTime.Now);

                                return insertCommand.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording time out: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Remove unused methods
        private void cuiButton1_Click(object sender, EventArgs e) { }
        private void cuiTextBox1_ContentChanged(object sender, EventArgs e) { }
        private void cuiLabel1_Load(object sender, EventArgs e) { }
        private void panelDates_Paint(object sender, PaintEventArgs e) { }

        private void PanelEmployeeCards_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}