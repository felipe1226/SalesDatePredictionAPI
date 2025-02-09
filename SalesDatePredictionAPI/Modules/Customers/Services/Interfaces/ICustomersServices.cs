using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Customers.Services.Interfaces
{
    public interface ICustomersServices
    {
        ActionResult<IEnumerable<OrderDTO>> getOrders(int customerId);
    }
}
