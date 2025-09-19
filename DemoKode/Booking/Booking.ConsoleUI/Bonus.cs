using Booking.Domain.Entity;
using Booking.Infrastructor.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.ConsoleUI;

public class Bonus
{
    public static int KundeId { get; private set; }

    public static void SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BookingContext>();
        var overlapCheck = scope.ServiceProvider.GetRequiredService<Booking.Domain.DomainService.IBookingOverlapCheck>();
        var now = scope.ServiceProvider.GetRequiredService<Booking.Domain.DomainService.ICurrentDateTime>();

        db.Database.EnsureCreated();

        if (!db.Kunder.Any())
        {
            db.Kunder.Add(new Kunde { Name = "Kaj" });
            db.SaveChanges();
        }

        var kunde = db.Kunder.First(a => a.Name == "Kaj");
        KundeId = kunde.Id;

        if (!db.Bookinger.Any())
        {
            // Seed with a non-overlapping booking
            db.Bookinger.Add(new Domain.Entity.Booking(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), kunde, overlapCheck, now));
            db.SaveChanges();
        }
    }

    public static int GetBookingId(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BookingContext>();
        return db.Bookinger.First(a => a.Kunde.Id == KundeId).Id;
    }
}