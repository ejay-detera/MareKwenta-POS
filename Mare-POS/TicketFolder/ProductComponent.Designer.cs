namespace Mare_POS.Ticket_Components
{
    partial class ProductComponent
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
            label2 = new Label();
            panel2 = new Panel();
            radioVenti = new RadioButton();
            radioGrande = new RadioButton();
            label4 = new Label();
            panel4 = new Panel();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            label5 = new Label();
            panel5 = new Panel();
            radioHot = new RadioButton();
            radioCold = new RadioButton();
            btnPlus = new CuoreUI.Controls.cuiButton();
            btnMinus = new CuoreUI.Controls.cuiButton();
            labelQuantity = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
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
            panel1.Size = new Size(603, 70);
            panel1.TabIndex = 0;
            // 
            // labelSubtotal
            // 
            labelSubtotal.Anchor = AnchorStyles.None;
            labelSubtotal.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtotal.ForeColor = Color.FromArgb(78, 45, 24);
            labelSubtotal.Location = new Point(185, 13);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(263, 49);
            labelSubtotal.TabIndex = 3;
            labelSubtotal.Text = "0.00";
            labelSubtotal.Click += label6_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(78, 45, 24);
            button1.Location = new Point(13, 9);
            button1.Name = "button1";
            button1.Size = new Size(54, 55);
            button1.TabIndex = 2;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(84, 13);
            label1.Name = "label1";
            label1.Size = new Size(263, 49);
            label1.TabIndex = 1;
            label1.Text = "Item ₱";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.Location = new Point(24, 73);
            label2.Name = "label2";
            label2.Size = new Size(79, 35);
            label2.TabIndex = 3;
            label2.Text = "Size";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(radioVenti);
            panel2.Controls.Add(radioGrande);
            panel2.Location = new Point(0, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(702, 48);
            panel2.TabIndex = 4;
            // 
            // radioVenti
            // 
            radioVenti.FlatAppearance.BorderColor = Color.Black;
            radioVenti.FlatAppearance.BorderSize = 4;
            radioVenti.Font = new Font("Microsoft Sans Serif", 15F);
            radioVenti.Location = new Point(163, 6);
            radioVenti.Name = "radioVenti";
            radioVenti.Size = new Size(137, 37);
            radioVenti.TabIndex = 1;
            radioVenti.TabStop = true;
            radioVenti.Text = "Venti";
            radioVenti.TextAlign = ContentAlignment.MiddleCenter;
            radioVenti.UseVisualStyleBackColor = true;
            radioVenti.CheckedChanged += radioVenti_CheckedChanged_1;
            // 
            // radioGrande
            // 
            radioGrande.FlatAppearance.BorderColor = Color.Black;
            radioGrande.FlatAppearance.BorderSize = 4;
            radioGrande.Font = new Font("Microsoft Sans Serif", 15F);
            radioGrande.Location = new Point(379, 6);
            radioGrande.Name = "radioGrande";
            radioGrande.Size = new Size(137, 37);
            radioGrande.TabIndex = 1;
            radioGrande.TabStop = true;
            radioGrande.Text = "Grande";
            radioGrande.TextAlign = ContentAlignment.MiddleCenter;
            radioGrande.UseVisualStyleBackColor = true;
            radioGrande.CheckedChanged += radioGrande_CheckedChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(24, 276);
            label4.Name = "label4";
            label4.Size = new Size(140, 33);
            label4.TabIndex = 7;
            label4.Text = "Quantity";
            // 
            // panel4
            // 
            panel4.Controls.Add(cuiButton1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 455);
            panel4.Name = "panel4";
            panel4.Size = new Size(603, 84);
            panel4.TabIndex = 9;
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
            cuiButton1.Location = new Point(433, 13);
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
            cuiButton1.Size = new Size(148, 59);
            cuiButton1.TabIndex = 7;
            cuiButton1.TextAlignment = StringAlignment.Center;
            cuiButton1.TextOffset = new Point(0, 0);
            cuiButton1.Click += cuiButton1_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(78, 45, 24);
            label5.Location = new Point(24, 167);
            label5.Name = "label5";
            label5.Size = new Size(90, 35);
            label5.TabIndex = 10;
            label5.Text = "Type";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.Controls.Add(radioHot);
            panel5.Controls.Add(radioCold);
            panel5.Location = new Point(0, 208);
            panel5.Name = "panel5";
            panel5.Size = new Size(702, 48);
            panel5.TabIndex = 11;
            // 
            // radioHot
            // 
            radioHot.FlatAppearance.BorderColor = Color.Black;
            radioHot.FlatAppearance.BorderSize = 4;
            radioHot.Font = new Font("Microsoft Sans Serif", 15F);
            radioHot.Location = new Point(163, 6);
            radioHot.Name = "radioHot";
            radioHot.Size = new Size(137, 37);
            radioHot.TabIndex = 1;
            radioHot.TabStop = true;
            radioHot.Text = "Hot";
            radioHot.TextAlign = ContentAlignment.MiddleCenter;
            radioHot.UseVisualStyleBackColor = true;
            radioHot.CheckedChanged += radioHot_CheckedChanged;
            // 
            // radioCold
            // 
            radioCold.FlatAppearance.BorderColor = Color.Black;
            radioCold.FlatAppearance.BorderSize = 4;
            radioCold.Font = new Font("Microsoft Sans Serif", 15F);
            radioCold.Location = new Point(379, 6);
            radioCold.Name = "radioCold";
            radioCold.Size = new Size(137, 37);
            radioCold.TabIndex = 1;
            radioCold.TabStop = true;
            radioCold.Text = "Iced";
            radioCold.TextAlign = ContentAlignment.MiddleCenter;
            radioCold.UseVisualStyleBackColor = true;
            radioCold.CheckedChanged += radioCold_CheckedChanged;
            // 
            // btnPlus
            // 
            btnPlus.Anchor = AnchorStyles.None;
            btnPlus.CheckButton = false;
            btnPlus.Checked = false;
            btnPlus.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnPlus.CheckedForeColor = Color.White;
            btnPlus.CheckedImageTint = Color.White;
            btnPlus.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnPlus.Content = "+";
            btnPlus.DialogResult = DialogResult.None;
            btnPlus.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlus.ForeColor = Color.Black;
            btnPlus.HoverBackground = Color.FromArgb(242, 239, 234);
            btnPlus.HoveredImageTint = Color.Transparent;
            btnPlus.HoverForeColor = Color.Black;
            btnPlus.HoverOutline = Color.Transparent;
            btnPlus.Image = null;
            btnPlus.ImageAutoCenter = true;
            btnPlus.ImageExpand = new Point(0, 0);
            btnPlus.ImageOffset = new Point(0, 0);
            btnPlus.Location = new Point(327, 339);
            btnPlus.Name = "btnPlus";
            btnPlus.NormalBackground = Color.FromArgb(242, 239, 234);
            btnPlus.NormalForeColor = Color.Black;
            btnPlus.NormalImageTint = Color.White;
            btnPlus.NormalOutline = Color.Transparent;
            btnPlus.OutlineThickness = 1F;
            btnPlus.PressedBackground = Color.WhiteSmoke;
            btnPlus.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnPlus.PressedImageTint = Color.White;
            btnPlus.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnPlus.Rounding = new Padding(30);
            btnPlus.Size = new Size(68, 56);
            btnPlus.TabIndex = 14;
            btnPlus.TextAlignment = StringAlignment.Center;
            btnPlus.TextOffset = new Point(0, 0);
            btnPlus.Click += cuiButton3_Click;
            // 
            // btnMinus
            // 
            btnMinus.Anchor = AnchorStyles.None;
            btnMinus.CheckButton = false;
            btnMinus.Checked = false;
            btnMinus.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnMinus.CheckedForeColor = Color.White;
            btnMinus.CheckedImageTint = Color.White;
            btnMinus.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnMinus.Content = "–";
            btnMinus.DialogResult = DialogResult.None;
            btnMinus.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.ForeColor = Color.Black;
            btnMinus.HoverBackground = Color.FromArgb(242, 239, 234);
            btnMinus.HoveredImageTint = Color.Transparent;
            btnMinus.HoverForeColor = Color.Black;
            btnMinus.HoverOutline = Color.Transparent;
            btnMinus.Image = null;
            btnMinus.ImageAutoCenter = true;
            btnMinus.ImageExpand = new Point(0, 0);
            btnMinus.ImageOffset = new Point(0, 0);
            btnMinus.Location = new Point(180, 339);
            btnMinus.Name = "btnMinus";
            btnMinus.NormalBackground = Color.FromArgb(242, 239, 234);
            btnMinus.NormalForeColor = Color.Black;
            btnMinus.NormalImageTint = Color.White;
            btnMinus.NormalOutline = Color.Transparent;
            btnMinus.OutlineThickness = 1F;
            btnMinus.PressedBackground = Color.WhiteSmoke;
            btnMinus.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnMinus.PressedImageTint = Color.White;
            btnMinus.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnMinus.Rounding = new Padding(30);
            btnMinus.Size = new Size(68, 56);
            btnMinus.TabIndex = 13;
            btnMinus.TextAlignment = StringAlignment.Center;
            btnMinus.TextOffset = new Point(0, 0);
            btnMinus.Click += MinusButton_Click;
            // 
            // labelQuantity
            // 
            labelQuantity.Anchor = AnchorStyles.None;
            labelQuantity.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelQuantity.ForeColor = Color.Black;
            labelQuantity.Location = new Point(273, 351);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(48, 44);
            labelQuantity.TabIndex = 12;
            labelQuantity.Text = "1";
            labelQuantity.Click += QuantityLabel_Click;
            // 
            // ProductComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(603, 539);
            ControlBox = false;
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(labelQuantity);
            Controls.Add(panel5);
            Controls.Add(label5);
            Controls.Add(panel4);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductComponent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Component";
            TransparencyKey = Color.Transparent;
            Load += ProductComponent_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Panel panel2;
        private RadioButton radioVenti;
        private Label label4;
        private Panel panel4;
        private RadioButton radioGrande;
        private Label label5;
        private Panel panel5;
        private RadioButton radioCold;
        private RadioButton radioHot;
        private CuoreUI.Controls.cuiButton btnPlus;
        private CuoreUI.Controls.cuiButton btnMinus;
        private Label labelQuantity;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private Label labelSubtotal;
    }
}