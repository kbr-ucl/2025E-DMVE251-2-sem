namespace Boooking.Port.Driving;

public interface IBookingQuery
{
    /// <summary>
    ///     Som kunde vil jeg kunne se alle mine bookings
    /// </summary>
    /// <param name="kundeId"></param>
    /// <returns></returns>
    List<BookingDto> GetAllByKundeId(int kundeId);
}

public record BookingDto(int KundeId, int BookingId, DateTime StartTid, DateTime SlutTid);