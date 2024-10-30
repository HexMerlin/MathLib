using System;
using System.Collections.Generic;
using System.Numerics;


namespace MathLib.Mult;

public class Product : ProductBase
{
    #region Data
    public override BigInteger Integer { get; }

    public override InputBase InputX { get; }
    public override InputBase InputY { get; }

    public NegativeProduct Negative { get; } 

    #endregion Data

    public Product(BigInteger integer, int xLength, int yLength)
    {
        this.Integer = integer;
        this.InputX = new Input(xLength);
        this.InputY = new Input(yLength);
        this.Negative = new NegativeProduct(this);
    }

    public void FillX(BigInteger number) => InputX.Fill(number);

    public void FillY(BigInteger number) => InputY.Fill(number);

    public override IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    {
        int yFirst = Math.Max(0, index - InputX.Length + 1);
        int yLast = Math.Min(index, InputY.Length - 1);

        for (int yIndex = yFirst; yIndex <= yLast; yIndex++)
            yield return (index - yIndex, yIndex);
    }

    public override int[] GetCoeffs()
    {
        BigInteger rem = Integer;
        
        int[] coeffs = new int[Length];
        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, int max) = MinMax(i);
            coeffs[i] = min;
            rem -= min * Weight(i); 
        }
        //distribute as much as possible up to max
        for (int i = Length - 1; i >= 0; i--)
        {
            int add = (int)BigInteger.Min(MinMax(i).max - coeffs[i], rem / Weight(i));
            coeffs[i] += add;
            rem -= add * Weight(i);
        }

        return rem.IsZero ? coeffs : Array.Empty<int>();
    }
}
