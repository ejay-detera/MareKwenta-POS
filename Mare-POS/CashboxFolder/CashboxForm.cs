using CuoreUI.Controls;
using Mare_POS.inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.CashboxFolder
{
    public partial class CashboxForm : UserControl
    {
        public CashboxForm()
        {
            InitializeComponent();
            LoadExpenseItems(); // Load expenses when the form is initialized
            DateChanger(); // Set the current date
            updateText(); // Update the text labels with current data
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void addExpenseButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Add an Expense?", "Add Expense", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var addQuantityForm = new AddExpenseForm())
                    {
                        addQuantityForm.ShowDialog();
                        LoadExpenseItems();
                        updateText(); // Update the text labels with current data
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Expense form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void LoadExpenseItems()
        {
            try
            {
                // Get the parent container that holds the ExpenseRow
                Control parentContainer = ExpenseRow.Parent;

                // Enable auto-scrolling on the parent container (if it's a Panel)
                if (parentContainer is Panel panel)
                {
                    panel.AutoScroll = true;
                    panel.AutoScrollMinSize = new Size(0, 0); // Will be calculated dynamically
                }

                // Remove all cloned expense rows (keep only the original template)
                var controlsToRemove = parentContainer.Controls.OfType<Control>()
                    .Where(c => c.Name.StartsWith("ExpenseRow_Clone_"))
                    .ToList();

                foreach (Control control in controlsToRemove)
                {
                    parentContainer.Controls.Remove(control);
                    control.Dispose();
                }

                // Use your existing Cashbox_backend class to get expense data
                Cashbox_backend cashboxBackend = new Cashbox_backend();
                DataTable dt = cashboxBackend.GetAllExpenses();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Update the original template row with the first record's data
                    UpdateExpenseRowData(ExpenseRow, dt.Rows[0], 0);
                    // IMPORTANT: Attach event handlers to the original buttons
                    AttachEventHandlersToExpenseRow(ExpenseRow, 0);
                    ExpenseRow.Visible = true;

                    // Create clones for the remaining records (starting from index 1)
                    int yOffset = ExpenseRow.Height + 5; // Normal spacing
                    int startY = ExpenseRow.Location.Y;
                    int totalHeight = startY;

                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[i];

                        // Create a cloned panel for each remaining database row
                        Panel clonedRow = CloneExpenseRow(i);
                        int newY = startY + (i * yOffset);
                        clonedRow.Location = new Point(ExpenseRow.Location.X, newY);

                        // Update the labels inside the cloned panel with database data
                        UpdateExpenseRowData(clonedRow, dataRow, i);

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
                    ExpenseRow.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading expense items: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachEventHandlersToExpenseRow(Panel expenseRow, int rowIndex)
        {
            foreach (Control control in expenseRow.Controls)
            {
                if (control is cuiButton cuiBtn)
                {
                    if (cuiBtn.Name.Contains("DeleteButton"))
                    {
                        // Remove existing event handlers first (to avoid duplicates)
                        cuiBtn.Click -= (sender, e) => DeleteExpense_Click(sender, e, rowIndex);
                        // Add the event handler
                        cuiBtn.Click += (sender, e) => DeleteExpense_Click(sender, e, rowIndex);
                    }
                    else if (cuiBtn.Name.Contains("EditButton"))
                    {
                        // Remove existing event handlers first (to avoid duplicates)
                        cuiBtn.Click -= (sender, e) => EditExpense_Click(sender, e, rowIndex);
                        // Add the event handler
                        cuiBtn.Click += (sender, e) => EditExpense_Click(sender, e, rowIndex);
                    }
                }

                // Handle nested controls recursively
                if (control.HasChildren)
                {
                    AttachEventHandlersToNestedControls(control, rowIndex);
                }
            }
        }

        // NEW METHOD: Handle nested controls for event handler attachment
        private void AttachEventHandlersToNestedControls(Control parentControl, int rowIndex)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl is cuiButton cuiBtn)
                {
                    if (cuiBtn.Name.Contains("DeleteButton"))
                    {
                        cuiBtn.Click -= (sender, e) => DeleteExpense_Click(sender, e, rowIndex);
                        cuiBtn.Click += (sender, e) => DeleteExpense_Click(sender, e, rowIndex);
                    }
                    else if (cuiBtn.Name.Contains("EditButton"))
                    {
                        cuiBtn.Click -= (sender, e) => EditExpense_Click(sender, e, rowIndex);
                        cuiBtn.Click += (sender, e) => EditExpense_Click(sender, e, rowIndex);
                    }
                }

                // Recursively handle deeper nesting if needed
                if (childControl.HasChildren)
                {
                    AttachEventHandlersToNestedControls(childControl, rowIndex);
                }
            }
        }

        // Method to clone the entire ExpenseRow panel
        private Panel CloneExpenseRow(int index)
        {
            Panel clonedPanel = new Panel
            {
                Name = $"ExpenseRow_Clone_{index}",
                Size = ExpenseRow.Size,
                BackColor = ExpenseRow.BackColor,
                BorderStyle = ExpenseRow.BorderStyle,
                Anchor = ExpenseRow.Anchor,
                Margin = ExpenseRow.Margin,
                Padding = ExpenseRow.Padding,
                Location = new Point(ExpenseRow.Location.X, ExpenseRow.Location.Y + (index * (ExpenseRow.Height + 5))),
                Tag = index // Store the row index for reference
            };

            // Clone all child controls (labels, buttons, etc.) from the original ExpenseRow
            foreach (Control originalControl in ExpenseRow.Controls)
            {
                Control clonedControl = CloneExpenseControl(originalControl, index);
                clonedPanel.Controls.Add(clonedControl);
            }

            return clonedPanel;
        }

        // Method to clone individual controls within the panel
        private Control CloneExpenseControl(Control original, int index)
        {
            Control cloned = null;

            // Create the appropriate control type
            if (original is Label)
            {
                cloned = new Label();
            }
            else if (original is Button)
            {
                cloned = new Button();
            }
            else if (original is cuiButton)
            {
                cloned = new cuiButton();
            }
            else if (original is Panel)
            {
                cloned = new Panel();
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
                    clonedLabel.Location = originalLabel.Location;
                    clonedLabel.Size = originalLabel.Size;
                    clonedLabel.ForeColor = originalLabel.ForeColor;
                    clonedLabel.BackColor = originalLabel.BackColor;
                    clonedLabel.Font = originalLabel.Font;
                    clonedLabel.Padding = originalLabel.Padding;
                }

                // Copy specific properties for cuiButtons and add event handlers
                if (original is cuiButton originalCuiButton && cloned is cuiButton clonedCuiButton)
                {
                    // Copy cuiButton specific properties
                    clonedCuiButton.Image = originalCuiButton.Image;
                    clonedCuiButton.Tag = originalCuiButton.Tag;
                    clonedCuiButton.Size = originalCuiButton.Size;
                    clonedCuiButton.Location = originalCuiButton.Location;
                    clonedCuiButton.Font = originalCuiButton.Font;
                    clonedCuiButton.ForeColor = originalCuiButton.ForeColor;
                    clonedCuiButton.OutlineThickness = originalCuiButton.OutlineThickness;
                    clonedCuiButton.NormalOutline = originalCuiButton.NormalOutline;
                    clonedCuiButton.HoverOutline = originalCuiButton.HoverOutline;
                    clonedCuiButton.PressedOutline = originalCuiButton.PressedOutline;
                    clonedCuiButton.BorderStyle = originalCuiButton.BorderStyle;
                    clonedCuiButton.ImageAutoCenter = originalCuiButton.ImageAutoCenter;
                    clonedCuiButton.HoverBackground = originalCuiButton.HoverBackground;
                    clonedCuiButton.PressedBackground = originalCuiButton.PressedBackground;
                    clonedCuiButton.NormalBackground = originalCuiButton.NormalBackground;
                    clonedCuiButton.HoveredImageTint = originalCuiButton.HoveredImageTint;
                    clonedCuiButton.HoverForeColor = originalCuiButton.HoverForeColor;
                    clonedCuiButton.PressedForeColor = originalCuiButton.PressedForeColor;
                    clonedCuiButton.NormalForeColor = originalCuiButton.NormalForeColor;
                    cloned.BackColor = originalCuiButton.BackColor;
                    clonedCuiButton.CheckButton = originalCuiButton.CheckButton;
                    clonedCuiButton.Checked = originalCuiButton.Checked;
                    clonedCuiButton.CheckedBackground = originalCuiButton.CheckedBackground;
                    clonedCuiButton.CheckedForeColor = originalCuiButton.CheckedForeColor;
                    clonedCuiButton.Content = originalCuiButton.Content;
                    clonedCuiButton.ImageExpand = originalCuiButton.ImageExpand;

                    if (originalCuiButton.Name.Contains("DeleteButton"))
                    {
                        clonedCuiButton.Click += (sender, e) => DeleteExpense_Click(sender, e, index);
                    }
                    else if (originalCuiButton.Name.Contains("EditButton"))
                    {
                        clonedCuiButton.Click += (sender, e) => EditExpense_Click(sender, e, index);
                    }
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
                        Control clonedChild = CloneExpenseControl(childControl, index);
                        cloned.Controls.Add(clonedChild);
                    }
                }
            }

            return cloned;
        }

        // Get ExpenseID for a specific row
        private int GetExpenseIdForRow(int rowIndex)
        {
            try
            {
                Cashbox_backend cashboxBackend = new Cashbox_backend();
                DataTable dt = cashboxBackend.GetAllExpenses();
                if (dt != null && rowIndex < dt.Rows.Count)
                {
                    DataRow row = dt.Rows[rowIndex];
                    // Get the ExpenseID from the database
                    if (row["ExpenseID"] != DBNull.Value)
                    {
                        return Convert.ToInt32(row["ExpenseID"]);
                    }
                }
                return -1; // Return -1 if not found
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting ExpenseID for row {rowIndex}: {ex.Message}");
                return -1;
            }
        }

        private void UpdateExpenseRowData(Panel expenseRow, DataRow dataRow, int rowIndex)
        {
            expenseRow.Visible = true;

            // Store the ExpenseID in the panel's Tag for easy access
            int expenseId = -1;
            if (dataRow["ExpenseID"] != DBNull.Value)
            {
                expenseId = Convert.ToInt32(dataRow["ExpenseID"]);
                expenseRow.Tag = expenseId;
            }

            // Get formatted date
            string formattedDate = "";
            if (dataRow["Date"] != DBNull.Value)
            {
                DateTime expenseDate = Convert.ToDateTime(dataRow["Date"]);
                formattedDate = expenseDate.ToString("MMM dd, yyyy");
            }

            foreach (Control control in expenseRow.Controls)
            {
                // Update ExpenseName label
                if (control.Name.StartsWith("ExpenseName") || control.Name.Contains("ExpenseName"))
                {
                    control.Text = dataRow["ExpenseName"]?.ToString() ?? "";
                }
                // Update ExpenseAmount label
                else if (control.Name.StartsWith("ExpenseAmount") || control.Name.Contains("ExpenseAmount"))
                {
                    if (dataRow["ExpenseAmount"] != DBNull.Value)
                    {
                        decimal amount = Convert.ToDecimal(dataRow["ExpenseAmount"]);
                        control.Text = $"₱{amount:N2}"; // Format as Philippine Peso
                    }
                    else
                    {
                        control.Text = "₱0.00";
                    }
                }
                // Update Category label
                else if (control.Name.StartsWith("Category") || control.Name.Contains("Category"))
                {
                    string category = dataRow["Category"]?.ToString() ?? "";
                    control.Text = category;

                    // Optional: Color-code based on category
                    if (category.Equals("Cash", StringComparison.OrdinalIgnoreCase))
                    {
                        control.ForeColor = Color.SaddleBrown;
                        control.Font = new Font(control.Font, FontStyle.Bold);
                    }
                    else if (category.Equals("Non-Cash", StringComparison.OrdinalIgnoreCase))
                    {
                        control.ForeColor = Color.SaddleBrown;
                        control.Font = new Font(control.Font, FontStyle.Bold);
                    }
                }
                // Update Date label (if you have one)
                else if (control.Name.StartsWith("Date") || control.Name.Contains("Date"))
                {
                    control.Text = formattedDate;
                }
                // Update buttons with ExpenseID in their Tag
                else if (control.Name.Contains("DeleteButton") || control.Name.Contains("EditButton"))
                {
                    control.Tag = expenseId; // Store ExpenseID in button's Tag
                }

                // Handle nested controls
                if (control.HasChildren)
                {
                    UpdateNestedExpenseControls(control, dataRow, rowIndex, expenseId, formattedDate);
                }
            }
        }

        private void UpdateNestedExpenseControls(Control parentControl, DataRow dataRow, int rowIndex, int expenseId, string formattedDate)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                // Apply the same logic as UpdateExpenseRowData for child controls
                if (childControl.Name.StartsWith("ExpenseName") || childControl.Name.Contains("ExpenseName"))
                {
                    childControl.Text = dataRow["ExpenseName"]?.ToString() ?? "";
                }
                else if (childControl.Name.StartsWith("ExpenseAmount") || childControl.Name.Contains("ExpenseAmount"))
                {
                    if (dataRow["ExpenseAmount"] != DBNull.Value)
                    {
                        decimal amount = Convert.ToDecimal(dataRow["ExpenseAmount"]);
                        childControl.Text = $"₱{amount:N2}";
                    }
                    else
                    {
                        childControl.Text = "₱0.00";
                    }
                }
                else if (childControl.Name.StartsWith("Category") || childControl.Name.Contains("Category"))
                {
                    string category = dataRow["Category"]?.ToString() ?? "";
                    childControl.Text = category;

                    // Optional: Color-code based on category
                    if (category.Equals("Cash", StringComparison.OrdinalIgnoreCase))
                    {
                        childControl.ForeColor = Color.Green;
                    }
                    else if (category.Equals("Non-Cash", StringComparison.OrdinalIgnoreCase))
                    {
                        childControl.ForeColor = Color.Blue;
                    }
                }
                else if (childControl.Name.StartsWith("Date") || childControl.Name.Contains("Date"))
                {
                    childControl.Text = formattedDate;
                }
                else if (childControl.Name.Contains("DeleteButton") || childControl.Name.Contains("EditButton"))
                {
                    childControl.Tag = expenseId; // Store ExpenseID in button's Tag
                }

                // Recursively handle deeper nesting if needed
                if (childControl.HasChildren)
                {
                    UpdateNestedExpenseControls(childControl, dataRow, rowIndex, expenseId, formattedDate);
                }
            }
        }

        // Event handler for Delete button clicks
        private void DeleteExpense_Click(object sender, EventArgs e, int rowIndex)
        {
            try
            {
                int expenseId = -1;

                if (sender is Control button && button.Tag != null)
                {
                    expenseId = Convert.ToInt32(button.Tag);
                }
                else
                {
                    expenseId = GetExpenseIdForRow(rowIndex);
                }

                if (expenseId <= 0)
                {
                    MessageBox.Show("Unable to identify the expense to delete.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this expense?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Cashbox_backend cashboxBackend = new Cashbox_backend();
                    if (cashboxBackend.DeleteExpense(expenseId))
                    {
                        MessageBox.Show("Expense deleted successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload the expense list to reflect changes
                        LoadExpenseItems();
                        updateText(); // Update the text labels with current data   
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete expense. Please try again.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting expense: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Edit button clicks
        private void EditExpense_Click(object sender, EventArgs e, int rowIndex)
        {
            try
            {
                // Get the ExpenseID from the button's Tag or by row index
                int expenseId = -1;

                if (sender is Control button && button.Tag != null)
                {
                    expenseId = Convert.ToInt32(button.Tag);
                }
                else
                {
                    expenseId = GetExpenseIdForRow(rowIndex);
                }

                if (expenseId <= 0)
                {
                    MessageBox.Show("Unable to identify the expense to edit.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the current expense data
                Cashbox_backend cashboxBackend = new Cashbox_backend();
                DataTable dt = cashboxBackend.GetAllExpenses();

                DataRow expenseRow = dt.AsEnumerable()
                    .FirstOrDefault(row => Convert.ToInt32(row["ExpenseID"]) == expenseId);

                if (expenseRow != null)
                {
                    // Create and show edit form (you'll need to create this form)
                    EditExpense editForm = new EditExpense();
                    editForm.LoadExpenseData(expenseId,
                                           expenseRow["ExpenseName"].ToString(),
                                           Convert.ToDecimal(expenseRow["ExpenseAmount"]),
                                           expenseRow["Category"].ToString());

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Reload the expense list to reflect changes
                        LoadExpenseItems();
                        updateText(); // Update the text labels with current data
                    }
                }
                else
                {
                    MessageBox.Show("Expense data not found.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing expense: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateText()
        {
            Cashbox_backend cashboxBackend = new Cashbox_backend();
            DataTable dt = cashboxBackend.GetAllTicket();
            DataTable dt2 = cashboxBackend.GetAllExpenses();

            // Initialize totals
            decimal cash = 0;
            decimal nonCashSales = 0;
            decimal cashExpenses = 0;
            decimal nonCashExpenses = 0;
            decimal gcashTotal = 0;
            decimal mayaTotal = 0;

            // Process ticket data (sales)
            foreach (DataRow row in dt.Rows)
            {
                string paymentType = row["paymentType"]?.ToString() ?? "";
                decimal totalAmount = Convert.ToDecimal(row["totalAmount"] ?? 0);

                // Get GCash and Maya amounts directly from the columns
                decimal gcashAmount = Convert.ToDecimal(row["GCashAmount"] ?? 0);
                decimal mayaAmount = Convert.ToDecimal(row["MayaAmount"] ?? 0);

                // Add to respective totals
                gcashTotal += gcashAmount;
                mayaTotal += mayaAmount;

                if (paymentType == "Cash")
                {
                    cash += totalAmount;
                }
                else if (paymentType == "Non-Cash")
                {
                    nonCashSales += totalAmount;
                }
            }

            // Process expenses data
            foreach (DataRow row in dt2.Rows)
            {
                string category = row["Category"]?.ToString() ?? "";
                decimal expenseAmount = Convert.ToDecimal(row["expenseAmount"] ?? 0);

                if (category == "Cash")
                {
                    cashExpenses += expenseAmount;
                }
                else if (category == "Non-Cash")
                {
                    nonCashExpenses += expenseAmount;
                }
            }

            // Update labels
            noncashlabel.Text = "₱" + nonCashExpenses.ToString("F2");
            cashlabel.Text = "₱" + cash.ToString("F2");
            cashexpenseslabel.Text = "₱" + cashExpenses.ToString("F2");
            gcashlabel.Text = "₱" + gcashTotal.ToString("F2");
            mayalabel.Text = "₱" + mayaTotal.ToString("F2");

            // Calculate net cash (Cash + Non-Cash sales - Cash expenses - Non-Cash expenses)
            decimal netCash = cash + nonCashSales - cashExpenses - nonCashExpenses;
            cashsaleslabel.Text = "₱" + netCash.ToString("F2");
        }
        private void DateChanger()
        {
            DateToday.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        private void cuiPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExpenseRow_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Custom painting logic for the ExpenseRow can be added here
        }

        private void CashboxHeader_Click(object sender, EventArgs e)
        {

        }

        private void ExpenseRow_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExpenseAmount_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void noncashlabel_Click(object sender, EventArgs e)
        {

        }

        private void mayalabel_Click(object sender, EventArgs e)
        {

        }
    }
}