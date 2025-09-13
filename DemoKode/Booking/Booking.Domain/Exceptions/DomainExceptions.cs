namespace Booking.Domain.Exceptions;

public class DomainException(string message) : Exception(message);

public sealed class NotFoundException(string message) : DomainException(message);

public sealed class ValidationException(string message) : DomainException(message);

public sealed class OwnershipException(string message) : DomainException(message);