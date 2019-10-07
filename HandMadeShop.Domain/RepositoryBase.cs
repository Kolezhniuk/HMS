using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandMadeShop.Domain
{
  public class RepositoryBase<T>: IGenericRepository<T> where T  : class, IEntity
    {
        protected readonly DbContext StorageContext;
        protected DbSet<T> _table;

        public RepositoryBase(IStorageContext storageContext)
        {
            StorageContext = storageContext as DbContext ??
                             throw new ArgumentException(
                                 "The storageContext object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");
            _table = StorageContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public IGenericRepository<T> Insert(T entity)
        {
            _table.Add(entity);
            return this;
        }

        public IGenericRepository<T> Update(T entity)
        {
            _table.Update(entity);
            return this;
        }

        public IGenericRepository<T> Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            return this;
        }

        public void Save() => StorageContext.SaveChanges();
        
    }
}