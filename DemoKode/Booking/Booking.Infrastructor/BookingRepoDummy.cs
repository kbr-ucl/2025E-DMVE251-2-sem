using Booking.Application;
using Booking.Domain.Entity;

namespace Booking.Infrastructor;

public class BookingRepoDummy : IBookingRepository
{
    private readonly IServiceProvider _serviceProvider;

    public BookingRepoDummy(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    Domain.Entity.Booking IBookingRepository.GetBooking()
    {
        var start = DateTime.Now +
                    new TimeSpan(0, 1, 0, 0);
        var slut = DateTime.Now +
                   new TimeSpan(0, 2, 0, 0);
        return new Domain.Entity.Booking(start, slut, new Kunde(), _serviceProvider);
    }

    void IBookingRepository.SaveBooking(Domain.Entity.Booking booking)
    {
    }
}