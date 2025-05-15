namespace WebApp.Repositories.Interface;
using System.Collections.Generic;
public interface IGenericRepository<T> where T : class
{
    public IEnumerable<T> GetAll();
    public T? GetById(int id);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(int id);
    public IQueryable<T> GetQueryable();
}
