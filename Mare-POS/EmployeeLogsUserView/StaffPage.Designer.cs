namespace Mare_POS
{
    
    public partial class StaffPage : UserControl
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            panelDates = new CuoreUI.Controls.cuiPanel();
            PanelEmployeeCards = new FlowLayoutPanel();
            cuiPanel8 = new CuoreUI.Controls.cuiPanel();
            label17 = new Label();
            dateHeader = new CuoreUI.Controls.cuiLabel();
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
            cuiLabel1.Location = new Point(77, 34);
            cuiLabel1.Margin = new Padding(5);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(182, 48);
            cuiLabel1.TabIndex = 1;
            cuiLabel1.VerticalAlignment = StringAlignment.Center;
            cuiLabel1.Load += cuiLabel1_Load;
            // 
            // panelDates
            // 
            panelDates.Anchor = AnchorStyles.None;
            panelDates.AutoScroll = true;
            panelDates.AutoScrollMargin = new Size(20, 20);
            panelDates.Location = new Point(66, 96);
            panelDates.Margin = new Padding(3, 4, 3, 4);
            panelDates.Name = "panelDates";
            panelDates.OutlineThickness = 1F;
            panelDates.Padding = new Padding(5);
            panelDates.PanelColor = Color.FromArgb(242, 239, 234);
            panelDates.PanelOutlineColor = Color.Transparent;
            panelDates.Rounding = new Padding(8);
            panelDates.Size = new Size(441, 811);
            panelDates.TabIndex = 3;
            panelDates.Paint += panelDates_Paint;
            // 
            // PanelEmployeeCards
            // 
            PanelEmployeeCards.AutoScroll = true;
            PanelEmployeeCards.FlowDirection = FlowDirection.TopDown;
            PanelEmployeeCards.Location = new Point(533, 96);
            PanelEmployeeCards.Margin = new Padding(3, 4, 3, 4);
            PanelEmployeeCards.Name = "PanelEmployeeCards";
            PanelEmployeeCards.Padding = new Padding(5);
            PanelEmployeeCards.Size = new Size(929, 811);
            PanelEmployeeCards.TabIndex = 4;
            PanelEmployeeCards.WrapContents = false;
            PanelEmployeeCards.Paint += PanelEmployeeCards_Paint;
            // 
            // cuiPanel8
            // 
            cuiPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cuiPanel8.BackColor = Color.FromArgb(242, 239, 234);
            cuiPanel8.Controls.Add(label17);
            cuiPanel8.Controls.Add(dateHeader);
            cuiPanel8.Location = new Point(1124, 27);
            cuiPanel8.Name = "cuiPanel8";
            cuiPanel8.OutlineThickness = 1F;
            cuiPanel8.PanelColor = Color.FromArgb(242, 239, 234);
            cuiPanel8.PanelOutlineColor = Color.FromArgb(78, 45, 24);
            cuiPanel8.Rounding = new Padding(12);
            cuiPanel8.Size = new Size(304, 48);
            cuiPanel8.TabIndex = 9;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Inter", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.FromArgb(78, 45, 24);
            label17.Location = new Point(3, 7);
            label17.Name = "label17";
            label17.Size = new Size(80, 32);
            label17.TabIndex = 1;
            label17.Text = "DATE:";
            // 
            // dateHeader
            // 
            dateHeader.Content = "try";
            dateHeader.Font = new Font("Inter", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateHeader.ForeColor = Color.FromArgb(78, 45, 24);
            dateHeader.HorizontalAlignment = StringAlignment.Far;
            dateHeader.Location = new Point(91, 7);
            dateHeader.Margin = new Padding(5, 7, 5, 7);
            dateHeader.Name = "dateHeader";
            dateHeader.Size = new Size(202, 38);
            dateHeader.TabIndex = 5;
            dateHeader.VerticalAlignment = StringAlignment.Center;
            // 
            // StaffPage
            // 
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(cuiPanel8);
            Controls.Add(cuiLabel1);
            Controls.Add(panelDates);
            Controls.Add(PanelEmployeeCards);
            Name = "StaffPage";
            Size = new Size(1488, 1026);
            cuiPanel8.ResumeLayout(false);
            cuiPanel8.PerformLayout();
            ResumeLayout(false);
            // 

        }

        #endregion
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiPanel panelDates;
        private FlowLayoutPanel PanelEmployeeCards;
        private CuoreUI.Controls.cuiPanel cuiPanel8;
        private Label label17;
        private CuoreUI.Controls.cuiLabel dateHeader;
    }
}


