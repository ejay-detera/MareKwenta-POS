namespace Mare_POS
{
    partial class AddExpenseForm
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
            label1 = new Label();
            ExpenseNameText = new CuoreUI.Controls.cuiTextBox();
            ExpenseAmountText = new CuoreUI.Controls.cuiTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            CashRadio = new RadioButton();
            NonCashRadio = new RadioButton();
            AddExpenseButton = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unbounded SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(9, 15);
            label1.Name = "label1";
            label1.Size = new Size(245, 43);
            label1.TabIndex = 0;
            label1.Text = "Add Expense";
            // 
            // ExpenseNameText
            // 
            ExpenseNameText.BackgroundColor = Color.White;
            ExpenseNameText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            ExpenseNameText.Content = "";
            ExpenseNameText.FocusBackgroundColor = Color.White;
            ExpenseNameText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            ExpenseNameText.FocusImageTint = Color.White;
            ExpenseNameText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpenseNameText.ForeColor = Color.FromArgb(78, 45, 24);
            ExpenseNameText.Image = null;
            ExpenseNameText.ImageExpand = new Point(0, 0);
            ExpenseNameText.ImageOffset = new Point(0, 0);
            ExpenseNameText.Location = new Point(52, 123);
            ExpenseNameText.Margin = new Padding(5);
            ExpenseNameText.Multiline = false;
            ExpenseNameText.Name = "ExpenseNameText";
            ExpenseNameText.NormalImageTint = Color.White;
            ExpenseNameText.Padding = new Padding(23, 15, 23, 0);
            ExpenseNameText.PasswordChar = false;
            ExpenseNameText.PlaceholderColor = Color.White;
            ExpenseNameText.PlaceholderText = "";
            ExpenseNameText.Rounding = new Padding(12);
            ExpenseNameText.Size = new Size(312, 53);
            ExpenseNameText.TabIndex = 1;
            ExpenseNameText.TextOffset = new Size(0, 0);
            ExpenseNameText.UnderlinedStyle = true;
            // 
            // ExpenseAmountText
            // 
            ExpenseAmountText.BackgroundColor = Color.White;
            ExpenseAmountText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            ExpenseAmountText.Content = "";
            ExpenseAmountText.FocusBackgroundColor = Color.White;
            ExpenseAmountText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            ExpenseAmountText.FocusImageTint = Color.White;
            ExpenseAmountText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpenseAmountText.ForeColor = Color.FromArgb(78, 45, 24);
            ExpenseAmountText.Image = null;
            ExpenseAmountText.ImageExpand = new Point(0, 0);
            ExpenseAmountText.ImageOffset = new Point(0, 0);
            ExpenseAmountText.Location = new Point(52, 225);
            ExpenseAmountText.Margin = new Padding(5);
            ExpenseAmountText.Multiline = false;
            ExpenseAmountText.Name = "ExpenseAmountText";
            ExpenseAmountText.NormalImageTint = Color.White;
            ExpenseAmountText.Padding = new Padding(23, 15, 23, 0);
            ExpenseAmountText.PasswordChar = false;
            ExpenseAmountText.PlaceholderColor = Color.White;
            ExpenseAmountText.PlaceholderText = "";
            ExpenseAmountText.Rounding = new Padding(12);
            ExpenseAmountText.Size = new Size(312, 53);
            ExpenseAmountText.TabIndex = 2;
            ExpenseAmountText.TextOffset = new Size(0, 0);
            ExpenseAmountText.UnderlinedStyle = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.Location = new Point(15, 85);
            label2.Name = "label2";
            label2.Size = new Size(135, 24);
            label2.TabIndex = 3;
            label2.Text = "Expense Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(15, 196);
            label3.Name = "label3";
            label3.Size = new Size(153, 24);
            label3.TabIndex = 4;
            label3.Text = "Expense Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(15, 304);
            label4.Name = "label4";
            label4.Size = new Size(117, 24);
            label4.TabIndex = 5;
            label4.Text = "Expense Tag";
            // 
            // CashRadio
            // 
            CashRadio.AutoSize = true;
            CashRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(78, 45, 24);
            CashRadio.FlatStyle = FlatStyle.Flat;
            CashRadio.Font = new Font("Microsoft Sans Serif", 12F);
            CashRadio.ForeColor = Color.FromArgb(78, 45, 24);
            CashRadio.Location = new Point(37, 339);
            CashRadio.Margin = new Padding(3, 4, 3, 4);
            CashRadio.Name = "CashRadio";
            CashRadio.Size = new Size(79, 29);
            CashRadio.TabIndex = 6;
            CashRadio.TabStop = true;
            CashRadio.Text = "Cash";
            CashRadio.UseVisualStyleBackColor = true;
            // 
            // NonCashRadio
            // 
            NonCashRadio.AutoSize = true;
            NonCashRadio.FlatStyle = FlatStyle.Flat;
            NonCashRadio.Font = new Font("Microsoft Sans Serif", 12F);
            NonCashRadio.ForeColor = Color.FromArgb(78, 45, 24);
            NonCashRadio.Location = new Point(37, 376);
            NonCashRadio.Margin = new Padding(3, 4, 3, 4);
            NonCashRadio.Name = "NonCashRadio";
            NonCashRadio.Size = new Size(122, 29);
            NonCashRadio.TabIndex = 7;
            NonCashRadio.TabStop = true;
            NonCashRadio.Text = "Non-Cash";
            NonCashRadio.UseVisualStyleBackColor = true;
            // 
            // AddExpenseButton
            // 
            AddExpenseButton.CheckButton = false;
            AddExpenseButton.Checked = false;
            AddExpenseButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            AddExpenseButton.CheckedForeColor = Color.White;
            AddExpenseButton.CheckedImageTint = Color.White;
            AddExpenseButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            AddExpenseButton.Content = "Add";
            AddExpenseButton.DialogResult = DialogResult.None;
            AddExpenseButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            AddExpenseButton.ForeColor = Color.White;
            AddExpenseButton.HoverBackground = Color.FromArgb(50, 78, 45, 24);
            AddExpenseButton.HoveredImageTint = Color.White;
            AddExpenseButton.HoverForeColor = Color.FromArgb(78, 45, 24);
            AddExpenseButton.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            AddExpenseButton.Image = null;
            AddExpenseButton.ImageAutoCenter = true;
            AddExpenseButton.ImageExpand = new Point(0, 0);
            AddExpenseButton.ImageOffset = new Point(0, 0);
            AddExpenseButton.Location = new Point(284, 376);
            AddExpenseButton.Margin = new Padding(3, 4, 3, 4);
            AddExpenseButton.Name = "AddExpenseButton";
            AddExpenseButton.NormalBackground = Color.FromArgb(78, 45, 24);
            AddExpenseButton.NormalForeColor = Color.White;
            AddExpenseButton.NormalImageTint = Color.White;
            AddExpenseButton.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            AddExpenseButton.OutlineThickness = 1F;
            AddExpenseButton.PressedBackground = Color.WhiteSmoke;
            AddExpenseButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            AddExpenseButton.PressedImageTint = Color.White;
            AddExpenseButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            AddExpenseButton.Rounding = new Padding(8);
            AddExpenseButton.Size = new Size(97, 60);
            AddExpenseButton.TabIndex = 8;
            AddExpenseButton.TextAlignment = StringAlignment.Center;
            AddExpenseButton.TextOffset = new Point(0, 0);
            AddExpenseButton.Click += AddExpenseButton_Click;
            // 
            // AddExpenseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(422, 461);
            Controls.Add(AddExpenseButton);
            Controls.Add(NonCashRadio);
            Controls.Add(CashRadio);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ExpenseAmountText);
            Controls.Add(ExpenseNameText);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddExpenseForm";
            Text = "Add Expense";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CuoreUI.Controls.cuiTextBox ExpenseNameText;
        private CuoreUI.Controls.cuiTextBox ExpenseAmountText;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton CashRadio;
        private RadioButton NonCashRadio;
        private CuoreUI.Controls.cuiButton AddExpenseButton;
    }
}