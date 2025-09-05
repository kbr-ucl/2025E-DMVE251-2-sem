// See https://aka.ms/new-console-template for more information

using Booking.Application;
using Booking.CrossCut;

Console.WriteLine("Hello, World!");

var serviceProvider = IocManager.RegisterService();
var bookingCommand = serviceProvider.GetService(typeof(IBookingCommand)) as IBookingCommand;

bookingCommand.UpdateStartTid(DateTime.Now 
                              + new TimeSpan(0,0,30,0));

Console.WriteLine("Done");
