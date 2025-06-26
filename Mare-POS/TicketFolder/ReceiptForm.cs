using Mare_POS.Database;
using Mare_POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class ReceiptForm : Form
    {
        private int transactionNo;

        public ReceiptForm(int transactionNo)
        {

            InitializeComponent();
            LoadReceiptDetails(transactionNo);
        }

        private void LoadReceiptDetails(int transactionNo)

        {
            List<Ticket> items = ReceiptBackend.GetReceiptItems(transactionNo);
            if (items == null || items.Count == 0)
            {
                MessageBox.Show("No receipt data found.");
                return;
            }

            Ticket first = items[0];

            lblPOS.Text = "POS: POS 1"; // if POS is fixed

            // Populate bottom labels
            lblDate.Text = first.Date.ToString("M/d/yy");
            lblTransaction.Text = $"#{first.TransactionNo}";

            // Populate payment breakdown
            lblCash.Text = first.CashAmount > 0 ? $"₱ {first.CashAmount:N2}" : "₱";
            lblGCash.Text = first.GcashAmount > 0 ? $"₱ {first.GcashAmount:N2}" : "₱";
            lblMaya.Text = first.MayaAmount > 0 ? $"₱ {first.MayaAmount:N2}" : "₱";
            lblChange.Text = $"₱ {first.Change:N2}";
            lblTotal.Text = $"₱ {first.TotalAmount:N2}";

            // Clear and populate items in FlowLayoutPanel
            flow_receipt_info.Controls.Clear();

            foreach (var item in items)
            {
                decimal unitPrice = item.ProductQuantity > 0 ? item.SubTotal / item.ProductQuantity : 0;
                AddReceiptItem(item.ProductName, item.ProductQuantity, unitPrice, item.SubTotal);
            }
        }

        private void AddReceiptItem(string name, int qty, decimal price, decimal total)
        {
            Label label = new Label();
            label.Text = $"{qty}x {name} @ ₱{price:N2} = ₱{total:N2}";
            label.Font = new Font("Segoe UI", 9);
            label.AutoSize = true;

            flow_receipt_info.Controls.Add(label);
        }


        private void ReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}