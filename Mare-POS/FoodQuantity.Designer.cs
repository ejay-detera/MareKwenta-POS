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
            labelSubtotal = new Label();
            button1 = new Button();
            label1 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            AddButton = new CuoreUI.Controls.cuiButton();
            MinusButton = new CuoreUI.Controls.cuiButton();
            labelQuantity = new Label();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelSubtotal);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 96);
            panel1.TabIndex = 1;
            // 
            // labelSubtotal
            // 
            labelSubtotal.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtotal.ForeColor = Color.FromArgb(78, 45, 24);
            labelSubtotal.Location = new Point(180, 21);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(263, 49);
            labelSubtotal.TabIndex = 3;
            labelSubtotal.Text = "0.00";
            labelSubtotal.Click += label2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            label1.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(84, 21);
            label1.Name = "label1";
            label1.Size = new Size(263, 49);
            label1.TabIndex = 1;
            label1.Text = "Item ₱";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            panel3.Controls.Add(AddButton);
            panel3.Controls.Add(MinusButton);
            panel3.Controls.Add(labelQuantity);
            panel3.Location = new Point(0, 202);
            panel3.Name = "panel3";
            panel3.Size = new Size(493, 99);
            panel3.TabIndex = 10;
            // 
            // AddButton
            // 
            AddButton.CheckButton = false;
            AddButton.Checked = false;
            AddButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            AddButton.CheckedForeColor = Color.White;
            AddButton.CheckedImageTint = Color.White;
            AddButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            AddButton.Content = "+";
            AddButton.DialogResult = DialogResult.None;
            AddButton.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddButton.ForeColor = Color.Black;
            AddButton.HoverBackground = Color.FromArgb(242, 239, 234);
            AddButton.HoveredImageTint = Color.Transparent;
            AddButton.HoverForeColor = Color.Black;
            AddButton.HoverOutline = Color.Transparent;
            AddButton.Image = null;
            AddButton.ImageAutoCenter = true;
            AddButton.ImageExpand = new Point(0, 0);
            AddButton.ImageOffset = new Point(0, 0);
            AddButton.Location = new Point(273, 22);
            AddButton.Name = "AddButton";
            AddButton.NormalBackground = Color.FromArgb(242, 239, 234);
            AddButton.NormalForeColor = Color.Black;
            AddButton.NormalImageTint = Color.White;
            AddButton.NormalOutline = Color.Transparent;
            AddButton.OutlineThickness = 1F;
            AddButton.PressedBackground = Color.WhiteSmoke;
            AddButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            AddButton.PressedImageTint = Color.White;
            AddButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            AddButton.Rounding = new Padding(30);
            AddButton.Size = new Size(68, 60);
            AddButton.TabIndex = 17;
            AddButton.TextAlignment = StringAlignment.Center;
            AddButton.TextOffset = new Point(0, 0);
            AddButton.Click += AddButton_Click;
            // 
            // MinusButton
            // 
            MinusButton.CheckButton = false;
            MinusButton.Checked = false;
            MinusButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            MinusButton.CheckedForeColor = Color.White;
            MinusButton.CheckedImageTint = Color.White;
            MinusButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            MinusButton.Content = "–";
            MinusButton.DialogResult = DialogResult.None;
            MinusButton.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MinusButton.ForeColor = Color.Black;
            MinusButton.HoverBackground = Color.FromArgb(242, 239, 234);
            MinusButton.HoveredImageTint = Color.Transparent;
            MinusButton.HoverForeColor = Color.Black;
            MinusButton.HoverOutline = Color.Transparent;
            MinusButton.Image = null;
            MinusButton.ImageAutoCenter = true;
            MinusButton.ImageExpand = new Point(0, 0);
            MinusButton.ImageOffset = new Point(0, 0);
            MinusButton.Location = new Point(139, 22);
            MinusButton.Name = "MinusButton";
            MinusButton.NormalBackground = Color.FromArgb(242, 239, 234);
            MinusButton.NormalForeColor = Color.Black;
            MinusButton.NormalImageTint = Color.White;
            MinusButton.NormalOutline = Color.Transparent;
            MinusButton.OutlineThickness = 1F;
            MinusButton.PressedBackground = Color.WhiteSmoke;
            MinusButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            MinusButton.PressedImageTint = Color.White;
            MinusButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            MinusButton.Rounding = new Padding(30);
            MinusButton.Size = new Size(68, 60);
            MinusButton.TabIndex = 16;
            MinusButton.TextAlignment = StringAlignment.Center;
            MinusButton.TextOffset = new Point(0, 0);
            MinusButton.Click += MinusButton_Click;
            // 
            // labelQuantity
            // 
            labelQuantity.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelQuantity.ForeColor = Color.Black;
            labelQuantity.Location = new Point(221, 26);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(48, 48);
            labelQuantity.TabIndex = 15;
            labelQuantity.Text = "1";
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
            cuiButton1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            cuiButton1.Click += cuiButton1_Click;
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
            Load += FoodQuantity_Load;
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
        private CuoreUI.Controls.cuiButton AddButton;
        private CuoreUI.Controls.cuiButton MinusButton;
        private Label labelQuantity;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private Label labelSubtotal;
    }
}