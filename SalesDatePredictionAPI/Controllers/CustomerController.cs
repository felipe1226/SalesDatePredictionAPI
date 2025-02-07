using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        [Route("orders")]
        public async Task<ActionResult<dynamic>> getOrders(string customerId)
        {
            return null;
        }


    }
}
