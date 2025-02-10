using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Products.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Products.DTO;
using SalesDatePredictionAPI.Modules.Products.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Products.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly JsonResponse _jsonResponse = JsonResponse.Instance;
        private readonly IProductsDomain _productsDomain;

        public ProductsServices(IProductsDomain productsDomain)
        {
            _productsDomain = productsDomain;
        }

        public ActionResult<IEnumerable<ProductDTO>> getAllProducts()
        {
            try
            {
                IEnumerable<ProductDTO> products = _productsDomain.getAllProducts();

                if (products is null)
                    return _jsonResponse.badResponse<IEnumerable<ProductDTO>>();

                if (!products.Any())
                    return _jsonResponse.successResponse(products, "No se obtuvo resultados");

                return _jsonResponse.successResponse(products);

            }
            catch (Exception e)
            {
                return _jsonResponse.errorResponse<IEnumerable<ProductDTO>>(e.Message);
            }
        }
    }
}
