using System;

namespace KompositionOverArvDemo.ArvEksempel;

public class BenzinBil : BilBase
{
    public override void Start() => Console.WriteLine("[ARV] Benzinbil: motor starter.");
    public override void Accelerer() => Console.WriteLine("[ARV] Benzinbil accelererer.");
    public override void FyldEnergi() => Console.WriteLine("[ARV] Tanker benzin.");
}
