using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using MathLib.Misc;

namespace MathLib.BalMult;
public enum Sign
{
    Any = 0,
    Plus = 1,
    Minus = -1
}

public enum Color
{
    Green,
    Red
}

public class Input
{

    public readonly Sign[] Signs;
    public readonly Color[] Colors;

    /// <summary>
    /// Indicates whether the input is valid or NaN.
    /// </summary>
    public bool IsNaN => Colors.Length == 0;

    public int InputLength => Colors.Length;

    public int ProductLength => (InputLength << 1) - 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Input"/> class with the specified BigInteger.
    /// </summary>
    /// <param name="integer">The BigInteger to convert to balanced binary coefficients.</param>
    /// <param name="minLength">Optional min length for the returned sequence.</param>
    public Input(BigInteger factor1, BigInteger factor2, int minLength = 0)
    {
        BigInteger product = factor1 * factor2;
        if (product.IsEven)
            throw new ArgumentException(nameof(product), "Must be an odd product");
        (factor1, factor2) = factor1.Abs() >= factor2.Abs() ? (factor1, factor2) : (factor2, factor1);

        Signs = BalBits.ToBalancedBits(factor1, minLength).Select(b => b == 1 ? Sign.Plus : Sign.Minus).ToArray();
        var signsY = BalBits.ToBalancedBits(factor2, Signs.Length).Select(b => b == 1 ? Sign.Plus : Sign.Minus).ToArray();

        Colors = Enumerable.Range(0, Signs.Length).Select(i => Signs[i] == signsY[i] ? Color.Green : Color.Red).ToArray();
     
     //  Colors = Enumerable.Range(0, Signs.Length).Select(i => Color.Green).ToArray();
    }

    public Input(int inputLength)
    {
        Signs = new Sign[inputLength];
        Array.Fill(Signs, Sign.Any);
        Colors = new Color[inputLength];
        Array.Fill(Colors, Color.Green);
    }

    /// <summary>
    /// Gets the BigInteger representation of the input.
    /// </summary>
    public BigInteger Integer => Signs.Select((s, i) => (BigInteger.One << i) * ((int)s)).Sum();

    /// <summary>
    /// Outputs the input as a string with left-padding of bits to the specified width.
    /// </summary>
    /// <param name="bitWidth">Pad each coefficient to this length</param>
    //public string ToString(int bitWidth) => coeffs.BitString(bitWidth);

    //public override string ToString() => coeffs.BitString();

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

    //public static (Sign sign, Color color) Product(Sign signX, Color colorX, Sign signY, Color colorY)
    //{
    //    if (colorX != colorY)
    //        return (Sign.Any, Color.Red);
    //    if (signX == Sign.Any || signY == Sign.Any)
    //        return (Sign.Any, Color.Green);
    //    return (signX == signY ? Sign.Plus : Sign.Minus, colorX);
    //}

    public ProdCoeff ProdCoeff(int productIndex)
    {
        ProdCoeff acc = new ProdCoeff(0, 0);

        foreach (var (xIndex, yIndex) in CoeffPairs(productIndex))
        {
            Sign sX = Signs[xIndex];
            Sign sY = Signs[yIndex];
            Color cX = Colors[xIndex];
            Color cY = Colors[yIndex];
       
            if (cX != cY) //different color: cell-product is zero
                continue; 
            Color singleColor = cX;

            if (xIndex == yIndex) //diagonal cell (same color and sign
                acc = acc.ShiftRange(singleColor == Color.Green);
            else if (sX == Sign.Any || sY == Sign.Any) //at least one unknown sign
                acc = acc.Widen();
            else
                acc = acc.ShiftRange(singleColor == Color.Green ? sX == sY : sX != sY);
             

        }
        return acc;
        
    }

    public IEnumerable<ProdCoeff> ProdCoeffs() => Enumerable.Range(0, ProductLength).Select(ProdCoeff);

    public override string ToString() 
        => Enumerable.Range(0, InputLength).Select(i => $"{ColorString(i)}").Str();

    public string ToStringProduct(int coeffWidth = 0) => ProdCoeffs().Select(c => $"{c.ToString().PadLeft(coeffWidth)}").Str();

    public string ToStringExpanded()
    {
        StringBuilder sb = new();
        for (int y = 0; y < InputLength; y++)
        {
            for (int x = 0; x < InputLength; x++)
            {
                sb.Append(CellString(x, y));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    private string CellString(int x, int y)
    {
        Color cX = Colors[x];
        Color cY = Colors[y];
        Sign sX = Signs[x];
        Sign sY = Signs[y];
        if (cX != cY)
            return ZeroChar.ToString();
        Color prodColor = cX; //cX and cY are equal
        if (sX == Sign.Any || sY == Sign.Any)
            return ColorString(Sign.Any, prodColor);
        bool plusSign = (sX == sY) == (prodColor == Color.Green);
        Sign prodSign = plusSign ? Sign.Plus : Sign.Minus;
        return ColorString(prodSign, prodColor);

    }
    public string ColorString(int inputIndex) => ColorString(Signs[inputIndex], Colors[inputIndex]);
  
    public static string ColorString(Sign sign, Color color) =>
        $"{(color == Color.Green ? GreenColorCode : RedColorCode)}{(sign == Sign.Plus ? PlusChar : sign == Sign.Minus ? MinusChar : AnyChar)}{ResetColorCode}";

    public const char PlusChar = '+';
    public const char MinusChar = '-';
    public const char ZeroChar = ' ';
    public const char AnyChar = '■'; 
    public const string GreenColorCode = "\u001b[32m";
    public const string RedColorCode = "\u001b[31m";
    public const string ResetColorCode = "\u001b[0m";
}
