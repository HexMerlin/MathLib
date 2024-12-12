using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib.BalMult;
public class Product
{
    public Int3 X;
    public Int3 Y;

    public int InputLength => X.Length;

    public int ProductLength => (X.Length << 1) - 1;

    public int Integer => X.Integer * Y.Integer;

    public Product(int x, int y)
    {
        (x, y) = x.Abs() >= y.Abs() ? (x, y) : (y, x);
        this.X = new Int3(x);
        this.Y = new Int3(y, X.Length);

    }

    public int this[int y, int x] => (Y[y] == 0 || X[x] == 0) ? 0 : (Y[y] == X[x] ? 1 : -1);

    public IEnumerable<Product> MatricesUnfiltered()
    {
        //static bool IsNAF(ReadOnlyCollection<int> sequence)
        //{
        //    bool prevZero = true;
        //    for (int i = 0; i < sequence.Count; i++)
        //    {
        //        if (sequence[i] != 0)
        //        {
        //            if (!prevZero)
        //                return false;
        //            prevZero = false;
        //        }   
        //        else prevZero = true;

        //    }
        //    return true;
        //}
        foreach (int[] seqX in X.Sequences())
        {
            //seqX.CopyTo(XBits);
            //if (!IsNAF(seqY))
            //    continue;
            foreach (int[] seqY in Y.Sequences())
            {
                //seqY.CopyTo(YBits);

                yield return this;
            }
        }
    }

    public IEnumerable<Product> Matrices()
    {
        foreach (var product in MatricesUnfiltered())
        {
   
            if (IsValid())
            {
                yield return this;
            }
        }
    }

    

    public IEnumerable<int> ProductCoeffs()
    {
        for (int i = 0; i < ProductLength; i++)
            yield return ProductCoeff(i);
    }
    public IEnumerable<int> DiagCoeffs()
    {
        for (int i = 0; i < InputLength; i++)
            yield return this[i, i];
    }

    public int ProductSum()
    {
        int sum = 0;
        for (int i = 0; i < ProductLength; i++)
            sum+= ProductCoeff(i) * (1 << i);
        return sum;
    }


    public bool IsValid()
    {

        //1. Diagonal consists of only 0 and -
        //2. One factor consists of only + and -, except for 0 padding in the end
        //3. Product bits:
        //   0: -
        //   1: not zero

        //if (XBits.All(b => b != 0) && YBits.All(b => b != 0))
        //    return true;
        //if (!XBits.Select((b, i) => new { b, i }).All(t => (t.b == 0) == (this[t.i, t.i] == 0)) &&
        //    !YBits.Select((b, i) => new { b, i }).All(t => (t.b == 0) == (this[t.i, t.i] == 0))) return false;
        //for (int i = 0; i < 3; i++)
        //{
        //    if (ProductCoeff(i) == 0)
        //        return false;
        //}

        for (int i = 0; i < InputLength; i++)
        {
            if (X[i] == Y[i])
                return false;
        }

        bool expectedOdd(int i) => i.IsEven();
        bool flipParity = false;

        for (int i = 0; i < InputLength; i++)
        {
            if (X[i] == 0 || Y[i] == 0)
                flipParity = !flipParity;
            bool realExpectedOdd = expectedOdd(i) != flipParity;
            if (ProductCoeff(i).IsOdd() != realExpectedOdd)
                return false;
        }

        //var balBits = Integer.ToBalancedBits(ProductLength).ToArray();

        //if (balBits[0] == -1 && balBits[1] == -1)
        //{
        //    if (ProductCoeff(1) != -1)
        //        return false;
        //}



        return true; //remove this line


        int largeCount = 0;

        for (int i = 0; i < ProductLength; i++)
        {
            int coeff = ProductCoeff(i);

            //if (i.IsEven() == coeff.IsEven())
            //    return false;
            //if (coeff.Abs() != Matrix[i, i].Abs())
            //    return false;
            //if (coeff.IsEven() != i.IsOdd())
            //    return false;
            //if (coeff < 0)
            //    return false;
            //if (i != InputLength - 1 && coeff.Abs() > 1)
            //    return false;

             //if (i != (InputLength - 1) && coeff.Abs() > 1)
             if (coeff.Abs() > 1)
             {
                if (i < InputLength - 1)
                    return false;

                largeCount++;

                if (largeCount > 1)
                    return false;
            }
             

        }
      
        return true;
    }

    public int ProductCoeff(int productIndex)
    {
        int startRow = Math.Max(0, productIndex - InputLength + 1);
        int endRow = Math.Min(productIndex, InputLength - 1);
        int sum = 0;
        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = productIndex - yIndex;
            sum += this[yIndex, xIndex];
        }
        return sum;
    }


    public IEnumerable<(int xIndex, int yIndex)> CoeffPairs(int productIndex)
    {
        int startRow = Math.Max(0, productIndex - InputLength + 1);
        int endRow = Math.Min(productIndex, InputLength - 1);

        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = productIndex - yIndex;
            yield return (xIndex, yIndex);
        }
    }

   
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public static string BitColorString(int bit, int coeffWidth = 0)
    {
        Color color = bit > 0 ? Color.Blue : bit < 0 ? Color.Red : Color.Green;
        return Colorize(Symbolize(bit).PadLeft(coeffWidth), color);

    }


    public static string Symbolize(int value) => value switch
    {
        0 => "0",
        1 => "+",
        -1 => "-",
        _ => value.ToString()
    };
    
    public static string Colorize(string str, Color color) => color switch
    {
        Color.Red => $"\u001b[31m{str}\u001b[0m",
        Color.Green => $"\u001b[32m{str}\u001b[0m",
        Color.Blue => $"\u001b[34m{str}\u001b[0m",
        _ => str
    };

    public string ToStringExpanded()
    {
        StringBuilder sb = new();
        for (int y = 0; y < InputLength; y++)
        {
            for (int x = 0; x < InputLength; x++)
            {
                int val = this[y, x];
                Color color = val > 0 ? Color.Blue : val < 0 ? Color.Red : Color.Green;
                sb.Append(Colorize(Symbolize(val), color));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public string ToStringProduct(int coeffWidth = 0) => ProductCoeffs().Select(c => BitColorString(c, coeffWidth)).Str();
    public string ToStringX(int coeffWidth = 0) => X.ToString(coeffWidth);
    public string ToStringY(int coeffWidth = 0) => Y.ToString(coeffWidth);

    public string ToStringDiag(int coeffWidth = 0) => DiagCoeffs().Select(c => BitColorString(c, coeffWidth)).Str();

}
