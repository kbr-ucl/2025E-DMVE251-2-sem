using Booking.Domain.DomainService;
using Booking.Infrastructor.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructor;

public class BookingOverlapCheck : IBookingOverlapCheck
{
    private readonly BookingContext _db;

    public BookingOverlapCheck(BookingContext db) => _db = db;

    bool IBookingOverlapCheck.HasOverlap(int kundeId, DateTime start, DateTime end, int? excludeBookingId)
    {
        var query = _db.Bookinger
            .AsNoTracking()
            .Where(b => b.Kunde.Id == kundeId);

        if (excludeBookingId is int excludeId)
            query = query.Where(b => b.Id != excludeId);

        // Overlap for half-open intervals: [start, end)
        return query.Any(b => b.StartTid < end && b.SlutTid > start);
    }
}