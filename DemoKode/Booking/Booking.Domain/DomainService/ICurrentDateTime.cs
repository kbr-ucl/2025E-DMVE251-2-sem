namespace Booking.Domain.DomainService;

public interface ICurrentDateTime
{
    public DateTime Now();
}

public class CurrentDateTime : ICurrentDateTime
{
    DateTime ICurrentDateTime.Now()
    {
        return DateTime.Now;
    }
}
