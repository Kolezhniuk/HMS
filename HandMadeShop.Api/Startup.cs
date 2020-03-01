using System.Reflection;
using Autofac;
using FluentValidation.AspNetCore;
using HandMadeShop.Api.Actions;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;
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
            // services.RegisterHandlers();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddSwaggerConfiguration();
            services.AddControllers().AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblies(new[]
                {
                    Assembly.GetAssembly(typeof(ICommand)),
                    Assembly.GetAssembly(typeof(WriteMeasureDto)),
                }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == Environments.Development) app.UseDeveloperExceptionPage();

            app.UseSwaggerConfiguration();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.InitDatabase();
            app.SeedData();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }
    }
}