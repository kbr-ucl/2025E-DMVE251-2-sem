using Microsoft.EntityFrameworkCore;
//https://visualstudiomagazine.com/blogs/tool-tracker/2015/02/conflicting-namespaces-aliases.aspx
using Entity = Booking.Domain.Entity;

namespace Booking.Infrastructor.Database;

// Database
// https://github.com/dotnet/SqlClient/issues/2239
// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
// Add-Migration InitialMigration
// Update-Database

// https://stackoverflow.com/questions/70273434/unable-to-resolve-service-for-type-%C2%A8microsoft-entityframeworkcore-dbcontextopti
public class BookingContext : DbContext
{
    public static readonly string ConnectionString =
        "Server=localhost;" +
        "Database=BookingDb;" +
        "Trusted_Connection=True;" +
        "MultipleActiveResultSets=true;" +
        "TrustServerCertificate=True";


    // Define DbSets for your entities here
    public DbSet<Entity.Kunde> Kunder { get; set; }
    public DbSet<Entity.Booking> Bookinger { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}