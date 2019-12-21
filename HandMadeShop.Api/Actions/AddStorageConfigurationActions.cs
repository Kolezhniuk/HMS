using HandMadeShop.Core.DomainEntities;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddRavenDbAsyncSession();
            services.AddIdentity<User, IdentityRole>()
                .AddRavenDbIdentityStores<User, IdentityRole>();
        }
    }
}