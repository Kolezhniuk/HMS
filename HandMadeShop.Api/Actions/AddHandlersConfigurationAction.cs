using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HandMadeShop.Infrastrucutre.Interfaces;
using HandMadeShop.Infrastrucutre.Messaging;
using HandMadeShop.Infrastrucutre.Utils.Decorators;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
    public static class AddHandlersConfigurationAction
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            var handlerTypes = typeof(ICommand).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlerTypes)
            {
                AddHandler(services, type);
                var genericParamType = type.GetInterfaces()[0].GetGenericArguments()[0];
                MessageBusHelper.RegisteredServices[type] = type.GetInterfaces()[0].GetGenericArguments();
            }
        }

        private static void AddHandler(IServiceCollection services, Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            var pipeline = attributes
                .Select(ToDecorator)
                .Concat(new[] {type})
                .Reverse()
                .ToList();

            var interfaceType = type.GetInterfaces().Single(IsHandlerInterface);
            var factory = BuildPipeline(pipeline, interfaceType);

            services.AddTransient(interfaceType, factory);
        }

        private static Func<IServiceProvider, object> BuildPipeline(IEnumerable<Type> pipeline, Type interfaceType)
        {
            var ctors = pipeline
                .Select(x =>
                {
                    var type = x.IsGenericType ? x.MakeGenericType(interfaceType.GenericTypeArguments) : x;
                    return type.GetConstructors().Single();
                })
                .ToList();

            Func<IServiceProvider, object> func = provider =>
            {
                object current = null;

                foreach (var ctor in ctors)
                {
                    var parameterInfos = ctor.GetParameters().ToList();

                    var parameters = GetParameters(parameterInfos, current, provider);

                    current = ctor.Invoke(parameters);
                }

                return current;
            };

            return func;
        }

        private static object[] GetParameters(IReadOnlyList<ParameterInfo> parameterInfos, object current,
            IServiceProvider provider)
        {
            var result = new object[parameterInfos.Count];

            for (var i = 0; i < parameterInfos.Count; i++)
                result[i] = GetParameter(parameterInfos[i], current, provider);

            return result;
        }

        private static object GetParameter(ParameterInfo parameterInfo, object current, IServiceProvider provider)
        {
            var parameterType = parameterInfo.ParameterType;

            if (IsHandlerInterface(parameterType))
                return current;

            var service = provider.GetRequiredService<IServiceScopeFactory>()
                .CreateScope()
                .ServiceProvider
                .GetService(parameterType);

            if (service != null)
                return service;

            throw new ArgumentException($"Type {parameterType} not found");
        }

        private static Type ToDecorator(object attribute)
        {
            var type = attribute.GetType();

            if (type == typeof(AuditLogAttribute))
                return typeof(AuditLoggingDecorator<>);

            throw new ArgumentException(attribute.ToString());
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