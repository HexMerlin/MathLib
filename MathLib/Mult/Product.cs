using System;
using System.Numerics;


namespace MathLib.Mult;

public class Product : ProductBase
{
    #region Data
    public override BigInteger Integer { get; }

    public override IInput InputX { get; }
    public override IInput InputY { get; }

    public NegativeProduct Negative { get; } 

    #endregion Data

    public bool IsInvalid => Length == 0;
  
    public Product(BigInteger integer, int xLength, int yLength)
    {
        this.Integer = integer;
        this.InputX = new Input(xLength);
        this.InputY = new Input(yLength);
        this.Negative = new NegativeProduct(this);
    }

    public bool SetX(int index, int value)
    {
        if (InputX[index] == value)
            return false;
        InputX[index] = value;
        return true;
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
