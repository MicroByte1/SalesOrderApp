




public class OrderService : IOrderService
{

    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Order Model)
    {
        _unitOfWork.genericRepository<Order>().Add(Model);
        _unitOfWork.Save();
    }

    public void Delete(Order model)
    {
        _unitOfWork.genericRepository<Order>().Delete(model);
        _unitOfWork.Save();
    }

    public IEnumerable<Order> GetAll()
    {
        return _unitOfWork.genericRepository<Order>().GetAll();
    }

    public Order GetById(object id)
    {
        return _unitOfWork.genericRepository<Order>().GetById(id);
    }

    public void Update(Order model)
    {
        _unitOfWork.genericRepository<Order>().Update(model);
        _unitOfWork.Save();
    }
}