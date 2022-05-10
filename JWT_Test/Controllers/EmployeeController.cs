using JWT_Test.Models;
using JWT_Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT_Test.Controllers
{
    [Authorize]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _IEmployee;

        public EmployeeController(IEmployeeInterface IEmployee)
        {
            _IEmployee = IEmployee;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await Task.FromResult(_IEmployee.GetEmployees());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employees = await Task.FromResult(_IEmployee.GetEmployee(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _IEmployee.AddEmployee(employee);
            return await Task.FromResult(employee);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            try
            {
                _IEmployee.EditEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(employee);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IEmployee.DeleteEmployee(id);

            return Ok();
        }

        private bool EmployeeExists(int id)
        {
            var employee = _IEmployee.GetEmployee(id);
            if (employee == null)
            {
                return false;
            }
            return true;
        }
    }
}
