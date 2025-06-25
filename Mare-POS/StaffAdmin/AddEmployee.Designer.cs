namespace Mare_POS.StaffAdmin
{
    partial class AddEmployee
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
            label2 = new Label();
            LastNameText = new CuoreUI.Controls.cuiTextBox();
            label3 = new Label();
            PasswordText = new CuoreUI.Controls.cuiTextBox();
            AddButton = new CuoreUI.Controls.cuiButton();
            FirstNameText = new CuoreUI.Controls.cuiTextBox();
            label4 = new Label();
            MiddleNameText = new CuoreUI.Controls.cuiTextBox();
            label5 = new Label();
            RoleText = new CuoreUI.Controls.cuiTextBox();
            UsernameText = new CuoreUI.Controls.cuiTextBox();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unbounded SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(28, 23);
            label1.Name = "label1";
            label1.Size = new Size(265, 43);
            label1.TabIndex = 1;
            label1.Text = "Add Employee";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.Location = new Point(36, 88);
            label2.Name = "label2";
            label2.Size = new Size(99, 24);
            label2.TabIndex = 4;
            label2.Text = "Last Name";
            // 
            // LastNameText
            // 
            LastNameText.BackgroundColor = Color.White;
            LastNameText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            LastNameText.Content = "";
            LastNameText.FocusBackgroundColor = Color.White;
            LastNameText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            LastNameText.FocusImageTint = Color.White;
            LastNameText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LastNameText.ForeColor = Color.FromArgb(78, 45, 24);
            LastNameText.Image = null;
            LastNameText.ImageExpand = new Point(0, 0);
            LastNameText.ImageOffset = new Point(0, 0);
            LastNameText.Location = new Point(36, 117);
            LastNameText.Margin = new Padding(5);
            LastNameText.Multiline = false;
            LastNameText.Name = "LastNameText";
            LastNameText.NormalImageTint = Color.White;
            LastNameText.Padding = new Padding(23, 10, 23, 0);
            LastNameText.PasswordChar = false;
            LastNameText.PlaceholderColor = Color.White;
            LastNameText.PlaceholderText = "";
            LastNameText.Rounding = new Padding(12);
            LastNameText.Size = new Size(131, 43);
            LastNameText.TabIndex = 5;
            LastNameText.TextOffset = new Size(0, 0);
            LastNameText.UnderlinedStyle = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(121, 286);
            label3.Name = "label3";
            label3.Size = new Size(93, 24);
            label3.TabIndex = 6;
            label3.Text = "Password";
            label3.Click += label3_Click;
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
            PasswordText.Location = new Point(121, 315);
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
            PasswordText.TabIndex = 7;
            PasswordText.TextOffset = new Size(0, 0);
            PasswordText.UnderlinedStyle = true;
            PasswordText.ContentChanged += PasswordText_ContentChanged;
            // 
            // AddButton
            // 
            AddButton.CheckButton = false;
            AddButton.Checked = false;
            AddButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            AddButton.CheckedForeColor = Color.White;
            AddButton.CheckedImageTint = Color.White;
            AddButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            AddButton.Content = "Add";
            AddButton.DialogResult = DialogResult.None;
            AddButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            AddButton.ForeColor = Color.White;
            AddButton.HoverBackground = Color.FromArgb(50, 78, 45, 24);
            AddButton.HoveredImageTint = Color.White;
            AddButton.HoverForeColor = Color.FromArgb(78, 45, 24);
            AddButton.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            AddButton.Image = null;
            AddButton.ImageAutoCenter = true;
            AddButton.ImageExpand = new Point(0, 0);
            AddButton.ImageOffset = new Point(0, 0);
            AddButton.Location = new Point(180, 410);
            AddButton.Margin = new Padding(3, 4, 3, 4);
            AddButton.Name = "AddButton";
            AddButton.NormalBackground = Color.FromArgb(78, 45, 24);
            AddButton.NormalForeColor = Color.White;
            AddButton.NormalImageTint = Color.White;
            AddButton.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            AddButton.OutlineThickness = 1F;
            AddButton.PressedBackground = Color.WhiteSmoke;
            AddButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            AddButton.PressedImageTint = Color.White;
            AddButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            AddButton.Rounding = new Padding(8);
            AddButton.Size = new Size(185, 44);
            AddButton.TabIndex = 9;
            AddButton.TextAlignment = StringAlignment.Center;
            AddButton.TextOffset = new Point(0, 0);
            AddButton.Click += AddButton_Click;
            // 
            // FirstNameText
            // 
            FirstNameText.BackgroundColor = Color.White;
            FirstNameText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            FirstNameText.Content = "";
            FirstNameText.FocusBackgroundColor = Color.White;
            FirstNameText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            FirstNameText.FocusImageTint = Color.White;
            FirstNameText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FirstNameText.ForeColor = Color.FromArgb(78, 45, 24);
            FirstNameText.Image = null;
            FirstNameText.ImageExpand = new Point(0, 0);
            FirstNameText.ImageOffset = new Point(0, 0);
            FirstNameText.Location = new Point(192, 117);
            FirstNameText.Margin = new Padding(5);
            FirstNameText.Multiline = false;
            FirstNameText.Name = "FirstNameText";
            FirstNameText.NormalImageTint = Color.White;
            FirstNameText.Padding = new Padding(23, 10, 23, 0);
            FirstNameText.PasswordChar = false;
            FirstNameText.PlaceholderColor = Color.White;
            FirstNameText.PlaceholderText = "";
            FirstNameText.Rounding = new Padding(12);
            FirstNameText.Size = new Size(150, 43);
            FirstNameText.TabIndex = 10;
            FirstNameText.TextOffset = new Size(0, 0);
            FirstNameText.UnderlinedStyle = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(192, 88);
            label4.Name = "label4";
            label4.Size = new Size(101, 24);
            label4.TabIndex = 11;
            label4.Text = "First Name";
            // 
            // MiddleNameText
            // 
            MiddleNameText.BackgroundColor = Color.White;
            MiddleNameText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            MiddleNameText.Content = "";
            MiddleNameText.FocusBackgroundColor = Color.White;
            MiddleNameText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            MiddleNameText.FocusImageTint = Color.White;
            MiddleNameText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MiddleNameText.ForeColor = Color.FromArgb(78, 45, 24);
            MiddleNameText.Image = null;
            MiddleNameText.ImageExpand = new Point(0, 0);
            MiddleNameText.ImageOffset = new Point(0, 0);
            MiddleNameText.Location = new Point(368, 117);
            MiddleNameText.Margin = new Padding(5);
            MiddleNameText.Multiline = false;
            MiddleNameText.Name = "MiddleNameText";
            MiddleNameText.NormalImageTint = Color.White;
            MiddleNameText.Padding = new Padding(23, 10, 23, 0);
            MiddleNameText.PasswordChar = false;
            MiddleNameText.PlaceholderColor = Color.White;
            MiddleNameText.PlaceholderText = "";
            MiddleNameText.Rounding = new Padding(12);
            MiddleNameText.Size = new Size(150, 43);
            MiddleNameText.TabIndex = 12;
            MiddleNameText.TextOffset = new Size(0, 0);
            MiddleNameText.UnderlinedStyle = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(78, 45, 24);
            label5.Location = new Point(368, 88);
            label5.Name = "label5";
            label5.Size = new Size(121, 24);
            label5.TabIndex = 13;
            label5.Text = "Middle Name";
            // 
            // RoleText
            // 
            RoleText.BackgroundColor = Color.White;
            RoleText.BorderColor = Color.FromArgb(128, 128, 128, 128);
            RoleText.Content = "Employee";
            RoleText.Enabled = false;
            RoleText.FocusBackgroundColor = Color.White;
            RoleText.FocusBorderColor = Color.FromArgb(78, 45, 24);
            RoleText.FocusImageTint = Color.White;
            RoleText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoleText.ForeColor = Color.FromArgb(78, 45, 24);
            RoleText.Image = null;
            RoleText.ImageExpand = new Point(0, 0);
            RoleText.ImageOffset = new Point(0, 0);
            RoleText.Location = new Point(368, 216);
            RoleText.Margin = new Padding(5);
            RoleText.Multiline = false;
            RoleText.Name = "RoleText";
            RoleText.NormalImageTint = Color.White;
            RoleText.Padding = new Padding(23, 10, 23, 0);
            RoleText.PasswordChar = false;
            RoleText.PlaceholderColor = Color.White;
            RoleText.PlaceholderText = "";
            RoleText.Rounding = new Padding(12);
            RoleText.Size = new Size(150, 43);
            RoleText.TabIndex = 14;
            RoleText.TextOffset = new Size(0, 0);
            RoleText.UnderlinedStyle = true;
            RoleText.ContentChanged += RoleText_ContentChanged;
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
            UsernameText.Location = new Point(38, 216);
            UsernameText.Margin = new Padding(5);
            UsernameText.Multiline = false;
            UsernameText.Name = "UsernameText";
            UsernameText.NormalImageTint = Color.White;
            UsernameText.Padding = new Padding(23, 10, 23, 0);
            UsernameText.PasswordChar = false;
            UsernameText.PlaceholderColor = Color.White;
            UsernameText.PlaceholderText = "";
            UsernameText.Rounding = new Padding(12);
            UsernameText.Size = new Size(304, 43);
            UsernameText.TabIndex = 15;
            UsernameText.TextOffset = new Size(0, 0);
            UsernameText.UnderlinedStyle = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(78, 45, 24);
            label6.Location = new Point(39, 187);
            label6.Name = "label6";
            label6.Size = new Size(96, 24);
            label6.TabIndex = 16;
            label6.Text = "Username";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Inter", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(78, 45, 24);
            label7.Location = new Point(365, 187);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 17;
            label7.Text = "Role";
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(557, 497);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(UsernameText);
            Controls.Add(RoleText);
            Controls.Add(label5);
            Controls.Add(MiddleNameText);
            Controls.Add(label4);
            Controls.Add(FirstNameText);
            Controls.Add(AddButton);
            Controls.Add(PasswordText);
            Controls.Add(label3);
            Controls.Add(LastNameText);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddEmployee";
            Text = "Add Employee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CuoreUI.Controls.cuiTextBox LastNameText;
        private Label label3;
        private CuoreUI.Controls.cuiTextBox PasswordText;
        private CuoreUI.Controls.cuiButton AddButton;
        private CuoreUI.Controls.cuiTextBox FirstNameText;
        private Label label4;
        private CuoreUI.Controls.cuiTextBox MiddleNameText;
        private Label label5;
        private CuoreUI.Controls.cuiTextBox RoleText;
        private CuoreUI.Controls.cuiTextBox UsernameText;
        private Label label6;
        private Label label7;
    }
}