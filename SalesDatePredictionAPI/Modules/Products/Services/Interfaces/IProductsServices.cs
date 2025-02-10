using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Products.DTO;

namespace SalesDatePredictionAPI.Modules.Products.Services.Interfaces
{
    public interface IProductsServices
    {
        ActionResult<IEnumerable<ProductDTO>> getAllProducts();
    }
}
