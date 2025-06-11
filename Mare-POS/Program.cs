using Mare_POS; // Add this using directive
using Mare_POS.Authentication;
using Mare_POS.inventory;
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
                new DatabaseSeeder().SeedDatabase();
                Application.Run(new Log_In());
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}