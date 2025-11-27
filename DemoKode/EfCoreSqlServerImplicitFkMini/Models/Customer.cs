
namespace EfCoreSqlServerImplicitFkMini.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public List<Order> Orders { get; set; } = new();
}
