using System;
using System.Numerics;

namespace MathLib;
public static class IntExtensions
{
    public static int Mod(this int integer, int modulus)
    {
        if (modulus == 0)
            throw new DivideByZeroException("The divisor must not be zero.");

        return (integer % modulus + modulus) % modulus;
    }

    /// <summary>
    /// Indicates whether the specified <paramref name="integer"/> is odd.
    /// </summary>
    /// <param name="integer">The 32-bit signed integer to check.</param>
    /// <returns>
    /// <see langword="true"/> <c>iff</c> <paramref name="integer"/> is odd; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsOdd(this int integer) => (integer & 1) != 0;

    /// <summary>
    /// Indicates whether the specified <paramref name="integer"/> is even.
    /// </summary>
    /// <param name="integer">The 32-bit signed integer to check.</param>
    /// <returns>
    /// <see langword="true"/> <c>iff</c> <paramref name="integer"/> is even; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsEven(this int integer) => (integer & 1) == 0;
}
