using System.Numerics;

namespace MathLib;

/// <summary>
/// Represents an immutable base-specific integer of a fixed length, that supports zero-padding.
/// </summary>
/// <remarks>
/// A <see cref="BaseInt"/> is fully defined by its integer value, base and length. 
/// Shifting and other operations are applied with respect to the specified base, and the length is preserved.
/// </remarks>
public class BaseInt : IEquatable<BaseInt>, IComparable<BaseInt>
{
    private enum Unchecked { Yes }

    /// <summary>
    /// Gets the base of the <see cref="BaseInt"/>.
    /// </summary>
    public Base Base { get; }

    /// <summary>
    /// Gets the length of the <see cref="BaseInt"/>.
    /// </summary>
    public int Length { get; }

    /// <summary>
    /// Integer value of the <see cref="BaseInt"/> in descending order.
    /// </summary>
    /// <remarks>
    /// This value is always stored descending order, regardless of the base's natural order.
    /// This makes it compliant with arithmetic operations of the <see cref="BigInteger"/> type.
    /// <para>For ascending order, the value is reversed when the <see cref="BaseInt"/> is created.</para>
    /// </remarks>
    public BigInteger IntValue { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="BaseInt"/> struct.
    /// </summary>
    /// <param name="base_">The base of the <see cref="BaseInt"/>.</param>
    /// <param name="intValue">The integer value.</param>
    /// <param name="length">An optional length of the <see cref="BaseInt"/>. Default is the minimum required length of <paramref name="intValue"/> in the given base.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the integer value is negative or the base is less than 2.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an explicit <paramref name="length"/> is specified that is less than minimum required length of <paramref name="intValue"/> (in the given base).</exception>
    public BaseInt(Base base_, BigInteger intValue, int length = -1) : this(base_, intValue, base_.LengthOf(intValue), Unchecked.Yes) 
    { 
        ArgumentOutOfRangeException.ThrowIfNegative(intValue, nameof(intValue)); // Negative numbers are not supported.
        if (intValue.IsZero) ArgumentOutOfRangeException.ThrowIfGreaterThan(length, 0, nameof(length)); 
        //For clarity and robustness, this constructor does not allow BaseInt with value 0 to have a non-zero length. Use Zero() instead.                                                 

        if (length != -1) //override of default automatic length
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(length, Length, nameof(length));
            Length = length;
        }

    }

    private BaseInt(Base base_, BigInteger intValue, int length, Unchecked _)
    {
        Base = base_;
        IntValue = intValue;
        Length = length;
    }

    public static BaseInt Zero(Base base_, int zeroCount = 0)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(zeroCount, 0, nameof(zeroCount));
        return new(base_, BigInteger.Zero, zeroCount, Unchecked.Yes);

    }

    public static BigInteger ReverseInt(int base_, BigInteger integer, int length)
    {
        BigInteger revInt = BigInteger.Zero;
  
        foreach (int coefficient in CoefficientsAscending(base_, integer, length))
        {
            revInt *= base_;
            revInt += coefficient; 
        }

        return revInt;
    }

    /// <summary>
    /// Returns a new <see cref="BaseInt"/> where the coefficients are reversed.
    /// </summary>
    /// <remarks>
    /// The coefficients are reversed such that the most significant becomes the least significant, and vice versa.
    /// As a result, the outputs of <see cref="Coefficients"/> is reversed, 
    /// compared to the original instance.
    /// </remarks>
    /// <returns>A new <see cref="BaseInt"/> with reversed coefficients.</returns>
    public BaseInt Reverse()
    {
        if (IsZero) return this;
        BigInteger revInt = ReverseInt(Base.IntValue, IntValue, Length);
        return new BaseInt(Base, revInt, this.Length);
    }


    /// <summary>
    /// Gets the first (most significant) coefficient.
    /// </summary>
    public int First => (int)(IntValue / BigInteger.Pow(Base.IntValue, Length - 1));

    /// <summary>
    /// Gets the last (least significant) coefficient.
    /// </summary>
    public int Last => (int) IntValue % Base.IntValue;


    /// <summary>
    /// Indicates whether the <see cref="BaseInt"/> is zero.
    /// </summary>
    public bool IsZero => IntValue.IsZero;

    /// <summary>
    /// Returns the coefficients in current base in descending order of significance.
    /// </summary>
    /// <returns>An enumerable sequence of coefficients from most to least significant.</returns>
    public IEnumerable<int> Coefficients()
        => CoefficientsDescending();


    /// <summary>
    /// Returns the coefficients in current base in descending order of significance.
    /// </summary>
    /// <returns>An enumerable sequence of coefficients from most to least significant.</returns>
    private IEnumerable<int> CoefficientsDescending()
    {
        if (Length == 0) yield break;
        BigInteger current = IntValue;
        BigInteger power = BigInteger.Pow(Base.IntValue, Length - 1);
        for (int i = 0; i < Length; i++)
        {
            yield return (int)BigInteger.DivRem(current, power, out BigInteger remainder);
            current = remainder;
            power /= Base.IntValue;
        }
    }

    /// <summary>
    /// Returns the coefficients from least significant to most significant.
    /// </summary>
    /// <returns>An enumerable sequence of coefficients from least to most significant.</returns>
    private static IEnumerable<int> CoefficientsAscending(int base_, BigInteger number, int length)
    {
        BigInteger current = BigInteger.Abs(number); 

        while (length-- > 0)
        {
            current = BigInteger.DivRem(current, base_, out BigInteger remainder);
            yield return (int)remainder;
        }
    }


    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Base, Length, IntValue);

    /// <inheritdoc/>
    public bool Equals(BaseInt? other) => other is not null && Base.Equals(other.Base) && Length.Equals(other.Length) && IntValue.Equals(other.IntValue);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is BaseInt other && Equals(other);

    /// <inheritdoc/>
    public int CompareTo(BaseInt? other)
    {
        if (other is null)
            return 1;
        if (Base != other.Base) 
            return Base.CompareTo(other.Base); 
        if (Length != other.Length)
            return Length.CompareTo(other.Length);
        return IntValue.CompareTo(other.IntValue);
    }

    /// <summary>
    /// Asserts that the current <see cref="BaseInt"/> has the same base as the specified <see cref="BaseInt"/>.
    /// </summary>
    /// <param name="other">The <see cref="BaseInt"/> to compare the base with.</param>
    /// <returns>The current <see cref="BaseInt"/> if the bases are equal.</returns>
    /// <exception cref="ArgumentException">Thrown when the bases are not equal.</exception>
    public BaseInt AssertSameBaseAs(BaseInt other)
        => Base == other.Base ? this : throw new ArgumentException($"Bases must be equal: {Base} != {other.Base}");

    public BaseInt Append(BaseInt right)
        => Concatenation(this, right);

    public static BaseInt Concatenation(BaseInt left, BaseInt right) 
        => left.AssertSameBaseAs(right).PadRightExtra(right.Length) + right;


    public static BaseInt operator +(BaseInt left, BaseInt right)
    {
        _ = left.AssertSameBaseAs(right);
        return new BaseInt(left.Base, left.IntValue + right.IntValue, Math.Max(left.Length, right.Length));
    }
    public static BaseInt operator -(BaseInt minuend, BaseInt subtrahend)
    {
        _ = minuend.AssertSameBaseAs(subtrahend);
        return new BaseInt(minuend.Base, minuend.IntValue - subtrahend.IntValue, Math.Max(minuend.Length, subtrahend.Length));
    }

    public BaseInt PadRightExtra(int zeros) 
        => IsZero ? 
            Zero(Base, Length + zeros) :
            new BaseInt(Base, IntValue * BigInteger.Pow(Base.IntValue, zeros), Length + zeros);



    public BaseInt PadLeftExtra(int zeros)
        => new BaseInt(Base, IntValue, Length + zeros);

    /// <summary>
    /// Shifts the <see cref="BaseInt"/> left by the specified number of positions.
    /// </summary>
    /// <remarks>
    /// <para>The length of the <see cref="BaseInt"/> is preserved.</para>
    /// Positions vacated on the right are zero-padded. 
    /// <para>Coefficients truncated on the left are discarded.</para>
    /// </remarks>
    /// <param name="baseInt">The <see cref="BaseInt"/> to shift.</param>
    /// <param name="shift">The number of positions to shift.</param>
    /// <returns>A new <see cref="BaseInt"/> shifted left by <paramref name="shift"/> positions.</returns>
    public static BaseInt operator <<(BaseInt baseInt, int shift)
        => shift >= 0
           ? new BaseInt(baseInt.Base, (baseInt.IntValue * BigInteger.Pow(baseInt.Base.IntValue, shift)) % BigInteger.Pow(baseInt.Base.IntValue, baseInt.Length), baseInt.Length)
            : baseInt >> -shift;

    /// <summary>
    /// Shifts the <see cref="BaseInt"/> right by the specified number of positions.
    /// </summary>
    /// <remarks>
    /// <para>The length of the <see cref="BaseInt"/> is preserved.</para>
    /// <para>Positions vacated on the left are zero-padded.</para>
    /// <para>Coefficients truncated on the right are discarded.</para>
    /// </remarks>
    /// <param name="baseInt">The <see cref="BaseInt"/> to shift.</param>
    /// <param name="shift">The number of positions to shift.</param>
    /// <returns>A new <see cref="BaseInt"/> shifted right by <paramref name="shift"/> positions.</returns>
    public static BaseInt operator >>(BaseInt baseInt, int shift)
        => shift >= 0
            ? new BaseInt(baseInt.Base, baseInt.IntValue / BigInteger.Pow(baseInt.Base.IntValue, shift), baseInt.Length)
            : baseInt << -shift;

    /// <summary>
    /// Indicates whether two <see cref="BaseInt"/> objects are equal.
    /// </summary>
    /// <param name="left">The first <see cref="BaseInt"/> to compare.</param>
    /// <param name="right">The second <see cref="BaseInt"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the two <see cref="BaseInt"/> objects are equal.</returns>
    public static bool operator ==(BaseInt left, BaseInt right) => left.Equals(right);

    /// <summary>
    /// Indicates whether two <see cref="BaseInt"/> objects are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="BaseInt"/> to compare.</param>
    /// <param name="right">The second <see cref="BaseInt"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the two <see cref="BaseInt"/> objects are not equal.</returns>
    public static bool operator !=(BaseInt left, BaseInt right) => !left.Equals(right);

    /// <summary>
    /// Indicates whether the first <see cref="BaseInt"/> object is less than the second <see cref="BaseInt"/> object.
    /// </summary>
    /// <param name="left">The first <see cref="BaseInt"/> to compare.</param>
    /// <param name="right">The second <see cref="BaseInt"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the first <see cref="BaseInt"/> object is less than the second <see cref="BaseInt"/> object.</returns>
    public static bool operator <(BaseInt left, BaseInt right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Indicates whether the first <see cref="BaseInt"/> object is less than or equal to the second <see cref="BaseInt"/> object.
    /// </summary>
    /// <param name="left">The first <see cref="BaseInt"/> to compare.</param>
    /// <param name="right">The second <see cref="BaseInt"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the first <see cref="BaseInt"/> object is less than or equal to the second <see cref="BaseInt"/> object.</returns>
    public static bool operator <=(BaseInt left, BaseInt right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// Indicates whether the first <see cref="BaseInt"/> object is greater than the second <see cref="BaseInt"/> object.
    /// </summary>
    /// <param name="left">The first <see cref="BaseInt"/> to compare.</param>
    /// <param name="right">The second <see cref="BaseInt"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the first <see cref="BaseInt"/> object is greater than the second <see cref="BaseInt"/> object.</returns>
    public static bool operator >(BaseInt left, BaseInt right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Indicates whether the first <see cref="BaseInt"/> object is greater than or equal to the second <see cref="BaseInt"/> object.
    /// </summary>
    /// <param name="left">The first <see cref="BaseInt"/> to compare.</param>
    /// <param name="right">The second <see cref="BaseInt"/> to compare.</param>
    /// <returns><see langword="true"/> <c>iff</c> the first <see cref="BaseInt"/> object is greater than or equal to the second <see cref="BaseInt"/> object.</returns>
    public static bool operator >=(BaseInt left, BaseInt right) => left.CompareTo(right) >= 0;


    public override string ToString() 
        => $"Int: {IntValue} Length: {Length}";

    public string ToStringCoefficient()
        => Coefficients().Str("");
}
