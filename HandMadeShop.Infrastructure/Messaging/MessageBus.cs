using System;
using System.Threading.Tasks;
using HandMadeShop.Infrastrucutre.Interfaces;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Infrastructure.Messaging
{
    public sealed class MessageBus
    {
        private readonly IServiceProvider _provider;

        public MessageBus(IServiceProvider provider)
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

        public async Task<TResult> PublishQuery<TResult>(IQuery<TResult> query)
        {
            //Generic handler
            var type = typeof(IQueryHandler<,>);
            //ARGS to substitute
            Type[] typeArgs = {query.GetType(), typeof(TResult)};
            //Create handler
            var handlerType = type.MakeGenericType(typeArgs);


            dynamic handler = _provider.GetService(handlerType);

            return await handler.Handle(query);
        }
    }
}