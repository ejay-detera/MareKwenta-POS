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
    public partial class PasswordPrompt : Form
    {
        public string EnteredPassword => txtPassword.Text;

        public PasswordPrompt(string employeeName)
        {
            InitializeComponent();
            lblPrompt.Text = $"Enter password for {employeeName}";
            txtPassword.UseSystemPasswordChar = true;

            buttonOk.Click += buttonOk_Click;
            buttonCancel.Click += buttonCancel_Click;
        }

        private void buttonOk_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PasswordPrompt_Load(object sender, EventArgs e)
        {
            // Optional logic on load (usually empty or for initial focus)
        }
    }
}
