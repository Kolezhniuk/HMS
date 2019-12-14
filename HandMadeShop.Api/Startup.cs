using HandMadeShop.Api.Actions;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HandMadeShop.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage();
            services.AddSingleton<Messages>();
            services.AddHandlers();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddSwaggerConfiguration();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == Environments.Development)
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.InitDatabase();
            app.SeedData();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}