using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathLib;


namespace MathLib.PAdics;

public class PyramidBase
{
    public readonly BigInteger Integer;

    public readonly int[] Coeffs;
    public readonly bool[] Locked;

    public int Length => Coeffs.Length;

    public bool IsInvalid => Length == 0;

    public PyramidBase(BigInteger integer, int length)
    {
        this.Integer = integer;
        Coeffs = new int[length];
        Locked = new bool[length];
        Coeffs[0] = 1;
        Coeffs[^1] = 1;
        Locked[0] = true;
        Locked[^1] = true;
        if (!SetUnlockedCoeffs())
        {
            Coeffs = Array.Empty<int>();
            Locked = Array.Empty<bool>();
        }
    }

    private BigInteger LockedSum() => Coeffs.Select((c, i) => Locked[i] ? c * Weight(i) : BigInteger.Zero).Sum();

    private bool SetUnlockedCoeffs()
    {
        BigInteger rem = Integer - LockedSum();
        if (rem < 0) return false;
        for (int i = Length - 1; i >= 0; i--)
        {
            if (Locked[i]) continue;
            int coeff = (int)BigInteger.Min(MaxCoeff(i, Length), rem / Weight(i));
            Coeffs[i] = coeff;
            rem -= coeff * Weight(i);
        }
        return rem.IsZero;
    }

    private static BigInteger Weight(int index) => BigInteger.One << index;

   // private static bool ParityDifferent(BigInteger intA, int intB) => intA.IsEven != ((intB & 1) == 0);

    //private BigInteger NextFreeWeight(int startIndex)
    //{
    //    for (int i = startIndex; i < Coeffs.Length; i++)
    //        if (!Locked[i]) return Weight(i);
    //    return BigInteger.MinusOne;
    //}

   
    //private static int GetCoeff(BigInteger integer, int maxCoeff, BigInteger modulus)
    //{
    //    BigInteger x = integer % modulus;
    //    if (x > maxCoeff)
    //    {
    //        x -= modulus;
    //    }
    //    return x >= 0 && x <= maxCoeff ? (int)x : -1;
    //}


    /// <summary>
    /// Max value at the specified <paramref name="index"/> in a pyramid array of given <paramref name="length"/>.
    /// </summary>
    /// <param name="index">Index for which the value is required.</param>
    /// <param name="length">Length of the implicit array.</param>
    /// <returns>The integer at the specified index in the pyramid array of given length.</returns>
    public static int MaxCoeff(int index, int length)
    {
        int maxVal = (length + 1) / 2;
        int mirrorIndex = index < maxVal ? index : length - index - 1;
        return mirrorIndex + 1;
    }

    public BigInteger Number => Coeffs.Select((c, i) => c * Weight(i)).Sum();

    public override string ToString() => IsInvalid ? "Invalid" : $"[{Coeffs.Str(", ")}]";
}
