using CuoreUI.Controls;
using Mare_POS.StaffAdmin;
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

            if (dataGridView1.Columns.Contains("Password"))
                dataGridView1.Columns["Password"].Visible = false;
            if (dataGridView1.Columns.Contains("Id"))
                dataGridView1.Columns["Id"].Visible = false;

            MakeRoundedPanel(panelRoundedContainer, 30);
            StyleCafeGrid(dataGridView1);
            //dataGridView1.ClearSelection();
        }
        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void cuiDataGridView1_Click(object sender, EventArgs e)
        {

        }
        
        private void StaffPageAdmin_Load_1(object sender, EventArgs e)
        {
            // This method is intentionally left empty.
            // The actual loading logic is handled in the StaffPageAdmin_Load method.
        }
        public void getData()
        {
            string conString = "server=localhost; uid=root; pwd=ejaydetera12; database=marepos-db;";
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string query = @"
            SELECT 
                t.EmployeeID, 
                e.FirstName,
                e.LastName,
                t.Date, 
                t.TimeIn, 
                t.TimeOut 
            FROM timelog t 
            INNER JOIN employees e ON t.EmployeeID = e.EmployeeID 
            WHERE e.OwnerID IS NULL 
              AND t.Date = CURDATE() 
            ORDER BY e.EmployeeID";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Add formatted columns
                dataTable.Columns.Add("Date:", typeof(string));
                dataTable.Columns.Add("Time In:", typeof(string));
                dataTable.Columns.Add("Time Out:", typeof(string));

                foreach (DataRow row in dataTable.Rows)
                {
                    // Format Date
                    if (row["Date"] != DBNull.Value)
                    {
                        DateTime date = Convert.ToDateTime(row["Date"]);
                        row["Date:"] = date.ToString("MMMM dd, yyyy");
                    }

                    // Format TimeIn
                    if (row["TimeIn"] != DBNull.Value)
                    {
                        TimeSpan timeIn = (TimeSpan)row["TimeIn"];
                        row["Time In:"] = DateTime.Today.Add(timeIn).ToString("h:mm tt");
                    }

                    // Format TimeOut
                    if (row["TimeOut"] != DBNull.Value)
                    {
                        TimeSpan timeOut = (TimeSpan)row["TimeOut"];
                        row["Time Out:"] = DateTime.Today.Add(timeOut).ToString("h:mm tt");
                    }
                }

                // Show only formatted columns + original name columns
                dataGridView1.DataSource = dataTable;

                this.BeginInvoke((MethodInvoker)delegate
                {
                    dataGridView1.ClearSelection();

                    // Optional: Hide raw columns if you want to show only formatted ones
                    dataGridView1.Columns["Date"].Visible = false;
                    dataGridView1.Columns["TimeIn"].Visible = false;
                    dataGridView1.Columns["TimeOut"].Visible = false;
                });
            }
        }


        private void dateHeader_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MakeRoundedPanel(Panel panel, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top left corner
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90); // Top right
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90); // Bottom right
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90); // Bottom left
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }

        private void CreateIngredient_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Add an Employee?", "Add Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var addEmployeeForm = new AddEmployee())
                    {
                        addEmployeeForm.ShowDialog();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Employee form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Reset a Password of an Employee?", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var addEmployeeForm = new ResetPassword())
                    {
                        addEmployeeForm.ShowDialog();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Reset Password Form form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelRoundedContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

