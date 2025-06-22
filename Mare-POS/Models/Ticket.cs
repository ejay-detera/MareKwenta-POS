using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareKwenta.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int EmployeeID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Change { get; set; }
        public decimal DiscountRate { get; set; }
        public string? PaymentType { get; set; }
        public string? DiscountType { get; set; }
        public DateTime Date { get; set; }
        public required string Category { get; set; }
        public decimal CashAmount { get; set; }
        public decimal GcashAmount { get; set; }
        public decimal MayaAmount { get; set; }

        // Optional: You can include related data like product or employee names if needed for display
        public string ProductName { get; set; }       
        public string EmployeeName { get; set; }

    }

}
