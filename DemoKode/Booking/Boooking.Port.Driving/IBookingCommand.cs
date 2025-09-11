namespace Boooking.Port.Driving;

public interface IBookingCommand
{
    /// <summary>
    /// Som kunde vil jeg kunne ændre en af mine bookings
    /// </summary>
    /// <param name="command"></param>
    void UpdateBooking(UpdateBookingCommand command);

    /// <summary>
    /// Som kunde vil jeg kunne oprette en ny booking til mig
    /// </summary>
    /// <param name="command"></param>
    void CreateBooking(CreateBookingCommand command);
}

public record CreateBookingCommand(int KundeId, DateTime StartTid, DateTime SlutTid);

public record UpdateBookingCommand(int KundeId, int BookingId, DateTime StartTid, DateTime SlutTid);