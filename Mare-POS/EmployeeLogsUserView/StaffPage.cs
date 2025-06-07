using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mare_POS
{
    public partial class StaffPage : UserControl
    {
        public StaffPage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += EmployeeLogs_Load;

        }

        private CuoreUI.Controls.cuiButton? selectedDateButton = null;
        private bool initialCardsLoaded = false;
        private void EmployeeLogs_Load(object? sender, EventArgs e)
        {
            dateHeader.Content = DateTime.Now.ToString("MMMM dd, yyyy");

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
                    dateHeader.Content = dateValue.ToString("MMMM dd, yyyy");
                    LoadEmployeeCards(dateValue);
                }
            }
        }

        private void StyleSelectedButton(CuoreUI.Controls.cuiButton btn)
        {
            btn.NormalBackground = Color.FromArgb(110, 80, 60); // Example: brown
            btn.NormalForeColor = Color.White;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
        }

        private void StyleUnselectedButton(CuoreUI.Controls.cuiButton btn)
        {
            btn.NormalBackground = Color.White;
            btn.NormalForeColor = Color.FromArgb(78, 45, 24);
            btn.Font = new Font(btn.Font, FontStyle.Regular);
        }

        public class Employee
        {
            public required string Name { get; set; }
            public TimeSpan Duration { get; set; }
            public required string Password { get; set; }
        }
        private void LoadEmployeeCards(DateTime date)
        {
            PanelEmployeeCards.Controls.Clear();

            // Simulate some data
            var employees = new List<Employee>
            {
                new Employee { Name = "Employee 1", Duration = TimeSpan.Zero, Password = "pass1" },
                new Employee { Name = "Employee 2", Duration = TimeSpan.FromHours(8), Password = "pass2" },
                new Employee { Name = "Employee 3", Duration = TimeSpan.FromHours(4.5), Password = "pass3" }
            };

            foreach (var emp in employees)
            {
                var card = new EmployeeCard
                {
                    EmployeeName = emp.Name,
                    WorkDuration = emp.Duration,
                    EmployeePassword = emp.Password,
                    Width = PanelEmployeeCards.Width - 20,
                    Margin = new Padding(10),
                };

                // Optional: Hook up IN/OUT logic
                card.InClicked -= Card_InClicked;
                card.InClicked += Card_InClicked;

                card.OutClicked -= Card_OutClicked;
                card.OutClicked += Card_OutClicked;

                PanelEmployeeCards.Controls.Add(card);
            }
        }
        private void Card_InClicked(object? sender, EventArgs e)
        {

            if (sender is EmployeeCard card)
            {
                using var prompt = new PasswordPrompt(card.EmployeeName);
                if (prompt.ShowDialog() == DialogResult.OK && prompt.EnteredPassword == card.EmployeePassword)
                {
                    card.LoadStatus(true, false);
                    MessageBox.Show($"{card.EmployeeName} clocked IN");
                }
                else
                {
                    MessageBox.Show("Incorrect password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Card_OutClicked(object? sender, EventArgs e)
        {
            if (sender is EmployeeCard card)
            {
                using var prompt = new PasswordPrompt(card.EmployeeName);
                if (prompt.ShowDialog() == DialogResult.OK && prompt.EnteredPassword == card.EmployeePassword)
                {
                    card.LoadStatus(false, true);
                    MessageBox.Show($"{card.EmployeeName} clocked OUT");
                }
                else
                {
                    MessageBox.Show("Incorrect password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void employeeCard_InClicked(object? sender, EventArgs e)
        {
            var card = sender as EmployeeCard;
            Console.WriteLine($"{card?.EmployeeName} clocked IN at {DateTime.Now}");

            // Optional: Save to DB or file
        }

        private void employeeCard_OutClicked(object? sender, EventArgs e)
        {
            var card = sender as EmployeeCard;
            Console.WriteLine($"{card?.EmployeeName} clocked OUT at {DateTime.Now}");

            // Optional: Save to DB or file
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_ContentChanged(object sender, EventArgs e)
        {



        }

        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }
    }
}

