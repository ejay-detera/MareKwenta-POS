
namespace Mare_POS
{
    partial class Login
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
            MareKwenta = new Label();
            SuspendLayout();
            // 
            // MareKwenta
            // 
            MareKwenta.AutoSize = true;
            MareKwenta.Location = new Point(588, 286);
            MareKwenta.Name = "MareKwenta";
            MareKwenta.Size = new Size(133, 23);
            MareKwenta.TabIndex = 0;
            MareKwenta.Text = "MareKwenta\r\n";
            MareKwenta.Click += label1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.NavajoWhite;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1357, 1055);
            Controls.Add(MareKwenta);
            Font = new Font("Unbounded", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label MareKwenta;
    }
}