using System.Threading.Tasks;
using HandMadeShop.Logic.Domain.User.Events;
using HandMadeShop.Logic.Interfaces;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Logic.Domain.Product
{
    public sealed class ProductEventListener : IEventHandler<UserAuthorizedEvt>
    {
        private readonly ILogger _logger;

        public ProductEventListener(ILogger<ProductEventListener> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserAuthorizedEvt @event)
        {
            _logger.LogError($"{nameof(ProductEventListener)} event {nameof(UserAuthorizedEvt)}");
            return Task.CompletedTask;
        }
    }
}