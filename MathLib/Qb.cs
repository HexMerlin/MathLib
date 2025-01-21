using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace MathLib;

/// <summary>
/// Represents a rational number with a base-dependent expansion, denoted ℚb.
/// </summary>
/// <remarks>
/// The class <see cref="Qb"/> extends <see cref="Q"/> by adopting a base, and thus defining a base-specific coefficient expansion 
/// of the rational number, with a preperiodic and a periodic part. These types of expansions are commonly used in numeral systems 
/// like p-ary expansions (e.g. decimal or binary) or in p-adic systems.
/// <para>Each number is expressed in terms of a base, denoted by <see cref="Base"/>, with a preperiodic part (initial terminating sequence) 
/// and a periodic part (repeating sequence).</para>
/// <para>Each coefficient is indexed according to the exponent of the base <see cref="Base"/>. The index <c>i</c> corresponds to the 
/// coefficient <c>c_i</c> associated with the term <c>c_i * Base^i</c>, where the value of <c>i</c> decreases as we move from 
/// left to right in the expansion.</para>
/// <para>The first (leftmost) coefficient has index <see cref="FirstExponent"/>, which corresponds to the largest 
/// exponent. The index decreases through the expansion, reflecting the successive exponents of the base, including negative 
/// exponents for terms after the radix point (radix point occurs between <c>c_0</c> and <c>c_-1</c>).
/// </para>
/// <para>
/// This consistent indexing system aligns with the mathematical representation of the number as a series in base <see cref="Base"/>:
/// <c>q = Σ (c_i * <see cref="Base"/>^i)</c>
/// where the index <c>i</c> decreases from <see cref="FirstExponent"/> to negative values as the expansion proceeds.
/// </para>
/// <para>Overview of concepts and properties, for a full (ultimately periodic) expansion:</para>
/// <code>
/// Indexes (example):   |-- 7   6   5   4   3   2   1   0  -1  -2  -3  -4  -5  --|  
/// Numeric parts:       |-- IntegralPart    --|-- FractionalPart               --|
/// Length  properties:  |-- IntegralLength  --|-- FractionalLength             --|
/// Numeric parts:       |-- PreperiodicPart               --|-- PeriodicPart   --|         
/// Length  properties:  |-- PreperiodicLength             --|-- Period         --|                  
///                      |-- Length                                             --|
/// Indexes (Exponents): • (FirstExponent=8)                     • (FirstPeriodicExponent=-2)
///                                                        • (Radix point, after c_0)
/// </code>
/// <para>The class methods must never throw exceptions for arithmetic operations. Instead, they return <see cref="Q.NaN"/> for undefined results (such as from divide by zero).</para>
/// </remarks>

public partial class Qb : Q, IEquatable<Qb>
{
    #region Data

    /// <summary>
    /// The preperiodic part.
    /// </summary>
    /// <remarks>
    /// Contains the preperiodic coefficients (including zero-padding), and the length of the preperiodic part.
    /// </remarks>
    public BaseInt PreperiodicPart { get; }

    /// <summary>
    /// The periodic part.
    /// </summary>
    /// <remarks>
    /// Contains the periodic coefficients (including zero-padding), and the period (=length of the periodic part).
    /// </remarks>
    public BaseInt PeriodicPart { get; }

    #endregion Data

    #region Value properties

    /// <summary>
    /// Gets the base of the rational number extension.
    /// </summary>
    public int Base => PeriodicPart.Base;

    /// <summary>
    /// Length of the integer part (of the base B expansion).
    /// </summary>
    /// <remarks>
    /// <para>This value is simply the base-specific length of <see cref="Q.IntegralPart"/>.</para>
    /// <para>Formula:</para>
    /// <para><see cref="IntegralLength"/> = <see cref="Q.IntegralPart"/>.Length(Base)</para>
    /// </remarks>
    public int IntegralLength => IntegralPart.Length(Base);

    /// <summary>
    /// Length of the fractional part (of the base B expansion).
    /// </summary>
    public int FractionalLength => Length - IntegralLength;

    /// <summary>
    /// Total length of the preperiodic and periodic parts (of the base B expansion).
    /// </summary>
    public int Length => PreperiodicLength + Period;

    /// <summary>
    /// Index (= exponent value) of the <c>first coefficient</c> (of the base <see cref="Base"/> expansion)
    /// </summary>
    /// <remarks>
    /// <para>This value is simply the length of <see cref="Q.IntegralPart"/> - 1: </para>
    /// <para>The range of possible values is <c>[-1..∞[</c>, since a number either starts before the radix point, or directly after it.</para>
    /// The <c>coefficient</c> at index <see cref="FirstExponent"/> is the true first coefficient in the expansion, which can be zero <c>iff</c> <see cref="FirstExponent"/> is -1.
    /// <para>Formula: </para>
    /// <para><see cref="FirstExponent"/> = <see cref="Q.IntegralPart"/>.Length(Base) - 1</para>
    /// </remarks>
    public int FirstExponent => IntegralLength - 1;

    /// <summary>
    /// Index (= exponent value) of the first coefficient of the periodic part (of the base B expansion).
    /// </summary>
    public int FirstPeriodicExponent => FirstExponent - PreperiodicLength;

    /// <summary>
    /// Length of the preperiodic part (of the base B expansion).
    /// </summary>
    public int PreperiodicLength => PreperiodicPart.Length;

    /// <summary>
    /// Length of the periodic part (of the base B expansion).
    /// </summary>
    public int Period => PeriodicPart.Length;

    /// <summary>
    /// Numeric concatenation of the preperiodic and periodic parts.
    /// </summary>
    public BaseInt FullInteger => BaseInt.Concatenation(PreperiodicPart, PeriodicPart);

    #endregion Value properties

    #region Constructors
  
    /// <summary>
    /// Constructor for a <see cref="Qb"/> that takes a numerator, denominator and a base. 
    /// The rational number is automatically normalized to its simplest form.
    /// </summary>
    /// <remarks>If you already have an object of type <see cref="Q"/>, then the constructor <see cref="Qb.Qb(Q, int)"/> will be faster.
    /// <para>Or alternatively, you can simply call <see cref="Q.InBase(int)"/> on the Q instance</para>
    /// </remarks>
    /// <param name="numerator">The numerator of the rational number.</param>
    /// <param name="denominator">The denominator of the rational number. Must be non-zero.</param>
    /// <param name="base_">The base of the rational number extension.</param>
    public Qb(BigInteger numerator, BigInteger denominator, int base_) : this(new Q(numerator, denominator), base_) { }

    /// <summary>
    /// Constructor that creates a <see cref="Qb"/> from the defining parts of a base-specific expansion.
    /// </summary>
    /// <remarks>
    /// This constructor will derive the <see cref="Q.Numerator"/> and <see cref="Q.Denominator"/> from the parts.
    /// </remarks>
    /// <param name="negative">A boolean indicating if the number is negative.</param>
    /// <param name="prePeriodicPart">The preperiodic part as a <see cref="BaseInt"/>.</param>
    /// <param name="periodicPart">The periodic part as a <see cref="BaseInt"/>>.</param>
    /// <param name="firstExponent">The exponent index of the first coefficient of the number.</param>
    public Qb(bool negative, BaseInt prePeriodicPart, BaseInt periodicPart, int firstExponent = -1)
        : this(PAryInterpretation(negative, prePeriodicPart, periodicPart, firstExponent), periodicPart.Base) {

       // Debug.Assert(new Qb(Numerator, Denominator, Base).Equals(this)); //Sanity check that we get the same result when running a complete costly period 
    }

    /// <summary>
    /// Returns a NaN Qb instance.
    /// </summary>
    public new static Qb NaN => new Qb();

    /// <summary>
    /// Constructor for a NaN Qb instance.
    /// </summary>
    private Qb() : base(Q.NaN) 
    {
        PreperiodicPart = BaseInt.Zero(2);
        PeriodicPart = BaseInt.Zero(2);
    }

    /// <summary>
    /// Extends a rational number to a Qb extension with the specific base <paramref name="base_"/>.
    /// </summary>
    /// <param name="q">A rational number of type <see cref="Q"/></param>
    /// <param name="base_">The base of the rational number extension.</param>
    public Qb(Q q, int base_) : base(q)
    {
        this.PeriodicPart = BaseInt.Zero(base_); //Initialize to zero, so the base is defined

        //FirstExponent is now also accessible (since IntegralLength has been set)
        int exponent = FirstExponent;

        //Compute the preperiodic and periodic parts
        Q firstPeriodicFraction = NaN;

        int firstPeriodicExponent = int.MinValue;

        BigInteger preperiodicPart = BigInteger.Zero;
        BigInteger periodicPart = BigInteger.Zero;

        foreach ((BigInteger integer, Q fraction) in ShiftedFractions())
        {
            if (firstPeriodicFraction.IsNaN && base_.IsPurelyPeriodic(fraction))
            {
                firstPeriodicFraction = fraction;  //found beginning of periodic part
                firstPeriodicExponent = exponent;
            }
            else if (fraction == firstPeriodicFraction)
                break; //found end of periodic part
            if (firstPeriodicFraction.IsNaN)
            {
                preperiodicPart *= base_;
                preperiodicPart += integer;
            }
            else
            {
                periodicPart *= base_;
                periodicPart += integer;
            }
            exponent--;
        }

        this.PreperiodicPart = preperiodicPart.IsZero
            ? BaseInt.Zero(base_, FirstExponent - firstPeriodicExponent)
            : new BaseInt(base_, preperiodicPart, FirstExponent - firstPeriodicExponent);
        this.PeriodicPart = periodicPart.IsZero
            ? BaseInt.Zero(base_)
            : new BaseInt(base_, periodicPart, firstPeriodicExponent - exponent);

        // Debug.Assert(new Qb(PreperiodicPart, PeriodicPart, FirstExponent).Equals(this)); //Sanity check that we get the same result when running a complete costly period calculation

    }

    #endregion Constructors

    #region Methods

    //public Q PreperiodicQ() => PAryPreperiodic(IsNegative, PreperiodicPart, FirstExponent);    
   
    //public Q PeriodicQ() => PAryPeriodic(IsNegative, PeriodicPart, FirstPeriodicExponent);

    /// <summary>
    /// Returns the left-to-right expansion of the rational number in the specified base as an infinite sequence of fractions. 
    /// Each fraction corresponds to the fractional part remaining after successive base-specific left shifts.
    /// </summary>
    /// <remarks>
    /// This method first applies a normalization step to the rational number, effectively shifting the radix point to the right (in base <see cref="Base"/>),  
    /// such that the integer part is zero, leaving only the fractional part. The first element of the sequence is 
    /// this fractional remainder. 
    /// <para>
    /// Subsequently, at each step, the fractional part is shifted left by the base (* Base), 
    /// and the next fractional part is extracted by removing the integer part.
    /// </para>
    /// <para>
    /// This process generates an infinite sequence of fractional remainders, which represent the underlying structure 
    /// of the rational number in the given base. These fractions can be used to derive coefficients or compute
    /// the period of the expansion.
    /// </para>
    /// </remarks>
    /// <returns>An enumerable sequence of rational numbers representing the shifted fractional parts in base <see cref="Base"/>.</returns>
    public IEnumerable<(BigInteger Integer, Q Fraction)> ShiftedFractions()
    {
        Q q = this / Base.Pow(IntegralLength); 

        while (true)
        {
            Q f = q.FractionalPart;

            q = f * Base;
            yield return (q.IntegralPart.Abs(), f);

        }
    }

    /// <summary>
    /// Returns the coefficient (or digit) expansion of a rational number in the specified base, expressed as a sequence of integers (modulo b). 
    /// </summary>
    /// <remarks>
    /// The coefficients are obtained from the fractional expansions generated by recursively shifting the radix point of 
    /// the rational number in base <see cref="Base"/>. 
    /// <para>Specifically, the coefficients are derived by taking the <see cref="ShiftedFractions()"/> and scaling them to the range <c>[0..<see cref="Base"/>-1]</c>.</para>
    /// <para>Thus, each coefficient is a number modulo <see cref="Base"/>.</para>
    /// </remarks>
    /// <returns>An enumerable sequence of integers representing the coefficients in base <see cref="Base"/>.</returns>

    public IEnumerable<int> Coefficients() => ShiftedFractions().Select(c => (int)c.Integer);

    /// <summary>
    /// Returns a new <see cref="Q"/> with a repetend (interpreted as an integer) that is base shifted 1 step to the left
    /// compared to the original repetend (interpreted as an integer).
    /// </summary>
    /// <returns>A new <see cref="Q"/> instance with the base-shifted repetend.</returns>
    public Q RepetendShiftLeft()
    {
        int period = Period;

        Q num = Base.Pow(period) - 1;
        Q den = Base.Pow(period - 1) - 1;
        return this * num / den;
    }

    /// <summary>
    /// Returns a new <see cref="Q"/> with a repetend (interpreted as an integer) that is base shifted 1 step to the right
    /// compared to the original repetend (interpreted as an integer).
    /// </summary>
    /// <returns>A new <see cref="Q"/> instance with the base-shifted repetend.</returns>
    public Q RepetendShiftRight()
    {
        int period = Period;
        Q num = Base.Pow(period) - 1;
        Q den = Base.Pow(period + 1) - 1;
        return this * num / den;
    }

    ///<inheritdoc/>
    public bool Equals(Qb? other) => other is not null && base.Equals(other) && Base.Equals(other.Base);

    #endregion Methods
}
