using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathLib.Misc;
public static class BalDigits
{
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

        var allowedDigits = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            int c = constraints[i];
            int parity = c.Mod(2);
            int maxAbs = Math.Abs(c);
            var digits = new List<int>();
            for (int d = -maxAbs; d <= maxAbs; d++)
                if (d.Mod(2) == parity)
                    digits.Add(d);
            allowedDigits.Add(digits);
        }

        // Enforce digits at the first and last positions to be -1 or 1
        allowedDigits[0] = allowedDigits[0].Where(d => d is (-1) or 1).ToList();
        allowedDigits[n - 1] = allowedDigits[n - 1].Where(d => d is (-1) or 1).ToList();

        Dictionary<(int position, BigInteger currentSum), List<int>?> memo = new();

        List<int>? Search(int position, BigInteger currentSum)
        {
            if (memo.TryGetValue((position, currentSum), out List<int>? memoResult))
                return memoResult;

            if (position == n)
                return currentSum == integer ? new List<int>() : null;

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
    public static int[] ToBalancedDigits(BigInteger integer, int xLength, int yLength)
    {
        int[] constraints = Counts(xLength, yLength).ToArray();
        return ToBalancedDigits(integer, constraints);
    }

    public static int Count(int index, int length)
    {
        if (length.IsEven())
            throw new ArgumentException("Length must be odd", nameof(length));
        if (index < 0 || index >= length)
            throw new ArgumentOutOfRangeException(nameof(index));

        return index <= length / 2
                ? index + 1
                : length - index;
    }

    public static int Count(int index, int xLength, int yLength)
    {
        (int max, int min) = xLength >= yLength ? (xLength, yLength) : (yLength, xLength);
        return index >= 0 && index < min + max - 1
            ? index < min - 1 
                ? index + 1 
                : index < max 
                    ? min 
                    : max + min - 1 - index
            : 0;    
    }

    public static IEnumerable<int> Counts(int xLength, int yLength) => Enumerable.Range(0, xLength + yLength - 1).Select(i => Count(i, xLength, yLength));

   
    public static string DigitString(this IEnumerable<int> balDigits, int digitWidth) 
        => balDigits.Select(c => c.ToString().PadLeft(digitWidth)).Str();

}
