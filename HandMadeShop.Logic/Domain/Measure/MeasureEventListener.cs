using System;
using HandMadeShop.Infrastrucutre.Domain.Product;
using HandMadeShop.Logic.Domain.User.Events;
using HandMadeShop.Logic.Utils;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Logic.Domain.Measure
{
    public class MeasureEventListener
    {
        private readonly EventBus _eventBus;
        private readonly ILogger _logger;

        public MeasureEventListener(EventBus eventBus, ILogger<MeasureEventListener> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public IDisposable HandleProductCreatedEvent()
        {
            return _eventBus.Of<ProductCreatedEvent>()
                .Subscribe(evt => { _logger.LogError($"ProductCreatedEvent {evt.Id}, {evt.Name} "); });
        }

        public IDisposable HandleUserAuthorizedEvent()
        {
            return _eventBus.Of<UserAuthorizedEvt>()
                .Subscribe(evt => { _logger.LogError($"UserAuthorizedEvt {evt.Id}, {evt.Name}, {evt.UserName} "); });
        }
    }
}