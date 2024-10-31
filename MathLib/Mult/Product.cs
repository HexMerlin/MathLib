using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace MathLib.Mult;

public class Product : ProductBase
{
    #region Data
    public NegativeProduct Negative { get; }

    public Product Swapped { get; }

    public override BigInteger Integer { get; }

    public override InputBase InputX { get; }
    public override InputBase InputY { get; }

  
    #endregion Data

    public Product(BigInteger integer, int xLength, int yLength, Product? swapped = null) :
        this(integer, new Input(xLength), new Input(yLength), swapped)

    {  
    }

    private Product(BigInteger integer, InputBase inputX, InputBase inputY, Product? swapped = null)
    {
        this.Integer = integer;
        this.InputX = inputX;
        this.InputY = inputY;
        this.Negative = new NegativeProduct(this);
        this.Swapped = swapped ?? new Product(integer, inputY, inputX, this);
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

    

    public void AssertPosNegSumValid()
    {
        var pos = GetCoeffs();
        var neg = Negative.GetCoeffs();
        int sameVal = pos[YLength] + neg[YLength];
        for (int i = YLength; i < Length; i++)
            if (pos[i] + neg[i] != sameVal)
                throw new InvalidOperationException("PosNegSum is not valid");

    }

    public IEnumerable<int> PosNegSum()
    {
        var pos = GetCoeffs();
        var neg = Negative.GetCoeffs();
        for (int i = 0; i < Length; i++)
            yield return pos[i] + neg[i];
    }
}
