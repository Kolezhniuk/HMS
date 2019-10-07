using System.Collections.Generic;

namespace HandMadeShop.Domain
{
  public interface IGenericRepository<T>
  {
    IEnumerable<T> GetAll();
    T GetById(int id);
    IGenericRepository<T> Insert(T entity);
    IGenericRepository<T> Update(T entity);
    IGenericRepository<T> Delete(int id);
    void Save();
  }
}