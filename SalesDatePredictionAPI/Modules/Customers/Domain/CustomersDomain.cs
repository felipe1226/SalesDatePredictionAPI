using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Infrastructure;
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
                        CommandText = "Sales.PA_GetClientOrders",
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId });

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
                                    orderId = Convert.ToInt32(reader["orderid"].ToString()),
                                    requiredDate = DateTime.Parse(reader["requireddate"].ToString()).ToString("MM/dd/yyyy, hh:mm:ss tt"),
                                    shippedDate = reader["shippeddate"] is not null && reader["shippeddate"].ToString() != string.Empty 
                                        ? DateTime.Parse(reader["shippeddate"].ToString()).ToString("MM/dd/yyyy, hh:mm:ss tt")
                                        : null,
                                    shipName = reader["shipname"].ToString(),
                                    shipAddress = reader["shipaddress"].ToString(),
                                    shipCity = reader["shipcity"].ToString()
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
