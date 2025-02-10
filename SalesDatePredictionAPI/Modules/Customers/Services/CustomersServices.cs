using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.Helpers;
using SalesDatePredictionAPI.Modules.Customers.Domain.Interfaces;
using SalesDatePredictionAPI.Modules.Customers.Services.Interfaces;
using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Customers.Services
{
    public class CustomersServices : ICustomersServices
    {
        private readonly JsonResponse _jsonResponse = JsonResponse.Instance;
        private readonly ICustomersDomain _customersDomain;

        public CustomersServices(ICustomersDomain customersDomain)
        {
            _customersDomain = customersDomain;
        }

        public ActionResult<IEnumerable<OrderDTO>> getOrders(int customerId)
        {
			try
			{
                IEnumerable<OrderDTO> orders = _customersDomain.getOrders(customerId);

                if (orders is null)
                    return _jsonResponse.badResponse<IEnumerable<OrderDTO>>();

                if (!orders.Any())
                    return _jsonResponse.successResponse(orders, "No se obtuvo resultados");

                return _jsonResponse.successResponse(orders);
            }
            catch (Exception e)
			{
                return _jsonResponse.errorResponse<IEnumerable<OrderDTO>>(e.Message);
            }
        }
    }
}
