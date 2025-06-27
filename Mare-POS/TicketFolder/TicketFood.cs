using Mare_POS.Ticket_Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mare_POS.TicketFolder.Database;
using Mare_POS.TicketFolder.Models;

namespace Mare_POS
{
    public partial class TicketFood : UserControl
    {
        private int transactionNo;
        private decimal finalAmount;

        public TicketFood()
        {
            InitializeComponent();
            this.transactionNo = transactionNo;
            this.finalAmount = finalAmount;

        }
        public event Action<Item> ItemAdded;
        // private List<Item> currentOrder = new List<Item>();

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
            string productName = "Tocilog";
            HandleFoodSelection(productName);
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            string productName = "Garlic Rice";
            HandleFoodSelection(productName);
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            string productName = "Pork Siomai Rice";
            HandleFoodSelection(productName);
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            string productName = "Beef Pares";
            HandleFoodSelection(productName);
        }

        // Centralized method to handle food selection
        private void HandleFoodSelection(string productName)
        {
            // Get ProductID dynamically from database
            int productId = ProductDataAccess.GetProductId(productName);

            if (productId == 0)
            {
                MessageBox.Show($"Product '{productName}' not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = productId;
            popup.ProductName = productName;

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                int qty = popup.Quantity;

                // Product info
                string category = "Food";

                // ✅ Get prices dynamically using the correct ProductID
                decimal basePrice = ProductDataAccess.GetBasePrice(productId);
                decimal itemTotal = (basePrice) * qty;

                // Debug info (remove after testing)
                //MessageBox.Show($"Debug Info:\nProductName: {productName}\nProductID: {productId}\nBase Price: {basePrice}", "Debug");

                // Add to cart
                var item = new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = "Food",
                    ProductSize = "N/A",        // ✅ Food items don't have size
                    ProductType = "N/A",       // ✅ Food items don't have type
                    Extras = new List<string>() // ✅ Food items typically don't have extras
                };

                // ✅ Fire the event to notify TicketForm
                ItemAdded?.Invoke(item);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}