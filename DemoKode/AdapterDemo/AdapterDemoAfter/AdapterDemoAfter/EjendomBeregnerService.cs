namespace AdapterDemoAfter;

/// <summary>
/// EjendomBeregnerService er "Clienten" i Adapter-mønstret.
/// </summary>
public class EjendomBeregnerService
{
    private readonly ILejemaalListTarget _lejemaalListTarget;

    public EjendomBeregnerService(ILejemaalListTarget lejemaalListTarget)
    {
        _lejemaalListTarget = lejemaalListTarget;
    }

    /// <summary>
    ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
    /// </summary>
    /// 
    /// <returns></returns>
    public double BeregnKvadratmeter()
    {
        var lejemaalene = _lejemaalListTarget.HentLejemaal();
        double kvadratmeter = 0.0;

        foreach (Lejemaal lejemaal in lejemaalene)
        {
            kvadratmeter += lejemaal.Kvadratmeter;
        }
        return kvadratmeter;
    }


}

public interface ILejemaalListTarget
{
    List<Lejemaal> HentLejemaal();
}

public class Lejemaal
{
    public int Lejlighednummer { get; set; }
    public double Kvadratmeter { get; set; }
    public int AntalRum { get; set; }
}