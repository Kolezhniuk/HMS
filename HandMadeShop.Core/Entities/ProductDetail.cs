namespace HandMadeShop.Core.Entities
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public int DetailId { get; set; }

        public Product Product { get; set; }
        public Detail Detail { get; set; }
    }
}