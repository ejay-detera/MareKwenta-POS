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
    public partial class TicketNonCoffee : UserControl
    {
        private int transactionNo;
        private decimal finalAmount;
        public TicketNonCoffee()
        {
            InitializeComponent();
            this.transactionNo = transactionNo;
            this.finalAmount = finalAmount;
        }
        public event Action<Item> ItemAdded;
        //private List<Item> currentOrder = new List<Item>();

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
            string productName = "Matcha Latte";
            HandleNonCoffeeSelection(productName);
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            string productName = "Chocolate";
            HandleNonCoffeeSelection(productName);
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            string productName = "Strawberry Frappe";
            HandleNonCoffeeSelection(productName);
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            string productName = "Caramel Frappe";
            HandleNonCoffeeSelection(productName);
        }

        private void cuiButton15_Click_1(object sender, EventArgs e)
        {
            string productName = "Chocolate Chip Frappe";
            HandleNonCoffeeSelection(productName);
        }

        // Centralized method to handle non-coffee selection (similar to HandleFoodSelection in TicketFood)
        private void HandleNonCoffeeSelection(string productName)
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
                string category = "Non Coffee";

                // ✅ Get prices dynamically using the correct ProductID
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal itemTotal = basePrice * qty;

                // Debug info (remove after testing)
               // MessageBox.Show($"Debug Info:\nProductName: {productName}\nProductID: {productId}\nBase Price: {basePrice}", "Debug");

                // Add to cart
                var item = new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = "Non Coffee"
                };

                // ✅ Fire the event to notify TicketForm
                ItemAdded?.Invoke(item);
            }
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton15_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;

            }
        }

        private void label39_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}