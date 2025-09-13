using Booking.Application;
using Booking.Domain.Exceptions;
using Booking.Infrastructor.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructor;

public class BookingRepository : IBookingRepository
{
    private readonly BookingContext _db;

    public BookingRepository(BookingContext db) => _db = db;

    void IBookingRepository.AddBooking(Domain.Entity.Booking booking)
    {
        _db.Bookinger.Add(booking);
        _db.SaveChanges();
    }

    Domain.Entity.Booking IBookingRepository.GetBooking(int id)
    {
        var entity = _db.Bookinger
            .Include(b => b.Kunde)
            .FirstOrDefault(b => b.Id == id);

        return entity ?? throw new NotFoundException($"Booking with id {id} was not found.");
    }

    void IBookingRepository.SaveBooking(Domain.Entity.Booking booking)
    {
        // Entity is tracked; save pending changes.
        _db.SaveChanges();
    }
}