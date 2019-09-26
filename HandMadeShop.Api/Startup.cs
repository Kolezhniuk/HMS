using HandMadeShop.Api.Actions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandMadeShop.Api
{
  public class Startup
  {
    private readonly IConfiguration configuration;
    private readonly IHostingEnvironment hostingEnvironment;

    public Startup(
      IConfiguration configuration,
      IHostingEnvironment hostingEnvironment)
    {
      this.configuration = configuration;
      this.hostingEnvironment = hostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<Domain.Options.StorageContextOptions>(o =>
      {
        o.ConnectionString = this.configuration.GetConnectionString("Default");
      });
      services.AddScoped<Domain.Interfaces.IStorageContext, Domain.StorageContext>();
      services.AddScoped<Domain.RepositoryAbstractions.IDeliveryMethodRepository, Domain.Repositories.DeliveryMethodRepository>();

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
