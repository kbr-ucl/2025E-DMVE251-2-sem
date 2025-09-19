using System;

namespace KompositionOverArvDemo.Domaene;

public class BenzinMotor : IMotor
{
    public void Start() => Console.WriteLine("Benzinmotor starter.");
    public void Accelerer() => Console.WriteLine("Accelererer på benzin.");
    public void FyldEnergi() => Console.WriteLine("Tanker benzin.");
}
