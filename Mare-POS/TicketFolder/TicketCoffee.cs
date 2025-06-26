using Mare_POS.Database;
using Mare_POS.Models;
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

        private List<Item> currentOrder = new List<Item>();

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
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 1;
            popup.ProductName = "Americano";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 1;
                string productName = "Americano";
                string category = "Coffee";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal extrasPrice = ProductDataAccess.GetExtrasTotal(extras);
                decimal itemTotal = (basePrice + extrasPrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Extras = extras,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Size: {size}\nType: {type}\nExtras: {extrasStr}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 2;
            popup.ProductName = "Cafe Latte";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 2;
                string productName = "Cafe Latte";
                string category = "Coffee";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal extrasPrice = ProductDataAccess.GetExtrasTotal(extras);
                decimal itemTotal = (basePrice + extrasPrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Extras = extras,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Size: {size}\nType: {type}\nExtras: {extrasStr}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 3;
            popup.ProductName = "Caramel Macchiato";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 3;
                string productName = "Caramel Macchiato";
                string category = "Coffee";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal extrasPrice = ProductDataAccess.GetExtrasTotal(extras);
                decimal itemTotal = (basePrice + extrasPrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Extras = extras,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Size: {size}\nType: {type}\nExtras: {extrasStr}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 4;
            popup.ProductName = "Mocha";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 4;
                string productName = "Mocha";
                string category = "Coffee";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal extrasPrice = ProductDataAccess.GetExtrasTotal(extras);
                decimal itemTotal = (basePrice + extrasPrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Extras = extras,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Size: {size}\nType: {type}\nExtras: {extrasStr}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }

        private void cuiButton5_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 5;
            popup.ProductName = "Cappucino";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 5;
                string productName = "Cappucino";
                string category = "Coffee";

                // ✅ Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal extrasPrice = ProductDataAccess.GetExtrasTotal(extras);
                decimal itemTotal = (basePrice + extrasPrice) * qty;

                // Add to cart
                currentOrder.Add(new Item
                {
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = size,
                    ProductType = type,
                    Extras = extras,
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = category
                });

                MessageBox.Show(
                    $"✅ Added {qty}x {productName}\n" +
                    $"Size: {size}\nType: {type}\nExtras: {extrasStr}\n" +
                    $"Subtotal: ₱{itemTotal}",
                    "Added to Order"
                );
            }
        }
    }
}