using EF_Core_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_WebApi.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }


        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Employee> Employeeinfo {  get; set; }

        public virtual DbSet<Departments> Departmentinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
