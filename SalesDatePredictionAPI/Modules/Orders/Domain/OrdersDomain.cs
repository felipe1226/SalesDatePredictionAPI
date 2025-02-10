using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Infrastructure;
using SalesDatePredictionAPI.Modules.Orders.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;
using System.Data;

namespace SalesDatePredictionAPI.Modules.Orders.Domain
{
    public class OrdersDomain : IOrdersDomain
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance;

        public IEnumerable<SalesDatePredictionDTO> getSalesDatePredictions(OrderFiltersDTO filters)
        {
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "Sales.PA_SalesDatePrediction",
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40) { Value = filters.customerName }
                    });

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<SalesDatePredictionDTO> salesDatePredictions = new();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                salesDatePredictions.Add(new SalesDatePredictionDTO
                                {
                                    customerId = Convert.ToInt32(reader["CustomerId"].ToString()),
                                    customerName = reader["CustomerName"].ToString(),
                                    lastOrderDate = DateTime.Parse(reader["LastOrderDate"].ToString()).ToString("MM/dd/yyyy"),
                                    nextPredictedOrder = DateTime.Parse(reader["NextPredictedOrder"].ToString()).ToString("MM/dd/yyyy")
                                });
                            }
                        }
                        reader.Close();

                        return salesDatePredictions.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool addNewOrder(NewOrderDTO orderData)
        {
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "Sales.PA_AddNewOrder",
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", SqlDbType.Int) { Value = orderData.customerId },
                        new SqlParameter("@EmpId", SqlDbType.Int) { Value = orderData.empId },
                        new SqlParameter("@ShipperId", SqlDbType.Int) { Value = orderData.shipperId},
                        new SqlParameter("@ShipName", SqlDbType.NVarChar, 40) { Value = orderData.shipName },
                        new SqlParameter("@ShipAddress", SqlDbType.NVarChar, 60) { Value = orderData.shipAddress },
                        new SqlParameter("@ShipCity", SqlDbType.NVarChar, 15) { Value = orderData.shipCity },
                        new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = orderData.orderDate },
                        new SqlParameter("@RequiredDate", SqlDbType.DateTime) { Value = orderData.requiredDate },
                        new SqlParameter("@ShippedDate", SqlDbType.DateTime) { Value = orderData.shippedDate },
                        new SqlParameter("@Freight", SqlDbType.Decimal) { Value = orderData.freight },
                        new SqlParameter("@ShipCountry", SqlDbType.NVarChar, 15) { Value = orderData.shipCountry },
                        new SqlParameter("@ProductId", SqlDbType.Int) { Value = orderData.productId },
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = orderData.unitPrice },
                        new SqlParameter("@Qty", SqlDbType.Int) { Value = orderData.qty },
                        new SqlParameter("@Discount", SqlDbType.Decimal) { Value = orderData.discount }
                    });

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected == 2;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
