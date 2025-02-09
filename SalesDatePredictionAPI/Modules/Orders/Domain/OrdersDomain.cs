using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Orders.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;
using System.Data;

namespace SalesDatePredictionAPI.Modules.Orders.Domain
{
    public class OrdersDomain : IOrdersDomain
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance;

        public IEnumerable<SalesDatePredictionDTO> getSalesDatePredictions()
        {
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "Sales.PA_SalesDatePredictions",
                        CommandType = CommandType.StoredProcedure
                    };

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
                                    CustomerName = reader[0].ToString(),
                                    LastOrderDate = DateTime.Parse(reader[1].ToString()),
                                    NextPredictOrder = DateTime.Parse(reader[2].ToString())
                                });
                            }
                        }
                        reader.Close();

                        return salesDatePredictions.ToList();
                    }
                }
            }
            catch (Exception)
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
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = orderData.CustomerId },
                    new SqlParameter("@EmpId", SqlDbType.Int) { Value = orderData.EmpId },
                    new SqlParameter("@ShipperId", SqlDbType.Int) { Value = orderData.ShipperId},
                    new SqlParameter("@ShipName", SqlDbType.NVarChar, 40) { Value = orderData.ShipName },
                    new SqlParameter("@ShipAddress", SqlDbType.NVarChar, 60) { Value = orderData.ShipAddress },
                    new SqlParameter("@ShipCity", SqlDbType.NVarChar, 15) { Value = orderData.ShipCity },
                    new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = orderData.OrderDate },
                    new SqlParameter("@RequiredDate", SqlDbType.DateTime) { Value = orderData.RequiredDate },
                    new SqlParameter("@ShippedDate", SqlDbType.DateTime) { Value = orderData.ShippedDate },
                    new SqlParameter("@Freight", SqlDbType.Decimal) { Value = orderData.Freight },
                    new SqlParameter("@ShipCountry", SqlDbType.NVarChar, 15) { Value = orderData.ShipCountry },
                    new SqlParameter("@ProductId", SqlDbType.Int) { Value = orderData.ProductId },
                    new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = orderData.UnitPrice },
                    new SqlParameter("@Qty", SqlDbType.Int) { Value = orderData.Qty },
                    new SqlParameter("@Discount", SqlDbType.Decimal) { Value = orderData.Discount }
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
