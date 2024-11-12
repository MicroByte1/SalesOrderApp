


using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem {

    public int Id { get; set; }

    public decimal SalePrice { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }

    public Order Order { get; set; }
    public int OrderId { get; set; }
 }