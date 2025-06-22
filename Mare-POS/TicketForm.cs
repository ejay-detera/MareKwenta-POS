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
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class TicketForm : UserControl
    {
        public event Action NavigateToTicketCoffee;
        public event Action NavigateToTicketForm;
        public TicketForm()
        {
            InitializeComponent();
        }

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnNonCoffee_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton24_Click(object sender, EventArgs e)
        {
            PopUpSplitComponent splitForm = new PopUpSplitComponent();
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
            // Create and show the ReceiptForm
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.ShowDialog(); // Use Show() if you don't want it modal
        }

        private void btnCafeLatte_Click(object sender, EventArgs e)
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

        private void cuiButton2_Click(object sender, EventArgs e)
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

        private void cuiButton3_Click(object sender, EventArgs e)
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

        private void cuiButton5_Click(object sender, EventArgs e)
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

        private void cuiButton17_Click(object sender, EventArgs e)
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

        private void cuiButton16_Click(object sender, EventArgs e)
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

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton15_Click_1(object sender, EventArgs e)
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

        private void cuiButton14_Click(object sender, EventArgs e)
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

        private void cuiButton4_Click(object sender, EventArgs e)
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

        private void cuiButton18_Click_1(object sender, EventArgs e)
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

        private void cuiButton27_Click(object sender, EventArgs e)
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

        private void cuiButton28_Click(object sender, EventArgs e)
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

        private void cuiButton13_Click_1(object sender, EventArgs e)
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

        private void cuiButton14_Click_1(object sender, EventArgs e)
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

        private void cuiButton15_Click_2(object sender, EventArgs e)
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

        private void cuiButton16_Click_1(object sender, EventArgs e)
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
    }
}
