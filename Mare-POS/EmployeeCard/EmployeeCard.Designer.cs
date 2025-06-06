using CuoreUI.Controls;
namespace Mare_POS
{
    partial class EmployeeCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblName = new Label();
            lblDuration = new Label();
            btnIn = new cuiButton();
            btnOut = new cuiButton();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Unbounded", 14F, FontStyle.Bold);
            lblName.Location = new Point(25, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 29);
            lblName.TabIndex = 0;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Unbounded", 10F);
            lblDuration.Location = new Point(25, 75);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(0, 22);
            lblDuration.TabIndex = 1;
            // 
            // btnIn
            // 
            btnIn.CheckButton = false;
            btnIn.Checked = false;
            btnIn.CheckedBackground = Color.FromArgb(49, 180, 82);
            btnIn.CheckedForeColor = Color.White;
            btnIn.CheckedImageTint = Color.White;
            btnIn.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnIn.Content = "IN";
            btnIn.DialogResult = DialogResult.None;
            btnIn.Font = new Font("Unbounded Medium", 13F, FontStyle.Bold);
            btnIn.ForeColor = Color.FromArgb(78, 45, 24);
            btnIn.HoverBackground = Color.White;
            btnIn.HoveredImageTint = Color.White;
            btnIn.HoverForeColor = Color.Black;
            btnIn.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnIn.Image = null;
            btnIn.ImageAutoCenter = true;
            btnIn.ImageExpand = new Point(0, 0);
            btnIn.ImageOffset = new Point(0, 0);
            btnIn.Location = new Point(469, 25);
            btnIn.Name = "btnIn";
            btnIn.NormalBackground = Color.White;
            btnIn.NormalForeColor = Color.FromArgb(78, 45, 24);
            btnIn.NormalImageTint = Color.White;
            btnIn.NormalOutline = Color.FromArgb(49, 180, 82);
            btnIn.OutlineThickness = 2F;
            btnIn.PressedBackground = Color.FromArgb(49, 180, 82);
            btnIn.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnIn.PressedImageTint = Color.White;
            btnIn.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnIn.Rounding = new Padding(42);
            btnIn.Size = new Size(84, 84);
            btnIn.TabIndex = 0;
            btnIn.TextAlignment = StringAlignment.Center;
            btnIn.TextOffset = new Point(0, 0);
            btnIn.Click += btnIn_Click;
            // 
            // btnOut
            // 
            btnOut.CheckButton = false;
            btnOut.Checked = false;
            btnOut.CheckedBackground = Color.FromArgb(192, 0, 0);
            btnOut.CheckedForeColor = Color.White;
            btnOut.CheckedImageTint = Color.White;
            btnOut.CheckedOutline = Color.FromArgb(192, 0, 0);
            btnOut.Content = "OUT";
            btnOut.DialogResult = DialogResult.None;
            btnOut.Font = new Font("Unbounded Medium", 13F, FontStyle.Bold);
            btnOut.ForeColor = Color.FromArgb(78, 45, 24);
            btnOut.HoverBackground = Color.FromArgb(192, 0, 0);
            btnOut.HoveredImageTint = Color.White;
            btnOut.HoverForeColor = Color.Black;
            btnOut.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnOut.Image = null;
            btnOut.ImageAutoCenter = true;
            btnOut.ImageExpand = new Point(0, 0);
            btnOut.ImageOffset = new Point(0, 0);
            btnOut.Location = new Point(608, 25);
            btnOut.Name = "btnOut";
            btnOut.NormalBackground = Color.White;
            btnOut.NormalForeColor = Color.FromArgb(78, 45, 24);
            btnOut.NormalImageTint = Color.White;
            btnOut.NormalOutline = Color.FromArgb(192, 0, 0);
            btnOut.OutlineThickness = 2F;
            btnOut.PressedBackground = Color.WhiteSmoke;
            btnOut.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnOut.PressedImageTint = Color.White;
            btnOut.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnOut.Rounding = new Padding(42);
            btnOut.Size = new Size(84, 84);
            btnOut.TabIndex = 1;
            btnOut.TextAlignment = StringAlignment.Center;
            btnOut.TextOffset = new Point(0, 0);
            btnOut.Click += btnOut_Click;
            // 
            // EmployeeCard
            // 
            BackColor = Color.White;
            Controls.Add(lblName);
            Controls.Add(lblDuration);
            Controls.Add(btnIn);
            Controls.Add(btnOut);
            Name = "EmployeeCard";
            Padding = new Padding(5);
            Size = new Size(1139, 137);
            Load += EmployeeCard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblDuration;
        private CuoreUI.Controls.cuiButton btnIn;
        private CuoreUI.Controls.cuiButton btnOut;
    }
}
