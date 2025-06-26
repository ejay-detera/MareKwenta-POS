using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.Models
{
    public class product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal GrandeHotPrice { get; set; }
        public decimal VentiHotPrice { get; set; }
        public decimal GrandeIcedPrice { get; set; }
        public decimal VentiIcedPrice { get; set; }
    }
}
