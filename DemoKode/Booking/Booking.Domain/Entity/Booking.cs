using Booking.Domain.DomainService;

namespace Booking.Domain.Entity;

public class Booking
{
    private IBookingOverlapCheck _overlapCheck;
    public DateTime StartTid { get; private set; }
    public DateTime SlutTid { get; private set; }
    public Kunde Kunde { get; private set; }

    public Booking(DateTime start, DateTime slut, Kunde kunde, IServiceProvider serviceProvider)
    {
        ResolveDependencies(serviceProvider);
        TimesIsValid(start);
        NoOverlap(start, slut);
        if (_overlapCheck.IsOverlapping(this)) throw new Exception("Overlap");

        Kunde = kunde;
        StartTid = start;
        SlutTid = slut;
    }

    private void ResolveDependencies(IServiceProvider serviceProvider)
    {
        _overlapCheck = serviceProvider.GetService(typeof(IBookingOverlapCheck)) as IBookingOverlapCheck ??
                        throw new Exception("Could not resolve IBookingOverlapCheck");
    }

    public void UpdateStartSlut(DateTime start, DateTime slut)
    {
        TimesIsValid(start);
        TimesIsValid(StartTid);
        NoOverlap(start, slut);

        StartTid = start;
        SlutTid = slut;
    }

    private void TimesIsValid(DateTime start)
    {
        if (DateTime.Now > start) throw new Exception("Booking is in the past");
    }

    //En Booking må ikke overlappende andre bookinger.
    private void NoOverlap(DateTime start, DateTime slut)
    {
    }
}