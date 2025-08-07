// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

// This code is a simple console application that uses dependency injection to resolve a service.
// For more information on dependency injection, see https://aka.ms/dotnet-dependency-injection


var services = CreateServices();

Console.WriteLine("Hello, World!");

// Resolve the IVatCalculator service from the service provider
var vatCalculator = services.GetRequiredService<IVatCalculator>();

// Use the IVatCalculator to add VAT to an amount
var amount = 100.00m;
var amountWithVat = vatCalculator.AddVat(amount);
Console.WriteLine($"Amount with VAT: {amountWithVat}");


//Creates a service provider with the necessary services registered.
ServiceProvider CreateServices()
{
    var serviceProvider = new ServiceCollection()
        .AddScoped<ICalculator, Calculator>() // Registering the ICalculator service
        .AddScoped<IVatCalculator, Vat25Calculator>() // Registering the IVatCalculator service
        .BuildServiceProvider();
    return serviceProvider;
}