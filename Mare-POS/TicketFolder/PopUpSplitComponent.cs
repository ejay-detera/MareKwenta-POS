using Mare_POS.Database;
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
            // Initialize payment amounts
            decimal cash = 0, gcash = 0, maya = 0, charge = 0;

            // Read all 3 dropdown-amount pairs
            ApplyPayment(comboBox1.Text, txtAmount1.Text, ref cash, ref gcash, ref maya);
            ApplyPayment(comboBox2.Text, txtAmount2.Text, ref cash, ref gcash, ref maya);
            ApplyPayment(comboBox3.Text, txtAmount3.Text, ref cash, ref gcash, ref maya);

            // Total entered
            decimal totalPaid = cash + gcash + maya + charge;

            // Validate payment
            if (totalPaid < finalAmount)
            {
                MessageBox.Show("Payment is not enough.");
                return;
            }

            // Compute change
            decimal change = totalPaid - finalAmount;

            // Save to database
            TicketPaymentBackend.SavePayment(transactionNo, cash, gcash, maya, change);

            // Show receipt
            ReceiptForm receipt = new ReceiptForm(transactionNo);
            receipt.Show();

            // Close popup
            this.Close();
        }

        private void ApplyPayment(string method, string amountText, ref decimal cash, ref decimal gcash, ref decimal maya)
        {
            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
                return;

            switch (method)
            {
                case "Cash":
                    cash += amount;
                    break;
                case "GCash":
                    gcash += amount;
                    break;
                case "Maya":
                    maya += amount;
                    break;
            }
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

    }
}