using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("shipper")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<dynamic>> getAll()
        {
            return null;
        }

    }
}
