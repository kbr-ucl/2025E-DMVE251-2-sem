using Microsoft.EntityFrameworkCore;

namespace EfValueObjectAsJson.DemoApi.Data;

public class OrderContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Item> Items => Set<Item>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(x =>
        {
            x.ComplexCollection<OrderItem>(y => y.Items, y =>
            {
                y.IsRequired();
                y.ToJson();
            });
        });
        base.OnModelCreating(modelBuilder);
    }
}