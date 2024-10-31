using System;
using System.Collections.Generic;
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

    //public override IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    //{
    //    int yLast = Math.Min(index, InputY.Length - 1);  // `yLast` remains the same

    //    for (int yIndex = 0; yIndex <= yLast; yIndex++)
    //        yield return (index - yIndex, yIndex);
    //}

    public override int[] GetCoeffs()
    {
        int[] givenCoeffs = Input.ToBitArray(Integer); //this can be 1 longer than Length

        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, int max) = MinMax(i);
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
