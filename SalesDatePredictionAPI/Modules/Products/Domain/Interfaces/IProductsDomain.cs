using SalesDatePredictionAPI.Modules.Products.DTO;

namespace SalesDatePredictionAPI.Modules.Products.Domain.Interfaces
{
    public interface IProductsDomain
    {
        IEnumerable<ProductDTO> getAllProducts();
    }
}
