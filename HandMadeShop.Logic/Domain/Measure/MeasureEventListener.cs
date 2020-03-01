using System.Threading.Tasks;
using HandMadeShop.Logic.Domain.Product;
using HandMadeShop.Logic.Domain.User.Events;
using HandMadeShop.Logic.Interfaces;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Logic.Domain.Measure
{
    public class MeasureEventListener :
        IEventHandler<ProductCreatedEvent>,
        IEventHandler<UserAuthorizedEvt>
    {
        private readonly ILogger _logger;

        public MeasureEventListener(ILogger<MeasureEventListener> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent @event)
        {
            _logger.LogError($" Product created {@event.Id}, {@event.Name}");
            return Task.CompletedTask;
        }

        public Task Handle(UserAuthorizedEvt @event)
        {
            _logger.LogError($" User authorized event {@event.Id}, {@event.UserName}");
            return Task.CompletedTask;
        }
    }
}