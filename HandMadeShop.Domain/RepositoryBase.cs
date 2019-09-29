using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HandMadeShop.Domain
{
    public abstract class RepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected DbContext storageContext;
        protected DbSet<TEntity> dbSet;

        protected RepositoryBase(IStorageContext storageContext)
        {
            this.storageContext = storageContext as DbContext ??
                                  throw new ArgumentException(
                                      "The storageContext object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");
            this.dbSet = this.storageContext.Set<TEntity>();
        }
    }
}