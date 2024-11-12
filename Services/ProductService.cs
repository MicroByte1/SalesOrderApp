


public class ProductService : IProductService
{

    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Product Model)
    {
        _unitOfWork.genericRepository<Product>().Add(Model);
        _unitOfWork.Save();
    }

    public void Delete(Product model)
    {
        _unitOfWork.genericRepository<Product>().Delete(model);
        _unitOfWork.Save();
    }

    public IEnumerable<Product> GetAll()
    {
        return _unitOfWork.genericRepository<Product>().GetAll();
    }

    public Product GetById(object id)
    {
        return _unitOfWork.genericRepository<Product>().GetById(id);
    }

    public void Update(Product model)
    {
        _unitOfWork.genericRepository<Product>().Update(model);
        _unitOfWork.Save();
    }
}