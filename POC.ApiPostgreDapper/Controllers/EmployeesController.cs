using Microsoft.AspNetCore.Mvc;
using POC.ApiPostgreDapper.Entities;
using POC.ApiPostgreDapper.Services;

namespace POC.ApiPostgreDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.Get(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            IEnumerable<Employee> employees = await _employeeService.GetList();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            bool result = await _employeeService.Create(employee);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            Employee result = await _employeeService.Update(employee);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _employeeService.Delete(id);

            return Ok(result);
        }
    }
}
