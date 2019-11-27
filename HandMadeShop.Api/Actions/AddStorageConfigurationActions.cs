using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
    public static class AddStorageConfigurationActions
    {
        public static void AddStorage(this IServiceCollection services)
        {
            //1. Configures Raven using the settings in appsettings.json.
            services.AddRavenDbDocStore();
            // 2. Add a scoped IAsyncDocumentSession. For the sync version, use .AddRavenSession() instead.
            services.AddTransient(sp => sp.GetRequiredService<IDocumentStore>().OpenAsyncSession());
        }
    }
}