// See https://aka.ms/new-console-template for more information

using Booking.CrossCut;
using Boooking.Port.Driving;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceProvider = IocManager.RegisterService();
var bookingCommand = serviceProvider.GetService<IBookingCommand>();

bookingCommand.UpdateStartTid(new UpdateStartTidCommand(1, DateTime.Now
                                                           + new TimeSpan(0, 0, 30, 0)));

Console.WriteLine("Done");