using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.Models
{
    public class employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int OwnerID { get; set; }
    }
}
