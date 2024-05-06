using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_WebApi.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Column(TypeName="varchar(20)")]
        public string? HouseNo { get; set; }

        [Column(TypeName="varchar(50)")]
        public string? Street { get; set; }

        [Column(TypeName="varchar(50)")]
        public string? Area { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? City { get; set; }

        [Column(TypeName="varchar(10)")]
        public string? Contact { get; set; }



    }
}
