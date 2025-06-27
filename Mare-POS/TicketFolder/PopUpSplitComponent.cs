using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Mare_POS
{
    public partial class PopUpSplitComponent : Form
    {
        private int splitCount = 2;
        private TicketForm parentForm;

        private int transactionNo;
        private decimal finalAmount;

        // Original constructor
        public PopUpSplitComponent(int transactionNo, decimal finalAmount)
        {
            InitializeComponent();
            this.transactionNo = transactionNo;
            this.finalAmount = finalAmount;

            btnPlus.Click += btnPlus_Click;
            btnMinus.Click += btnMinus_Click;

            txtAmount1.Leave += FormatCurrency;
            txtAmount2.Leave += FormatCurrency;
            txtAmount3.Leave += FormatCurrency;

            txtAmount1.KeyPress += txtAmount_KeyPress;
            txtAmount2.KeyPress += txtAmount_KeyPress;
            txtAmount3.KeyPress += txtAmount_KeyPress;

            UpdateSplitInputs();

            comboBox1.SelectedIndexChanged += PaymentDropdown_Changed;
            comboBox2.SelectedIndexChanged += PaymentDropdown_Changed;
            comboBox3.SelectedIndexChanged += PaymentDropdown_Changed;
        }

        private TicketForm ticketform = new TicketForm();
        public PopUpSplitComponent(TicketForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (splitCount > 2)
            {
                splitCount--;
                label3.Text = splitCount.ToString();
                UpdateSplitInputs();
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (splitCount < 3)
            {
                splitCount++;
                label3.Text = splitCount.ToString();
                UpdateSplitInputs();
            }
        }

        private void UpdateSplitInputs()
        {
            if (splitCount == 2)
            {
                paymentline3.Visible = false;
            }
            else if (splitCount == 3)
            {
                paymentline3.Visible = true;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect payment data from the form
                var payments = new List<(string Method, decimal Amount)>();

                // Add payments from visible inputs
                AddPaymentIfValid(comboBox1.Text, txtAmount1.Text, payments);
                AddPaymentIfValid(comboBox2.Text, txtAmount2.Text, payments);

                if (splitCount >= 3)
                {
                    AddPaymentIfValid(comboBox3.Text, txtAmount3.Text, payments);
                }

                // Validate that we have at least one payment
                if (payments.Count == 0)
                {
                    MessageBox.Show("Please enter at least one payment method and amount.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate total payment amount
                decimal totalPaid = payments.Sum(p => p.Amount);
                if (totalPaid < finalAmount)
                {
                    MessageBox.Show($"Payment is not enough. Required: ₱{finalAmount:0.00}, Paid: ₱{totalPaid:0.00}",
                        "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the existing FinalizeSplitPayment method from TicketForm
                if (parentForm != null)
                {
                    parentForm.FinalizeSplitPayment(payments);
                }
                else
                {
                    ticketform.FinalizeSplitPayment(payments);
                }

                // Show receipt after successful payment
                ShowReceipt(transactionNo);

                this.Close(); // Close the split payment popup
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPaymentIfValid(string method, string amountText, List<(string Method, decimal Amount)> payments)
        {
            if (string.IsNullOrEmpty(method) || string.IsNullOrEmpty(amountText))
                return;

            // Remove currency symbol and parse
            string cleanAmount = amountText.Replace("₱", "").Trim();
            if (decimal.TryParse(cleanAmount, out decimal amount) && amount > 0)
            {
                payments.Add((method, amount));
            }
        }

        private void ShowReceipt(int transactionNo)
        {
            ReceiptForm receipt = new ReceiptForm(transactionNo);
            receipt.Show();
        }

        private void FormatCurrency(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                if (decimal.TryParse(txt.Text.Replace("₱", "").Trim(), out decimal value))
                {
                    txt.Text = $"₱{value:0.00}";
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void PaymentDropdown_Changed(object sender, EventArgs e)
        {
            var selected = new HashSet<string>();

            ComboBox[] comboBoxes = { comboBox1, comboBox2, comboBox3 };

            foreach (ComboBox cmb in comboBoxes)
            {
                string method = cmb.Text;
                if (!string.IsNullOrEmpty(method))
                {
                    if (selected.Contains(method))
                    {
                        MessageBox.Show($"Duplicate payment method: {method} is already selected.", "Duplicate Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmb.SelectedIndex = -1; // clear selection
                        return;
                    }
                    selected.Add(method);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}