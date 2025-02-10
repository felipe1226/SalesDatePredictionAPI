using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Employees.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Employees.DTO;
using SalesDatePredictionAPI.Modules.Employees.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Employees.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly JsonResponse _jsonResponse = JsonResponse.Instance;
        private readonly IEmployeesDomain _employeesDomain;

        public EmployeesServices(IEmployeesDomain employeesDomain)
        {
            _employeesDomain = employeesDomain;
        }

        public ActionResult<IEnumerable<EmployeeDTO>> getAllEmployees()
        {
            try
            {
                IEnumerable<EmployeeDTO> employees = _employeesDomain.getAllEmployees();

                if (employees is null)
                    return _jsonResponse.badResponse<IEnumerable<EmployeeDTO>>();

                if (!employees.Any())
                    return _jsonResponse.successResponse(employees, "No se obtuvo resultados");

                return _jsonResponse.successResponse(employees);
            }
            catch (Exception e)
            {
                return _jsonResponse.errorResponse<IEnumerable<EmployeeDTO>>(e.Message);
            }
        }
    }
}
