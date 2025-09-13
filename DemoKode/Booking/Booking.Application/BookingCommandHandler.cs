using Booking.Domain.DomainService;
using Booking.Domain.Exceptions;
using Boooking.Port.Driving;

namespace Booking.Application;

public class BookingCommandHandler : IBookingCommand
{
    private readonly IKundeRepository _kundeRepository;
    private readonly IBookingRepository _repo;
    private readonly IBookingOverlapCheck _overlapCheck;

    public BookingCommandHandler(
        IBookingRepository bookingRepository,
        IKundeRepository kundeRepository,
        IBookingOverlapCheck overlapCheck)
    {
        _repo = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        _kundeRepository = kundeRepository ?? throw new ArgumentNullException(nameof(kundeRepository));
        _overlapCheck = overlapCheck ?? throw new ArgumentNullException(nameof(overlapCheck));
    }

    void IBookingCommand.CreateBooking(CreateBookingCommand command)
    {
        // Load
        var kunde = _kundeRepository.Get(command.KundeId);

        // Validate business rule (no overlap)
        if (_overlapCheck.HasOverlap(kunde.Id, command.StartTid, command.SlutTid))
            throw new ValidationException("The booking overlaps an existing booking.");

        // Do
        var booking = new Domain.Entity.Booking(command.StartTid, command.SlutTid, kunde);

        // Save
        _repo.AddBooking(booking);
    }

    void IBookingCommand.UpdateBooking(UpdateBookingCommand command)
    {
        // Load
        var booking = _repo.GetBooking(command.BookingId);
        if (command.KundeId != booking.Kunde.Id)
            throw new OwnershipException("Booking does not belong to the specified customer.");

        // Validate business rule (no overlap)
        if (_overlapCheck.HasOverlap(command.KundeId, command.StartTid, command.SlutTid, command.BookingId))
            throw new ValidationException("The booking overlaps an existing booking.");

        // Do
        booking.UpdateStartSlut(command.StartTid, command.SlutTid);

        // Save
        _repo.SaveBooking(booking);
    }
}