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

namespace Mare_POS
{
    public partial class FoodQuantity : Form
    {
        public FoodQuantity()
        {
            InitializeComponent();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public int Quantity { get; private set; }

        private int quantity = 1;
        private decimal unitPrice = 0;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            quantity++;
            labelQuantity.Text = quantity.ToString();
            UpdateSubtotal();
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            // ✅ Handle Quantity
            Quantity = quantity;

            // ✅ Close the popup with result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                if (quantity > 1)
                {
                    quantity--;
                    labelQuantity.Text = quantity.ToString();
                    UpdateSubtotal();
                }
            }
        }

        private void UpdateSubtotal()
        {
            decimal total = unitPrice * quantity;
            labelSubtotal.Text = $"{total:0.00}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FoodQuantity_Load(object sender, EventArgs e)
        {
            unitPrice = ProductDataAccess.GetBasePrice(ProductId); // ✅ Reads from DB

            quantity = 1;
            labelQuantity.Text = quantity.ToString();
            UpdateSubtotal();
        }
    }
}