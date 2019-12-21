using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using HandMadeShop.Core;

namespace HandMadeShop.Logic.Utils
{
    public class EventBus
    {
        private readonly Subject<DomainEvent> _domainEventObserver = new Subject<DomainEvent>();
        private IObservable<DomainEvent> DomainEventListener => _domainEventObserver;

        public void PublishEvent(DomainEvent evt)
        {
            _domainEventObserver.OnNext(evt);
        }

        public IObservable<T> Of<T>()
        {
            return _domainEventObserver.OfType<T>();
        }
    }
}