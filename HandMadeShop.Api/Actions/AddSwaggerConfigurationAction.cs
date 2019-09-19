using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace HandMadeShop.Api.Actions
{
  public static class AddSwaggerConfigurationAction
  {
    public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
      IEnumerable<string> docFilePathes = configuration.GetSection("Swagger:DocFilePathes").Get<string[]>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "HandMadeShop API",
          Version = "v1"
        });

        foreach (string doc in docFilePathes)
          c.IncludeXmlComments(doc);

        c.CustomSchemaIds(x => x.FullName);
      });
    }

  }
}
