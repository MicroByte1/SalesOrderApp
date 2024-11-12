

using System.Security.Claims;

public class OrderVM{
    public int Id { get; set; }
    public int Number { get; set; }

    public DateTime Date { get; set; }

    public Decimal Total { get; set; }

    public Status Status { get; set; }

    public int UserId { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; set; }
    public OrderVM(int userid)
    {
        Random random = new Random();
        Number = random.Next(1, 1000);
        Date = DateTime.Now;
        Status = Status.New;
        UserId = userid;
    }

    public Order MakeOrder(List<OrderItemVM> orderItemVMs){
        OrderItems = orderItemVMs.Select(x => x.ToOrderItem(Number));
        Total = OrderItems.Sum(x => x.Total);
        return new Order{
            Number = this.Number,
            Date = this.Date,
            Status = this.Status,
            Total = this.Total,
            OrderItems = this.OrderItems.ToList(),
            UserId = this.UserId

        };
    }

}