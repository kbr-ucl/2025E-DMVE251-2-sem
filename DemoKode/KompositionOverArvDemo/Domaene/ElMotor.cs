using System;

namespace KompositionOverArvDemo.Domaene;

public class ElMotor : IMotor
{
    public void Start() => Console.WriteLine("Elmotor starter lydløst.");
    public void Accelerer() => Console.WriteLine("Accelererer på el.");
    public void FyldEnergi() => Console.WriteLine("Lader batteri.");
}
