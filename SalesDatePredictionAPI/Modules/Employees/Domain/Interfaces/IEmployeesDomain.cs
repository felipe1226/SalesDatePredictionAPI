using SalesDatePredictionAPI.Modules.Employees.DTO;

namespace SalesDatePredictionAPI.Modules.Employees.Domain.Interfaces
{
    public interface IEmployeesDomain
    {
        IEnumerable<EmployeeDTO> getAllEmployees();
    }
}
