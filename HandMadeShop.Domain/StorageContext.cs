using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HandMadeShop.Domain
{
  public class StorageContext : DbContext, IStorageContext
  {
    private readonly StorageContextOptions storageContextOptions;

    public StorageContext(IOptions<StorageContextOptions> options)
    {
      this.storageContextOptions = options.Value ?? throw new ArgumentNullException("Storage context options is null.");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer(this.storageContextOptions.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      this.GetType().Assembly
        .GetTypes()
        .Where(t => t.IsClass && typeof(IEntity).GetTypeInfo().IsAssignableFrom(t))
        .ToList()
        .ForEach(a => ((IEntity)Activator.CreateInstance(a)).Configure(modelBuilder));
    }

    public async Task SaveAsync() => await this.SaveChangesAsync();
  }
}
