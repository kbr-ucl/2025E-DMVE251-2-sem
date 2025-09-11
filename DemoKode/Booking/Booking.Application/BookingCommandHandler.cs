using Boooking.Port.Driving;

namespace Booking.Application;

public class BookingCommandHandler : IBookingCommand
{
    private readonly IBookingRepository _repo;

    public BookingCommandHandler(IBookingRepository repo)
    {
        _repo = repo;
    }

    void IBookingCommand.UpdateStartTid(UpdateStartTidCommand command)
    {
        // Load
        var booking = _repo.GetBooking(command.Id);

        // Do
        booking.UpdateStartSlut(command.StartTid, booking.SlutTid);

        // Save
        _repo.SaveBooking(booking);
    }
}