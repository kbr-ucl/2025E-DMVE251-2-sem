namespace PriceCalculator.Models
{
    public class CalculatedPrice
    {
        public decimal TotalPriceExclDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPriceInclDiscount { get; set; }
    }
}
