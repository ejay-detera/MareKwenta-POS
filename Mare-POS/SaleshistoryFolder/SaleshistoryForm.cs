using CuoreUI.Controls;
using Mare_POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mare_POS.Properties;


namespace Mare_POS.SaleshistoryFolder
{
    public partial class SaleshistoryForm : UserControl
    {
        SalesHistoryBackend backend;

        public SaleshistoryForm()
        {
            InitializeComponent();
            backend = new SalesHistoryBackend();
            this.Load += new System.EventHandler(this.SalesHistoryForm_Load);
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
            if (int.TryParse(cuiTextBox1.Content?.Trim(), out int transactionNo))
            {
                DisplayReceiptByTransactionNo(transactionNo);
            }
            else
            {
                MessageBox.Show("Please enter a valid transaction number.");
            }
        }
        private void DisplayReceiptByTransactionNo(int transactionNo)
        {
            SalesHistoryBackend backend = new SalesHistoryBackend();

            int ticketID = backend.GetFirstTicketIDByTransactionNo(transactionNo);

            if (ticketID > 0)
            {
                DisplayReceipt(ticketID); 
            }
            else
            {
                MessageBox.Show($"Transaction #{transactionNo} not found.");
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_ContentChanged(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_ContentChanged_1(object sender, EventArgs e)
        {

        }
        private void LoadTicketHistory()
        {
            flowLayoutPanel1.Controls.Clear();

            var backend = new SalesHistoryBackend();
            var summaries = backend.GetAllTicketSummaries();

            // Group by formatted date string (e.g. "Saturday 25 May 2025")
            var groupedByDate = summaries
                .GroupBy(t => t.Date.ToString("dddd d MMMM yyyy"))
                .OrderByDescending(g => DateTime.Parse(g.Key)); // Sort groups by date

            foreach (var group in groupedByDate)
            {
                // Date
                var dateLabel = new Label
                {
                    Text = group.Key,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.Green,
                    AutoSize = true,
                    Padding = new Padding(10, 10, 5, 2)
                };
                flowLayoutPanel1.Controls.Add(dateLabel);

                foreach (var ticket in group)
                {
                    var ticketPanel = new Panel
                    {
                        Height = 90,  
                        Width = flowLayoutPanel1.Width - 60,
                        BackColor = Color.White,
                        Margin = new Padding(15, 5, 15, 5),
                        BorderStyle = BorderStyle.None,  
                        Cursor = Cursors.Hand,
                        Tag = ticket.TicketID
                    };

                    // Draw custom brown border using Paint event
                    ticketPanel.Paint += (s, e) =>
                    {
                        ControlPaint.DrawBorder(e.Graphics, ticketPanel.ClientRectangle,
                            Color.FromArgb(102, 57, 19), 2, ButtonBorderStyle.Solid,
                            Color.FromArgb(102, 57, 19), 2, ButtonBorderStyle.Solid,
                            Color.FromArgb(102, 57, 19), 2, ButtonBorderStyle.Solid,
                            Color.FromArgb(102, 57, 19), 2, ButtonBorderStyle.Solid);
                    };

                    var icon = new PictureBox
                    {
                        Image = Properties.Resources.receipt_icon,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = new Point(10, 20),
                        Size = new Size(35, 35)  
                    };
                    ticketPanel.Controls.Add(icon);

                    var lblAmount = new Label
                    {
                        Text = $"₱{ticket.TotalAmount:F2}",
                        Font = new Font("Segoe UI", 15, FontStyle.Bold),
                        Location = new Point(55, 15),
                        AutoSize = true,
                        ForeColor = Color.FromArgb(102, 57, 19)
                    };
                    ticketPanel.Controls.Add(lblAmount);

                    var lblTime = new Label
                    {
                        Text = ticket.Date.ToString("h:mm tt"),
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(55, 50),
                        AutoSize = true,
                        ForeColor = Color.FromArgb(102, 57, 19)
                    };
                    ticketPanel.Controls.Add(lblTime);

                    var ticketNoLabel = new Label
                    {
                        Text = $"#{ticket.TransactionNo}",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.FromArgb(102, 57, 19),
                        AutoSize = true
                    };
                    ticketNoLabel.Location = new Point(ticketPanel.Width - ticketNoLabel.PreferredWidth - 20, 30);
                    ticketNoLabel.Anchor = AnchorStyles.Right;
                    ticketPanel.Controls.Add(ticketNoLabel);

                    // Make entire panel clickable
                    ticketPanel.Click += (s, e) =>
                    {
                        if (ticketPanel.Tag is int id)
                            DisplayReceipt(id);
                    };
                    foreach (Control c in ticketPanel.Controls)
                    {
                        c.Click += (s, e) =>
                        {
                            if (ticketPanel.Tag is int id)
                                DisplayReceipt(id);
                        };
                    }

                    flowLayoutPanel1.Controls.Add(ticketPanel);
                }


            }
        }
        private void DisplayReceipt(int ticketID)
        {
            SalesHistoryBackend backend = new SalesHistoryBackend();
            var items = backend.GetReceiptByTicketID(ticketID);

            if (items.Count == 0)
            {
                MessageBox.Show("No receipt found.");
                return;
            }

            var summary = items.FirstOrDefault(t => t.TotalAmount > 0)
                        ?? items.OrderBy(t => t.TicketID).First();

            decimal calculatedSubtotal = items.Sum(i => i.Subtotal);

            lblOrderNo.Text = $"#{summary?.TransactionNo}";
            lblEmployeeName.Text = $"Employee Name: {summary?.EmployeeName}";
            lblPOS.Text = "POS: POS 1";
            lblTotal.Text = $"₱{calculatedSubtotal:F2}";
            lblCash.Text = $"₱{summary?.CashAmount:F2}";
            lblGCash.Text = $"₱{summary?.GcashAmount:F2}";
            lblMaya.Text = $"₱{summary?.MayaAmount:F2}";
            lblChange.Text = $"₱{summary?.Change:F2}";
            lblDate.Text = summary.Date != DateTime.MinValue
                    ? summary.Date.ToString("dd/MM/yyyy h:mm tt")
                    : "-";

            // Clear old items
            flow_receipt_items.Controls.Clear();

            // === ITEM LIST ===
            foreach (var item in items)
            {
                var itemPanel = new Panel
                {
                    Width = flow_receipt_items.Width - 10,
                    Height = 65,
                    Margin = new Padding(0, 5, 0, 5)
                };


                var lblName = new Label
                {
                    Text = item.ProductName,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 5),
                    AutoSize = true
                };

                var lblDetails = new Label
                {
                    Text = $"Quantity: {item.ProductQuantity}\nSize: {item.Size} ({item.Type}) (₱{item.UnitPrice:F2})",
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(10, 25),
                    AutoSize = true
                };

                var lblAmount = new Label
                {
                    Text = $"₱{item.Subtotal:F2}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(itemPanel.Width - 90, 20)
                };

                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(lblDetails);
                itemPanel.Controls.Add(lblAmount);

                flow_receipt_items.Controls.Add(itemPanel);
            }
        }

        private void SalesHistoryForm_Load(object sender, EventArgs e)
        {
            LoadTicketHistory();
        }

        private void lblMaya_Click(object sender, EventArgs e)
        {

        }
    }
}