using System.Linq;
using PriceCalculator.Models;
using PriceCalculator.Strategies;

namespace PriceCalculator.Services.Implementations;

public class PriceCalculatorService : IPriceCalculatorService
{
    private readonly DiscountStrategyFactory _strategies;

    public PriceCalculatorService(DiscountStrategyFactory discountStrategyFactory)
    {
        _strategies = discountStrategyFactory;
    }

    public CalculatedPrice CalculatePrice(Order order)
    {
        var totalPrice = order.Items.Sum(a => a.TotalPrice);
        var discount = _strategies.GetStrategy(order.Customer.Type).CalculateDiscount(totalPrice);
        var finalPrice = totalPrice - discount;

        return new CalculatedPrice
        {
            TotalPriceExclDiscount = totalPrice,
            Discount = discount,
            TotalPriceInclDiscount = finalPrice
        };
    }
}