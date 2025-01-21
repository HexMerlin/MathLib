using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

using MathLib;
using MathLib.Misc;

namespace MathLib.Experimental.BalMult;

public enum MinFluctuation
{
    Yes,
}

/// <summary>
/// This class represents an odd integer represented in base 2 with the following constraints:
/// 1. Positional weights starts with the least-significant coefficient: 2^0, 2^1, 2^2, ...
/// 2. The integer equals Coeffs[0] * 2^0 + Coeffs[1] * 2^1 + Coeffs[2] * 2^2 + ... + Coeffs[length - 1] * 2^(length-1).
/// 3. Coefficients can be either negative or positive, and the value of each coefficient at index i must always be in range [Min(i), Max(i)],
/// 4. The parity of coefficients must alternate: Coeffs[0] is odd, Coeffs[1] is even, Coeffs[2] is odd, Coeffs[3] is even, etc.
/// 5. Symmetrically, for every index i, the parity of values for in all arrays will be equal and never be changed: MinAbs(i), MaxAbs(i) and Coeffs(i) will have the same fixed parity
/// 6. Length of all arrays is always odd, so first and last coefficients are always odd. Lengths of arrays must never change.
/// 7. The length of all arrays are equal: MinAbs, MaxAbs, and Coeffs.
/// 8. There can be multiple solutions that satisfy the constraints, any valid solution is acceptable.
/// 10. MaxAbs will initially start with 1, 2, 3, ... up to the middle of the array, then decrease to 1.
/// 11. MinAbs will initially start the negative of MaxAbs at each index: -1, -2, -3, ... down to the middle of the array, then increase to -1.
/// 12. The method Update() will attempt to find a valid solution that satisfies all constraints. It will update the Coeffs array and return true iff a solution is found.
/// 12. The min and max arrays can be updated at any time, and will only be updated to even narrower ranges. 
/// 13. Whenever Update() is called is called it should modify the Coeffs array to a solution, so that any narrower range of Min and Max are respected.
/// 14. The integer, and hence the arrays, could be very large, extending lengths of 1000 elements or more, so all code must be very optimized for performance.
/// </summary>
/// <example>
/// <code>
/// Integer: 15
/// MinAbs: [1, 0, 1, 0, 1]
/// MaxAbs: [1, 2, 3, 2, 1]
/// Coeffs:  [-1, 2, -1, 0, 1]
/// Coeffs is a valid solution since all the following criteria are met:
/// True: Alternating and matching parity, starting with odd (odd, even, odd, even, odd)
/// True: Absolute values of each coefficient is within valid range [MinAbs..MaxAbs] 
/// True: Weighted sum equals integer: -1 * 2^0 + 2 * 2^1 + -1 * 2^2 + 0 * 2^3 + 1 * 2^4 =
/// -1 + 4 - 4 + 0 + 16 = 15
/// </code>
/// </example>
public class AltParity
{
    public BigInteger Integer { get; }

    public int[] Min;

    public int[] Max;

    public int[] Coeffs;
    public int Length => Coeffs.Length;

    public AltParity(BigInteger integer, int length = 0)
    {
        if (integer.IsEven)
            throw new ArgumentException(nameof(integer), "Must be an odd integer");

        this.Integer = integer;
        this.Coeffs = ToAltParity(integer, length).ToArray();
        this.Max = Enumerable.Range(0, length).Select(i => i <= length / 2 ? i + 1 : length - i).ToArray();
        this.Min = Max.Select(max => -max).ToArray();
        if (length != 0) 
        {
            if (Coeffs.Length != length)
                ReduceLength();
            Debug.Assert(Coeffs.Length == length);
        }
     
  
          
        Debug.Assert(Enumerable.Range(0, Length).All(i => Coeffs[i] >= Min[i] && Coeffs[i] <= Max[i]));
        Debug.Assert(Integer == Coeffs.Select((c, i) => (BigInteger.One << i) * c).Sum());
    }

    public AltParity(BigInteger integer, int[] coeffs)
    {
        this.Integer = integer;
        this.Coeffs = coeffs.ToArray();
        this.Min = this.Coeffs.ToArray();
        this.Max = this.Coeffs.ToArray();
    }

    //Create a new AltParity with minimum fluctuation
    public AltParity(BigInteger integer, MinFluctuation _)
    {
        this.Integer = integer;
        this.Coeffs = ToAltParityMinFluctuation(integer).ToArray();
        this.Min = this.Coeffs.ToArray();
        this.Max = this.Coeffs.ToArray();
    }

    //Create a new AltParity object that replicates the product coefficients from a SymProduct object
    public AltParity(SymProduct symProduct)
    {
        this.Integer = symProduct.Product;
        this.Coeffs = symProduct.ProductCoeffs().ToArray();
        this.Min = this.Coeffs.ToArray();
        this.Max = this.Coeffs.ToArray();
    }

    public int this[int index] => Coeffs[index];

    private void UpdateLeft(int index)
    {
        Debug.Assert(index.IsOdd() != Coeffs[index].IsOdd());
        if (Coeffs[index] > Max[index])
        {
            Coeffs[index - 1] += (Coeffs[index] - Max[index]) * 2;
            Coeffs[index] = Max[index];
            UpdateLeft(index - 1);
        }
        else if (Coeffs[index] < Min[index])
        {
            Coeffs[index - 1] -= (Min[index] - Coeffs[index]) * 2;
            Coeffs[index] = Min[index];
            UpdateLeft(index - 1);
        }
        
    }

    internal void ReduceLength()
    {
        var temp = Coeffs;
        Coeffs = new int[Coeffs.Length - 1];
        Array.Copy(temp, Coeffs, Coeffs.Length);
        Coeffs[^1] += temp[^1] * 2;
        UpdateLeft(Coeffs.Length - 1);
    }

    public static bool IsOdd(int integer) => (integer & 1) != 0;

    public static IEnumerable<int> ToAltParityMinFluctuation(BigInteger integer)
    {
      
        var bits = integer.ToBalancedBits().ToArray();
        if (bits.Length.IsEven())
            bits = integer.ToBalancedBits(bits.Length + 1).ToArray();

        for (int i = 0; i < bits.Length - 1; i+=2)
        {
            if (bits[i] != bits[i+1])
            {
                yield return bits[i + 1];
                yield return 0;
            }
            else
            {
                yield return -bits[i];
                yield return bits[i + 1] * 2;
            }
        }
        yield return bits[^1];
    }

    public static IEnumerable<int> ToAltParity(BigInteger integer, int length = 0)
    {   
        int carry = 0;
       
        foreach (int bit in integer.ToBalancedBits(length))
        {
            if (carry == 0)
            {
                yield return -bit;
                carry = bit;
            }
            else
            {
                yield return bit + carry;
                carry = 0;
            }
        }
        if (carry != 0)
            yield return carry;
    }

    public static string CoeffString(IEnumerable<int> coeffs, int coeffWidth)
        => coeffs.Select(c => c.ToString().PadLeft(coeffWidth)).Str();
    public string ToStringMinMax() => Min.Zip(Max, (min, max) => $"[{min}, {max}]").Str();

    public override string ToString() => CoeffString(Coeffs, 0);
    
    public string ToString(int coeffWidth) => CoeffString(Coeffs, coeffWidth);



}
