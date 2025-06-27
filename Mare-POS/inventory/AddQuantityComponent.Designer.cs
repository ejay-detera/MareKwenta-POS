namespace Mare_POS.inventory
{
    partial class AddQuantityComponent
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
            AddQuantityToIngredient = new CuoreUI.Controls.cuiTextBox();
            label1 = new Label();
            AddQuantityButton = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // AddQuantityToIngredient
            // 
            AddQuantityToIngredient.Anchor = AnchorStyles.None;
            AddQuantityToIngredient.BackColor = Color.White;
            AddQuantityToIngredient.BackgroundColor = Color.White;
            AddQuantityToIngredient.BorderColor = Color.FromArgb(224, 224, 224);
            AddQuantityToIngredient.Content = "";
            AddQuantityToIngredient.FocusBackgroundColor = Color.White;
            AddQuantityToIngredient.FocusBorderColor = Color.FromArgb(224, 224, 224);
            AddQuantityToIngredient.FocusImageTint = Color.White;
            AddQuantityToIngredient.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddQuantityToIngredient.ForeColor = Color.Green;
            AddQuantityToIngredient.Image = null;
            AddQuantityToIngredient.ImageExpand = new Point(0, 0);
            AddQuantityToIngredient.ImageOffset = new Point(0, 0);
            AddQuantityToIngredient.Location = new Point(76, 88);
            AddQuantityToIngredient.Margin = new Padding(4);
            AddQuantityToIngredient.Multiline = false;
            AddQuantityToIngredient.Name = "AddQuantityToIngredient";
            AddQuantityToIngredient.NormalImageTint = Color.White;
            AddQuantityToIngredient.Padding = new Padding(21, 11, 21, 0);
            AddQuantityToIngredient.PasswordChar = false;
            AddQuantityToIngredient.PlaceholderColor = Color.Green;
            AddQuantityToIngredient.PlaceholderText = "";
            AddQuantityToIngredient.Rounding = new Padding(8);
            AddQuantityToIngredient.Size = new Size(270, 42);
            AddQuantityToIngredient.TabIndex = 8;
            AddQuantityToIngredient.TextOffset = new Size(0, 0);
            AddQuantityToIngredient.UnderlinedStyle = true;
            AddQuantityToIngredient.ContentChanged += AddQuantityToIngredient_ContentChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unbounded SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(76, 19);
            label1.Name = "label1";
            label1.Size = new Size(254, 43);
            label1.TabIndex = 9;
            label1.Text = "Add Quantity";
            // 
            // AddQuantityButton
            // 
            AddQuantityButton.Anchor = AnchorStyles.None;
            AddQuantityButton.BackColor = Color.White;
            AddQuantityButton.CheckButton = false;
            AddQuantityButton.Checked = false;
            AddQuantityButton.CheckedBackground = Color.Transparent;
            AddQuantityButton.CheckedForeColor = Color.White;
            AddQuantityButton.CheckedImageTint = Color.White;
            AddQuantityButton.CheckedOutline = Color.Transparent;
            AddQuantityButton.Content = "Add";
            AddQuantityButton.DialogResult = DialogResult.None;
            AddQuantityButton.Font = new Font("Arial", 11.8F);
            AddQuantityButton.ForeColor = Color.White;
            AddQuantityButton.HoverBackground = Color.Transparent;
            AddQuantityButton.HoveredImageTint = Color.Transparent;
            AddQuantityButton.HoverForeColor = Color.Black;
            AddQuantityButton.HoverOutline = Color.Transparent;
            AddQuantityButton.Image = null;
            AddQuantityButton.ImageAutoCenter = true;
            AddQuantityButton.ImageExpand = new Point(0, 0);
            AddQuantityButton.ImageOffset = new Point(0, 0);
            AddQuantityButton.Location = new Point(140, 160);
            AddQuantityButton.Name = "AddQuantityButton";
            AddQuantityButton.NormalBackground = Color.Green;
            AddQuantityButton.NormalForeColor = Color.White;
            AddQuantityButton.NormalImageTint = Color.White;
            AddQuantityButton.NormalOutline = Color.Transparent;
            AddQuantityButton.OutlineThickness = 1F;
            AddQuantityButton.PressedBackground = Color.WhiteSmoke;
            AddQuantityButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            AddQuantityButton.PressedImageTint = Color.White;
            AddQuantityButton.PressedOutline = Color.Transparent;
            AddQuantityButton.Rounding = new Padding(8);
            AddQuantityButton.Size = new Size(127, 45);
            AddQuantityButton.TabIndex = 11;
            AddQuantityButton.TextAlignment = StringAlignment.Center;
            AddQuantityButton.TextOffset = new Point(0, 0);
            AddQuantityButton.Click += AddQuantityButton_Click;
            // 
            // AddQuantityComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(406, 231);
            Controls.Add(AddQuantityButton);
            Controls.Add(label1);
            Controls.Add(AddQuantityToIngredient);
            Name = "AddQuantityComponent";
            Text = "Add Quantity";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CuoreUI.Controls.cuiTextBox AddQuantityToIngredient;
        private Label label1;
        private CuoreUI.Controls.cuiButton AddQuantityButton;
    }
}