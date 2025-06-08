using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void addExpenseButton_Click(object sender, EventArgs e)
        {
            AddExpenseForm popup = new AddExpenseForm();
            popup.ShowDialog(); // This pops it up as a modal
        }


    }
}
