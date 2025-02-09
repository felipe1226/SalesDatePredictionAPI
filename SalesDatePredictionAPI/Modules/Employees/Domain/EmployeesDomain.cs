using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Employees.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Employees.DTO;
using System.Data;

namespace SalesDatePredictionAPI.Modules.Employees.Domain
{
    public class EmployeesDomain : IEmployeesDomain
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance;

        public IEnumerable<EmployeeDTO> getAllEmployees()
        {
            using (SqlConnection connection = new(_dbConnection.getConnectionString()))
            {
                SqlCommand command = new()
                {
                    Connection = connection,
                    CommandText = "HR.PA_GetAllEmployees",
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<EmployeeDTO> employees = new();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeDTO
                            {
                                EmpID = Convert.ToInt32(reader[0].ToString()),
                                FullName = reader[1].ToString()
                            });
                        }
                    }
                    reader.Close();

                    return employees.ToList();
                }
            }
        }
    }
}
