using EmployeeListAPI.Data;
using EmployeeListAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        [HttpGet("GetCurrentEmployee")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetCurrentEmployee()
        {
            return await _employeeRepository.GetCurrentEmployees();
        }

        [HttpPost("InsertEmployee")]
        public async Task<ActionResult> InsertEmployee(Employee employee)
        {
            await _employeeRepository.InsertEmployee(employee);
            return Ok(new { message = "Employee created successfully" });
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.empId) return BadRequest("Mismatched ID.");
            await _employeeRepository.UpdateEmployee(employee);
            return Ok(new { message = "Employee updated successfully" });
        }

        [HttpPatch("RemoveCurrentEmployee/{id}")]
        public async Task<ActionResult> RemoveCurrentEmployee(int id)
        {
            await _employeeRepository.RemoveCurrentEmployee(id);
            return Ok(new { message = "Employee remove successfully" });
        }

        [HttpPatch("RetrieveEmployee/{id}")]
        public async Task<ActionResult> RetrieveEmployee(int id)
        {
            await _employeeRepository.RetrieveEmployee(id);
            return Ok(new { message = "Employee retrieved successfully" });
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok(new { message = "Employee deleted permanently" });
        }
    }
}
