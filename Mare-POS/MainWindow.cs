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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Load += MainWindow_Load;
            

        }

        private void MainWindow_Load(object? sender, EventArgs e)
        {
            LoadUserControl(new EmployeeLogsEmployee()); // default view on startup
        }

        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void btnEmployeeView_Click(object sender, EventArgs e)
        {
            LoadUserControl(new EmployeeLogsEmployee());
        }
        private void btnAdminView_Click(object sender, EventArgs e)
        {
            LoadUserControl(new EmployeeLogsAdmin());
        }
    }
}
