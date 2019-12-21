namespace HandMadeShop.Infrastrucutre.DomainEntities
{
    public class Supplier
    {
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}