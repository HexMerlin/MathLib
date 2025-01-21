#nullable enable
using MathLib.Compatibility;
using System;
using System.Numerics;

namespace MathLib;

/// <summary>
/// Provides a set of extension methods for the <see cref="BigInteger"/> struct, enabling additional functionality
/// such as determining whether a number is odd, computing its absolute value, and calculating its bit length.
/// It also provides the Extended Euclidean algorithm for computing GCD and Bézout coefficients.
/// </summary>
public static class BigIntegerExtensions
{

     
    /// <summary>
    /// Indicates whether the specified <see cref="BigInteger"/> value is odd.
    /// </summary>
    /// <param name="integer">The <see cref="BigInteger"/> value to check.</param>
    /// <returns><see langword="true"/> <c>iff</c><paramref name="integer"/> is odd.</returns>
    public static bool IsOdd(this BigInteger integer) => !integer.IsEven;

    /// <summary>
    /// Absolute value of the specified <paramref name="integer"/> value.
    /// </summary>
    /// <param name="integer">The <see cref="BigInteger"/> value whose absolute value is to be computed.</param>
    /// <returns>A <see cref="BigInteger"/> representing the absolute value of the input.</returns>
    public static BigInteger Abs(this BigInteger integer) => BigInteger.Abs(integer);

    /// <summary>
    /// Indicates whether two specified <see cref="BigInteger"/> values are coprime.
    /// </summary>
    /// <param name="a">The first <see cref="BigInteger"/> value.</param>
    /// <param name="b">The second <see cref="BigInteger"/> value.</param>
    /// <returns><see langword="true"/> <c>iff</c> <paramref name="a"/> and <paramref name="b"/> are coprime.</returns>
    public static bool Coprime(this BigInteger a, BigInteger b)
        => BigInteger.GreatestCommonDivisor(a, b).IsOne;

    /// <summary>
    /// Indicates whether the specified <see cref="BigInteger"/> value is divisible by the specified divisor.
    /// </summary>
    /// <param name="integer">The <see cref="BigInteger"/> value to check.</param>
    /// <param name="divisor">The divisor to check against.</param>
    /// <returns><see langword="true"/> <c>iff</c> the value is divisible by the divisor.</returns>
    public static bool IsDivisibleBy(this BigInteger integer, BigInteger divisor) => (integer % divisor).IsZero;


    /// <summary>
    /// Computes the modulus of a <see cref="BigInteger"/> in the same way as in languages like 
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
    /// <param name="integer">The <see cref="BigInteger"/> value to compute the modulus for.</param>
    /// <param name="modulus">The modulus value. Must be non-zero.</param>
    /// <returns>
    /// The remainder when <paramref name="integer"/> is divided by <paramref name="modulus"/>, adjusted to 
    /// follow the same sign as <paramref name="modulus"/>.
    /// </returns>
    /// <example>
    /// <para>Examples:</para>
    /// 
    /// <code>
    /// BigInteger result1 = new BigInteger(10).Mod(3);  // 1
    /// BigInteger result2 = new BigInteger(-10).Mod(3); // 2
    /// BigInteger result3 = new BigInteger(10).Mod(-3); // -2
    /// BigInteger result4 = new BigInteger(-10).Mod(-3); // -1
    /// </code>
    /// </example>
    /// <exception cref="DivideByZeroException">
    /// Thrown when <paramref name="modulus"/> is zero.
    /// </exception>
    public static BigInteger Mod(this BigInteger integer, BigInteger modulus)
    {
        if (modulus == 0)
            throw new DivideByZeroException("The divisor must not be zero.");

        return (integer % modulus + modulus) % modulus;
    }


    /// <summary>
    /// Modulo operation yielding the remainder (positive or negative) with the smallest absolute value, 
    /// preserving congruence under the specified modulus.
    /// </summary>
    /// <param name="integer">Dividend, an integer.</param>
    /// <param name="modulus">Modulus, a positive integer.</param>
    /// <returns>The integer <c>r</c> closest to zero for which there exists an integer <c>k</c> such that 
    /// <c>n = k × mod + r</c>, and <c>-mod/2 ≤ r ≤ mod/2</c>.</returns>
    /// <remarks>
    /// For both positive and negative <paramref name="integer"/>, the result minimizes <c>|r|</c>, providing a "balanced" or symmetric result. 
    /// This is useful in contexts where closeness to zero is desired, such as balanced systems or modular 
    /// arithmetic with minimal magnitude deviation.
    /// 
    /// For example:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <c>4 Mod 7</c> yields <c>-3</c> instead of <c>4</c>, as <c>-3</c> is closer to zero.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <c>9 Mod 7</c> yields <c>2</c>, as <c>2</c> is already closest to zero.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public static BigInteger ModMinAbs(this BigInteger integer, BigInteger modulus)
    {
        modulus = modulus.Abs();
        BigInteger result = integer % modulus;
        BigInteger half = modulus / 2;
        if (result > half) return result - modulus;
        if (result < -half) return result + modulus;
        return result;
    }

    /// <summary>
    /// Returns the Least Common Multiple of two integers
    /// </summary>
    /// <example>LCM(4, 6) = 12, since 12 is both a multiple of 4 (4*3) and a multiple of 6 (6*2) </example>
    /// <param name="first">The first integer</param>
    /// <param name="second">The second integer</param>
    /// <returns>LCM of <paramref name="first"/> and <paramref name="second"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="first"/> or <paramref name="second"/> is zero.
    /// </exception>
    public static BigInteger LCM(this BigInteger first, BigInteger second)
    {
        ArgOutOfRangeException.ThrowIfZero(first, nameof(first));
        ArgOutOfRangeException.ThrowIfZero(second, nameof(second));
        return (first.Abs() / BigInteger.GreatestCommonDivisor(first, second)) * second.Abs();
    }

    /// <summary>
    /// Returns the number of coefficients (or digits) required to represent this  
    /// <see cref="BigInteger"/> in a specified base.
    /// </summary>
    /// <remarks>
    /// If this <see cref="BigInteger"/> is <c>0</c>, the result is always <c>0</c>, regardless of the base.
    /// <para>If this <see cref="BigInteger"/> is negative, the result will be the same as for its absolute value.</para>
    /// <para>If the base <paramref name="base_"/> is less than <c>2</c>, this method returns <c>0</c>, 
    /// following the behavior of <see cref="BigInteger.Log(BigInteger, double)"/>.</para>
    /// </remarks>
    /// <param name="integer">The <see cref="BigInteger"/> to calculate the coefficient count for.</param>
    /// <param name="base_">The base in which this <see cref="BigInteger"/> will be represented. Must be greater than <c>1</c> for meaningful results.</param>
    /// <returns><para>The number of coefficients required to represent this <see cref="BigInteger"/> in base <paramref name="base_"/>.</para>
    /// <para><c>0</c> if <paramref name="base_"/> is less than <c>2</c>.</para></returns>
    public static int Length(this BigInteger integer, int base_)
    {      
        if (integer.IsZero) return 0;
        if (base_ < 2) return 0;
     
        int len = 1;
        for (BigInteger ceiling = base_; ceiling <= integer.Abs(); ceiling *= base_, len++) { }
        return len;
    }


    /// <summary>
    /// Indicates whether the specified <see cref="BigInteger"/> value is a power of the specified exponent.
    /// </summary>
    /// <param name="integer">The <see cref="BigInteger"/> value to check.</param>
    /// <param name="exponent">The exponent to check against.</param>
    /// <returns><see langword="true"/> <c>iff</c> the value is a power of the exponent.</returns>
    public static bool IsPowerOf(this BigInteger integer, int exponent)
    {
        ArgOutOfRangeException.ThrowIfNegative(integer, nameof(integer));
        ArgOutOfRangeException.ThrowIfNegative(exponent, nameof(exponent));

        if (exponent == 0) return integer.IsOne;  // Only 1^0 = 1, no other number raised to 0 gives anything but 1.
        if (exponent == 1) return integer.IsOne;  // Only 1 is a power of 1.
#if RELEASE
            if (exponent == 2) return integer.IsPowerOfTwo; 
#endif
        if (integer.IsOne) return true;  // 1^anything = 1
        if (integer.IsZero) return false;  // 0 can only be a power of a positive exponent, and we handle 0^0 earlier.

        BigInteger power = BigInteger.One;

        while (power < integer)
            power *= exponent;
        return power == integer;
    }

    /// <summary>
    /// Computes the modular inverse of a number <paramref name="integer"/> under a given modulus <paramref name="modulus"/>.
    /// </summary>
    /// <remarks>
    /// The modular inverse of <paramref name="integer"/> modulo <paramref name="modulus"/> is a number <c>x</c> such that:
    /// 
    /// <code>
    /// integer ⋅ x ≡ 1 (mod modulus)
    /// </code>
    /// This method uses the Extended Euclidean Algorithm to compute the inverse. 
    /// <para>The result of this method is always in the range [0, <paramref name="modulus"/>), as it is normalized by applying the modulus operation.</para>
    /// </remarks>
    /// <param name="integer">The number for which the modular inverse is to be computed. Must be greater than or equal to 1.</param>
    /// <param name="modulus">The modulus under which the inverse is computed. Must be greater than or equal to 2.</param>
    /// <returns>
    /// The modular inverse of <paramref name="integer"/> modulo <paramref name="modulus"/>. 
    /// The result is normalized to be within the range [0, <paramref name="modulus"/>).
    /// </returns>
    /// <example>
    /// 
    /// <code>
    /// BigInteger result1 = new BigInteger(3).ModularInverse(7);  // 5
    /// BigInteger result2 = new BigInteger(2).ModularInverse(11); // 6
    /// </code>
    /// </example>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="integer"/> is less than 1 <c>or</c> if <paramref name="modulus"/> is less than 2.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="integer"/> and <paramref name="modulus"/> are not coprime, i.e., if the greatest common divisor of the two is not 1.
    /// </exception>
    public static BigInteger ModularInverse(this BigInteger integer, BigInteger modulus)
    {
        ArgOutOfRangeException.ThrowIfLessThan(integer, 1, nameof(integer)); // Negative numbers and zero are not supported.
        ArgOutOfRangeException.ThrowIfLessThan(modulus, 2, nameof(modulus)); // Inverse does not exist for modulus less than 2

        BigInteger remainder = modulus;
        (BigInteger x0, BigInteger x1) = (BigInteger.Zero, BigInteger.One);

        while (integer > 1)
        {
            if (remainder.IsZero)
                throw new ArgumentException($"Modular inverse does not exist (arguments {integer} and {modulus} are not coprime)");

            BigInteger q = integer / remainder;
            (integer, remainder) = (remainder, integer % remainder);
            (x0, x1) = (x1 - q * x0, x0);
        }
        return x1.Mod(modulus);
    }

    /// <summary>
    /// Implements the extended Euclidean algorithm to compute the greatest common divisor (GCD) of two <see cref="BigInteger"/> values
    /// and the corresponding Bézout coefficients.
    /// </summary>
    /// <remarks>
    /// For two integers <paramref name="a"/> and <paramref name="b"/>, this method computes the GCD, denoted as gcd(a, b),
    /// and finds integers 'x' and 'y' such that Bézout's identity is satisfied:
    /// 
    /// <code>
    /// a·x + b· y = gcd(a, b)
    /// </code>
    /// </remarks>
    /// <param name="a">The first <see cref="BigInteger"/>.</param>
    /// <param name="b">The second <see cref="BigInteger"/>.</param>
    /// <returns>
    /// A tuple containing three <see cref="BigInteger"/> values:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The greatest common divisor (gcd) of <paramref name="a"/> and <paramref name="b"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The Bézout coefficient 'x' (corresponding to <paramref name="a"/> in Bézout's identity).
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The Bézout coefficient 'y' (corresponding to <paramref name="b"/> in Bézout's identity).
    /// </description>
    /// </item>
    /// </list>
    /// </returns>
    public static (BigInteger gcd, BigInteger x, BigInteger y) ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b)
    {
        (BigInteger r0, BigInteger r1) = (a, b);
        (BigInteger s0, BigInteger s1) = (BigInteger.One, BigInteger.Zero);
        (BigInteger t0, BigInteger t1) = (BigInteger.Zero, BigInteger.One);

        while (!r1.IsZero)
        {
            BigInteger quotient = r0 / r1;
            (r0, r1) = (r1, r0 - quotient * r1);
            (s0, s1) = (s1, s0 - quotient * s1);
            (t0, t1) = (t1, t0 - quotient * t1);
        }

        // r0 now holds the GCD, and s0 and t0 are the Bézout coefficients
        return (r0, s0, t0);
    }

    /// <summary>
    /// Parses the string representation of a number in the specified base to its <see cref="BigInteger"/> equivalent.
    /// </summary>
    /// <param name="input">The string representation of the number to parse. It may start with a '-' to indicate a negative number.</param>
    /// <param name="fromBase">The base of the input number, ranging from 2 to 36.</param>
    /// <returns>A <see cref="BigInteger"/> representation of the parsed value.</returns>
    /// <example>
    /// <code>
    /// Console.WriteLine(Parse("-10.011", 2));  //outputs "-19/8"
    /// </code>
    /// </example>
    /// <exception cref="ArgumentException">Thrown if <paramref name="fromBase"/> is not within 2 to 36.</exception>
    public static BigInteger Parse(string input, int fromBase)
    {
        if (fromBase is < 2 or > 36)
            throw new ArgumentException($"Base must be between 2 and 36, but was {fromBase}.");
       
        bool isNegative = input.StartsWith('-');
        int startIndex = isNegative ? 1 : 0; // Start after '-' if negative

        BigInteger result = BigInteger.Zero;
        BigInteger multiplier = BigInteger.One;

        for (int i = input.Length - 1; i >= startIndex; i--)
        {
            char c = input[i];

            int coeffValue = c switch
            {
                >= '0' and <= '9' => c - '0',
                >= 'A' and <= 'Z' => c - 'A' + 10,
                >= 'a' and <= 'z' => c - 'a' + 10,
                _ => throw new ArgumentException($"Invalid character '{c}' in input string.")
            };

            if (coeffValue >= fromBase)
                throw new ArgumentException($"Invalid character '{c}' for base {fromBase}.");
            
            result += coeffValue * multiplier;
            multiplier *= fromBase;
        }

        return isNegative ? -result : result;
    }
}
