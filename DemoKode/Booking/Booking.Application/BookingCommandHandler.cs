namespace Booking.Application;

public class BookingCommandHandler : IBookingCommand
{
    private readonly IBookingRepository _repo;

    public BookingCommandHandler(IBookingRepository repo)
    {
        _repo = repo;
    }

    void IBookingCommand.UpdateStartTid(int id, DateTime startTid)
    {
        // Load
        var booking = _repo.GetBooking(id);

        // Do
        booking.UpdateStartSlut(startTid, booking.SlutTid);

        // Save
        _repo.SaveBooking(booking);
    }
}