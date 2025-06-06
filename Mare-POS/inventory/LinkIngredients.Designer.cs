namespace Mare_POS.inventory
{
    partial class LinkIngredients
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
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            cuiPanel7 = new CuoreUI.Controls.cuiPanel();
            label6 = new Label();
            cuiPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(242, 75);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(242, 75);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cuiPanel7
            // 
            cuiPanel7.Controls.Add(label6);
            cuiPanel7.Location = new Point(23, 18);
            cuiPanel7.Name = "cuiPanel7";
            cuiPanel7.OutlineThickness = 1F;
            cuiPanel7.PanelColor = Color.White;
            cuiPanel7.PanelOutlineColor = Color.White;
            cuiPanel7.Rounding = new Padding(24);
            cuiPanel7.Size = new Size(1106, 215);
            cuiPanel7.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Unbounded", 11.7999992F, FontStyle.Bold);
            label6.Location = new Point(14, 12);
            label6.Name = "label6";
            label6.Size = new Size(230, 31);
            label6.TabIndex = 0;
            label6.Text = "Coffe-Ice-Grande";
            // 
            // LinkIngredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Linen;
            Controls.Add(cuiPanel7);
            Name = "LinkIngredients";
            Size = new Size(1148, 744);
            cuiPanel7.ResumeLayout(false);
            cuiPanel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CuoreUI.Controls.cuiPanel cuiPanel7;
        private Label label6;
    }
}
