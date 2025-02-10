using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Shippers.DTO;

namespace SalesDatePredictionAPI.Modules.Shippers.Services.Interfaces
{
    public interface IShippersServices
    {
        ActionResult<IEnumerable<ShipperDTO>> getAllShippers();
    }
}
