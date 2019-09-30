using HandMadeShop.Domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HandMadeShop.Api.Actions
{
    public static class AddMongoSettingsConfigurationActions
    {
        public static void AddMongoSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(
                configuration.GetSection(nameof(MongoSettings)));

            services.AddSingleton<IMongoSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoSettgtings>>().Value);

        }
    }
}