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
                //SetupDatabase();

                // Start the application
                Application.Run(new Log_In());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SetupDatabase()
        {
            try
            {
                var dbCreator = new MarePosDbCreator("localhost", "root", "ejaydetera12");

                // Use GetAwaiter().GetResult() to run async method synchronously
                bool success = dbCreator.CreateDatabaseAndTablesAsync().GetAwaiter().GetResult();

                if (success)
                {
                    new DatabaseSeeder().SeedDatabase();
                    Console.WriteLine("Database setup completed successfully.");
                }
                else
                {
                    throw new Exception("Failed to setup database. Check console for details.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database setup failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw to be caught by Main
            }
        }
    }
}