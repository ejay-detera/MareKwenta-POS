using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class EmployeeCard : UserControl
    {
        public string EmployeeName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public TimeSpan WorkDuration
        {
            set => lblDuration.Text = $"{value.Hours} hrs {value.Minutes} mins";
        }
        public string EmployeePassword { get; set; } = "";
        public event EventHandler? InClicked;
        public event EventHandler? OutClicked;

        public EmployeeCard()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            OutClicked?.Invoke(this, EventArgs.Empty);
        }

        private void EmployeeCard_Load(object sender, EventArgs e)
        {

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int radius = 24; // Adjust for more/less rounding
            using (GraphicsPath path = GetRoundedRectPath(this.ClientRectangle, radius))
            {
                this.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
        private bool isClockedIn = false;
        private bool isClockedOut = false;

        public bool IsClockedIn
        {
            get => isClockedIn;
            private set
            {
                isClockedIn = value;
                btnIn.Checked = value;
                btnIn.NormalBackground = value ? Color.FromArgb(49, 180, 82) : Color.White; // Green
                btnIn.ForeColor = value ? Color.White : Color.FromArgb(78, 45, 24);
            }
        }

        public bool IsClockedOut
        {
            get => isClockedOut;
            private set
            {
                isClockedOut = value;
                btnOut.Checked = value;
                btnOut.NormalBackground = value ? Color.FromArgb(255, 106, 0) : Color.White; // Orange
                btnOut.ForeColor = value ? Color.White : Color.FromArgb(78, 45, 24);
            }
        }
        public void LoadStatus(bool clockedIn, bool clockedOut)
        {
            IsClockedIn = clockedIn;
            IsClockedOut = clockedOut;
        }
        
        
    }

}
