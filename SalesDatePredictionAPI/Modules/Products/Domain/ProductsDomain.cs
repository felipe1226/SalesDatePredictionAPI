using Microsoft.Data.SqlClient;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Employees.DTO;
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
            using (SqlConnection connection = new(_dbConnection.getConnectionString()))
            {
                SqlCommand command = new()
                {
                    Connection = connection,
                    CommandText = "Production.PA_GetAllProducts",
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
                                ProductID = Convert.ToInt32(reader[0].ToString()),
                                ProductName = reader[1].ToString()
                            });
                        }
                    }
                    reader.Close();

                    return products.ToList();
                }
            }
        }
    }
}
