using Mare_POS.SaleshistoryFolder;

namespace Mare_POS
{
    public partial class NavbarForm : Form
    {
        private Panel contentPanel = new Panel();
        private Button activeButton = new Button();

        // Enum to define user types
        public enum UserType
        {
            User,
            Admin
        }

        // Property to store current user type
        private UserType currentUserType;

        // Property to get/set user type with automatic UI update
        public UserType CurrentUserType
        {
            get { return currentUserType; }
            set
            {
                currentUserType = value;
                UpdateSidebarVisibility();
            }
        }

        public NavbarForm()
        {
            InitializeComponent();
            InitializeContentPanel();
            // Set default user type (you can change this based on login)
            CurrentUserType = UserType.Admin; // Default to User access
        }

        private void InitializeContentPanel()
        {
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.White;
            contentPanel.Location = new Point(navbarPanel.Width, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1440, 1024);
            Controls.Add(contentPanel);
            Controls.SetChildIndex(contentPanel, 0);
        }

        // Method to update sidebar button visibility based on user type
        private void UpdateSidebarVisibility()
        {
            if (currentUserType == UserType.Admin)
            {
                // Admin sees all buttons
                ShowAllButtons();
            }
            else
            {
                // User sees only specific buttons
                ShowUserButtons();
            }
        }

        // Show all buttons for Admin
        private void ShowAllButtons()
        {
            // Show all sidebar buttons
            btn_dashboard.Visible = true;
            btn_inventory.Visible = true;
            btn_ticket.Visible = true;
            btn_staff.Visible = true;
            btn_receipt.Visible = true;
            btn_cashbox.Visible = true;
        }

        // Show only specific buttons for User
        private void ShowUserButtons()
        {
            // Hide admin-only buttons
            btn_dashboard.Visible = false;
            btn_inventory.Visible = false;

            // Show user-allowed buttons
            btn_ticket.Visible = true;
            btn_staff.Visible = true;
            btn_receipt.Visible = true;
            btn_cashbox.Visible = true;
        }

        // Method to set user type (call this after login validation)
        public void SetUserAccess(string username, string userRole)
        {
            if (userRole.ToLower() == "admin" || username.ToLower() == "admin")
            {
                CurrentUserType = UserType.Admin;
            }
            else
            {
                CurrentUserType = UserType.User;
            }
        }

        // Alternative method using boolean
        public void SetUserAccess(bool isAdmin)
        {
            CurrentUserType = isAdmin ? UserType.Admin : UserType.User;
        }

        // Method to toggle between user types (for testing purposes)
        public void ToggleUserType()
        {
            CurrentUserType = (currentUserType == UserType.Admin) ? UserType.User : UserType.Admin;
        }

        private void LoadPage(UserControl page)
        {
            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
        }

        private void HighlightButton(Button clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.Transparent;
                activeButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                activeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            }

            clickedButton.BackColor = Color.FromArgb(60, 78, 45, 24);
            clickedButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 78, 45, 24);
            clickedButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 78, 45, 24);
            activeButton = clickedButton;
        }

        private void btn_inventory_Click(object sender, EventArgs e)
        {
            LoadPage(new InventoryPage());
            HighlightButton((Button)sender);
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            LoadPage(new StaffPage()); // change the "StaffPage" to the name of you user control
            HighlightButton((Button)sender);
        }

        private void btn_receipt_Click(object sender, EventArgs e)
        {
            LoadPage(new SaleshistoryForm()); // change the "ReceiptPage" to the name of you user control
            HighlightButton((Button)sender);
        }

        private void btn_cashbox_Click(object sender, EventArgs e)
        {
            LoadPage(new CashboxForm());
            HighlightButton((Button)sender);
        }

        private void btn_ticket_Click(object sender, EventArgs e)
        {
            LoadPage(new TicketPage()); // change the "TicketPage" to the name of you user control
            HighlightButton((Button)sender);
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new DashboardPage()); // change the "DashboardPage" to the name of you user control
            HighlightButton((Button)sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPage(new TicketPage());
            HighlightButton(btn_ticket);
        }

        private void bottomMarker_Paint(object sender, PaintEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class InventoryPage : UserControl
    {
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(242, 239, 234);
            Label label = new Label();
            label.Text = "This is the Inventory Page";
            label.Font = new Font("Segoe UI", 16);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
        }
    }

    public class StaffPage : UserControl
    {
        public StaffPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(242, 239, 234);
            Label label = new Label();
            label.Text = "This is the Staff Page";
            label.Font = new Font("Segoe UI", 16);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
        }
    }

    public class ReceiptPage : UserControl
    {
        public ReceiptPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(242, 239, 234);
            Label label = new Label();
            label.Text = "This is the Receipt Page";
            label.Font = new Font("Segoe UI", 16);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
        }
    }

    public class CashboxPage : UserControl
    {
        public CashboxPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(242, 239, 234);
            Label label = new Label();
            label.Text = "This is the Cashbox Page";
            label.Font = new Font("Segoe UI", 16);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
        }
    }

    public class TicketPage : UserControl
    {
        public TicketPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(242, 239, 234);
            Label label = new Label();
            label.Text = "This is the Ticket Page";
            label.Font = new Font("Segoe UI", 16);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
        }
    }

    public class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(242, 239, 234);
            Label label = new Label();
            label.Text = "This is the Dashboard Page";
            label.Font = new Font("Segoe UI", 16);
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
        }
    }

}