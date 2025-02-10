using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Infrastructure;
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
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "HR.PA_GetEmployees",
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
                                    empId = Convert.ToInt32(reader["empid"].ToString()),
                                    fullName = reader["fullname"].ToString()
                                });
                            }
                        }
                        reader.Close();

                        return employees.ToList();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
