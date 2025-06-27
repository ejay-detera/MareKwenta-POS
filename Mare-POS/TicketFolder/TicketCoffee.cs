using Mare_POS.TicketFolder.Database;
using Mare_POS.TicketFolder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Mare_POS.Ticket_Components
{
    public partial class TicketCoffee : UserControl
    {
        private int transactionNo;
        private decimal finalAmount;

        public TicketCoffee()
        {
            InitializeComponent();
            this.transactionNo = transactionNo;
            this.finalAmount = finalAmount;
        }
        public event Action<Item> ItemAdded;
        //private List<Item> currentOrder = new List<Item>();

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton25_Click(object sender, EventArgs e)
        {
            // Create and show the ReceiptForm
            ReceiptForm receiptForm = new ReceiptForm(transactionNo);
            receiptForm.ShowDialog(); // Use Show() if you don't want it modal
        }

        private void cuiButton24_Click(object sender, EventArgs e)
        {
            PopUpSplitComponent splitForm = new PopUpSplitComponent(transactionNo, finalAmount);
            splitForm.StartPosition = FormStartPosition.CenterParent; // Center it over parent form

            if (splitForm.ShowDialog(this) == DialogResult.OK)
            {
                // Access public properties from SplitForm
                //string part1 = splitForm.Part1;
                //string part2 = splitForm.Part2;

                //MessageBox.Show($"Split result:\nPart 1: {part1}\nPart 2: {part2}");
            }
        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {
            string productName = "Americano";
            HandleProductSelection(productName);
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            string productName = "Cafe Latte";
            HandleProductSelection(productName);
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            string productName = "Caramel Macchiato";
            HandleProductSelection(productName);
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            string productName = "Mocha";
            HandleProductSelection(productName);
        }

        private void cuiButton5_Click(object sender, EventArgs e)
        {
            string productName = "Cappuccino";
            HandleProductSelection(productName);
        }

        // Centralized method to handle product selection
        private void HandleProductSelection(string productName)
        {
            // Get ProductID dynamically from database
            int productId = ProductDataAccess.GetProductId(productName);

            if (productId == 0)
            {
                MessageBox.Show($"Product '{productName}' not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = productId;
            popup.ProductName = productName;

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;

                // Product info
                string category = "Coffee";

                // ✅ Get prices dynamically using the correct ProductID
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal itemTotal = basePrice * qty;

                // Debug info (remove after testing)
                //MessageBox.Show($"Debug Info:\nProductName: {productName}\nProductID: {productId}\nSize: {size}\nType: {type}\nBase Price: {basePrice}", "Debug");

                // Add to cart
                var item = new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = "Coffee"
                };
                // ✅ DEBUG: Check if event has subscribers before firing
                if (ItemAdded != null)
                {
                    //MessageBox.Show($"ItemAdded event has {ItemAdded.GetInvocationList().Length} subscribers. Firing event...");
                    ItemAdded?.Invoke(item);
                    //MessageBox.Show("Event fired successfully!");
                }
                else
                {
                    MessageBox.Show("ERROR: ItemAdded event is NULL! No subscribers attached!");
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}