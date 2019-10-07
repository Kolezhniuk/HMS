using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace HandMadeShop.Api
{
    public static class Program
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
        .UseSerilog((hostingContext, loggerConfiguration) => 
          loggerConfiguration
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .ReadFrom.Configuration(hostingContext.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            {
              AutoRegisterTemplate = true,
              AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
            })
        )
        .ConfigureWebHostDefaults(builder =>
        {
          builder.UseStartup<Startup>();
        });
  }
}
