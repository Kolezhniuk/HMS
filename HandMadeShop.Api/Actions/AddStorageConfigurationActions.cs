using Microsoft.Extensions.DependencyInjection;
using Raven.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
    public static class AddStorageConfigurationActions
    {
        public static void AddStorage(this IServiceCollection services)
        {
            services.AddRavenDbDocStore();
            services.AddRavenDbAsyncSession();
        }
    }
}