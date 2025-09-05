using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Domain.DomainService;

namespace Booking.Infrastructor
{
    public class BookingOverlapCheck : IBookingOverlapCheck
    {
        bool IBookingOverlapCheck.IsOverlapping(Domain.Entity.Booking booking)
        {
            return false;
        }
    }
}
