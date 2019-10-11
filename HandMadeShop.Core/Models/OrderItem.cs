namespace HandMadeShop.Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }

        public string Product { get; set; }
        public string ProductName { get; set; }
    }
}