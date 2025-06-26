namespace Mare_POS
{
    partial class DiscountButton
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
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnClear = new CuoreUI.Controls.cuiButton();
            txtPercent = new TextBox();
            txtPeso = new TextBox();
            tableLayoutPanel9 = new TableLayoutPanel();
            btn100 = new CuoreUI.Controls.cuiButton();
            btn20 = new CuoreUI.Controls.cuiButton();
            btn10 = new CuoreUI.Controls.cuiButton();
            btn5 = new CuoreUI.Controls.cuiButton();
            cuiPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            SuspendLayout();
            // 
            // cuiPanel1
            // 
            cuiPanel1.Controls.Add(tableLayoutPanel2);
            cuiPanel1.Controls.Add(tableLayoutPanel9);
            cuiPanel1.Dock = DockStyle.Fill;
            cuiPanel1.Location = new Point(0, 0);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.PanelColor = Color.FromArgb(242, 239, 234);
            cuiPanel1.PanelOutlineColor = Color.Gray;
            cuiPanel1.Rounding = new Padding(8);
            cuiPanel1.Size = new Size(489, 106);
            cuiPanel1.TabIndex = 0;
            cuiPanel1.Paint += cuiPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(btnClear, 2, 0);
            tableLayoutPanel2.Controls.Add(txtPercent, 1, 0);
            tableLayoutPanel2.Controls.Add(txtPeso, 0, 0);
            tableLayoutPanel2.Location = new Point(7, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(479, 47);
            tableLayoutPanel2.TabIndex = 40;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClear.BackColor = Color.Transparent;
            btnClear.CheckButton = false;
            btnClear.Checked = false;
            btnClear.CheckedBackground = Color.FromArgb(158, 43, 43);
            btnClear.CheckedForeColor = Color.Transparent;
            btnClear.CheckedImageTint = Color.Transparent;
            btnClear.CheckedOutline = Color.FromArgb(158, 43, 43);
            btnClear.Content = "Clear";
            btnClear.DialogResult = DialogResult.None;
            btnClear.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.FromArgb(158, 43, 43);
            btnClear.HoverBackground = Color.FromArgb(158, 43, 43);
            btnClear.HoveredImageTint = Color.White;
            btnClear.HoverForeColor = Color.Black;
            btnClear.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnClear.Image = null;
            btnClear.ImageAutoCenter = true;
            btnClear.ImageExpand = new Point(0, 0);
            btnClear.ImageOffset = new Point(0, 0);
            btnClear.Location = new Point(321, 3);
            btnClear.Name = "btnClear";
            btnClear.NormalBackground = Color.WhiteSmoke;
            btnClear.NormalForeColor = Color.FromArgb(158, 43, 43);
            btnClear.NormalImageTint = Color.White;
            btnClear.NormalOutline = Color.FromArgb(158, 43, 43);
            btnClear.OutlineThickness = 1F;
            btnClear.PressedBackground = Color.WhiteSmoke;
            btnClear.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnClear.PressedImageTint = Color.White;
            btnClear.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnClear.Rounding = new Padding(8);
            btnClear.Size = new Size(155, 41);
            btnClear.TabIndex = 7;
            btnClear.TextAlignment = StringAlignment.Center;
            btnClear.TextOffset = new Point(0, 0);
            // 
            // txtPercent
            // 
            txtPercent.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPercent.ForeColor = Color.FromArgb(78, 45, 24);
            txtPercent.Location = new Point(162, 3);
            txtPercent.Name = "txtPercent";
            txtPercent.Size = new Size(153, 38);
            txtPercent.TabIndex = 11;
            txtPercent.TextChanged += txtPercent_TextChanged;
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Segoe UI", 15F);
            txtPeso.Location = new Point(3, 3);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(153, 41);
            txtPeso.TabIndex = 12;
            txtPeso.TextChanged += txtPeso_TextChanged;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel9.AutoSize = true;
            tableLayoutPanel9.ColumnCount = 4;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.Controls.Add(btn100, 3, 0);
            tableLayoutPanel9.Controls.Add(btn20, 2, 0);
            tableLayoutPanel9.Controls.Add(btn10, 1, 0);
            tableLayoutPanel9.Controls.Add(btn5, 0, 0);
            tableLayoutPanel9.Location = new Point(7, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel9.Size = new Size(479, 47);
            tableLayoutPanel9.TabIndex = 33;
            // 
            // btn100
            // 
            btn100.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn100.BackColor = Color.Transparent;
            btn100.CheckButton = false;
            btn100.Checked = false;
            btn100.CheckedBackground = Color.FromArgb(135, 167, 10);
            btn100.CheckedForeColor = Color.Transparent;
            btn100.CheckedImageTint = Color.Transparent;
            btn100.CheckedOutline = Color.FromArgb(135, 167, 10);
            btn100.Content = "100%";
            btn100.DialogResult = DialogResult.None;
            btn100.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn100.ForeColor = Color.FromArgb(135, 167, 10);
            btn100.HoverBackground = Color.FromArgb(135, 167, 10);
            btn100.HoveredImageTint = Color.White;
            btn100.HoverForeColor = Color.Black;
            btn100.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btn100.Image = null;
            btn100.ImageAutoCenter = true;
            btn100.ImageExpand = new Point(0, 0);
            btn100.ImageOffset = new Point(0, 0);
            btn100.Location = new Point(360, 3);
            btn100.Name = "btn100";
            btn100.NormalBackground = Color.WhiteSmoke;
            btn100.NormalForeColor = Color.FromArgb(135, 167, 10);
            btn100.NormalImageTint = Color.White;
            btn100.NormalOutline = Color.FromArgb(135, 167, 10);
            btn100.OutlineThickness = 1F;
            btn100.PressedBackground = Color.WhiteSmoke;
            btn100.PressedForeColor = Color.FromArgb(32, 32, 32);
            btn100.PressedImageTint = Color.White;
            btn100.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btn100.Rounding = new Padding(8);
            btn100.Size = new Size(116, 41);
            btn100.TabIndex = 4;
            btn100.Tag = "100";
            btn100.TextAlignment = StringAlignment.Center;
            btn100.TextOffset = new Point(0, 0);
            btn100.Click += DiscountButton_Click;
            // 
            // btn20
            // 
            btn20.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn20.BackColor = Color.Transparent;
            btn20.CheckButton = false;
            btn20.Checked = false;
            btn20.CheckedBackground = Color.FromArgb(255, 106, 0);
            btn20.CheckedForeColor = Color.Transparent;
            btn20.CheckedImageTint = Color.Transparent;
            btn20.CheckedOutline = Color.FromArgb(255, 106, 0);
            btn20.Content = "20%";
            btn20.DialogResult = DialogResult.None;
            btn20.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn20.ForeColor = Color.FromArgb(92, 0, 153);
            btn20.HoverBackground = Color.FromArgb(92, 0, 153);
            btn20.HoveredImageTint = Color.White;
            btn20.HoverForeColor = Color.Black;
            btn20.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btn20.Image = null;
            btn20.ImageAutoCenter = true;
            btn20.ImageExpand = new Point(0, 0);
            btn20.ImageOffset = new Point(0, 0);
            btn20.Location = new Point(241, 3);
            btn20.Name = "btn20";
            btn20.NormalBackground = Color.WhiteSmoke;
            btn20.NormalForeColor = Color.FromArgb(92, 0, 153);
            btn20.NormalImageTint = Color.White;
            btn20.NormalOutline = Color.FromArgb(92, 0, 153);
            btn20.OutlineThickness = 1F;
            btn20.PressedBackground = Color.WhiteSmoke;
            btn20.PressedForeColor = Color.FromArgb(32, 32, 32);
            btn20.PressedImageTint = Color.White;
            btn20.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btn20.Rounding = new Padding(8);
            btn20.Size = new Size(113, 41);
            btn20.TabIndex = 3;
            btn20.Tag = "20";
            btn20.TextAlignment = StringAlignment.Center;
            btn20.TextOffset = new Point(0, 0);
            btn20.Click += DiscountButton_Click;
            // 
            // btn10
            // 
            btn10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn10.BackColor = Color.Transparent;
            btn10.CheckButton = false;
            btn10.Checked = false;
            btn10.CheckedBackground = Color.FromArgb(195, 14, 14);
            btn10.CheckedForeColor = Color.Transparent;
            btn10.CheckedImageTint = Color.Transparent;
            btn10.CheckedOutline = Color.FromArgb(195, 14, 14);
            btn10.Content = "10%";
            btn10.DialogResult = DialogResult.None;
            btn10.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn10.ForeColor = Color.FromArgb(195, 14, 14);
            btn10.HoverBackground = Color.FromArgb(195, 14, 14);
            btn10.HoveredImageTint = Color.White;
            btn10.HoverForeColor = Color.Black;
            btn10.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btn10.Image = null;
            btn10.ImageAutoCenter = true;
            btn10.ImageExpand = new Point(0, 0);
            btn10.ImageOffset = new Point(0, 0);
            btn10.Location = new Point(122, 3);
            btn10.Name = "btn10";
            btn10.NormalBackground = Color.WhiteSmoke;
            btn10.NormalForeColor = Color.FromArgb(195, 14, 14);
            btn10.NormalImageTint = Color.White;
            btn10.NormalOutline = Color.FromArgb(195, 14, 14);
            btn10.OutlineThickness = 1F;
            btn10.PressedBackground = Color.WhiteSmoke;
            btn10.PressedForeColor = Color.FromArgb(32, 32, 32);
            btn10.PressedImageTint = Color.White;
            btn10.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btn10.Rounding = new Padding(8);
            btn10.Size = new Size(113, 41);
            btn10.TabIndex = 2;
            btn10.Tag = "10";
            btn10.TextAlignment = StringAlignment.Center;
            btn10.TextOffset = new Point(0, 0);
            btn10.Click += DiscountButton_Click;
            // 
            // btn5
            // 
            btn5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn5.BackColor = Color.Transparent;
            btn5.CheckButton = false;
            btn5.Checked = false;
            btn5.CheckedBackground = Color.FromArgb(255, 106, 0);
            btn5.CheckedForeColor = Color.Transparent;
            btn5.CheckedImageTint = Color.Transparent;
            btn5.CheckedOutline = Color.FromArgb(255, 106, 0);
            btn5.Content = "5%";
            btn5.DialogResult = DialogResult.None;
            btn5.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn5.ForeColor = Color.FromArgb(248, 150, 30);
            btn5.HoverBackground = Color.FromArgb(248, 150, 30);
            btn5.HoveredImageTint = Color.White;
            btn5.HoverForeColor = Color.Black;
            btn5.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btn5.Image = null;
            btn5.ImageAutoCenter = true;
            btn5.ImageExpand = new Point(0, 0);
            btn5.ImageOffset = new Point(0, 0);
            btn5.Location = new Point(3, 3);
            btn5.Name = "btn5";
            btn5.NormalBackground = Color.WhiteSmoke;
            btn5.NormalForeColor = Color.FromArgb(248, 150, 30);
            btn5.NormalImageTint = Color.White;
            btn5.NormalOutline = Color.FromArgb(248, 150, 30);
            btn5.OutlineThickness = 1F;
            btn5.PressedBackground = Color.WhiteSmoke;
            btn5.PressedForeColor = Color.FromArgb(32, 32, 32);
            btn5.PressedImageTint = Color.White;
            btn5.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btn5.Rounding = new Padding(8);
            btn5.Size = new Size(113, 41);
            btn5.TabIndex = 1;
            btn5.Tag = "5";
            btn5.TextAlignment = StringAlignment.Center;
            btn5.TextOffset = new Point(0, 0);
            btn5.Click += DiscountButton_Click;
            // 
            // DiscountButton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cuiPanel1);
            Name = "DiscountButton";
            Size = new Size(489, 106);
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private CuoreUI.Controls.cuiButton btnClear;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel9;
        private CuoreUI.Controls.cuiButton btn100;
        private CuoreUI.Controls.cuiButton btn20;
        private CuoreUI.Controls.cuiButton btn10;
        private CuoreUI.Controls.cuiButton btn5;
        private TextBox txtPercent;
        private TextBox txtPeso;
    }
}
