using PriceCalculator.Services;
using PriceCalculator.Services.Implementations;
using PriceCalculator.Strategies;

namespace PriceCalculator;

public class PriceCalculatorFactory
{
    public static DiscountStrategyFactory DiscountStrategyFactory { get; } = new();
    public static IPriceCalculatorService PriceCalculatorService { get; } = new PriceCalculatorService(DiscountStrategyFactory);
}