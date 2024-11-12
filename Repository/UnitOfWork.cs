


public class UnitOfWork : IUnitOfWork
{
    private readonly AppContext _context;
    public UnitOfWork(AppContext context)
    {
        _context = context;
    }
    public IGenericRepository<T> genericRepository<T>() where T : class
    {
        IGenericRepository<T> repo = new GenericRepository<T>(_context);
        return repo;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}