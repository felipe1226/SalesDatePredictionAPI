using SalesDatePredictionAPI.Modules.Orders.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;
using SalesDatePredictionAPI.Modules.Orders.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Orders.Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly IOrdersDomain _ordersDomain;

        public OrdersServices(IOrdersDomain ordersDomain)
        {
            _ordersDomain = ordersDomain;
        }

        public IEnumerable<SalesDatePredictionDTO> getSalesDatePredictions()
        {
            try
            {
                IEnumerable<SalesDatePredictionDTO> salesDatePredictions = _ordersDomain.getSalesDatePredictions();

                if (salesDatePredictions is null || !salesDatePredictions.Any())
                    return null;

                return salesDatePredictions;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool addNewOrder(NewOrderDTO orderData)
        {
            try
            {
               bool isCorrectResponse = _ordersDomain.addNewOrder(orderData);

                if (!isCorrectResponse)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
