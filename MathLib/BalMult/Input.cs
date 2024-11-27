using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using MathLib.Misc;

namespace MathLib.BalMult;

/// <summary>
/// Represents an integer in balanced binary form
/// </summary>
public class Input
{
 
    private int[] coeffs { get; }

    /// <summary>
    /// Indicates whether the input is valid or NaN.
    /// </summary>
    public bool IsNaN => coeffs.Length == 0;

    public int Length => coeffs.Length;

    /// <summary>
    /// Exposes the coefficients as a readonly span.
    /// </summary>
    public ReadOnlySpan<int> Coeffs => coeffs;


    /// <summary>
    /// Gets the coefficient at the specified index.
    /// </summary>
    /// <param name="index">The index</param>
    public int this[int index] 
        => index >= 0 && index < Length 
            ? coeffs[index] 
            : 0;

    public void Set(int index, int value)
    {
       Debug.Assert(index >= 0 && index < Length);
       Debug.Assert(value is 1 or -1);
       coeffs[index] = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Input"/> class with the specified BigInteger.
    /// </summary>
    /// <param name="integer">The BigInteger to convert to balanced binary coefficients.</param>
    /// <param name="minLength">Optional min length for the returned sequence.</param>
    public Input(BigInteger integer, int minLength = 0)
    {
        if (integer.IsEven)
            coeffs = new int[0];
        coeffs = BalBits.ToBalancedBits(integer, minLength).ToArray();
    }

    public Input(params int[] coeffs) => this.coeffs = coeffs;


    /// <summary>
    /// Gets the BigInteger representation of the input.
    /// </summary>
    public BigInteger Integer => coeffs.Select((d, i) => (BigInteger.One << i) * d).Sum();

    public void Clear() => Array.Clear(coeffs, 0, coeffs.Length);

    /// <summary>
    /// Outputs the input as a string with left-padding of bits to the specified width.
    /// </summary>
    /// <param name="bitWidth">Pad each coefficient to this length</param>
    public string ToString(int bitWidth) => coeffs.BitString(bitWidth);

    public override string ToString() => coeffs.BitString();

    public bool Flip(int i) => Enumerable.Range(0, i).Count(i => this[i] == -1).IsOdd();

    public int Flip(int x, int y) => Flip(x) == Flip(y) ? 1 : -1;

    public string Test()
    {
        StringBuilder sb = new StringBuilder();

        for (int y = 0; y < Length; y++)
        {
            for (int x = 0; x < Length; x++)
            {
                int val = this[x] != this[y]
                    ? 0
                    : this[x] * Flip(x, y);
                sb.Append(val == 0 ? ' ' : val == 1 ? '+' : '-');
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
