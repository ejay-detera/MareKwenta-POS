using CuoreUI.Controls;
using MySql.Data.MySqlClient; // Ensure you have the MySQL Connector/NET installed
using Mysqlx.Resultset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private Inventory_backend dbHelper = new Inventory_backend();

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_ContentChanged(object sender, EventArgs e)
        {

        }

        private void cuiTextBox2_ContentChanged(object sender, EventArgs e)
        {

        }

        private void cuiTextBox2_ContentChanged_1(object sender, EventArgs e)
        {

        }

        private void cuiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_ContentChanged_2(object sender, EventArgs e)
        {

        }


        private void cuiButton1_Click_1(object sender, EventArgs e)
        {

            string IngredientName = "";
            string quantityText = "";
            string costText = "";


            if (!string.IsNullOrEmpty(AddIngredient.Text))
                IngredientName = AddIngredient.Text.Trim();
            else if (AddIngredient.GetType().GetProperty("Content") != null)
            {
                var contentProp = AddIngredient.GetType().GetProperty("Content");
                IngredientName = contentProp?.GetValue(AddIngredient)?.ToString()?.Trim() ?? "";
            }
            else if (AddIngredient.GetType().GetProperty("Value") != null)
            {
                var valueProp = AddIngredient.GetType().GetProperty("Value");
                IngredientName = valueProp?.GetValue(AddIngredient)?.ToString()?.Trim() ?? "";
            }

            if (!string.IsNullOrEmpty(AddAmountStock.Text))
                quantityText = AddAmountStock.Text.Trim();
            else if (AddAmountStock.GetType().GetProperty("Content") != null)
            {
                var contentProp = AddAmountStock.GetType().GetProperty("Content");
                quantityText = contentProp?.GetValue(AddAmountStock)?.ToString()?.Trim() ?? "";
            }
            else if (AddAmountStock.GetType().GetProperty("Value") != null)
            {
                var valueProp = AddAmountStock.GetType().GetProperty("Value");
                quantityText = valueProp?.GetValue(AddAmountStock)?.ToString()?.Trim() ?? "";
            }

            if (!string.IsNullOrEmpty(Cost.Text))
                costText = Cost.Text.Trim();
            else if (Cost.GetType().GetProperty("Content") != null)
            {
                var contentProp = Cost.GetType().GetProperty("Content");
                costText = contentProp?.GetValue(Cost)?.ToString()?.Trim() ?? "";
            }
            else if (Cost.GetType().GetProperty("Value") != null)
            {
                var valueProp = Cost.GetType().GetProperty("Value");
                costText = valueProp?.GetValue(Cost)?.ToString()?.Trim() ?? "";
            }

            // Debug: Show what we're getting from the textboxes
            //MessageBox.Show($"Ingredient: '{IngredientName1}'\nQuantity: '{quantityText}'\nCost: '{costText}'\nIngredient Type: {AddIngredient.GetType().Name}\nQuantity Type: {AddAmountStock.GetType().Name}", "Debug Values");


            if (string.IsNullOrWhiteSpace(IngredientName))
            {
                MessageBox.Show("Please enter an ingredient name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddIngredient.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(quantityText))
            {
                MessageBox.Show("Please enter a quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddAmountStock.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(costText))
            {
                MessageBox.Show("Please enter a cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cost.Focus();
                return;
            }

            if (UnitOfMeasurement.SelectedItem == null)
            {
                MessageBox.Show("Please select a measurement unit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UnitOfMeasurement.Focus();
                return;
            }


            if (!decimal.TryParse(quantityText, out decimal quantity))
            {
                MessageBox.Show("Please enter a valid numeric quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddAmountStock.Focus();
                return;
            }

            if (!decimal.TryParse(costText, out decimal cost))
            {
                MessageBox.Show("Please enter a valid numeric cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cost.Focus();
                return;
            }

            try
            {
                dbHelper.AddIngredientToInventory(IngredientName, quantity, UnitOfMeasurement.SelectedItem.ToString(), cost);


                AddAmountStock.Content = "";
                AddIngredient.Content = "";
                Cost.Content = "";
                UnitOfMeasurement.SelectedItem = UnitOfMeasurement.Items[0];

                LoadInventoryItems();
                MessageBox.Show("Ingredient added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding ingredient: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            InventorySeparator.Visible = true;
            LinkIngredientSeparator.Visible = false;
            linkingredientspanel.Visible = false; // Hide the link ingredients panel initially
            LoadInventoryItems(); // Load inventory items when the 
        }

        private void label4_Click(object sender, EventArgs e)
        {
            linkingredientspanel.Visible = false; // Hide the link ingredients panel
            InventoryPanel.Visible = true;
            LinkIngredientSeparator.Visible = false;
            InventorySeparator.Visible = true;

        }

        private void cuiPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            // Add your custom painting logic here if needed.
            // This method is called when the cuiPanel1 needs to be repainted.
        }
        private void cuiTextBox1_ContentChanged_1(object sender, EventArgs e)
        {
        }

        private void cuiComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void cuiPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cuiSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void LinkIngredientName_Click(object sender, EventArgs e)
        {
            // Hide the InventoryPanel
            linkingredientspanel.Visible = true;
            InventoryPanel.Visible = false;
            LinkIngredientSeparator.Visible = true;
            InventorySeparator.Visible = false;
        }

        private void cuiSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void cuiPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadInventoryItems()
        {
            try
            {
                // Get the parent container that holds the InventoryRow
                Control parentContainer = InventoryRow.Parent;

                // Enable auto-scrolling on the parent container (if it's a Panel)
                if (parentContainer is Panel panel)
                {
                    panel.AutoScroll = true;
                    panel.AutoScrollMinSize = new Size(0, 0); // Will be calculated dynamically
                }

                // Remove all cloned inventory rows (keep only the original template)
                var controlsToRemove = parentContainer.Controls.OfType<Control>()
                    .Where(c => c.Name.StartsWith("InventoryRow_Clone_"))
                    .ToList();

                foreach (Control control in controlsToRemove)
                {
                    parentContainer.Controls.Remove(control);
                    control.Dispose();
                }

                DataTable dt = dbHelper.GetInventoryData();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Update the original template row with the first record's data
                    UpdateRowData(InventoryRow, dt.Rows[0], 0);
                    InventoryRow.Visible = true;

                    // Create clones for the remaining records (starting from index 1)
                    int yOffset = InventoryRow.Height + 5; // Normal spacing
                    int startY = InventoryRow.Location.Y;
                    int totalHeight = startY;

                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[i];

                        // Create a cloned panel for each remaining database row
                        Panel clonedRow = CloneInventoryRow(i);
                        int newY = startY + (i * yOffset);
                        clonedRow.Location = new Point(InventoryRow.Location.X, newY);

                        // Update the labels inside the cloned panel with database data
                        UpdateRowData(clonedRow, dataRow, i);

                        // Add the cloned row to the parent container
                        parentContainer.Controls.Add(clonedRow);

                        // Calculate total height needed
                        totalHeight = newY + clonedRow.Height;
                    }

                    // Set the AutoScrollMinSize to enable scrolling when content exceeds container
                    if (parentContainer is Panel scrollPanel)
                    {
                        scrollPanel.AutoScrollMinSize = new Size(0, totalHeight + 20); // Add some padding
                    }
                }
                else
                {
                    InventoryRow.Visible = false;
                    MessageBox.Show("No inventory items found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory items: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to clone the entire InventoryRow panel
        private Panel CloneInventoryRow(int index)
        {
            Panel clonedPanel = new Panel
            {
                Name = $"InventoryRow_Clone_{index}",
                Size = InventoryRow.Size,
                BackColor = InventoryRow.BackColor,
                BorderStyle = InventoryRow.BorderStyle,
                Anchor = InventoryRow.Anchor,
                Margin = InventoryRow.Margin,
                Padding = InventoryRow.Padding,
                Tag = index // Store the row index for reference
            };

            // Clone all child controls (labels, buttons, etc.) from the original InventoryRow
            foreach (Control originalControl in InventoryRow.Controls)
            {
                Control clonedControl = CloneControl(originalControl, index);
                clonedPanel.Controls.Add(clonedControl);
            }

            return clonedPanel;
        }

        // Method to clone individual controls within the panel
        private Control CloneControl(Control original, int index)
        {
            Control cloned = null;

            // Create the appropriate control type
            if (original is Label)
            {
                cloned = new Label();
            }
            else if (original is cuiButton)
            {
                cloned = new cuiButton();
            }
            else if (original is cuiTextBox)
            {
                cloned = new cuiTextBox();
            }
            else if (original is Panel)
            {
                cloned = new Panel();
            }
            else if (original is cuiSeparator)
            {
                cloned = new cuiSeparator();
            }
            else if (original is ComboBox)
            {
                cloned = new ComboBox();
            }
            else if (original is PictureBox)
            {
                cloned = new PictureBox();
            }
            else
            {
                cloned = new Control();
            }

            if (cloned != null)
            {
                // Copy all common properties
                cloned.Name = $"{original.Name}_Clone_{index}";
                cloned.Text = original.Text;
                cloned.Size = original.Size;
                cloned.Location = original.Location;
                cloned.Font = original.Font;
                cloned.ForeColor = original.ForeColor;
                cloned.BackColor = original.BackColor;
                cloned.Anchor = original.Anchor;
                cloned.Margin = original.Margin;
                cloned.Padding = original.Padding;
                cloned.Visible = original.Visible;
                cloned.Enabled = original.Enabled;
                cloned.Tag = index; // Store the row index

                // Copy specific properties for Labels
                if (original is Label originalLabel && cloned is Label clonedLabel)
                {
                    clonedLabel.TextAlign = originalLabel.TextAlign;
                    clonedLabel.AutoSize = originalLabel.AutoSize;
                    clonedLabel.BorderStyle = originalLabel.BorderStyle;
                    clonedLabel.Tag = originalLabel.Tag;
                }

                // Copy specific properties for Buttons
                if (original is cuiButton originalButton && cloned is cuiButton clonedButton)
                {
                    clonedButton.BackColor = originalButton.BackColor;
                    clonedButton.ForeColor = originalButton.ForeColor;
                    clonedButton.HoverForeColor = originalButton.HoverForeColor;
                    clonedButton.NormalForeColor = originalButton.NormalForeColor;
                    clonedButton.Size = originalButton.Size;
                    clonedButton.NormalOutline = originalButton.NormalOutline;
                    clonedButton.TextAlignment = originalButton.TextAlignment;
                    clonedButton.Content = originalButton.Content;
                    clonedButton.CheckedBackground = originalButton.CheckedBackground;
                    clonedButton.CheckedForeColor = originalButton.CheckedForeColor;
                    clonedButton.NormalBackground = originalButton.NormalBackground;
                    clonedButton.NormalForeColor = originalButton.NormalForeColor;
                    clonedButton.CheckButton = originalButton.CheckButton;
                    clonedButton.Checked = originalButton.Checked;
                    clonedButton.Name = originalButton.Name;
                    clonedButton.Font = originalButton.Font?.Clone() as Font;
                    clonedButton.Text = originalButton.Text;
                    clonedButton.Enabled = originalButton.Enabled;
                    clonedButton.Visible = originalButton.Visible;
                    clonedButton.Cursor = originalButton.Cursor;
                    clonedButton.Tag = originalButton.Tag;
                    // Special handling for AddQuantity buttons
                    if (original.Name.StartsWith("AddQuantityButton") || original.Name.Contains("AddQuantity"))
                    {
                        clonedButton.Click += (sender, e) => AddQuantityButton_Click(sender, e, index);
                    }
                }

                // Copy specific properties for TextBoxes
                if (original is cuiTextBox originalTextBox && cloned is cuiTextBox clonedTextBox)
                {
                    clonedTextBox.Multiline = originalTextBox.Multiline;
                    clonedTextBox.BackColor = originalTextBox.BackColor;
                    clonedTextBox.BorderStyle = originalTextBox.BorderStyle;
                    clonedTextBox.ForeColor = originalTextBox.ForeColor;
                    clonedTextBox.Margin = originalTextBox.Margin;
                    clonedTextBox.Padding = originalTextBox.Padding;
                    clonedTextBox.Content = originalTextBox.Content;
                    clonedTextBox.PlaceholderColor = originalTextBox.PlaceholderColor;
                    clonedTextBox.PlaceholderText = originalTextBox.PlaceholderText;
                    clonedTextBox.Location = originalTextBox.Location;
                    clonedTextBox.Size = originalTextBox.Size;
                    clonedTextBox.Anchor = originalTextBox.Anchor;
                    clonedTextBox.BorderColor = originalTextBox.BorderColor;
                    clonedTextBox.FocusBorderColor = originalTextBox.FocusBorderColor;
                    clonedTextBox.AccessibleName = originalTextBox.AccessibleName;
                    clonedTextBox.Name = originalTextBox.Name;
                    clonedTextBox.AccessibleName = originalTextBox.AccessibleName ?? originalTextBox.Name;
                    clonedTextBox.Tag = originalTextBox.Tag;
                    // Special handling for AddQuantityPerIngredient textbox
                    if (original.Name.StartsWith("AddQuantityToIngredient"))
                    {
                        // Clear the content for new input
                        clonedTextBox.Content = "";
                    }
                }

                // Copy specific properties for ComboBoxes
                if (original is ComboBox originalComboBox && cloned is ComboBox clonedComboBox)
                {
                    clonedComboBox.DropDownStyle = originalComboBox.DropDownStyle;
                    clonedComboBox.Items.AddRange(originalComboBox.Items.Cast<object>().ToArray());
                    clonedComboBox.SelectedIndex = originalComboBox.SelectedIndex;
                }

                // Copy specific properties for PictureBoxes
                if (original is PictureBox originalPictureBox && cloned is PictureBox clonedPictureBox)
                {
                    clonedPictureBox.Image = originalPictureBox.Image;
                    clonedPictureBox.SizeMode = originalPictureBox.SizeMode;
                    clonedPictureBox.BorderStyle = originalPictureBox.BorderStyle;
                }

                // If the original control has child controls, clone them recursively
                if (original.HasChildren)
                {
                    foreach (Control childControl in original.Controls)
                    {
                        Control clonedChild = CloneControl(childControl, index);
                        cloned.Controls.Add(clonedChild);
                    }
                }
            }

            return cloned;
        }


        // FIXED METHOD: Handle Add Quantity button click
        private void HandleAddQuantityButtonClick(cuiTextBox AddQuantityToIngredient, int inventoryId)
        {
            try
            {
                // Get the quantity to add from the textbox
                var quantityText = AddQuantityToIngredient.Content?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(quantityText))
                {
                    MessageBox.Show("Please enter a quantity to add.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddQuantityToIngredient.Focus();
                    return;
                }

                // Validate that the input is a valid number
                if (!int.TryParse(quantityText, out int quantityToAdd))
                {
                    MessageBox.Show("Please enter a valid numeric quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddQuantityToIngredient.Focus();
                    return;
                }

                if (quantityToAdd <= 0)
                {
                    MessageBox.Show("Please enter a positive quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddQuantityToIngredient.Focus();
                    return;
                }

                // Use the inventoryId parameter directly (no need to call GetInventoryIdForRow)
                if (inventoryId <= 0)
                {
                    MessageBox.Show("Could not identify the inventory item for this row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the quantity to the database
                bool success = dbHelper.AddQuantityToInventoryItem(inventoryId, quantityToAdd);
                if (success)
                {

                    // Reload the inventory to show updated quantities
                    LoadInventoryItems();
                    MessageBox.Show($"Successfully added {quantityToAdd} to inventory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add quantity to inventory.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NEW METHOD: Get InventoryID for a specific row
        private int GetInventoryIdForRow(int rowIndex)
        {
            try
            {
                DataTable dt = dbHelper.GetInventoryData();
                if (dt != null && rowIndex < dt.Rows.Count)
                {
                    DataRow row = dt.Rows[rowIndex];
                    // Assuming your database has an InventoryID column
                    if (row["InventoryID"] != DBNull.Value)
                    {
                        return Convert.ToInt32(row["InventoryID"]);
                    }
                }
                return -1; // Return -1 if not found
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting InventoryID for row {rowIndex}: {ex.Message}");
                return -1;
            }
        }

        // Method to update the cloned row with database data
        private void UpdateRowData(Panel clonedRow, DataRow dataRow, int rowIndex)
        {
            InventoryRow.Visible = true;

            // Store the InventoryID in the panel's Tag for easy access
            int inventoryId = -1;
            if (dataRow["InventoryID"] != DBNull.Value)
            {
                inventoryId = Convert.ToInt32(dataRow["InventoryID"]);
                clonedRow.Tag = inventoryId;
            }

            foreach (Control control in clonedRow.Controls)
            {
                // Update IngredientName label
                if (control.Name.StartsWith("IngredientName1"))
                {
                    control.Text = dataRow["IngredientName"]?.ToString() ?? "";
                }
                // Update Quantity label
                else if (control.Name.StartsWith("Quantity"))
                {
                    control.Text = dataRow["Quantity"]?.ToString() ?? "";
                }
                // Update Price field
                else if (control.Name.StartsWith("Price"))
                {
                    if (dataRow["Price"] != DBNull.Value)
                    {
                        decimal price = Convert.ToDecimal(dataRow["Price"]);
                        control.Text = price.ToString("C2"); // Format as currency
                    }
                    else
                    {
                        control.Text = "";
                    }
                }
                // Update Date fields
                else if (control.Name.StartsWith("ExpiryDate") || control.Name.StartsWith("DateAdded"))
                {
                    string columnName = control.Name.StartsWith("ExpiryDate") ? "ExpiryDate" : "DateAdded";
                    if (dataRow[columnName] != DBNull.Value)
                    {
                        DateTime date = Convert.ToDateTime(dataRow[columnName]);
                        control.Text = date.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        control.Text = "";
                    }
                }
                // Update Category field
                else if (control.Name.StartsWith("Category"))
                {
                    control.Text = dataRow["Category"]?.ToString() ?? "";
                }
                // Handle AddQuantityPerIngredient textbox
                else if (control.Name.StartsWith($"AddQuantityToIngredient") && control is cuiTextBox addQtyTextBox)
                {
                    // Clear the content and set the tag with inventory ID
                    addQtyTextBox.Content = "";
                    addQtyTextBox.Tag = inventoryId; // Set the inventory ID as tag
                }
                // Handle AddQuantity button
                else if (control.Name.StartsWith("AddQuantityButton") && control is cuiButton addQtyButton)
                {
                    // Set the inventory ID as the button's tag
                    addQtyButton.Tag = inventoryId;

                    // Remove any existing event handlers to prevent duplicates
                    addQtyButton.Click -= (sender, e) => AddQuantityButton_Click(sender, e, rowIndex);

                    // Add the event handler with the correct row index
                    addQtyButton.Click += (sender, e) => AddQuantityButton_Click(sender, e, rowIndex);
                }

                // Handle nested controls (if any controls contain other controls)
                if (control.HasChildren)
                {
                    UpdateNestedControls(control, dataRow, rowIndex, inventoryId);
                }
            }
        }

        // Helper method to find the corresponding textbox for a button
        // Helper method to find the corresponding textbox for a button - FIXED VERSION
        private cuiTextBox FindCorrespondingTextBox(cuiButton button, int inventoryId)
        {
            try
            {
                // First, check if the button has a parent
                Control parentPanel = button.Parent;

                if (parentPanel == null)
                {
                    // If direct parent is null, try to find the textbox in all inventory rows
                    return FindTextBoxByInventoryId(inventoryId);
                }

                // Look for AddQuantityToIngredient textbox in the same panel
                foreach (Control control in parentPanel.Controls)
                {
                    if (control is cuiTextBox cuiTextBox &&
                        control.Name.StartsWith("AddQuantityToIngredient"))
                    {
                        return cuiTextBox;
                    }

                    // Also check nested controls if needed
                    if (control.HasChildren)
                    {
                        cuiTextBox nestedTextBox = FindTextBoxInNestedControls(control);
                        if (nestedTextBox != null)
                        {
                            return nestedTextBox;
                        }
                    }
                }

                // If not found in direct parent, try to find by inventory ID
                return FindTextBoxByInventoryId(inventoryId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error finding corresponding textbox: {ex.Message}");
                return FindTextBoxByInventoryId(inventoryId);
            }
        }

        // New method to find textbox by inventory ID across all rows
        private cuiTextBox FindTextBoxByInventoryId(int inventoryId)
        {
            try
            {
                // Get the parent container that holds all inventory rows
                Control mainContainer = InventoryRow.Parent;

                if (mainContainer == null) return null;

                // Search through all controls in the main container
                foreach (Control control in mainContainer.Controls)
                {
                    // Check if this is an inventory row (original or cloned)
                    if (control is Panel panel &&
                        (control.Name == "InventoryRow" || control.Name.StartsWith("InventoryRow_Clone_")))
                    {
                        // Check if this panel has the matching inventory ID
                        if (panel.Tag != null && panel.Tag.ToString() == inventoryId.ToString())
                        {
                            // Look for the textbox in this panel
                            cuiTextBox textBox = FindTextBoxInPanel(panel);
                            if (textBox != null)
                            {
                                return textBox;
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error finding textbox by inventory ID: {ex.Message}");
                return null;
            }
        }

        // Helper method to find textbox within a specific panel
        private cuiTextBox FindTextBoxInPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is cuiTextBox textBox &&
                    control.Name.StartsWith("AddQuantityToIngredient"))
                {
                    return textBox;
                }

                // Check nested controls recursively
                if (control.HasChildren)
                {
                    cuiTextBox nestedTextBox = FindTextBoxInNestedControls(control);
                    if (nestedTextBox != null)
                    {
                        return nestedTextBox;
                    }
                }
            }

            return null;
        }
        // Helper method to find textbox in nested controls
        private cuiTextBox FindTextBoxInNestedControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is cuiTextBox textBox &&
                    control.Name.StartsWith("AddQuantityToIngredient"))
                {
                    return textBox;
                }

                if (control.HasChildren)
                {
                    cuiTextBox nestedTextBox = FindTextBoxInNestedControls(control);
                    if (nestedTextBox != null)
                    {
                        return nestedTextBox;
                    }
                }
            }

            return null;
        }

        // Helper method to handle nested controls - Updated with inventoryId parameter
        private void UpdateNestedControls(Control parentControl, DataRow dataRow, int rowIndex, int inventoryId)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                // Apply the same logic as UpdateRowData for child controls
                if (childControl.Name.StartsWith("IngredientName"))
                {
                    childControl.Text = dataRow["IngredientName"]?.ToString() ?? "";
                }
                else if (childControl.Name.StartsWith("Quantity"))
                {
                    childControl.Text = dataRow["Quantity"]?.ToString() ?? "";
                }
                else if (childControl.Name.StartsWith("Notes") && childControl is TextBox)
                {
                    childControl.Text = dataRow["Notes"]?.ToString() ?? "";
                }
                else if (childControl.Name.StartsWith("Price"))
                {
                    if (dataRow["Price"] != DBNull.Value)
                    {
                        decimal price = Convert.ToDecimal(dataRow["Price"]);
                        childControl.Text = price.ToString("C2");
                    }
                    else
                    {
                        childControl.Text = "";
                    }
                }
                // Handle AddQuantityPerIngredient textbox in nested controls
                else if (childControl.Name.StartsWith("AddQuantityToIngredient") && childControl is cuiTextBox addQtyTextBox)
                {
                    addQtyTextBox.Content = "";
                    addQtyTextBox.Tag = inventoryId; // Set the inventory ID as tag
                }
                // Handle AddQuantity button in nested controls
                else if (childControl.Name.StartsWith("AddQuantityButton") && childControl is cuiButton addQtyButton)
                {
                    // Set the inventory ID as the button's tag
                    addQtyButton.Tag = inventoryId;

                    // Remove any existing event handlers to prevent duplicates
                    addQtyButton.Click -= (sender, e) => AddQuantityButton_Click(sender, e, rowIndex);

                    // Add the event handler with the correct row index
                    addQtyButton.Click += (sender, e) => AddQuantityButton_Click(sender, e, rowIndex);
                }

                // Recursively handle deeper nesting if needed
                if (childControl.HasChildren)
                {
                    UpdateNestedControls(childControl, dataRow, rowIndex, inventoryId);
                }
            }
        }


        private void cuiScrollbar1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddTextbox_ContentChanged(object sender, EventArgs e)
        {

        }

        private void InventoryRow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Quantity_Click(object sender, EventArgs e)
        {

        }

        private void cuiSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void Quantity1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TotalQuantity_Click(object sender, EventArgs e)
        {

        }

        private void AddQuantityButton_Click(object sender, EventArgs e, int rowIndex)
        {
            try
            {
                // Get the button that was clicked
                cuiButton clickedButton = sender as cuiButton;

                if (clickedButton == null)
                {
                    MessageBox.Show("Button is null!", "Debug Error");
                    return;
                }

                // Debug: Show button information

                // Get the inventory ID from the button's Tag property
                if (clickedButton.Tag != null && int.TryParse(clickedButton.Tag.ToString(), out int inventoryId))
                {

                    // Find the corresponding textbox in the same row
                    cuiTextBox correspondingTextBox = FindCorrespondingTextBox(clickedButton, inventoryId);

                    if (correspondingTextBox != null)
                    {
                        HandleAddQuantityButtonClick(correspondingTextBox, inventoryId);
                    }
                    else
                    {
                        MessageBox.Show("Could not find the quantity input textbox for this row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Button Tag is: {clickedButton.Tag ?? "NULL"}", "Debug Error");
                    MessageBox.Show("Could not determine the inventory ID for this button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button click handler: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddQuantityButton_Click(object sender, EventArgs e)
        {


        }

        private void cuiPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkIngredients1_Load(object sender, EventArgs e)
        {

        }
    }
}
