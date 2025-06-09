using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS.Authentication
{
    public partial class Log_In : Form
    {

        private AuthService authService;
        private EmployeeInfo currentEmployee;

        public Log_In()
        {
            InitializeComponent();

            authService = new AuthService();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private async void PerformLogin()
        {
            if (!ValidateInput()) return;

            SetLoadingState(true);

            try
            {
                bool loginSuccess = await Task.Run(() =>
                    SessionManager.Login(UsernameText.Content.Trim(), PasswordText.Content));

                if (loginSuccess)
                {
                    HandleSuccessfulLogin();
                }
                else
                {
                    HandleFailedLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }
        private bool ValidateInput()
        {
            // Check username
            if (string.IsNullOrWhiteSpace(UsernameText.Content))
            {
                MessageBox.Show("Please enter a username.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsernameText.Focus();
                return false;
            }

            // Check password
            if (string.IsNullOrWhiteSpace(PasswordText.Content))
            {
                MessageBox.Show("Please enter a password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordText.Focus();
                return false;
            }

            return true;
        }

        private void SetLoadingState(bool isLoading)
        {
            LoginButton.Enabled = !isLoading;
            LoginButton.Text = isLoading ? "Logging in..." : "Login";
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private void HandleSuccessfulLogin()
        {
            MessageBox.Show($"Welcome, {SessionManager.CurrentUser.FullName}!\nRole: {SessionManager.CurrentUser.Role}",
                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Hide login form and show main application
            this.Hide();
            NavbarForm mainForm = new NavbarForm();
            mainForm.FormClosed += (s, e) => this.Close();
            mainForm.Show();
        }

        private void HandleFailedLogin()
        {
            MessageBox.Show("Invalid username or password. Please try again.",
                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Clear password and refocus
            PasswordText.Content = "";
            UsernameText.Focus();
            UsernameText.Select();
        }

        private void RedirectBasedOnRole(string role)
        {
            try
            {
                Form nextForm = null;

                switch (role.ToUpper())
                {
                    case "ADMIN":
                        MessageBox.Show("Redirecting to Admin Dashboard...", "Access Granted");
                        nextForm = new NavbarForm(); // Create admin dashboard form
                        break;

                    case "EMPLOYEE":
                        MessageBox.Show("Redirecting to Employee Dashboard...", "Access Granted");
                        nextForm = new NavbarForm(); // Create employee dashboard form
                        break;

                    default:
                        MessageBox.Show($"Role '{role}' is not recognized. Contact administrator.",
                            "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Hide the login form
                this.Hide();

                // Set up event handler to close login form when next form closes
                nextForm.FormClosed += (s, e) => this.Close();

                // Show the next form
                nextForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error redirecting user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers for Enter key navigation
        private void UsernameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PasswordText.Focus();
                e.Handled = true;
            }
        }

        private void PasswordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformLogin();
                e.Handled = true;
            }
        }
    }

    // Static session management class
    public static class CurrentSession
    {
        public static EmployeeInfo Employee { get; set; }

        public static bool IsLoggedIn => Employee != null;

        public static bool HasRole(string role)
        {
            return Employee?.Role?.Equals(role, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        public static bool HasAnyRole(params string[] roles)
        {
            if (Employee == null) return false;

            foreach (string role in roles)
            {
                if (Employee.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static void Logout()
        {
            Employee = null;
        }
    }
}
