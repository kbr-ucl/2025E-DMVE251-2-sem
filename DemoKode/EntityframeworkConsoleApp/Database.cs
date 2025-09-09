using Microsoft.EntityFrameworkCore;

namespace EntityframeworkConsoleApp;

public class Kunde
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Booking> Bookings { get; set; } = new();
}

public class Booking
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Service { get; set; }
    public Kunde Kunde { get; set; }
}

public class BookingContext : DbContext
{
    public static readonly string ConnectionString =
        "Server=localhost;" +
        "Database=ConsoleBookingDb;" +
        "Trusted_Connection=True;" +
        "MultipleActiveResultSets=true;" +
        "TrustServerCertificate=True";

    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    // Database
    // https://github.com/dotnet/SqlClient/issues/2239
    // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
    // Add-Migration InitialMigration
    // Update-Database
}