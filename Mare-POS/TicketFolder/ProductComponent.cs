using Mare_POS.TicketFolder.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.Ticket_Components
{
    public partial class ProductComponent : Form
    {
        public ProductComponent()
        {
            InitializeComponent();
            quantity = 1;
            labelQuantity.Text = "1";

            UpdateSubtotal(); // ✅ Set initial subtotal
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";

        public string? SelectedSize { get; private set; }
        public string? SelectedType { get; private set; }
        public int Quantity { get; private set; }

        private int quantity = 1;

        private void radioGrande_CheckedChanged(object sender, EventArgs e) => UpdateSubtotal();
        private void radioVenti_CheckedChanged_1(object sender, EventArgs e) => UpdateSubtotal();
        private void radioHot_CheckedChanged(object sender, EventArgs e) => UpdateSubtotal();
        private void radioCold_CheckedChanged(object sender, EventArgs e) => UpdateSubtotal();

        private void chkSoloShot_CheckedChanged_1(object sender, EventArgs e) => UpdateSubtotal();
        private void chkDoppioShot_CheckedChanged_1(object sender, EventArgs e) => UpdateSubtotal();
        private void chkWhipCream_CheckedChanged_1(object sender, EventArgs e) => UpdateSubtotal();


        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            // ✅ Handle Size (only one should be selected)
            if (radioGrande.Checked)
                SelectedSize = "Grande";
            else if (radioVenti.Checked)
                SelectedSize = "Venti";
            else
            {
                MessageBox.Show("Please select a size.");
                return;
            }

            // ✅ Handle Type (only one should be selected)
            if (radioHot.Checked)
                SelectedType = "Hot";
            else if (radioCold.Checked)
                SelectedType = "Cold";
            else
            {
                MessageBox.Show("Please select a type.");
                return;
            }

            // ✅ Handle Quantity
            Quantity = quantity;

            // ✅ Close the popup with result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            quantity++;
            labelQuantity.Text = quantity.ToString();
            UpdateSubtotal();
        }

        private void QuantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                labelQuantity.Text = quantity.ToString();
                UpdateSubtotal();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void UpdateSubtotal()
        {
            try
            {
                int productId = ProductId;
                string size = radioGrande.Checked ? "Grande" : "Venti";
                string type = radioHot.Checked ? "Hot" : "Cold";

                decimal basePrice = ProductDataAccess.GetBasePrice(productId, size, type);
                decimal total = basePrice * quantity;

                labelSubtotal.Text = $"{total:0.00}";
            }
            catch
            {
                labelSubtotal.Text = "₱0.00"; // fallback
            }
        }

        private void ProductComponent_Load(object sender, EventArgs e)
        {

        }
    }
}