using Booking.Application;
using Booking.Domain.Entity;
using Booking.Domain.Exceptions;
using Booking.Infrastructor.Database;

namespace Booking.Infrastructor;

public class KundeRepository : IKundeRepository
{
    private readonly BookingContext _db;

    public KundeRepository(BookingContext db) => _db = db;

    Kunde IKundeRepository.Get(int id)
        => _db.Kunder.Find(id) ?? throw new NotFoundException($"Customer with id {id} was not found.");
}