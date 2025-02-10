namespace SalesDatePredictionAPI.Modules.Orders.DTO
{
    public class OrderDTO
    {
        public int orderId { get; set; }
        public string requiredDate { get; set; }
        public string? shippedDate { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
    }
}
