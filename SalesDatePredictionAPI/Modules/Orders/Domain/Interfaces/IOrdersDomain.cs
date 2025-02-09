using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Orders.Domain.Interfaces
{
    public interface IOrdersDomain
    {
        IEnumerable<SalesDatePredictionDTO> getSalesDatePredictions();

        bool addNewOrder(NewOrderDTO orderData);
    }
}
