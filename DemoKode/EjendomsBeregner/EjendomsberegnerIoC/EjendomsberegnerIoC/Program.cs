// See https://aka.ms/new-console-template for more information

using EjendomsberegnerIoC;
using Microsoft.Extensions.DependencyInjection;

var services = CreateServices();
// Resolve the IVatCalculator service from the service provider
var kvmCalculator = services.GetRequiredService<IEjendomBeregnerService>();


Console.WriteLine("Hello, World!");

double kvadratmeter = kvmCalculator.BeregnKvadratmeter();
Console.WriteLine($"Ejendommens samlede kvadratmeter er: {kvadratmeter}");




ServiceProvider CreateServices()
{
    var serviceProvider = new ServiceCollection()
        .AddScoped<IEjendomBeregnerService, EjendomBeregnerService>() // Registering the ICalculator service
        .AddScoped<EjendomBeregnerService.ILejemaalRepository, EjendomBeregnerService.LejemaalFraFilRepository>() // Registering the IVatCalculator service
        .BuildServiceProvider();
    return serviceProvider;
}
