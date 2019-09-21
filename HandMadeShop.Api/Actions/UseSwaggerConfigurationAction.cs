using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HandMadeShop.Api.Actions
{
  public static class UseSwaggerConfigurationAction
  {
    public static void UseSwaggerConfiguration(this IApplicationBuilder applicationBuilder, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
    {
        applicationBuilder.UseOpenApi();
        applicationBuilder.UseSwaggerUi3();
    }

  }
}
