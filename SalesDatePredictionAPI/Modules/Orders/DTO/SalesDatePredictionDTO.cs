namespace SalesDatePredictionAPI.Modules.Orders.DTO
{
    public class SalesDatePredictionDTO
    {
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictOrder { get; set; }
    }
}
