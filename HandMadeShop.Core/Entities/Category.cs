using System.Collections.Generic;

namespace HandMadeShop.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }

        public Category Parent { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}