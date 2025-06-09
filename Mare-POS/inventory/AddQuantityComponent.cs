using CuoreUI;
using CuoreUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.inventory
{
    public partial class AddQuantityComponent : Form
    {
        private Panel inventoryRow;
        private int inventoryId; // Store inventory ID
        private Inventory_backend dbHelper = new Inventory_backend();

        // Default constructor (keep for designer)
        public AddQuantityComponent()
        {
            InitializeComponent();
        }

        // Constructor that accepts InventoryRow and inventoryId
        public AddQuantityComponent(Panel inventoryRowPanel, int inventoryId)
        {
            InitializeComponent();
            this.inventoryRow = inventoryRowPanel;
            this.inventoryId = inventoryId; // Store the inventory ID as class field
        }

        // Constructor that accepts only inventoryId (more common usage)
        public AddQuantityComponent(int inventoryId)
        {
            InitializeComponent();
            this.inventoryId = inventoryId;
        }

        private void AddQuantityToIngredient_ContentChanged(object sender, EventArgs e)
        {
            // Handle content change if needed
        }

        private void AddQuantityButton_Click(object sender, EventArgs e)
        {
            try
            {
                cuiTextBox quantityTextBox = FindQuantityTextBoxInForm();

                if (quantityTextBox != null)
                {
                    HandleAddQuantityButtonClick(quantityTextBox, this.inventoryId);
                }
                else
                {
                    MessageBox.Show("Could not find the quantity input textbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button click handler: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Find the quantity textbox within this form
        private cuiTextBox FindQuantityTextBoxInForm()
        {
            return FindTextBoxInControl(this, "AddQuantityToIngredient");
        }

        // Recursive method to find textbox by name in any control
        private cuiTextBox FindTextBoxInControl(Control parent, string textBoxNamePrefix)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is cuiTextBox textBox &&
                    control.Name.StartsWith(textBoxNamePrefix))
                {
                    return textBox;
                }

                if (control.HasChildren)
                {
                    cuiTextBox nestedTextBox = FindTextBoxInControl(control, textBoxNamePrefix);
                    if (nestedTextBox != null)
                    {
                        return nestedTextBox;
                    }
                }
            }
            return null;
        }

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
                if (!decimal.TryParse(quantityText, out decimal quantityToAdd))
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

                // Validate inventory ID
                if (inventoryId <= 0)
                {
                    MessageBox.Show("Invalid inventory ID. Cannot update inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the quantity to the database
                bool success = dbHelper.AddQuantityToInventoryItem(inventoryId, quantityToAdd);

                if (success)
                {
                    MessageBox.Show($"Items successfully Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AddQuantityToIngredient.Content = "";
                    this.Close(); // Close the form after successful addition
                }
                else
                {
                    MessageBox.Show($"Failed to add quantity to inventory item (ID: {inventoryId}).", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Error in HandleAddQuantityButtonClick: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label click if needed
        }

        private void AddQuantityComponent_Load(object sender, EventArgs e)
        {

        }
    }
}