namespace EfValueObjectAsJson.DemoApi.Data;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}