﻿using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System;

namespace MathLib.Mult;

public abstract class ProductBase
{
    
    public abstract BigInteger Integer { get; }

    public abstract IInput InputX { get; }
    public abstract IInput InputY { get; }
    
    public int Length => XLength + YLength - 1;
    public int XLength => InputX.Length;
    public int YLength => InputY.Length;
        
    public abstract int[] GetCoeffs();

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

    public int TotalSetOnes() => MinMax().Select(m => m.min).Sum();

    public IEnumerable<(int min, int max)> MinMax() => Enumerable.Range(0, Length).Select(MinMax);

    public string ToStringMinValues() => $"[{Enumerable.Range(0, Length).Select(i => MinMax(i).min).Str(", ")}]";

    public string ToStringMaxValues() => $"[{Enumerable.Range(0, Length).Select(i => MinMax(i).max).Str(", ")}]";

    public BigInteger Weight(int index) => BigInteger.One << index;

    public override string ToString() 
    {
        int[] coeffs = GetCoeffs();
        return coeffs.Length == 0 ? "Invalid" : $"[{coeffs.Str(", ")}]";
    }
     
}
