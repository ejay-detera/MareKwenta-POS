using Mare_POS.Models;
using System.Security.Cryptography;
using System.Text;

namespace Mare_POS.Services
{
    public class AuthenticationService
    {
        private readonly MyDbContext _context;
        private static Employee? _currentUser;

        public AuthenticationService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Authenticates user with username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Plain text password</param>
        /// <returns>True if authentication successful, false otherwise</returns>
        public bool Login(string username, string password)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

                // Find user in database
                var user = _context.Employees
                    .FirstOrDefault(e => e.Username.ToLower() == username.ToLower());

                if (user == null)
                {
                    return false;
                }

                // Verify password
                if (VerifyPassword(password, user.Password))
                {
                    _currentUser = user;
                    LogLoginActivity(user.EmployeeID);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Log exception (you might want to use a logging framework)
                Console.WriteLine($"Login error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Logs out the current user
        /// </summary>
        public void Logout()
        {
            if (_currentUser != null)
            {
                LogLogoutActivity(_currentUser.EmployeeID);
                _currentUser = null;
            }
        }

        /// <summary>
        /// Gets the currently logged-in user
        /// </summary>
        /// <returns>Current user or null if not logged in</returns>
        public Employee? GetCurrentUser()
        {
            return _currentUser;
        }

        /// <summary>
        /// Checks if a user is currently logged in
        /// </summary>
        /// <returns>True if user is logged in</returns>
        public bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        /// <summary>
        /// Gets the current user's role
        /// </summary>
        /// <returns>User role or empty string if not logged in</returns>
        public string GetCurrentUserRole()
        {
            return _currentUser?.Role ?? string.Empty;
        }

        /// <summary>
        /// Checks if current user has specific role
        /// </summary>
        /// <param name="role">Role to check</param>
        /// <returns>True if user has the role</returns>
        public bool HasRole(string role)
        {
            return _currentUser?.Role?.Equals(role, StringComparison.OrdinalIgnoreCase) == true;
        }

        /// <summary>
        /// Changes password for current user
        /// </summary>
        /// <param name="oldPassword">Current password</param>
        /// <param name="newPassword">New password</param>
        /// <returns>True if password changed successfully</returns>
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (_currentUser == null)
                return false;

            try
            {
                var user = _context.Employees.Find(_currentUser.EmployeeID);
                if (user == null || !VerifyPassword(oldPassword, user.Password))
                    return false;

                user.Password = HashPassword(newPassword);
                _context.SaveChanges();

                // Update current user object
                _currentUser.Password = user.Password;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Password change error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Hashes a password using SHA256
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <returns>Hashed password</returns>
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Verifies a password against its hash
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <param name="hash">Hashed password from database</param>
        /// <returns>True if password matches</returns>
        private bool VerifyPassword(string password, string hash)
        {
            string hashedInput = HashPassword(password);
            return hashedInput.Equals(hash, StringComparison.Ordinal);
        }

        /// <summary>
        /// Logs login activity (optional - for audit trail)
        /// </summary>
        /// <param name="employeeId">Employee ID</param>
        private void LogLoginActivity(int employeeId)
        {
            // You can implement logging to database or file here
            // For example, create a UserActivity table to track logins
            Console.WriteLine($"User {employeeId} logged in at {DateTime.Now}");
        }

        /// <summary>
        /// Logs logout activity (optional - for audit trail)
        /// </summary>
        /// <param name="employeeId">Employee ID</param>
        private void LogLogoutActivity(int employeeId)
        {
            // You can implement logging to database or file here
            Console.WriteLine($"User {employeeId} logged out at {DateTime.Now}");
        }

        /// <summary>
        /// Validates if username is available for new registration
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns>True if username is available</returns>
        public bool IsUsernameAvailable(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return !_context.Employees.Any(e => e.Username.ToLower() == username.ToLower());
        }
    }
}