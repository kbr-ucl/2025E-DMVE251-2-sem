using Booking.Application;
using Booking.Infrastructor.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructor;

public class BookingRepository : IBookingRepository
{
    private readonly BookingContext _db;

    public BookingRepository(BookingContext db)
    {
        _db = db;
    }

    void IBookingRepository.AddBooking(Domain.Entity.Booking booking)
    {
        _db.Bookinger.Add(booking);
        _db.SaveChanges();
    }

    Domain.Entity.Booking IBookingRepository.GetBooking(int id)
    {
        return _db.Bookinger.Include(b => b.Kunde).First(b => b.Id == id) ?? throw new Exception("Booking not found");
    }

    void IBookingRepository.SaveBooking(Domain.Entity.Booking booking)
    {
        _db.SaveChanges();
    }
}