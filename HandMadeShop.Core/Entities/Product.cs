using System.Collections.Generic;

namespace HandMadeShop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHidden { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<ProductMeasure> ProductMeasures { get; set; }
    }
}