namespace SalesDatePredictionAPI.Modules.Orders.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCit { get; set; }
    }
}
