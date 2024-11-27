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
    /// <param name="pos">Indicates if the bit is positive.</param>
    /// <param name="green">Indicates if the bit is green.</param>
    /// <returns>
    /// An integer representing the composed CBit value:
    /// <list type="bullet">
    /// <item>
    /// <description>0 - None / Invalid</description>
    /// </item>
    /// <item>
    /// <description>1 - Pos | Green</description>
    /// </item>
    /// <item>
    /// <description>-1 - Neg | Green</description>
    /// </item>
    /// <item>
    /// <description>2 - Pos | Red</description>
    /// </item>
    /// <item>
    /// <description>-2 - Neg | Red</description>
    /// </item>
    /// </list>
    /// </returns>
    public static int Compose(bool pos, bool green) => pos ? (green ? 1 : 2) : (green ? -1 : -2);

    /// <summary>
    /// Decomposes a CBit value into its boolean components.
    /// </summary>
    /// <param name="value">The integer value to decompose.</param>
    /// <returns>
    /// A tuple containing two boolean values:
    /// <list type="bullet">
    /// <item>
    /// <description>pos: true iff the bit is positive.</description>
    /// </item>
    /// <item>
    /// <description>green: true iff the bit is green.</description>
    /// </item>
    /// </list>
    /// </returns>
    public static (bool pos, bool green) Decompose(int value) => (value > 0, value.IsOdd());

    public static int Mult(int bitA, int bitB)
    {
        (bool posA, bool greenA) = Decompose(bitA);
        (bool posB, bool greenB) = Decompose(bitB);
        if (greenA != greenB)
            return 0;
        if (greenA)
            return posA == posB ? 1 : -1;
        return posA == posB ? -2 : 2;
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
            Coeffs[i] = CBit.Compose(xBits[i] == 1, xBits[i] == yBits[i]);
        
    }


    public static string ColorCoeff(int coeff)
    {
        if (coeff == 0) return CBit.ZeroChar.ToString();
        var (pos, green) = CBit.Decompose(coeff);
        return $"{(green ? CBit.GreenColorCode : CBit.RedColorCode)}{(pos ? CBit.PosChar : CBit.NegChar)}{CBit.ResetColorCode}";
    }

    public override string ToString() => Coeffs.Select(ColorCoeff).Str();

    public string ToStringExpanded()
    {
        StringBuilder sb = new StringBuilder(Length * (Length + 1));
        for (int y = 0; y < Length; y++)
        {
            for (int x = 0; x < Length; x++)
                sb.Append(ColorCoeff(CBit.Mult(Coeffs[x], Coeffs[y])));
            sb.AppendLine();
        }
        return sb.ToString();
    }

}
