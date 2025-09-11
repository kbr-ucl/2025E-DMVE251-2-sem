namespace Booking.Application;

public interface IBookingRepository
{
    void AddBooking(Domain.Entity.Booking booking);
    Domain.Entity.Booking GetBooking(int id);
    void SaveBooking(Domain.Entity.Booking booking);
}