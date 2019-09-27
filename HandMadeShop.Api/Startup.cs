using HandMadeShop.Api.Actions;
using HandMadeShop.Domain.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage(configuration);
            services.AddHandlers();
            services.AddSingleton<Messages>();

            services.AddSwaggerConfiguration();
            services
                .AddMvc()
                .AddJsonOptions(a => a.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();
            app.UseMvc();
        }
    }
}