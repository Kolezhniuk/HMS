using System;
using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Utils
{
  public sealed class Messages
  {
    private readonly IServiceProvider _provider;

    public Messages(IServiceProvider provider)
    {
      _provider = provider;
    }

    public CommandResult Dispatch(ICommand command)
    {
      var type = typeof(ICommandHandler<>);
      Type[] typeArgs = { command.GetType() };
      var handlerType = type.MakeGenericType(typeArgs);

      dynamic handler = _provider.GetService(handlerType);
      CommandResult commandResult = handler.Handle((dynamic)command);

      return commandResult;
    }

    public T Dispatch<T>(IQuery<T> query)
    {
      var type = typeof(IQueryHandler<,>);
      Type[] typeArgs = { query.GetType(), typeof(T) };
      var handlerType = type.MakeGenericType(typeArgs);

      dynamic handler = _provider.GetService(handlerType);
      T result = handler.Handle((dynamic)query);

      return result;
    }
  }
}