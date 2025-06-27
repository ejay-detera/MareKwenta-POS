using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.CashboxFolder
{
    public partial class EditExpense : Form
    {
        private Cashbox_backend cashboxBackend;
        private int expenseId;

        public EditExpense()
        {
            InitializeComponent();
            cashboxBackend = new Cashbox_backend();
            InitializeFormSettings();
        }

        private void EditExpense_Load(object sender, EventArgs e)
        {

        }
        private void InitializeFormSettings()
        {
            // Set default radio button selection
            CashRadio.Checked = true;

            // Set form properties
            this.Text = "Edit Expense";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public void LoadExpenseData(int id, string expenseName, decimal expenseAmount, string category)
        {
            expenseId = id;
            ExpenseNameText.Content = expenseName;
            ExpenseAmountText.Content = expenseAmount.ToString("F2");

            // Set the appropriate radio button based on category
            if (category.Equals("Cash", StringComparison.OrdinalIgnoreCase))
            {
                CashRadio.Checked = true;
                NonCashRadio.Checked = false;
            }
            else
            {
                NonCashRadio.Checked = true;
                CashRadio.Checked = false;
            }
        }

        private void ExpenseNameText_ContentChanged(object sender, EventArgs e)
        {

        }

        private void NonCashRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string expenseName = ExpenseNameText.Content.Trim();
                decimal expenseAmount;
                string category = CashRadio.Checked ? "Cash" : "Non-Cash";

                if (decimal.TryParse(ExpenseAmountText.Content.Trim(), out expenseAmount))
                {
                    if (cashboxBackend.UpdateExpense(expenseId, expenseName, expenseAmount, category))
                    {
                        MessageBox.Show("Expense updated successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update expense. Please try again.", "Error",
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

            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
        }
        private void ExpenseNameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle Enter key to move to next field
            if (e.KeyChar == (char)Keys.Enter)
            {
                ExpenseAmountText.Focus();
            }
        }
    }
}
