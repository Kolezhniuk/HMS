using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
    public static class AddStorageConfigurationActions
    {

        public static void AddStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<Domain.Options.StorageContextOptions>
                (o => o.ConnectionString = configuration.GetConnectionString("Default"));
            serviceCollection.AddTransient<Domain.Interfaces.IStorageContext, Domain.StorageContext>();
            serviceCollection.AddTransient<Domain.RepositoryAbstractions.IDeliveryMethodRepository, Domain.Repositories.DeliveryMethodRepository>();
        }

    }
}