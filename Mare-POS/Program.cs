using Mare_POS; // Add this using directive
using System;
using System.Windows.Forms;

namespace Mare_POS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Inventory()); // Ensure you start the application with a form
                Application.Run(new Form1()); // This line is redundant if you already have a main form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}