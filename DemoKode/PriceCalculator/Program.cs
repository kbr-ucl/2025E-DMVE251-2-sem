using System;
using System.Collections.Generic;
using PriceCalculator.Models;
using PriceCalculator.Services;
using PriceCalculator.Services.Implementations;

namespace PriceCalculator;

class Program
{
    static void Main()
    {
        var order = new Order
        {
            Customer = new Customer{ Type= CustomerType.Private },
            Items = new List<CartItem>
            {
                new CartItem { Name = "Laptop", UnitPrice = 1200, Quantity = 1 },
                new CartItem { Name = "Mouse", UnitPrice = 200, Quantity = 2 }
            }
        };


        var calculator = PriceCalculatorFactory.PriceCalculatorService;

        var result = calculator.CalculatePrice(order);

        Console.WriteLine($"Pris før rabat: {result.TotalPriceExclDiscount:C}");
        Console.WriteLine($"Rabat: {result.Discount:C}");
        Console.WriteLine($"Pris efter rabat: {result.TotalPriceInclDiscount:C}");
    }
}