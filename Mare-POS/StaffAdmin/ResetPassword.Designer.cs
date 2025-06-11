namespace Mare_POS.StaffAdmin
{
    partial class ResetPassword
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
            label6 = new Label();
            UsernameText = new CuoreUI.Controls.cuiTextBox();
            PasswordText = new CuoreUI.Controls.cuiTextBox();
            label3 = new Label();
            ResetButton = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unbounded SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(304, 43);
            label1.TabIndex = 2;
            label1.Text = "Reset Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(78, 45, 24);
            label6.Location = new Point(34, 86);
            label6.Name = "label6";
            label6.Size = new Size(96, 24);
            label6.TabIndex = 17;
            label6.Text = "Username";
            // 
            // UsernameText
            // 
            UsernameText.BackgroundColor = Color.White;
            UsernameText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            UsernameText.Content = "";
            UsernameText.FocusBackgroundColor = Color.White;
            UsernameText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            UsernameText.FocusImageTint = Color.White;
            UsernameText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameText.ForeColor = Color.FromArgb(78, 45, 24);
            UsernameText.Image = null;
            UsernameText.ImageExpand = new Point(0, 0);
            UsernameText.ImageOffset = new Point(0, 0);
            UsernameText.Location = new Point(48, 115);
            UsernameText.Margin = new Padding(5);
            UsernameText.Multiline = false;
            UsernameText.Name = "UsernameText";
            UsernameText.NormalImageTint = Color.White;
            UsernameText.Padding = new Padding(23, 10, 23, 0);
            UsernameText.PasswordChar = false;
            UsernameText.PlaceholderColor = Color.White;
            UsernameText.PlaceholderText = "";
            UsernameText.Rounding = new Padding(12);
            UsernameText.Size = new Size(324, 43);
            UsernameText.TabIndex = 18;
            UsernameText.TextOffset = new Size(0, 0);
            UsernameText.UnderlinedStyle = true;
            UsernameText.ContentChanged += this.UsernameText_ContentChanged;
            // 
            // PasswordText
            // 
            PasswordText.BackgroundColor = Color.White;
            PasswordText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            PasswordText.Content = "";
            PasswordText.FocusBackgroundColor = Color.White;
            PasswordText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            PasswordText.FocusImageTint = Color.White;
            PasswordText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordText.ForeColor = Color.FromArgb(78, 45, 24);
            PasswordText.Image = null;
            PasswordText.ImageExpand = new Point(0, 0);
            PasswordText.ImageOffset = new Point(0, 0);
            PasswordText.Location = new Point(60, 209);
            PasswordText.Margin = new Padding(5);
            PasswordText.Multiline = false;
            PasswordText.Name = "PasswordText";
            PasswordText.NormalImageTint = Color.White;
            PasswordText.Padding = new Padding(23, 12, 23, 0);
            PasswordText.PasswordChar = true;
            PasswordText.PlaceholderColor = Color.White;
            PasswordText.PlaceholderText = "";
            PasswordText.Rounding = new Padding(12);
            PasswordText.Size = new Size(312, 47);
            PasswordText.TabIndex = 19;
            PasswordText.TextOffset = new Size(0, 0);
            PasswordText.UnderlinedStyle = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(37, 180);
            label3.Name = "label3";
            label3.Size = new Size(134, 24);
            label3.TabIndex = 20;
            label3.Text = "New Password";
            // 
            // ResetButton
            // 
            ResetButton.CheckButton = false;
            ResetButton.Checked = false;
            ResetButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            ResetButton.CheckedForeColor = Color.White;
            ResetButton.CheckedImageTint = Color.White;
            ResetButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            ResetButton.Content = "Save";
            ResetButton.DialogResult = DialogResult.None;
            ResetButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            ResetButton.ForeColor = Color.White;
            ResetButton.HoverBackground = Color.FromArgb(50, 78, 45, 24);
            ResetButton.HoveredImageTint = Color.White;
            ResetButton.HoverForeColor = Color.FromArgb(78, 45, 24);
            ResetButton.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            ResetButton.Image = null;
            ResetButton.ImageAutoCenter = true;
            ResetButton.ImageExpand = new Point(0, 0);
            ResetButton.ImageOffset = new Point(0, 0);
            ResetButton.Location = new Point(121, 309);
            ResetButton.Margin = new Padding(3, 4, 3, 4);
            ResetButton.Name = "ResetButton";
            ResetButton.NormalBackground = Color.FromArgb(78, 45, 24);
            ResetButton.NormalForeColor = Color.White;
            ResetButton.NormalImageTint = Color.White;
            ResetButton.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            ResetButton.OutlineThickness = 1F;
            ResetButton.PressedBackground = Color.WhiteSmoke;
            ResetButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            ResetButton.PressedImageTint = Color.White;
            ResetButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            ResetButton.Rounding = new Padding(8);
            ResetButton.Size = new Size(185, 44);
            ResetButton.TabIndex = 21;
            ResetButton.TextAlignment = StringAlignment.Center;
            ResetButton.TextOffset = new Point(0, 0);
            ResetButton.Click += this.ResetButton_Click;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(430, 420);
            Controls.Add(ResetButton);
            Controls.Add(label3);
            Controls.Add(PasswordText);
            Controls.Add(UsernameText);
            Controls.Add(label6);
            Controls.Add(label1);
            Name = "ResetPassword";
            Text = "Reset Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label6;
        private CuoreUI.Controls.cuiTextBox UsernameText;
        private CuoreUI.Controls.cuiTextBox PasswordText;
        private Label label3;
        private CuoreUI.Controls.cuiButton ResetButton;
    }
}