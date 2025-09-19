using System;

namespace KompositionOverArvDemo.Domaene;

public class SkiveBremse : IBremse
{
    public void Bremse() => Console.WriteLine("Bremser med skiver.");
}
