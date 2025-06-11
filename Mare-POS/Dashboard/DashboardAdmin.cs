using CuoreUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Measure;
using LiveChartsCore.Painting;


namespace Mare_POS
{
    public partial class DashboardAdmin : UserControl
    {
        public DashboardAdmin()
        {
            InitializeComponent();
            this.Load += DashboardAdmin_Load;
        }
        private void DashboardAdmin_Load(object sender, EventArgs e)
        {

            comboBox1.Items.AddRange(new object[] { "Sales Summary", "Sales by Product", "Sales by Category" });
            cbTimeRange.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            cbTimeRange.SelectedIndexChanged += CbTimeRange_SelectedIndexChanged;
            cbDateFilter.SelectedIndexChanged += ComboBoxDependenciesChanged;

            // Init defaults
            cbTimeRange.Enabled = false;
            cbDateFilter.Enabled = false;
            btnGenerateChart.Enabled = false;
            MakeRoundedPanel(panelRoundedContainer, 30);
            MakeRoundedPanel(panelRoundedContainer1, 30);
            MakeRoundedPanel(panelRoundedContainer2, 30);
            MakeRoundedPanel(chartContainer, 30);
        }

        private void PopulateDaysOfMonth(ComboBox cb)
        {
            var today = DateTime.Today;
            var daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            for (int i = 1; i <= daysInMonth; i++)
            {
                cb.Items.Add(new DateTime(today.Year, today.Month, i).ToString("MMMM d, yyyy"));
            }
        }

        private void PopulateWeeks(ComboBox cb, int year = -1, int month = -1)
        {
            cb.Items.Clear();

            if (year == -1 || month == -1)
            {
                var now = DateTime.Now;
                year = now.Year;
                month = now.Month;
            }

            var firstDayOfMonth = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);

            int startDay = 1;
            int weekNumber = 1;

            while (startDay <= daysInMonth)
            {
                int endDay = Math.Min(startDay + 6, daysInMonth);
                cb.Items.Add($"Week {weekNumber} ({startDay}–{endDay})");
                startDay += 7;
                weekNumber++;
            }
        }


        private void PopulateMonths(ComboBox cb)
        {
            cb.Items.AddRange(new object[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            });
        }

        private void PopulateYears(ComboBox cb)
        {
            int currentYear = DateTime.Now.Year;
            for (int i = 0; i < 5; i++)
            {
                cb.Items.Add((currentYear - i).ToString());
            }
        }

        private void cbTimeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string selected = cb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return;
            cbDateFilter.Items.Clear();

            if (selected == "Daily")
                PopulateDaysOfMonth(cbDateFilter);
            else if (selected == "Weekly")
                PopulateWeeks(cbDateFilter);
            else if (selected == "Monthly")
                PopulateMonths(cbDateFilter);
            else if (selected == "Yearly")
                PopulateYears(cbDateFilter);
        }
        private string GetXAxisName()
        {
            switch (cbTimeRange.SelectedItem?.ToString())
            {
                case "Daily": return "Day";
                case "Weekly": return "Week";
                case "Monthly": return "Month";
                case "Yearly": return "Year";
                default: return "Time";
            }
        }

        private Panel CreateSummaryCard(string title, string value, string change, Color changeColor)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(5)
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 60, 50),
                Dock = DockStyle.Top,
                Height = 18
            };

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 70, 60),
                Dock = DockStyle.Top,
                Height = 24
            };

            var changeLabel = new Label
            {
                Text = change,
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                ForeColor = changeColor,
                Dock = DockStyle.Top,
                Height = 16
            };

            panel.Controls.Add(changeLabel);
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(titleLabel);
            return panel;
        }

        private CartesianChart salesCharts;
        public class SalesSummary
        {
            public double GrossSales { get; set; }
            public double Refunds { get; set; }
            public double Discounts { get; set; }
            public double NetSales { get; set; }
            public double GrossProfits { get; set; }

            public double[] DailySales { get; set; } = new double[0]; // Chart data
            public string[] Dates { get; set; } = new string[0]; // Chart labels
        }
        private SalesSummary GetSalesData()
        {
            // TODO: Replace this with database logic
            return new SalesSummary
            {
                GrossSales = 287,
                Refunds = 0,
                Discounts = 145,
                NetSales = 20000,
                GrossProfits = 145,
                DailySales = new double[] { 10, 15, 40, 30 },
                Dates = new string[] { "June 1", "June 2", "June 3", "June 4" }
            };
        }
        private void ShowSalesSummaryChart()
        {
            chartContainer.Controls.Clear();
            var sales = GetSalesData();
            var stackedPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.White
            };

            // Create summary panel
            var summaryPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 80,
                ColumnCount = 5,
                RowCount = 1,
                BackColor = Color.White
            };

            for (int i = 0; i < 5; i++)
                summaryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));


            // Add summary items (you can fetch these from your database later)
            summaryPanel.Controls.Add(CreateSummaryCard("Gross Sales", $"₱{sales.GrossSales:0.00}", "+₱287.00 (+100%)", Color.ForestGreen), 0, 0);
            summaryPanel.Controls.Add(CreateSummaryCard("Refunds", $"₱{sales.Refunds:0.00}", "₱0.00", Color.Gray), 1, 0);
            summaryPanel.Controls.Add(CreateSummaryCard("Discounts", $"₱{sales.Discounts:0.00}", "-₱500.00", Color.Red), 2, 0);
            summaryPanel.Controls.Add(CreateSummaryCard("Net Sales", $"₱{sales.NetSales:0,0.00}", "+₱20,000.00", Color.ForestGreen), 3, 0);
            summaryPanel.Controls.Add(CreateSummaryCard("Gross Profits", $"₱{sales.GrossProfits:0.00}", "-₱500.00", Color.Red), 4, 0);

            // TODO: Replace this with actual sales data from the database
            var salesValues = new List<double> { 10, 15, 40, 30 };
            var dateLabels = new List<string> { "June 1", "June 2", "June 3", "June 4" };

            var lineChart = new CartesianChart
            {
                BackColor = Color.White, // WinForms Control background
                DrawMarginFrame = new DrawMarginFrame
                {
                    Stroke = new SolidColorPaint(SKColors.LightGray, 2),
                    Fill = new SolidColorPaint(SKColors.White)
                },
                Margin = new Padding(30),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Left,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = salesValues,
                        Name = "Sales",
                        Stroke = new SolidColorPaint(SKColor.Parse("4E2D18"),3),
                        GeometrySize = 10,
                        GeometryStroke = new SolidColorPaint(SKColor.Parse("4E2D18"), 2),
                        Fill = new SolidColorPaint(SKColor.Parse("D5C8B0"), 0.5f) // Semi-transparent fill
                    }
                },


                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = GetXAxisName(),
                        Labels = dateLabels.ToArray(),
                        NamePaint = new SolidColorPaint(SKColor.Parse("4E2D18")),
                        LabelsPaint = new SolidColorPaint(SKColor.Parse("4E2D18")),
                        TextSize = 16
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Amount",
                        NamePaint = new SolidColorPaint(SKColor.Parse("4E2D18")),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                        TextSize = 14
                    }
                }
            };
            stackedPanel.Controls.Add(lineChart);
            stackedPanel.Controls.Add(summaryPanel);
            chartContainer.Controls.Add(stackedPanel);
        }


        private void ShowSalesByProductChart()
        {
            chartContainer.Controls.Clear();

            // TODO: Replace this with actual sales by product data from the database
            var productSales = new Dictionary<string, double>
            {
                { "Americano", 50 },
                { "Matcha Latte", 30 },
                { "Mocha", 20 }
            };

            var legendPaint = new SolidColorPaint
            {
                Color = SKColors.Black,
            };

            var pieSeries = productSales.Select(ps => new PieSeries<double>
            {
                Values = new double[] { ps.Value },
                Name = ps.Key,
                //Fill = new SolidColorPaint(SKColor.Parse("#" + GetColorHexForProduct(ps.Key))),
                DataLabelsFormatter = point => $"{ps.Key}: {point.Model}",
                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle
            }).ToArray();

            var pieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = pieSeries,
                Name = "Sales by Product",
                BackColor = Color.White, // Set the background color of the chart container
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Left,
                LegendTextPaint = legendPaint
            };
            pieChart.LegendTextSize = 16;

            chartContainer.Controls.Add(pieChart);
        }

        private void ShowSalesByCategoryChart()
        {
            chartContainer.Controls.Clear();

            // TODO: Replace this with actual category sales data from the database
            var categoryLabels = new List<string> { "Coffee", "Non-Coffee", "Food" };
            var categorySales = new List<double> { 25, 45, 30 };

            var columnChart = new CartesianChart
            {
                BackColor = Color.White, // WinForms Control background
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Values = categorySales,
                        Name = "Categories",
                        Fill = new SolidColorPaint(SKColor.Parse("4E2D18"), 2),
                    }
                },
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = categoryLabels.ToArray(),
                        Name="Category",
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Amount"
                    }
                }
            };

            chartContainer.Controls.Add(columnChart);
        }



        private void MakeRoundedPanel(Panel panel, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top left corner
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90); // Top right
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90); // Bottom right
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90); // Bottom left
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTimeRange.Enabled = comboBox1.SelectedIndex >= 0;
            cbTimeRange.SelectedIndex = -1;

            cbDateFilter.Enabled = false;
            cbDateFilter.Items.Clear();
            cbDateFilter.SelectedIndex = -1;

            btnGenerateChart.Enabled = false;
        }

        private void CbTimeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimeRange.SelectedIndex >= 0)
            {
                cbDateFilter.Enabled = true;
                cbDateFilter.Items.Clear();
                cbDateFilter.SelectedIndex = -1;

                string selected = cbTimeRange.SelectedItem.ToString();
                if (selected == "Daily")
                    PopulateDaysOfMonth(cbDateFilter);
                else if (selected == "Weekly")
                    PopulateWeeks(cbDateFilter);
                else if (selected == "Monthly")
                    PopulateMonths(cbDateFilter);
                else if (selected == "Yearly")
                    PopulateYears(cbDateFilter);
            }

            btnGenerateChart.Enabled = false;
        }

        private void ComboBoxDependenciesChanged(object sender, EventArgs e)
        {
            btnGenerateChart.Enabled =
                comboBox1.SelectedIndex >= 0 &&
                cbTimeRange.SelectedIndex >= 0 &&
                cbDateFilter.SelectedIndex >= 0;
        }
        private void btnGenerateChart_Click(object sender, EventArgs e)
        {
            string chartType = comboBox1.SelectedItem?.ToString();

            switch (chartType)
            {
                case "Sales Summary":
                    ShowSalesSummaryChart();
                    break;
                case "Sales by Product":
                    ShowSalesByProductChart();
                    break;
                case "Sales by Category":
                    ShowSalesByCategoryChart();
                    break;
            }
        }

        private void DashboardAdmin_Load_1(object sender, EventArgs e)
        {

        }

        private void chartContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
