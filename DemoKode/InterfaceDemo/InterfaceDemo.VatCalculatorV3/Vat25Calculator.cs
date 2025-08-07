namespace InterfaceDemo.VatCalculatorV3;

public interface IVatCalculator
{
    decimal CalculateVat(decimal amount);
}

public class Vat25Calculator : IVatCalculator
{
    private const decimal VatRate = 0.25m; // 20% VAT

    /// <summary>
    ///     Calculates the VAT for a given amount.
    /// </summary>
    /// <param name="amount">The amount to calculate VAT for.</param>
    /// <returns>The calculated VAT.</returns>
    decimal IVatCalculator.CalculateVat(decimal amount)
    {
        ICalculator calculator = new Calculator();
        var vat = calculator.Multiply(amount, VatRate);
        return calculator.Add(amount, vat);
    }
}