namespace Boooking.Port.Driving;

public interface IBookingCommand
{
    void UpdateStartTid(UpdateStartTidCommand command);
}

public record UpdateStartTidCommand(int Id, DateTime StartTid);