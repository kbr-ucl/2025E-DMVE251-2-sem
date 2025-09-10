// See https://aka.ms/new-console-template for more information

using Booking.Application;
using Booking.CrossCut;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceProvider = IocManager.RegisterService();
var bookingCommand = serviceProvider.GetService<IBookingCommand>();

bookingCommand.UpdateStartTid(1, DateTime.Now
                                    + new TimeSpan(0, 0, 30, 0));

Console.WriteLine("Done");
