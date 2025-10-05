namespace CPU_boundTaskDemo;

public class MyMath
{
// Returnerer true hvis n er primtal
    public static bool IsPrime(long n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        var limit = (long)Math.Floor(Math.Sqrt(n));
        for (long d = 3; d <= limit; d += 2)
            if (n % d == 0)
                return false;
        return true;
    }
}