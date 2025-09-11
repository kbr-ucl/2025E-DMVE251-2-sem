using Booking.Infrastructor.Database;
using Boooking.Port.Driving;

namespace Booking.Infrastructor;

public class BookingQueryHandler : IBookingQuery
{
    private readonly BookingContext _db;

    public BookingQueryHandler(BookingContext db)
    {
        _db = db;
    }

    List<BookingDto> IBookingQuery.GetAllByKundeId(int kundeId)
    {
        return _db.Bookinger
            .Where(b => b.Kunde.Id == kundeId)
            .Select(b => new BookingDto(b.Kunde.Id, b.Id, b.StartTid, b.SlutTid))
            .ToList();
    }
}