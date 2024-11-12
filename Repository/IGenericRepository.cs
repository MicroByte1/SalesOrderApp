


public interface IGenericRepository<T>  {

    IEnumerable<T> GetAll();

    T GetById(object id);

    void Add(T Model);

    void Delete(T model);

    void Update(T model);

}