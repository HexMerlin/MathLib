using System;
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

  
}
    

