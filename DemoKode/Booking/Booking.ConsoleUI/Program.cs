// See https://aka.ms/new-console-template for more information

using Booking.ConsoleUI;
using Booking.CrossCut;
using Boooking.Port.Driving;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceProvider = IocManager.RegisterService();
Bonus.SeedDatabase(serviceProvider);

var bookingCommand = serviceProvider.GetService<IBookingCommand>();
var bookingQuery = serviceProvider.GetService<IBookingQuery>();

Console.WriteLine("---- Creating booking ---");
var bookings = bookingQuery.GetAllByKundeId(Bonus.KundeId);

foreach (var booking in bookings)
    Console.WriteLine($"Booking ID: {booking.BookingId}, Start: {booking.StartTid}, End: {booking.SlutTid}");

Console.WriteLine("---- Updating booking ---");
var bookingId = Bonus.GetBookingId(serviceProvider);
bookingCommand.UpdateBooking(new UpdateBookingCommand(Bonus.KundeId, bookingId,
    DateTime.Now + new TimeSpan(0, 0, 30, 0), DateTime.Now + new TimeSpan(0, 1, 0, 0)));


Console.WriteLine("---- Creating booking ---");
bookingCommand.CreateBooking(new CreateBookingCommand(1, DateTime.Now + new TimeSpan(0, 1, 30, 0),
    DateTime.Now + new TimeSpan(0, 2, 0, 0)));

Console.WriteLine("Done");