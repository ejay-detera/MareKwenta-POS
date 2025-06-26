using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.Models
{
    public class Item
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public string ProductType { get; set; }
        public List<string> Extras { get; set; } = new List<string>();
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } // Coffee, Food, etc.
    }
}