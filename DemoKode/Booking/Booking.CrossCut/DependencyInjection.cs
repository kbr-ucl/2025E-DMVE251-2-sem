using Booking.Application;
using Booking.Domain.DomainService;
using Booking.Infrastructor;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.CrossCut;

public static class DependencyInjection
{
    public static IServiceCollection AddBookingCore(this IServiceCollection services)
    {
        services.AddScoped<IBookingCommand, BookingCommandHandler>();
        services.AddScoped<IBookingRepository, BookingRepoDummy>();
        services.AddScoped<IBookingOverlapCheck, BookingOverlapCheck>();
        return services;
    }
}