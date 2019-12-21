using HandMadeShop.Core;

namespace HandMadeShop.Logic.Interfaces
{
    public interface IEventHandler<T> where T : DomainEvent
    {
    }
}