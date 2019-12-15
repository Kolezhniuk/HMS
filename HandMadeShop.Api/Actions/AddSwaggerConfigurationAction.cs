using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api.Actions
{
    public static class AddSwaggerConfigurationAction
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "HandMadeShop API";
                    document.Info.Description = "Best hand made shop ever developed by professionals";
                    document.Info.TermsOfService = "None";
                };
            });
        }
    }
}