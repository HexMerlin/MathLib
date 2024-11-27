using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathLib.BalMult;


/// <summary>
/// Provides extension methods for composing and decomposing CBit values that are pairs of bits.
/// </summary>
public static class CBit
{
    /// <summary>
    /// Composes a CBit value from the given boolean values.
    /// </summary>
    /// <param name="sign">Value 1 (+) or -1 (-)</param>
    /// <param name="green">Indicates if the bit is green.</param>
    /// <returns>
    /// An integer representing the composed CBit value:
    /// <list type="bullet">
    /// <item>
    /// <description>Zero: 0</description>
    /// </item>
    /// <item>
    /// <description>1 Green: 1</description>
    /// </item>
    /// <item>
    /// <description>-1 Green: -1</description>
    /// </item>
    /// <item>
    /// <description>1 Red: 2</description>
    /// </item>
    /// <item>
    /// <description>-1 Red: -2</description>
    /// </item>
    /// </list>
    /// </returns>
    public static int Compose(int sign, bool green) => green ? sign : sign << 1;

    /// <summary>
    /// Decomposes a CBit value into its boolean components.
    /// </summary>
    /// <param name="value">The integer value to decompose.</param>
    /// <returns>
    /// A tuple containing two boolean values:
    /// <list type="bullet">
    /// <item>
    /// <description>sign: 1 (+) or -1 (-), or 0 for Zero/Invalid</description>
    /// </item>
    /// <item>
    /// <description>green: true iff the bit is green.</description>
    /// </item>
    /// </list>
    /// </returns>
    public static (int sign, bool green) Decompose(int value) => (value.Sign(), value.IsOdd());

    /// <summary>
    /// Computes the product of two CBit values.
    /// </summary>
    /// <param name="cbit1">The first CBit value.</param>
    /// <param name="cbit2">The second CBit value.</param>
    /// <returns>A new CBit value that is the product of the two given.</returns>
    public static int Product(int cbit1, int cbit2)
    {
        (int sign1, bool green1) = Decompose(cbit1);
        (int sign2, bool green2) = Decompose(cbit2);
        return green1 != green2
            ? 0
            : green1
                ? sign1 == sign2 ? 1 : -1
                : sign1 == sign2 ? -2 : 2;
    }

    public const char PosChar = '+';
    public const char NegChar = '-';
    public const char ZeroChar = ' ';
    public const string GreenColorCode = "\u001b[32m";
    public const string RedColorCode = "\u001b[31m";
    public const string ResetColorCode = "\u001b[0m";
}

public class SymProduct
{
    public int[] Coeffs { get; }

    public int Length => Coeffs.Length;

    public SymProduct(BigInteger x, BigInteger y, int minLength = 0)
    {
        var product = x * y;
        if (product.IsEven)
        {
            Coeffs = new int[0];
            return;
        }
        
        if (x.Abs() < y.Abs()) 
            (x, y) = (y, x);
               
        var xBits = BalBits.ToBalancedBits(x, minLength).ToArray();
        var yBits = BalBits.ToBalancedBits(y, xBits.Length).ToArray();
        Coeffs = new int[xBits.Length];
        for (int i = 0; i < Coeffs.Length; i++)
            Coeffs[i] = CBit.Compose(xBits[i], xBits[i] == yBits[i]); 
    }


    public static string ColorCoeff(int coeff)
    {
        if (coeff == 0) return CBit.ZeroChar.ToString();
        (int sign, bool green) = CBit.Decompose(coeff);
        return $"{(green ? CBit.GreenColorCode : CBit.RedColorCode)}{(sign == 1 ? CBit.PosChar : CBit.NegChar)}{CBit.ResetColorCode}";
    }

    public override string ToString() => Coeffs.Select(ColorCoeff).Str();

    public string ToStringExpanded()
    {
        StringBuilder sb = new StringBuilder(Length * (Length + 1));
        for (int y = 0; y < Length; y++)
        {
            for (int x = 0; x < Length; x++)
                sb.Append(ColorCoeff(CBit.Product(Coeffs[x], Coeffs[y])));
            sb.AppendLine();
        }
        return sb.ToString();
    }

}
