namespace HandMadeShop.Infrastrucutre.DomainEntities
{
    public class OrderItem
    {
        public string Id { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }

        public string Product { get; set; }
        public string ProductName { get; set; }
    }
}