using System.Diagnostics;
using System.Numerics;

namespace MathLib;

/// <summary>
/// Represents the field of ultimately periodic p-adic numbers, denoted ℚₚ in mathematics.
/// </summary>
/// <remarks>
/// ℚₚ is the completion of the rational numbers ℚ with respect to the p-adic norm, defined for a given prime p.
/// Each number can be decomposed into a finite preperiodic part and a periodic part in its coefficient expansion. 
/// Both parts can be optionally empty.
/// <para>
/// ℚₚ contains exactly the set ℚ of all rational numbers.
/// </para>
/// ℚₚ is closed under addition, subtraction, multiplication, and division (excluding division by zero), but it is 
/// not algebraically closed. For example, the square root of -1 does not exist in ℚₚ, but it does exist in ℂₚ, 
/// the complex p-adic numbers (<see cref="Cp"/>).
/// <para>
/// The class <see cref="Qp"/> represents these ultimately periodic p-adic numbers and can extend to <see cref="Cp"/> 
/// for operations like √-1.
/// </para>
/// </remarks>
/// <example>
/// A 5-adic expansion for the rational number -4/3 is:
/// <code>
/// -4/3 = …2222222212₅
/// </code>
/// </example>
public class Qp : Q 
{
    /// <summary>
    /// Returns the prime base of this p-adic number.
    /// </summary>
    public Base Base => Generator.Base;

    public int FirstExponent => -Generator.IntegralLength;

    /// <summary>
    /// A reverse generator that can be used to generate the coefficients of the p-adic number, in reverse order (least significant digit first).
    /// </summary>
    public Qb Generator { get; }

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
        while (value.IsDivisibleBy(Base.IntValue))
        {
            value /= Base.IntValue;
            count++;
        }
        return count;
    }



    public Qp(BigInteger Numerator, BigInteger Denominator, Base base_) : this(new Q(Numerator, Denominator), base_) {}

    public Qp(Q q, Base base_) : base(q)
    {

        int firstExponent = -1;

        BigInteger d = q.Denominator;
        while (d.IsDivisibleBy(base_.IntValue))
        {
            d /= base_.IntValue;
            firstExponent++;
        }
        Q current = new Q(q.Numerator, d);

        List<(int k, Q q)> list = new List<(int, Q)>();

        int prefixLength = -1;

        while (true)
        {
            var tuple = FindKQ(current, base_.IntValue);
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
            preperiodicInt *= base_.IntValue;
            preperiodicInt += list[i].k;
        }
        BigInteger periodicInt = BigInteger.Zero;
        for (int i = prefixLength; i < list.Count; i++)
        {
            periodicInt *= base_.IntValue;
            periodicInt += list[i].k;
        }

        int period = periodicInt.IsZero ? 0 : list.Count - prefixLength;

     
        Generator = new Qb(!q.IsNegative, preperiodicInt.IsZero 
            ? BaseInt.Zero(base_, prefixLength) 
            : new BaseInt(base_, preperiodicInt, prefixLength), 
            periodicInt.IsZero 
                ? BaseInt.Zero(base_, period) 
                : new BaseInt(base_, periodicInt, period) , firstExponent);
    }

    //https://math.stackexchange.com/questions/1186967/method-of-finding-a-p-adic-expansion-to-a-rational-number#:~:text=You%20can%20calculate%20the%20p,b%2Fp)%20...
    public static IEnumerable<int> PadicCoeffs(Q q, Base base_, bool yieldDelimiters = false)
    {
        int firstExponent = -1;

        BigInteger d = q.Denominator;

        Q firstPeriodic = Q.NaN;
        while (d.IsDivisibleBy(base_.IntValue))
        {
            d /= base_.IntValue;
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

    //TODO: FIX THIS
    //public Qp(Q q, Base base_) : base(q)
    //{
    //    Qb qb = (this).InBase(base_);
    //    BaseInt pAryPreperiodic = qb.PreperiodicPart;
    //    BaseInt pAryPeriodic = qb.PeriodicPart;

    //    Q preQ = Q.PAdicPreperiodic(pAryPreperiodic, -qb.FirstExponent - 1);
    //    Q perQ = Q.PAdicPeriodic(pAryPeriodic, -qb.FirstExponent - 1 + pAryPreperiodic.Length);

    //    //DebugPAryPreperiodic = pAryPreperiodic;
    //    //DebugPAryPeriodic = pAryPeriodic;

    //    //DebugPAdicPreperiodic = Q.GetPAdicPreperiodic(qb.PreperiodicQ(), pAryPreperiodic, qb.FirstExponent);
    //    //DebugPAdicPeriodic = Q.GetPAdicPeriodic(IsNegative, pAdicPeriodic, -firstExponent - 1 - pAdicPreperiodic.Length);

    //    //Console.WriteLine("PRE: " + preQ);
    //    //Console.WriteLine("PER: " + perQ);
    //    Generator = (preQ + perQ).InBase(base_); //TODO: FIX THIS
    //}

    public Qp(BaseInt pAdicPreperiodic, BaseInt pAdicPeriodic, int firstExponent = 0) :
       base(PAdicInterpretation(pAdicPreperiodic, pAdicPeriodic, firstExponent))
    //PAdicPreperiodic(pAdicPreperiodic, firstExponent)
    //+ PAdicPeriodic(pAdicPeriodic, firstExponent + pAdicPreperiodic.Length))
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(firstExponent, 0, nameof(firstExponent));
        _ = pAdicPreperiodic.AssertSameBaseAs(pAdicPeriodic);

        //Q preQ = PAryPreperiodic(IsNegative, pAdicPreperiodic, -firstExponent - 1);
        //Q perQ = PAryPeriodic(IsNegative, pAdicPeriodic, -firstExponent - 1 - pAdicPreperiodic.Length);   
        //Generator = (preQ + perQ).InBase(pAdicPeriodic.Base);
        Q q = PAryInterpretation(IsNegative, pAdicPreperiodic, pAdicPeriodic, firstExponent);
        
        Generator = q.InBase(pAdicPeriodic.Base);
      
    }


    ///<summary>
    ///Constructor for a p-adic number.
    ///</summary> 
    ///<param name="generator">A generator that generates the coefficients of the p-adic number.</param>
    /// <param name="_">A parameter to denote Q is not the value of Qp (but a generator)</param>
    //public Qp(Qb generator, QIsGenerator _)
    //{
    //    this.Generator = generator;
    //    //CALL BASE CONSTRUCTOR. MUST SET ALL PROPERTIES 
    //}

    public IEnumerable<int> Coefficients() => Generator.Coefficients();

    /// <summary>
    /// Returns a string for the p-adic number in canonical form.
    /// </summary>
    /// <param name="coefficientCount">The number of coefficients to include</param>
    /// <returns></returns>
    public string ToStringCanonical(int coefficientCount = 16)
    {
        //TODO: fix this!
        return Generator.ToStringCanonical(coefficientCount);
        
        //StringBuilder sb = new StringBuilder();
        //int exponent = FirstExponent;
        //foreach (int coeff in Coefficients().Take(coefficientCount))
        //{
        //    sb.Append(coeff);
        //    if (exponent == -1) sb.Append('.');
        //    exponent++;
        //}
        //sb.Append("…");
        //return sb.ToString();
    }
    /// <summary>
    /// Default string representation of the p-adic number.
    /// </summary>
    public override string ToString() => $"{base.ToStringSimple()} = {ToStringCanonical()}";

    /// <summary>
    /// Returns a p-adic number representing 0.
    /// </summary>
    /// <example><code>0₂ = 0000000000000000...</code></example>
    /// <param name="base_">The base</param>
    /// <returns></returns>
   // public static Qp Zero(Base base_) => new Qp(new Qb(0, 1, base_), QIsGenerator.Yes);

    /// <summary>
    /// Returns a p-adic number representing 1.
    /// </summary>
    /// <example><code>1₂ = 1000000000000000...</code></example>
    /// <param name="base_">The base</param>
    /// <returns></returns>
   // public static Qp One(Base base_) => new Qp(new Qb(1, 1, base_), QIsGenerator.Yes);

    /// <summary>
    /// Returns a p-adic number representing -1.
    /// </summary>
    /// <example><code>-1₂ = 1111111111111111...</code></example>
    /// <param name="base_">The base</param>
    /// <returns></returns>
   // public static Qp MinusOne(Base base_) => new Qp(new Qb(-1, 1, base_), QIsGenerator.Yes);


    /// <summary>
    /// Returns a reverse generator for the p-adic number denoting the reciprocal of a given integer in the base <paramref name="base_"/>.
    /// </summary>
    /// <param name="n">The integer to take the reciprocal of</param>
    /// <param name="base_">The base (p) of the resulting p-adic number</param>
    private static Qb ReciprocalGenerator(BigInteger n, Base base_)
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
                preperiodicInt *= base_.IntValue;
                preperiodicInt += coefficient;
            }
            else
            {
                periodicInt *= base_.IntValue;
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
    public static IEnumerable<(int coefficient, BigInteger remainder)> ReciprocalCoefficients(BigInteger n, Base base_)
    {
        BigInteger remainder = 1;  // Start with 1/n
        BigInteger mod = base_.IntValue;        // Start with modulus p

        while (true)
        {
            // Find the modular inverse of n mod current modulus
            BigInteger modInverse = n.ModularInverse(mod);

            // Calculate the next p-adic coefficient
            BigInteger coefficient = (remainder * modInverse) % base_.IntValue;
            if (coefficient < 0)
                coefficient += base_.IntValue;

            yield return ((int)coefficient, remainder % n);
            // Update the remainder (reduce by subtracting the contribution of the current coefficient)
            remainder = (remainder - coefficient * n) / base_.IntValue;

            mod *= base_.IntValue;  // Increase mod to handle next precision step
        }
    }

    private Qp AssertSameBaseAs(Qp other)
        => Base == other.Base ? this : throw new ArgumentException($"Bases must be equal: {Base} != {other.Base}");

}

//public enum QIsGenerator
//{
//    Yes,
//}