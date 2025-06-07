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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cuiLabel1
            // 
            cuiLabel1.BackColor = Color.Transparent;
            cuiLabel1.Content = "Staff";
            cuiLabel1.Font = new Font("Unbounded Medium", 27F, FontStyle.Bold);
            cuiLabel1.ForeColor = Color.FromArgb(78, 45, 24);
            cuiLabel1.HorizontalAlignment = StringAlignment.Near;
            cuiLabel1.Location = new Point(31, 27);
            cuiLabel1.Margin = new Padding(5);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(182, 48);
            cuiLabel1.TabIndex = 1;
            cuiLabel1.VerticalAlignment = StringAlignment.Center;
            cuiLabel1.Load += cuiLabel1_Load;
            // 
            // dateHeader
            // 
            dateHeader.Content = "";
            dateHeader.Font = new Font("Unbounded", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateHeader.ForeColor = Color.FromArgb(78, 45, 24);
            dateHeader.HorizontalAlignment = StringAlignment.Far;
            dateHeader.Location = new Point(932, 30);
            dateHeader.Margin = new Padding(4, 5, 4, 5);
            dateHeader.Name = "dateHeader";
            dateHeader.Size = new Size(350, 45);
            dateHeader.TabIndex = 5;
            dateHeader.VerticalAlignment = StringAlignment.Far;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1213, 485);
            dataGridView1.TabIndex = 6;
            // 
            // StaffPageAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(dataGridView1);
            Controls.Add(cuiLabel1);
            Controls.Add(dateHeader);
            Name = "StaffPageAdmin";
            Size = new Size(1304, 985);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
            dgv.RowTemplate.Height = 40;
            dgv.AllowUserToAddRows = false;

            // Colors
            Color cream = Color.FromArgb(255, 250, 240);
            Color coffee = Color.FromArgb(94, 59, 35);
            Color tan = Color.FromArgb(230, 216, 192);
            Color orangeAccent = Color.FromArgb(255, 140, 0);

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = coffee;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row style
            dgv.DefaultCellStyle.BackColor = cream;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = orangeAccent;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = tan;

            // Grid color
            dgv.GridColor = tan;
        }


        #endregion
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiLabel dateHeader;
        private DataGridView dataGridView1;
    }
}

