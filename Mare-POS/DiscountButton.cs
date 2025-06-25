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

namespace Mare_POS
{
    public partial class DiscountButton : UserControl
    {
        public event Action<decimal> DiscountClicked;
        public event Action<decimal> PesoDiscountEntered;
        public event Action<decimal> PercentDiscountEntered;
        public event Action DiscountCleared;


        public DiscountButton()
        {
            InitializeComponent();

            // Button click events (5%, 10%, etc.)
            btn5.Click += DiscountButton_Click;
            btn10.Click += DiscountButton_Click;
            btn20.Click += DiscountButton_Click;
            btn100.Click += DiscountButton_Click;

            // Input field formatting & trigger
            txtPeso.Leave += txtPeso_Leave;
            txtPeso.KeyDown += txtPeso_KeyDown;
            txtPercent.KeyUp += txtPercent_KeyUp;

            // Clear discount
            btnClear.Click += BtnClear_Click;
        }

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DiscountButton_Click(object sender, EventArgs e)
        {
            if (sender is Control ctrl && decimal.TryParse(ctrl.Tag?.ToString(), out decimal percent))
            {
                DiscountClicked?.Invoke(percent);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtPeso.Text = string.Empty;
            txtPercent.Text = string.Empty;
            DiscountCleared?.Invoke();
        }

        private void txtPeso_Leave(object sender, EventArgs e)
        {
            string input = txtPeso.Text.Replace("₱", "").Trim();

            if (int.TryParse(input, out int intValue))
            {
                if (intValue >= 1 && intValue <= 999)
                {
                    decimal value = Convert.ToDecimal(intValue);

                    txtPeso.TextChanged -= txtPeso_TextChanged;
                    txtPeso.Text = $"₱{value:N2}";
                    txtPeso.SelectionStart = txtPeso.Text.Length;
                    txtPeso.TextChanged += txtPeso_TextChanged;

                    PesoDiscountEntered?.Invoke(value);
                }
            }
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevent ding sound
                txtPeso_Leave(sender, e);  // manually trigger it
            }
        }

        private void txtPercent_KeyUp(object sender, KeyEventArgs e)
        {
            string input = txtPercent.Text.Replace("%", "").Trim();

            if (decimal.TryParse(input, out decimal value))
            {
                txtPercent.TextChanged -= txtPercent_TextChanged;
                txtPercent.Text = $"{value:0.#}%";
                txtPercent.SelectionStart = txtPercent.Text.Length;
                txtPercent.TextChanged += txtPercent_TextChanged;

                PercentDiscountEntered?.Invoke(value);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
