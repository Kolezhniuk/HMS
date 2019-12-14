using HandMadeShop.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.DependencyInjection;
using Raven.Identity;

namespace HandMadeShop.Api.Actions
{
    public static class AddStorageConfigurationActions
    {
        public static void AddStorage(this IServiceCollection services)
        {
            //1. Configures Raven using the settings in appsettings.json.
            services.AddRavenDbDocStore(options =>
            {
                // Maybe we want to change the identity parts separator.
                options.BeforeInitializeDocStore = docStore => docStore.Conventions.IdentityPartsSeparator = "-";
            });
            // 2. Add a scoped IAsyncDocumentSession. For the sync version, use .AddRavenSession() instead.
            services.AddTransient(sp => sp.GetRequiredService<IDocumentStore>().OpenAsyncSession());
            services.AddIdentity<User, IdentityRole>()
                .AddRavenDbIdentityStores<User, IdentityRole>();
        }
    }
}