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

  // TODO move this out of Domain?
  public class StorageContext : DbContext, IStorageContext
  {
    private readonly StorageContextOptions _storageContextOptions;

    public StorageContext(IOptions<StorageContextOptions> options)
    {
      _storageContextOptions =
        options.Value ?? throw new ArgumentNullException("Storage context options is null.");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer(_storageContextOptions.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      GetType().Assembly
        .GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && typeof(IEntity).GetTypeInfo().IsAssignableFrom(t))
        .ToList()
        .ForEach(a => ((IEntity)Activator.CreateInstance(a)).Configure(modelBuilder));
    }

    public async Task SaveAsync() => await SaveChangesAsync();
  }
}