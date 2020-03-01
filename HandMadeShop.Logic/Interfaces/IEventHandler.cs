using System.Threading.Tasks;

namespace HandMadeShop.Logic.Interfaces
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task Handle(T @event);
    }
}