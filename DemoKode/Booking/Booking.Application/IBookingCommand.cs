namespace Booking.Application;

public interface IBookingCommand
{
    void UpdateStartTid(int id, DateTime startTid);
}