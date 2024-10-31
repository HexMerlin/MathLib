using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System;

namespace MathLib.Mult;

public abstract class ProductBase
{    
    public abstract BigInteger Integer { get; }

    public abstract InputBase InputX { get; }
    public abstract InputBase InputY { get; }
    
    public int Length => XLength + YLength - 1;
    public int XLength => InputX.Length;
    public int YLength => InputY.Length;
        
    public abstract int[] GetCoeffs();

   // public abstract IEnumerable<(int xIndex, int yIndex)> InputCells(int index);

    public IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    {
        for (int i = 0; i <= index; i++)
            yield return (index - i, i);
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

    public int CoeffsSum() => GetCoeffs().Sum();

    public abstract IEnumerable<int> PosNegSum();

    public IEnumerable<(int min, int max)> MinMax() => Enumerable.Range(0, Length).Select(MinMax);

    public string ToStringMinValues() => $"{Enumerable.Range(0, Length).Select(i => MinMax(i).min).Str(", ")}";

    public string ToStringMaxValues() => $"{Enumerable.Range(0, Length).Select(i => MinMax(i).max).Str(", ")}";

    public BigInteger Weight(int index) => BigInteger.One << index;

    public int[] AdjustedPosNegSum(int targetTrail = 5)
    {
        int[] coeffs = PosNegSum().ToArray();

        while (true)
        {
            int trail = coeffs[^1] + 1;
            
            coeffs[^1] += 2;
            for (int i = coeffs.Length - 1; i >= YLength; i--)
            {
                int move = coeffs[i] - trail;
                if (move > 0)
                {
                    coeffs[i] -= move;
                    coeffs[i - 1] += move * 2;
                }
            }
            if (trail >= targetTrail)
                break;
        }
        return coeffs;

    }

    public override string ToString() 
    {
        int[] coeffs = GetCoeffs();
        return coeffs.Length == 0 ? "Invalid" : $"{coeffs.Str(", ")} \tSum: {coeffs.Sum()}";
    }
     
}
