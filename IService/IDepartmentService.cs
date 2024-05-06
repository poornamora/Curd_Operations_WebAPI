using EF_Core_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_WebApi.IService
{
    public interface IDepartmentService
    {
        Task<ActionResult<IEnumerable<Departments>>> GetDepartmentList();

        //Task<ActionResult<IEnumerable<Departments>>> GetDepartmentListbyLinq();

        //Task<ActionResult<Departments>> GetDepartmentByID(int? id);

        Task<ActionResult<Departments>> PostDepartment(Departments department);

        Task<ActionResult<Departments>> UpdateDepartment(int id, Departments department);
    }
}
