using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Orders.Services.Interfaces
{
    public interface IOrdersServices
    {
        IEnumerable<SalesDatePredictionDTO> getSalesDatePredictions();

        bool addNewOrder(NewOrderDTO orderData);
    }
}
