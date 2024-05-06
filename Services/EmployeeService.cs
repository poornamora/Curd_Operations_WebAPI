using EF_Core_WebApi.DatabaseContext;
using EF_Core_WebApi.IService;
using EF_Core_WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_WebApi.Services
{
    public class EmployeeService : IEmployeeService
    {

        public readonly ApplicationDbContext _dbcontext;

        public EmployeeService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {
            var result = await _dbcontext.Employeeinfo.FindAsync(id);
            return result;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq()
        {
            var result = await _dbcontext.Employeeinfo.ToListAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeList()
        {
            var result = await _dbcontext.Employeeinfo.ToListAsync();
            return result;
        }

        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (employee != null)
            {
                var result = await _dbcontext.Employeeinfo.AddAsync(employee);
                await _dbcontext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<ActionResult<Employee>> UpdateEmployees(int id, Employee employee)
        {
            _dbcontext.Entry(employee).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return employee;
        }
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq2()
        {
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
            var resultquery = (from e in _dbcontext.Employeeinfo
                               join d in _dbcontext.Departmentinfo on e.EmployeeId equals d.Employee.EmployeeId
                               select new Employee
                               {
                                   EmployeeId = e.EmployeeId,
                                   Name = e.Name,
                                   Area = e.Area,
                                   Contact = e.Contact,
                                   Address = e.Address,
                               }).ToList();

            return resultquery;
            // }
        }

        //        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeList();
        //        {
        //            var result = await _dbcontext.Employeeinfo.ToListAsync();
        //            return result;
        //        }

        //        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq();
        //        {
        //            var result = await _dbcontext.Addressinfo.ToListAsync();
        //            return result;
        //        }

        //        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        //{
        //            var result = await _dbcontext.Addressinfo.FindAsync(id);
        //            return result;
        //        }

        //        public async Task<ActionResult<Employee>> PostEmployee(Employee employee);
        //{
        //            if(employee != null)
        //            {
        //                var result=await _dbcontext. .AddAsync(employee);
        //                await _dbcontext.SaveChangesAsync();
        //                return result.Entity;
        //            }
        //            return null;
        //        }

        //        public async Task<ActionResult<Employee>> UpdateEmployees(int id, Employee employee);
        //{
        //            _dbcontext.Entry(employee).State = EntityState.Modified;
        //            await _dbcontext.SaveChangesAsync();
        //            return address;
        //        }


    }
}
