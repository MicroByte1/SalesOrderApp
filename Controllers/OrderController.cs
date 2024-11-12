


using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
[Authorize]
public class OrderController : Controller {


    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }
    [Authorize(Roles ="Admin")]
    public IActionResult Index(string searchVal){
        var orders = _service.GetAll();
        if (searchVal != null){
            int searchNumber = int.Parse(searchVal);
            orders = orders.Where(x => x.Number == searchNumber || x.UserId== searchNumber).ToList();
        }
        return View(orders);
    }
    [Authorize(Roles ="Admin, DataEntry")]
    public IActionResult Details(int id){
        var orderModel = _service.GetById(id);
        return View(orderModel);
    }


    [HttpGet]
    public IActionResult SaveOrder(){
        //List<OrderVM> VMS = new List<OrderVM>();
        string res = "Empty";
        List<OrderItemVM> products = new List<OrderItemVM>();
       
        res = HttpContext.Session.GetString("products");
        if (res == null || res == "Empty"){
            return PartialView("EmptyOrder");
        }
        products = JsonConvert.DeserializeObject<List<OrderItemVM>>(res);

        return View(products);
    }
    [HttpPost]
    public IActionResult SaveOrder(int id){
        //List<OrderVM> VMS = new List<OrderVM>();
        //List<OrderItemVM>? products;
       
        string? res = HttpContext.Session.GetString("products");
        if (res != null){
            List<OrderItemVM>? products = JsonConvert.DeserializeObject<List<OrderItemVM>>(res);
            //OrderVM orderVM = new OrderVM();
            if (products.Count > 0){
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Order orderModel = new OrderVM(int.Parse(userid)).MakeOrder(products);
                _service.Add(orderModel);
                HttpContext.Session.Remove("products");
                return PartialView("Thanks"); 

            }
            
        }
        
        return Content("Can not save order now Maybe Order is Null");  
    }





    public IActionResult PayOrder(int id){
        Order? orderModel = _service.GetById(id);
        if (orderModel != null){
            orderModel.Status = Status.Paid;
            _service.Update(orderModel);
        }else{
            return Content("Order Not Avilable");
        }
        return Content("Order Payied Sucessfully");
    }
}