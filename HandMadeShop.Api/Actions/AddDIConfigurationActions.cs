using HandMadeShop.Infrastructure.Messaging;
using HandMadeShop.Logic.Domain.Measure;
using HandMadeShop.Logic.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
    public static class AddDiConfigurationActions
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddSingleton<MessageBus>();
            services.AddSingleton<EventBus>();
            services.AddSingleton<AddEventHandlersConfiguration>();
            services.AddSingleton<MeasureEventListener>();
        }
    }
}