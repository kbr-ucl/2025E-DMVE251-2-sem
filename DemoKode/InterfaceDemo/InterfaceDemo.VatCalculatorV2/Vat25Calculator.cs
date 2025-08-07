namespace InterfaceDemo.VatCalculatorV2
{
    public class Vat25Calculator
    {
        private const decimal VatRate = 0.25m; // 20% VAT
        /// <summary>
        /// Calculates the VAT for a given amount.
        /// </summary>
        /// <param name="amount">The amount to calculate VAT for.</param>
        /// <returns>The calculated VAT.</returns>
        public decimal CalculateVat(decimal amount)
        {
            var calculator = new Calculator();
            var vat = calculator.Multiply(amount, VatRate);
            return calculator.Add(amount, vat);
        }
    }
}
