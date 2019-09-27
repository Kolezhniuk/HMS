using HandMadeShop.Domain.Options;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace HandMadeShop.Domain
{
  internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StorageContext>
  {
    private readonly StorageContextOptions storageContextOptions;

    public DesignTimeDbContextFactory()
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.UserName.Replace(" ", string.Empty)}.json", optional: true, reloadOnChange: true)
        .Build();

      this.storageContextOptions = new StorageContextOptions { ConnectionString = configuration.GetConnectionString("Default") };
    }

    public StorageContext CreateDbContext(string[] args) =>
      new StorageContext(new OptionsWrapper<StorageContextOptions>(this.storageContextOptions));
  }
}
