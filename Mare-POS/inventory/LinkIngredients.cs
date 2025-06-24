using CuoreUI.Controls;
using MySql.Data.MySqlClient;
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
    public partial class LinkIngredients : UserControl
    {
        public LinkIngredients()
        {
            InitializeComponent();
        }

        private Inventory_backend dbHelper = new Inventory_backend();

        private void LinkIngredients_Load(object sender, EventArgs e)
        {
            dropdownvalue();
            LoadExistingIngredientData();
        }

        private void dropdownvalue()
        {
            List<string> ingredientNames = dbHelper.GetIngredientNamesForDropDown();
            var comboBoxes = GetAllControls(this).OfType<cuiComboBox>().ToList();

            foreach (cuiComboBox cb in comboBoxes)
            {
                cb.Items = ingredientNames.ToArray();
            }
        }

        private void LoadExistingIngredientData()
        {
            try
            {
                LoadPanelData("chgpanel", 5, "chg");
                LoadPanelData("cigpanel", 5, "cig");
                LoadPanelData("chvpanel", 5, "chv");
                LoadPanelData("civpanel", 5, "civ");
                LoadPanelData("nhgpanel", 2, "nhg");
                LoadPanelData("ncgpanel", 5, "ncg");
                LoadPanelData("nhvpanel", 2, "nhv");
                LoadPanelData("ncvpanel", 5, "ncv");
                LoadPanelData("foodpanel", 4, "food");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading existing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPanelData(string panelPrefix, int panelCount, string category)
        {
            for (int i = 1; i <= panelCount; i++)
            {
                string panelName = $"{panelPrefix}{i}";
                Panel panel = this.Controls.Find(panelName, true).FirstOrDefault() as Panel;

                if (panel != null)
                {
                    var labels = GetControlsFromPanel<Label>(panel);
                    string productName = "";
                    if (labels.Count > 0)
                    {
                        productName = labels.FirstOrDefault()?.Text ?? "";
                    }

                    if (!string.IsNullOrWhiteSpace(productName))
                    {
                        List<IngredientData> existingIngredients = dbHelper.GetExistingIngredientsForProduct(productName, category);

                        var comboBoxes = GetControlsFromPanel<cuiComboBox>(panel);
                        var textBoxes = GetControlsFromPanel<cuiTextBox>(panel);

                        for (int j = 0; j < Math.Min(existingIngredients.Count, Math.Min(comboBoxes.Count, textBoxes.Count)); j++)
                        {
                            comboBoxes[j].SelectedItem = existingIngredients[j].IngredientName;
                            //MessageBox.Show($"Ingredient: {existingIngredients[j].IngredientName} Quantity: {existingIngredients[j].Quantity}");
                            textBoxes[j].Content = existingIngredients[j].Quantity;
                        }
                    }
                }
            }
        }

        public static IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = container.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }

        public class IngredientData
        {
            public string IngredientName { get; set; }
            public string Quantity { get; set; }
            public string Unit { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
        }

        // Updated method to handle different panel types and counts with category
        private List<IngredientData> CollectPanelData(string panelPrefix, int panelCount, string category)
        {
            List<IngredientData> ingredientsList = new List<IngredientData>();

            // Loop through panels based on the specified count
            for (int i = 1; i <= panelCount; i++)
            {
                string panelName = $"{panelPrefix}{i}";
                Panel panel = this.Controls.Find(panelName, true).FirstOrDefault() as Panel;

                if (panel != null)
                {
                    // Get all controls from the current panel
                    var comboBoxes = GetControlsFromPanel<cuiComboBox>(panel);
                    var textBoxes = GetControlsFromPanel<cuiTextBox>(panel);
                    var labels = GetControlsFromPanel<Label>(panel);

                    string productName = "";
                    if (labels.Count > 0)
                    {
                        productName = labels.FirstOrDefault()?.Text ?? "";
                    }

                    for (int j = 0; j < comboBoxes.Count; j++)
                    {
                        if (j < textBoxes.Count)
                        {
                            string ingredientName = "";
                            if (comboBoxes[j].SelectedIndex >= 0 && comboBoxes[j].SelectedIndex < comboBoxes[j].Items.Length)
                            {
                                ingredientName = comboBoxes[j].Items[comboBoxes[j].SelectedIndex];
                            }

                            IngredientData ingredient = new IngredientData
                            {
                                IngredientName = ingredientName,
                                Quantity = textBoxes[j].Content,
                                ProductName = productName,
                                Category = category
                            };

                            // Only add if ingredient name and quantity are not empty
                            if (!string.IsNullOrWhiteSpace(ingredient.IngredientName) &&
                                !string.IsNullOrWhiteSpace(ingredient.Quantity))
                            {
                                ingredientsList.Add(ingredient);
                            }
                        }
                    }
                }
            }

            return ingredientsList;
        }

        private List<T> GetControlsFromPanel<T>(Control panel) where T : Control
        {
            return GetAllControls(panel).OfType<T>().ToList();
        }

        private void HandlePanelDataInsertion(string panelPrefix, int panelCount, string category, string panelTypeName)
        {
            try
            {
                List<IngredientData> ingredients = CollectPanelData(panelPrefix, panelCount, category);

                if (ingredients.Count > 0)
                {
                    bool success = dbHelper.InsertOrUpdateIngredientsToDatabase(ingredients);

                    if (success)
                    {

                        LoadExistingIngredientData();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to save {panelTypeName} ingredients to database.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"No {panelTypeName} ingredient data found to save.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing {panelTypeName}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers for all button types - updated to pass category
        private void chg_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("chgpanel", 5, "chg", "CHG");
        }

        private void cig_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("cigpanel", 5, "cig", "CIG");
        }

        private void chv_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("chvpanel", 5, "chv", "CHV");
        }

        private void civ_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("civpanel", 5, "civ", "CIV");
        }

        private void nhg_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("nhgpanel", 2, "nhg", "NHG");
        }

        private void ncg_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("ncgpanel", 5, "ncg", "NCG");
        }

        private void nhv_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("nhvpanel", 2, "nhv", "NHV");
        }

        private void ncv_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("ncvpanel", 5, "ncv", "NCV");
        }

        private void foods_button_Click(object sender, EventArgs e)
        {
            HandlePanelDataInsertion("foodpanel", 4, "food", "FOOD");
        }

        private void cuiScrollbar1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click_1(object sender, EventArgs e)
        {

        }
        private void cuiSeparator1_Load(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void label48_Click(object sender, EventArgs e)
        {

        }
        private void cuiComboBox129_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void chgpanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void label26_Click(object sender, EventArgs e)
        {

        }
        private void label30_Click(object sender, EventArgs e)
        {

        }
        private void label40_Click(object sender, EventArgs e)
        {

        }
        private void label39_Click(object sender, EventArgs e)
        {

        }
    }
}