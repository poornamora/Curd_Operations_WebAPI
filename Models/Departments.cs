using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_WebApi.Models
{
    [Table("Departments")]
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string  DepartmentName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string SubDepartment {  get; set; }

        public virtual Employee Employee {  get; set; }     
    }
}
