using Booking.Application;
using Booking.Infrastructor;
using Booking.Domain.DomainService;
using Microsoft.Extensions.DependencyInjection;
namespace Booking.CrossCut
{
    public class IocManager
    {
        private static ServiceProvider? ServiceProvider;
        public static ServiceProvider RegisterService()
        {
            if (ServiceProvider is not null) return ServiceProvider;
            var serviceProvider = new ServiceCollection()
                .AddScoped<IBookingCommand, BookingCommandHandler>()
                .AddScoped<IBookingRepository, BookingRepoDummy>()
                .AddScoped<IBookingOverlapCheck, BookingOverlapCheck>()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;
            return ServiceProvider;

        }
    }
}
