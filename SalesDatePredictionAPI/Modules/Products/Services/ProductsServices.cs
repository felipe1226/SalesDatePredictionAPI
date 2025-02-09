using SalesDatePredictionAPI.Modules.Products.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Products.DTO;
using SalesDatePredictionAPI.Modules.Products.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Products.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsDomain _productsDomain;

        public ProductsServices(IProductsDomain productsDomain)
        {
            _productsDomain = productsDomain;
        }

        public IEnumerable<ProductDTO> getAllProducts()
        {
            try
            {
                IEnumerable<ProductDTO> products = _productsDomain.getAllProducts();

                if (products is null || !products.Any())
                    return null;

                return products;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
