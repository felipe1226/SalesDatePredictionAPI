using SalesDatePredictionAPI.Modules.Employees.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Employees.DTO;
using SalesDatePredictionAPI.Modules.Employees.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Employees.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IEmployeesDomain _employeesDomain;

        public EmployeesServices(IEmployeesDomain employeesDomain)
        {
            _employeesDomain = employeesDomain;
        }


        public IEnumerable<EmployeeDTO> getAllEmployees()
        {
            try
            {
                IEnumerable<EmployeeDTO> employees = _employeesDomain.getAllEmployees();

                if (employees is null || !employees.Any())
                    return null;

                return employees;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
