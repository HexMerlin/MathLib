using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathLib.Misc;
public static class Forms
{
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


    public static int BalancedBit(BigInteger number, int index, bool isLastDigit)
    {
        BigInteger div = BigInteger.One << (index + 2);
        BigInteger mod = number.ModMinAbs(div);
        return isLastDigit ? mod.Sign : -mod.Sign;
    }

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
}
