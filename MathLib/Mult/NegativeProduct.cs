using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathLib.Mult;

public class NegativeProduct : IProduct
{
    #region Data
    
    public Product Positive { get; }
  
    public IInput InputX { get; }

    private readonly int[] coeffs;

    #endregion Data

    public IInput InputY => Positive.InputY;

    public BigInteger Integer => -Positive.Integer;

    public int Length => Positive.Length;

    public int XLength => Positive.XLength;

    public int YLength => Positive.YLength;

    public bool IsInvalid => Positive.IsInvalid;

   
    public NegativeProduct(Product positive)
    {
        this.Positive = positive;
        this.InputX = ((Input)positive.InputX).Negative();
        
        coeffs = new int[Length];
        if (!DistributeIntegerWithinMinMax())
        {
            coeffs = Array.Empty<int>();
        }
    }

    private static bool IsOdd(int index) => (index & 1) != 0;

    public bool DistributeIntegerWithinMinMax()
    {
        int[] initCoeffs = Input.ToBitArray(Integer); //this can be 1 longer than Length

        Array.Copy(initCoeffs, coeffs, Length);
        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, int max) = MinMax(i);
            if (coeffs[i] < min)
            {
                int add = min - coeffs[i];
                if (IsOdd(add))
                    add++;
                coeffs[i] += add;
                if (i + 1 < Length) coeffs[i + 1] -= add / 2;
            }

        }
        AssertCoeffsValid(initCoeffs);
        return true;
    }

    private void AssertCoeffsValid(int[] reference)
    {
        int[] coeffs = this.coeffs.ToArray();

        for (int i = 0; i < Length; i++)
        {
            int move = (coeffs[i] / 2);
            coeffs[i] -= move * 2;
            coeffs[i + 1] += move;
        }
        for (int i = 0; i < Length; i++)
        {
            if (coeffs[i] != reference[i])
                throw new InvalidOperationException($"Assert failed: Invalid coefficient at index {i}");
        }
    }

    public IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    {
        for (int yIndex = 0; yIndex <= YLength; yIndex++)
            yield return (index - yIndex, yIndex);
    }

    public (int min, int max) MinMax(int index)
    {
        int notSetCount = 0;
        int oneCount = 0;

        foreach (var (xIndex, yIndex) in InputCells(index))
        {
            int x = InputX[xIndex];
            int y = InputY[yIndex];
            if (x == 0 || y == 0)
                continue; //zero value (not counted)
            else if (x == 1 && y == 1)
                oneCount++;
            else
                notSetCount++;
        }
        return (oneCount, oneCount + notSetCount);
    }
}
