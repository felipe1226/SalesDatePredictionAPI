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

        [HttpGet]
        [Route("sales-date-predictions")]
        public async Task<IEnumerable<SalesDatePredictionDTO>> getSalesDatePredictions()
        {
            return _ordersServices.getSalesDatePredictions();
        }

        [HttpPost]
        [Route("add-new-order")]
        public async Task<bool> addNewOrder(NewOrderDTO orderData)
        {
            return _ordersServices.addNewOrder(orderData);
        }

    }
}
