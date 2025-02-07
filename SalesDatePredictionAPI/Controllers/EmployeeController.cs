using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<dynamic>> getAll()
        {
            return null;
        }

    }
}
