using CuoreUI.Controls;
using Mare_POS.Authentication;
using Mare_POS.inventory;
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
    public partial class Inventory : UserControl
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
            LoadInventoryItems();
        }

        private void label4_Click(object sender, EventArgs e)
        {
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
            InventoryPanel.Visible = false;
            LinkIngredientSeparator.Visible = true;
            InventorySeparator.Visible = false;
        }

        private void LinkIngredientSeparator_Load(object sender, EventArgs e)
        {

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
                Location = new Point(InventoryRow.Location.X, InventoryRow.Location.Y + (index * (InventoryRow.Height + 5))),
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
            else if (original is cuiComboBox)
            {
                cloned = new cuiComboBox();
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
                    clonedLabel.AccessibleName = originalLabel.AccessibleName ?? originalLabel.Name;
                    clonedLabel.Location = originalLabel.Location; // Preserve the location
                    clonedLabel.Size = originalLabel.Size; // Preserve the size
                }

                // Copy specific properties for ComboBoxes
                if (original is cuiComboBox originalComboBox && cloned is cuiComboBox clonedComboBox)
                {
                    clonedComboBox.BackColor = originalComboBox.BackColor;
                    clonedComboBox.ForeColor = originalComboBox.ForeColor;
                    clonedComboBox.Font = originalComboBox.Font?.Clone() as Font;
                    clonedComboBox.Visible = originalComboBox.Visible;
                    clonedComboBox.Enabled = originalComboBox.Enabled;
                    clonedComboBox.Name = originalComboBox.Name;
                    clonedComboBox.BackgroundColor = originalComboBox.BackgroundColor;
                    clonedComboBox.ButtonCursor = originalComboBox.ButtonCursor;
                    clonedComboBox.ButtonHoverBackground = originalComboBox.ButtonHoverBackground;
                    clonedComboBox.ButtonHoverOutline = originalComboBox.ButtonHoverOutline;
                    clonedComboBox.ButtonNormalBackground = originalComboBox.ButtonNormalBackground;
                    clonedComboBox.ButtonNormalOutline = originalComboBox.ButtonNormalOutline;
                    clonedComboBox.ButtonPressedBackground = originalComboBox.ButtonPressedBackground;
                    clonedComboBox.ButtonPressedOutline = originalComboBox.ButtonPressedOutline;
                    clonedComboBox.Items = originalComboBox.Items;
                    clonedComboBox.NoSelectionDropdownText = originalComboBox.NoSelectionDropdownText;
                    clonedComboBox.OutlineColor = originalComboBox.OutlineColor;
                    clonedComboBox.NoSelectionText = originalComboBox.NoSelectionText;
                    clonedComboBox.DropDownBackgroundColor = originalComboBox.DropDownBackgroundColor;
                    clonedComboBox.DropDownOutlineColor = originalComboBox.DropDownOutlineColor;
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

            // Get quantity for status calculation
            decimal quantity = 0;
            if (dataRow["Quantity"] != DBNull.Value)
            {
                quantity = Convert.ToDecimal(dataRow["Quantity"]);
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
                else if (control.Name.StartsWith("Actions"))
                {
                    Action.SelectedIndexChanged += (sender, e) => Action_SelectedIndexChanged(sender, e, rowIndex);
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
                else if (control.Name.StartsWith("MeasurementText"))
                {
                    control.Text = dataRow["IngredientMeasurement"]?.ToString() ?? "";
                }
                // Update Category field
                else if (control.Name.StartsWith("Category"))
                {
                    control.Text = dataRow["Category"]?.ToString() ?? "";
                }
                // UPDATE STATUS FIELD - NEW CODE
                else if (control.Name.StartsWith("statusControl"))
                {
                    UpdateStatusLabel(control, quantity);
                }
                else if (control.Name.StartsWith("Action") && control is cuiComboBox actionCombo)
                {
                    // Remove any existing event handlers to prevent duplicates
                    actionCombo.SelectedIndexChanged -= (s, e) => Action_SelectedIndexChanged(s, e, rowIndex);

                    // Add the event handler
                    actionCombo.SelectedIndexChanged += (s, e) => Action_SelectedIndexChanged(s, e, rowIndex);
                }

                if (control.HasChildren)
                {
                    UpdateNestedControls(control, dataRow, rowIndex, inventoryId);
                }
            }
        }
        private void UpdateStatusLabel(Control statusControl, decimal quantity)
        {
            if (quantity == 0)
            {
                // No Stock - Black
                statusControl.Text = "No Stock";
                statusControl.ForeColor = Color.Black;
            }
            else if (quantity <= 10.00m)
            {
                // Low Stock - Dark Red
                statusControl.Text = "Low Stock";
                statusControl.ForeColor = Color.DarkRed;
            }
            else
            {
                // Stocked - Green
                statusControl.Text = "In Stock";
                statusControl.ForeColor = Color.Green;
            }

            // Optional: Make the text bold for better visibility
            if (statusControl.Font != null)
            {
                statusControl.Font = new Font(statusControl.Font, FontStyle.Bold);
            }
        }



        private void UpdateNestedControls(Control parentControl, DataRow dataRow, int rowIndex, int inventoryId)
        {
            decimal quantity = 0;
            if (dataRow["Quantity"] != DBNull.Value)
            {
                quantity = Convert.ToDecimal(dataRow["Quantity"]);
            }

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
                else if (childControl.Name.StartsWith("MeasurementText"))
                {
                    childControl.Text = dataRow["IngredientMeasurement"]?.ToString() ?? "";
                }
                else if (childControl.Name.StartsWith("Notes") && childControl is TextBox)
                {
                    childControl.Text = dataRow["Notes"]?.ToString() ?? "";
                }
                else if (childControl.Name.StartsWith("Action") && childControl is cuiComboBox actionCombo)
                {
                    // Remove any existing event handlers to prevent duplicates
                    actionCombo.SelectedIndexChanged -= (s, e) => Action_SelectedIndexChanged(s, e, rowIndex);

                    // Add the event handler
                    actionCombo.SelectedIndexChanged += (s, e) => Action_SelectedIndexChanged(s, e, rowIndex);
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
                // UPDATE STATUS FIELD IN NESTED CONTROLS - NEW CODE
                else if (childControl.Name.StartsWith("statusControl"))
                {
                    UpdateStatusLabel(childControl, quantity);
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


        private void cuiPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkIngredients1_Load(object sender, EventArgs e)
        {

        }

        private void navbarForm1_Load(object sender, EventArgs e)
        {

        }

        private void navbarForm1_Load_1(object sender, EventArgs e)
        {

        }

        private void IngredientName1_Click(object sender, EventArgs e)
        {

        }

        private void Action_SelectedIndexChanged(object sender, EventArgs e, int rowIndex)
        {
            // Get the ComboBox that triggered the event
            cuiComboBox actionComboBox = sender as cuiComboBox;
            if (actionComboBox == null) return;

            // Get the InventoryID for the selected row
            int inventoryId = GetInventoryIdForRow(rowIndex);
            if (inventoryId == -1)
            {
                MessageBox.Show("Unable to find InventoryID for the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (actionComboBox.SelectedItem != null)
            {
                string selectedAction = actionComboBox.SelectedItem.ToString();

                if (selectedAction == "Add")
                {
                    try
                    {
                        DialogResult result = MessageBox.Show("Do you want to add quantity to this ingredient?", "Add Quantity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            using (var addQuantityForm = new AddQuantityComponent(InventoryRow, inventoryId))
                            {
                                addQuantityForm.ShowDialog();
                                LoadInventoryItems(); // Reload inventory items after adding quantity
                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening Add Quantity form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (selectedAction == "Delete")
                {
                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to remove this ingredient?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            dbHelper.DeleteInventoryItem(inventoryId);
                            LoadInventoryItems();
                            MessageBox.Show("Ingredient removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error removing ingredient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // Reset the ComboBox selection to prevent accidental re-triggers
                actionComboBox.SelectedItem = actionComboBox.Items[0];
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Action_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
