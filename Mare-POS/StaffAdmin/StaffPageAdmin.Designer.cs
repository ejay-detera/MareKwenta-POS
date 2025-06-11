using CuoreUI.Controls;

namespace Mare_POS
{
    partial class StaffPageAdmin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffPageAdmin));
            cuiLabel1 = new cuiLabel();
            dateHeader = new cuiLabel();
            dataGridView1 = new DataGridView();
            panelRoundedContainer = new Panel();
            CreateIngredient = new cuiButton();
            cuiPanel8 = new cuiPanel();
            label17 = new Label();
            ResetPasswordButton = new cuiButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelRoundedContainer.SuspendLayout();
            cuiPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // cuiLabel1
            // 
            cuiLabel1.BackColor = Color.Transparent;
            cuiLabel1.Content = "Staff";
            cuiLabel1.Font = new Font("Unbounded", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiLabel1.ForeColor = Color.FromArgb(78, 45, 24);
            cuiLabel1.HorizontalAlignment = StringAlignment.Near;
            cuiLabel1.Location = new Point(56, 36);
            cuiLabel1.Margin = new Padding(6, 7, 6, 7);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(208, 64);
            cuiLabel1.TabIndex = 1;
            cuiLabel1.VerticalAlignment = StringAlignment.Center;
            cuiLabel1.Load += cuiLabel1_Load;
            // 
            // dateHeader
            // 
            dateHeader.Content = "try";
            dateHeader.Font = new Font("Inter", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateHeader.ForeColor = Color.FromArgb(78, 45, 24);
            dateHeader.HorizontalAlignment = StringAlignment.Far;
            dateHeader.Location = new Point(84, 7);
            dateHeader.Margin = new Padding(5, 7, 5, 7);
            dateHeader.Name = "dateHeader";
            dateHeader.Size = new Size(202, 38);
            dateHeader.TabIndex = 5;
            dateHeader.VerticalAlignment = StringAlignment.Center;
            dateHeader.Load += dateHeader_Load;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.Location = new Point(44, 43);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1205, 734);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panelRoundedContainer
            // 
            panelRoundedContainer.Anchor = AnchorStyles.None;
            panelRoundedContainer.BackColor = Color.White;
            panelRoundedContainer.Controls.Add(ResetPasswordButton);
            panelRoundedContainer.Controls.Add(CreateIngredient);
            panelRoundedContainer.Controls.Add(dataGridView1);
            panelRoundedContainer.Location = new Point(100, 110);
            panelRoundedContainer.Name = "panelRoundedContainer";
            panelRoundedContainer.Size = new Size(1292, 851);
            panelRoundedContainer.TabIndex = 7;
            // 
            // CreateIngredient
            // 
            CreateIngredient.Anchor = AnchorStyles.None;
            CreateIngredient.BackColor = Color.Transparent;
            CreateIngredient.CheckButton = false;
            CreateIngredient.Checked = false;
            CreateIngredient.CheckedBackground = Color.Transparent;
            CreateIngredient.CheckedForeColor = Color.White;
            CreateIngredient.CheckedImageTint = Color.White;
            CreateIngredient.CheckedOutline = Color.Transparent;
            CreateIngredient.Content = "➕";
            CreateIngredient.DialogResult = DialogResult.None;
            CreateIngredient.Font = new Font("Arial", 18.8F);
            CreateIngredient.ForeColor = Color.White;
            CreateIngredient.HoverBackground = Color.FromArgb(128, 64, 64);
            CreateIngredient.HoveredImageTint = Color.Transparent;
            CreateIngredient.HoverForeColor = Color.White;
            CreateIngredient.HoverOutline = Color.Transparent;
            CreateIngredient.Image = null;
            CreateIngredient.ImageAutoCenter = true;
            CreateIngredient.ImageExpand = new Point(0, 0);
            CreateIngredient.ImageOffset = new Point(0, 0);
            CreateIngredient.Location = new Point(1085, 717);
            CreateIngredient.Name = "CreateIngredient";
            CreateIngredient.NormalBackground = Color.FromArgb(78, 45, 24);
            CreateIngredient.NormalForeColor = Color.White;
            CreateIngredient.NormalImageTint = Color.White;
            CreateIngredient.NormalOutline = Color.Transparent;
            CreateIngredient.OutlineThickness = 1F;
            CreateIngredient.PressedBackground = Color.FromArgb(128, 64, 64);
            CreateIngredient.PressedForeColor = Color.FromArgb(32, 32, 32);
            CreateIngredient.PressedImageTint = Color.White;
            CreateIngredient.PressedOutline = Color.Transparent;
            CreateIngredient.Rounding = new Padding(8);
            CreateIngredient.Size = new Size(69, 60);
            CreateIngredient.TabIndex = 7;
            CreateIngredient.TextAlignment = StringAlignment.Center;
            CreateIngredient.TextOffset = new Point(0, 0);
            CreateIngredient.Click += CreateIngredient_Click;
            // 
            // cuiPanel8
            // 
            cuiPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiPanel8.BackColor = Color.FromArgb(242, 239, 234);
            cuiPanel8.Controls.Add(label17);
            cuiPanel8.Controls.Add(dateHeader);
            cuiPanel8.Location = new Point(1068, 52);
            cuiPanel8.Name = "cuiPanel8";
            cuiPanel8.OutlineThickness = 1F;
            cuiPanel8.PanelColor = Color.FromArgb(242, 239, 234);
            cuiPanel8.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            cuiPanel8.Rounding = new Padding(12);
            cuiPanel8.Size = new Size(304, 48);
            cuiPanel8.TabIndex = 8;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Inter", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.FromArgb(78, 45, 24);
            label17.Location = new Point(13, 7);
            label17.Name = "label17";
            label17.Size = new Size(80, 32);
            label17.TabIndex = 1;
            label17.Text = "DATE:";
            // 
            // ResetPasswordButton
            // 
            ResetPasswordButton.Anchor = AnchorStyles.None;
            ResetPasswordButton.BackColor = Color.Transparent;
            ResetPasswordButton.CheckButton = false;
            ResetPasswordButton.Checked = false;
            ResetPasswordButton.CheckedBackground = Color.Transparent;
            ResetPasswordButton.CheckedForeColor = Color.White;
            ResetPasswordButton.CheckedImageTint = Color.White;
            ResetPasswordButton.CheckedOutline = Color.Transparent;
            ResetPasswordButton.Content = "";
            ResetPasswordButton.DialogResult = DialogResult.None;
            ResetPasswordButton.Font = new Font("Arial", 16.8F);
            ResetPasswordButton.ForeColor = Color.White;
            ResetPasswordButton.HoverBackground = Color.FromArgb(128, 64, 64);
            ResetPasswordButton.HoveredImageTint = Color.Transparent;
            ResetPasswordButton.HoverForeColor = Color.White;
            ResetPasswordButton.HoverOutline = Color.Transparent;
            ResetPasswordButton.Image = (Image)resources.GetObject("ResetPasswordButton.Image");
            ResetPasswordButton.ImageAutoCenter = true;
            ResetPasswordButton.ImageExpand = new Point(-2, -2);
            ResetPasswordButton.ImageOffset = new Point(0, 0);
            ResetPasswordButton.Location = new Point(1171, 717);
            ResetPasswordButton.Name = "ResetPasswordButton";
            ResetPasswordButton.NormalBackground = Color.FromArgb(78, 45, 24);
            ResetPasswordButton.NormalForeColor = Color.White;
            ResetPasswordButton.NormalImageTint = Color.White;
            ResetPasswordButton.NormalOutline = Color.Transparent;
            ResetPasswordButton.OutlineThickness = 1F;
            ResetPasswordButton.PressedBackground = Color.FromArgb(128, 64, 64);
            ResetPasswordButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            ResetPasswordButton.PressedImageTint = Color.White;
            ResetPasswordButton.PressedOutline = Color.Transparent;
            ResetPasswordButton.Rounding = new Padding(8);
            ResetPasswordButton.Size = new Size(69, 60);
            ResetPasswordButton.TabIndex = 8;
            ResetPasswordButton.TextAlignment = StringAlignment.Center;
            ResetPasswordButton.TextOffset = new Point(0, 0);
            ResetPasswordButton.Click += cuiButton1_Click;
            // 
            // StaffPageAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(cuiPanel8);
            Controls.Add(panelRoundedContainer);
            Controls.Add(cuiLabel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StaffPageAdmin";
            Size = new Size(1438, 1026);
            Load += StaffPageAdmin_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelRoundedContainer.ResumeLayout(false);
            cuiPanel8.ResumeLayout(false);
            cuiPanel8.PerformLayout();
            ResumeLayout(false);
        }
        private void StyleCafeGrid(DataGridView dgv)
        {
            // Basic setup
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 50;
            dgv.AllowUserToAddRows = false;

            // Colors
            Color cream = Color.FromArgb(255, 250, 240);
            Color coffee = Color.FromArgb(94, 59, 35);
            Color tan = Color.FromArgb(230, 216, 192);
            Color orangeAccent = Color.FromArgb(255, 140, 0);

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = coffee;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Inter", 10);
            //dgv.DefaultCellStyle.SelectionBackColor = orangeAccent;
            //dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Alternating rows
            //dgv.AlternatingRowsDefaultCellStyle.BackColor = tan;

            // Grid color
            dgv.GridColor = tan;
        }


        #endregion
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiLabel dateHeader;
        private DataGridView dataGridView1;
        private Panel panelRoundedContainer;
        private cuiPanel cuiPanel8;
        private Label label17;
        private cuiButton CreateIngredient;
        private cuiButton ResetPasswordButton;
    }
}

