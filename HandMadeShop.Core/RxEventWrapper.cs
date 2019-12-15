using System;
using System.Reactive.Subjects;

namespace HandMadeShop.Core
{
    public class RxEventWrapper
    {
        public Subject<AppEvent> Subject { get; set; } = new Subject<AppEvent>();
        public IObservable<AppEvent> Observable => Subject;
    }
}