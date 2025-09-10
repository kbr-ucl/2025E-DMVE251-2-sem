namespace Booking.Application;

public interface IBookingRepository
{
    Domain.Entity.Booking GetBooking(int id);
    void SaveBooking(Domain.Entity.Booking booking);
}