using Boooking.Port.Driving;

namespace Booking.Application;

public class BookingCommandHandler : IBookingCommand
{
    private readonly IKundeRepository _kundeRepository;
    private readonly IBookingRepository _repo;
    private readonly IServiceProvider _serviceProvider;

    public BookingCommandHandler(IBookingRepository bookingRepository, IKundeRepository kundeRepository,
        IServiceProvider serviceProvider)
    {
        _repo = bookingRepository;
        _kundeRepository = kundeRepository;
        _serviceProvider = serviceProvider;
    }

    void IBookingCommand.CreateBooking(CreateBookingCommand command)
    {
        // Load
        var kunde = _kundeRepository.Get(command.KundeId);

        // Do
        var booking = new Domain.Entity.Booking(command.StartTid, command.SlutTid, kunde, _serviceProvider);

        // Save
        _repo.AddBooking(booking);
    }

    void IBookingCommand.UpdateBooking(UpdateBookingCommand command)
    {
        // Load
        var booking = _repo.GetBooking(command.BookingId);
        if (command.KundeId != booking.Kunde.Id) throw new Exception("Booking tilhører ikke kunde");

        // Do
        booking.UpdateStartSlut(command.StartTid, command.SlutTid);

        // Save
        _repo.SaveBooking(booking);
    }
}