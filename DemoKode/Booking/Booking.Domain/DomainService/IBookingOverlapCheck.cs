namespace Booking.Domain.DomainService;

public interface IBookingOverlapCheck
{
    // Returns true if any existing booking for the given customer overlaps the given interval.
    // excludeBookingId is used during updates to ignore the current booking in the check.
    bool HasOverlap(int kundeId, DateTime start, DateTime end, int? excludeBookingId = null);
}