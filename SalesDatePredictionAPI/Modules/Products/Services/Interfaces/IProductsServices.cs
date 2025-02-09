using SalesDatePredictionAPI.Modules.Products.DTO;

namespace SalesDatePredictionAPI.Modules.Products.Services.Interfaces
{
    public interface IProductsServices
    {
        IEnumerable<ProductDTO> getAllProducts();
    }
}
