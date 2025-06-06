namespace Mare_POS
{
    partial class Inventory
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
            label1 = new Label();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label2 = new Label();
            InventoryPanel = new CuoreUI.Controls.cuiPanel();
            cuiPanel2 = new CuoreUI.Controls.cuiPanel();
            InventoryRow = new CuoreUI.Controls.cuiPanel();
            AddQuantityButton = new CuoreUI.Controls.cuiButton();
            IngredientName1 = new Label();
            Quantity1 = new Label();
            IngredientName = new Label();
            TotalQuantity = new Label();
            Quantity = new Label();
            Deducted = new Label();
            AddQuantityToIngredient = new CuoreUI.Controls.cuiTextBox();
            SeparatorInventory = new CuoreUI.Controls.cuiSeparator();
            cuiPanel3 = new CuoreUI.Controls.cuiPanel();
            Cost = new CuoreUI.Controls.cuiTextBox();
            CreateIngredient = new CuoreUI.Controls.cuiButton();
            UnitOfMeasurement = new CuoreUI.Controls.cuiComboBox();
            AddAmountStock = new CuoreUI.Controls.cuiTextBox();
            AddIngredient = new CuoreUI.Controls.cuiTextBox();
            label3 = new Label();
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            label4 = new Label();
            label8 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            cuiSeparator2 = new CuoreUI.Controls.cuiSeparator();
            InventoryName = new Label();
            LinkIngredientName = new Label();
            InventorySeparator = new CuoreUI.Controls.cuiSeparator();
            LinkIngredientSeparator = new CuoreUI.Controls.cuiSeparator();
            linkingredientspanel = new CuoreUI.Controls.cuiPanel();
            linkIngredients1 = new Mare_POS.inventory.LinkIngredients();
            InventoryPanel.SuspendLayout();
            cuiPanel2.SuspendLayout();
            InventoryRow.SuspendLayout();
            cuiPanel3.SuspendLayout();
            cuiPanel1.SuspendLayout();
            linkingredientspanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Unbounded", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(78, 45, 24);
            label1.Location = new Point(45, 40);
            label1.Name = "label1";
            label1.Size = new Size(140, 53);
            label1.TabIndex = 1;
            label1.Text = "Hello!";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Location = new Point(4, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(901, 234);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Location = new Point(4, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1336, 234);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.Click += tabPage2_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Unbounded", 18.8000011F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(78, 45, 24);
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.Location = new Point(177, 44);
            label2.Name = "label2";
            label2.Size = new Size(115, 49);
            label2.TabIndex = 3;
            label2.Text = "User";
            label2.Click += label2_Click;
            // 
            // InventoryPanel
            // 
            InventoryPanel.Anchor = AnchorStyles.None;
            InventoryPanel.Controls.Add(cuiPanel2);
            InventoryPanel.Controls.Add(cuiPanel3);
            InventoryPanel.Controls.Add(cuiPanel1);
            InventoryPanel.Location = new Point(12, 185);
            InventoryPanel.Name = "InventoryPanel";
            InventoryPanel.OutlineThickness = 1F;
            InventoryPanel.Padding = new Padding(15);
            InventoryPanel.PanelColor = Color.Linen;
            InventoryPanel.PanelOutlineColor = Color.Linen;
            InventoryPanel.Rounding = new Padding(8);
            InventoryPanel.Size = new Size(1398, 768);
            InventoryPanel.TabIndex = 4;
            InventoryPanel.Paint += cuiPanel1_Paint_1;
            // 
            // cuiPanel2
            // 
            cuiPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cuiPanel2.Controls.Add(InventoryRow);
            cuiPanel2.Dock = DockStyle.Bottom;
            cuiPanel2.Location = new Point(15, 253);
            cuiPanel2.Name = "cuiPanel2";
            cuiPanel2.OutlineThickness = 1F;
            cuiPanel2.Padding = new Padding(15);
            cuiPanel2.PanelColor = Color.White;
            cuiPanel2.PanelOutlineColor = Color.White;
            cuiPanel2.Rounding = new Padding(0, 0, 8, 8);
            cuiPanel2.Size = new Size(1368, 500);
            cuiPanel2.TabIndex = 7;
            cuiPanel2.Paint += cuiPanel2_Paint;
            // 
            // InventoryRow
            // 
            InventoryRow.BackColor = Color.White;
            InventoryRow.Controls.Add(AddQuantityButton);
            InventoryRow.Controls.Add(IngredientName1);
            InventoryRow.Controls.Add(Quantity1);
            InventoryRow.Controls.Add(IngredientName);
            InventoryRow.Controls.Add(TotalQuantity);
            InventoryRow.Controls.Add(Quantity);
            InventoryRow.Controls.Add(Deducted);
            InventoryRow.Controls.Add(AddQuantityToIngredient);
            InventoryRow.Controls.Add(SeparatorInventory);
            InventoryRow.Location = new Point(6, 0);
            InventoryRow.Name = "InventoryRow";
            InventoryRow.OutlineThickness = 1F;
            InventoryRow.Padding = new Padding(10);
            InventoryRow.PanelColor = Color.White;
            InventoryRow.PanelOutlineColor = Color.White;
            InventoryRow.Rounding = new Padding(8);
            InventoryRow.Size = new Size(1362, 137);
            InventoryRow.TabIndex = 19;
            InventoryRow.Paint += InventoryRow_Paint;
            // 
            // AddQuantityButton
            // 
            AddQuantityButton.Anchor = AnchorStyles.None;
            AddQuantityButton.BackColor = Color.White;
            AddQuantityButton.CheckButton = false;
            AddQuantityButton.Checked = false;
            AddQuantityButton.CheckedBackground = Color.Transparent;
            AddQuantityButton.CheckedForeColor = Color.White;
            AddQuantityButton.CheckedImageTint = Color.White;
            AddQuantityButton.CheckedOutline = Color.Transparent;
            AddQuantityButton.Content = "➕";
            AddQuantityButton.DialogResult = DialogResult.None;
            AddQuantityButton.Font = new Font("Arial", 11.8F);
            AddQuantityButton.ForeColor = Color.FromArgb(64, 64, 64);
            AddQuantityButton.HoverBackground = Color.Transparent;
            AddQuantityButton.HoveredImageTint = Color.Transparent;
            AddQuantityButton.HoverForeColor = Color.Black;
            AddQuantityButton.HoverOutline = Color.Transparent;
            AddQuantityButton.Image = null;
            AddQuantityButton.ImageAutoCenter = true;
            AddQuantityButton.ImageExpand = new Point(0, 0);
            AddQuantityButton.ImageOffset = new Point(0, 0);
            AddQuantityButton.Location = new Point(709, 19);
            AddQuantityButton.Name = "AddQuantityButton";
            AddQuantityButton.NormalBackground = Color.White;
            AddQuantityButton.NormalForeColor = Color.FromArgb(64, 64, 64);
            AddQuantityButton.NormalImageTint = Color.White;
            AddQuantityButton.NormalOutline = Color.Transparent;
            AddQuantityButton.OutlineThickness = 1F;
            AddQuantityButton.PressedBackground = Color.WhiteSmoke;
            AddQuantityButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            AddQuantityButton.PressedImageTint = Color.White;
            AddQuantityButton.PressedOutline = Color.Transparent;
            AddQuantityButton.Rounding = new Padding(8);
            AddQuantityButton.Size = new Size(61, 52);
            AddQuantityButton.TabIndex = 8;
            AddQuantityButton.TextAlignment = StringAlignment.Center;
            AddQuantityButton.TextOffset = new Point(0, 0);
            AddQuantityButton.Click += AddQuantityButton_Click;
            // 
            // IngredientName1
            // 
            IngredientName1.Anchor = AnchorStyles.None;
            IngredientName1.AutoSize = true;
            IngredientName1.BackColor = Color.White;
            IngredientName1.Font = new Font("Inter", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IngredientName1.Location = new Point(111, 40);
            IngredientName1.Name = "IngredientName1";
            IngredientName1.Size = new Size(41, 26);
            IngredientName1.TabIndex = 20;
            IngredientName1.Text = "123";
            // 
            // Quantity1
            // 
            Quantity1.Anchor = AnchorStyles.None;
            Quantity1.AutoSize = true;
            Quantity1.BackColor = Color.White;
            Quantity1.Font = new Font("Inter", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Quantity1.Location = new Point(358, 40);
            Quantity1.Name = "Quantity1";
            Quantity1.Size = new Size(41, 26);
            Quantity1.TabIndex = 19;
            Quantity1.Text = "123";
            Quantity1.Click += Quantity1_Click;
            // 
            // IngredientName
            // 
            IngredientName.Anchor = AnchorStyles.None;
            IngredientName.AutoSize = true;
            IngredientName.BackColor = Color.White;
            IngredientName.Font = new Font("Inter", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IngredientName.Location = new Point(126, 43);
            IngredientName.Name = "IngredientName";
            IngredientName.Size = new Size(0, 26);
            IngredientName.TabIndex = 18;
            // 
            // TotalQuantity
            // 
            TotalQuantity.Anchor = AnchorStyles.None;
            TotalQuantity.AutoSize = true;
            TotalQuantity.BackColor = Color.White;
            TotalQuantity.Font = new Font("Inter", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalQuantity.Location = new Point(1197, 43);
            TotalQuantity.Name = "TotalQuantity";
            TotalQuantity.Size = new Size(41, 26);
            TotalQuantity.TabIndex = 17;
            TotalQuantity.Text = "123";
            TotalQuantity.Click += TotalQuantity_Click;
            // 
            // Quantity
            // 
            Quantity.Anchor = AnchorStyles.None;
            Quantity.AutoSize = true;
            Quantity.BackColor = Color.White;
            Quantity.Font = new Font("Inter", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Quantity.Location = new Point(352, 43);
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(0, 26);
            Quantity.TabIndex = 15;
            Quantity.Click += Quantity_Click;
            // 
            // Deducted
            // 
            Deducted.Anchor = AnchorStyles.None;
            Deducted.AutoSize = true;
            Deducted.BackColor = Color.White;
            Deducted.Font = new Font("Inter", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Deducted.ForeColor = Color.DarkRed;
            Deducted.Location = new Point(937, 40);
            Deducted.Name = "Deducted";
            Deducted.Size = new Size(41, 26);
            Deducted.TabIndex = 16;
            Deducted.Text = "123";
            // 
            // AddQuantityToIngredient
            // 
            AddQuantityToIngredient.Anchor = AnchorStyles.None;
            AddQuantityToIngredient.BackColor = Color.White;
            AddQuantityToIngredient.BackgroundColor = Color.White;
            AddQuantityToIngredient.BorderColor = Color.FromArgb(224, 224, 224);
            AddQuantityToIngredient.Content = "";
            AddQuantityToIngredient.FocusBackgroundColor = Color.White;
            AddQuantityToIngredient.FocusBorderColor = Color.FromArgb(224, 224, 224);
            AddQuantityToIngredient.FocusImageTint = Color.White;
            AddQuantityToIngredient.Font = new Font("Inter", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddQuantityToIngredient.ForeColor = Color.Green;
            AddQuantityToIngredient.Image = null;
            AddQuantityToIngredient.ImageExpand = new Point(0, 0);
            AddQuantityToIngredient.ImageOffset = new Point(0, 0);
            AddQuantityToIngredient.Location = new Point(605, 19);
            AddQuantityToIngredient.Margin = new Padding(4);
            AddQuantityToIngredient.Multiline = false;
            AddQuantityToIngredient.Name = "AddQuantityToIngredient";
            AddQuantityToIngredient.NormalImageTint = Color.White;
            AddQuantityToIngredient.Padding = new Padding(21, 16, 21, 0);
            AddQuantityToIngredient.PasswordChar = false;
            AddQuantityToIngredient.PlaceholderColor = Color.Green;
            AddQuantityToIngredient.PlaceholderText = "Add";
            AddQuantityToIngredient.Rounding = new Padding(8);
            AddQuantityToIngredient.Size = new Size(97, 52);
            AddQuantityToIngredient.TabIndex = 7;
            AddQuantityToIngredient.TextOffset = new Size(0, 0);
            AddQuantityToIngredient.UnderlinedStyle = true;
            AddQuantityToIngredient.ContentChanged += AddTextbox_ContentChanged;
            // 
            // SeparatorInventory
            // 
            SeparatorInventory.BackColor = Color.White;
            SeparatorInventory.ForeColor = Color.Black;
            SeparatorInventory.Location = new Point(55, 58);
            SeparatorInventory.Margin = new Padding(4, 5, 4, 5);
            SeparatorInventory.Name = "SeparatorInventory";
            SeparatorInventory.SeparatorMargin = 8;
            SeparatorInventory.Size = new Size(1266, 79);
            SeparatorInventory.TabIndex = 8;
            SeparatorInventory.Thickness = 0.5F;
            SeparatorInventory.Vertical = false;
            SeparatorInventory.Load += cuiSeparator1_Load;
            // 
            // cuiPanel3
            // 
            cuiPanel3.Controls.Add(Cost);
            cuiPanel3.Controls.Add(CreateIngredient);
            cuiPanel3.Controls.Add(UnitOfMeasurement);
            cuiPanel3.Controls.Add(AddAmountStock);
            cuiPanel3.Controls.Add(AddIngredient);
            cuiPanel3.Controls.Add(label3);
            cuiPanel3.Dock = DockStyle.Top;
            cuiPanel3.Location = new Point(15, 15);
            cuiPanel3.Name = "cuiPanel3";
            cuiPanel3.OutlineThickness = 1F;
            cuiPanel3.Padding = new Padding(15);
            cuiPanel3.PanelColor = Color.White;
            cuiPanel3.PanelOutlineColor = Color.White;
            cuiPanel3.Rounding = new Padding(24);
            cuiPanel3.Size = new Size(1368, 141);
            cuiPanel3.TabIndex = 6;
            cuiPanel3.Paint += cuiPanel3_Paint;
            // 
            // Cost
            // 
            Cost.Anchor = AnchorStyles.None;
            Cost.BackColor = Color.White;
            Cost.BackgroundColor = Color.White;
            Cost.BorderColor = Color.FromArgb(224, 224, 224);
            Cost.Content = "";
            Cost.FocusBackgroundColor = Color.White;
            Cost.FocusBorderColor = Color.FromArgb(224, 224, 224);
            Cost.FocusImageTint = Color.White;
            Cost.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cost.ForeColor = Color.Black;
            Cost.Image = null;
            Cost.ImageExpand = new Point(0, 0);
            Cost.ImageOffset = new Point(0, 0);
            Cost.Location = new Point(698, 60);
            Cost.Margin = new Padding(4);
            Cost.Multiline = false;
            Cost.Name = "Cost";
            Cost.NormalImageTint = Color.White;
            Cost.Padding = new Padding(21, 16, 21, 0);
            Cost.PasswordChar = false;
            Cost.PlaceholderColor = Color.Gray;
            Cost.PlaceholderText = "Cost";
            Cost.Rounding = new Padding(8);
            Cost.Size = new Size(122, 52);
            Cost.TabIndex = 7;
            Cost.TextOffset = new Size(0, 0);
            Cost.UnderlinedStyle = true;
            Cost.ContentChanged += cuiTextBox2_ContentChanged;
            // 
            // CreateIngredient
            // 
            CreateIngredient.Anchor = AnchorStyles.None;
            CreateIngredient.BackColor = Color.White;
            CreateIngredient.CheckButton = false;
            CreateIngredient.Checked = false;
            CreateIngredient.CheckedBackground = Color.Transparent;
            CreateIngredient.CheckedForeColor = Color.White;
            CreateIngredient.CheckedImageTint = Color.White;
            CreateIngredient.CheckedOutline = Color.Transparent;
            CreateIngredient.Content = "➕";
            CreateIngredient.DialogResult = DialogResult.None;
            CreateIngredient.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateIngredient.ForeColor = Color.FromArgb(64, 64, 64);
            CreateIngredient.HoverBackground = Color.Transparent;
            CreateIngredient.HoveredImageTint = Color.Transparent;
            CreateIngredient.HoverForeColor = Color.Black;
            CreateIngredient.HoverOutline = Color.Transparent;
            CreateIngredient.Image = null;
            CreateIngredient.ImageAutoCenter = true;
            CreateIngredient.ImageExpand = new Point(0, 0);
            CreateIngredient.ImageOffset = new Point(0, 0);
            CreateIngredient.Location = new Point(1219, 60);
            CreateIngredient.Name = "CreateIngredient";
            CreateIngredient.NormalBackground = Color.White;
            CreateIngredient.NormalForeColor = Color.FromArgb(64, 64, 64);
            CreateIngredient.NormalImageTint = Color.White;
            CreateIngredient.NormalOutline = Color.Transparent;
            CreateIngredient.OutlineThickness = 1F;
            CreateIngredient.PressedBackground = Color.WhiteSmoke;
            CreateIngredient.PressedForeColor = Color.FromArgb(32, 32, 32);
            CreateIngredient.PressedImageTint = Color.White;
            CreateIngredient.PressedOutline = Color.Transparent;
            CreateIngredient.Rounding = new Padding(8);
            CreateIngredient.Size = new Size(61, 52);
            CreateIngredient.TabIndex = 6;
            CreateIngredient.TextAlignment = StringAlignment.Center;
            CreateIngredient.TextOffset = new Point(0, 0);
            CreateIngredient.Click += cuiButton1_Click_1;
            // 
            // UnitOfMeasurement
            // 
            UnitOfMeasurement.Anchor = AnchorStyles.None;
            UnitOfMeasurement.BackColor = Color.Transparent;
            UnitOfMeasurement.BackgroundColor = Color.White;
            UnitOfMeasurement.ButtonCursor = Cursors.Arrow;
            UnitOfMeasurement.ButtonHoverBackground = Color.Silver;
            UnitOfMeasurement.ButtonHoverOutline = Color.Empty;
            UnitOfMeasurement.ButtonNormalBackground = Color.DimGray;
            UnitOfMeasurement.ButtonNormalOutline = Color.Empty;
            UnitOfMeasurement.ButtonPressedBackground = Color.Silver;
            UnitOfMeasurement.ButtonPressedOutline = Color.Empty;
            UnitOfMeasurement.DropDownBackgroundColor = Color.DimGray;
            UnitOfMeasurement.DropDownOutlineColor = Color.Empty;
            UnitOfMeasurement.ExpandArrowColor = Color.DimGray;
            UnitOfMeasurement.Font = new Font("Inter Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UnitOfMeasurement.ForeColor = Color.DimGray;
            UnitOfMeasurement.Items = new string[]
    {
    "",
    "mg",
    "ml",
    "oz",
    "pc"
    };
            UnitOfMeasurement.Location = new Point(888, 55);
            UnitOfMeasurement.Margin = new Padding(4, 5, 4, 5);
            UnitOfMeasurement.Name = "UnitOfMeasurement";
            UnitOfMeasurement.NoSelectionDropdownText = "Empty";
            UnitOfMeasurement.NoSelectionText = "Unit of Measurement";
            UnitOfMeasurement.OutlineColor = Color.Empty;
            UnitOfMeasurement.OutlineThickness = 1F;
            UnitOfMeasurement.Rounding = 8;
            UnitOfMeasurement.Size = new Size(261, 57);
            UnitOfMeasurement.TabIndex = 5;
            UnitOfMeasurement.SelectedIndexChanged += cuiComboBox1_SelectedIndexChanged_1;
            // 
            // AddAmountStock
            // 
            AddAmountStock.Anchor = AnchorStyles.None;
            AddAmountStock.BackColor = Color.White;
            AddAmountStock.BackgroundColor = Color.White;
            AddAmountStock.BorderColor = Color.FromArgb(224, 224, 224);
            AddAmountStock.Content = "";
            AddAmountStock.FocusBackgroundColor = Color.White;
            AddAmountStock.FocusBorderColor = Color.FromArgb(224, 224, 224);
            AddAmountStock.FocusImageTint = Color.White;
            AddAmountStock.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddAmountStock.ForeColor = Color.Black;
            AddAmountStock.Image = null;
            AddAmountStock.ImageExpand = new Point(0, 0);
            AddAmountStock.ImageOffset = new Point(0, 0);
            AddAmountStock.Location = new Point(355, 60);
            AddAmountStock.Margin = new Padding(4);
            AddAmountStock.Multiline = false;
            AddAmountStock.Name = "AddAmountStock";
            AddAmountStock.NormalImageTint = Color.White;
            AddAmountStock.Padding = new Padding(21, 16, 21, 0);
            AddAmountStock.PasswordChar = false;
            AddAmountStock.PlaceholderColor = Color.Gray;
            AddAmountStock.PlaceholderText = "Amount in Stock";
            AddAmountStock.Rounding = new Padding(8);
            AddAmountStock.Size = new Size(269, 52);
            AddAmountStock.TabIndex = 4;
            AddAmountStock.TextOffset = new Size(0, 0);
            AddAmountStock.UnderlinedStyle = true;
            AddAmountStock.ContentChanged += cuiTextBox2_ContentChanged;
            // 
            // AddIngredient
            // 
            AddIngredient.Anchor = AnchorStyles.None;
            AddIngredient.BackColor = Color.White;
            AddIngredient.BackgroundColor = Color.White;
            AddIngredient.BorderColor = Color.FromArgb(224, 224, 224);
            AddIngredient.Content = "";
            AddIngredient.FocusBackgroundColor = Color.White;
            AddIngredient.FocusBorderColor = Color.FromArgb(224, 224, 224);
            AddIngredient.FocusImageTint = Color.White;
            AddIngredient.Font = new Font("Inter Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddIngredient.ForeColor = Color.Black;
            AddIngredient.Image = null;
            AddIngredient.ImageExpand = new Point(0, 0);
            AddIngredient.ImageOffset = new Point(0, 0);
            AddIngredient.Location = new Point(43, 60);
            AddIngredient.Margin = new Padding(4);
            AddIngredient.Multiline = false;
            AddIngredient.Name = "AddIngredient";
            AddIngredient.NormalImageTint = Color.White;
            AddIngredient.Padding = new Padding(21, 16, 21, 0);
            AddIngredient.PasswordChar = false;
            AddIngredient.PlaceholderColor = Color.Gray;
            AddIngredient.PlaceholderText = "Ingredient Name";
            AddIngredient.Rounding = new Padding(8);
            AddIngredient.Size = new Size(270, 52);
            AddIngredient.TabIndex = 2;
            AddIngredient.TextOffset = new Size(0, 0);
            AddIngredient.UnderlinedStyle = true;
            AddIngredient.ContentChanged += cuiTextBox1_ContentChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Unbounded", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(78, 45, 24);
            label3.Location = new Point(588, 24);
            label3.Name = "label3";
            label3.Size = new Size(197, 26);
            label3.TabIndex = 3;
            label3.Text = "Create Ingredient";
            label3.Click += label3_Click_1;
            // 
            // cuiPanel1
            // 
            cuiPanel1.Controls.Add(label4);
            cuiPanel1.Controls.Add(label8);
            cuiPanel1.Controls.Add(label5);
            cuiPanel1.Controls.Add(label7);
            cuiPanel1.Controls.Add(label6);
            cuiPanel1.Controls.Add(cuiSeparator2);
            cuiPanel1.Location = new Point(15, 172);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.PanelColor = Color.White;
            cuiPanel1.PanelOutlineColor = Color.White;
            cuiPanel1.Rounding = new Padding(8, 8, 0, 0);
            cuiPanel1.Size = new Size(1368, 89);
            cuiPanel1.TabIndex = 20;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Unbounded Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(78, 45, 24);
            label4.Location = new Point(90, 15);
            label4.Name = "label4";
            label4.Size = new Size(139, 31);
            label4.TabIndex = 7;
            label4.Text = "Ingredient";
            label4.Click += label4_Click_1;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Unbounded Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(78, 45, 24);
            label8.Location = new Point(1156, 15);
            label8.Name = "label8";
            label8.Size = new Size(124, 31);
            label8.TabIndex = 12;
            label8.Text = "Quantity";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Unbounded Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(78, 45, 24);
            label5.Location = new Point(337, 15);
            label5.Name = "label5";
            label5.Size = new Size(124, 31);
            label5.TabIndex = 9;
            label5.Text = "Quantity";
            label5.Click += label5_Click_1;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Unbounded Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkRed;
            label7.Location = new Point(897, 15);
            label7.Name = "label7";
            label7.Size = new Size(134, 31);
            label7.TabIndex = 11;
            label7.Text = "Deducted";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Unbounded Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Green;
            label6.Location = new Point(622, 15);
            label6.Name = "label6";
            label6.Size = new Size(94, 31);
            label6.TabIndex = 10;
            label6.Text = "Added";
            label6.Click += label6_Click;
            // 
            // cuiSeparator2
            // 
            cuiSeparator2.BackColor = Color.White;
            cuiSeparator2.ForeColor = Color.Black;
            cuiSeparator2.Location = new Point(61, 33);
            cuiSeparator2.Margin = new Padding(4, 5, 4, 5);
            cuiSeparator2.Name = "cuiSeparator2";
            cuiSeparator2.SeparatorMargin = 8;
            cuiSeparator2.Size = new Size(1266, 56);
            cuiSeparator2.TabIndex = 18;
            cuiSeparator2.Thickness = 0.5F;
            cuiSeparator2.Vertical = false;
            cuiSeparator2.Load += cuiSeparator2_Load;
            // 
            // InventoryName
            // 
            InventoryName.Anchor = AnchorStyles.None;
            InventoryName.AutoSize = true;
            InventoryName.Font = new Font("Unbounded", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InventoryName.ForeColor = Color.FromArgb(78, 45, 24);
            InventoryName.Location = new Point(449, 114);
            InventoryName.Name = "InventoryName";
            InventoryName.Size = new Size(202, 47);
            InventoryName.TabIndex = 5;
            InventoryName.Text = "Inventory";
            InventoryName.Click += label4_Click;
            // 
            // LinkIngredientName
            // 
            LinkIngredientName.Anchor = AnchorStyles.None;
            LinkIngredientName.AutoSize = true;
            LinkIngredientName.Font = new Font("Unbounded", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LinkIngredientName.ForeColor = Color.FromArgb(78, 45, 24);
            LinkIngredientName.Location = new Point(749, 114);
            LinkIngredientName.Name = "LinkIngredientName";
            LinkIngredientName.Size = new Size(301, 47);
            LinkIngredientName.TabIndex = 6;
            LinkIngredientName.Text = "Link Ingredient";
            LinkIngredientName.Click += LinkIngredientName_Click;
            // 
            // InventorySeparator
            // 
            InventorySeparator.Anchor = AnchorStyles.None;
            InventorySeparator.ForeColor = Color.FromArgb(78, 45, 24);
            InventorySeparator.Location = new Point(441, 129);
            InventorySeparator.Margin = new Padding(4, 5, 4, 5);
            InventorySeparator.Name = "InventorySeparator";
            InventorySeparator.SeparatorMargin = 8;
            InventorySeparator.Size = new Size(210, 77);
            InventorySeparator.TabIndex = 7;
            InventorySeparator.Thickness = 2F;
            InventorySeparator.Vertical = false;
            InventorySeparator.Load += cuiSeparator3_Load;
            // 
            // LinkIngredientSeparator
            // 
            LinkIngredientSeparator.Anchor = AnchorStyles.None;
            LinkIngredientSeparator.ForeColor = Color.FromArgb(78, 45, 24);
            LinkIngredientSeparator.Location = new Point(742, 129);
            LinkIngredientSeparator.Margin = new Padding(4, 5, 4, 5);
            LinkIngredientSeparator.Name = "LinkIngredientSeparator";
            LinkIngredientSeparator.SeparatorMargin = 8;
            LinkIngredientSeparator.Size = new Size(316, 77);
            LinkIngredientSeparator.TabIndex = 8;
            LinkIngredientSeparator.Thickness = 2F;
            LinkIngredientSeparator.Vertical = false;
            // 
            // linkingredientspanel
            // 
            linkingredientspanel.Anchor = AnchorStyles.None;
            linkingredientspanel.Controls.Add(linkIngredients1);
            linkingredientspanel.Location = new Point(12, 181);
            linkingredientspanel.Name = "linkingredientspanel";
            linkingredientspanel.OutlineThickness = 1F;
            linkingredientspanel.PanelColor = Color.FromArgb(255, 106, 0);
            linkingredientspanel.PanelOutlineColor = Color.FromArgb(255, 106, 0);
            linkingredientspanel.Rounding = new Padding(0);
            linkingredientspanel.Size = new Size(1398, 772);
            linkingredientspanel.TabIndex = 9;
            linkingredientspanel.Paint += cuiPanel4_Paint;
            // 
            // linkIngredients1
            // 
            linkIngredients1.Anchor = AnchorStyles.None;
            linkIngredients1.AutoScroll = true;
            linkIngredients1.BackColor = Color.Linen;
            linkIngredients1.Location = new Point(0, 0);
            linkIngredients1.Name = "linkIngredients1";
            linkIngredients1.Size = new Size(1398, 880);
            linkIngredients1.TabIndex = 0;
            linkIngredients1.Load += linkIngredients1_Load;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1422, 977);
            Controls.Add(linkingredientspanel);
            Controls.Add(LinkIngredientName);
            Controls.Add(InventoryName);
            Controls.Add(InventoryPanel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(InventorySeparator);
            Controls.Add(LinkIngredientSeparator);
            Name = "Inventory";
            Text = "Inventory";
            Load += Inventory_Load;
            InventoryPanel.ResumeLayout(false);
            cuiPanel2.ResumeLayout(false);
            InventoryRow.ResumeLayout(false);
            InventoryRow.PerformLayout();
            cuiPanel3.ResumeLayout(false);
            cuiPanel3.PerformLayout();
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            linkingredientspanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label2;
        private CuoreUI.Controls.cuiPanel InventoryPanel;
        private CuoreUI.Controls.cuiPanel cuiPanel3;
        private CuoreUI.Controls.cuiButton CreateIngredient;
        private CuoreUI.Controls.cuiComboBox UnitOfMeasurement;
        private CuoreUI.Controls.cuiTextBox AddAmountStock;
        private CuoreUI.Controls.cuiTextBox AddIngredient;
        private Label label3;
        private Label InventoryName;
        private Label LinkIngredientName;
        private CuoreUI.Controls.cuiPanel cuiPanel2;
        private Label label4;
        private CuoreUI.Controls.cuiSeparator SeparatorInventory;
        private Label label5;
        private Label label6;
        private Label label7;
        private CuoreUI.Controls.cuiTextBox AddQuantityToIngredient;
        private Label label8;
        private Label TotalQuantity;
        private Label Deducted;
        private Label Quantity;
        private CuoreUI.Controls.cuiSeparator InventorySeparator;
        private CuoreUI.Controls.cuiSeparator LinkIngredientSeparator;
        private CuoreUI.Controls.cuiTextBox Cost;
        private CuoreUI.Controls.cuiPanel InventoryRow;
        private CuoreUI.Controls.cuiSeparator cuiSeparator2;
        private Label IngredientName;
        private Label IngredientName1;
        private Label Quantity1;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private CuoreUI.Controls.cuiButton AddQuantityButton;
        private CuoreUI.Controls.cuiPanel linkingredientspanel;
        private inventory.LinkIngredients linkIngredients1;
    }
}