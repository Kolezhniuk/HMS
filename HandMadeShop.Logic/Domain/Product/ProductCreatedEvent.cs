using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Product
{
    public class ProductCreatedEvent : IEvent
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}