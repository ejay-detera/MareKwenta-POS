namespace Mare_POS.CashboxFolder
{
    partial class EditExpense
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
            LabelExpense = new Label();
            ExpenseNameText = new CuoreUI.Controls.cuiTextBox();
            ExpenseAmountText = new CuoreUI.Controls.cuiTextBox();
            CashRadio = new RadioButton();
            NonCashRadio = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SaveButton = new CuoreUI.Controls.cuiButton();
            CancelButton = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // LabelExpense
            // 
            LabelExpense.AutoSize = true;
            LabelExpense.Font = new Font("Unbounded", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelExpense.Location = new Point(32, 9);
            LabelExpense.Name = "LabelExpense";
            LabelExpense.Size = new Size(264, 47);
            LabelExpense.TabIndex = 0;
            LabelExpense.Text = "Edit Expense";
            // 
            // ExpenseNameText
            // 
            ExpenseNameText.Anchor = AnchorStyles.None;
            ExpenseNameText.BackColor = Color.White;
            ExpenseNameText.BackgroundColor = Color.White;
            ExpenseNameText.BorderColor = Color.FromArgb(224, 224, 224);
            ExpenseNameText.Content = "";
            ExpenseNameText.FocusBackgroundColor = Color.White;
            ExpenseNameText.FocusBorderColor = Color.FromArgb(224, 224, 224);
            ExpenseNameText.FocusImageTint = Color.White;
            ExpenseNameText.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExpenseNameText.ForeColor = Color.Black;
            ExpenseNameText.Image = null;
            ExpenseNameText.ImageExpand = new Point(0, 0);
            ExpenseNameText.ImageOffset = new Point(0, 0);
            ExpenseNameText.Location = new Point(51, 124);
            ExpenseNameText.Margin = new Padding(4);
            ExpenseNameText.Multiline = false;
            ExpenseNameText.Name = "ExpenseNameText";
            ExpenseNameText.NormalImageTint = Color.White;
            ExpenseNameText.Padding = new Padding(21, 16, 21, 0);
            ExpenseNameText.PasswordChar = false;
            ExpenseNameText.PlaceholderColor = Color.Gray;
            ExpenseNameText.PlaceholderText = "Amount in Stock";
            ExpenseNameText.Rounding = new Padding(8);
            ExpenseNameText.Size = new Size(332, 52);
            ExpenseNameText.TabIndex = 5;
            ExpenseNameText.TextOffset = new Size(0, 0);
            ExpenseNameText.UnderlinedStyle = true;
            ExpenseNameText.ContentChanged += ExpenseNameText_ContentChanged;
            // 
            // ExpenseAmountText
            // 
            ExpenseAmountText.Anchor = AnchorStyles.None;
            ExpenseAmountText.BackColor = Color.White;
            ExpenseAmountText.BackgroundColor = Color.White;
            ExpenseAmountText.BorderColor = Color.FromArgb(224, 224, 224);
            ExpenseAmountText.Content = "";
            ExpenseAmountText.FocusBackgroundColor = Color.White;
            ExpenseAmountText.FocusBorderColor = Color.FromArgb(224, 224, 224);
            ExpenseAmountText.FocusImageTint = Color.White;
            ExpenseAmountText.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExpenseAmountText.ForeColor = Color.Black;
            ExpenseAmountText.Image = null;
            ExpenseAmountText.ImageExpand = new Point(0, 0);
            ExpenseAmountText.ImageOffset = new Point(0, 0);
            ExpenseAmountText.Location = new Point(51, 222);
            ExpenseAmountText.Margin = new Padding(4);
            ExpenseAmountText.Multiline = false;
            ExpenseAmountText.Name = "ExpenseAmountText";
            ExpenseAmountText.NormalImageTint = Color.White;
            ExpenseAmountText.Padding = new Padding(21, 16, 21, 0);
            ExpenseAmountText.PasswordChar = false;
            ExpenseAmountText.PlaceholderColor = Color.Gray;
            ExpenseAmountText.PlaceholderText = "Amount in Stock";
            ExpenseAmountText.Rounding = new Padding(8);
            ExpenseAmountText.Size = new Size(332, 52);
            ExpenseAmountText.TabIndex = 6;
            ExpenseAmountText.TextOffset = new Size(0, 0);
            ExpenseAmountText.UnderlinedStyle = true;
            // 
            // CashRadio
            // 
            CashRadio.AutoSize = true;
            CashRadio.FlatAppearance.CheckedBackColor = Color.FromArgb(78, 45, 24);
            CashRadio.FlatStyle = FlatStyle.Flat;
            CashRadio.Font = new Font("Microsoft Sans Serif", 12F);
            CashRadio.ForeColor = Color.FromArgb(78, 45, 24);
            CashRadio.Location = new Point(51, 332);
            CashRadio.Margin = new Padding(3, 4, 3, 4);
            CashRadio.Name = "CashRadio";
            CashRadio.Size = new Size(79, 29);
            CashRadio.TabIndex = 7;
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
            NonCashRadio.Location = new Point(51, 369);
            NonCashRadio.Margin = new Padding(3, 4, 3, 4);
            NonCashRadio.Name = "NonCashRadio";
            NonCashRadio.Size = new Size(122, 29);
            NonCashRadio.TabIndex = 8;
            NonCashRadio.TabStop = true;
            NonCashRadio.Text = "Non-Cash";
            NonCashRadio.UseVisualStyleBackColor = true;
            NonCashRadio.CheckedChanged += NonCashRadio_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.Location = new Point(32, 96);
            label2.Name = "label2";
            label2.Size = new Size(135, 24);
            label2.TabIndex = 9;
            label2.Text = "Expense Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(32, 194);
            label3.Name = "label3";
            label3.Size = new Size(153, 24);
            label3.TabIndex = 10;
            label3.Text = "Expense Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(32, 304);
            label4.Name = "label4";
            label4.Size = new Size(117, 24);
            label4.TabIndex = 11;
            label4.Text = "Expense Tag";
            // 
            // SaveButton
            // 
            SaveButton.CheckButton = false;
            SaveButton.Checked = false;
            SaveButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            SaveButton.CheckedForeColor = Color.White;
            SaveButton.CheckedImageTint = Color.White;
            SaveButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            SaveButton.Content = "Save";
            SaveButton.DialogResult = DialogResult.None;
            SaveButton.Font = new Font("Inter Medium", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = Color.White;
            SaveButton.HoverBackground = Color.FromArgb(50, 78, 45, 24);
            SaveButton.HoveredImageTint = Color.White;
            SaveButton.HoverForeColor = Color.FromArgb(78, 45, 24);
            SaveButton.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            SaveButton.Image = null;
            SaveButton.ImageAutoCenter = true;
            SaveButton.ImageExpand = new Point(0, 0);
            SaveButton.ImageOffset = new Point(0, 0);
            SaveButton.Location = new Point(39, 456);
            SaveButton.Margin = new Padding(3, 4, 3, 4);
            SaveButton.Name = "SaveButton";
            SaveButton.NormalBackground = Color.FromArgb(78, 45, 24);
            SaveButton.NormalForeColor = Color.White;
            SaveButton.NormalImageTint = Color.White;
            SaveButton.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            SaveButton.OutlineThickness = 1F;
            SaveButton.PressedBackground = Color.WhiteSmoke;
            SaveButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            SaveButton.PressedImageTint = Color.White;
            SaveButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            SaveButton.Rounding = new Padding(8);
            SaveButton.Size = new Size(134, 44);
            SaveButton.TabIndex = 12;
            SaveButton.TextAlignment = StringAlignment.Center;
            SaveButton.TextOffset = new Point(0, 0);
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.CheckButton = false;
            CancelButton.Checked = false;
            CancelButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            CancelButton.CheckedForeColor = Color.White;
            CancelButton.CheckedImageTint = Color.White;
            CancelButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            CancelButton.Content = "Cancel";
            CancelButton.DialogResult = DialogResult.None;
            CancelButton.Font = new Font("Inter Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelButton.ForeColor = Color.DimGray;
            CancelButton.HoverBackground = Color.FromArgb(50, 78, 45, 24);
            CancelButton.HoveredImageTint = Color.White;
            CancelButton.HoverForeColor = Color.Gray;
            CancelButton.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            CancelButton.Image = null;
            CancelButton.ImageAutoCenter = true;
            CancelButton.ImageExpand = new Point(0, 0);
            CancelButton.ImageOffset = new Point(0, 0);
            CancelButton.Location = new Point(285, 456);
            CancelButton.Margin = new Padding(3, 4, 3, 4);
            CancelButton.Name = "CancelButton";
            CancelButton.NormalBackground = Color.White;
            CancelButton.NormalForeColor = Color.DimGray;
            CancelButton.NormalImageTint = Color.White;
            CancelButton.NormalOutline = Color.Gray;
            CancelButton.OutlineThickness = 1F;
            CancelButton.PressedBackground = Color.Gray;
            CancelButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            CancelButton.PressedImageTint = Color.White;
            CancelButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            CancelButton.Rounding = new Padding(8);
            CancelButton.Size = new Size(134, 44);
            CancelButton.TabIndex = 13;
            CancelButton.TextAlignment = StringAlignment.Center;
            CancelButton.TextOffset = new Point(0, 0);
            CancelButton.Click += CancelButton_Click;
            // 
            // EditExpense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(476, 525);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NonCashRadio);
            Controls.Add(CashRadio);
            Controls.Add(ExpenseAmountText);
            Controls.Add(ExpenseNameText);
            Controls.Add(LabelExpense);
            ForeColor = Color.FromArgb(78, 45, 24);
            Name = "EditExpense";
            Text = "Edit Expense";
            Load += EditExpense_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelExpense;
        private CuoreUI.Controls.cuiTextBox ExpenseNameText;
        private CuoreUI.Controls.cuiTextBox ExpenseAmountText;
        private RadioButton CashRadio;
        private RadioButton NonCashRadio;
        private Label label2;
        private Label label3;
        private Label label4;
        private CuoreUI.Controls.cuiButton SaveButton;
        private CuoreUI.Controls.cuiButton CancelButton;
    }
}