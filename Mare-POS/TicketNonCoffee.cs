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
        public TicketNonCoffee()
        {
            InitializeComponent();
        }

        private void cuiButton25_Click(object sender, EventArgs e)
        {
            // Create and show the ReceiptForm
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.ShowDialog(); // Use Show() if you don't want it modal
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
    }
}
