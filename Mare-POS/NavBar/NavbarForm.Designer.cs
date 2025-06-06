namespace Mare_POS
{
    partial class NavbarForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            navbarPanel = new Panel();
            logo = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_inventory = new Button();
            btn_staff = new Button();
            btn_receipt = new Button();
            btn_cashbox = new Button();
            btn_ticket = new Button();
            btn_dashboard = new Button();
            panel1 = new Panel();
            navbarPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // navbarPanel
            // 
            navbarPanel.BackColor = Color.FromArgb(242, 239, 234);
            navbarPanel.Controls.Add(logo);
            navbarPanel.Controls.Add(flowLayoutPanel1);
            navbarPanel.Dock = DockStyle.Left;
            navbarPanel.Location = new Point(0, 0);
            navbarPanel.Name = "navbarPanel";
            navbarPanel.Size = new Size(120, 985);
            navbarPanel.TabIndex = 1;
            navbarPanel.Paint += navbarPanel_Paint_1;
            // 
            // logo
            // 
            logo.AutoSize = true;
            logo.BackColor = Color.Transparent;
            logo.Font = new Font("Unbounded Medium", 27.7499962F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            logo.ForeColor = Color.FromArgb(78, 45, 24);
            logo.Location = new Point(8, 9);
            logo.Margin = new Padding(0);
            logo.Name = "logo";
            logo.RightToLeft = RightToLeft.Yes;
            logo.Size = new Size(103, 58);
            logo.TabIndex = 0;
            logo.Text = "MK";
            logo.Click += logo_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btn_inventory);
            flowLayoutPanel1.Controls.Add(btn_staff);
            flowLayoutPanel1.Controls.Add(btn_receipt);
            flowLayoutPanel1.Controls.Add(btn_cashbox);
            flowLayoutPanel1.Controls.Add(btn_ticket);
            flowLayoutPanel1.Controls.Add(btn_dashboard);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 161);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(120, 824);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_inventory
            // 
            btn_inventory.BackColor = Color.Transparent;
            btn_inventory.FlatAppearance.BorderSize = 0;
            btn_inventory.FlatStyle = FlatStyle.Flat;
            btn_inventory.Font = new Font("Unbounded Light", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_inventory.ForeColor = Color.FromArgb(78, 45, 24);
            btn_inventory.Image = Properties.Resources.Archive;
            btn_inventory.Location = new Point(0, 0);
            btn_inventory.Margin = new Padding(0, 0, 0, 14);
            btn_inventory.Name = "btn_inventory";
            btn_inventory.RightToLeft = RightToLeft.No;
            btn_inventory.Size = new Size(119, 87);
            btn_inventory.TabIndex = 3;
            btn_inventory.Text = "Inventory";
            btn_inventory.TextAlign = ContentAlignment.BottomCenter;
            btn_inventory.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_inventory.UseVisualStyleBackColor = false;
            btn_inventory.Click += btn_inventory_Click;
            // 
            // btn_staff
            // 
            btn_staff.BackColor = Color.Transparent;
            btn_staff.FlatAppearance.BorderSize = 0;
            btn_staff.FlatStyle = FlatStyle.Flat;
            btn_staff.Font = new Font("Unbounded Light", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_staff.ForeColor = Color.FromArgb(78, 45, 24);
            btn_staff.Image = Properties.Resources.User;
            btn_staff.Location = new Point(0, 101);
            btn_staff.Margin = new Padding(0, 0, 0, 14);
            btn_staff.Name = "btn_staff";
            btn_staff.RightToLeft = RightToLeft.No;
            btn_staff.Size = new Size(120, 87);
            btn_staff.TabIndex = 5;
            btn_staff.Text = "Staff";
            btn_staff.TextAlign = ContentAlignment.BottomCenter;
            btn_staff.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_staff.UseVisualStyleBackColor = false;
            btn_staff.Click += btn_staff_Click;
            // 
            // btn_receipt
            // 
            btn_receipt.BackColor = Color.Transparent;
            btn_receipt.FlatAppearance.BorderSize = 0;
            btn_receipt.FlatStyle = FlatStyle.Flat;
            btn_receipt.Font = new Font("Unbounded Light", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_receipt.ForeColor = Color.FromArgb(78, 45, 24);
            btn_receipt.Image = Properties.Resources.List;
            btn_receipt.Location = new Point(0, 202);
            btn_receipt.Margin = new Padding(0, 0, 0, 15);
            btn_receipt.Name = "btn_receipt";
            btn_receipt.RightToLeft = RightToLeft.No;
            btn_receipt.Size = new Size(120, 87);
            btn_receipt.TabIndex = 7;
            btn_receipt.Text = "Receipt";
            btn_receipt.TextAlign = ContentAlignment.BottomCenter;
            btn_receipt.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_receipt.UseVisualStyleBackColor = false;
            btn_receipt.Click += btn_receipt_Click;
            // 
            // btn_cashbox
            // 
            btn_cashbox.BackColor = Color.Transparent;
            btn_cashbox.FlatAppearance.BorderSize = 0;
            btn_cashbox.FlatStyle = FlatStyle.Flat;
            btn_cashbox.Font = new Font("Unbounded Light", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cashbox.ForeColor = Color.FromArgb(78, 45, 24);
            btn_cashbox.Image = Properties.Resources.DollarSign;
            btn_cashbox.Location = new Point(0, 304);
            btn_cashbox.Margin = new Padding(0, 0, 0, 15);
            btn_cashbox.Name = "btn_cashbox";
            btn_cashbox.RightToLeft = RightToLeft.No;
            btn_cashbox.Size = new Size(120, 87);
            btn_cashbox.TabIndex = 5;
            btn_cashbox.Text = "Cash Box";
            btn_cashbox.TextAlign = ContentAlignment.BottomCenter;
            btn_cashbox.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_cashbox.UseVisualStyleBackColor = false;
            btn_cashbox.Click += btn_cashbox_Click;
            // 
            // btn_ticket
            // 
            btn_ticket.BackColor = Color.Transparent;
            btn_ticket.FlatAppearance.BorderSize = 0;
            btn_ticket.FlatStyle = FlatStyle.Flat;
            btn_ticket.Font = new Font("Unbounded Light", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ticket.ForeColor = Color.FromArgb(78, 45, 24);
            btn_ticket.Image = Properties.Resources.Ticket;
            btn_ticket.Location = new Point(0, 406);
            btn_ticket.Margin = new Padding(0, 0, 0, 15);
            btn_ticket.Name = "btn_ticket";
            btn_ticket.RightToLeft = RightToLeft.No;
            btn_ticket.Size = new Size(120, 87);
            btn_ticket.TabIndex = 9;
            btn_ticket.Text = "Ticket";
            btn_ticket.TextAlign = ContentAlignment.BottomCenter;
            btn_ticket.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_ticket.UseVisualStyleBackColor = false;
            btn_ticket.Click += btn_ticket_Click;
            // 
            // btn_dashboard
            // 
            btn_dashboard.BackColor = Color.Transparent;
            btn_dashboard.FlatAppearance.BorderSize = 0;
            btn_dashboard.FlatStyle = FlatStyle.Flat;
            btn_dashboard.Font = new Font("Unbounded Light", 11.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_dashboard.ForeColor = Color.FromArgb(78, 45, 24);
            btn_dashboard.Image = Properties.Resources.BarChart;
            btn_dashboard.Location = new Point(0, 508);
            btn_dashboard.Margin = new Padding(0);
            btn_dashboard.Name = "btn_dashboard";
            btn_dashboard.RightToLeft = RightToLeft.No;
            btn_dashboard.Size = new Size(120, 87);
            btn_dashboard.TabIndex = 5;
            btn_dashboard.Text = "Dashboard";
            btn_dashboard.TextAlign = ContentAlignment.BottomCenter;
            btn_dashboard.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_dashboard.UseVisualStyleBackColor = false;
            btn_dashboard.Click += btn_dashboard_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 78, 45, 24);
            panel1.Location = new Point(118, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(3, 985);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // NavbarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(1424, 985);
            Controls.Add(panel1);
            Controls.Add(navbarPanel);
            Name = "NavbarForm";
            Text = "Form1";
            Load += Form1_Load;
            navbarPanel.ResumeLayout(false);
            navbarPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void Btn_ticket_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

        private Panel navbarPanel;
        private Label logo;
        private Button btn_inventory;
        private Button btn_dashboard;
        private Button btn_ticket;
        private Button btn_cashbox;
        private Button btn_receipt;
        private Button btn_staff;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}