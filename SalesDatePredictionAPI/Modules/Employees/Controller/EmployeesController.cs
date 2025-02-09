using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Employees.DTO;
using SalesDatePredictionAPI.Modules.Employees.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Employee.Controller
{
    [Route("employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesServices _employeesServices;

        public EmployeesController(IEmployeesServices employeesServices)
        {
            _employeesServices = employeesServices;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<EmployeeDTO>> getAllEmployees()
        {
            return _employeesServices.getAllEmployees();
        }

    }
}
