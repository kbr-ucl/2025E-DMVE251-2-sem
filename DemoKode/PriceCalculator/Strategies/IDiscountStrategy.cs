namespace PriceCalculator.Strategies
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal totalPrice);
    }
}
