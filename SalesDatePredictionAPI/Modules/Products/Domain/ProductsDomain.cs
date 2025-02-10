using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Infrastructure;
using SalesDatePredictionAPI.Modules.Products.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Products.DTO;
using System.Data;

namespace SalesDatePredictionAPI.Modules.Products.Domain
{
    public class ProductsDomain : IProductsDomain
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance;

        public IEnumerable<ProductDTO> getAllProducts()
        {
            try
            {
                using (SqlConnection connection = new(_dbConnection.getConnectionString()))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection,
                        CommandText = "Production.PA_GetProducts",
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<ProductDTO> products = new();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                products.Add(new ProductDTO
                                {
                                    productId = Convert.ToInt32(reader["productid"].ToString()),
                                    productName = reader["productname"].ToString()
                                });
                            }
                        }
                        reader.Close();

                        return products.ToList();
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
