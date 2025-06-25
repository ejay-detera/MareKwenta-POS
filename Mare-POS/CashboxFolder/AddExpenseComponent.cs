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
    public partial class AddExpenseForm : Form
    {
        private Cashbox_backend cashboxBackend;

        public AddExpenseForm()
        {
            InitializeComponent();
            cashboxBackend = new Cashbox_backend();
            InitializeFormSettings();
        }

        private void InitializeFormSettings()
        {
            // Set default radio button selection
            CashRadio.Checked = true;

            // Add event handlers
            this.Load += AddExpenseForm_Load;
        }

        private void AddExpenseForm_Load(object sender, EventArgs e)
        {
            // Test database connection on form load
            if (!cashboxBackend.TestConnection())
            {
                MessageBox.Show("Unable to connect to database. Please check your connection settings.",
                              "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddExpenseButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string expenseName = ExpenseNameText.Content.Trim();
                decimal expenseAmount;
                string category = CashRadio.Checked ? "Cash" : "Non-Cash";

                if (decimal.TryParse(ExpenseAmountText.Content.Trim(), out expenseAmount))
                {
                    if (cashboxBackend.AddExpense(expenseName, expenseAmount, category))
                    {
                        MessageBox.Show("Expense added successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to add expense. Please try again.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid amount.", "Invalid Input",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ExpenseAmountText.Focus();
                }
            }
        }

        private bool ValidateInput()
        {
            // Check if expense name is empty
            if (string.IsNullOrWhiteSpace(ExpenseNameText.Content))
            {
                MessageBox.Show("Please enter an expense name.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ExpenseNameText.Focus();
                return false;
            }

            // Check if amount is empty
            if (string.IsNullOrWhiteSpace(ExpenseAmountText.Content))
            {
                MessageBox.Show("Please enter an expense amount.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ExpenseAmountText.Focus();
                return false;
            }

            // Check if amount is a valid decimal
            decimal amount;
            if (!decimal.TryParse(ExpenseAmountText.Content.Trim(), out amount))
            {
                MessageBox.Show("Please enter a valid numeric amount.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ExpenseAmountText.Focus();
                return false;
            }

            // Check if amount is positive
            if (amount <= 0)
            {
                MessageBox.Show("Please enter a positive amount.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ExpenseAmountText.Focus();
                return false;
            }

            // Check if neither radio button is selected (shouldn't happen with default selection)
            if (!CashRadio.Checked && !NonCashRadio.Checked)
            {
                MessageBox.Show("Please select a payment type.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            ExpenseNameText.Content = "";
            ExpenseAmountText.Content = "";
            CashRadio.Checked = true;
            NonCashRadio.Checked = false;
            ExpenseNameText.Focus();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for Enter key press to add expense
        private void ExpenseAmountText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, decimal point, and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            // Handle Enter key to add expense
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddExpenseButton_Click(sender, e);
            }
        }

        private void ExpenseNameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle Enter key to move to next field
            if (e.KeyChar == (char)Keys.Enter)
            {
                ExpenseAmountText.Focus();
            }
        }

        // Method to get current expense totals (useful for reporting)
        public void ShowExpenseTotals()
        {
            decimal cashTotal = cashboxBackend.GetTotalExpensesByCategory("Cash");
            decimal nonCashTotal = cashboxBackend.GetTotalExpensesByCategory("Non-Cash");
            decimal grandTotal = cashTotal + nonCashTotal;

            string message = $"Expense Totals:\n\n" +
                           $"Cash Expenses: ₱{cashTotal:N2}\n" +
                           $"Non-Cash Expenses: ₱{nonCashTotal:N2}\n" +
                           $"Total Expenses: ₱{grandTotal:N2}";

            MessageBox.Show(message, "Expense Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}