using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Shippers.DTO;
using SalesDatePredictionAPI.Modules.Shippers.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Shipper.Controller
{
    [Route("shippers")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShippersServices _shippersServices;

        public ShippersController(IShippersServices shippersServices)
        {
            _shippersServices = shippersServices;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<ShipperDTO>>> getAllShippers()
        {
            return _shippersServices.getAllShippers();
        }
    }
}
