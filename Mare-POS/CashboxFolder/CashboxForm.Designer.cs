namespace Mare_POS.CashboxFolder
{
    partial class CashboxForm
    {
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashboxForm));
            CashboxHeader = new Label();
            cuiPanel8 = new CuoreUI.Controls.cuiPanel();
            DateToday = new Label();
            label17 = new Label();
            cashSales = new CuoreUI.Controls.cuiPanel();
            cuiButton10 = new CuoreUI.Controls.cuiButton();
            label23 = new Label();
            label24 = new Label();
            cashExpenses = new CuoreUI.Controls.cuiPanel();
            label25 = new Label();
            cuiButton11 = new CuoreUI.Controls.cuiButton();
            label26 = new Label();
            label27 = new Label();
            noncashExpenses = new CuoreUI.Controls.cuiPanel();
            label28 = new Label();
            cuiButton12 = new CuoreUI.Controls.cuiButton();
            label29 = new Label();
            label30 = new Label();
            gCash = new CuoreUI.Controls.cuiPanel();
            cuiButton13 = new CuoreUI.Controls.cuiButton();
            label31 = new Label();
            label32 = new Label();
            maYa = new CuoreUI.Controls.cuiPanel();
            cuiButton14 = new CuoreUI.Controls.cuiButton();
            label33 = new Label();
            label34 = new Label();
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            cuiPanel2 = new CuoreUI.Controls.cuiPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            cuiPanel3 = new CuoreUI.Controls.cuiPanel();
            label5 = new Label();
            addExpenseButton = new CuoreUI.Controls.cuiButton();
            label6 = new Label();
            ExpenseRow = new CuoreUI.Controls.cuiPanel();
            ExpenseAmount = new Label();
            Category = new Label();
            ExpenseName = new Label();
            DeleteButton = new CuoreUI.Controls.cuiButton();
            EditButton = new CuoreUI.Controls.cuiButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            casH = new CuoreUI.Controls.cuiPanel();
            cuiButton2 = new CuoreUI.Controls.cuiButton();
            label3 = new Label();
            label4 = new Label();
            pettyCash = new CuoreUI.Controls.cuiPanel();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            label1 = new Label();
            label2 = new Label();
            cuiPanel8.SuspendLayout();
            cashSales.SuspendLayout();
            cashExpenses.SuspendLayout();
            noncashExpenses.SuspendLayout();
            gCash.SuspendLayout();
            maYa.SuspendLayout();
            cuiPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            cuiPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            cuiPanel3.SuspendLayout();
            ExpenseRow.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            casH.SuspendLayout();
            pettyCash.SuspendLayout();
            SuspendLayout();
            // 
            // CashboxHeader
            // 
            CashboxHeader.AutoSize = true;
            CashboxHeader.BackColor = Color.Transparent;
            CashboxHeader.Dock = DockStyle.Top;
            CashboxHeader.FlatStyle = FlatStyle.Flat;
            CashboxHeader.Font = new Font("Unbounded", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CashboxHeader.ForeColor = Color.FromArgb(78, 45, 24);
            CashboxHeader.Location = new Point(0, 0);
            CashboxHeader.Margin = new Padding(20, 0, 20, 20);
            CashboxHeader.Name = "CashboxHeader";
            CashboxHeader.Padding = new Padding(20, 10, 10, 10);
            CashboxHeader.Size = new Size(293, 81);
            CashboxHeader.TabIndex = 2;
            CashboxHeader.Text = "Cash Box";
            // 
            // cuiPanel8
            // 
            cuiPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiPanel8.BackColor = Color.FromArgb(242, 239, 234);
            cuiPanel8.Controls.Add(DateToday);
            cuiPanel8.Controls.Add(label17);
            cuiPanel8.Location = new Point(1126, 21);
            cuiPanel8.Name = "cuiPanel8";
            cuiPanel8.OutlineThickness = 1F;
            cuiPanel8.PanelColor = Color.FromArgb(242, 239, 234);
            cuiPanel8.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            cuiPanel8.Rounding = new Padding(12);
            cuiPanel8.Size = new Size(304, 48);
            cuiPanel8.TabIndex = 4;
            // 
            // DateToday
            // 
            DateToday.AutoSize = true;
            DateToday.Font = new Font("Inter", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DateToday.ForeColor = Color.FromArgb(78, 45, 24);
            DateToday.Location = new Point(121, 13);
            DateToday.Name = "DateToday";
            DateToday.Size = new Size(51, 32);
            DateToday.TabIndex = 2;
            DateToday.Text = "Try";
            DateToday.Click += label18_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Inter", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.FromArgb(78, 45, 24);
            label17.Location = new Point(9, 13);
            label17.Name = "label17";
            label17.Size = new Size(80, 32);
            label17.TabIndex = 1;
            label17.Text = "DATE:";
            // 
            // cashSales
            // 
            cashSales.BackColor = Color.Transparent;
            cashSales.Controls.Add(cuiButton10);
            cashSales.Controls.Add(label23);
            cashSales.Controls.Add(label24);
            cashSales.Dock = DockStyle.Fill;
            cashSales.Location = new Point(14, 312);
            cashSales.Margin = new Padding(14, 14, 14, 0);
            cashSales.Name = "cashSales";
            cashSales.OutlineThickness = 2F;
            cashSales.Padding = new Padding(0, 0, 0, 12);
            cashSales.PanelColor = Color.White;
            cashSales.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            cashSales.Rounding = new Padding(14);
            cashSales.Size = new Size(238, 135);
            cashSales.TabIndex = 4;
            // 
            // cuiButton10
            // 
            cuiButton10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiButton10.CheckButton = false;
            cuiButton10.Checked = false;
            cuiButton10.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton10.CheckedForeColor = Color.White;
            cuiButton10.CheckedImageTint = Color.White;
            cuiButton10.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton10.Content = "";
            cuiButton10.DialogResult = DialogResult.None;
            cuiButton10.Enabled = false;
            cuiButton10.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton10.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton10.HoverBackground = Color.White;
            cuiButton10.HoveredImageTint = Color.White;
            cuiButton10.HoverForeColor = Color.Black;
            cuiButton10.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton10.Image = (Image)resources.GetObject("cuiButton10.Image");
            cuiButton10.ImageAutoCenter = true;
            cuiButton10.ImageExpand = new Point(5, 5);
            cuiButton10.ImageOffset = new Point(0, 0);
            cuiButton10.Location = new Point(184, 12);
            cuiButton10.Name = "cuiButton10";
            cuiButton10.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton10.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton10.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton10.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton10.OutlineThickness = 1F;
            cuiButton10.PressedBackground = Color.WhiteSmoke;
            cuiButton10.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton10.PressedImageTint = Color.White;
            cuiButton10.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton10.Rounding = new Padding(21);
            cuiButton10.Size = new Size(42, 42);
            cuiButton10.TabIndex = 3;
            cuiButton10.TextAlignment = StringAlignment.Center;
            cuiButton10.TextOffset = new Point(0, 0);
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.FromArgb(78, 45, 24);
            label23.Location = new Point(29, 92);
            label23.Name = "label23";
            label23.Size = new Size(174, 43);
            label23.TabIndex = 2;
            label23.Text = "₱ 3,100.00";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 14F);
            label24.ForeColor = Color.FromArgb(78, 45, 24);
            label24.Location = new Point(11, 23);
            label24.Name = "label24";
            label24.Size = new Size(160, 29);
            label24.TabIndex = 0;
            label24.Text = "CASH SALES";
            // 
            // cashExpenses
            // 
            cashExpenses.BackColor = Color.Transparent;
            cashExpenses.Controls.Add(label25);
            cashExpenses.Controls.Add(cuiButton11);
            cashExpenses.Controls.Add(label26);
            cashExpenses.Controls.Add(label27);
            cashExpenses.Dock = DockStyle.Fill;
            cashExpenses.Location = new Point(14, 461);
            cashExpenses.Margin = new Padding(14, 14, 14, 0);
            cashExpenses.Name = "cashExpenses";
            cashExpenses.OutlineThickness = 2F;
            cashExpenses.Padding = new Padding(0, 0, 0, 12);
            cashExpenses.PanelColor = Color.White;
            cashExpenses.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            cashExpenses.Rounding = new Padding(14);
            cashExpenses.Size = new Size(238, 135);
            cashExpenses.TabIndex = 5;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Microsoft Sans Serif", 14F);
            label25.ForeColor = Color.FromArgb(78, 45, 24);
            label25.Location = new Point(13, 40);
            label25.Name = "label25";
            label25.Size = new Size(144, 29);
            label25.TabIndex = 4;
            label25.Text = "EXPENSES";
            // 
            // cuiButton11
            // 
            cuiButton11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiButton11.CheckButton = false;
            cuiButton11.Checked = false;
            cuiButton11.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton11.CheckedForeColor = Color.White;
            cuiButton11.CheckedImageTint = Color.White;
            cuiButton11.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton11.Content = "";
            cuiButton11.DialogResult = DialogResult.None;
            cuiButton11.Enabled = false;
            cuiButton11.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton11.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton11.HoverBackground = Color.White;
            cuiButton11.HoveredImageTint = Color.White;
            cuiButton11.HoverForeColor = Color.Black;
            cuiButton11.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton11.Image = (Image)resources.GetObject("cuiButton11.Image");
            cuiButton11.ImageAutoCenter = true;
            cuiButton11.ImageExpand = new Point(5, 5);
            cuiButton11.ImageOffset = new Point(0, 0);
            cuiButton11.Location = new Point(184, 13);
            cuiButton11.Name = "cuiButton11";
            cuiButton11.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton11.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton11.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton11.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton11.OutlineThickness = 1F;
            cuiButton11.PressedBackground = Color.WhiteSmoke;
            cuiButton11.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton11.PressedImageTint = Color.White;
            cuiButton11.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton11.Rounding = new Padding(21);
            cuiButton11.Size = new Size(42, 42);
            cuiButton11.TabIndex = 3;
            cuiButton11.TextAlignment = StringAlignment.Center;
            cuiButton11.TextOffset = new Point(0, 0);
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.FromArgb(78, 45, 24);
            label26.Location = new Point(29, 92);
            label26.Name = "label26";
            label26.Size = new Size(174, 43);
            label26.TabIndex = 2;
            label26.Text = "₱ 3,100.00";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Microsoft Sans Serif", 14F);
            label27.ForeColor = Color.FromArgb(78, 45, 24);
            label27.Location = new Point(13, 15);
            label27.Name = "label27";
            label27.Size = new Size(78, 29);
            label27.TabIndex = 0;
            label27.Text = "CASH";
            // 
            // noncashExpenses
            // 
            noncashExpenses.BackColor = Color.Transparent;
            noncashExpenses.Controls.Add(label28);
            noncashExpenses.Controls.Add(cuiButton12);
            noncashExpenses.Controls.Add(label29);
            noncashExpenses.Controls.Add(label30);
            noncashExpenses.Dock = DockStyle.Top;
            noncashExpenses.Location = new Point(14, 610);
            noncashExpenses.Margin = new Padding(14);
            noncashExpenses.Name = "noncashExpenses";
            noncashExpenses.OutlineThickness = 2F;
            noncashExpenses.Padding = new Padding(0, 0, 0, 12);
            noncashExpenses.PanelColor = SystemColors.Window;
            noncashExpenses.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            noncashExpenses.Rounding = new Padding(14);
            noncashExpenses.Size = new Size(238, 139);
            noncashExpenses.TabIndex = 6;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Microsoft Sans Serif", 14F);
            label28.ForeColor = Color.FromArgb(78, 45, 24);
            label28.Location = new Point(13, 40);
            label28.Name = "label28";
            label28.Size = new Size(144, 29);
            label28.TabIndex = 4;
            label28.Text = "EXPENSES";
            // 
            // cuiButton12
            // 
            cuiButton12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiButton12.CheckButton = false;
            cuiButton12.Checked = false;
            cuiButton12.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton12.CheckedForeColor = Color.White;
            cuiButton12.CheckedImageTint = Color.White;
            cuiButton12.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton12.Content = "";
            cuiButton12.DialogResult = DialogResult.None;
            cuiButton12.Enabled = false;
            cuiButton12.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton12.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton12.HoverBackground = Color.White;
            cuiButton12.HoveredImageTint = Color.White;
            cuiButton12.HoverForeColor = Color.Black;
            cuiButton12.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton12.Image = (Image)resources.GetObject("cuiButton12.Image");
            cuiButton12.ImageAutoCenter = true;
            cuiButton12.ImageExpand = new Point(5, 5);
            cuiButton12.ImageOffset = new Point(0, 0);
            cuiButton12.Location = new Point(183, 14);
            cuiButton12.Name = "cuiButton12";
            cuiButton12.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton12.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton12.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton12.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton12.OutlineThickness = 1F;
            cuiButton12.PressedBackground = Color.WhiteSmoke;
            cuiButton12.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton12.PressedImageTint = Color.White;
            cuiButton12.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton12.Rounding = new Padding(21);
            cuiButton12.Size = new Size(42, 42);
            cuiButton12.TabIndex = 3;
            cuiButton12.TextAlignment = StringAlignment.Center;
            cuiButton12.TextOffset = new Point(0, 0);
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.ForeColor = Color.FromArgb(78, 45, 24);
            label29.Location = new Point(29, 96);
            label29.Name = "label29";
            label29.Size = new Size(174, 43);
            label29.TabIndex = 2;
            label29.Text = "₱ 3,100.00";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Microsoft Sans Serif", 14F);
            label30.ForeColor = Color.FromArgb(78, 45, 24);
            label30.Location = new Point(13, 15);
            label30.Name = "label30";
            label30.Size = new Size(153, 29);
            label30.TabIndex = 0;
            label30.Text = "NON - CASH";
            // 
            // gCash
            // 
            gCash.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gCash.BackColor = Color.Transparent;
            gCash.Controls.Add(cuiButton13);
            gCash.Controls.Add(label31);
            gCash.Controls.Add(label32);
            gCash.Dock = DockStyle.Fill;
            gCash.Location = new Point(266, 14);
            gCash.Margin = new Padding(0, 14, 14, 0);
            gCash.Name = "gCash";
            gCash.OutlineThickness = 2F;
            gCash.Padding = new Padding(0, 0, 0, 12);
            gCash.PanelColor = Color.White;
            gCash.PanelOutlineColor = Color.FromArgb(0, 145, 247);
            gCash.Rounding = new Padding(14);
            gCash.Size = new Size(240, 135);
            gCash.TabIndex = 0;
            // 
            // cuiButton13
            // 
            cuiButton13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiButton13.CheckButton = false;
            cuiButton13.Checked = false;
            cuiButton13.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton13.CheckedForeColor = Color.White;
            cuiButton13.CheckedImageTint = Color.White;
            cuiButton13.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton13.Content = "";
            cuiButton13.DialogResult = DialogResult.None;
            cuiButton13.Enabled = false;
            cuiButton13.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton13.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton13.HoverBackground = Color.White;
            cuiButton13.HoveredImageTint = Color.White;
            cuiButton13.HoverForeColor = Color.Black;
            cuiButton13.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton13.Image = (Image)resources.GetObject("cuiButton13.Image");
            cuiButton13.ImageAutoCenter = true;
            cuiButton13.ImageExpand = new Point(5, 5);
            cuiButton13.ImageOffset = new Point(0, 0);
            cuiButton13.Location = new Point(186, 9);
            cuiButton13.Name = "cuiButton13";
            cuiButton13.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton13.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton13.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton13.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton13.OutlineThickness = 1F;
            cuiButton13.PressedBackground = Color.WhiteSmoke;
            cuiButton13.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton13.PressedImageTint = Color.White;
            cuiButton13.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton13.Rounding = new Padding(21);
            cuiButton13.Size = new Size(42, 42);
            cuiButton13.TabIndex = 3;
            cuiButton13.TextAlignment = StringAlignment.Center;
            cuiButton13.TextOffset = new Point(0, 0);
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Inter SemiBold", 18.2F, FontStyle.Bold);
            label31.ForeColor = Color.FromArgb(0, 145, 247);
            label31.Location = new Point(13, 84);
            label31.Name = "label31";
            label31.Size = new Size(216, 44);
            label31.TabIndex = 2;
            label31.Text = "₱ 893,100.00";
            label31.Click += label31_Click;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Microsoft Sans Serif", 14F);
            label32.ForeColor = Color.FromArgb(0, 145, 247);
            label32.Location = new Point(13, 23);
            label32.Name = "label32";
            label32.Size = new Size(96, 29);
            label32.TabIndex = 0;
            label32.Text = "GCASH";
            // 
            // maYa
            // 
            maYa.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            maYa.BackColor = Color.Transparent;
            maYa.Controls.Add(cuiButton14);
            maYa.Controls.Add(label33);
            maYa.Controls.Add(label34);
            maYa.Dock = DockStyle.Fill;
            maYa.Location = new Point(266, 163);
            maYa.Margin = new Padding(0, 14, 14, 0);
            maYa.Name = "maYa";
            maYa.OutlineThickness = 2F;
            maYa.Padding = new Padding(0, 0, 0, 12);
            maYa.PanelColor = Color.White;
            maYa.PanelOutlineColor = Color.FromArgb(0, 137, 76);
            maYa.Rounding = new Padding(14);
            maYa.Size = new Size(240, 135);
            maYa.TabIndex = 1;
            // 
            // cuiButton14
            // 
            cuiButton14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cuiButton14.CheckButton = false;
            cuiButton14.Checked = false;
            cuiButton14.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton14.CheckedForeColor = Color.White;
            cuiButton14.CheckedImageTint = Color.White;
            cuiButton14.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton14.Content = "";
            cuiButton14.DialogResult = DialogResult.None;
            cuiButton14.Enabled = false;
            cuiButton14.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton14.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton14.HoverBackground = Color.White;
            cuiButton14.HoveredImageTint = Color.White;
            cuiButton14.HoverForeColor = Color.Black;
            cuiButton14.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton14.Image = (Image)resources.GetObject("cuiButton14.Image");
            cuiButton14.ImageAutoCenter = true;
            cuiButton14.ImageExpand = new Point(5, 5);
            cuiButton14.ImageOffset = new Point(0, 0);
            cuiButton14.Location = new Point(184, 12);
            cuiButton14.Name = "cuiButton14";
            cuiButton14.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton14.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton14.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton14.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton14.OutlineThickness = 1F;
            cuiButton14.PressedBackground = Color.WhiteSmoke;
            cuiButton14.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton14.PressedImageTint = Color.White;
            cuiButton14.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton14.Rounding = new Padding(21);
            cuiButton14.Size = new Size(44, 42);
            cuiButton14.TabIndex = 3;
            cuiButton14.TextAlignment = StringAlignment.Center;
            cuiButton14.TextOffset = new Point(0, 0);
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label33.ForeColor = Color.FromArgb(0, 137, 76);
            label33.Location = new Point(33, 90);
            label33.Name = "label33";
            label33.Size = new Size(174, 43);
            label33.TabIndex = 2;
            label33.Text = "₱ 3,100.00";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Microsoft Sans Serif", 14F);
            label34.ForeColor = Color.FromArgb(0, 137, 76);
            label34.Location = new Point(13, 15);
            label34.Name = "label34";
            label34.Size = new Size(79, 29);
            label34.TabIndex = 0;
            label34.Text = "MAYA";
            // 
            // cuiPanel1
            // 
            cuiPanel1.AutoScroll = true;
            cuiPanel1.Controls.Add(tableLayoutPanel2);
            cuiPanel1.Controls.Add(tableLayoutPanel1);
            cuiPanel1.Location = new Point(0, 81);
            cuiPanel1.Margin = new Padding(20);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.Padding = new Padding(30, 50, 30, 30);
            cuiPanel1.PanelColor = Color.FromArgb(242, 239, 234);
            cuiPanel1.PanelOutlineColor = Color.Transparent;
            cuiPanel1.Rounding = new Padding(0);
            cuiPanel1.Size = new Size(1440, 943);
            cuiPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(cuiPanel2, 0, 0);
            tableLayoutPanel2.Location = new Point(550, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(20, 12, 20, 20);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(860, 863);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // cuiPanel2
            // 
            cuiPanel2.Anchor = AnchorStyles.None;
            cuiPanel2.BackColor = Color.Transparent;
            cuiPanel2.Controls.Add(tableLayoutPanel3);
            cuiPanel2.Location = new Point(20, 12);
            cuiPanel2.Margin = new Padding(0);
            cuiPanel2.Name = "cuiPanel2";
            cuiPanel2.OutlineThickness = 2F;
            cuiPanel2.Padding = new Padding(20);
            cuiPanel2.PanelColor = Color.White;
            cuiPanel2.PanelOutlineColor = Color.Transparent;
            cuiPanel2.Rounding = new Padding(14);
            cuiPanel2.Size = new Size(820, 831);
            cuiPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.None;
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(cuiPanel3, 0, 0);
            tableLayoutPanel3.Controls.Add(ExpenseRow, 0, 1);
            tableLayoutPanel3.Location = new Point(20, 20);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 11;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091073F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091075F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091075F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091075F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091075F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091074F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091075F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091075F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.091074F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090165F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090165F));
            tableLayoutPanel3.Size = new Size(780, 791);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // cuiPanel3
            // 
            cuiPanel3.Anchor = AnchorStyles.None;
            cuiPanel3.Controls.Add(label5);
            cuiPanel3.Controls.Add(addExpenseButton);
            cuiPanel3.Controls.Add(label6);
            cuiPanel3.Location = new Point(3, 2);
            cuiPanel3.Margin = new Padding(0);
            cuiPanel3.Name = "cuiPanel3";
            cuiPanel3.OutlineThickness = 0.8F;
            cuiPanel3.PanelColor = Color.White;
            cuiPanel3.PanelOutlineColor = Color.Transparent;
            cuiPanel3.Rounding = new Padding(0);
            cuiPanel3.Size = new Size(774, 68);
            cuiPanel3.TabIndex = 4;
            cuiPanel3.Paint += cuiPanel3_Paint;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Unbounded Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(78, 45, 24);
            label5.Location = new Point(11, 9);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(283, 43);
            label5.TabIndex = 0;
            label5.Text = "Expense Added";
            label5.Click += label5_Click;
            // 
            // addExpenseButton
            // 
            addExpenseButton.Anchor = AnchorStyles.None;
            addExpenseButton.BackColor = Color.White;
            addExpenseButton.CheckButton = false;
            addExpenseButton.Checked = false;
            addExpenseButton.CheckedBackground = Color.White;
            addExpenseButton.CheckedForeColor = Color.White;
            addExpenseButton.CheckedImageTint = Color.White;
            addExpenseButton.CheckedOutline = Color.White;
            addExpenseButton.Content = "";
            addExpenseButton.DialogResult = DialogResult.None;
            addExpenseButton.Font = new Font("Microsoft Sans Serif", 9.75F);
            addExpenseButton.ForeColor = Color.FromArgb(78, 45, 24);
            addExpenseButton.HoverBackground = Color.FromArgb(60, 78, 45, 24);
            addExpenseButton.HoveredImageTint = Color.FromArgb(78, 45, 24);
            addExpenseButton.HoverForeColor = Color.Black;
            addExpenseButton.HoverOutline = Color.FromArgb(78, 45, 24);
            addExpenseButton.Image = (Image)resources.GetObject("addExpenseButton.Image");
            addExpenseButton.ImageAutoCenter = true;
            addExpenseButton.ImageExpand = new Point(4, 4);
            addExpenseButton.ImageOffset = new Point(0, 0);
            addExpenseButton.Location = new Point(704, 16);
            addExpenseButton.Margin = new Padding(0);
            addExpenseButton.Name = "addExpenseButton";
            addExpenseButton.NormalBackground = Color.FromArgb(30, 78, 45, 24);
            addExpenseButton.NormalForeColor = Color.FromArgb(78, 45, 24);
            addExpenseButton.NormalImageTint = Color.White;
            addExpenseButton.NormalOutline = Color.FromArgb(78, 45, 24);
            addExpenseButton.OutlineThickness = 1F;
            addExpenseButton.PressedBackground = Color.FromArgb(60, 78, 45, 24);
            addExpenseButton.PressedForeColor = Color.FromArgb(78, 45, 24);
            addExpenseButton.PressedImageTint = Color.FromArgb(78, 45, 24);
            addExpenseButton.PressedOutline = Color.FromArgb(78, 45, 24);
            addExpenseButton.Rounding = new Padding(8);
            addExpenseButton.Size = new Size(36, 36);
            addExpenseButton.TabIndex = 4;
            addExpenseButton.TextAlignment = StringAlignment.Center;
            addExpenseButton.TextOffset = new Point(0, 0);
            addExpenseButton.Click += addExpenseButton_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(78, 45, 24);
            label6.Location = new Point(1100, -16);
            label6.Name = "label6";
            label6.Size = new Size(114, 29);
            label6.TabIndex = 9;
            label6.Text = "₱ 300.00";
            // 
            // ExpenseRow
            // 
            ExpenseRow.Anchor = AnchorStyles.None;
            ExpenseRow.Controls.Add(ExpenseAmount);
            ExpenseRow.Controls.Add(Category);
            ExpenseRow.Controls.Add(ExpenseName);
            ExpenseRow.Controls.Add(DeleteButton);
            ExpenseRow.Controls.Add(EditButton);
            ExpenseRow.Location = new Point(3, 73);
            ExpenseRow.Margin = new Padding(0);
            ExpenseRow.Name = "ExpenseRow";
            ExpenseRow.OutlineThickness = 0.8F;
            ExpenseRow.PanelColor = Color.White;
            ExpenseRow.PanelOutlineColor = Color.Transparent;
            ExpenseRow.Rounding = new Padding(0);
            ExpenseRow.Size = new Size(774, 68);
            ExpenseRow.TabIndex = 7;
            // 
            // ExpenseAmount
            // 
            ExpenseAmount.Anchor = AnchorStyles.None;
            ExpenseAmount.AutoSize = true;
            ExpenseAmount.BackColor = Color.White;
            ExpenseAmount.Font = new Font("Inter", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExpenseAmount.ForeColor = Color.FromArgb(78, 45, 24);
            ExpenseAmount.Location = new Point(585, 16);
            ExpenseAmount.Name = "ExpenseAmount";
            ExpenseAmount.Size = new Size(120, 32);
            ExpenseAmount.TabIndex = 10;
            ExpenseAmount.Text = "₱ 300.00";
            // 
            // Category
            // 
            Category.AutoSize = true;
            Category.BackColor = Color.White;
            Category.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Category.ForeColor = Color.FromArgb(78, 45, 24);
            Category.Location = new Point(142, 37);
            Category.Name = "Category";
            Category.Size = new Size(58, 24);
            Category.TabIndex = 8;
            Category.Text = "CASH";
            Category.Click += Category_Click;
            // 
            // ExpenseName
            // 
            ExpenseName.AutoSize = true;
            ExpenseName.BackColor = Color.White;
            ExpenseName.Font = new Font("Inter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExpenseName.ForeColor = Color.FromArgb(78, 45, 24);
            ExpenseName.Location = new Point(142, 11);
            ExpenseName.Name = "ExpenseName";
            ExpenseName.Size = new Size(132, 26);
            ExpenseName.TabIndex = 7;
            ExpenseName.Text = "1 Sack of Rice";
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.None;
            DeleteButton.AutoSize = true;
            DeleteButton.BackColor = Color.White;
            DeleteButton.CheckButton = false;
            DeleteButton.Checked = false;
            DeleteButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            DeleteButton.CheckedForeColor = Color.White;
            DeleteButton.CheckedImageTint = Color.White;
            DeleteButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            DeleteButton.Content = "";
            DeleteButton.DialogResult = DialogResult.None;
            DeleteButton.Font = new Font("Microsoft Sans Serif", 9.75F);
            DeleteButton.ForeColor = Color.FromArgb(195, 14, 14);
            DeleteButton.HoverBackground = Color.FromArgb(60, 195, 14, 14);
            DeleteButton.HoveredImageTint = Color.FromArgb(195, 14, 14);
            DeleteButton.HoverForeColor = Color.Black;
            DeleteButton.HoverOutline = Color.FromArgb(195, 14, 14);
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageAutoCenter = true;
            DeleteButton.ImageExpand = new Point(4, 4);
            DeleteButton.ImageOffset = new Point(0, 0);
            DeleteButton.Location = new Point(22, 16);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.NormalBackground = Color.FromArgb(30, 195, 14, 14);
            DeleteButton.NormalForeColor = Color.FromArgb(195, 14, 14);
            DeleteButton.NormalImageTint = Color.White;
            DeleteButton.NormalOutline = Color.FromArgb(195, 14, 14);
            DeleteButton.OutlineThickness = 1F;
            DeleteButton.PressedBackground = Color.FromArgb(60, 195, 14, 14);
            DeleteButton.PressedForeColor = Color.FromArgb(195, 14, 14);
            DeleteButton.PressedImageTint = Color.FromArgb(195, 14, 14);
            DeleteButton.PressedOutline = Color.FromArgb(195, 14, 14);
            DeleteButton.Rounding = new Padding(8);
            DeleteButton.Size = new Size(40, 40);
            DeleteButton.TabIndex = 6;
            DeleteButton.TextAlignment = StringAlignment.Center;
            DeleteButton.TextOffset = new Point(0, 0);
            // 
            // EditButton
            // 
            EditButton.Anchor = AnchorStyles.None;
            EditButton.BackColor = Color.White;
            EditButton.CheckButton = false;
            EditButton.Checked = false;
            EditButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            EditButton.CheckedForeColor = Color.White;
            EditButton.CheckedImageTint = Color.White;
            EditButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            EditButton.Content = "";
            EditButton.DialogResult = DialogResult.None;
            EditButton.Font = new Font("Microsoft Sans Serif", 9.75F);
            EditButton.ForeColor = Color.FromArgb(0, 137, 76);
            EditButton.HoverBackground = Color.FromArgb(60, 0, 137, 76);
            EditButton.HoveredImageTint = Color.FromArgb(0, 137, 76);
            EditButton.HoverForeColor = Color.Black;
            EditButton.HoverOutline = Color.FromArgb(0, 137, 76);
            EditButton.Image = (Image)resources.GetObject("EditButton.Image");
            EditButton.ImageAutoCenter = true;
            EditButton.ImageExpand = new Point(4, 4);
            EditButton.ImageOffset = new Point(0, 0);
            EditButton.Location = new Point(78, 16);
            EditButton.Margin = new Padding(0);
            EditButton.Name = "EditButton";
            EditButton.NormalBackground = Color.FromArgb(30, 0, 137, 76);
            EditButton.NormalForeColor = Color.FromArgb(0, 137, 76);
            EditButton.NormalImageTint = Color.White;
            EditButton.NormalOutline = Color.FromArgb(0, 137, 76);
            EditButton.OutlineThickness = 1F;
            EditButton.PressedBackground = Color.FromArgb(60, 0, 137, 76);
            EditButton.PressedForeColor = Color.FromArgb(0, 137, 76);
            EditButton.PressedImageTint = Color.FromArgb(0, 137, 76);
            EditButton.PressedOutline = Color.FromArgb(0, 137, 76);
            EditButton.Rounding = new Padding(8);
            EditButton.Size = new Size(40, 40);
            EditButton.TabIndex = 5;
            EditButton.TextAlignment = StringAlignment.Center;
            EditButton.TextOffset = new Point(0, 0);
            EditButton.Click += EditButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(casH, 0, 0);
            tableLayoutPanel1.Controls.Add(pettyCash, 0, 1);
            tableLayoutPanel1.Controls.Add(maYa, 1, 1);
            tableLayoutPanel1.Controls.Add(gCash, 1, 0);
            tableLayoutPanel1.Controls.Add(noncashExpenses, 0, 4);
            tableLayoutPanel1.Controls.Add(cashExpenses, 0, 3);
            tableLayoutPanel1.Controls.Add(cashSales, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(30, 50);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(520, 863);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // casH
            // 
            casH.BackColor = Color.Transparent;
            casH.Controls.Add(cuiButton2);
            casH.Controls.Add(label3);
            casH.Controls.Add(label4);
            casH.Dock = DockStyle.Fill;
            casH.Location = new Point(14, 14);
            casH.Margin = new Padding(14, 14, 14, 0);
            casH.Name = "casH";
            casH.OutlineThickness = 2F;
            casH.Padding = new Padding(0, 0, 0, 12);
            casH.PanelColor = Color.White;
            casH.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            casH.Rounding = new Padding(14);
            casH.Size = new Size(238, 135);
            casH.TabIndex = 8;
            // 
            // cuiButton2
            // 
            cuiButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiButton2.CheckButton = false;
            cuiButton2.Checked = false;
            cuiButton2.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton2.CheckedForeColor = Color.White;
            cuiButton2.CheckedImageTint = Color.White;
            cuiButton2.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton2.Content = "";
            cuiButton2.DialogResult = DialogResult.None;
            cuiButton2.Enabled = false;
            cuiButton2.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton2.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton2.HoverBackground = Color.White;
            cuiButton2.HoveredImageTint = Color.White;
            cuiButton2.HoverForeColor = Color.Black;
            cuiButton2.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton2.Image = (Image)resources.GetObject("cuiButton2.Image");
            cuiButton2.ImageAutoCenter = true;
            cuiButton2.ImageExpand = new Point(5, 5);
            cuiButton2.ImageOffset = new Point(0, 0);
            cuiButton2.Location = new Point(184, 9);
            cuiButton2.Name = "cuiButton2";
            cuiButton2.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton2.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton2.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton2.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton2.OutlineThickness = 1F;
            cuiButton2.PressedBackground = Color.WhiteSmoke;
            cuiButton2.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton2.PressedImageTint = Color.White;
            cuiButton2.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton2.Rounding = new Padding(21);
            cuiButton2.Size = new Size(42, 42);
            cuiButton2.TabIndex = 4;
            cuiButton2.TextAlignment = StringAlignment.Center;
            cuiButton2.TextOffset = new Point(0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(29, 85);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(174, 43);
            label3.TabIndex = 2;
            label3.Text = "₱ 3,100.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14F);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(11, 23);
            label4.Name = "label4";
            label4.Size = new Size(78, 29);
            label4.TabIndex = 0;
            label4.Text = "CASH";
            // 
            // pettyCash
            // 
            pettyCash.BackColor = Color.Transparent;
            pettyCash.Controls.Add(cuiButton1);
            pettyCash.Controls.Add(label1);
            pettyCash.Controls.Add(label2);
            pettyCash.Dock = DockStyle.Fill;
            pettyCash.Location = new Point(14, 163);
            pettyCash.Margin = new Padding(14, 14, 14, 0);
            pettyCash.Name = "pettyCash";
            pettyCash.OutlineThickness = 2F;
            pettyCash.Padding = new Padding(0, 0, 0, 12);
            pettyCash.PanelColor = Color.White;
            pettyCash.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            pettyCash.Rounding = new Padding(14);
            pettyCash.Size = new Size(238, 135);
            pettyCash.TabIndex = 7;
            // 
            // cuiButton1
            // 
            cuiButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiButton1.CheckButton = false;
            cuiButton1.Checked = false;
            cuiButton1.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton1.CheckedForeColor = Color.White;
            cuiButton1.CheckedImageTint = Color.White;
            cuiButton1.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton1.Content = "";
            cuiButton1.DialogResult = DialogResult.None;
            cuiButton1.Enabled = false;
            cuiButton1.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton1.ForeColor = Color.FromArgb(242, 239, 234);
            cuiButton1.HoverBackground = Color.White;
            cuiButton1.HoveredImageTint = Color.White;
            cuiButton1.HoverForeColor = Color.Black;
            cuiButton1.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton1.Image = (Image)resources.GetObject("cuiButton1.Image");
            cuiButton1.ImageAutoCenter = true;
            cuiButton1.ImageExpand = new Point(5, 5);
            cuiButton1.ImageOffset = new Point(0, 0);
            cuiButton1.Location = new Point(184, 11);
            cuiButton1.Name = "cuiButton1";
            cuiButton1.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton1.NormalForeColor = Color.FromArgb(242, 239, 234);
            cuiButton1.NormalImageTint = Color.FromArgb(242, 239, 234);
            cuiButton1.NormalOutline = Color.FromArgb(242, 239, 234);
            cuiButton1.OutlineThickness = 1F;
            cuiButton1.PressedBackground = Color.WhiteSmoke;
            cuiButton1.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton1.PressedImageTint = Color.White;
            cuiButton1.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.Rounding = new Padding(21);
            cuiButton1.Size = new Size(42, 42);
            cuiButton1.TabIndex = 4;
            cuiButton1.TextAlignment = StringAlignment.Center;
            cuiButton1.TextOffset = new Point(0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(29, 90);
            label1.Name = "label1";
            label1.Size = new Size(174, 43);
            label1.TabIndex = 2;
            label1.Text = "₱ 3,100.00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.Location = new Point(11, 23);
            label2.Name = "label2";
            label2.Size = new Size(164, 29);
            label2.TabIndex = 0;
            label2.Text = "PETTY CASH";
            // 
            // CashboxForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(cuiPanel1);
            Controls.Add(cuiPanel8);
            Controls.Add(CashboxHeader);
            Name = "CashboxForm";
            Size = new Size(1460, 1044);
            cuiPanel8.ResumeLayout(false);
            cuiPanel8.PerformLayout();
            cashSales.ResumeLayout(false);
            cashSales.PerformLayout();
            cashExpenses.ResumeLayout(false);
            cashExpenses.PerformLayout();
            noncashExpenses.ResumeLayout(false);
            noncashExpenses.PerformLayout();
            gCash.ResumeLayout(false);
            gCash.PerformLayout();
            maYa.ResumeLayout(false);
            maYa.PerformLayout();
            cuiPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            cuiPanel2.ResumeLayout(false);
            cuiPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            cuiPanel3.ResumeLayout(false);
            cuiPanel3.PerformLayout();
            ExpenseRow.ResumeLayout(false);
            ExpenseRow.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            casH.ResumeLayout(false);
            casH.PerformLayout();
            pettyCash.ResumeLayout(false);
            pettyCash.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CashboxHeader;
        private CuoreUI.Controls.cuiPanel cuiPanel8;
        private Label DateToday;
        private Label label17;

        private CuoreUI.Controls.cuiPanel cashSales;
        private CuoreUI.Controls.cuiButton cuiButton10;
        private Label label23;
        private Label label24;

        private CuoreUI.Controls.cuiPanel cashExpenses;
        private Label label25;
        private CuoreUI.Controls.cuiButton cuiButton11;
        private Label label26;
        private Label label27;

        private CuoreUI.Controls.cuiPanel noncashExpenses;
        private Label label28;
        private CuoreUI.Controls.cuiButton cuiButton12;
        private Label label29;
        private Label label30;

        private CuoreUI.Controls.cuiPanel gCash;
        private CuoreUI.Controls.cuiButton cuiButton13;
        private Label label31;
        private Label label32;

        private CuoreUI.Controls.cuiPanel maYa;
        private CuoreUI.Controls.cuiButton cuiButton14;
        private Label label33;
        private Label label34;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private TableLayoutPanel tableLayoutPanel1;

        private CuoreUI.Controls.cuiPanel pettyCash;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private Label label1;
        private Label label2;

        private CuoreUI.Controls.cuiPanel casH;
        private CuoreUI.Controls.cuiButton cuiButton2;
        private Label label3;
        private Label label4;
        private CuoreUI.Controls.cuiButton addExpenseButton;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel2;
        private CuoreUI.Controls.cuiPanel cuiPanel2;
        private CuoreUI.Controls.cuiPanel cuiPanel3;
        private Label label6;
        private CuoreUI.Controls.cuiPanel ExpenseRow;
        private Label Category;
        private Label ExpenseName;
        private CuoreUI.Controls.cuiButton DeleteButton;
        private CuoreUI.Controls.cuiButton EditButton;
        private Label ExpenseAmount;
        private TableLayoutPanel tableLayoutPanel3;
    }
}
