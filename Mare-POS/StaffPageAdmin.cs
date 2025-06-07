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

namespace Mare_POS
{
    public partial class StaffPageAdmin : UserControl
    {
        
        public StaffPageAdmin()
        {
            InitializeComponent();
            this.Load += StaffPageAdmin_Load;
        }

        private void StaffPageAdmin_Load(object? sender, EventArgs e)
        {
            dateHeader.Content = DateTime.Now.ToString("MMMM dd, yyyy");
            getData();
            StyleCafeGrid(dataGridView1);
        }
        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void cuiDataGridView1_Click(object sender, EventArgs e)
        {

        }
        public void getData()
        {
            // This method can be used to fetch data from a database or other source
            // and populate the DataGridView with employee logs.
            // For now, it is left empty as a placeholder.
            string conString = "server=localhost; uid=root; pwd=Exosaranghaja21_; database=mareposdb;";
            MySqlConnection connection = new MySqlConnection(conString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users", connection);
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
            
        }

    }
}
    

