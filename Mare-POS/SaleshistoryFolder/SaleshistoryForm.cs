using MareKwenta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.SaleshistoryFolder
{
    public partial class SaleshistoryForm : UserControl
    {
        SalesHistoryBackend backend;

        public SaleshistoryForm()
        {
            InitializeComponent();
            backend = new SalesHistoryBackend();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Example action: Show a message box
            MessageBox.Show("Price label clicked.");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Example action: Show order number
            MessageBox.Show("Order number clicked.");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Custom drawing code or leave blank
        }

        private void cuiPanel2_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Custom drawing code or leave blank
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void record_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string input = cuiTextBox1.Content?.Trim();
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Raw input: '{input}'");

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Please enter an Order No.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isNumeric = int.TryParse(input, out int ticketId);

                Console.WriteLine($"[DEBUG] TryParse result: {isNumeric}, Parsed ID: {ticketId}");

                if (isNumeric)
                {
                    SalesHistoryBackend backend = new SalesHistoryBackend();
                    var ticket = backend.GetTicketDetails(ticketId);

                    if (ticket != null)
                    {
                        label5.Text = $"#{ticket.TicketID}";
                        label7.Text = $"Employee Name: {ticket.EmployeeName}";
                        label9.Text = $"POS: POS 1";

                        label13.Text = ticket.ProductName;
                        label10.Text = $"Quantity: {ticket.ProductQuantity}";
                        label11.Text = $"Size: {ticket.Size} / {ticket.Type} (₱{ticket.UnitPrice:0.00})";
                        label25.Text = $"₱{ticket.TotalAmount:0.00}";

                        label18.Text = $"₱{ticket.CashAmount:0.00}";
                        label20.Text = $"₱{ticket.GcashAmount:0.00}";
                        label32.Text = $"₱{ticket.MayaAmount:0.00}";
                        label33.Text = $"₱{ticket.Change:0.00}";
                        label24.Text = ticket.Date.ToString("dd/MM/yyyy h:mm tt");
                    }
                    else
                    {
                        MessageBox.Show("Ticket not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid Ticket ID (numbers only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_ContentChanged(object sender, EventArgs e)
        {

        }
    }
}

