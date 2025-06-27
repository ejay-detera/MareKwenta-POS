using Mare_POS;
using Mare_POS.Authentication;
using Mare_POS.inventory;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS
{
    internal static class Program
    {
        [STAThread]
        static void Main() // Changed from async Task Main() to void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();

                // Run database setup synchronously

                // Start the application
                Application.Run(new Log_In());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}