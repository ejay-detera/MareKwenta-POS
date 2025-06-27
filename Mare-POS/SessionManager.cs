using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Mare_POS.Authentication
{
    public static class SessionManager
    {
        private static EmployeeInfo _currentUser;
        private static DateTime _loginTime;
        private static DateTime _lastActivity;
        private static readonly TimeSpan _sessionTimeout = TimeSpan.FromMinutes(30); // 30-minute timeout

        // Properties
        public static EmployeeInfo CurrentUser
        {
            get => _currentUser;
            private set => _currentUser = value;
        }

        public static bool IsLoggedIn => _currentUser != null && !IsSessionExpired();

        public static DateTime LoginTime => _loginTime;
        public static DateTime LastActivity => _lastActivity;

        // Login method
        public static bool Login(string username, string password)
        {
            try
            {
                AuthService authService = new AuthService();
                EmployeeInfo user = authService.ValidateLogin(username, password);

                if (user != null)
                {
                    _currentUser = user;
                    _loginTime = DateTime.Now;
                    _lastActivity = DateTime.Now;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Logout method
        public static void Logout()
        {
            try
            {
                // Clear session data
                _currentUser = null;
                _loginTime = default(DateTime);
                _lastActivity = default(DateTime);
                MessageBox.Show("You have been logged out successfully.", "Logout",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update last activity (call this on user interactions)
        public static void UpdateActivity()
        {
            if (IsLoggedIn)
            {
                _lastActivity = DateTime.Now;
            }
        }

        // Check if session is expired
        public static bool IsSessionExpired()
        {
            if (_currentUser == null) return true;
            return DateTime.Now - _lastActivity > _sessionTimeout;
        }

        // Force logout if session expired
        public static void CheckSessionTimeout()
        {
            if (IsSessionExpired())
            {
                Logout();
                MessageBox.Show("Your session has expired. Please log in again.", "Session Expired",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowLoginForm();
            }
        }

        // Show login form
        public static void ShowLoginForm()
        {
            try
            {
                // Create and show login form
                Log_In loginForm = new Log_In();
                loginForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing login form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CloseAllForms()
        {
            try
            {
                var formsToClose = new List<Form>();

                foreach (Form form in Application.OpenForms)
                {
                    formsToClose.Add(form);
                }

                foreach (Form form in formsToClose)
                {
                    if (!form.IsDisposed)
                    {
                        form.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing forms: {ex.Message}");
            }
        }

        // Check if user has required role
        public static bool HasRole(string requiredRole)
        {
            if (!IsLoggedIn) return false;
            return _currentUser.Role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase);
        }

        public static bool RequireAuthentication()
        {
            if (!IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to access this feature.", "Authentication Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowLoginForm();
                return false;
            }

            CheckSessionTimeout();
            UpdateActivity();
            return IsLoggedIn;
        }
    }
}