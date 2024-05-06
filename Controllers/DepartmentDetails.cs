using EF_Core_WebApi.IService;
using EF_Core_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentDetails : Controller
    {
       
        private readonly IDepartmentService _departmentService;

        public DepartmentDetails(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("DepartmentList")]
        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        {
            if(_departmentService==null)
            {
                return NotFound();
            }
            return await _departmentService.GetDepartmentList();
        }

        //public async Task<ActionResult<Departments>> GetDepartmentById(int id)
        //{
        //    try
        //    {
        //        if(_departmentService==null)
        //        {
        //            return NotFound();  
        //        }
        //        var employee=await _departmentService.GetDepartmentByID(id);
        //        return employee;
        //    }
        //    catch(Exception)
        //    {
        //        Response.StatusCode = 404;
        //        return NotFound();
        //    }
        //}

        [HttpPost("AddDepartment")]
        public async Task<ActionResult<Departments>> PostDepartments(Departments departments)
        {
            try
            {
                if(_departmentService==null)
                {
                    return Problem("Entityset of ApplicationDbContext.Departments is null");
                }
                await _departmentService.PostDepartment(departments);
                CreatedAtAction("DepartmentList", new { id = departments.DepartmentId });
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
