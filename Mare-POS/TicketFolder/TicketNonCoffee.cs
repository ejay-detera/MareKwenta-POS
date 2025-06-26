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
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 6;
            popup.ProductName = "Matcha Latte";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 6;
                string productName = "Matcha Latte";
                string category = "Non Coffee";

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
            popup.ProductId = 7;
            popup.ProductName = "Chocolate";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 7;
                string productName = "Chocolate";
                string category = "Non Coffee";

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
            popup.ProductId = 8;
            popup.ProductName = "Strawberry Frappe";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 8;
                string productName = "Strawberry Frappe";
                string category = "Non Coffee";

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
            popup.ProductId = 9;
            popup.ProductName = "Caramel Frappe";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 9;
                string productName = "Caramel Frappe";
                string category = "Non Coffee";

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
                string extras = popup.SelectedExtras.Count > 0 ? string.Join(", ", popup.SelectedExtras) : "None";

                // Display the result (or add to order/cart)
                MessageBox.Show($"Added {qty}x Americano\n" +
                                $"Size: {size}\n" +
                                $"Type: {type}\n" +
                                $"Extras: {extras}", "Order Summary");
            }
        }

        private void label39_Click_1(object sender, EventArgs e)
        {

        }

        private void cuiButton15_Click_1(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = 10;
            popup.ProductName = "Chocolate Chip Frappe";

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                // Popup selection
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
                List<string> extras = popup.SelectedExtras;
                string extrasStr = extras.Count > 0 ? string.Join(", ", extras) : "None";

                // Product info
                int productId = 10;
                string productName = "Chocolate Chip Frappe";
                string category = "Non Coffee";

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