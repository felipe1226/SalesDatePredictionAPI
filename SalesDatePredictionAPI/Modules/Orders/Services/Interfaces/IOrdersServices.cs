using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Orders.Services.Interfaces
{
    public interface IOrdersServices
    {
        ActionResult<IEnumerable<SalesDatePredictionDTO>> getSalesDatePredictions(OrderFiltersDTO filters);

        ActionResult<bool> addNewOrder(NewOrderDTO orderData);
    }
}
