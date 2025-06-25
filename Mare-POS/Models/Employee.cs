using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string Role { get; set; }        
        public string Password { get; set; }
        public string Username { get; set; }
        public int OwnerID { get; set; }       
    }
}
