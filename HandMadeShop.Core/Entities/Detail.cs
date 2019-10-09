using System.Collections.Generic;

namespace HandMadeShop.Core.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public int? DetailId { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public Detail Parent { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}