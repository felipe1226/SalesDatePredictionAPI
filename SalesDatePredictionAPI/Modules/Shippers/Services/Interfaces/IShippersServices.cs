using SalesDatePredictionAPI.Modules.Shippers.DTO;

namespace SalesDatePredictionAPI.Modules.Shippers.Services.Interfaces
{
    public interface IShippersServices
    {
        IEnumerable<ShipperDTO> getAllShippers();
    }
}
