using System.Collections.Generic;

namespace HandMadeShop.Core.Entities
{
    public class Measure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public ICollection<ProductMeasure> ProductMeasures { get; set; }
    }
}