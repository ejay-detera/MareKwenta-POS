namespace Mare_POS
{
    partial class FoodQuantity
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            cuiButton3 = new CuoreUI.Controls.cuiButton();
            cuiButton2 = new CuoreUI.Controls.cuiButton();
            label6 = new Label();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 96);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Unbounded", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(78, 45, 24);
            button1.Location = new Point(22, 17);
            button1.Name = "button1";
            button1.Size = new Size(54, 55);
            button1.TabIndex = 2;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Unbounded Medium", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(84, 21);
            label1.Name = "label1";
            label1.Size = new Size(263, 49);
            label1.TabIndex = 1;
            label1.Text = "Item ₱ 0.00";
            // 
            // label4
            // 
            label4.Font = new Font("Inter 28pt 28pt", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(32, 21);
            label4.Name = "label4";
            label4.Size = new Size(156, 42);
            label4.TabIndex = 8;
            label4.Text = "Quantity";
            label4.Click += label4_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Location = new Point(0, 115);
            panel2.Name = "panel2";
            panel2.Size = new Size(493, 81);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Controls.Add(cuiButton3);
            panel3.Controls.Add(cuiButton2);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(0, 202);
            panel3.Name = "panel3";
            panel3.Size = new Size(493, 99);
            panel3.TabIndex = 10;
            // 
            // cuiButton3
            // 
            cuiButton3.CheckButton = false;
            cuiButton3.Checked = false;
            cuiButton3.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton3.CheckedForeColor = Color.White;
            cuiButton3.CheckedImageTint = Color.White;
            cuiButton3.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton3.Content = "+";
            cuiButton3.DialogResult = DialogResult.None;
            cuiButton3.Font = new Font("Unbounded SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton3.ForeColor = Color.Black;
            cuiButton3.HoverBackground = Color.FromArgb(242, 239, 234);
            cuiButton3.HoveredImageTint = Color.Transparent;
            cuiButton3.HoverForeColor = Color.Black;
            cuiButton3.HoverOutline = Color.Transparent;
            cuiButton3.Image = null;
            cuiButton3.ImageAutoCenter = true;
            cuiButton3.ImageExpand = new Point(0, 0);
            cuiButton3.ImageOffset = new Point(0, 0);
            cuiButton3.Location = new Point(273, 22);
            cuiButton3.Name = "cuiButton3";
            cuiButton3.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton3.NormalForeColor = Color.Black;
            cuiButton3.NormalImageTint = Color.White;
            cuiButton3.NormalOutline = Color.Transparent;
            cuiButton3.OutlineThickness = 1F;
            cuiButton3.PressedBackground = Color.WhiteSmoke;
            cuiButton3.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton3.PressedImageTint = Color.White;
            cuiButton3.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton3.Rounding = new Padding(30);
            cuiButton3.Size = new Size(68, 60);
            cuiButton3.TabIndex = 17;
            cuiButton3.TextAlignment = StringAlignment.Center;
            cuiButton3.TextOffset = new Point(0, 0);
            // 
            // cuiButton2
            // 
            cuiButton2.CheckButton = false;
            cuiButton2.Checked = false;
            cuiButton2.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton2.CheckedForeColor = Color.White;
            cuiButton2.CheckedImageTint = Color.White;
            cuiButton2.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton2.Content = "–";
            cuiButton2.DialogResult = DialogResult.None;
            cuiButton2.Font = new Font("Unbounded SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton2.ForeColor = Color.Black;
            cuiButton2.HoverBackground = Color.FromArgb(242, 239, 234);
            cuiButton2.HoveredImageTint = Color.Transparent;
            cuiButton2.HoverForeColor = Color.Black;
            cuiButton2.HoverOutline = Color.Transparent;
            cuiButton2.Image = null;
            cuiButton2.ImageAutoCenter = true;
            cuiButton2.ImageExpand = new Point(0, 0);
            cuiButton2.ImageOffset = new Point(0, 0);
            cuiButton2.Location = new Point(139, 22);
            cuiButton2.Name = "cuiButton2";
            cuiButton2.NormalBackground = Color.FromArgb(242, 239, 234);
            cuiButton2.NormalForeColor = Color.Black;
            cuiButton2.NormalImageTint = Color.White;
            cuiButton2.NormalOutline = Color.Transparent;
            cuiButton2.OutlineThickness = 1F;
            cuiButton2.PressedBackground = Color.WhiteSmoke;
            cuiButton2.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton2.PressedImageTint = Color.White;
            cuiButton2.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton2.Rounding = new Padding(30);
            cuiButton2.Size = new Size(68, 60);
            cuiButton2.TabIndex = 16;
            cuiButton2.TextAlignment = StringAlignment.Center;
            cuiButton2.TextOffset = new Point(0, 0);
            // 
            // label6
            // 
            label6.Font = new Font("Unbounded", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(221, 26);
            label6.Name = "label6";
            label6.Size = new Size(48, 48);
            label6.TabIndex = 15;
            label6.Text = "2";
            // 
            // cuiButton1
            // 
            cuiButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cuiButton1.CheckButton = false;
            cuiButton1.Checked = false;
            cuiButton1.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton1.CheckedForeColor = Color.White;
            cuiButton1.CheckedImageTint = Color.White;
            cuiButton1.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton1.Content = "DONE";
            cuiButton1.DialogResult = DialogResult.None;
            cuiButton1.Font = new Font("Unbounded", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiButton1.ForeColor = Color.White;
            cuiButton1.HoverBackground = Color.White;
            cuiButton1.HoveredImageTint = Color.White;
            cuiButton1.HoverForeColor = Color.Black;
            cuiButton1.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton1.Image = null;
            cuiButton1.ImageAutoCenter = true;
            cuiButton1.ImageExpand = new Point(0, 0);
            cuiButton1.ImageOffset = new Point(0, 0);
            cuiButton1.Location = new Point(365, 361);
            cuiButton1.Name = "cuiButton1";
            cuiButton1.NormalBackground = Color.FromArgb(78, 45, 24);
            cuiButton1.NormalForeColor = Color.White;
            cuiButton1.NormalImageTint = Color.White;
            cuiButton1.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.OutlineThickness = 1F;
            cuiButton1.PressedBackground = Color.WhiteSmoke;
            cuiButton1.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton1.PressedImageTint = Color.White;
            cuiButton1.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.Rounding = new Padding(8);
            cuiButton1.Size = new Size(101, 47);
            cuiButton1.TabIndex = 11;
            cuiButton1.TextAlignment = StringAlignment.Center;
            cuiButton1.TextOffset = new Point(0, 0);
            // 
            // FoodQuantity
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 429);
            ControlBox = false;
            Controls.Add(cuiButton1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FoodQuantity";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FoodQuantity";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Label label4;
        private Panel panel2;
        private Panel panel3;
        private CuoreUI.Controls.cuiButton cuiButton3;
        private CuoreUI.Controls.cuiButton cuiButton2;
        private Label label6;
        private CuoreUI.Controls.cuiButton cuiButton1;
    }
}