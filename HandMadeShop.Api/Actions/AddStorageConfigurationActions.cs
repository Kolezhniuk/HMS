using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.DependencyInjection;
using Raven.Identity;
using HandMadeShop.Core.Models;

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
            services.AddTransient(sp => sp.GetRequiredService<IDocumentStore>().OpenAsyncSession())
                .AddRavenDbIdentity<AppUser>(); // Use Raven to manage users and roles.
        }
    }
}