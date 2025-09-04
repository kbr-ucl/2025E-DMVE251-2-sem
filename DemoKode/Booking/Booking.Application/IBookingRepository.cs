namespace Booking.Application;

public interface IBookingRepository
{
    Domain.Entity.Booking GetBooking();
    void SaveBooking(Domain.Entity.Booking booking);
}