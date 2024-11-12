using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles ="Admin, DataEntry")]
public class StockController : Controller {
    private AppContext _context;
    public StockController(AppContext context)
    {
        _context = context;
    }

    public IActionResult Index(){
        var stock = _context.Stocks.Include(x => x.Product).ToList();
        return View(stock);
    }

    public IActionResult AddProduct(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct(Stock stock, IFormFile ProductImg){
        if (ProductImg != null){
            using (var stream = new MemoryStream()){
                await ProductImg.CopyToAsync(stream);
                stock.Product.Img = stream.ToArray();
            }
        }else{
            return Content("img is null");
        }
        _context.Stocks.Add(stock);
        _context.SaveChanges();
        return Content("Added sucessfully");
    }

    public IActionResult UpdateProduct(int id){
        var stock = _context.Stocks.Include(e => e.Product).First(x => x.productId == id);
        return View(stock);
    }
    [HttpPost]
    public IActionResult UpdateProduct(int id, int quantity){
        var stock = _context.Stocks.First(x => x.productId == id);
        stock.Quantity += quantity;
        _context.SaveChanges();
        return Content("Updated Sucess");
    }


    public IActionResult EditProduct(int id){
        var stock = _context.Stocks.Include(e => e.Product).First(x => x.productId == id);
        var p  = _context.Products.First(x => x.Id == id);
        return View(p);
    }
    [HttpPost]
    public IActionResult EditProduct(Product p){
        var stock = _context.Stocks.First(x => x.productId == p.Id);
        var _Product = _context.Products.First(x => x.Id == p.Id);
        _Product.Name = p.Name;
        _Product.Number = p.Number;
        _Product.Price = p.Price;
        _Product.Type = p.Type;
        _context.SaveChanges();
        return Content("Updated Sucess");
    }
}