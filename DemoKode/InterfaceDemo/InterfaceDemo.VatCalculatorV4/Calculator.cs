namespace InterfaceDemo.VatCalculatorV4;

public interface ICalculator
{
    decimal Add(decimal a, decimal b);
    decimal Multiply(decimal a, decimal b);
}

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