using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathLib.BalMult;

public class SymProduct
{
    public BigInteger Product { get; }

    private readonly int[] coeffs;
    public int Length => coeffs.Length;

    public int ProductLength => (coeffs.Length << 1) - 1;
    
    public int this[Index index]
    {
        get => coeffs[index.IsFromEnd ? coeffs.Length - index.Value : index.Value];
        set => coeffs[index.IsFromEnd ? coeffs.Length - index.Value : index.Value] = value;
    }

    public int ProductCoeff(Index productIndex) => CoeffPairs(productIndex.IsFromEnd ? ProductLength - productIndex.Value : productIndex.Value).Select(t => CBit.Product(coeffs[t.xIndex], coeffs[t.yIndex]).Sign()).Sum();

    public SymProduct(AltParity altParity)
    {
        this.Product = altParity.Integer;
        this.coeffs = new int[(altParity.Length + 1) / 2];
    }

    public SymProduct(BigInteger x, BigInteger y, int minLength = 0)
    {
        this.Product = x * y;
        if (this.Product.IsEven)
        {
            coeffs = new int[0];
            return;
        }
        
        if (x.Abs() < y.Abs()) 
            (x, y) = (y, x);
               
        var xBits = BalBits.ToBalancedBits(x, minLength).ToArray();
        var yBits = BalBits.ToBalancedBits(y, xBits.Length).ToArray();
        coeffs = new int[xBits.Length];
        for (int i = 0; i < coeffs.Length; i++)
            coeffs[i] = CBit.Compose(xBits[i], xBits[i] == yBits[i]); 
    }

    public void Reset() => Array.Fill(coeffs, 1);

    private IEnumerable<(int xIndex, int yIndex)> CoeffPairs(int productIndex)
    {
        int startRow = Math.Max(0, productIndex - Length + 1);
        int endRow = Math.Min(productIndex, Length - 1);

        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = productIndex - yIndex;
            yield return (xIndex, yIndex);
        }
    }

    public bool IncreaseOne()
    {
        int i = 0;
        while (i < coeffs.Length)
        {
            coeffs[i] = CBit.Next(coeffs[i]);
            if (coeffs[i] != 1)
                return true;
            i++;
        }
        return false;
    }

    public IEnumerable<int> ProductCoeffs() => Enumerable.Range(0, ProductLength).Select(i => ProductCoeff(i));


    private bool TrySolve(AltParity altParity, int index)
    {
        int i = index;
        while (true)
        {
            if (ProductCoeff(i) == altParity[i])
            {
                if (i == index)
                    return true; //solved to index
                i++;
            }
               
            this[i] = CBit.Next(this[i]);

            if (this[i] == 1)
            {
                index--; //backtrack
                if (index < 0)
                    return false; //no solution  
            }
        }
    }

    private bool TrySolveFromRight(AltParity altParity, int index)
    {
        int i = index;
        while (true)
        {
            if (ProductCoeff(^i) == altParity[^i])
            {
                if (i == index)
                    return true; //solved to index
                i++;
            }

            this[^i] = CBit.Next(this[^i]);

            if (this[^i] == 1)
            {
                index--; //backtrack
                if (index < 1)
                    return false; //no solution  
            }
        }
    }

    public int TrySolve(AltParity altParity)
    {
        Reset();

        int i = 0;
        while (true)
        {
            bool IsSolved = ProductCoeffs().SequenceEqual(altParity.Coeffs);
            if (IsSolved) return ProductLength;
            if (!IncreaseOne()) return -1;
        }        
    }

    //public int TrySolve(AltParity product)
    //{
    //    Reset();

    //    for (int c = 0; c < Length; c++)
    //    {
    //        if (!TrySolve(product, c))
    //            return c;
    //        if (!TrySolveFromRight(product, c + 1))
    //            return Length - c;
    //        //Console.WriteLine(this.ToStringExpanded());
    //        //Console.WriteLine();
    //    }
    //    return Length;
    //}

    public static string ColorCoeff(int coeff)
    {
        if (coeff == 0) return CBit.ZeroChar.ToString();
        (int sign, bool green) = CBit.Decompose(coeff);
        return $"{(green ? CBit.GreenColorCode : CBit.RedColorCode)}{(sign == 1 ? CBit.PosChar : CBit.NegChar)}{CBit.ResetColorCode}";
    }

    public string ProductString(int coeffWidth = 0) => ProductCoeffs().Select(c => c.ToString().PadLeft(coeffWidth)).Str();

    public string ToStringSigns() => coeffs.Select(c => c.Sign()).Str();

    public override string ToString() => coeffs.Select(ColorCoeff).Str();

    public string ToStringExpanded()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < Length; y++)
        {
            for (int x = 0; x < Length; x++)
                sb.Append(ColorCoeff(CBit.Product(coeffs[x], coeffs[y])));
            sb.AppendLine();
        }
        return sb.ToString();
    }

}
