using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.TicketFolder.Models
{
    public class Item
    {
        public int ProductID { get; set; }
        public int EmployeeID { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public string ProductType { get; set; }
        public List<string> Extras { get; set; } = new List<string>();
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Base price of the product
        public string Name { get; set; }
        public string Size { get; set; } // Grande, Venti, etc.
        public string Type { get; set; } // Hot, Cold, etc.
        public decimal Amount { get; set; }
        public string Category { get; set; } // Coffee, Food, etc.
    }
}