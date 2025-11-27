using EfCoreSqlServerImplicitFkMini.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfCoreSqlServerImplicitFkMini.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Indlæs connection string fra appsettings.json
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddEnvironmentVariables()
            .Build();

        var cs = config.GetConnectionString("Default")
                 ??
                 @"Server=localhost;Database=EfCoreImplicitFkDemoDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";

        options.UseSqlServer(cs);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Eksplicit konfiguration af relationen (konventioner ville også finde den)
    //    modelBuilder.Entity<Order>()
    //        .HasOne(o => o.Customer)
    //        .WithMany(c => c.Orders)
    //        .IsRequired() // FK bliver NOT NULL
    //        .OnDelete(DeleteBehavior.Cascade);

    //    // Hvis du vil styre navnet på shadow FK, så afkommentér og brug denne:
    //    // modelBuilder.Entity<Order>().Property<int>("KundeRefId");
    //    // modelBuilder.Entity<Order>()
    //    //     .HasOne(o => o.Customer)
    //    //     .WithMany(c => c.Orders)
    //    //     .HasForeignKey("KundeRefId")
    //    //     .IsRequired()
    //    //     .OnDelete(DeleteBehavior.Cascade);
    //}
}