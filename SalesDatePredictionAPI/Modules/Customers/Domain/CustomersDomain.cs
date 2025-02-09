using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Customers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;
using System.Data;

namespace SalesDatePredictionAPI.Modules.Customers.Domain
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance;

        public IEnumerable<OrderDTO> getOrders(int customerId)
        {
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "Sales.PA_GetCustomerOrders",
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add(new SqlParameter("@customerId", SqlDbType.Int) { Value = customerId });

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OrderDTO> orders = new();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                orders.Add(new OrderDTO
                                {
                                    OrderID = Convert.ToInt32(reader[0].ToString()),
                                    RequiredDate = DateTime.Parse(reader[1].ToString()),
                                    ShippedDate = DateTime.Parse(reader[2].ToString()),
                                    ShipName = reader[3].ToString(),
                                    ShipAddress = reader[4].ToString(),
                                    ShipCit = reader[5].ToString()
                                });
                            }
                        }
                        reader.Close();

                        return orders.ToList();
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
