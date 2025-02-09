using SalesDatePredictionAPI.Modules.Products.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Products.DTO;
using SalesDatePredictionAPI.Modules.Shippers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Shippers.DTO;
using SalesDatePredictionAPI.Modules.Shippers.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Shippers.Services
{
    public class ShippersServices : IShippersServices
    {
        private readonly IShippersDomain _shippersDomain;

        public ShippersServices(IShippersDomain shippersDomain)
        {
            _shippersDomain = shippersDomain;
        }

        public IEnumerable<ShipperDTO> getAllShippers()
        {
            try
            {
                IEnumerable<ShipperDTO> shippers = _shippersDomain.getAllShippers();

                if (shippers is null || !shippers.Any())
                    return null;

                return shippers;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
