using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_WebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Address { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Area { get; set; }

        [Column(TypeName = "varchar(50)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? Contact { get; set; }

    }
}
