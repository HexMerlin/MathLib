using System.Numerics;

namespace MathLib;

/// <summary>
/// Represents the set of rational numbers, denoted by ℚ in mathematics.
/// </summary>
/// <remarks>
/// The set of rational numbers is defined as the set of all numbers that can be expressed as the quotient of two integers, 
/// where the denominator is non-zero. Formally:
/// 
/// <para>ℚ = {a / b | a ∈ ℤ, b ∈ ℤ, b ≠ 0}</para>
/// Rational numbers include integers, fractions, and terminating or repeating decimal expansions. 
/// Many operations, such as addition, subtraction, multiplication, and division (excluding division by zero) 
/// are closed within ℚ.
/// 
/// <para>Rational numbers can be embedded within the set of real numbers ℝ, and the set of p-adic numbers ℚₚ. 
/// They serve as the foundation for more complex number systems.</para>
/// 
/// In this library, the class <see cref="Q"/> represents the mathematical structure of rational numbers, 
/// and serves as a base for more advanced number fields like <see cref="Qp"/> and <see cref="Cp"/>.
/// <para>The class methods must never throw exceptions from arithmetic operations. 
/// Instead, they return <see cref="NaN"/> for undefined results (such as from divide by zero).</para>
/// </remarks>
public partial class Q : IEquatable<Q>, IComparable<Q>
{
    #region Data

    /// <summary>
    /// The numerator of the rational number.
    /// </summary>
    public BigInteger Numerator { get; }

    /// <summary>
    /// The denominator of the rational number, guaranteed to be positive in normalized form.
    /// </summary>
    public BigInteger Denominator { get; }

    #endregion Data

    #region Value properties

    /// <summary>
    /// The integral (integer) part of a rational number
    /// </summary>
    /// <remarks>
    /// In general mathematics, the concept of "integral part" is not objectively defined, since it has two possible interpretations (or modes).
    /// These interpretations are defined by whether we regard the set of all pure fractions to include the number 1 or not.
    /// We denote these interpretations (modes), as FIO (Fractions Include One) and FEO (Fractions Exclude One), respectively.
    /// <para>For instance, in decimal, the number 1 has the following two interpretations:</para>
    /// <code> 
    /// 1 = 0.999999... (FIO)
    /// 1 = 1.000000... (FEO)
    /// </code>
    /// <para>In FIO the number 1 is a purely fractional number, with integral part=0 and fractional part=1.</para>
    /// <para>In FEO the number 1 is a purely integral number, with integral part=1 and fractional part=0.</para>
    /// <para>Irrespective of the mode, any number is always the sum of its integral and fractional parts.</para>
    /// <para>In FIO, all numbers will have a non-zero-terminating expansion.</para>
    /// <para>In FEO, any number that can terminate (with an ultimately infinite expansion of zeros) will do so.</para>
    /// <para>Only numbers where the denominator is a power of the base, can have different representations in FIO and FEO.</para>
    /// <para>To make <see cref="IntegralPart"/> and <see cref="FractionalPart"/> well defined, yet allow access to both FIO and FEO,
    /// we assign FIO to all positive numbers, and FEO to all negative numbers and zero.</para>
    /// <para>This whole logic is completely governed by the implementation of <see cref="IntegralPart"/>.
    /// Hence, we do not need to manage modes anywhere in the code base.
    /// </para>
    /// </remarks>
    /// <example>
    /// <list type="table">
    ///   <listheader>
    ///     <term><see cref="Q"/></term>
    ///     <term>Expansion</term>
    ///     <term>Mode</term>
    ///   </listheader>
    ///   <item>
    ///     <term>0</term>
    ///     <description>.0000000000000000</description>
    ///     <description>FIO=FEO, in any base</description>
    ///   </item>
    ///   <item>
    ///     <term>1₂</term>
    ///     <description>.1111111111111111</description>
    ///     <description>FIO</description>
    ///   </item>
    ///   <item>
    ///     <term>-1₂</term>
    ///     <description>1.000000000000000 </description>
    ///      <description>FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>103/16₂</term>
    ///     <description>110.0110111111111</description>
    ///     <description>FIO</description>
    ///   </item>
    ///   <item>
    ///     <term>-103/16₂</term>
    ///     <description>110.0111000000000</description>
    ///     <description>FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>5/24₂</term>
    ///     <description>.0011010101010101</description>
    ///      <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>-5/24₂</term>
    ///     <description>.0011010101010101</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>3/45₅</term>
    ///     <description>.3333333333333333</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>-3/45₅</term>
    ///     <description>.3333333333333333</description> 
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>537/11₃</term>
    ///     <description>1210.211002110021</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///    <item>
    ///     <term>-537/11₃</term>
    ///     <description>1210.211002110021</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    /// </list>
    /// </example>
    /// <seealso cref="Qb.ToStringCanonical(int)"/>
    public BigInteger IntegralPart =>
        IsPositiveInteger
            ? (Numerator / Denominator) - 1
            : (Numerator / Denominator);

    /// <value>
    /// The fractional part of the rational number, obtained by subtracting the integer part.
    /// </value>
    public Q FractionalPart => this - IntegralPart;

    /// <value>
    /// Represents a NaN (not a number) denoting an invalid number.
    /// <see cref="NaN"/> is return value of operations that are not defined (e.g. when dividing by zero)
    /// </value>
    public static Q NaN => new Q(BigInteger.Zero, BigInteger.Zero, false);

    /// <value>
    /// Represents the rational number zero.
    /// </value>
    public static Q Zero => new Q(BigInteger.Zero, BigInteger.One, false);

    /// <value>
    /// Represents the rational number one.
    /// </value>
    public static Q One => new Q(BigInteger.One, BigInteger.One, false);

    #endregion Value properties

    #region Constructors

    /// <summary>
    /// Initializes a rational number for the default value zero.
    /// </summary>
    public Q() : this(BigInteger.Zero, BigInteger.One, false) { }

    /// <summary>
    /// Initializes a rational number with the specified integer value.
    /// </summary>
    /// <param name="numerator">The integer value.</param>
    public Q(BigInteger numerator) : this(numerator, BigInteger.One, false) { }

    /// <summary>
    /// Initializes a rational number with the specified numerator and denominator.
    /// The rational number is automatically <c>normalized</c>, meaning:
    /// <para>Q will be simplified so the numerator and denominator is coprime.</para>
    /// <para>The sign of the number will always be carried by the numerator (denominator will be strictly positive).</para> 
    /// </summary>
    /// <param name="numerator">The numerator of the rational number.</param>
    /// <param name="denominator">The denominator of the rational number.</param>
    /// <returns>A new rational number with the specified <paramref name="numerator"/> and <paramref name="denominator"/> in normalized form.
    /// <c>iff</c> the denominator is <c>0</c>, <see cref="NaN"/> is returned.</returns>
    public Q(BigInteger numerator, BigInteger denominator) : this(numerator, denominator, true) { }


    /// <summary>
    /// Protected constructor for a rational number with the specified numerator and denominator.
    /// </summary>
    /// <remarks>
    /// <para>Caution: Setting <paramref name="normalize"/> to <see langword="false"/> will result in a faulty object if any of the following conditions are not met:</para>
    /// <list type="bullet">
    /// <item><description>The <paramref name="numerator"/> and <paramref name="denominator"/> are coprime (i.e., their greatest common divisor is 1).</description></item>
    /// <item><description>The <paramref name="denominator"/> is greater than <c>0</c>.</description></item>
    /// </list>
    /// <para>If unsure if above conditions hold, use the public constructor <see cref="Q(BigInteger, BigInteger)"/> instead.</para>
    /// <para>If you are sure above conditions hold, you can safely set <paramref name="normalize"/> to <see langword="false"/> for significantly faster execution.</para>
    /// </remarks>
    /// <param name="numerator">The numerator of the rational number.</param>
    /// <param name="denominator">The denominator of the rational number.</param>
    /// <param name="normalize"><c>Iff</c> <see langword="true"/>, the rational number will be normalized to its simplest form.</param>
    public Q(BigInteger numerator, BigInteger denominator, bool normalize) 
        => (Numerator, Denominator) = Normalize(numerator, denominator, normalize);

    /// <summary>
    /// Protected constructor that creates a copy of a Q object.
    /// </summary>
    /// <param name="q"></param>
    protected Q (Q q) : this(q.Numerator, q.Denominator, false) { }

    #endregion Constructors

}
