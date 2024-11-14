using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Gets the coefficient at the specified index.
    /// </summary>
    /// <param name="index">The index</param>
    public int this[int index] 
        => index >= 0 && index < Length 
            ? coeffs[index] 
            : 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Input"/> class with the specified BigInteger.
    /// </summary>
    /// <param name="integer">The BigInteger to convert to balanced binary coefficients.</param>
    public Input(BigInteger integer)
    {
        if (integer.IsEven)
            coeffs = new int[0];
        coeffs = Forms.ToBalancedBits(integer).ToArray();
    }

    /// <summary>
    /// Gets the BigInteger representation of the input.
    /// </summary>
    public BigInteger Integer => coeffs.Select((d, i) => (BigInteger.One << i) * d).Sum();

    public override string ToString() => coeffs.Select(c => c == 1 ? '+' : '-').Str();
}
