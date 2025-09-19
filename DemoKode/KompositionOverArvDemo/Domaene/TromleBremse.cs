using System;

namespace KompositionOverArvDemo.Domaene;

public class TromleBremse : IBremse
{
    public void Bremse() => Console.WriteLine("Bremser med tromler.");
}
