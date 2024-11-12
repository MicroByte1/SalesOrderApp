

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Order {
    public int Id { get; set; }

    public int Number { get; set; }

    public DateTime Date { get; set; }

    public Decimal Total { get; set; }

    public Status Status { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    [ForeignKey("AppUser")]
    public int UserId { get; set; }

    public AppUser AppUser { get; set; }
}