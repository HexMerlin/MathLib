using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;


namespace MathLib.Mult;

public class Product : IProduct
{
    #region Data
    public BigInteger Integer { get; }

    public IInput InputX { get; }
    public IInput InputY { get; }

    private readonly int[] coeffs;

    #endregion Data

    public int Length => XLength + YLength - 1;

    public int XLength => InputX.Length;
    public int YLength => InputY.Length;

    public bool IsInvalid => XLength == 0;

    public Product(BigInteger integer, int xLength, int yLength)
    {
        this.Integer = integer;
        this.InputX = new Input(xLength);
        this.InputY = new Input(yLength);

        coeffs = new int[Length];
        if (!DistributeIntegerWithinMinMax())
        {
            coeffs = Array.Empty<int>();
        }
    }

    public int this[int index] => index < Length ? coeffs[index] : 0;

    public bool DistributeIntegerWithinMinMax()
    {
        BigInteger rem = Integer;
        
        Array.Fill(coeffs, 0);
        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, int max) = MinMax(i);
            coeffs[i] = min;
            rem -= min * IProduct.Weight(i); 
        }
        //distribute as much as possible up to max
        for (int i = Length - 1; i >= 0; i--)
        {
            int add = (int)BigInteger.Min(MinMax(i).max - coeffs[i], rem / IProduct.Weight(i));
            coeffs[i] += add;
            rem -= add * IProduct.Weight(i);
        }

        return rem.IsZero;
    }

    public IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    {
        int yFirst = Math.Max(0, index - InputX.Length + 1);
        int yLast = Math.Min(index, InputY.Length - 1);

        for (int yIndex = yFirst; yIndex <= yLast; yIndex++)
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



    //private static BigInteger Weight(int index) => BigInteger.One << index;

    public override string ToString() => IsInvalid ? "Invalid" : $"[{coeffs.Str(", ")}]";
       
    //public string ToStringMinValues() => $"[{Enumerable.Range(0, Length).Select(i => MinMax(i).min).Str(", ")}]";

    //public string ToStringMaxValues() => $"[{Enumerable.Range(0, Length).Select(i => MinMax(i).max).Str(", ")}]";

}
