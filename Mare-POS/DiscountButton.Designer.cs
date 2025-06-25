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
            cuiTextBox1 = new CuoreUI.Controls.cuiTextBox();
            cuiTextBox2 = new CuoreUI.Controls.cuiTextBox();
            cuiButton12 = new CuoreUI.Controls.cuiButton();
            tableLayoutPanel9 = new TableLayoutPanel();
            cuiButton8 = new CuoreUI.Controls.cuiButton();
            cuiButton9 = new CuoreUI.Controls.cuiButton();
            cuiButton10 = new CuoreUI.Controls.cuiButton();
            cuiButton11 = new CuoreUI.Controls.cuiButton();
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
            cuiPanel1.Size = new Size(489, 109);
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
            tableLayoutPanel2.Controls.Add(cuiTextBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(cuiTextBox2, 1, 0);
            tableLayoutPanel2.Controls.Add(cuiButton12, 2, 0);
            tableLayoutPanel2.Location = new Point(14, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(465, 47);
            tableLayoutPanel2.TabIndex = 40;
            // 
            // cuiTextBox1
            // 
            cuiTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiTextBox1.BackgroundColor = Color.WhiteSmoke;
            cuiTextBox1.BorderColor = Color.FromArgb(242, 239, 234);
            cuiTextBox1.Content = "₱";
            cuiTextBox1.FocusBackgroundColor = Color.White;
            cuiTextBox1.FocusBorderColor = Color.FromArgb(255, 106, 0);
            cuiTextBox1.FocusImageTint = Color.White;
            cuiTextBox1.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiTextBox1.ForeColor = Color.FromArgb(78, 45, 24);
            cuiTextBox1.Image = null;
            cuiTextBox1.ImageExpand = new Point(0, 0);
            cuiTextBox1.ImageOffset = new Point(0, 0);
            cuiTextBox1.Location = new Point(5, 4);
            cuiTextBox1.Margin = new Padding(5, 4, 5, 4);
            cuiTextBox1.Multiline = true;
            cuiTextBox1.Name = "cuiTextBox1";
            cuiTextBox1.NormalImageTint = Color.White;
            cuiTextBox1.Padding = new Padding(17, 6, 17, 6);
            cuiTextBox1.PasswordChar = false;
            cuiTextBox1.PlaceholderColor = SystemColors.WindowText;
            cuiTextBox1.PlaceholderText = "";
            cuiTextBox1.Rounding = new Padding(8);
            cuiTextBox1.Size = new Size(145, 39);
            cuiTextBox1.TabIndex = 10;
            cuiTextBox1.TextOffset = new Size(0, 0);
            cuiTextBox1.UnderlinedStyle = true;
            // 
            // cuiTextBox2
            // 
            cuiTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiTextBox2.BackgroundColor = Color.WhiteSmoke;
            cuiTextBox2.BorderColor = Color.FromArgb(242, 239, 234);
            cuiTextBox2.Content = "%";
            cuiTextBox2.FocusBackgroundColor = Color.White;
            cuiTextBox2.FocusBorderColor = Color.FromArgb(255, 106, 0);
            cuiTextBox2.FocusImageTint = Color.White;
            cuiTextBox2.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiTextBox2.ForeColor = Color.FromArgb(78, 45, 24);
            cuiTextBox2.Image = null;
            cuiTextBox2.ImageExpand = new Point(0, 0);
            cuiTextBox2.ImageOffset = new Point(0, 0);
            cuiTextBox2.Location = new Point(160, 4);
            cuiTextBox2.Margin = new Padding(5, 4, 5, 4);
            cuiTextBox2.Multiline = true;
            cuiTextBox2.Name = "cuiTextBox2";
            cuiTextBox2.NormalImageTint = Color.White;
            cuiTextBox2.Padding = new Padding(17, 6, 17, 6);
            cuiTextBox2.PasswordChar = false;
            cuiTextBox2.PlaceholderColor = SystemColors.WindowText;
            cuiTextBox2.PlaceholderText = "";
            cuiTextBox2.Rounding = new Padding(8);
            cuiTextBox2.Size = new Size(145, 39);
            cuiTextBox2.TabIndex = 9;
            cuiTextBox2.TextOffset = new Size(0, 0);
            cuiTextBox2.UnderlinedStyle = true;
            // 
            // cuiButton12
            // 
            cuiButton12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiButton12.BackColor = Color.Transparent;
            cuiButton12.CheckButton = false;
            cuiButton12.Checked = false;
            cuiButton12.CheckedBackground = Color.FromArgb(158, 43, 43);
            cuiButton12.CheckedForeColor = Color.Transparent;
            cuiButton12.CheckedImageTint = Color.Transparent;
            cuiButton12.CheckedOutline = Color.FromArgb(158, 43, 43);
            cuiButton12.Content = "Clear";
            cuiButton12.DialogResult = DialogResult.None;
            cuiButton12.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton12.ForeColor = Color.FromArgb(158, 43, 43);
            cuiButton12.HoverBackground = Color.FromArgb(158, 43, 43);
            cuiButton12.HoveredImageTint = Color.White;
            cuiButton12.HoverForeColor = Color.Black;
            cuiButton12.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton12.Image = null;
            cuiButton12.ImageAutoCenter = true;
            cuiButton12.ImageExpand = new Point(0, 0);
            cuiButton12.ImageOffset = new Point(0, 0);
            cuiButton12.Location = new Point(313, 3);
            cuiButton12.Name = "cuiButton12";
            cuiButton12.NormalBackground = Color.WhiteSmoke;
            cuiButton12.NormalForeColor = Color.FromArgb(158, 43, 43);
            cuiButton12.NormalImageTint = Color.White;
            cuiButton12.NormalOutline = Color.FromArgb(158, 43, 43);
            cuiButton12.OutlineThickness = 1F;
            cuiButton12.PressedBackground = Color.WhiteSmoke;
            cuiButton12.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton12.PressedImageTint = Color.White;
            cuiButton12.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton12.Rounding = new Padding(8);
            cuiButton12.Size = new Size(149, 41);
            cuiButton12.TabIndex = 7;
            cuiButton12.TextAlignment = StringAlignment.Center;
            cuiButton12.TextOffset = new Point(0, 0);
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
            tableLayoutPanel9.Controls.Add(cuiButton8, 3, 0);
            tableLayoutPanel9.Controls.Add(cuiButton9, 2, 0);
            tableLayoutPanel9.Controls.Add(cuiButton10, 1, 0);
            tableLayoutPanel9.Controls.Add(cuiButton11, 0, 0);
            tableLayoutPanel9.Location = new Point(6, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel9.Size = new Size(479, 47);
            tableLayoutPanel9.TabIndex = 33;
            // 
            // cuiButton8
            // 
            cuiButton8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiButton8.BackColor = Color.Transparent;
            cuiButton8.CheckButton = false;
            cuiButton8.Checked = false;
            cuiButton8.CheckedBackground = Color.FromArgb(135, 167, 10);
            cuiButton8.CheckedForeColor = Color.Transparent;
            cuiButton8.CheckedImageTint = Color.Transparent;
            cuiButton8.CheckedOutline = Color.FromArgb(135, 167, 10);
            cuiButton8.Content = "100%";
            cuiButton8.DialogResult = DialogResult.None;
            cuiButton8.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton8.ForeColor = Color.FromArgb(135, 167, 10);
            cuiButton8.HoverBackground = Color.FromArgb(135, 167, 10);
            cuiButton8.HoveredImageTint = Color.White;
            cuiButton8.HoverForeColor = Color.Black;
            cuiButton8.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton8.Image = null;
            cuiButton8.ImageAutoCenter = true;
            cuiButton8.ImageExpand = new Point(0, 0);
            cuiButton8.ImageOffset = new Point(0, 0);
            cuiButton8.Location = new Point(360, 3);
            cuiButton8.Name = "cuiButton8";
            cuiButton8.NormalBackground = Color.WhiteSmoke;
            cuiButton8.NormalForeColor = Color.FromArgb(135, 167, 10);
            cuiButton8.NormalImageTint = Color.White;
            cuiButton8.NormalOutline = Color.FromArgb(135, 167, 10);
            cuiButton8.OutlineThickness = 1F;
            cuiButton8.PressedBackground = Color.WhiteSmoke;
            cuiButton8.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton8.PressedImageTint = Color.White;
            cuiButton8.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton8.Rounding = new Padding(8);
            cuiButton8.Size = new Size(116, 41);
            cuiButton8.TabIndex = 4;
            cuiButton8.TextAlignment = StringAlignment.Center;
            cuiButton8.TextOffset = new Point(0, 0);
            // 
            // cuiButton9
            // 
            cuiButton9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiButton9.BackColor = Color.Transparent;
            cuiButton9.CheckButton = false;
            cuiButton9.Checked = false;
            cuiButton9.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton9.CheckedForeColor = Color.Transparent;
            cuiButton9.CheckedImageTint = Color.Transparent;
            cuiButton9.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton9.Content = "20%";
            cuiButton9.DialogResult = DialogResult.None;
            cuiButton9.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton9.ForeColor = Color.FromArgb(92, 0, 153);
            cuiButton9.HoverBackground = Color.FromArgb(92, 0, 153);
            cuiButton9.HoveredImageTint = Color.White;
            cuiButton9.HoverForeColor = Color.Black;
            cuiButton9.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton9.Image = null;
            cuiButton9.ImageAutoCenter = true;
            cuiButton9.ImageExpand = new Point(0, 0);
            cuiButton9.ImageOffset = new Point(0, 0);
            cuiButton9.Location = new Point(241, 3);
            cuiButton9.Name = "cuiButton9";
            cuiButton9.NormalBackground = Color.WhiteSmoke;
            cuiButton9.NormalForeColor = Color.FromArgb(92, 0, 153);
            cuiButton9.NormalImageTint = Color.White;
            cuiButton9.NormalOutline = Color.FromArgb(92, 0, 153);
            cuiButton9.OutlineThickness = 1F;
            cuiButton9.PressedBackground = Color.WhiteSmoke;
            cuiButton9.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton9.PressedImageTint = Color.White;
            cuiButton9.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton9.Rounding = new Padding(8);
            cuiButton9.Size = new Size(113, 41);
            cuiButton9.TabIndex = 3;
            cuiButton9.TextAlignment = StringAlignment.Center;
            cuiButton9.TextOffset = new Point(0, 0);
            // 
            // cuiButton10
            // 
            cuiButton10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiButton10.BackColor = Color.Transparent;
            cuiButton10.CheckButton = false;
            cuiButton10.Checked = false;
            cuiButton10.CheckedBackground = Color.FromArgb(195, 14, 14);
            cuiButton10.CheckedForeColor = Color.Transparent;
            cuiButton10.CheckedImageTint = Color.Transparent;
            cuiButton10.CheckedOutline = Color.FromArgb(195, 14, 14);
            cuiButton10.Content = "10%";
            cuiButton10.DialogResult = DialogResult.None;
            cuiButton10.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton10.ForeColor = Color.FromArgb(195, 14, 14);
            cuiButton10.HoverBackground = Color.FromArgb(195, 14, 14);
            cuiButton10.HoveredImageTint = Color.White;
            cuiButton10.HoverForeColor = Color.Black;
            cuiButton10.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton10.Image = null;
            cuiButton10.ImageAutoCenter = true;
            cuiButton10.ImageExpand = new Point(0, 0);
            cuiButton10.ImageOffset = new Point(0, 0);
            cuiButton10.Location = new Point(122, 3);
            cuiButton10.Name = "cuiButton10";
            cuiButton10.NormalBackground = Color.WhiteSmoke;
            cuiButton10.NormalForeColor = Color.FromArgb(195, 14, 14);
            cuiButton10.NormalImageTint = Color.White;
            cuiButton10.NormalOutline = Color.FromArgb(195, 14, 14);
            cuiButton10.OutlineThickness = 1F;
            cuiButton10.PressedBackground = Color.WhiteSmoke;
            cuiButton10.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton10.PressedImageTint = Color.White;
            cuiButton10.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton10.Rounding = new Padding(8);
            cuiButton10.Size = new Size(113, 41);
            cuiButton10.TabIndex = 2;
            cuiButton10.TextAlignment = StringAlignment.Center;
            cuiButton10.TextOffset = new Point(0, 0);
            // 
            // cuiButton11
            // 
            cuiButton11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiButton11.BackColor = Color.Transparent;
            cuiButton11.CheckButton = false;
            cuiButton11.Checked = false;
            cuiButton11.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton11.CheckedForeColor = Color.Transparent;
            cuiButton11.CheckedImageTint = Color.Transparent;
            cuiButton11.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton11.Content = "5%";
            cuiButton11.DialogResult = DialogResult.None;
            cuiButton11.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton11.ForeColor = Color.FromArgb(248, 150, 30);
            cuiButton11.HoverBackground = Color.FromArgb(248, 150, 30);
            cuiButton11.HoveredImageTint = Color.White;
            cuiButton11.HoverForeColor = Color.Black;
            cuiButton11.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton11.Image = null;
            cuiButton11.ImageAutoCenter = true;
            cuiButton11.ImageExpand = new Point(0, 0);
            cuiButton11.ImageOffset = new Point(0, 0);
            cuiButton11.Location = new Point(3, 3);
            cuiButton11.Name = "cuiButton11";
            cuiButton11.NormalBackground = Color.WhiteSmoke;
            cuiButton11.NormalForeColor = Color.FromArgb(248, 150, 30);
            cuiButton11.NormalImageTint = Color.White;
            cuiButton11.NormalOutline = Color.FromArgb(248, 150, 30);
            cuiButton11.OutlineThickness = 1F;
            cuiButton11.PressedBackground = Color.WhiteSmoke;
            cuiButton11.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton11.PressedImageTint = Color.White;
            cuiButton11.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton11.Rounding = new Padding(8);
            cuiButton11.Size = new Size(113, 41);
            cuiButton11.TabIndex = 1;
            cuiButton11.TextAlignment = StringAlignment.Center;
            cuiButton11.TextOffset = new Point(0, 0);
            // 
            // DiscountButton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cuiPanel1);
            Name = "DiscountButton";
            Size = new Size(489, 109);
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private CuoreUI.Controls.cuiButton cuiButton12;
        private CuoreUI.Controls.cuiTextBox cuiTextBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel9;
        private CuoreUI.Controls.cuiButton cuiButton8;
        private CuoreUI.Controls.cuiButton cuiButton9;
        private CuoreUI.Controls.cuiButton cuiButton10;
        private CuoreUI.Controls.cuiButton cuiButton11;
        private CuoreUI.Controls.cuiTextBox cuiTextBox1;
    }
}
