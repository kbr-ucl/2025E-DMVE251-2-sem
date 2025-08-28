// See https://aka.ms/new-console-template for more information

using EjendomsberegnerConsoleAppAfter;

Console.WriteLine("Hello, World!");
var beregnerService = new EjendomBeregnerService();
double kvadratmeter = beregnerService.BeregnKvadratmeter();
Console.WriteLine($"Ejendommens samlede kvadratmeter er: {kvadratmeter}");
