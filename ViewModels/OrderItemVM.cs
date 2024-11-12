

public class OrderItemVM{
    public Product Product { get; set; }

    public int Quantity { get; set; }

    public OrderItem ToOrderItem(int _orderid){
        return new OrderItem{
            SalePrice= this.Product.Price,
            Quantity = this.Quantity,
            Total =  this.Product.Price * this.Quantity,
            ProductId = this.Product.Id,
            OrderId = _orderid
        };
    }
    
}