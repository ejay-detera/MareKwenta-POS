namespace Mare_POS
{
    
    public partial class EmployeeLogsEmployee : UserControl
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
            cuiLabel1.Font = new Font("Unbounded Medium", 18F, FontStyle.Bold);
            cuiLabel1.ForeColor = Color.FromArgb(78, 45, 24);
            cuiLabel1.HorizontalAlignment = StringAlignment.Center;
            cuiLabel1.Location = new Point(79, 35);
            cuiLabel1.Margin = new Padding(5);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(126, 48);
            cuiLabel1.TabIndex = 1;
            cuiLabel1.VerticalAlignment = StringAlignment.Center;
            // 
            // panelDates
            // 
            panelDates.Location = new Point(79, 121);
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
            PanelEmployeeCards.Location = new Point(374, 121);
            PanelEmployeeCards.Margin = new Padding(3, 4, 3, 4);
            PanelEmployeeCards.Name = "PanelEmployeeCards";
            PanelEmployeeCards.Padding = new Padding(5);
            PanelEmployeeCards.Size = new Size(1202, 1176);
            PanelEmployeeCards.TabIndex = 4;
            PanelEmployeeCards.WrapContents = false;
            // 
            // dateHeader
            // 
            dateHeader.Content = "";
            dateHeader.Font = new Font("Unbounded", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateHeader.ForeColor = Color.FromArgb(78, 45, 24);
            dateHeader.HorizontalAlignment = StringAlignment.Center;
            dateHeader.Location = new Point(1226, 67);
            dateHeader.Margin = new Padding(4, 5, 4, 5);
            dateHeader.Name = "dateHeader";
            dateHeader.Size = new Size(350, 45);
            dateHeader.TabIndex = 5;
            dateHeader.VerticalAlignment = StringAlignment.Far;
            // 
            // EmployeeLogsEmployee
            // 
            Name = "EmployeeLogsEmployee";
            Size = new Size(1347, 891);
            this.Controls.Add(cuiLabel1);
            this.Controls.Add(panelDates);
            this.Controls.Add(PanelEmployeeCards);
            this.Controls.Add(dateHeader);
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


