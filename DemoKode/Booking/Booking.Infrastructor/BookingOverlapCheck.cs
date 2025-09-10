using Booking.Domain.DomainService;
using Booking.Infrastructor.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructor;

public class BookingOverlapCheck : IBookingOverlapCheck
{
    private readonly BookingContext _db;

    public BookingOverlapCheck(BookingContext db)
    {
        _db = db;
    }

    bool IBookingOverlapCheck.IsOverlapping(Domain.Entity.Booking booking)
    {
        // Guard: if no customer, we cannot determine overlap (treat as no overlap)
        if (booking.Kunde is null) return false;

        // NOTE: Definition:
        // Intervals [A.Start, A.End) and [B.Start, B.End) overlap if:
        // A.Start < B.End AND A.End > B.Start
        // If you want "touching" (end == start) to count as overlap, change < / > to <= / >=.

        var kundeId = booking.Kunde.Id;

        return _db.Bookinger
            .AsNoTracking()
            .Where(b => b.Id != booking.Id) // exclude same booking (updates)
            .Where(b => b.Kunde.Id == kundeId) // same customer
            .Any(b =>
                b.StartTid < booking.SlutTid && // overlaps on left
                b.SlutTid > booking.StartTid); // overlaps on right
    }
}