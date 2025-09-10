namespace Booking.Domain.Entity;

public class Kunde : EntityBase
{
    public string Name { get; set; }
    public List<Booking> Bookings { get; set; } = new();
}