using System;

namespace MathLib.Experimental.BalMult;

/// <summary>
/// Provides extension methods for composing and decomposing cBit values that are pairs of bits.
/// </summary>
public static class CBit
{
    /// <summary>
    /// Composes a cBit value from the given component values.
    /// </summary>
    /// <param name="sign">Value 1 (+) or -1 (-) or 0 for Zero/Invalid</param>
    /// <param name="green">Indicates if the bit is green.</param>
    /// <returns>
    /// An integer representing the composed cBit value:
    /// <list type="bullet">
    /// <item>
    /// <description>Zero: 0 (has no color)</description>
    /// </item>
    /// <item>
    /// <description>1 + Green: 1</description>
    /// </item>
    /// <item>
    /// <description>-1 + Green: -1</description>
    /// </item>
    /// <item>
    /// <description>1 + Red: 2</description>
    /// </item>
    /// <item>
    /// <description>-1 + Red: -2</description>
    /// </item>
    /// </list>
    /// </returns>
    public static int Compose(int sign, bool green) => green ? sign : sign << 1;

    public static int Next(int value) => 
        value switch
        {
            1 => -1,
            -1 => 2,
            2 => -2,
            -2 => 1,
            _ => throw new ArgumentException("Invalid cBit value", nameof(value))
        };

    /// <summary>
    /// Decomposes a cBit value into its components.
    /// </summary>
    /// <param name="value">The integer value to decompose.</param>
    /// <returns>
    /// A tuple containing two values:
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
    /// Computes the product of two cBit values.
    /// </summary>
    /// <param name="cBit1">The first cBit value.</param>
    /// <param name="cBit2">The second cBit value.</param>
    /// <returns>A new cBit value that is the product of the two given.</returns>
    public static int Product(int cBit1, int cBit2)
    {
        (int sign1, bool green1) = Decompose(cBit1);
        (int sign2, bool green2) = Decompose(cBit2);
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
