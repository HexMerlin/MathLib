using System;
using System.Numerics;
using MathLib.Compatibility;


namespace MathLib;

/// <summary>
/// Contains extensions for base in number representations.
/// </summary>
public static class Base 
{
    /// <summary>
    /// Checks if the given rational number is purely periodic in the current base.
    /// </summary>
    /// <param name="base_">The base.</param>
    /// <param name="q">The rational number to check.</param>
    /// <returns><see langword="true"/> <c>iff</c> the rational number is purely periodic.</returns>
    public static bool IsPurelyPeriodic(this int base_, Q q) => q.Denominator.Coprime(base_);

    /// <summary>
    /// Raises the base to the specified exponent.
    /// </summary>
    /// <param name="base_">The base.</param>
    /// <param name="exponent">The exponent.</param>
    /// <returns>The result of raising the base to the exponent.</returns>
    public static Q Pow(this int base_, int exponent) => exponent switch
    {
        > 0 => new Q(BigInteger.Pow(base_, exponent)),
        < 0 => new Q(BigInteger.One, BigInteger.Pow(base_, -exponent), false),
        _ => Q.One,
    };

}
