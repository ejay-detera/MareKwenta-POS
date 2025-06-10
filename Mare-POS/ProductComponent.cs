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
        }

        public string? SelectedSize { get; private set; }
        public string? SelectedType { get; private set; }
        public List<string> SelectedExtras { get; private set; } = new List<string>();
        public int Quantity { get; private set; }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // Example: logic to set these values based on controls
            if (radioGrande.Checked) SelectedSize = "Grande";
            else if (radioVenti.Checked) SelectedSize = "Venti";

            if (radioHot.Checked) SelectedType = "Hot";
            else if (radioCold.Checked) SelectedType = "Cold";

            SelectedExtras.Clear();
            if (chkSoloShot.Checked) SelectedExtras.Add("Solo Shot");
            if (chkDoppioShot.Checked) SelectedExtras.Add("Doppio Shot");
            if (chkWhipCream.Checked) SelectedExtras.Add("Whip Cream");

            //Quantity = (int)numericUpDownQuantity.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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
    }
}
