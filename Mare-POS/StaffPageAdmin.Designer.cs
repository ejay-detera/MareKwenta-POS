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
            cuiLabel1 = new cuiLabel();
            dateHeader = new cuiLabel();
            dataGridView1 = new DataGridView();
            panelRoundedContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelRoundedContainer.SuspendLayout();
            SuspendLayout();
            // 
            // cuiLabel1
            // 
            cuiLabel1.BackColor = Color.Transparent;
            cuiLabel1.Content = "Staff";
            cuiLabel1.Font = new Font("Unbounded Medium", 27F, FontStyle.Bold);
            cuiLabel1.ForeColor = Color.FromArgb(78, 45, 24);
            cuiLabel1.HorizontalAlignment = StringAlignment.Near;
            cuiLabel1.Location = new Point(35, 36);
            cuiLabel1.Margin = new Padding(6, 7, 6, 7);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(208, 64);
            cuiLabel1.TabIndex = 1;
            cuiLabel1.VerticalAlignment = StringAlignment.Center;
            cuiLabel1.Load += cuiLabel1_Load;
            // 
            // dateHeader
            // 
            dateHeader.Content = "";
            dateHeader.Font = new Font("Unbounded Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateHeader.ForeColor = Color.FromArgb(78, 45, 24);
            dateHeader.HorizontalAlignment = StringAlignment.Far;
            dateHeader.Location = new Point(1056, 40);
            dateHeader.Margin = new Padding(5, 7, 5, 7);
            dateHeader.Name = "dateHeader";
            dateHeader.Size = new Size(400, 60);
            dateHeader.TabIndex = 5;
            dateHeader.VerticalAlignment = StringAlignment.Center;
            dateHeader.Load += dateHeader_Load;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.Location = new Point(19, 19);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1384, 606);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panelRoundedContainer
            // 
            panelRoundedContainer.BackColor = Color.White;
            panelRoundedContainer.Controls.Add(dataGridView1);
            panelRoundedContainer.Location = new Point(35, 110);
            panelRoundedContainer.Name = "panelRoundedContainer";
            panelRoundedContainer.Size = new Size(1421, 1167);
            panelRoundedContainer.TabIndex = 7;
            // 
            // StaffPageAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(panelRoundedContainer);
            Controls.Add(cuiLabel1);
            Controls.Add(dateHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StaffPageAdmin";
            Size = new Size(1490, 1313);
            Load += StaffPageAdmin_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelRoundedContainer.ResumeLayout(false);
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
    }
}

