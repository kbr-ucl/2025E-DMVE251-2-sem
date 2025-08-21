namespace PriceCalculator.Strategies.Implementations
{
    public class PublicOrNonProfitDiscount : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal totalPrice)
        {
            return totalPrice * 0.20m;
        }
    }
}
