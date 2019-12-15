using System;
using System.Reactive.Linq;
using HandMadeShop.Core;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Logic.Domain.Measure
{
    public class MeasureEventListener<T> : IDisposable where T : AppEvent
    {
        private readonly ILogger _logger;
        private readonly RxEventWrapper _rxEventWrapper;
        private IDisposable _subscribtion;

        public MeasureEventListener(RxEventWrapper rxEventWrapper, ILogger<MeasureEventListener<T>> logger)
        {
            _rxEventWrapper = rxEventWrapper;
            _logger = logger;
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        public void Listen()
        {
            _subscribtion = _rxEventWrapper
                .Observable
                .OfType<T>()
                .Subscribe(evt
                    => _logger.LogError($"Event {nameof(evt)} happened Id: {evt.Id} Info: {evt.Name} "));
        }

        private void ReleaseUnmanagedResources()
        {
            _subscribtion.Dispose();
        }

        ~MeasureEventListener()
        {
            ReleaseUnmanagedResources();
        }
    }
}