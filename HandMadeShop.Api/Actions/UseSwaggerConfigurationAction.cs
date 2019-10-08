using Microsoft.AspNetCore.Builder;

namespace HandMadeShop.Api.Actions
{
  public static class UseSwaggerConfigurationAction
  {
    public static void UseSwaggerConfiguration(this IApplicationBuilder applicationBuilder)
    {
      applicationBuilder.UseOpenApi();
      applicationBuilder.UseSwaggerUi3();
    }
  }
}
