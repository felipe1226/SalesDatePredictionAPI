namespace SalesDatePredictionAPI.Modules.Orders.DTO
{
    public class SalesDatePredictionDTO
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string lastOrderDate { get; set; }
        public string nextPredictedOrder { get; set; }
    }
}
