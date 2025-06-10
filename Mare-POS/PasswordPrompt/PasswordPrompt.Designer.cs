namespace Mare_POS
{
    partial class PasswordPrompt
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
            lblPrompt = new Label();
            txtPassword = new TextBox();
            buttonOk = new CuoreUI.Controls.cuiButton();
            buttonCancel = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = AnchorStyles.Top;
            lblPrompt.AutoSize = true;
            lblPrompt.Font = new Font("Inter SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrompt.Location = new Point(13, 32);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(99, 17);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Enter Password";
            lblPrompt.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(13, 60);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(322, 23);
            txtPassword.TabIndex = 1;
            // 
            // buttonOk
            // 
            buttonOk.CheckButton = false;
            buttonOk.Checked = false;
            buttonOk.CheckedBackground = Color.FromArgb(255, 106, 0);
            buttonOk.CheckedForeColor = Color.White;
            buttonOk.CheckedImageTint = Color.White;
            buttonOk.CheckedOutline = Color.FromArgb(255, 106, 0);
            buttonOk.Content = "OK";
            buttonOk.DialogResult = DialogResult.None;
            buttonOk.Font = new Font("Microsoft Sans Serif", 9.75F);
            buttonOk.ForeColor = Color.Black;
            buttonOk.HoverBackground = Color.White;
            buttonOk.HoveredImageTint = Color.White;
            buttonOk.HoverForeColor = Color.FromArgb(78, 45, 24); ;
            buttonOk.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            buttonOk.Image = null;
            buttonOk.ImageAutoCenter = true;
            buttonOk.ImageExpand = new Point(0, 0);
            buttonOk.ImageOffset = new Point(0, 0);
            buttonOk.Location = new Point(123, 98);
            buttonOk.Margin = new Padding(3, 2, 3, 2);
            buttonOk.Name = "buttonOk";
            buttonOk.NormalBackground = Color.FromArgb(78, 45, 24);
            buttonOk.NormalForeColor = Color.White;
            buttonOk.NormalImageTint = Color.White;
            buttonOk.NormalOutline = Color.FromArgb(78, 45, 24);
            buttonOk.OutlineThickness = 1F;
            buttonOk.PressedBackground = Color.WhiteSmoke;
            buttonOk.PressedForeColor = Color.FromArgb(32, 32, 32);
            buttonOk.PressedImageTint = Color.White;
            buttonOk.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            buttonOk.Rounding = new Padding(8);
            buttonOk.Size = new Size(103, 23);
            buttonOk.TabIndex = 2;
            buttonOk.TextAlignment = StringAlignment.Center;
            buttonOk.TextOffset = new Point(0, 0);
            // 
            // buttonCancel
            // 
            buttonCancel.CheckButton = false;
            buttonCancel.Checked = false;
            buttonCancel.CheckedBackground = Color.FromArgb(255, 106, 0);
            buttonCancel.CheckedForeColor = Color.White;
            buttonCancel.CheckedImageTint = Color.White;
            buttonCancel.CheckedOutline = Color.FromArgb(255, 106, 0);
            buttonCancel.Content = "Cancel";
            buttonCancel.DialogResult = DialogResult.None;
            buttonCancel.Font = new Font("Microsoft Sans Serif", 9.75F);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.HoverBackground = Color.White;
            buttonCancel.HoveredImageTint = Color.White;
            buttonCancel.HoverForeColor = Color.FromArgb(78, 45, 24);
            buttonCancel.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            buttonCancel.Image = null;
            buttonCancel.ImageAutoCenter = true;
            buttonCancel.ImageExpand = new Point(0, 0);
            buttonCancel.ImageOffset = new Point(0, 0);
            buttonCancel.Location = new Point(232, 98);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NormalBackground = Color.FromArgb(78, 45, 24); 
            buttonCancel.NormalForeColor = Color.White;
            buttonCancel.NormalImageTint = Color.White;
            buttonCancel.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            buttonCancel.OutlineThickness = 1F;
            buttonCancel.PressedBackground = Color.WhiteSmoke;
            buttonCancel.PressedForeColor = Color.FromArgb(32, 32, 32);
            buttonCancel.PressedImageTint = Color.White;
            buttonCancel.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            buttonCancel.Rounding = new Padding(8);
            buttonCancel.Size = new Size(103, 25);
            buttonCancel.TabIndex = 3;
            buttonCancel.TextAlignment = StringAlignment.Center;
            buttonCancel.TextOffset = new Point(0, 0);
            // 
            // PasswordPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            ClientSize = new Size(357, 151);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(txtPassword);
            Controls.Add(lblPrompt);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(373, 190);
            MinimumSize = new Size(373, 190);
            Name = "PasswordPrompt";
            Text = "PasswordPrompt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrompt;
        private TextBox txtPassword;
        private CuoreUI.Controls.cuiButton buttonOk;
        private CuoreUI.Controls.cuiButton buttonCancel;
    }
}