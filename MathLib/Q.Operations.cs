﻿using System.Buffers.Text;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MathLib;

public partial class Q
{
    /// <summary>
    /// Extends the current rational number to a <see cref="Qb"/> with the specified base.
    /// </summary>
    /// <param name="base_">The base to convert to.</param>
    /// <returns>A new <see cref="Qb"/> representing the current rational number in the specified base.</returns>
    public Qb InBase(int base_) => new Qb(this, base_);

    /// <summary>
    /// Light version of <see cref="Qb.ShiftedFractions()"/> that takes a rational number and a base.
    /// </summary>
    /// <remarks>This method does not require the costly creation of a <see cref="Qb"/>.</remarks>
    /// <param name="base_">The base to convert to.</param>
    /// <returns>An enumerable sequence of tuples, where each tuple contains the integer part and the fractional part of the rational number in the specified base.</returns>
    /// <seealso cref="Qb.ShiftedFractions()"/>
    public IEnumerable<(BigInteger Integer, Q Fraction)> ShiftedFractions(int base_)
    {
        Q q = this / BigInteger.Pow(base_, this.IntegralPart.Length(base_));

        while (true)
        {
            Q f = q.FractionalPart;

            q = q.FractionalPart * base_;
            yield return (q.IntegralPart.Abs(), f);
        }
    }

    /// <summary>
    /// Light version of <see cref="Qb.Coefficients()"/> that takes a rational number and a base.
    /// </summary>
    /// <remarks>This method does not require the costly creation of a <see cref="Qb"/>.</remarks>
    /// <param name="base_">The base to convert to.</param>
    /// <returns>An enumerable sequence of integers representing the coefficients of the rational number in the specified base.</returns>
    /// <seealso cref="Qb.Coefficients()"/>
    /// <seealso cref="Qb.ShiftedFractions()"/>
    public IEnumerable<int> Coefficients(int base_) => ShiftedFractions(base_).Select(c => (int)c.Integer);


    /// <summary>
    /// The value of the rational number in the specified base.
    /// </summary>
    /// <param name="base_">The base to convert to.</param>
    /// <returns>The coefficient of the rational number in the specified base.</returns>
    public BigInteger Coeff(int base_) => ((Numerator * base_) / Denominator);

    /// <summary> 
    /// Obsolete: This method is obsolete and will be removed.
    /// </summary>
    [Obsolete("This method is obsolete and will be removed")] 
    public Q Backward(int base_)
        => base_.IsPurelyPeriodic(this)
            ? Numerator.IsDivisibleBy(base_)
                ? new Q(Numerator / base_, Denominator)
                : new Q((Numerator + Denominator) / base_, Denominator)
            : new Q(Numerator + Denominator, Denominator / base_);

    /// <summary> 
    /// Obsolete: This method is obsolete and will be removed.
    /// </summary>
    [Obsolete("This method is obsolete and will be removed")]
    public Q Forward(int base_)
    {
        BigInteger n = Numerator;
        BigInteger d = Denominator;
        n *= base_;
        if (n > d) n /= d; //TODO: Or should it be % instead of /?
        return new Q(n, d);
    }


    /// <summary>
    /// Sign of the current rational number.
    /// </summary>
    /// <returns>An integer that indicates the sign of the current rational number. 
    /// Returns -1 if the number is negative, 0 if the number is zero, and 1 if the number is positive.</returns>
    public int Sign => Numerator.Sign;

    /// <summary>
    /// Reciprocal of this rational number.
    /// </summary>
    /// <remarks>
    /// The reciprocal of a rational number <c>a/b</c> is <c>b/a</c>.
    /// Returns <see cref="NaN"/> if the numerator is <c>0</c>.
    /// </remarks>
    public Q Reciprocal => Numerator.IsZero
        ? NaN
        : Numerator > BigInteger.Zero
            ? new Q(Denominator, Numerator, normalize: false) //positive number, no normalization required
            : new Q(-Denominator, -Numerator, normalize: false); //negative number, switch signs, no normalization required

    /// <summary>
    /// Conditionally negates the current rational number.
    /// </summary>
    /// <param name="negate">A boolean value indicating whether to negate the rational number.</param>
    /// <returns>A new <see cref="Q"/> representing the negative value if <paramref name="negate"/> is <see langword="true"/>; otherwise, returns the current instance.</returns>
    public Q Negation(bool negate) => negate ? -this : this;

    /// <summary>
    /// Increments this rational number by one.
    /// </summary>
    /// <param name="a">The rational number to increment.</param>
    /// <returns>A new rational number representing the result of the increment.</returns>
    public static Q operator ++(Q a) => new(a.Numerator + a.Denominator, a.Denominator);

    /// <summary>
    /// Decrements this rational number by one.
    /// </summary>
    /// <param name="a">The rational number to decrement.</param>
    /// <returns>A new rational number representing the result of the decrement.</returns>
    public static Q operator --(Q a) => new(a.Numerator - a.Denominator, a.Denominator);

    /// <summary>
    /// Negation of this rational number.
    /// </summary>
    /// <param name="a">The rational number to negate.</param>
    /// <returns>A new rational number representing the negated value.</returns>
    public static Q operator -(Q a) => new(-(a.Numerator), a.Denominator, false);

    /// <summary>
    /// Sum of two rational numbers.
    /// </summary>
    /// <param name="a">The first term.</param>
    /// <param name="b">The second term.</param>
    /// <returns>A new rational number representing the sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static Q operator +(Q a, Q b) => new(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    /// <summary>
    /// Difference of two rational numbers.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>A new rational number representing the difference between <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static Q operator -(Q a, Q b) => new(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    /// <summary>
    /// Product of two rational numbers.
    /// </summary>
    /// <param name="a">The first factor.</param>
    /// <param name="b">The second factor.</param>
    /// <returns>A new rational number representing the product of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static Q operator *(Q a, Q b) => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    /// <summary>
    /// Quotient of two rational numbers.
    /// </summary>
    /// <param name="a">The dividend.</param>
    /// <param name="b">The divisor.</param>
    /// <returns>A new rational number representing the quotient of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static Q operator /(Q a, Q b) => new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);

    /// <summary>
    /// Sum of a rational number and an integer.
    /// </summary>
    /// <param name="q">A rational number denoting the first term.</param>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the second term.</param>
    /// <returns>A new rational number representing the sum of <paramref name="q"/> and <paramref name="integer"/>.</returns>
    public static Q operator +(Q q, BigInteger integer) => new(q.Numerator + integer * q.Denominator, q.Denominator);

    /// <summary>
    /// Sum of an integer and a rational number.
    /// </summary>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the first term.</param>
    /// <param name="q">A rational number denoting the second term.</param>
    /// <returns>A new rational number representing the sum of <paramref name="integer"/> and <paramref name="q"/>.</returns>
    public static Q operator +(BigInteger integer, Q q) => new(q.Numerator + integer * q.Denominator, q.Denominator);

    /// <summary>
    /// Difference of a rational number and an integer.
    /// </summary>
    /// <param name="q">A rational number denoting the minuend.</param>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the subtrahend.</param>
    /// <returns>A new rational number representing the difference of <paramref name="q"/> and <paramref name="integer"/>.</returns>
    public static Q operator -(Q q, BigInteger integer) => new(q.Numerator - integer * q.Denominator, q.Denominator);

    /// <summary>
    /// Difference of an integer and a rational number.
    /// </summary>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the minuend.</param>
    /// <param name="q">A rational number denoting the subtrahend.</param>
    /// <returns>A new rational number representing the difference of <paramref name="integer"/> and <paramref name="q"/>.</returns>
    public static Q operator -(BigInteger integer, Q q) => new(integer * q.Denominator - q.Numerator, q.Denominator);


    /// <summary>
    /// Product of a rational number and an integer.
    /// </summary>
    /// <param name="q">A rational number denoting the first factor.</param>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the second factor.</param>
    /// <returns>A new rational number representing the product of <paramref name="q"/> and <paramref name="integer"/>.</returns>
    public static Q operator *(Q q, BigInteger integer) => new(q.Numerator * integer, q.Denominator);

    /// <summary>
    /// Product of an integer and a rational number.
    /// </summary>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the first factor.</param>
    /// <param name="q">A rational number denoting the second factor.</param>
    /// <returns>A new rational number representing the product of <paramref name="integer"/> and <paramref name="q"/> .</returns>
    public static Q operator *(BigInteger integer, Q q) => new(q.Numerator * integer, q.Denominator);

    /// <summary>
    /// Quotient of a rational number and an integer.
    /// </summary>
    /// <param name="q">A rational number denoting the dividend.</param>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the divisor.</param>
    /// <returns>A new rational number representing the quotient of <paramref name="q"/> and <paramref name="integer"/>.</returns>
    public static Q operator /(Q q, BigInteger integer) => new(q.Numerator, q.Denominator * integer);

    /// <summary>
    /// Quotient of am integer and rational number.
    /// </summary>
    /// <param name="integer">A <see cref="BigInteger"/> denoting the dividend.</param>
    /// <param name="q">A rational number denoting the divisor.</param>
    /// <returns>A new rational number representing the quotient of <paramref name="integer"/> and <paramref name="q"/>.</returns>
    public static Q operator /(BigInteger integer, Q q) => new(integer * q.Denominator, q.Numerator);

    /// <summary>
    /// Performs the modulus operation on two rational numbers.
    /// </summary>
    /// <remarks>
    /// The formula for the modulus operation is:
    /// <code>
    /// (a_n / a_d) % (b_n / b_d) = ((a_n * b_d) % (a_d * b_n)) / (a_d * b_d)
    /// </code>
    /// where <c>a_n</c> and <c>a_d</c> are the numerator and denominator of <paramref name="a"/> respectively,
    /// and <c>b_n</c> and <c>b_d</c> are the numerator and denominator of <paramref name="b"/> respectively.
    /// </remarks>
    /// <param name="a">The left operand.</param>
    /// <param name="b">The right operand.</param>
    /// <returns>The modulus of <paramref name="a"/> and <paramref name="b"/> as a <see cref="Q"/>.</returns>
    public static Q operator %(Q a, Q b)
    {
        if (b.Numerator == 0)
            return NaN; // Cannot perform modulus by zero

        BigInteger newNumerator = (a.Numerator * b.Denominator) % (a.Denominator * b.Numerator);
        BigInteger newDenominator = a.Denominator * b.Denominator;

        return new(newNumerator, newDenominator);
    }

    /// <summary>
    /// Performs a left bitwise shift on the current rational number.
    /// </summary>
    /// <remarks>
    /// If <paramref name="shift"/> is negative, the shift direction will be reversed,
    /// making this operation equivalent to a right shift. This behavior mirrors the standard
    /// behavior of the C# operators `&lt;&lt;` and `&gt;&gt;` for integral types, where negative values
    /// reverse the shift direction.
    /// </remarks>
    /// <param name="a">The rational number to shift.</param>
    /// <param name="shift">The number of bits to shift. A positive value shifts left, a negative value shifts right.</param>
    /// <returns>A new rational number representing the result of the shift operation.</returns>
    public static Q operator <<(Q a, int shift)
        => shift switch
        {
            > 0 => new(a.Numerator << shift, a.Denominator, normalize: a.Numerator.IsEven),
            < 0 => a >> -shift,
            _ => a  // shift == 0
        };

    /// <summary>
    /// Performs a right bitwise shift on the current rational number.
    /// </summary>
    /// <remarks>
    /// If <paramref name="shift"/> is negative, the shift direction will be reversed,
    /// making this operation equivalent to a left shift. This behavior mirrors the standard
    /// behavior of the C# operators `&lt;&lt;` and `&gt;&gt;` for integral types, where negative values
    /// reverse the shift direction.
    /// </remarks>
    /// <param name="a">The rational number to shift.</param>
    /// <param name="shift">The number of bits to shift. A positive value shifts right, a negative value shifts left.</param>
    /// <returns>A new rational number representing the result of the shift operation.</returns>
    public static Q operator >>(Q a, int shift)
        => shift switch
        {
            > 0 => new(a.Numerator, a.Denominator << shift, normalize: a.Denominator.IsEven),
            < 0 => a << -shift,
            _ => a  // shift == 0
        };

    /// <summary>
    /// Returns the square of the current rational number.
    /// </summary>
    /// <returns>A new rational number representing the square of the current rational number.</returns>
    public Q Square() => new Q(Numerator * Numerator, Denominator * Denominator, false);

    /// <summary>
    /// Gets the absolute value of the current rational number.
    /// </summary>
    /// <value>
    /// A <see cref="Q"/> representing the absolute value of the current rational number. 
    /// If the rational number is negative, a new <see cref="Q"/> instance is returned 
    /// with the absolute value. If the rational number is non-negative, the current instance is returned.
    /// </value>
    public Q Abs =>
        Numerator >= BigInteger.Zero
        ? this
        : new(-Numerator, Denominator, false);

    /// <summary>
    /// Raises the current rational number to the power of the given exponent.
    /// </summary>
    /// <param name="exponent">The exponent to which to raise the current rational number.</param>
    /// <returns>A new rational number representing the result of the exponentiation.</returns>
    public Q Pow(Q exponent) => exponent.TryCastToInt32(out int exponentInt) ? Pow(exponentInt) : NaN;

    /// <summary>
    /// Raises the current rational number to the power of the given integer exponent.
    /// </summary>
    /// <param name="exponent">The integer exponent to which to raise the current rational number.</param>
    /// <returns>A new rational number representing the result of the exponentiation.</returns>
    public Q Pow(int exponent) => exponent switch
    {
        > 0 => new Q(BigInteger.Pow(Numerator, exponent), BigInteger.Pow(Denominator, exponent)),
        < 0 => new Q(BigInteger.Pow(Denominator, -exponent), BigInteger.Pow(Numerator, -exponent)), // Numerator and Denominator are flipped
        _ => Q.One,
    };

    /// <summary>
    /// Attempts to cast the rational number to a 32-bit integer, if possible.
    /// </summary>
    /// <param name="result">The resulting 32-bit integer if the cast is successful.</param>
    /// <returns><see langword="true"/> <c>iff</c> the cast is successful.</returns>
    public bool TryCastToInt32(out int result)
    {
        if (Denominator == 1 && Numerator <= int.MaxValue && Numerator >= int.MinValue)
        {
            result = (int)Numerator;
            return true;
        }
        result = int.MinValue;
        return false;
    }

    /// <summary>
    /// This version always sets FEO mode.
    /// </summary>
    protected BigInteger IntegralPartAlwaysFEO => Numerator / Denominator;

    /// <summary>
    /// This version selects between FIO and FEO mode.
    /// </summary>
    /// <remarks>
    /// This property needs to replace the existing version to come in to effect.
    /// Current implementation is provided only to give an understanding.
    /// </remarks>
    /// <param name="fio">If <see langword="true"/> FIO mode, otherwise FEO mode</param>
    protected BigInteger IntegralPartSelective(bool fio)
        => fio && IsNonZeroInteger
                ? (Numerator / Denominator) - Sign
                : (Numerator / Denominator); //FEO

    private static (BigInteger Numerator, BigInteger Denominator) Normalize(BigInteger numerator, BigInteger denominator, bool normalize)
    {
        if (denominator.IsZero)
            return (BigInteger.Zero, BigInteger.Zero); //return NaN

        if (numerator.IsZero) //always denominator 1 for Zero
            return (numerator, BigInteger.One);

        if (denominator < BigInteger.Zero) //negative Denominator, move sign to numerator
            (numerator, denominator) = (-numerator, -denominator); //switch sign

        if (normalize)
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator.Abs(), denominator.Abs());
            if (gcd != BigInteger.One)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
        }
        else
        {

            //In Debug build only: check if constructor was called with an incorrect normalize=false 
            Debug.Assert(BigInteger.GreatestCommonDivisor(numerator.Abs(), denominator.Abs()).IsOne,
                "Serious error: Unsafe constructor was called with arguments that required normalize=true.");
        }

        return (numerator, denominator);
    }

  
}
