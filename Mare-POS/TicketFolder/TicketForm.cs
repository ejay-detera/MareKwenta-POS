using Mare_POS.Database;
using Mare_POS.Models;
using Mare_POS.Ticket_Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class TicketForm : UserControl
    {
        public event Action NavigateToTicketCoffee;
        public event Action NavigateToTicketForm;

        private decimal currentDiscountAmount = 0;
        private decimal currentDiscountRate = 0;

        private int transactionNo;


        public TicketForm()
        {
            InitializeComponent();

            // Wire the event manually
            txtManualAmount.KeyUp += txtManualAmount_KeyUp;

            this.Load += TicketForm_Load;

            transactionNo = TicketPaymentBackend.GetNextTransactionNo();

        }

        private List<Item> currentOrder = new List<Item>();

        private decimal cashReceived = 0;

        private decimal GetSubtotal()
        {
            return currentOrder.Sum(item => item.Amount);
        }


        private void btnFood_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TicketFood allControl = new TicketFood();
            allControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(allControl);
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiButton8_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton15_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void btnCoffee_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TicketCoffee coffeeControl = new TicketCoffee();
            coffeeControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(coffeeControl);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            TicketForm allControl = new TicketForm();
            allControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(allControl);
        }

        private void btnAmericano_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cuiButton18_Click(object sender, EventArgs e)
        {

        }

        private void cuiPanel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void btnCoffee_Click_1(object sender, EventArgs e)
        {
            //panelMain.Controls.Clear();

            //TicketCoffee coffeeControl = new TicketCoffee();
            //coffeeControl.AutoScroll = true; // allow scroll if content exceeds visible area
            //coffeeControl.Dock = DockStyle.Fill; // <-- Remove this
            //coffeeControl.Anchor = AnchorStyles.Top | AnchorStyles.Left; // optional

            //panelMain.Controls.Add(coffeeControl);

            NavigateToTicketCoffee?.Invoke();


        }

        private void btnAmericano_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void btnNonCoffee_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton24_Click(object sender, EventArgs e)
        {
            PopUpSplitComponent splitForm = new PopUpSplitComponent(this);
            splitForm.StartPosition = FormStartPosition.CenterParent; // Center it over parent form

            if (splitForm.ShowDialog(this) == DialogResult.OK)
            {
                // Access public properties from SplitForm
                //string part1 = splitForm.Part1;
                //string part2 = splitForm.Part2;

                //MessageBox.Show($"Split result:\nPart 1: {part1}\nPart 2: {part2}");
            }
        }

        private void cuiButton25_Click(object sender, EventArgs e)
        {
            decimal finalAmount = Convert.ToDecimal(labelSubtotal.Text.Replace("₱", "").Trim());
            decimal cashReceived = Convert.ToDecimal(labelCashReceived.Text.Replace("₱", "").Replace(",", "").Trim());
            decimal change = cashReceived - finalAmount;

            TicketPaymentBackend.SavePayment(transactionNo, finalAmount, 0, 0, change);
            ShowReceipt(transactionNo);
        }

        private void btnCafeLatte_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton17_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton16_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton15_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton14_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton13_Click(object sender, EventArgs e)
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

        private void cuiButton26_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                //string size = popup.SelectedSize ?? "N/A";
                //string type = popup.SelectedType ?? "N/A";
                //int qty = popup.Quantity;
                //string extras = popup.SelectedExtras.Count > 0 ? string.Join(", ", popup.SelectedExtras) : "None";

                // Display the result (or add to order/cart)
                //MessageBox.Show($"Added {qty}x Americano\n" +
                // $"Size: {size}\n" +
                // $"Type: {type}\n" +
                // $"Extras: {extras}", "Order Summary");
            }
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton21_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                //string size = popup.SelectedSize ?? "N/A";
                //string type = popup.SelectedType ?? "N/A";
                //int qty = popup.Quantity;
                //string extras = popup.SelectedExtras.Count > 0 ? string.Join(", ", popup.SelectedExtras) : "None";

                // Display the result (or add to order/cart)
                //MessageBox.Show($"Added {qty}x Americano\n" +
                // $"Size: {size}\n" +
                // $"Type: {type}\n" +
                // $"Extras: {extras}", "Order Summary");
            }
        }

        private void cuiButton20_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                //string size = popup.SelectedSize ?? "N/A";
                //string type = popup.SelectedType ?? "N/A";
                //int qty = popup.Quantity;
                //string extras = popup.SelectedExtras.Count > 0 ? string.Join(", ", popup.SelectedExtras) : "None";

                // Display the result (or add to order/cart)
                //MessageBox.Show($"Added {qty}x Americano\n" +
                // $"Size: {size}\n" +
                // $"Type: {type}\n" +
                // $"Extras: {extras}", "Order Summary");
            }
        }

        private void cuiButton19_Click(object sender, EventArgs e)
        {
            var popup = new FoodQuantity();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                //string size = popup.SelectedSize ?? "N/A";
                //string type = popup.SelectedType ?? "N/A";
                //int qty = popup.Quantity;
                //string extras = popup.SelectedExtras.Count > 0 ? string.Join(", ", popup.SelectedExtras) : "None";

                // Display the result (or add to order/cart)
                //MessageBox.Show($"Added {qty}x Americano\n" +
                // $"Size: {size}\n" +
                // $"Type: {type}\n" +
                // $"Extras: {extras}", "Order Summary");
            }
        }

        private void btnAll_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            pnlChange.Visible = false;
            pnlDiscount.Visible = true;
        }

        private void cuiPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton4_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton18_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton27_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton28_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton13_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton14_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton15_Click_2(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton16_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void AddItemToTicketPanel(Item item)
        {
            Panel panelClone = new Panel
            {
                Size = panelTemplateCartItem.Size,
                BackColor = panelTemplateCartItem.BackColor,
                Margin = panelTemplateCartItem.Margin,
                BorderStyle = panelTemplateCartItem.BorderStyle
            };

            // Clone labels from the template
            foreach (Control ctrl in panelTemplateCartItem.Controls)
            {
                if (ctrl is Label templateLabel)
                {
                    Label lbl = new Label
                    {
                        AutoSize = templateLabel.AutoSize,
                        Font = templateLabel.Font,
                        ForeColor = templateLabel.ForeColor,
                        Location = templateLabel.Location,
                        Size = templateLabel.Size
                    };

                    switch (templateLabel.Name)
                    {
                        case "lblProductNameTemplate":
                            lbl.Text = item.ProductName;
                            break;
                        case "lblSizeTemplate":
                            lbl.Text = item.ProductSize;
                            break;
                        case "lblTypeTemplate":
                            lbl.Text = item.ProductType;
                            break;
                        case "lblExtrasTemplate":
                            lbl.Text = item.Extras != null && item.Extras.Any() ? string.Join(", ", item.Extras) : "-";
                            break;
                        case "lblQuantityTemplate":
                            lbl.Text = $"x{item.Quantity}";
                            break;
                        case "lblPriceTemplate":
                            lbl.Text = $"₱{item.Amount:0.00}";
                            break;
                        default:
                            lbl.Text = templateLabel.Text;
                            break;
                    }

                    panelClone.Controls.Add(lbl);
                }
            }

            flowTicketPanel.Controls.Add(panelClone);
        }

        private void UpdateSubtotalLabel()
        {
            decimal subtotal = currentOrder.Sum(item => item.Amount);
            labelSubtotal.Text = $"₱{subtotal:0.00}";
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            if (sender is Control btn && btn.Tag != null)
            {
                if (decimal.TryParse(btn.Tag.ToString(), out decimal value))
                {
                    cashReceived += value;
                    UpdateCashAndChangeUI();
                }
            }
        }

        private void txtManualAmount_KeyUp(object sender, KeyEventArgs e)
        {
            string input = txtManualAmount.Text.Replace("₱", "").Trim();

            if (decimal.TryParse(input, out decimal value))
            {
                txtManualAmount.TextChanged -= txtManualAmount_TextChanged; // Temporarily unhook
                txtManualAmount.Text = $"₱{value}";
                txtManualAmount.SelectionStart = txtManualAmount.Text.Length;
                txtManualAmount.TextChanged += txtManualAmount_TextChanged;

                cashReceived = value;
                UpdateCashAndChangeUI();
            }
        }

        private void btnClearPayment_Click(object sender, EventArgs e)
        {
            cashReceived = 0;
            UpdateCashAndChangeUI();
            if (txtManualAmount != null) txtManualAmount.Text = "";
        }

        private void UpdateCashAndChangeUI()
        {
            labelCashReceived.Text = $"₱{cashReceived:0.00}";
            decimal change = cashReceived - GetSubtotal();
            labelChange.Text = $"₱{(change >= 0 ? change : 0):0.00}";
        }

        private void txtManualAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void cuiButton4_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton18_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton27_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton28_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton13_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton14_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton15_Click_2(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton16_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void AddItemToTicketPanel(Item item)
        {
            Panel panelClone = new Panel
            {
                Size = panelTemplateCartItem.Size,
                BackColor = panelTemplateCartItem.BackColor,
                Margin = panelTemplateCartItem.Margin,
                BorderStyle = panelTemplateCartItem.BorderStyle
            };

            // Clone labels from the template
            foreach (Control ctrl in panelTemplateCartItem.Controls)
            {
                if (ctrl is Label templateLabel)
                {
                    Label lbl = new Label
                    {
                        AutoSize = templateLabel.AutoSize,
                        Font = templateLabel.Font,
                        ForeColor = templateLabel.ForeColor,
                        Location = templateLabel.Location,
                        Size = templateLabel.Size
                    };

                    switch (templateLabel.Name)
                    {
                        case "lblProductNameTemplate":
                            lbl.Text = item.ProductName;
                            break;
                        case "lblSizeTemplate":
                            lbl.Text = item.ProductSize;
                            break;
                        case "lblTypeTemplate":
                            lbl.Text = item.ProductType;
                            break;
                        case "lblExtrasTemplate":
                            lbl.Text = item.Extras != null && item.Extras.Any() ? string.Join(", ", item.Extras) : "-";
                            break;
                        case "lblQuantityTemplate":
                            lbl.Text = $"x{item.Quantity}";
                            break;
                        case "lblPriceTemplate":
                            lbl.Text = $"₱{item.Amount:0.00}";
                            break;
                        default:
                            lbl.Text = templateLabel.Text;
                            break;
                    }

                    panelClone.Controls.Add(lbl);
                }
            }

            flowTicketPanel.Controls.Add(panelClone);
        }

        private void UpdateSubtotalLabel()
        {
            decimal subtotal = currentOrder.Sum(x => x.Amount);
            decimal finalTotal = subtotal - currentDiscountAmount;
            labelSubtotal.Text = $"₱{finalTotal:0.00}";
        }



        private void btnMoney_Click(object sender, EventArgs e)
        {
            if (sender is Control btn && btn.Tag != null)
            {
                if (decimal.TryParse(btn.Tag.ToString(), out decimal value))
                {
                    cashReceived += value;

                    // Get the latest total amount after discount
                    decimal totalAmount = currentOrder.FirstOrDefault(x => x.Amount > 0)?.Amount ?? 0;
                    totalAmount = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero);

                    decimal finalTotal = totalAmount - currentDiscountAmount;
                    finalTotal = Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);

                    UpdateCashAndChangeUI(finalTotal); // ✅ Now passes the real total
                }
            }
        }

        private void txtManualAmount_KeyUp(object sender, KeyEventArgs e)
        {
            string input = txtManualAmount.Text.Replace("₱", "").Trim();

            if (decimal.TryParse(input, out decimal value))
            {
                txtManualAmount.TextChanged -= txtManualAmount_TextChanged; // Temporarily unhook
                txtManualAmount.Text = $"₱{value}";
                txtManualAmount.SelectionStart = txtManualAmount.Text.Length;
                txtManualAmount.TextChanged += txtManualAmount_TextChanged;

                cashReceived = value;
                UpdateCashAndChangeUI(GetFinalTotal());
            }
        }

        private void btnClearPayment_Click(object sender, EventArgs e)
        {
            cashReceived = 0;
            UpdateCashAndChangeUI(GetFinalTotal());
            if (txtManualAmount != null) txtManualAmount.Text = "";
        }

        private void UpdateCashAndChangeUI(decimal finalTotal)
        {
            labelCashReceived.Text = $"₱{cashReceived:0.00}";

            decimal change = cashReceived - finalTotal;
            change = Math.Round(change, 2, MidpointRounding.AwayFromZero);

            labelChange.Text = $"₱{(change >= 0 ? change : 0):0.00}";
        }


        private void txtManualAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlChange.Visible = true;
            pnlDiscount.Visible = false;
        }
        private void TicketForm_Load(object sender, EventArgs e)
        {
            // Make sure you're referencing the correct control placed on the form
            discountButton2.DiscountClicked += percent => ApplyDiscount(discountRate: percent);

            discountButton2.PesoDiscountEntered += amount =>
            {
                ApplyDiscount(discountAmount: amount);
            };

            discountButton2.PercentDiscountEntered += percent =>
            {
                ApplyDiscount(discountRate: percent);
            };

            discountButton2.DiscountCleared += () =>
            {
                currentDiscountAmount = 0;
                currentDiscountRate = 0;
                UpdateSubtotalLabel();
                UpdateCashAndChangeUI(GetFinalTotal());
            };

            transactionNo = TicketPaymentBackend.GetNextTransactionNo(); // this sets a fresh TransactionNo
        }

        private void ApplyDiscount(decimal discountRate = 0, decimal discountAmount = 0)
        {
            decimal subtotal = currentOrder.Sum(item => item.Amount);
            subtotal = Math.Round(subtotal, 2, MidpointRounding.AwayFromZero);

            if (discountAmount > 0)
            {
                currentDiscountAmount = Math.Round(discountAmount, 2, MidpointRounding.AwayFromZero);
                currentDiscountRate = 0;
            }
            else if (discountRate > 0)
            {
                currentDiscountRate = discountRate;
                currentDiscountAmount = Math.Round(subtotal * (discountRate / 100), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                currentDiscountAmount = 0;
                currentDiscountRate = 0;
            }

            decimal finalTotal = subtotal - currentDiscountAmount;
            finalTotal = Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);

            labelSubtotal.Text = $"₱{finalTotal:0.00}";
            UpdateCashAndChangeUI(finalTotal);
        }

        public decimal GetFinalTotal()
        {
            return currentOrder.Sum(x => x.Amount) - currentDiscountAmount;
        }

        private void cuiButton23_Click(object sender, EventArgs e)
        {
            decimal finalAmount = Convert.ToDecimal(labelSubtotal.Text.Replace("₱", "").Trim());
            decimal change = 0;

            TicketPaymentBackend.SavePayment(transactionNo, 0, 0, finalAmount, change);

            ShowReceipt(transactionNo);
        }

        private void cuiButton22_Click(object sender, EventArgs e)
        {
            decimal finalAmount = Convert.ToDecimal(labelSubtotal.Text.Replace("₱", "").Trim());
            decimal change = 0;

            TicketPaymentBackend.SavePayment(transactionNo, 0, finalAmount, 0, change);

            ShowReceipt(transactionNo);
        }

        public void FinalizeSplitPayment(List<(string Method, decimal Amount)> payments)
        {
            string transactionNo = Guid.NewGuid().ToString();

            decimal total = payments.Sum(p => p.Amount);
            decimal cash = 0, gcash = 0, maya = 0;

            foreach (var payment in payments)
            {
                switch (payment.Method)
                {
                    case "Cash": cash += payment.Amount; break;
                    case "GCash": gcash += payment.Amount; break;
                    case "Maya": maya += payment.Amount; break;
                }
            }
        }

        private void ApplyPesoDiscount(decimal peso)
        {
            MessageBox.Show($"ApplyPesoDiscount received: {peso}");
            currentDiscountAmount = peso;
            currentDiscountRate = 0;
            UpdateSubtotalLabel();
            UpdateCashAndChangeUI(GetFinalTotal());
        }

        private void ApplyPercentDiscount(decimal percent)
        {
            decimal subtotal = currentOrder.Sum(x => x.Amount);
            currentDiscountRate = percent;
            currentDiscountAmount = subtotal * (percent / 100m);
            UpdateSubtotalLabel();
            UpdateCashAndChangeUI(GetFinalTotal());
        }

        private void ShowReceipt(int transactionNo)
        {
            ReceiptForm receipt = new ReceiptForm(transactionNo);
            receipt.Show();
        }



        private void cuiButton1_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton4_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton18_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton27_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton28_Click(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton13_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton14_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton15_Click_2(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void cuiButton16_Click_1(object sender, EventArgs e)
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

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void AddItemToTicketPanel(Item item)
        {
            Panel panelClone = new Panel
            {
                Size = panelTemplateCartItem.Size,
                BackColor = panelTemplateCartItem.BackColor,
                Margin = panelTemplateCartItem.Margin,
                BorderStyle = panelTemplateCartItem.BorderStyle
            };

            // Clone labels from the template
            foreach (Control ctrl in panelTemplateCartItem.Controls)
            {
                if (ctrl is Label templateLabel)
                {
                    Label lbl = new Label
                    {
                        AutoSize = templateLabel.AutoSize,
                        Font = templateLabel.Font,
                        ForeColor = templateLabel.ForeColor,
                        Location = templateLabel.Location,
                        Size = templateLabel.Size
                    };

                    switch (templateLabel.Name)
                    {
                        case "lblProductNameTemplate":
                            lbl.Text = item.ProductName;
                            break;
                        case "lblSizeTemplate":
                            lbl.Text = item.ProductSize;
                            break;
                        case "lblTypeTemplate":
                            lbl.Text = item.ProductType;
                            break;
                        case "lblExtrasTemplate":
                            lbl.Text = item.Extras != null && item.Extras.Any() ? string.Join(", ", item.Extras) : "-";
                            break;
                        case "lblQuantityTemplate":
                            lbl.Text = $"x{item.Quantity}";
                            break;
                        case "lblPriceTemplate":
                            lbl.Text = $"₱{item.Amount:0.00}";
                            break;
                        default:
                            lbl.Text = templateLabel.Text;
                            break;
                    }

                    panelClone.Controls.Add(lbl);
                }
            }

            flowTicketPanel.Controls.Add(panelClone);
        }

        private void UpdateSubtotalLabel()
        {
            decimal subtotal = currentOrder.Sum(item => item.Amount);
            labelSubtotal.Text = $"₱{subtotal:0.00}";
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            if (sender is Control btn && btn.Tag != null)
            {
                if (decimal.TryParse(btn.Tag.ToString(), out decimal value))
                {
                    cashReceived += value;
                    UpdateCashAndChangeUI();
                }
            }
        }

        private void txtManualAmount_KeyUp(object sender, KeyEventArgs e)
        {
            string input = txtManualAmount.Text.Replace("₱", "").Trim();

            if (decimal.TryParse(input, out decimal value))
            {
                txtManualAmount.TextChanged -= txtManualAmount_TextChanged; // Temporarily unhook
                txtManualAmount.Text = $"₱{value}";
                txtManualAmount.SelectionStart = txtManualAmount.Text.Length;
                txtManualAmount.TextChanged += txtManualAmount_TextChanged;

                cashReceived = value;
                UpdateCashAndChangeUI();
            }
        }

        private void btnClearPayment_Click(object sender, EventArgs e)
        {
            cashReceived = 0;
            UpdateCashAndChangeUI();
            if (txtManualAmount != null) txtManualAmount.Text = "";
        }

        private void UpdateCashAndChangeUI()
        {
            labelCashReceived.Text = $"₱{cashReceived:0.00}";
            decimal change = cashReceived - GetSubtotal();
            labelChange.Text = $"₱{(change >= 0 ? change : 0):0.00}";
        }

        private void txtManualAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
