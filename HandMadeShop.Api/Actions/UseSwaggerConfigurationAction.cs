using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HandMadeShop.Api.Actions
{
  public static class UseSwaggerConfigurationAction
  {
    public static void UseSwaggerConfiguration(this IApplicationBuilder applicationBuilder, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
    {
      string endPointName = "HandMadeShop API v1";

      applicationBuilder.UseSwagger(c =>
      {
        c.RouteTemplate = "api-docs/{documentName}/swagger.json";
      });

      if (hostingEnvironment.IsDevelopment())
        applicationBuilder.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/api-docs/v1/swagger.json", endPointName);
          c.IndexStream = () => new FileStream($"SwaggerIndex.html", FileMode.Open);
        });
      else
        applicationBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/api-docs/v1/swagger.json", endPointName));
    }

  }
}
