using Booking.Domain.Entity;

namespace Booking.Application;

public interface IKundeRepository
{
    Kunde Get(int id);
}