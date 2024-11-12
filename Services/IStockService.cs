


public interface IStockService {

    IEnumerable<Stock> GetAll();

    Stock GetById(object id);

    void Add(Stock Model);

    void Delete(Stock model);

    void Update(Stock model);
}