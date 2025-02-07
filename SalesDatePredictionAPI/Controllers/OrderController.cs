using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpGet]
        [Route("predictions")]
        public async Task<ActionResult<dynamic>> getCustomerOrderPredictions()
        {
            return null;
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<dynamic>> saveNewOrder()
        {
            return null;
        }

    }
}
