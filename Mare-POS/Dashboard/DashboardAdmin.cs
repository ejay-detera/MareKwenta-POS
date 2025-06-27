using CuoreUI.Controls;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Mare_POS.Dashboard;
using MySql.Data.MySqlClient;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class DashboardAdmin : UserControl
    {
        private string connectionString;

        public DashboardAdmin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? "Server=localhost;Database=marepos-db;Uid=root;Pwd=ejaydetera12;";
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

        private SalesSummary GetSalesDataFromDB()
        {
            try
            {
                string timeRange = cbTimeRange.SelectedItem?.ToString() ?? "Daily";
                string dateFilter = cbDateFilter.SelectedItem?.ToString() ?? DateTime.Now.ToString("MMMM d, yyyy");

                // Use the new enhanced sales data processor
                var processor = new SalesDataProcessor(connectionString);
                processor.ApplyFilter(timeRange, dateFilter);

                return processor.ProcessData() as SalesSummary;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sales data: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new SalesSummary(); // Return empty summary on error
            }
        }

        // New method to get aggregated sales data for all months/years
        private Dictionary<string, double> GetAggregatedSalesData(string timeRange)
        {
            var salesData = new Dictionary<string, double>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "";

                    if (timeRange == "Monthly")
                    {
                        // Get sales data grouped by month for current year
                        query = @"
                            SELECT 
                                MONTHNAME(Date) as Period,
                                MONTH(Date) as MonthNum,
                                SUM(TotalAmount) as TotalSales
                            FROM ticket 
                            WHERE YEAR(Date) = YEAR(CURDATE())
                            GROUP BY YEAR(Date), MONTH(Date), MONTHNAME(Date)
                            ORDER BY MonthNum";
                    }
                    else if (timeRange == "Yearly")
                    {
                        // Get sales data grouped by year
                        query = @"
                            SELECT 
                                YEAR(Date) as Period,
                                SUM(TotalAmount) as TotalSales
                            FROM ticket 
                            GROUP BY YEAR(Date)
                            ORDER BY YEAR(Date)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string period = reader["Period"].ToString();
                                double totalSales = Convert.ToDouble(reader["TotalSales"]);
                                salesData[period] = totalSales;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching aggregated sales data: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return salesData;
        }

        private void GetDateRange(out DateTime startDate, out DateTime endDate)
        {
            string timeRange = cbTimeRange.SelectedItem?.ToString();
            string dateFilter = cbDateFilter.SelectedItem?.ToString();

            var now = DateTime.Now;
            startDate = now.Date;
            endDate = now.Date.AddDays(1).AddSeconds(-1);

            switch (timeRange)
            {
                case "Daily":
                    if (DateTime.TryParse(dateFilter, out DateTime selectedDate))
                    {
                        startDate = selectedDate.Date;
                        endDate = selectedDate.Date.AddDays(1).AddSeconds(-1);
                    }
                    break;

                case "Weekly":
                    // Extract week number from selection like "Week 1 (1–7)"
                    if (dateFilter.Contains("Week"))
                    {
                        var weekMatch = System.Text.RegularExpressions.Regex.Match(dateFilter, @"Week (\d+) \((\d+)–(\d+)\)");
                        if (weekMatch.Success)
                        {
                            int startDay = int.Parse(weekMatch.Groups[2].Value);
                            int endDay = int.Parse(weekMatch.Groups[3].Value);
                            startDate = new DateTime(now.Year, now.Month, startDay);
                            endDate = new DateTime(now.Year, now.Month, endDay, 23, 59, 59);
                        }
                    }
                    break;

                case "Monthly":
                    int monthIndex = Array.IndexOf(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }, dateFilter);
                    if (monthIndex >= 0)
                    {
                        startDate = new DateTime(now.Year, monthIndex + 1, 1);
                        endDate = startDate.AddMonths(1).AddSeconds(-1);
                    }
                    break;

                case "Yearly":
                    if (int.TryParse(dateFilter, out int year))
                    {
                        startDate = new DateTime(year, 1, 1);
                        endDate = new DateTime(year, 12, 31, 23, 59, 59);
                    }
                    break;
            }
        }

        private Dictionary<string, int> GetProductSalesFromDB()
        {
            var productSales = new Dictionary<string, int>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string timeRange = cbTimeRange.SelectedItem?.ToString();
                    string query = "";

                    if ((timeRange == "Monthly" || timeRange == "Yearly") && cbDateFilter.SelectedIndex == -1)
                    {
                        // Get all products for the entire time range
                        if (timeRange == "Monthly")
                        {
                            query = @"
                                SELECT 
                                    p.ProductName,
                                    SUM(t.ProductQuantity) as TotalQuantity
                                FROM ticket t
                                INNER JOIN product p ON t.ProductID = p.ProductID
                                WHERE YEAR(t.Date) = YEAR(CURDATE())
                                GROUP BY t.ProductID, p.ProductName";
                        }
                        else // Yearly
                        {
                            query = @"
                                SELECT 
                                    p.ProductName,
                                    SUM(t.ProductQuantity) as TotalQuantity
                                FROM ticket t
                                INNER JOIN product p ON t.ProductID = p.ProductID
                                GROUP BY t.ProductID, p.ProductName";
                        }

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string productName = reader["ProductName"].ToString();
                                    int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                                    productSales[productName] = totalQuantity;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Use existing date range method for specific dates
                        DateTime startDate, endDate;
                        GetDateRange(out startDate, out endDate);

                        query = @"
                            SELECT 
                                p.ProductName,
                                SUM(t.ProductQuantity) as TotalQuantity
                            FROM ticket t
                            INNER JOIN product p ON t.ProductID = p.ProductID
                            WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                            GROUP BY t.ProductID, p.ProductName";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StartDate", startDate);
                            cmd.Parameters.AddWithValue("@EndDate", endDate);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string productName = reader["ProductName"].ToString();
                                    int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                                    productSales[productName] = totalQuantity;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product sales data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return productSales;
        }

        private Dictionary<string, double> GetCategorySalesFromDB()
        {
            var categorySales = new Dictionary<string, double>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string timeRange = cbTimeRange.SelectedItem?.ToString();
                    string query = "";

                    if ((timeRange == "Monthly" || timeRange == "Yearly") && cbDateFilter.SelectedIndex == -1)
                    {
                        // Get all categories for the entire time range
                        if (timeRange == "Monthly")
                        {
                            query = @"
                                SELECT 
                                    t.Category,
                                    SUM(t.TotalAmount) as TotalSales
                                FROM ticket t
                                WHERE YEAR(t.Date) = YEAR(CURDATE())
                                AND t.Category IS NOT NULL AND t.Category != ''
                                GROUP BY t.Category
                                ORDER BY TotalSales DESC";
                        }
                        else // Yearly
                        {
                            query = @"
                                SELECT 
                                    t.Category,
                                    SUM(t.TotalAmount) as TotalSales
                                FROM ticket t
                                WHERE t.Category IS NOT NULL AND t.Category != ''
                                GROUP BY t.Category
                                ORDER BY TotalSales DESC";
                        }

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string category = reader["Category"].ToString();
                                    double sales = Convert.ToDouble(reader["TotalSales"]);
                                    categorySales[category] = sales;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Use existing date range method for specific dates
                        DateTime startDate, endDate;
                        GetDateRange(out startDate, out endDate);

                        query = @"
                            SELECT 
                                t.Category,
                                SUM(t.TotalAmount) as TotalSales
                            FROM ticket t
                            WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                            AND t.Category IS NOT NULL AND t.Category != ''
                            GROUP BY t.Category
                            ORDER BY TotalSales DESC";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StartDate", startDate);
                            cmd.Parameters.AddWithValue("@EndDate", endDate);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string category = reader["Category"].ToString();
                                    double sales = Convert.ToDouble(reader["TotalSales"]);
                                    categorySales[category] = sales;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching category sales data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return categorySales;
        }

        private void ShowSalesSummaryChart()
        {
            chartContainer.Controls.Clear();

            try
            {
                string timeRange = cbTimeRange.SelectedItem?.ToString();

                // Check if we should show aggregated data (Monthly/Yearly without specific date filter)
                if ((timeRange == "Monthly" || timeRange == "Yearly") && cbDateFilter.SelectedIndex == -1)
                {
                    ShowAggregatedSalesSummaryChart(timeRange);
                    return;
                }

                var salesData = GetSalesDataFromDB();

                var stackedPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10),
                    BackColor = Color.White
                };

                // Create enhanced summary panel with calculated values
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

                // Add summary cards with properly calculated values
                summaryPanel.Controls.Add(CreateSummaryCard(
                    "Gross Sales",
                    $"₱{salesData.GrossSales:N2}",
                    $"+₱{salesData.GrossSales:N2}",
                    Color.ForestGreen), 0, 0);

                summaryPanel.Controls.Add(CreateSummaryCard(
                    "Refunds",
                    $"₱{salesData.TotalRefunds:N2}",
                    $"-₱{salesData.TotalRefunds:N2}",
                    Color.Red), 1, 0);

                summaryPanel.Controls.Add(CreateSummaryCard(
                    "Discounts",
                    $"₱{salesData.TotalDiscounts:N2}",
                    $"-₱{salesData.TotalDiscounts:N2}",
                    Color.Orange), 2, 0);

                summaryPanel.Controls.Add(CreateSummaryCard(
                    "Net Sales",
                    $"₱{salesData.NetSales:N2}",
                    $"+₱{salesData.NetSales:N2}",
                    salesData.NetSales >= 0 ? Color.ForestGreen : Color.Red), 3, 0);

                summaryPanel.Controls.Add(CreateSummaryCard(
                    "Gross Profit",
                    $"₱{salesData.GrossProfit:N2}",
                    $"+₱{salesData.GrossProfit:N2}",
                    salesData.GrossProfit >= 0 ? Color.ForestGreen : Color.Red), 4, 0);

                // Create the line chart with enhanced data
                var lineChart = new CartesianChart
                {
                    BackColor = Color.White,
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
                            Values = salesData.ChartValues,
                            Name = "Sales Trend",
                            Stroke = new SolidColorPaint(SKColor.Parse("#4E2D18"), 3),
                            GeometrySize = 10,
                            GeometryStroke = new SolidColorPaint(SKColor.Parse("#4E2D18"), 2),
                            Fill = new SolidColorPaint(SKColor.Parse("#D5C8B0")) { Color = SKColor.Parse("#D5C8B0").WithAlpha(127) }
                        }
                    },
                    XAxes = new Axis[]
                    {
                        new Axis
                        {
                            Name = GetXAxisName(),
                            Labels = salesData.ChartLabels,
                            NamePaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                            LabelsPaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                            TextSize = 14
                        }
                    },
                    YAxes = new Axis[]
                    {
                        new Axis
                        {
                            Name = "Sales Amount (₱)",
                            NamePaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                            LabelsPaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                            TextSize = 12,
                            Labeler = value => $"₱{value:N0}"
                        }
                    }
                };

                stackedPanel.Controls.Add(lineChart);
                stackedPanel.Controls.Add(summaryPanel);
                chartContainer.Controls.Add(stackedPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying sales summary: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAggregatedSalesSummaryChart(string timeRange)
        {
            var salesData = GetAggregatedSalesData(timeRange);

            if (salesData.Count == 0)
            {
                MessageBox.Show($"No sales data found for {timeRange.ToLower()} view.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var stackedPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.White
            };

            // Calculate totals for summary cards
            double totalSales = salesData.Values.Sum();
            var periods = salesData.Keys.ToArray();
            var values = salesData.Values.ToArray();

            // Create summary panel
            var summaryPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 80,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.White
            };

            for (int i = 0; i < 3; i++)
                summaryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

            summaryPanel.Controls.Add(CreateSummaryCard(
                $"Total {timeRange} Sales",
                $"₱{totalSales:N2}",
                $"{periods.Length} {(timeRange == "Monthly" ? "months" : "years")} with data",
                Color.ForestGreen), 0, 0);

            summaryPanel.Controls.Add(CreateSummaryCard(
                $"Average {timeRange.Substring(0, timeRange.Length - 2)} Sales",
                $"₱{(totalSales / periods.Length):N2}",
                $"Across {periods.Length} periods",
                Color.DodgerBlue), 1, 0);

            summaryPanel.Controls.Add(CreateSummaryCard(
                $"Best {timeRange.Substring(0, timeRange.Length - 2)}",
                periods.Length > 0 ? periods[Array.IndexOf(values, values.Max())] : "N/A",
                $"₱{values.Max():N2}",
                Color.Gold), 2, 0);

            // Create the line chart
            var lineChart = new CartesianChart
            {
                BackColor = Color.White,
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
                        Values = values,
                        Name = $"{timeRange} Sales",
                        Stroke = new SolidColorPaint(SKColor.Parse("#4E2D18"), 3),
                        GeometrySize = 10,
                        GeometryStroke = new SolidColorPaint(SKColor.Parse("#4E2D18"), 2),
                        Fill = new SolidColorPaint(SKColor.Parse("#D5C8B0")) { Color = SKColor.Parse("#D5C8B0").WithAlpha(127) }
                    }
                },
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = GetXAxisName(),
                        Labels = periods,
                        NamePaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                        LabelsPaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                        TextSize = 14
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Sales Amount (₱)",
                        NamePaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                        LabelsPaint = new SolidColorPaint(SKColor.Parse("#4E2D18")),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 },
                        TextSize = 12,
                        Labeler = value => $"₱{value:N0}"
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

            var productSales = GetProductSalesFromDB();

            if (productSales.Count == 0)
            {
                MessageBox.Show("No product sales data found for the selected period.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var legendPaint = new SolidColorPaint
            {
                Color = SKColors.Black,
            };

            var pieSeries = productSales.Select(ps => new PieSeries<double>
            {
                Values = new double[] { ps.Value },
                Name = ps.Key,
                DataLabelsFormatter = point => $"{ps.Key}: {ps.Value} units",
                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle
            }).ToArray();

            var pieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = pieSeries,
                Name = "Sales by Product",
                BackColor = Color.White,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Left,
                LegendTextPaint = legendPaint
            };
            pieChart.LegendTextSize = 16;

            chartContainer.Controls.Add(pieChart);
        }

        private void ShowSalesByCategoryChart()
        {
            chartContainer.Controls.Clear();

            var categoryData = GetCategorySalesFromDB();

            if (categoryData.Count == 0)
            {
                MessageBox.Show("No category sales data found for the selected period.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var categoryLabels = categoryData.Keys.ToList();
            var categorySales = categoryData.Values.ToList();

            var columnChart = new CartesianChart
            {
                BackColor = Color.White,
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
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
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

            cbDateFilter.Enabled = true;
            cbDateFilter.Items.Clear();
            cbDateFilter.SelectedIndex = -1;

            btnGenerateChart.Enabled = true;
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

            btnGenerateChart.Enabled = true;
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