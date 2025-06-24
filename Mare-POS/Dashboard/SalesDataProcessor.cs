using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Mare_POS.Dashboard
{
    // Base abstract class for all data processors
    public abstract class DataProcessor
    {
        protected string connectionString;
        protected DateTime startDate;
        protected DateTime endDate;

        public DataProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public abstract object ProcessData();

        protected abstract string GetQuery();

        public void SetDateRange(DateTime start, DateTime end)
        {
            startDate = start;
            endDate = end;
        }
    }

    // Interface for filterable data processors
    public interface IFilterable
    {
        void ApplyFilter(string timeRange, string dateFilter);
    }

    // Enhanced SalesSummary class
    public class SalesSummary
    {
        public double GrossSales { get; set; }
        public double TotalRefunds { get; set; }
        public double TotalDiscounts { get; set; }
        public double NetSales { get; set; }
        public double TotalCost { get; set; }
        public double GrossProfit { get; set; }
        public double[] ChartValues { get; set; } = new double[0];
        public string[] ChartLabels { get; set; } = new string[0];

        // Calculate derived values
        public void CalculateDerivedValues()
        {
            NetSales = GrossSales - TotalRefunds - TotalDiscounts;
            GrossProfit = NetSales - TotalCost;
        }
    }

    // Sales data processor implementing inheritance and polymorphism
    public class SalesDataProcessor : DataProcessor, IFilterable
    {
        private string timeRange;
        private string dateFilter;

        public SalesDataProcessor(string connectionString) : base(connectionString)
        {
        }

        public void ApplyFilter(string timeRange, string dateFilter)
        {
            this.timeRange = timeRange;
            this.dateFilter = dateFilter;
            SetDateRangeFromFilter();
        }

        public override object ProcessData()
        {
            var salesSummary = new SalesSummary();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get summary data
                    GetSummaryData(conn, salesSummary);

                    // Get chart data
                    GetChartData(conn, salesSummary);

                    // Calculate derived values
                    salesSummary.CalculateDerivedValues();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing sales data: {ex.Message}");
            }

            return salesSummary;
        }

        protected override string GetQuery()
        {
            // This method returns the chart query based on time range
            return GetChartQuery();
        }

        private void GetSummaryData(MySqlConnection conn, SalesSummary summary)
        {
            string summaryQuery = @"
                SELECT 
                    -- Gross Sales (sum of all TotalAmount)
                    SUM(t.TotalAmount) as GrossSales,
                    
                    SUM(t.TotalAmount * t.DiscountRate / 100) as TotalDiscounts,
                    
                    SUM(CASE 
                        WHEN t.Change > 0 AND t.PaymentAmount > t.TotalAmount 
                        THEN t.Change 
                        ELSE 0 
                    END) as TotalRefunds,
                    
                    SUM(p.UnitPrice * t.ProductQuantity) as TotalCost
                        
                FROM ticket t
                LEFT JOIN product p ON t.ProductID = p.ProductID
                WHERE t.Date >= @StartDate AND t.Date <= @EndDate";

            using (MySqlCommand cmd = new MySqlCommand(summaryQuery, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        summary.GrossSales = reader.IsDBNull("GrossSales") ? 0 : Convert.ToDouble(reader["GrossSales"]);
                        summary.TotalRefunds = reader.IsDBNull("TotalRefunds") ? 0 : Convert.ToDouble(reader["TotalRefunds"]);
                        summary.TotalDiscounts = reader.IsDBNull("TotalDiscounts") ? 0 : Convert.ToDouble(reader["TotalDiscounts"]);
                        summary.TotalCost = reader.IsDBNull("TotalCost") ? 0 : Convert.ToDouble(reader["TotalCost"]);
                    }
                }
            }
        }

        private void GetChartData(MySqlConnection conn, SalesSummary summary)
        {
            var salesValues = new List<double>();
            var dateLabels = new List<string>();

            string chartQuery = GetChartQuery();

            using (MySqlCommand cmd = new MySqlCommand(chartQuery, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salesValues.Add(reader.IsDBNull("SalesAmount") ? 0 : Convert.ToDouble(reader["SalesAmount"]));
                        dateLabels.Add(reader["Period"]?.ToString() ?? "");
                    }
                }
            }

            summary.ChartValues = salesValues.ToArray();
            summary.ChartLabels = dateLabels.ToArray();
        }

        private string GetChartQuery()
        {
            switch (timeRange)
            {
                case "Daily":
                    return @"
                        SELECT 
                            DATE_FORMAT(t.Date, '%m/%d/%Y') as Period,
                            SUM(t.TotalAmount) as SalesAmount
                        FROM ticket t
                        WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                        GROUP BY DATE(t.Date), DATE_FORMAT(t.Date, '%m/%d/%Y')
                        ORDER BY DATE(t.Date)";

                case "Weekly":
                    return @"
                        SELECT 
                            CONCAT('Week ', WEEK(t.Date, 1)) as Period,
                            SUM(t.TotalAmount) as SalesAmount
                        FROM ticket t
                        WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                        GROUP BY YEAR(t.Date), WEEK(t.Date, 1)
                        ORDER BY YEAR(t.Date), WEEK(t.Date, 1)";

                case "Monthly":
                    return @"
                        SELECT 
                            MONTHNAME(t.Date) as Period,
                            SUM(t.TotalAmount) as SalesAmount
                            FROM ticket t
                            WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                            GROUP BY YEAR(t.Date), MONTH(t.Date), MONTHNAME(t.Date)
                            ORDER BY YEAR(t.Date), MONTH(t.Date)";

                case "Yearly":
                    return @"
                        SELECT 
                            YEAR(t.Date) as Period,
                            SUM(t.TotalAmount) as SalesAmount
                        FROM ticket t
                        WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                        GROUP BY YEAR(t.Date)
                        ORDER BY YEAR(t.Date)";

                default:
                    return @"
                        SELECT 
                            DATE_FORMAT(t.Date, '%m/%d/%Y') as Period,
                            SUM(t.TotalAmount) as SalesAmount
                        FROM ticket t
                        WHERE t.Date >= @StartDate AND t.Date <= @EndDate
                        GROUP BY DATE(t.Date), DATE_FORMAT(t.Date, '%m/%d/%Y')
                        ORDER BY DATE(t.Date)";
            }
        }

        private void SetDateRangeFromFilter()
        {
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
                    string[] months = { "January", "February", "March", "April", "May", "June",
                                      "July", "August", "September", "October", "November", "December" };
                    int monthIndex = Array.IndexOf(months, dateFilter);
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
    }

    // Factory pattern for creating data processors
    public static class DataProcessorFactory
    {
        public static DataProcessor CreateProcessor(string type, string connectionString)
        {
            switch (type.ToLower())
            {
                case "sales":
                case "salessummary":
                    return new SalesDataProcessor(connectionString);
                default:
                    throw new ArgumentException($"Unknown processor type: {type}");
            }
        }
    }

    // Extension methods for the DashboardAdmin class
    public static class DashboardExtensions
    {
        public static SalesSummary GetEnhancedSalesData(this DashboardAdmin dashboard,
            string connectionString, string timeRange, string dateFilter)
        {
            var processor = DataProcessorFactory.CreateProcessor("sales", connectionString) as SalesDataProcessor;
            processor.ApplyFilter(timeRange, dateFilter);
            return processor.ProcessData() as SalesSummary;
        }
    }
}