using Booking.Application;
using Booking.Domain.Entity;
using Booking.Infrastructor.Database;

namespace Booking.Infrastructor;

public class KundeRepository : IKundeRepository
{
    private readonly BookingContext _db;

    public KundeRepository(BookingContext db)
    {
        _db = db;
    }

    Kunde IKundeRepository.Get(int id)
    {
        return _db.Kunder.Find(id) ?? throw new Exception("Kunde not found");
    }
}