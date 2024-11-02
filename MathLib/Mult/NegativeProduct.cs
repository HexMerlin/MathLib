using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace MathLib.Mult;

public class NegativeProduct : ProductBase
{
    #region Data
    
    public Product Positive { get; }   
    public override InputBase InputX { get; }

    #endregion Data

    public override InputBase InputY => Positive.InputY;

    public override BigInteger Integer => -Positive.Integer;
   
    public NegativeProduct(Product positive)
    {
        this.Positive = positive;
        this.InputX = ((Input) positive.InputX).CreateNegative();

       
    }

    private static bool IsOdd(int index) => (index & 1) != 0;

    private (int[] coeffs, int trail) InitCoeffs()
    {
        int[] givenCoeffs = Input.ToBitArray(Integer); //this will be 1 or 2 longer than Length
        Debug.Assert(givenCoeffs.Length > Length && givenCoeffs.Length <= Length + 2);
        Debug.Assert(givenCoeffs[^2] == 0 && givenCoeffs[^1] == 1);
        int trail = givenCoeffs.Length - Length;
        int[] coeffs = new int[Length];
        Array.Copy(Input.ToBitArray(Integer), coeffs, Length);
        return (coeffs, trail); 
    }

    public int[] GetCoeffs(int targetTrail)
    {
        (int[] coeffs, int trail) = InitCoeffs();

        while (trail < targetTrail)
        {
            trail++;
            coeffs[^1] += 2;
        }

        //redistribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, _) = MinMax(i);
       
            if (coeffs[i] < min)
            {
                int add = min - coeffs[i];
                if (IsOdd(add))
                    add++;
                coeffs[i] += add;
                coeffs[i + 1] -= add / 2;
            }
        }
   
        //redistribute so that none is above max
        for (int i = Length - 1; i >= 0; i--)
        {
            (_, int max) = MinMax(i);

            if (coeffs[i] > max)
            {
                int decr = coeffs[i] - max;

                coeffs[i] -= decr;
                coeffs[i - 1] -= decr * 2;
            }
        }


        return IsCoeffsValid(coeffs) ? coeffs : Array.Empty<int>();
    }

    public override int[] GetCoeffs()
    {
        int[] givenCoeffs = Input.ToBitArray(Integer); //this can be 1 longer than Length
        //Console.WriteLine($"DEBUG :     {(givenCoeffs.Str(", "))}"); 

        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, _) = MinMax(i);

            if (givenCoeffs[i] < min)
            {
                int add = min - givenCoeffs[i];
                if (IsOdd(add))
                    add++;
                givenCoeffs[i] += add;
                givenCoeffs[i + 1] -= add / 2;
            }

        }
        int[] coeffs = new int[Length];
        Array.Copy(givenCoeffs, coeffs, Length);
        return IsCoeffsValid(coeffs) ? coeffs : Array.Empty<int>();
    }

    private bool IsCoeffsValid(ReadOnlySpan<int> coeffs)
    {
        int[] reference = Input.ToBitArray(Integer);
        int[] result = coeffs.ToArray();

        for (int i = 0; i < Length; i++)
        {
            int move = (result[i] / 2);
            result[i] -= move * 2;
            if (i < Length - 1) result[i + 1] += move;
        }
        for (int i = 0; i < Length; i++)
            if (result[i] != reference[i]) return false;
        
        return true;
    }

    public override IEnumerable<int> PosNegSum() => Positive.PosNegSum();
}
