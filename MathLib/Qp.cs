using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using MathLib.Compatibility;

namespace MathLib;

/// <summary>
/// Represents p-adic numbers that are rational, denoted ℚ⊂ℚₚ.
/// </summary>
/// <remarks>
/// In mathematics, the set of p-adic numbers ℚₚ is the completion of the rational numbers ℚ with respect to the p-adic norm.
/// This completion includes both rational numbers and p-adic irrationals (limits of infinite p-adic expansions).
/// <para>However, in this library, the <see cref="Qp"/> class is restricted to representing only the rational numbers within ℚₚ (which can be finitely represented in a computer).
/// Consequently, it handles p-adic numbers whose expansions are finite or ultimately periodic, corresponding exactly to elements of ℚ
///</para>
/// <para>
/// This means that while ℚₚ is uncountable and includes numbers that cannot be expressed as ratios of integers (p-adic irrationals),
/// our <see cref="Qp"/> class cannot represent these elements. It focuses on rational numbers and their representations in p-adic form.
///</para>
/// </remarks>
/// <example>
/// A 5-adic expansion for the rational number -4/3 is:
/// <code>
/// -4/3 = …2222222212₅
/// </code>
/// </example>
public class Qp : Q 
{

    #region Data

    /// <summary>
    /// A reverse generator that can be used to generate the coefficients of the p-adic number, in reverse order (least significant digit first).
    /// </summary>
    public Qb Generator { get; }

    #endregion Data

    /// <summary>
    /// Returns the prime base of this p-adic number.
    /// </summary>
    public int Base => Generator.Base;

    public int FirstExponent => -Generator.IntegralLength;

   
    /// <summary>
    /// Decomposes a rational number <paramref name="q"/> into an integer part <c>k</c> and a fractional remainder based on the specified modulus.
    /// </summary>
    /// <param name="q">The rational number to decompose, represented as an instance of <see cref="Q"/>.</param>
    /// <param name="modulus">The modulus (or base) for the decomposition, which must be a positive integer greater than 1.</param>
    /// <remarks>
    /// This method computes the first coefficient <c>k</c> in the p-adic expansion of the rational number <paramref name="q"/> 
    /// with respect to the specified modulus <paramref name="modulus"/> (which serves as the base of the p-adic expansion).
    /// The remainder is the fractional part of the number after subtracting the integer part <c>k</c> and dividing by <paramref name="modulus"/>.
    /// 
    /// Mathematically, this method solves the equation:
    /// <code>
    /// q = k + modulus × remainder
    /// </code>
    /// where <c>k</c> is an integer in the range [0, <paramref name="modulus"/>) and <c>remainder</c> is the fractional part of <paramref name="q"/> after division by <paramref name="modulus"/>.
    /// 
    /// The method uses modular arithmetic to compute <c>k</c> efficiently by solving the congruence:
    /// <code>
    /// k ≡ q.Numerator × (q.Denominator)⁻¹ (mod modulus)
    /// </code>
    /// where <c>q.Denominator⁻¹</c> is the modular inverse of <c>q.Denominator</c> with respect to <paramref name="modulus"/>.
    /// </remarks>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item><description><c>k</c>: An integer representing the integer component of the decomposition, in the range [0, <paramref name="modulus"/>).</description></item>
    /// <item><description><c>q</c>: The remaining fractional part of the decomposition, represented as a rational number <see cref="Q"/>.</description></item>
    /// </list>
    /// </returns>
    /// <example>
    /// This example demonstrates decomposing a rational number with respect to a modulus:
    /// <code>
    /// Q q = new Q(1, 17);
    /// (int k, Q remainder) = FindKQ(q, 5);
    /// Console.WriteLine($"k = {k}, remainder = {remainder}");
    /// // Output: k = 3, remainder = -10 / 17
    /// </code>
    /// </example>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="q"/>'s denominator and <paramref name="modulus"/> are not coprime (i.e., their greatest common divisor is not 1).
    /// </exception>
    public static (int k, Q q) FindKQ(Q q, int modulus)
    {
        BigInteger k = (q.Numerator * q.Denominator.ModularInverse(modulus)).Mod(modulus);
        return ((int)k, (q - k) / modulus);
    }

    /// <summary>
    /// p-adic valuation of the current p-adic number.
    /// </summary>
    /// <returns>Valuation of the number relative to <see cref="Base"/>.</returns>
    public int Valuation() => ValuationOf(Numerator) - ValuationOf(Denominator);

    private int ValuationOf(BigInteger value)
    {
        int count = 0;
        
        value = BigInteger.Abs(value);
        while (value.IsDivisibleBy(Base))
        {
            value /= Base;
            count++;
        }
        return count;
    }


    /// <summary>
    /// Returns a NaN Qp instance.
    /// </summary>
    public new static Qp NaN => new Qp();

    /// <summary>
    /// Constructor for a NaN Qp instance.
    /// </summary>
    private Qp() : base(Q.NaN) => Generator = Qb.NaN;

   

    public Qp(BigInteger Numerator, BigInteger Denominator, int base_) : this(new Q(Numerator, Denominator), base_) {}

    ///<summary>
    /// Constructor for a p-adic number.
    /// </summary>
    /// <param name="q">The rational number to represent as a p-adic number.</param>
    /// <param name="base_">The prime base of the p-adic number.</param>
    public Qp(Q q, int base_) : base(q)
    {

        int firstExponent = -1;

        BigInteger d = q.Denominator;
        while (d.IsDivisibleBy(base_))
        {
            d /= base_;
            firstExponent++;
        }
        Q current = new Q(q.Numerator, d);

        List<(int k, Q q)> list = new List<(int, Q)>();

        int prefixLength;
        while (true)
        {
            (int k, Q q) tuple = FindKQ(current, base_);
            current = tuple.q;

            int index = list.IndexOf(tuple);
            if (index != -1)
            {
                Debug.Assert(current <= 0);
                prefixLength = index;
                break;
            }

            list.Add(tuple);
            //if (current.IsZero)
            //    break;

        }

        BigInteger preperiodicInt = BigInteger.Zero;
        for (int i = 0; i < prefixLength; i++)
        {
            preperiodicInt *= base_;
            preperiodicInt += list[i].k;
        }
        BigInteger periodicInt = BigInteger.Zero;
        for (int i = prefixLength; i < list.Count; i++)
        {
            periodicInt *= base_;
            periodicInt += list[i].k;
        }

        int period = periodicInt.IsZero ? 0 : list.Count - prefixLength;

        Generator = new Qb(
          !q.IsPositive, preperiodicInt.IsZero
              ? BaseInt.Zero(base_, prefixLength)
              : new BaseInt(base_, preperiodicInt, prefixLength), periodicInt.IsZero
                  ? BaseInt.Zero(base_, period)
                  : new BaseInt(base_, periodicInt, period), firstExponent);
    }

    /// <summary>
    /// Constructor for a p-adic number for the specified preperiodic and periodic parts, and an optional first exponent.
    /// </summary>
    /// <param name="pAdicPreperiodic">The p-adic preperiodic part of the number.</param>
    /// <param name="pAdicPeriodic">The p-adic periodic part of the number.</param>
    /// <param name="firstExponent">The first exponent of the number (Default value = <c>0</c>).</param>
    public Qp(BaseInt pAdicPreperiodic, BaseInt pAdicPeriodic, int firstExponent = 0) :
       this(PAdicInterpretation(pAdicPreperiodic, pAdicPeriodic, firstExponent), pAdicPeriodic.Base)
    {
        ArgOutOfRangeException.ThrowIfGreaterThan(firstExponent, 0, nameof(firstExponent));
        _ = pAdicPreperiodic.AssertSameBaseAs(pAdicPeriodic);
    }


    /// <summary>
    /// Generates the p-adic coefficient expansion of a rational number <paramref name="q"/> in the specified base <paramref name="base_"/>.
    /// </summary>
    /// <param name="q">The rational number whose p-adic expansion coefficients are computed.</param>
    /// <param name="base_">The prime base of the p-adic expansion, which must be a positive integer greater than 1.</param>
    /// <param name="yieldDelimiters">
    /// <see langword="true"/> <c>iff</c> delimiter values should be yielded to mark the transition between preperiodic and periodic parts.
    /// When <see langword="true"/>, yields <c>-8</c> after the first coefficient to mark the start of the periodic part detection,
    /// and <c>-9</c> when the periodic cycle is detected.
    /// </param>
    /// <returns>
    /// An infinite enumerable sequence of integers representing the p-adic coefficients in ascending order of significance (least significant digit first).
    /// Each coefficient is in the range [0, <paramref name="base_"/> - 1].
    /// <c>Iff</c> <paramref name="yieldDelimiters"/> is <see langword="true"/>, special delimiter values <c>-8</c> and <c>-9</c> are interspersed to mark structural boundaries.
    /// </returns>
    /// <remarks>
    /// This method implements the standard algorithm for computing p-adic expansions of rational numbers by iteratively applying 
    /// the decomposition formula <see cref="FindKQ(Q, int)"/> to generate coefficients in reverse order (least significant first).
    /// <para>
    /// The algorithm first normalizes the denominator by removing all factors of <paramref name="base_"/> to ensure the denominator 
    /// is coprime to the base, which is a prerequisite for the p-adic expansion to be well-defined.
    /// </para>
    /// <para>
    /// The expansion is ultimately periodic for any rational number, meaning it consists of a finite preperiodic part 
    /// followed by an infinitely repeating periodic part. The method detects this periodicity by tracking when 
    /// the same fractional remainder <c>q</c> is encountered twice in the iteration sequence.
    /// </para>
    /// <para>
    /// When <paramref name="yieldDelimiters"/> is <see langword="true"/>, the method provides structural information:
    /// <list type="bullet">
    /// <item><description><c>-8</c>: Marks the beginning of periodic part detection (yielded after the first coefficient)</description></item>
    /// <item><description><c>-9</c>: Marks the detection of the periodic cycle (yielded when repetition is found)</description></item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <example>
    /// Computing the 5-adic expansion of -4/3:
    /// <code>
    /// Q q = new Q(-4, 3);
    /// var coeffs = PadicCoeffs(q, 5).Take(8).ToArray();
    /// // Results in: [2, 2, 2, 2, 2, 2, 1, 2] representing ...2222222₅
    /// </code>
    /// </example>
    /// <exception cref="ArgumentException">
    /// Thrown <c>iff</c> <paramref name="q"/>'s normalized denominator and <paramref name="base_"/> are not coprime after factoring out all powers of <paramref name="base_"/> from the denominator.
    /// </exception>
    /// <seealso cref="FindKQ(Q, int)"/>
    /// <seealso cref="Coefficients()"/>
    public static IEnumerable<int> PadicCoeffs(Q q, int base_, bool yieldDelimiters = false)
    {
        int firstExponent = -1;

        BigInteger d = q.Denominator;

        Q firstPeriodic = Q.NaN;
        while (d.IsDivisibleBy(base_))
        {
            d /= base_;
            firstExponent--;
        }
        q = new Q(q.Numerator, d, normalize: false);

        while (true)
        {
            (int k, q) = FindKQ(q, base_);
            yield return k;
            if (firstPeriodic.IsNaN)
            {
                if (yieldDelimiters) yield return -8;
                firstPeriodic = q;

            }
            else if (yieldDelimiters && q == firstPeriodic)
                yield return -9;

        }
    }

    public IEnumerable<int> Coefficients() => Generator.Coefficients();

    /// <summary>
    /// Returns a string for the p-adic number in expanded form.
    /// </summary>
    /// <param name="coefficientCount">The number of coefficients to include</param>
    /// <returns></returns>
    public string ToStringExpanded(int coefficientCount = 16) 
        => Generator.ToStringExpanded(coefficientCount);
    
    /// <summary>
    /// Default string representation of the p-adic number.
    /// </summary>
    public override string ToString() => $"{base.ToStringCanonical()} = {ToStringExpanded()}";

    /// <summary>
    /// Returns a reverse generator for the p-adic number denoting the reciprocal of a given integer in the base <paramref name="base_"/>.
    /// </summary>
    /// <param name="n">The integer to take the reciprocal of</param>
    /// <param name="base_">The base (p) of the resulting p-adic number</param>
    private static Qb ReciprocalGenerator(BigInteger n, int base_)
    {
        int firstPeriodicExponent = int.MaxValue;
        BigInteger firsPeriodicRemainder = BigInteger.Zero;

        BigInteger preperiodicInt = BigInteger.Zero;
        BigInteger periodicInt = BigInteger.Zero;

        int exponent = -1;
        foreach ((int coefficient, BigInteger remainder) in ReciprocalCoefficients(n, base_))
        {
            if (firstPeriodicExponent == int.MaxValue && remainder < 0)
            {
                firstPeriodicExponent = exponent;
                firsPeriodicRemainder = remainder;  //found beginning of periodic part
                
            }
            else if (remainder == firsPeriodicRemainder)
                break; //found end of periodic part

            if (firstPeriodicExponent == int.MaxValue)
            {
                preperiodicInt *= base_;
                preperiodicInt += coefficient;
            }
            else
            {
                periodicInt *= base_;
                periodicInt += coefficient;
            }
            exponent--;
        }

        BaseInt preperiodicPart = new BaseInt(base_, preperiodicInt, -1 - firstPeriodicExponent);
        BaseInt periodicPart = new BaseInt(base_, periodicInt, firstPeriodicExponent - exponent);
        Qb qbGen = new Qb(n < BigInteger.Zero, preperiodicPart, periodicPart, -1);
        return qbGen;
    }

    /// <summary>
    /// Generates the p-adic coefficients of the reciprocal of <paramref name="n"/> in the base <paramref name="base_"/>.
    /// Also returns a remainder with each coefficient.
    /// </summary>
    /// <param name="n">The number whose reciprocal's p-adic expansion is computed.</param>
    /// <param name="base_">The prime base of the p-adic expansion.</param>
    /// <returns>An enumerable tuple sequence (coefficient, remainder).</returns>
    public static IEnumerable<(int coefficient, BigInteger remainder)> ReciprocalCoefficients(BigInteger n, int base_)
    {
        BigInteger remainder = 1;  // Start with 1/n
        BigInteger mod = base_;        // Start with modulus p

        while (true)
        {
            // Find the modular inverse of n mod current modulus
            BigInteger modInverse = n.ModularInverse(mod);

            // Calculate the next p-adic coefficient
            BigInteger coefficient = (remainder * modInverse) % base_;
            if (coefficient < 0)
                coefficient += base_;

            yield return ((int)coefficient, remainder % n);
            // Update the remainder (reduce by subtracting the contribution of the current coefficient)
            remainder = (remainder - coefficient * n) / base_;

            mod *= base_;  // Increase mod to handle next precision step
        }
    }

    private Qp AssertSameBaseAs(Qp other)
        => Base == other.Base ? this : throw new ArgumentException($"Bases must be equal: {Base} != {other.Base}");

    public string ToStringPeriodic()
        => IsNaN ? nameof(NaN) : Generator.ToStringPeriodic(FirstExponent == 0 ? "" : FirstExponent.ToString());
}
