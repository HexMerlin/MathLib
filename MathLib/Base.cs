using System;
using System.Numerics;
using MathLib.Compatibility;


namespace MathLib;

/// <summary>
/// Represents a base for number representation.
/// </summary>
public readonly struct Base : IEquatable<Base>, IComparable<Base>
{
    /// <summary>
    /// Returns base value as an integer.
    /// </summary>
    public int IntValue { get; }

    /// <summary>
    /// Implicitly converts a <see cref="Base"/> to an integer.
    /// </summary>
    /// <param name="b">The <see cref="Base"/> to convert.</param>
    public static implicit operator int(Base b) => b.IntValue;


    /// <summary>
    /// Initializes a new instance of the <see cref="Base"/> struct.
    /// </summary>
    /// <param name="base_">The base value.</param>
    public Base(int base_)
    {
        ArgOutOfRangeException.ThrowIfLessThan(base_, 2, nameof(base_));
        this.IntValue = base_;
    }

    /// <summary>
    /// Checks if the given rational number is purely periodic in the current base.
    /// </summary>
    /// <param name="q">The rational number to check.</param>
    /// <returns><see langword="true"/> <c>iff</c> the rational number is purely periodic.</returns>
    public bool IsPurelyPeriodic(Q q) => q.Denominator.Coprime(IntValue);

    /// <summary>
    /// Raises the base to the specified exponent.
    /// </summary>
    /// <param name="exponent">The exponent.</param>
    /// <returns>The result of raising the base to the exponent.</returns>
    public Q Pow(int exponent) => exponent switch
    {
        > 0 => new Q(BigInteger.Pow(IntValue, exponent)),
        < 0 => new Q(BigInteger.One, BigInteger.Pow(IntValue, -exponent), false),
        _ => Q.One,
    };

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Base base_ && Equals(base_);

    /// <inheritdoc/>
    public override int GetHashCode() => IntValue.GetHashCode();

    /// <inheritdoc/>
    public bool Equals(Base other) => IntValue == other.IntValue;

    /// <inheritdoc/>
    public int CompareTo(Base other) => IntValue.CompareTo(other.IntValue);

    /// <summary>
    /// Gets a <see cref="BaseInt"/> representing the value zero in the current base.
    /// The length for 0 is always 0.
    /// </summary>
    public BaseInt ZeroInt => new BaseInt(this, BigInteger.Zero);

    /// <inheritdoc/>
    public static bool operator ==(Base left, Base right) => left.Equals(right);

    /// <inheritdoc/>
    public static bool operator !=(Base left, Base right) => !(left == right);

    /// <inheritdoc/>
    public override string ToString() => IntValue.ToString();
}
