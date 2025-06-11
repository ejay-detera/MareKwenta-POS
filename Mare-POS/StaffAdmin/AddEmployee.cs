using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mare_POS.Authentication;

namespace Mare_POS.StaffAdmin
{
    public partial class AddEmployee : Form
    {
        private AuthService authService;

        public AddEmployee()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(FirstNameText.Content))
                {
                    MessageBox.Show("First Name is required.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FirstNameText.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(LastNameText.Content))
                {
                    MessageBox.Show("Last Name is required.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LastNameText.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(UsernameText.Content))
                {
                    MessageBox.Show("Username is required.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UsernameText.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(PasswordText.Content))
                {
                    MessageBox.Show("Password is required.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordText.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(RoleText.Content))
                {
                    MessageBox.Show("Role is required.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RoleText.Focus();
                    return;
                }

                // Get values from textboxes
                string lastName = LastNameText.Content.Trim();
                string firstName = FirstNameText.Content.Trim();
                string middleName = MiddleNameText.Content.Trim();
                string username = UsernameText.Content.Trim();
                string password = PasswordText.Content;
                string role = RoleText.Content.Trim();

                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to create employee:\n\n" +
                    $"Name: {firstName} {middleName} {lastName}\n" +
                    $"Username: {username}\n" +
                    $"Role: {role}",
                    "Confirm Employee Creation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = authService.CreateEmployee(
                        lastName: lastName,
                        firstName: firstName,
                        middleName: middleName,
                        role: role,
                        username: username,
                        password: password,
                        ownerID: null
                    );

                    if (success)
                    {
                        MessageBox.Show("Employee created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create employee. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while creating the employee:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            FirstNameText.Content = "";
            LastNameText.Content = "";
            MiddleNameText.Content = "";
            UsernameText.Content = "";
            PasswordText.Content = "";
            RoleText.Content = "";
            FirstNameText.Focus();
        }

        private void PasswordText_ContentChanged(object sender, EventArgs e)
        {

        }
    }
}