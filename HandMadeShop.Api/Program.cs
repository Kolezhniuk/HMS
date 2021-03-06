﻿using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((builder, context) =>
                {
                    var alias = Environment.UserName.Replace(" ", string.Empty);

                    context.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true)
                        .AddJsonFile($"appsettings.{builder.HostingEnvironment.EnvironmentName}.json", true,
                            true)
                        .AddJsonFile($"appsettings.{alias}.json", true, true);
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
                            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7
                        })
                )
                .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });
        }
    }
}