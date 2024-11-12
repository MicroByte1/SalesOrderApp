

using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    private readonly AppContext _context;
    internal DbSet<T> dbSet;
    public GenericRepository(AppContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }
    public void Add(T Model)
    {
        dbSet.Add(Model);
    }

    public void Delete(T model)
    {
        dbSet.Remove(model);
    }

    public IEnumerable<T> GetAll()
    {
        return dbSet.ToList();
    }

    public T GetById(object id)
    {
        return dbSet.Find(id);
    }

    public void Update(T model)
    {
        _context.Entry(model).State = EntityState.Modified;
    }
}