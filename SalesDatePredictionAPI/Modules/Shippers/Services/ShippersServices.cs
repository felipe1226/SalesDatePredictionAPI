using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Shippers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Shippers.DTO;
using SalesDatePredictionAPI.Modules.Shippers.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Shippers.Services
{
    public class ShippersServices : IShippersServices
    {
        private readonly JsonResponse _jsonResponse = JsonResponse.Instance;
        private readonly IShippersDomain _shippersDomain;

        public ShippersServices(IShippersDomain shippersDomain)
        {
            _shippersDomain = shippersDomain;
        }

        public ActionResult<IEnumerable<ShipperDTO>> getAllShippers()
        {
            try
            {
                IEnumerable<ShipperDTO> shippers = _shippersDomain.getAllShippers();

                if (shippers is null)
                    return _jsonResponse.badResponse<IEnumerable<ShipperDTO>>();

                if (!shippers.Any())
                    return _jsonResponse.successResponse(shippers, "No se obtuvo resultados");

                return _jsonResponse.successResponse(shippers);
            }
            catch (Exception e)
            {
                return _jsonResponse.errorResponse<IEnumerable<ShipperDTO>>(e.Message);
            }
        }
    }
}
