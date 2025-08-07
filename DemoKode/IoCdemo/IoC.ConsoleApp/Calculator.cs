/// <summary>
///     Defines the contract for performing basic arithmetic operations on decimal values.
/// </summary>
public interface ICalculator
{
    decimal Add(decimal a, decimal b);
    decimal Multiply(decimal a, decimal b);
}

/// <summary>
///     Provides functionality for performing basic arithmetic operations such as addition and multiplication.
/// </summary>
public class Calculator : ICalculator
{
    decimal ICalculator.Add(decimal a, decimal b)
    {
        return a + b;
    }

    decimal ICalculator.Multiply(decimal a, decimal b)
    {
        return a * b;
    }
}