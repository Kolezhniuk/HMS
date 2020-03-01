using System.Linq;
using System.Threading.Tasks;
using Autofac;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Utils
{
    public sealed class MessageBus
    {
        private readonly ILifetimeScope _scope;

        public MessageBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<CommandResult> DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<TCommand>>();
            var commandResult = await handler.Handle(command);
            return commandResult;
        }

        public async Task<TResult> PublishQuery<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _scope.Resolve<IQueryHandler<TQuery, TResult>>();
            var result = await handler.Handle(query);
            return result;
        }

        public Task PublishEvent<T>(T evt) where T : IEvent => Handle(evt);

        private Task Handle<T>(T evt) where T : IEvent
        {
            var types = _scope.ComponentRegistry.Registrations
                .Where(r => typeof(IEventHandler<T>).IsAssignableFrom(r.Activator.LimitType))
                .Select(r => r.Activator.LimitType);
            var subscribers = types.Select(t => _scope.Resolve(t) as IEventHandler<T>);

            foreach (var subscriber in subscribers)
                subscriber?.Handle(evt);
            return Task.CompletedTask;
        }
    }
}