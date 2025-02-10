
namespace SalesDatePredictionAPI.Modules.Orders.DTO
{
    public class NewOrderDTO
    {
        public int customerId { get; set; }
        public int empId {  get; set; }
        public int shipperId { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public decimal freight { get; set; }
        public string shipCountry { get; set; }
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public int qty { get; set; }
        public double discount { get; set; }
    }
}
