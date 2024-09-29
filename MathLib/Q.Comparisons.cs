using System.Numerics;

namespace MathLib;

public partial class Q
{
    /// <summary>
    /// Indicates whether the rational number is NaN (not a number), indicated by a zero denominator.
    /// </summary>
    public bool IsNaN => Denominator.IsZero;

    /// <summary>
    /// Indicates whether the rational number is zero.
    /// </summary>
    public bool IsZero => Numerator.IsZero && Denominator.IsOne;

    /// <summary>
    /// Indicates whether the rational number is equal to one.
    /// </summary>
    public bool IsOne => Numerator.IsOne && Denominator.IsOne;

    /// <summary>
    /// Indicates whether the rational number is positive.
    /// </summary>
    public bool IsPositive => Numerator > BigInteger.Zero;

    /// <summary>
    /// Indicates whether the rational number is negative.
    /// </summary>
    public bool IsNegative => Numerator < BigInteger.Zero;

    /// <summary>
    /// Indicates whether the rational number is an integer.
    /// </summary>
    public bool IsInteger => Denominator.IsOne;

    /// <summary>
    /// Indicates whether the rational number is a non-zero integer.
    /// </summary>
    public bool IsNonZeroInteger => Denominator.IsOne && !Numerator.IsZero;

    /// <summary>
    /// Indicates whether the rational number is a positive integer.
    /// </summary>
    public bool IsPositiveInteger => Numerator > BigInteger.Zero && Denominator.IsOne;

    /// <summary>
    /// Indicates whether the rational number is a negative integer.
    /// </summary>
    public bool IsNegativeInteger => Numerator < BigInteger.Zero && Denominator.IsOne;

    /// <summary>
    /// Indicates whether the rational number is a unit fraction.
    /// </summary>
    /// <remarks>
    /// Unit fractions are strictly positive, meaning <c>-1/10</c> is not a unit fraction.
    /// </remarks>
    public bool IsUnitFraction => Numerator.IsOne && Denominator > BigInteger.Zero;

    /// <summary>
	/// Indicates whether two rational numbers are equal.
	/// </summary>
	/// <param name="a">The first rational number.</param>
	/// <param name="b">The second rational number.</param>
	/// <returns><see langword="true"/> <c>iff</c> the two rational numbers are equal.</returns>
	public static bool operator ==(Q a, Q b) => a.Numerator.Equals(b.Numerator) && a.Denominator.Equals(b.Denominator);

    /// <summary>
    /// Indicates whether two rational numbers are not equal.
    /// </summary>
    /// <param name="a">The first rational number.</param>
    /// <param name="b">The second rational number.</param>
    /// <returns><see langword="true"/> <c>iff</c> the two rational numbers are not equal.</returns>
    public static bool operator !=(Q a, Q b) => !(a == b);


    /// <summary>
    /// Indicates whether the current rational number is equal to another rational number.
    /// </summary>
    /// <param name="other">The rational number to compare with.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is equal to the specified rational number.</returns>
    public bool Equals(Q? other) => other is not null && Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);

    /// <summary>
    /// Compares the current rational number to another rational number.
    /// </summary>
    /// <param name="other">The rational number to compare with.</param>
    /// <returns>An integer that indicates the relative order of the current rational number and the specified rational number.</returns>
    public int CompareTo(Q? other) => other is not null ? (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator) : 1;

    /// <summary>
    /// Compares the current rational number to a <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="integer">The <see cref="BigInteger"/> to compare with.</param>
    /// <returns>An integer that indicates the relative order of the current rational number and the specified <see cref="BigInteger"/>.</returns>
    public int CompareTo(BigInteger integer) => Numerator.CompareTo(integer * Denominator);

    /// <summary>
    /// Indicates whether the current rational number is equal to a specified <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="q">The rational number to compare.</param>
    /// <param name="integer">The <see cref="BigInteger"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is equal to <paramref name="integer"/>.</returns>
    public static bool operator ==(Q q, BigInteger integer) => q.CompareTo(integer) == 0;

    /// <summary>
    /// Indicates whether the current rational number is not equal to a specified <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="q">The rational number to compare.</param>
    /// <param name="integer">The <see cref="BigInteger"/> to compare.</param>
    /// <returns><see langword="true"/> if the current rational number is not equal to the specified <paramref name="integer"/>.</returns>
    public static bool operator !=(Q q, BigInteger integer) => q.CompareTo(integer) != 0;

    /// <summary>
    /// Indicates whether the current rational number is less than another rational number.
    /// </summary>
    /// <param name="a">The first rational number.</param>
    /// <param name="b">The second rational number.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is less than the specified rational number.</returns>
    public static bool operator <(Q a, Q b) => a.CompareTo(b) < 0;

    /// <summary>
    /// Indicates whether the current rational number is less than or equal to another rational number.
    /// </summary>
    /// <param name="a">The first rational number.</param>
    /// <param name="b">The second rational number.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is less than or equal to the specified rational number</returns>
    public static bool operator <=(Q a, Q b) => a.CompareTo(b) <= 0;

    /// <summary>
    /// Indicates whether the current rational number is greater than another rational number.
    /// </summary>
    /// <param name="a">The first rational number.</param>
    /// <param name="b">The second rational number.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is greater than the specified rational number.</returns>
    public static bool operator >(Q a, Q b) => a.CompareTo(b) > 0;

    /// <summary>
    /// Indicates whether the current rational number is greater than or equal to another rational number.
    /// </summary>
    /// <param name="a">The first rational number.</param>
    /// <param name="b">The second rational number.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is greater than or equal to the specified rational number.</returns>
    public static bool operator >=(Q a, Q b) => a.CompareTo(b) >= 0;

    /// <summary>
    /// Indicates whether the current rational number is less than a <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="BigInteger"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is less than the specified integer.</returns>
    public static bool operator <(Q q, BigInteger integer) => q.CompareTo(integer) < 0;

    /// <summary>
    /// Indicates whether the current rational number is less than or equal to a <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="BigInteger"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is less than or equal to the specified integer.</returns>
    public static bool operator <=(Q q, BigInteger integer) => q.CompareTo(integer) <= 0;

    /// <summary>
    /// Indicates whether the current rational number is greater than a <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="BigInteger"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is greater than the specified integer.</returns>
    public static bool operator >(Q q, BigInteger integer) => q.CompareTo(integer) > 0;

    /// <summary>
    /// Indicates whether the current rational number is greater than or equal to a <see cref="BigInteger"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="BigInteger"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is greater than or equal to the specified integer.</returns>
    public static bool operator >=(Q q, BigInteger integer) => q.CompareTo(integer) >= 0;

    /// <summary>
    /// Compares the current rational number to an <see cref="int"/>.
    /// </summary>
    /// <param name="integer">The <see cref="int"/> to compare with.</param>
    /// <returns>An integer that indicates the relative order of the current rational number and <paramref name="integer"/>.</returns>
    public int CompareTo(int integer) => Numerator.CompareTo(integer * Denominator);

    /// <summary>
    /// Indicates whether the current rational number is equal to a specified <see cref="int"/>.
    /// </summary>
    /// <param name="q">The rational number to compare.</param>
    /// <param name="integer">The <see cref="int"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is equal to the specified <paramref name="integer"/>.</returns>
    public static bool operator ==(Q q, int integer) => q.CompareTo(integer) == 0;

    /// <summary>
    /// Indicates whether the current rational number is not equal to a specified <see cref="int"/>.
    /// </summary>
    /// <param name="q">The rational number to compare.</param>
    /// <param name="integer">The <see cref="int"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is not equal to <paramref name="integer"/>.</returns>
    public static bool operator !=(Q q, int integer) => q.CompareTo(integer) != 0;

    /// <summary>
    /// Indicates whether the current rational number is less than an <see cref="int"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="int"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is less than <paramref name="integer"/>.</returns>
    public static bool operator <(Q q, int integer) => q.CompareTo(integer) < 0;

    /// <summary>
    /// Indicates whether the current rational number is less than or equal to an <see cref="int"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="int"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is less than or equal to the specified integer.</returns>
    public static bool operator <=(Q q, int integer) => q.CompareTo(integer) <= 0;

    /// <summary>
    /// Indicates whether the current rational number is greater than a specified <see cref="int"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="int"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is greater than the specified <paramref name="integer"/>.</returns>
    public static bool operator >(Q q, int integer) => q.CompareTo(integer) > 0;

    /// <summary>
    /// Indicates whether the current rational number is greater than or equal to a specified <see cref="int"/>.
    /// </summary>
    /// <param name="q">The current rational number.</param>
    /// <param name="integer">The <see cref="int"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current rational number is greater than or equal to <paramref name="integer"/>.</returns>
    public static bool operator >=(Q q, int integer) => q.CompareTo(integer) >= 0;

    /// <summary>
    /// Indicates whether the current instance is equal to a specified object.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><see langword="true"/> <c>iff</c> the current instance is equal to the specified object <paramref name="obj"/>.</returns>
    public override bool Equals(object? obj) => obj is Q other && Equals(other);

    /// <summary>
    /// Returns the hash code for the current instance.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
}
