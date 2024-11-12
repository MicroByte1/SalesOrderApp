




public class StockService : IStockService
{

    private readonly IUnitOfWork _unitOfWork;

    public StockService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Stock Model)
    {
        _unitOfWork.genericRepository<Stock>().Add(Model);
        _unitOfWork.Save();
    }

    public void Delete(Stock model)
    {
        _unitOfWork.genericRepository<Stock>().Delete(model);
        _unitOfWork.Save();
    }

    public IEnumerable<Stock> GetAll()
    {
        return _unitOfWork.genericRepository<Stock>().GetAll();
    }

    public Stock GetById(object id)
    {
        return _unitOfWork.genericRepository<Stock>().GetById(id);
    }

    public void Update(Stock model)
    {
        _unitOfWork.genericRepository<Stock>().Update(model);
        _unitOfWork.Save();
    }
}