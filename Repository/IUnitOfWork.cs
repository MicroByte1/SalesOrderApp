


public interface IUnitOfWork {
    // method to get istance of current T class model
    IGenericRepository<T> genericRepository<T>() where T : class;

    void Save();


}