using HandMadeShop.Core;

namespace HandMadeShop.Infrastrucutre.Handlers
{
    public interface IEventHandler<T> where T : DomainEvent
    {
    }
}