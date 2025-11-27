
namespace EfCoreSqlServerImplicitFkMini.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    // Reference-navigation – ingen eksplicit CustomerId property
    public Customer Customer { get; set; } = default!;
}
