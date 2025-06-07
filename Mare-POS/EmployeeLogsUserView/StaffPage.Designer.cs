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
            dateHeader = new CuoreUI.Controls.cuiLabel();
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
            // panelDates
            // 
            panelDates.Location = new Point(31, 96);
            panelDates.Margin = new Padding(3, 4, 3, 4);
            panelDates.Name = "panelDates";
            panelDates.OutlineThickness = 1F;
            panelDates.Padding = new Padding(5);
            panelDates.PanelColor = Color.FromArgb(242, 239, 234);
            panelDates.PanelOutlineColor = Color.Transparent;
            panelDates.Rounding = new Padding(8);
            panelDates.Size = new Size(245, 1176);
            panelDates.TabIndex = 3;
            // 
            // PanelEmployeeCards
            // 
            PanelEmployeeCards.AutoScroll = true;
            PanelEmployeeCards.FlowDirection = FlowDirection.TopDown;
            PanelEmployeeCards.Location = new Point(309, 96);
            PanelEmployeeCards.Margin = new Padding(3, 4, 3, 4);
            PanelEmployeeCards.Name = "PanelEmployeeCards";
            PanelEmployeeCards.Padding = new Padding(5);
            PanelEmployeeCards.Size = new Size(973, 985);
            PanelEmployeeCards.TabIndex = 4;
            PanelEmployeeCards.WrapContents = false;
            // 
            // dateHeader
            // 
            dateHeader.Content = "June\\ 05,\\ 2024";
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
            // StaffPage
            // 
            BackColor = Color.FromArgb(242, 239, 234);
            Controls.Add(cuiLabel1);
            Controls.Add(panelDates);
            Controls.Add(PanelEmployeeCards);
            Controls.Add(dateHeader);
            Name = "StaffPage";
            Size = new Size(1304, 985);
            ResumeLayout(false);
            // 

        }

        #endregion
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiPanel panelDates;
        private FlowLayoutPanel PanelEmployeeCards;
        private CuoreUI.Controls.cuiLabel dateHeader;
    }
}


