using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Infrastructure;
using SalesDatePredictionAPI.Modules.Shippers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Shippers.DTO;
using System.Data;

namespace SalesDatePredictionAPI.Modules.Shippers.Domain
{
    public class ShippersDomain : IShippersDomain
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance;

        public IEnumerable<ShipperDTO> getAllShippers()
        {
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "Sales.PA_GetShippers",
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<ShipperDTO> shippers = new();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                shippers.Add(new ShipperDTO
                                {
                                    shipperId = Convert.ToInt32(reader["shipperid"].ToString()),
                                    companyName = reader["companyname"].ToString()
                                });
                            }
                        }
                        reader.Close();

                        return shippers.ToList();
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
