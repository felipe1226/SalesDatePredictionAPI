using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Orders.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;
using SalesDatePredictionAPI.Modules.Orders.Services.Interfaces;

namespace SalesDatePredictionAPI.Modules.Orders.Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly JsonResponse _jsonResponse = JsonResponse.Instance;
        private readonly IOrdersDomain _ordersDomain;

        public OrdersServices(IOrdersDomain ordersDomain)
        {
            _ordersDomain = ordersDomain;
        }

        public ActionResult<IEnumerable<SalesDatePredictionDTO>> getSalesDatePredictions(OrderFiltersDTO filters)
        {
            try
            {
                IEnumerable<SalesDatePredictionDTO> salesDatePredictions = _ordersDomain.getSalesDatePredictions(filters);

                if (salesDatePredictions is null)
                    return _jsonResponse.badResponse<IEnumerable<SalesDatePredictionDTO>>();

                if (!salesDatePredictions.Any())
                    return _jsonResponse.successResponse(salesDatePredictions, "No se obtuvo resultados");

                return _jsonResponse.successResponse(salesDatePredictions);
            }
            catch (Exception e)
            {
                return _jsonResponse.errorResponse<IEnumerable<SalesDatePredictionDTO>>(e.Message);
            }
        }

        public ActionResult<bool> addNewOrder(NewOrderDTO orderData)
        {
            try
            {
               bool isCorrectResponse = _ordersDomain.addNewOrder(orderData);

                if (!isCorrectResponse)
                    return _jsonResponse.badResponse<bool>("No se registró la orden correctamente");

                return _jsonResponse.successResponse(true, "Se registró la orden satisfactoriamente");
            }
            catch (Exception e)
            {
                return _jsonResponse.errorResponse<bool>(e.Message);
            }
        }
    }
}
