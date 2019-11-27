namespace HandMadeShop.Core.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Measure { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }

        public int UnitsInStock { get; set; }

        //TO DO consideration about attachments FS or RAVEN
        public string PhotoUrl { get; set; }
        public bool IsHidden { get; set; }
        public bool IsAvailable { get; set; }
    }
}