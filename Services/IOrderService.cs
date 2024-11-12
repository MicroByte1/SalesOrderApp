


public interface IOrderService {

    IEnumerable<Order> GetAll();

    Order GetById(object id);

    void Add(Order Model);

    void Delete(Order model);

    void Update(Order model);
}