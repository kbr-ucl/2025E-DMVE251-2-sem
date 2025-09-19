using System;

namespace KompositionOverArvDemo.Domaene;

public class Bil
{
    private IMotor _motor;
    private IBremse _bremse;

    public Bil(IMotor motor, IBremse bremse)
    {
        _motor = motor ?? throw new ArgumentNullException(nameof(motor));
        _bremse = bremse ?? throw new ArgumentNullException(nameof(bremse));
    }

    public void Kør()
    {
        _motor.Start();
        _motor.Accelerer();
    }

    public void FyldEnergi() => _motor.FyldEnergi();

    public void Nødstop() => _bremse.Bremse();

    public void SkiftMotor(IMotor nyMotor) => _motor = nyMotor ?? throw new ArgumentNullException(nameof(nyMotor));

    public void SkiftBremse(IBremse nyBremse) => _bremse = nyBremse ?? throw new ArgumentNullException(nameof(nyBremse));
}
