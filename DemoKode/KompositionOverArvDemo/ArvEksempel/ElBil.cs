using System;

namespace KompositionOverArvDemo.ArvEksempel;

public class ElBil : BilBase
{
    public override void Start() => Console.WriteLine("[ARV] Elbil: motor starter lydløst.");
    public override void Accelerer() => Console.WriteLine("[ARV] Elbil accelererer.");
    public override void FyldEnergi() => Console.WriteLine("[ARV] Lader batteri.");
}
