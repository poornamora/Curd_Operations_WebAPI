using EF_Core_WebApi.DatabaseContext;
using EF_Core_WebApi.IService;
using EF_Core_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EF_Core_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetails : ControllerBase
    {
        private readonly IEmployeeService _context;
        private readonly ApplicationDbContext _dbcontext;

        public EmployeeDetails(IEmployeeService context, ApplicationDbContext dbcontext)
        {
            _context = context;
            _dbcontext = dbcontext;
        }

        [HttpGet("EmployeeList")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeList()
        {
            if (_context == null)
            {
                return NotFound();
            }

            return await _context.GetEmployeList();
        }

        [HttpGet("EmployeeListLinq")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq()
        {

            return await _context.GetEmployeeListByLinq2();
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {
            try
            {
                if (_context == null)
                {
                    return NotFound();
                }

               
                var city = await _context.GetEmployeeByID(id);
                return city;
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
        }

        [HttpPost("AddEmployees")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                if (_context == null)
                {
                    return Problem("Entity Set of ApplicationContext.Employee is null");
                }

                await _context.PostEmployee(employee);
                CreatedAtAction("EmployeeList", new { id = employee.EmployeeId }, employee);
                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"ErrorSqlException: Cannot insert explicit value for identity column in table 'Employeeinfo' when IDENTITY_INSERT is set to OFF. Retrieving data from database");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployees(int id, Employee employee)
        {
            try
            {
                if (id == null)
                    return null;

                var updateemployees = await _context.UpdateEmployees(id, employee);

                if(updateemployees != null)
                {
                    return Ok(updateemployees);
                }
                return NotFound();
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("EmployeeListLinq3")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByLinq2()
        {
            return await _context.GetEmployeeListByLinq();
        }
    }
}
