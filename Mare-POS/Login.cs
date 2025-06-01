using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuoreUI.Controls; // Assuming CuoreUI is a custom UI library used in the project

namespace Mare_POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetupForm(); // Call the method to set up the form properties
        }
        private void SetupForm()
        {
            // Form properties
            this.Text = "MareKwenta POS - Login";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(220, 206, 180); // Beige background
        }
    }
}
