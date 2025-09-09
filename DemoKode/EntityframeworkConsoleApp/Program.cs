// See https://aka.ms/new-console-template for more information

using EntityframeworkConsoleApp;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var db = new BookingContext();
var kunden = db.Kunden.Include(k => k.Bookings).ToList();
Console.WriteLine("Kundeliste");
foreach (var kunde in kunden)
{
    Console.WriteLine($"Kunde: {kunde.Name}");
    foreach (var booking in kunde.Bookings)
    {
        Console.WriteLine($"  Booking: {booking.Id}, Dato: {booking.Date}, Service: {booking.Service}");
    }
    Console.WriteLine("-----------------------");
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Bookings:");
var bookings = db.Bookings.Include(b => b.Kunde).ToList();
foreach (var booking in bookings)
{
    Console.WriteLine($"Booking: {booking.Id}, Kunde: {booking.Kunde.Name}, Dato: {booking.Date}, Service: {booking.Service}");
}

