using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Products.DTO;
using SalesDatePredictionAPI.Modules.Products.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Products.Controller
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductsServices _productsServices;

        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<ProductDTO>> getAllProducts()
        {
            return _productsServices.getAllProducts();
        }
    }
}
