using Microsoft.Extensions.DependencyInjection;

namespace Booking.CrossCut;

public class IocManager
{
    private static ServiceProvider? ServiceProvider;

    public static ServiceProvider RegisterService()
    {
        if (ServiceProvider is not null) return ServiceProvider;
        var serviceProvider = new ServiceCollection()
            .AddBookingCore()
            .BuildServiceProvider();

        ServiceProvider = serviceProvider;
        return ServiceProvider;
    }
}