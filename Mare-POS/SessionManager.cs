using System;
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
            _currentUser = null;
            _loginTime = default;
            _lastActivity = default;
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
            // Hide all open forms except login
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != "LoginForm")
                {
                    form.Hide();
                }
            }

            // Show login form (you'll need to create this)
            Log_In loginForm = new Log_In();
            loginForm.ShowDialog();
        }

        // Check if user has required role
        public static bool HasRole(string requiredRole)
        {
            if (!IsLoggedIn) return false;
            return _currentUser.Role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase);
        }

        // Check if user has any of the required roles
        public static bool HasAnyRole(params string[] requiredRoles)
        {
            if (!IsLoggedIn) return false;

            foreach (string role in requiredRoles)
            {
                if (_currentUser.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        // Require authentication - call this at the start of protected forms/methods
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

        // Require specific role - call this for role-based access
        public static bool RequireRole(string requiredRole)
        {
            if (!RequireAuthentication()) return false;

            if (!HasRole(requiredRole))
            {
                MessageBox.Show($"Access denied. This feature requires '{requiredRole}' role.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Require any of the specified roles
        public static bool RequireAnyRole(params string[] requiredRoles)
        {
            if (!RequireAuthentication()) return false;

            if (!HasAnyRole(requiredRoles))
            {
                string roleList = string.Join(" or ", requiredRoles);
                MessageBox.Show($"Access denied. This feature requires one of these roles: {roleList}", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}