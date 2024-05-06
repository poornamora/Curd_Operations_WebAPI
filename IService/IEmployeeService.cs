using EF_Core_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_WebApi.IService
{
    public interface IEmployeeService
    {
        Task<ActionResult<IEnumerable<Employee>>> GetEmployeList();

        Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq();

        Task<ActionResult<Employee>> GetEmployeeByID(int id);

        Task<ActionResult<Employee>> PostEmployee(Employee employee);

        Task<ActionResult<Employee>> UpdateEmployees(int id, Employee employee);
        Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq2();

    }
}
