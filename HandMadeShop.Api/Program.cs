using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace HandMadeShop.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateWebHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((builder, context) =>
        {
          string alias = Environment.UserName.Replace(" ", string.Empty);

          context.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hostsettings.json", optional: true)
            .AddJsonFile($"appsettings.{builder.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{alias}.json", optional: true, reloadOnChange: true);

        })
        .ConfigureWebHostDefaults(builder =>
        {
          builder.UseStartup<Startup>();
        });
  }
}
