using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Metadata;

namespace Mare_POS
{
    public partial class CashboxForm : UserControl
    {
        public CashboxForm()
        {
            InitializeComponent();

            this.btn_addExpense.Click += new System.EventHandler(this.btn_plus_Click);
            label17.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void btn_plus_Click(object? sender, EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm();
            addExpenseForm.StartPosition = FormStartPosition.CenterParent;
            addExpenseForm.ShowDialog();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton5_Click(object sender, EventArgs e)
        {

        }

    }
}
