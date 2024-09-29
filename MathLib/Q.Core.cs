
using System.Diagnostics;
using System.Numerics;

namespace MathLib;
public partial class Q
{

    /// <summary>
    /// This version always sets FEO mode.
    /// </summary>
    protected BigInteger IntegralPartAlwaysFEO => Numerator / Denominator;

    /// <summary>
    /// This version selects between FIO and FEO mode.
    /// </summary>
    /// <remarks>
    /// This property needs to replace the existing version to come in to effect.
    /// Current implementation is provided only to give an understanding.
    /// </remarks>
    /// <param name="fio">If <see langword="true"/> FIO mode, otherwise FEO mode</param>
    protected BigInteger IntegralPartSelective(bool fio)
        => fio && IsNonZeroInteger
                ? (Numerator / Denominator) - Sign
                : (Numerator / Denominator); //FEO

    private static (BigInteger Numerator, BigInteger Denominator) Normalize(BigInteger numerator, BigInteger denominator, bool normalize)
    {
        if (denominator.IsZero)
            return (BigInteger.Zero, BigInteger.Zero); //return NaN

        if (numerator.IsZero) //always denominator 1 for Zero
            return (numerator, BigInteger.One);

        if (denominator < BigInteger.Zero) //negative Denominator, move sign to numerator
            (numerator, denominator) = (-numerator, -denominator); //switch sign

        if (normalize)
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator.Abs(), denominator.Abs());
            if (gcd != BigInteger.One)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
        }
        else
        {

            //In Debug build only: check if constructor was called with an incorrect normalize=false 
            Debug.Assert(BigInteger.GreatestCommonDivisor(numerator.Abs(), denominator.Abs()).IsOne,
                "Serious error: Unsafe constructor was called with arguments that required normalize=true.");
        }

        return (numerator, denominator);
    }

    public partial string ToStringSimple()
        => IsNaN
            ? nameof(NaN)
            : Denominator.IsOne
                ? Numerator.ToString()
                : $"{Numerator}/{Denominator}";
}