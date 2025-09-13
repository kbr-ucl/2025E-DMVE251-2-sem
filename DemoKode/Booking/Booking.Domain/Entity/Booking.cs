using Booking.Domain.Exceptions;

namespace Booking.Domain.Entity;

public class Booking : EntityBase
{
    public DateTime StartTid { get; private set; }
    public DateTime SlutTid { get; private set; }
    public Kunde Kunde { get; private set; }

    // EF Only
    protected Booking() { }

    public Booking(DateTime start, DateTime slut, Kunde kunde)
    {
        if (kunde is null) throw new ArgumentNullException(nameof(kunde));
        ValidateTimes(start, slut);

        Kunde = kunde;
        StartTid = start;
        SlutTid = slut;
    }

    public void UpdateStartSlut(DateTime start, DateTime slut)
    {
        ValidateTimes(start, slut);
        StartTid = start;
        SlutTid = slut;
    }

    private static void ValidateTimes(DateTime start, DateTime slut)
    {
        if (start >= slut)
            throw new ValidationException("Start time must be before end time.");
        if (start <= DateTime.Now)
            throw new ValidationException("Start time must be in the future.");
    }
}