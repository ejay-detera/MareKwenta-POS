using Mare_POS.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.StaffAdmin
{
    public partial class ResetPassword : Form
    {
        private AuthService authService;
        public ResetPassword()
        {
            InitializeComponent();
            authService = new AuthService();
        }


        private void UsernameText_ContentChanged(object sender, EventArgs e)
        {
            // Optional: Handle any logic when the username text changes
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(UsernameText.Content))
                {
                    MessageBox.Show("Username is required.", "Validation Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UsernameText.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(PasswordText.Content))
                {
                    MessageBox.Show("New Password is required.", "Validation Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordText.Focus();
                    return;
                }
                // Call the AuthService to reset the password
                bool success = authService.ResetPassword(UsernameText.Content.Trim(), PasswordText.Content);
                if (success)
                {
                    MessageBox.Show("Password reset successfully.", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close the form after successful reset
                }
                else
                {
                    MessageBox.Show("Failed to reset password. Please try again.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}