using Mare_POS.Models;
using Mare_POS.Database;
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

        private List<Item> currentOrder = new List<Item>();

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
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form
            popup.ProductId = 11;
            popup.ProductName = "Tocilog";

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Popup selection
                int qty = popup.Quantity;

                // Product info
                int productId = 11;
                string productName = "Tocilog";
                string category = "Food";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId);
                decimal itemTotal = (basePrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form
            popup.ProductId = 12;
            popup.ProductName = "Garlic Rice";

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Popup selection
                int qty = popup.Quantity;

                // Product info
                int productId = 12;
                string productName = "Garlic Rice";
                string category = "Food";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId);
                decimal itemTotal = (basePrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form
            popup.ProductId = 13;
            popup.ProductName = "Pork Siomai Rice";

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Popup selection
                int qty = popup.Quantity;

                // Product info
                int productId = 13;
                string productName = "Pork Siomai Rice";
                string category = "Food";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId);
                decimal itemTotal = (basePrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form
            popup.ProductId = 14;
            popup.ProductName = "Hamsilog";

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Popup selection
                int qty = popup.Quantity;

                // Product info
                int productId = 14;
                string productName = "Hamsilog";
                string category = "Food";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId);
                decimal itemTotal = (basePrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }
    }
}
