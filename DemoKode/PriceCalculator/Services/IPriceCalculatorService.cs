using PriceCalculator.Models;

namespace PriceCalculator.Services;

public interface IPriceCalculatorService
{
    CalculatedPrice CalculatePrice(Order order);
}
