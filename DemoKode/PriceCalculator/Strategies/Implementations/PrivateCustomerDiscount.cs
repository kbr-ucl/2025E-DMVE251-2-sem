namespace PriceCalculator.Strategies.Implementations
{
    public class PrivateCustomerDiscount : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal totalPrice)
        {
            if (totalPrice > 10000) return totalPrice * 0.20m;
            if (totalPrice > 5000) return totalPrice * 0.15m;
            if (totalPrice > 1000) return totalPrice * 0.10m;
            return 0;
        }
    }
}
