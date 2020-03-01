using Autofac;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using HandMadeShop.Logic.Utils.Decorators;

namespace HandMadeShop.Api.Extensions
{
    public static class AutofacExtensions
    {
        public static void AddProjectServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MessageBus>().SingleInstance();
        }

        public static void AddCqrsHandlers(this ContainerBuilder builder)
        {
            var dataAccess = typeof(ICommand).Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("QueryHandler") || t.Name.EndsWith("CommandHandler"))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }

        public static void AddDecorators(this ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(LoggingCommandDecorator<>), typeof(ICommandHandler<>));
            builder.RegisterGenericDecorator(typeof(LoggingQueryDecorator<,>), typeof(IQueryHandler<,>));
        }

        public static void AddEventListeners(this ContainerBuilder builder)
        {
            var dataAccess = typeof(IEvent).Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .InstancePerLifetimeScope();
        }
    }
}