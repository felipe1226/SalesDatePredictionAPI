using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<dynamic>> getAll()
        {
            return null;
        }
    }
}
