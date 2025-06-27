using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.TicketFolder.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int EmployeeID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string DiscountType { get; set; } // e.g., "Senior", "PWD", "Regular"  
        public int TransactionNo { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Change { get; set; }
        public decimal DiscountRate { get; set; }
        public string PaymentType { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public decimal CashAmount { get; set; }
        public decimal GcashAmount { get; set; }
        public decimal MayaAmount { get; set; }
        public decimal SubTotal { get; set; }
        public string EmployeeName { get; set; }
        public decimal UnitPrice { get; set; } // This will be calculated based on ProductID, Size, and Type
    }
}
