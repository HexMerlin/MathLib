using System;
using System.Numerics;

namespace MathLib;
public static class IntExtensions
{
    /// <summary>
    /// Computes the modulus of an <see cref="int"/> in the same way as in languages like 
    /// Python, Haskell, Julia and Matlab.
    /// The result follows the mathematical definition of modulus where the remainder always has the same sign as 
    /// the divisor, ensuring predictable results for both positive and negative values.
    /// </summary>
    /// <remarks>
    /// The result of the modulus operation is adjusted based on the sign of <paramref name="modulus"/>:
    /// <para>When <paramref name="modulus"/> is positive, the result is in the range [0, modulus)</para>
    /// <para>When <paramref name="modulus"/> is negative, the result is in the range (modulus, 0].</para>
    ///
    /// This method provides consistent behavior for modulus operations, similar to how it is implemented 
    /// in Python, Haskell, Julia, and Matlab.
    /// </remarks>
    /// <param name="integer">The <see cref="int"/> value to compute the modulus for.</param>
    /// <param name="modulus">The modulus value. Must be non-zero.</param>
    /// <returns>
    /// The remainder when <paramref name="integer"/> is divided by <paramref name="modulus"/>, adjusted to 
    /// follow the same sign as <paramref name="modulus"/>.
    /// </returns>
    /// <example>
    /// <para>Examples:</para>
    /// <code>
    /// int result1 = 10.Mod(3);  // 1
    /// int result2 = (-10).Mod(3); // 2
    /// int result3 = 10.Mod(-3); // -2
    /// int result4 = (-10).Mod(-3); // -1
    /// </code>
    /// </example>
    /// <exception cref="DivideByZeroException">
    /// Thrown when <paramref name="modulus"/> is zero.
    /// </exception>
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

    /// <summary>
    /// Returns a value indicating the sign of the specified <paramref name="integer"/>.
    /// </summary>
    /// <param name="integer">The 32-bit signed integer to check.</param>
    /// <returns>A number that indicates the sign of <paramref name="integer"/>.</returns>
    public static int Sign(this int integer) => Math.Sign(integer);

    /// <summary>
    /// Returns the absolute value of the specified <paramref name="integer"/>.
    /// </summary>
    /// <param name="integer">The 32-bit signed integer to check.</param>
    /// <returns>The absolute value of <paramref name="integer"/>.</returns>
    public static int Abs(this int integer) => Math.Abs(integer);
}
