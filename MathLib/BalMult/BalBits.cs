using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.BalMult;
public static class BalBits
{

    public static string BitString(this IEnumerable<int> balBits) => balBits.Select(c => c == 1 ? '+' : '-').Str();

    public static string BitString(this IEnumerable<int> balBits, int bitWidth) => balBits.Select(c => new string (' ', Math.Max(0, bitWidth - 1)) + (c == 1 ? '+' : '-')).Str();

    /// <summary>Same as <see cref="BalBits.ToBalancedBits(BigInteger, int)"/> but for Int32 type</summary>
    public static IEnumerable<int> ToBalancedBits(this int integer, int minLength = 0)
    {
        if (integer.IsEven())
            throw new ArgumentException("The balanced binary form can only represent odd numbers.");
        int length = 0;

        int rem = integer;
        for (int index = 0; ; index++)
        {
            int digit = BalancedBit(integer, index, rem.Abs() == 1);
            rem -= digit;
            rem /= 2;
            length++;

            if (rem != 0)
                yield return digit;
            else
            {
                while (length < minLength)
                {
                    yield return -digit;
                    length++;
                }
                yield return digit;
                yield break;
            }

        }
    }

    /// <summary>
    /// Converts a <see cref="BigInteger"/> to its balanced binary form, where each bit is either -1 or 1.
    /// </summary>
    /// <param name="integer">The integer to convert. Must be odd.</param>
    /// <param name="minLength"> The minimum length of the resulting balanced bit sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="int"/> values representing the balanced binary form of 
    /// <paramref name="integer"/>, where each bit is either -1 or 1.
    /// </returns>
    /// <remarks>
    /// The balanced binary form provides a unique, minimal-magnitude representation for each odd integer, 
    /// utilizing only the digits -1 and 1. This form is symmetric around zero, meaning that positive and 
    /// negative values are represented with the same minimal magnitude in each position.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="integer"/> is even, as the balanced binary form is defined only for odd integers.
    /// </exception>
    public static IEnumerable<int> ToBalancedBits(this BigInteger integer, int minLength = 0)
    {
        if (integer.IsEven)
            throw new ArgumentException("The balanced binary form can only represent odd numbers.");
        int length = 0;

        BigInteger rem = integer;
        for (int index = 0; ; index++)
        {
            int digit = BalancedBit(integer, index, rem.Abs().IsOne);
            rem -= digit;
            rem /= 2;
            length++;

            if (rem != 0)
                yield return digit;
            else
            {
                while (length < minLength)
                {
                    yield return -digit;
                    length++;
                }
                yield return digit;
                yield break;
            }

        }
    }

    /// <summary>
    /// Computes the "balanced bit" at the specified position in a <see cref="BigInteger"/>, 
    /// used in representing the number in a balanced binary form.
    /// </summary>
    /// <param name="number">The integer from which to extract the balanced bit.</param>
    /// <param name="index">The zero-based index of the bit position.</param>
    /// <param name="isLastDigit">
    /// A <see cref="bool"/> value indicating if the bit at <paramref name="index"/> 
    /// is the last digit in the balanced binary representation.
    /// </param>
    /// <returns>
    /// Returns <c>-1</c> for negative and <c>1</c> for positive, representing the balanced bit at the specified 
    /// index.
    /// </returns>
    /// <remarks>
    /// A "balanced bit" system uses the set {-1, 1} at each position to represent both positive 
    /// and negative values. This method is part of converting numbers into balanced binary form.
    /// </remarks>
    private static int BalancedBit(BigInteger number, int index, bool isLastDigit)
    {
        BigInteger mod = BigInteger.One << (index + 2);
        BigInteger rem = number.ModMinAbs(mod);
        return isLastDigit ? rem.Sign : -rem.Sign;
    }

    public static int BalancedBit(int number, int index, bool isLastDigit)
    {
        int mod = 1 << (index + 2);
        int rem = number.ModMinAbs(mod);
        return isLastDigit ? rem.Sign() : -(rem.Sign());
    }
}
