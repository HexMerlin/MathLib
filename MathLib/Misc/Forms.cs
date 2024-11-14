﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using MathLib;

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
    /// Converts a specified <paramref name="integer"/> into a sequence of constrained digits 
    /// based on the constraints provided in <paramref name="constraints"/>.
    /// </summary>
    /// <remarks>
    /// This method generates a sequence representing <paramref name="integer"/> as a weighted
    /// sum in base-2, adhering to constraints in <paramref name="constraints"/>.
    /// Each constraint specifies:
    /// <list type="bullet">
    /// <item><description>The maximum absolute value of the corresponding digit.</description></item>
    /// <item><description>The parity requirement (odd/even) based on the parity of the constraint.</description></item>
    /// </list>
    /// The minimum length of <paramref name="constraints"/> is 3, and the first and last elements 
    /// are always <c>1</c>, ensuring that the sequence starts and ends with either -1 or 1.
    ///
    /// The resulting sequence meets the following conditions:
    /// <list type="number">
    /// <item><description>Its length matches the length of <paramref name="constraints"/>.</description></item>
    /// <item><description>The weighted sum of the sequence, using powers of 2 (1, 2, 4, 8, ...), equals <paramref name="integer"/>.</description></item>
    /// <item><description>Each digit in the sequence meets both the absolute value and parity requirements specified by the corresponding constraint.</description></item>
    /// <item><description>The first and last digits are constrained to either -1 or 1.</description></item>
    /// </list>
    /// </remarks>
    /// <param name="integer">The target integer value to represent as a sequence of constrained digits.</param>
    /// <param name="constraints">A list of non-negative integers, each defining constraints for the respective position in the sequence.</param>
    /// <returns>An array of integers representing <paramref name="integer"/> as a sequence of constrained digits.</returns>
    /// <example>
    /// <code>
    /// ToBalancedDigits(1, new int[] { 1, 1 })  => [-1, 1]  //1 = 1 * 2^0 + 1 * 2^1)
    ///
    /// ToBalancedDigits(-1, new int[] { 1, 1 }) => [1, -1] //-1 = 1 * 2^0 + (-1) * 2^1)
    ///
    /// ToBalancedDigits(-25, new int[] { 1, 2, 3, 2, 1 }) => [-1, -2, -1, 0, -1] //-25 = -1 * 2^0 + (-2) * 2^1 + (-1) * 2^2 + 0 * 2^3 + (-1) * 2^4)
    /// </code>
    /// </example>
    public static int[] ToBalancedDigits(BigInteger integer, int[] constraints)
    {
        BigInteger Weight(int i) => BigInteger.One << i;
        int n = constraints.Length;

        List<List<int>> allowedDigits = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            int c = constraints[i];
            int parity = c.Mod(2);
            int maxAbs = Math.Abs(c);
            List<int> digits = new List<int>();
            for (int d = -maxAbs; d <= maxAbs; d++)
            {
                if (d.Mod(2) == parity)
                {
                    digits.Add(d);
                }
            }
            allowedDigits.Add(digits);
        }

        // Enforce digits at the first and last positions to be -1 or 1
        allowedDigits[0] = allowedDigits[0].Where(d => d is (-1) or 1).ToList();
        allowedDigits[n - 1] = allowedDigits[n - 1].Where(d => d is (-1) or 1).ToList();

        Dictionary<(int position, BigInteger currentSum), List<int>?> memo = new ();

        List<int>? Search(int position, BigInteger currentSum)
        {
            if (memo.TryGetValue((position, currentSum), out List<int>? memoResult))
                return memoResult;
           
            if (position == n)
            {
                return (currentSum == integer) ? new List<int>() : null;
            }

            BigInteger minRemaining = BigInteger.Zero;
            BigInteger maxRemaining = BigInteger.Zero;
            for (int i = position; i < n; i++)
            {
                int minD = allowedDigits[i].Min();
                int maxD = allowedDigits[i].Max();
                minRemaining += minD * Weight(i);
                maxRemaining += maxD * Weight(i);
            }

            foreach (int digit in allowedDigits[position])
            {
                BigInteger newSum = currentSum + digit * Weight(position);
                if (newSum + minRemaining > integer || newSum + maxRemaining < integer)
                    continue;
                var subResult = Search(position + 1, newSum);
                if (subResult != null)
                {
                    var result = new List<int> { digit };
                    result.AddRange(subResult);
                    memo[(position, currentSum)] = result;
                    return result;
                }
            }

            memo[(position, currentSum)] = null;
            return null;
        }

        return Search(0, BigInteger.Zero)?.ToArray() ?? Array.Empty<int>();
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
}
    

