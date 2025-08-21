namespace PriceCalculator.Strategies.Implementations
{
    public class BusinessCustomerDiscount : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal totalPrice)
        {
            if (totalPrice > 100000) return totalPrice * 0.30m;
            if (totalPrice > 75000) return totalPrice * 0.25m;
            if (totalPrice > 50000) return totalPrice * 0.20m;
            if (totalPrice > 10000) return totalPrice * 0.15m;
            return 0;
        }
    }
}
