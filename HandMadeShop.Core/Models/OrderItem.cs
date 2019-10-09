namespace HandMadeShop.Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}