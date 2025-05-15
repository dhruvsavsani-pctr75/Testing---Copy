using WebApp.Entities.Data;
using WebApp.Repositories.Interface;


namespace WebApp.Repositories.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TestingFinalContext _context;

    public GenericRepository(TestingFinalContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        T entity = GetById(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }


    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IQueryable<T> GetQueryable()
    {
        return _context.Set<T>();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
