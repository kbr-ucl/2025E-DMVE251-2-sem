using Booking.Application;
using Booking.Domain.DomainService;
using Booking.Infrastructor;
using Booking.Infrastructor.Database;
using Boooking.Port.Driving;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.CrossCut;

public static class DependencyInjection
{
    public static IServiceCollection AddBookingCore(this IServiceCollection services)
    {
        services.AddScoped<IBookingCommand, BookingCommandHandler>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingOverlapCheck, BookingOverlapCheck>();
        services.AddScoped<IBookingQuery, BookingQueryHandler>();
        services.AddScoped<IKundeRepository, KundeRepository>();

        // https://stackoverflow.com/questions/70273434/unable-to-resolve-service-for-type-%C2%A8microsoft-entityframeworkcore-dbcontextopti
        services.AddDbContext<BookingContext>();
        return services;
    }
}