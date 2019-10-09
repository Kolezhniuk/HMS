namespace HandMadeShop.Core.Entities
{
    public class ProductMeasure
    {
        public int ProductId { get; set; }
        public int MeasureId { get; set; }

        public Product Product { get; set; }
        public Measure Measure { get; set; }
    }
}