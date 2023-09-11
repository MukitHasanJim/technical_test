using AspNetCoreWebApi6.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDBContext _dbContext;

        public EmployeeController(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_dbContext.Employees == null)
            {
                return NotFound();
            }
            return await _dbContext.Employees.ToListAsync();
        }

        //API01# Update an employee’s Employee Name and Code [Don't allow duplicate employee code]
        [HttpPut("updateEmployeeDetails")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {

            if(employee.Id == 0) return BadRequest();

            try
            {
                var duplicateEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id != employee.Id && x.Code == employee.Code);

                if (duplicateEmployee != null) return BadRequest(new { message = "This employee code is already exist!" });


                var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

                if (existingEmployee == null) return BadRequest(new { message = "This employee does not exist!" });

                existingEmployee.Name = employee.Name;
                existingEmployee.Code = employee.Code;

                _dbContext.Employees.Update(existingEmployee);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        //API02# Get employee who has 3rd highest salary
        [HttpGet("getEmployeeWhoHasThirdHighestSalary")]
        public ActionResult<Employee> GetEmployeeWhoHasThirdHighestSalary()
        {
            var employee =  _dbContext.Employees.OrderByDescending(x => x.Salary).Skip(2).Take(1);
            return Ok(employee);
        }


    }
}
