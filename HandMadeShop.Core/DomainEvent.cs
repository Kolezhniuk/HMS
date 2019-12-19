namespace HandMadeShop.Core
{
    public abstract class DomainEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}