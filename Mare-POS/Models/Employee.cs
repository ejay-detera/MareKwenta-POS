using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mare_POS.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string Role { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }

        // Foreign Key
        [ForeignKey("Owner")]
        public int OwnerID { get; set; }

        // Navigation Property
        public virtual Employee? Owner { get; set; }

        public virtual ICollection<Employee> OwnedEmployees { get; set; } = new List<Employee>();
    }
}