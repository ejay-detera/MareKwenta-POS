namespace Mare_POS.Authentication
{
    partial class Log_In
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
            cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            cuiSeparator1 = new CuoreUI.Controls.cuiSeparator();
            cuiLabel2 = new CuoreUI.Controls.cuiLabel();
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            LoginButton = new CuoreUI.Controls.cuiButton();
            label2 = new Label();
            PasswordText = new CuoreUI.Controls.cuiTextBox();
            UsernameText = new CuoreUI.Controls.cuiTextBox();
            label1 = new Label();
            cuiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cuiLabel1
            // 
            cuiLabel1.Anchor = AnchorStyles.None;
            cuiLabel1.Content = "MareKwenta";
            cuiLabel1.Font = new Font("Unbounded", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiLabel1.HorizontalAlignment = StringAlignment.Center;
            cuiLabel1.Location = new Point(592, 249);
            cuiLabel1.Margin = new Padding(4, 5, 4, 5);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(495, 54);
            cuiLabel1.TabIndex = 0;
            cuiLabel1.VerticalAlignment = StringAlignment.Near;
            // 
            // cuiSeparator1
            // 
            cuiSeparator1.Anchor = AnchorStyles.None;
            cuiSeparator1.ForeColor = Color.FromArgb(78, 45, 24);
            cuiSeparator1.Location = new Point(643, 274);
            cuiSeparator1.Margin = new Padding(4, 5, 4, 5);
            cuiSeparator1.Name = "cuiSeparator1";
            cuiSeparator1.SeparatorMargin = 8;
            cuiSeparator1.Size = new Size(394, 79);
            cuiSeparator1.TabIndex = 1;
            cuiSeparator1.Thickness = 2F;
            cuiSeparator1.Vertical = false;
            // 
            // cuiLabel2
            // 
            cuiLabel2.Anchor = AnchorStyles.None;
            cuiLabel2.Content = "POS";
            cuiLabel2.Font = new Font("Unica One", 22.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiLabel2.HorizontalAlignment = StringAlignment.Center;
            cuiLabel2.Location = new Point(592, 325);
            cuiLabel2.Margin = new Padding(4, 5, 4, 5);
            cuiLabel2.Name = "cuiLabel2";
            cuiLabel2.Size = new Size(495, 54);
            cuiLabel2.TabIndex = 2;
            cuiLabel2.VerticalAlignment = StringAlignment.Near;
            // 
            // cuiPanel1
            // 
            cuiPanel1.Anchor = AnchorStyles.None;
            cuiPanel1.Controls.Add(LoginButton);
            cuiPanel1.Controls.Add(label2);
            cuiPanel1.Controls.Add(PasswordText);
            cuiPanel1.Controls.Add(UsernameText);
            cuiPanel1.Controls.Add(label1);
            cuiPanel1.Location = new Point(592, 425);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.PanelColor = Color.FromArgb(242, 239, 234);
            cuiPanel1.PanelOutlineColor = Color.FromArgb(242, 239, 234);
            cuiPanel1.Rounding = new Padding(24);
            cuiPanel1.Size = new Size(495, 337);
            cuiPanel1.TabIndex = 3;
            cuiPanel1.Paint += cuiPanel1_Paint;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(242, 239, 234);
            LoginButton.CheckButton = false;
            LoginButton.Checked = false;
            LoginButton.CheckedBackground = Color.FromArgb(78, 45, 24);
            LoginButton.CheckedForeColor = Color.White;
            LoginButton.CheckedImageTint = Color.White;
            LoginButton.CheckedOutline = Color.FromArgb(78, 45, 24);
            LoginButton.Content = "LOG IN";
            LoginButton.DialogResult = DialogResult.None;
            LoginButton.Font = new Font("Inter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.HoverBackground = Color.FromArgb(39, 22, 12);
            LoginButton.HoveredImageTint = Color.White;
            LoginButton.HoverForeColor = Color.White;
            LoginButton.HoverOutline = Color.Transparent;
            LoginButton.Image = null;
            LoginButton.ImageAutoCenter = true;
            LoginButton.ImageExpand = new Point(0, 0);
            LoginButton.ImageOffset = new Point(0, 0);
            LoginButton.Location = new Point(147, 254);
            LoginButton.Name = "LoginButton";
            LoginButton.NormalBackground = Color.FromArgb(78, 45, 24);
            LoginButton.NormalForeColor = Color.White;
            LoginButton.NormalImageTint = Color.White;
            LoginButton.NormalOutline = Color.Transparent;
            LoginButton.OutlineThickness = 1F;
            LoginButton.PressedBackground = Color.FromArgb(78, 45, 24);
            LoginButton.PressedForeColor = Color.FromArgb(78, 45, 24);
            LoginButton.PressedImageTint = Color.White;
            LoginButton.PressedOutline = Color.FromArgb(78, 45, 24);
            LoginButton.Rounding = new Padding(8);
            LoginButton.Size = new Size(201, 47);
            LoginButton.TabIndex = 8;
            LoginButton.TextAlignment = StringAlignment.Center;
            LoginButton.TextOffset = new Point(0, 0);
            LoginButton.Click += LoginButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(242, 239, 234);
            label2.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(51, 136);
            label2.Name = "label2";
            label2.Size = new Size(89, 24);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // PasswordText
            // 
            PasswordText.Anchor = AnchorStyles.None;
            PasswordText.BackColor = Color.White;
            PasswordText.BackgroundColor = Color.White;
            PasswordText.BorderColor = Color.FromArgb(224, 224, 224);
            PasswordText.Content = "";
            PasswordText.FocusBackgroundColor = Color.White;
            PasswordText.FocusBorderColor = Color.FromArgb(224, 224, 224);
            PasswordText.FocusImageTint = Color.White;
            PasswordText.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordText.ForeColor = Color.Black;
            PasswordText.Image = null;
            PasswordText.ImageExpand = new Point(0, 0);
            PasswordText.ImageOffset = new Point(0, 0);
            PasswordText.Location = new Point(51, 170);
            PasswordText.Margin = new Padding(4);
            PasswordText.Multiline = false;
            PasswordText.Name = "PasswordText";
            PasswordText.NormalImageTint = Color.White;
            PasswordText.Padding = new Padding(21, 16, 21, 0);
            PasswordText.PasswordChar = true;
            PasswordText.PlaceholderColor = Color.Gray;
            PasswordText.PlaceholderText = "";
            PasswordText.Rounding = new Padding(8);
            PasswordText.Size = new Size(394, 52);
            PasswordText.TabIndex = 6;
            PasswordText.TextOffset = new Size(0, 0);
            PasswordText.UnderlinedStyle = true;
            PasswordText.ContentChanged += PasswordText_ContentChanged;
            // 
            // UsernameText
            // 
            UsernameText.Anchor = AnchorStyles.None;
            UsernameText.BackColor = Color.White;
            UsernameText.BackgroundColor = Color.White;
            UsernameText.BorderColor = Color.FromArgb(224, 224, 224);
            UsernameText.Content = "";
            UsernameText.FocusBackgroundColor = Color.White;
            UsernameText.FocusBorderColor = Color.FromArgb(224, 224, 224);
            UsernameText.FocusImageTint = Color.White;
            UsernameText.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameText.ForeColor = Color.Black;
            UsernameText.Image = null;
            UsernameText.ImageExpand = new Point(0, 0);
            UsernameText.ImageOffset = new Point(0, 0);
            UsernameText.Location = new Point(51, 65);
            UsernameText.Margin = new Padding(4);
            UsernameText.Multiline = false;
            UsernameText.Name = "UsernameText";
            UsernameText.NormalImageTint = Color.White;
            UsernameText.Padding = new Padding(21, 16, 21, 0);
            UsernameText.PasswordChar = false;
            UsernameText.PlaceholderColor = Color.Gray;
            UsernameText.PlaceholderText = "";
            UsernameText.Rounding = new Padding(8);
            UsernameText.Size = new Size(394, 52);
            UsernameText.TabIndex = 5;
            UsernameText.TextOffset = new Size(0, 0);
            UsernameText.UnderlinedStyle = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(242, 239, 234);
            label1.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(51, 31);
            label1.Name = "label1";
            label1.Size = new Size(93, 24);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // Log_In
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 200, 176);
            ClientSize = new Size(1639, 1055);
            Controls.Add(cuiPanel1);
            Controls.Add(cuiLabel2);
            Controls.Add(cuiLabel1);
            Controls.Add(cuiSeparator1);
            ForeColor = Color.FromArgb(78, 45, 24);
            Name = "Log_In";
            Text = "Mare POS";
            Load += Log_In_Load;
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiSeparator cuiSeparator1;
        private CuoreUI.Controls.cuiLabel cuiLabel2;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private Label label1;
        private CuoreUI.Controls.cuiTextBox UsernameText;
        private Label label2;
        private CuoreUI.Controls.cuiTextBox PasswordText;
        private CuoreUI.Controls.cuiButton LoginButton;
    }
}