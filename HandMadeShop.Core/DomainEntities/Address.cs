namespace HandMadeShop.Core.DomainEntities
{
    public class Address
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public object Location { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
    }
}