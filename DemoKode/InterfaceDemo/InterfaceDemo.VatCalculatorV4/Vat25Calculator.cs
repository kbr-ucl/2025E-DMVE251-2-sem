namespace InterfaceDemo.VatCalculatorV4;

public interface IVatCalculator
{
    decimal CalculateVat(decimal amount);
}

public class Vat25Calculator : IVatCalculator
{
    private const decimal VatRate = 0.25m; // 20% VAT
    private readonly ICalculator _calculator;

    public Vat25Calculator(ICalculator calculator)
    {
        _calculator = calculator;
    }

    /// <summary>
    ///     Calculates the VAT for a given amount.
    /// </summary>
    /// <param name="amount">The amount to calculate VAT for.</param>
    /// <returns>The calculated VAT.</returns>
    decimal IVatCalculator.CalculateVat(decimal amount)
    {
        var vat = _calculator.Multiply(amount, VatRate);
        return _calculator.Add(amount, vat);
    }
}