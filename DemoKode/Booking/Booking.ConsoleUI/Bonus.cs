using Booking.Domain.Entity;
using Booking.Infrastructor.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.ConsoleUI;

public class Bonus
{
    // Dette er en bonus-klasse til at illustrere, at du kan tilføje ekstra funktionalitet her.
    // Du kan f.eks. tilføje metoder til at håndtere specielle scenarier eller hjælpefunktioner.
    public static int KundeId { get; private set; }

    public static void SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BookingContext>();
        // Tilføj seed data til databasen her
        db.Database.EnsureCreated();
        // Eksempel på at tilføje en kunde
        if (!db.Kunder.Any())
        {
            db.Kunder.Add(new Kunde { Name = "Kaj" });
            db.SaveChanges();
        }

        var kunde = db.Kunder.First(a => a.Name == "Kaj");
        KundeId = kunde.Id;
        if (!db.Bookinger.Any())
        {
            db.Bookinger.Add(new Domain.Entity.Booking(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), kunde,
                serviceProvider));
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