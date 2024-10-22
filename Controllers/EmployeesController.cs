using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityOffice.Dtos;
using SecurityOffice.Models;

namespace SecurityOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            List<Employee> employeesList = _context.Employees.ToList();
            return Ok(employeesList);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            Employee employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound($"No employee was found with ID: {id}");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
    }
}
