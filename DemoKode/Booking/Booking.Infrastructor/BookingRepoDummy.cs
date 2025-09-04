using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Application;
using Booking.Domain.Entity;

namespace Booking.Infrastructor
{
    public class BookingRepoDummy : IBookingRepository
    {
        Domain.Entity.Booking IBookingRepository.GetBooking()
        {
            var start = DateTime.Now +
                        new TimeSpan(0, 1, 0, 0);
            var slut = DateTime.Now +
                       new TimeSpan(0, 2, 0, 0);
            return new Domain.Entity.Booking(start, slut, new Kunde());
        }

        void IBookingRepository.SaveBooking(Domain.Entity.Booking booking)
        {

        }
    }
}
