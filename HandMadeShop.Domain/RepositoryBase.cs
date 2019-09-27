using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace HandMadeShop.Domain
{
  public abstract class RepositoryBase<TEntity> where TEntity : class, IEntity
  {
    protected DbContext storageContext;
    protected DbSet<TEntity> dbSet;

    protected RepositoryBase(IStorageContext storageContext)
    {
      if (!(storageContext is DbContext))
        throw new ArgumentException("The storageContext object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");

      this.storageContext = storageContext as DbContext;
      this.dbSet = this.storageContext.Set<TEntity>();
    }
  }
}
