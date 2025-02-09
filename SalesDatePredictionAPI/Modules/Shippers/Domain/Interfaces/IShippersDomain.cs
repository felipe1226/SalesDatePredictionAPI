using SalesDatePredictionAPI.Modules.Shippers.DTO;

namespace SalesDatePredictionAPI.Modules.Shippers.Domain.Interfaces
{
    public interface IShippersDomain
    {
        IEnumerable<ShipperDTO> getAllShippers();
    }
}
