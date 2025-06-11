using CuoreUI.Controls;
using System.Windows.Forms;

namespace Mare_POS
{
    partial class DashboardAdmin
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            cbTimeRange = new ComboBox();
            cbDateFilter = new ComboBox();
            chartContainer = new Panel();
            panelRoundedContainer = new Panel();
            panelRoundedContainer1 = new Panel();
            panelRoundedContainer2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGenerateChart = new cuiButton();
            panelRoundedContainer.SuspendLayout();
            panelRoundedContainer1.SuspendLayout();
            panelRoundedContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unbounded", 27F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(12, 0);
            label1.Name = "label1";
            label1.Size = new Size(349, 70);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.DropDownHeight = 140;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Inter Medium", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = Color.FromArgb(78, 45, 24);
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.ItemHeight = 26;
            comboBox1.Location = new Point(10, 8);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(315, 34);
            comboBox1.TabIndex = 2;
            // 
            // cbTimeRange
            // 
            cbTimeRange.BackColor = Color.White;
            cbTimeRange.DropDownHeight = 140;
            cbTimeRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTimeRange.FlatStyle = FlatStyle.Flat;
            cbTimeRange.Font = new Font("Inter Medium", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbTimeRange.ForeColor = Color.FromArgb(78, 45, 24);
            cbTimeRange.FormattingEnabled = true;
            cbTimeRange.IntegralHeight = false;
            cbTimeRange.ItemHeight = 26;
            cbTimeRange.Location = new Point(10, 8);
            cbTimeRange.Name = "cbTimeRange";
            cbTimeRange.Size = new Size(316, 34);
            cbTimeRange.TabIndex = 0;
            // 
            // cbDateFilter
            // 
            cbDateFilter.BackColor = Color.White;
            cbDateFilter.DropDownHeight = 140;
            cbDateFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDateFilter.FlatStyle = FlatStyle.Flat;
            cbDateFilter.Font = new Font("Inter Medium", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbDateFilter.ForeColor = Color.FromArgb(78, 45, 24);
            cbDateFilter.FormattingEnabled = true;
            cbDateFilter.IntegralHeight = false;
            cbDateFilter.ItemHeight = 26;
            cbDateFilter.Location = new Point(12, 8);
            cbDateFilter.Name = "cbDateFilter";
            cbDateFilter.Size = new Size(316, 34);
            cbDateFilter.TabIndex = 1;
            // 
            // chartContainer
            // 
            chartContainer.BackColor = Color.FromArgb(242, 239, 234);
            chartContainer.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartContainer.ForeColor = Color.FromArgb(78, 45, 24);
            chartContainer.Location = new Point(36, 195);
            chartContainer.Name = "chartContainer";
            chartContainer.Size = new Size(1419, 802);
            chartContainer.TabIndex = 3;
            chartContainer.Paint += chartContainer_Paint;
            // 
            // panelRoundedContainer
            // 
            panelRoundedContainer.BackColor = Color.White;
            panelRoundedContainer.Controls.Add(comboBox1);
            panelRoundedContainer.Location = new Point(36, 119);
            panelRoundedContainer.Name = "panelRoundedContainer";
            panelRoundedContainer.Size = new Size(335, 50);
            panelRoundedContainer.TabIndex = 7;
            // 
            // panelRoundedContainer1
            // 
            panelRoundedContainer1.BackColor = Color.White;
            panelRoundedContainer1.Controls.Add(cbTimeRange);
            panelRoundedContainer1.Location = new Point(444, 119);
            panelRoundedContainer1.Name = "panelRoundedContainer1";
            panelRoundedContainer1.Size = new Size(335, 50);
            panelRoundedContainer1.TabIndex = 7;
            // 
            // panelRoundedContainer2
            // 
            panelRoundedContainer2.BackColor = Color.White;
            panelRoundedContainer2.Controls.Add(cbDateFilter);
            panelRoundedContainer2.Location = new Point(860, 119);
            panelRoundedContainer2.Name = "panelRoundedContainer2";
            panelRoundedContainer2.Size = new Size(338, 50);
            panelRoundedContainer2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.Location = new Point(39, 87);
            label2.Name = "label2";
            label2.Size = new Size(57, 26);
            label2.TabIndex = 8;
            label2.Text = "Filter";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(444, 87);
            label3.Name = "label3";
            label3.Size = new Size(106, 26);
            label3.TabIndex = 9;
            label3.Text = "Periodicity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(860, 87);
            label4.Name = "label4";
            label4.Size = new Size(52, 26);
            label4.TabIndex = 10;
            label4.Text = "Date";
            label4.Click += label4_Click;
            // 
            // btnGenerateChart
            // 
            btnGenerateChart.CheckButton = false;
            btnGenerateChart.Checked = false;
            btnGenerateChart.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGenerateChart.CheckedForeColor = Color.White;
            btnGenerateChart.CheckedImageTint = Color.White;
            btnGenerateChart.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGenerateChart.Content = "Generate";
            btnGenerateChart.DialogResult = DialogResult.None;
            btnGenerateChart.Enabled = false;
            btnGenerateChart.Font = new Font("Inter SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateChart.ForeColor = Color.White;
            btnGenerateChart.HoverBackground = Color.FromArgb(242, 239, 234);
            btnGenerateChart.HoveredImageTint = Color.White;
            btnGenerateChart.HoverForeColor = Color.FromArgb(78, 45, 24);
            btnGenerateChart.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGenerateChart.Image = null;
            btnGenerateChart.ImageAutoCenter = true;
            btnGenerateChart.ImageExpand = new Point(0, 0);
            btnGenerateChart.ImageOffset = new Point(0, 0);
            btnGenerateChart.Location = new Point(1240, 119);
            btnGenerateChart.Name = "btnGenerateChart";
            btnGenerateChart.NormalBackground = Color.FromArgb(78, 45, 24);
            btnGenerateChart.NormalForeColor = Color.White;
            btnGenerateChart.NormalImageTint = Color.White;
            btnGenerateChart.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnGenerateChart.OutlineThickness = 1F;
            btnGenerateChart.PressedBackground = Color.WhiteSmoke;
            btnGenerateChart.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnGenerateChart.PressedImageTint = Color.White;
            btnGenerateChart.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGenerateChart.Rounding = new Padding(8);
            btnGenerateChart.Size = new Size(125, 42);
            btnGenerateChart.TabIndex = 11;
            btnGenerateChart.TextAlignment = StringAlignment.Center;
            btnGenerateChart.TextOffset = new Point(0, 0);
            btnGenerateChart.Click += btnGenerateChart_Click;
            // 
            // DashboardAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(btnGenerateChart);
            Controls.Add(chartContainer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelRoundedContainer);
            Controls.Add(panelRoundedContainer1);
            Controls.Add(panelRoundedContainer2);
            ForeColor = Color.Coral;
            Name = "DashboardAdmin";
            Size = new Size(1490, 1313);
            Load += DashboardAdmin_Load_1;
            panelRoundedContainer.ResumeLayout(false);
            panelRoundedContainer1.ResumeLayout(false);
            panelRoundedContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private ComboBox cbTimeRange;
        private ComboBox cbDateFilter;
        private Panel chartContainer;
        private Panel panelRoundedContainer;
        private Panel panelRoundedContainer1;
        private Panel panelRoundedContainer2;
        private Label label2;
        private Label label3;
        private Label label4;
        private cuiButton btnGenerateChart;
    }
}
