using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Orders.DTO;
using SalesDatePredictionAPI.Modules.Orders.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Order.Controller
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices _ordersServices;

        public OrdersController(IOrdersServices ordersServices)
        {
            _ordersServices = ordersServices;
        }

        [HttpPost]
        [Route("sales-date-prediction")]
        public async Task<ActionResult<IEnumerable<SalesDatePredictionDTO>>> getSalesDatePredictions(OrderFiltersDTO filters)
        {
            return _ordersServices.getSalesDatePredictions(filters);
        }

        [HttpPost]
        [Route("add-new-order")]
        public async Task<ActionResult<bool>> addNewOrder(NewOrderDTO orderData)
        {
            return _ordersServices.addNewOrder(orderData);
        }
    }
}
