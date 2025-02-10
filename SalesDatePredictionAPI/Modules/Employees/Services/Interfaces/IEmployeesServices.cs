using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Employees.DTO;

namespace SalesDatePredictionAPI.Modules.Employees.Services.Interfaces
{
    public interface IEmployeesServices
    {
        ActionResult<IEnumerable<EmployeeDTO>> getAllEmployees();
    }
}
