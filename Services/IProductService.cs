

public interface IProductService {

    IEnumerable<Product> GetAll();

    Product GetById(object id);

    void Add(Product Model);

    void Delete(Product model);

    void Update(Product model);
}