using System.Collections.Generic;

namespace HandMadeShop.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHidden { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Category> ProductCategories { get; set; }
        public ICollection<Detail> ProductDetails { get; set; }
        public ICollection<Measure> ProductMeasures { get; set; }
    }
}