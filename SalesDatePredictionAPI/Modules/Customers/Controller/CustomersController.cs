using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Customers.Services.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Customer.Controller
{
    [Route("customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersServices _customersServices;

        public CustomersController(ICustomersServices customersServices)
        {
            _customersServices = customersServices;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> getOrders(int customerId)
        {
            return _customersServices.getOrders(customerId);
        }

    }
}
