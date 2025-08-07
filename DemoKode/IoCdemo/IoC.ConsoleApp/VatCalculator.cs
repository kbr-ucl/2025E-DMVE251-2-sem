/// <summary>
///     Defines a contract for calculating value-added tax (VAT).
/// </summary>
public interface IVatCalculator
{
    /// <summary>
    ///     Calculates the total amount including value-added tax (VAT) for the specified amount.
    /// </summary>
    /// <param name="amount">The original amount to which VAT will be applied. Must be a non-negative value.</param>
    /// <returns>The total amount after adding VAT to the specified <paramref name="amount" />.</returns>
    decimal AddVat(decimal amount);
}

/// <summary>
///     Provides functionality to calculate Value Added Tax (VAT) using a fixed VAT rate.
/// </summary>
/// <remarks>
///     The <see cref="Vat25Calculator" /> applies a standard VAT rate to amounts by utilizing an injected
///     <see
///         cref="ICalculator" />
///     for arithmetic operations.
/// </remarks>
public class Vat25Calculator : IVatCalculator
{
    private const decimal VatRate = 0.25m; // 25% VAT rate
    private readonly ICalculator _calculator;

    public Vat25Calculator(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public decimal AddVat(decimal amount)
    {
        var vat = _calculator.Multiply(amount, VatRate);
        return _calculator.Add(amount, vat);
    }
}