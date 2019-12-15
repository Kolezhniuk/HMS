using System;

namespace HandMadeShop.Core.DomainEntities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Measure { get; set; }
        public double Price { get; set; }
        public double? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public bool HasOptions { get; set; }
        public bool IsAllowToOrder { get; set; }
        public int StockQuantity { get; set; }
        public bool IsHidden { get; set; }
        public bool IsAvailable { get; set; }
        public int DisplayOrder { get; set; }
        public string Vendor { get; set; }

        //TODO handle these properties
        public string PhotoUrl { get; set; }
        public string ThumbnailImage { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }
    }
}