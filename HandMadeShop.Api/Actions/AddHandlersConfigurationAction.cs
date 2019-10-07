using System;
using System.Linq;
using HandMadeShop.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
  public static class AddHandlersConfigurationAction
  {
    public static void AddHandlers(this IServiceCollection services)
    {
      var handlerTypes = typeof(ICommand).Assembly.GetTypes()
          .Where(x => x.GetInterfaces().Any(y => IsHandlerInterface(y)))
          .Where(x => x.Name.EndsWith("Handler"))
          .ToList();

      foreach (var type in handlerTypes)
      {
        AddHandler(services, type);
      }
    }

    private static void AddHandler(IServiceCollection services, Type type)
    {
      var interfaceType = type.GetInterfaces().Single(y => IsHandlerInterface(y));
      services.AddTransient(interfaceType, type);
    }

    private static bool IsHandlerInterface(Type type)
    {
      if (!type.IsGenericType)
        return false;

      var typeDefinition = type.GetGenericTypeDefinition();

      return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
    }

  }
}