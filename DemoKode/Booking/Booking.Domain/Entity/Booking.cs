using Booking.Domain.DomainService;
using Booking.Domain.Exceptions;

namespace Booking.Domain.Entity;

public class Booking : EntityBase
{
    public DateTime StartTid { get; private set; }
    public DateTime SlutTid { get; private set; }
    public Kunde Kunde { get; }

    // EF Only
    protected Booking()
    {
    }

    public Booking(DateTime start, DateTime slut, Kunde kunde, IBookingOverlapCheck overlapCheck)
    {
        if (kunde is null) throw new ArgumentNullException(nameof(kunde));
        ValidateTimes(start, slut);
        OverlapCheck(overlapCheck, kunde.Id, start, slut);

        Kunde = kunde;
        StartTid = start;
        SlutTid = slut;
    }

    private void OverlapCheck(IBookingOverlapCheck overlapCheck, int kundeId, DateTime start, DateTime slut,
        int? excludeBookingId = null)
    {
        // Validate business rule (no overlap)
        if (overlapCheck.HasOverlap(kundeId, start, slut))
            throw new ValidationException("The booking overlaps an existing booking.");
    }

    public void UpdateStartSlut(DateTime start, DateTime slut, IBookingOverlapCheck overlapCheck)
    {
        ValidateTimes(start, slut);
        OverlapCheck(overlapCheck, Kunde.Id, start, slut, Id);
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