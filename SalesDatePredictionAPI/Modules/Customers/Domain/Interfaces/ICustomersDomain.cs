using SalesDatePredictionAPI.Modules.Orders.DTO;

namespace SalesDatePredictionAPI.Modules.Customers.Domain.Interfaces
{
    public interface ICustomersDomain
    {
        public IEnumerable<OrderDTO> getOrders(int customerId);
    }
}
