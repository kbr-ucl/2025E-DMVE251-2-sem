// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// All-in-one 
var vatCalculatorAllInOne = new InterfaceDemo.VatCalculatorV1.Vat25Calculator();
decimal amount = 100m;
Console.WriteLine($"All-in-one: {vatCalculatorAllInOne.CalculateVat(amount)}");

// Single Responsibility Principle
var vatCalculatorSRP = new InterfaceDemo.VatCalculatorV2.Vat25Calculator();
Console.WriteLine($"Single Responsibility Principle: {vatCalculatorSRP.CalculateVat(amount)}");

// Interface Segregation Principle
var vatCalculatorISP = new InterfaceDemo.VatCalculatorV3.Vat25Calculator() as InterfaceDemo.VatCalculatorV3.IVatCalculator;
Console.WriteLine($"Interface Segregation Principle: {vatCalculatorISP.CalculateVat(amount)}");

// Dependency Inversion Principle
var vatCalculatorDIP = Factory.CreateVatCalculator();
Console.WriteLine($"Dependency Inversion Principle: {vatCalculatorDIP.CalculateVat(amount)}");


/// <summary>
/// IoC factory creating instances of implementations.
/// </summary>
public class Factory
{
    public static InterfaceDemo.VatCalculatorV4.ICalculator CreateCalculator()
    {
        return new InterfaceDemo.VatCalculatorV4.Calculator();
    }

    public static InterfaceDemo.VatCalculatorV4.IVatCalculator CreateVatCalculator()
    {
        return new InterfaceDemo.VatCalculatorV4.Vat25Calculator(CreateCalculator());
    }
}