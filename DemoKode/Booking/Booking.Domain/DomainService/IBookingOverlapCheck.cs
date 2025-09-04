namespace Booking.Domain.DomainService;

public interface IBookingOverlapCheck
{
    bool IsOverlapping(Entity.Booking booking);
}