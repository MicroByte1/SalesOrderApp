using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
public class ProductsController : Controller {
    private readonly IProductService _service;

    public ProductsController( IProductService service)
    { 
        _service = service;
    }


    public IActionResult Index(string searchVal){
        var products = _service.GetAll().OrderBy(x => x.Type).ToList();
        if (searchVal != null){
            products = products.Where(x => x.Number == searchVal || x.Name.ToLower().Contains(searchVal.ToLower())).ToList();
        }
        //var products = _context.Products.OrderBy(x => x.Type).ToList();
        //var products = _service.GetAll().OrderBy(x => x.Type).ToList();
        return View(products);
    }

    [Authorize]
    [HttpPost]
    public IActionResult AddToCard(int ProductId){
        List<OrderItemVM> productList;

        string res = HttpContext.Session.GetString("products");
        if (res == null){
            productList = new List<OrderItemVM>();

            var prod = _service.GetById(ProductId);
            OrderItemVM orderVM = new OrderItemVM{
                Product = prod,
                Quantity =1
            };

            productList.Add(orderVM);
        }else{
            productList = JsonConvert.DeserializeObject<List<OrderItemVM>>(res);
            var condition = productList.Find(x => x.Product.Id == ProductId);
            if (condition != null){
                condition.Quantity++;
            }
            else{
                var prod = _service.GetById(ProductId);
                OrderItemVM orderVM = new OrderItemVM{
                    Product = prod,
                    Quantity =1
                };
                productList.Add(orderVM);
            }
            
        }


        string objectAsString = JsonConvert.SerializeObject(productList);
        HttpContext.Session.SetString("products", objectAsString);
        //TempData["id"] = res;


        string? urlReferrer = null;
        if (Request.Headers.ContainsKey("Referer"))
        {
            urlReferrer = Request.Headers["Referer"]!.ToString();
        }
        
        return Redirect(urlReferrer);
        //return Content(res);
    }

    [Authorize]
    [HttpPost]
    public IActionResult RemoveFromCard(int ProductId){
        List<OrderItemVM> productList;

        string res = HttpContext.Session.GetString("products");
        if (res == null){
  
            return RedirectToAction("Index");
        }else{
            productList = JsonConvert.DeserializeObject<List<OrderItemVM>>(res);
            var condition = productList.Find(x => x.Product.Id == ProductId);
            if (condition != null){
                condition.Quantity--;
                if (condition.Quantity <= 0)
                    productList.Remove(condition);
            }
        }


        string objectAsString = JsonConvert.SerializeObject(productList);
        HttpContext.Session.SetString("products", objectAsString);
        //TempData["id"] = res;
        string? urlReferrer = null;
        if (Request.Headers.ContainsKey("Referer"))
        {
            urlReferrer = Request.Headers["Referer"]!.ToString();
        }
        
        return Redirect(urlReferrer);
        //return Content(res);
    }
    


}