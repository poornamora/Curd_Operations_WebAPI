using EF_Core_WebApi.DatabaseContext;
using EF_Core_WebApi.IService;
using EF_Core_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace EF_Core_WebApi.Services
{
    public class DepartmentServices : IDepartmentService
    {
        public readonly ApplicationDbContext _dbcontext;
        
        public DepartmentServices(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //public async Task<ActionResult<Departments>> GetDepartmentByID(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var result = await _dbcontext.Departmentinfo.FindAsync();
        //    if (result != null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        //    }
        //    return result;
        //}

        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartmentList()
        {
            var result = await _dbcontext.Departmentinfo.ToListAsync();
            return result;
        }


        //public async Task<ActionResult<IEnumerable<Departments>>> GetDepartmentListbyLinq()
        //{
        //    var result = await (from d in _dbcontext.Departmentinfo
        //                  join e in _dbcontext.Employeeinfo on d.Employee.EmployeeId equals e.EmployeeId
        //                  select new 
        //                  {
        //                      d.DepartmentId,
        //                      d.DepartmentName,
        //                      d.SubDepartment,
        //                      e.Name,
        //                      e.Area
        //                  }).ToListAsync();
        //    return result;
        //}

        public async Task<ActionResult<Departments>> PostDepartment(Departments department)
        {
            if(department!=null)
            {
                var result = await _dbcontext.Departmentinfo.AddAsync(department);
                await _dbcontext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<ActionResult<Departments>> UpdateDepartment(int id, Departments department)
        {
            _dbcontext.Entry(department).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return department;
        }
    }
}
