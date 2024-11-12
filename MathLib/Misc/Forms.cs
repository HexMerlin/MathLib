using System;
using System.Collections.Generic;
using System.Numerics;

namespace MathLib.Misc;

/// <summary>
/// Provides methods for converting integers to various forms such as Non-Adjacent Form (NAF) and balanced binary form.
/// </summary>
public static class Forms
{
    /// <summary>
    /// Converts a <see cref="BigInteger"/> to its Non-Adjacent Form (NAF), 
    /// a sparse representation where no two adjacent digits are non-zero.
    /// </summary>
    /// <param name="integer">The integer to convert.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="int"/> values representing the 
    /// Non-Adjacent Form of <paramref name="integer"/>, with each element being 0, 1, or -1.
    /// </returns>
    /// <remarks>
    /// The Non-Adjacent Form (NAF) minimizes the number of non-zero bits, which is useful in 
    /// contexts like cryptographic algorithms for efficiency.
    /// </remarks>
    public static IEnumerable<int> ToNonAdjacentForm(this BigInteger integer)
    {
        BigInteger k = BigInteger.Abs(integer);
        int sign = integer.Sign;

        while (k != 0)
        {
            int z;
            if (k % 2 != 0)
            {
                z = 2 - (int)(k % 4);
                if (z == 2)
                    z = -1;
                k -= z;
            }
            else
            {
                z = 0;
            }
            yield return sign * z;
            k /= 2;
        }
    }

    /// <summary>
    /// Converts a <see cref="BigInteger"/> to its balanced binary form, where each bit is either -1 or 1.
    /// </summary>
    /// <param name="integer">The integer to convert. Must be odd.</param>
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
    public static IEnumerable<int> ToBalancedBinary(this BigInteger integer)
    {
        if (integer.IsEven)
            throw new ArgumentException("The balanced binary form can only represent odd numbers.");

        BigInteger rem = integer;
        for (int index = 0; ; index++)
        {
            int digit = BalancedBit(integer, index, rem.Abs().IsOne);
            yield return digit;
            rem -= digit;
            rem /= 2;
            if (rem == 0)
                break;
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
        BigInteger div = BigInteger.One << (index + 2);
        BigInteger mod = number.ModMinAbs(div);
        return isLastDigit ? mod.Sign : -mod.Sign;
    }
}
    

