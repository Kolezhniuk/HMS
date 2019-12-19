using System;
using System.Reactive.Subjects;

namespace HandMadeShop.Core
{
    public class RxEventWrapper
    {
        public Subject<DomainEvent> Subject { get; set; } = new Subject<DomainEvent>();
        public IObservable<DomainEvent> Observable => Subject;
    }
}