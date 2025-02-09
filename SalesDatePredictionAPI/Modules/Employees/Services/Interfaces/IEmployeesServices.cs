using SalesDatePredictionAPI.Modules.Employees.DTO;

namespace SalesDatePredictionAPI.Modules.Employees.Services.Interfaces
{
    public interface IEmployeesServices
    {
        IEnumerable<EmployeeDTO> getAllEmployees();
    }
}
