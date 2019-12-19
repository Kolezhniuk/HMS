using System;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Utils
{
    public sealed class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<CommandResult> DispatchCommand(ICommand command)
        {
            var type = typeof(ICommandHandler<>);
            Type[] typeArgs = {command.GetType()};
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            CommandResult commandResult = await handler.Handle((dynamic) command);

            return commandResult;
        }

        public async Task<T> DispatchQuery<T>(IQuery<T> query)
        {
            var type = typeof(IQueryHandler<,>);
            Type[] typeArgs = {query.GetType(), typeof(T)};
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = await handler.Handle(query);

            return result;
        }
    }
}