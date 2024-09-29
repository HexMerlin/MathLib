using System.Diagnostics;
using System.Numerics;

namespace MathLib;


public class QTuple
{
    public Base Base => Qb.Base;

    public Qb Qb { get; }

    //public Q Prefix { get; }

    //public Q Periodic { get; }

    public QTuple(Q q, int base_) : this(new Qb(q, new Base(base_)))
    {

    }

    public QTuple(Qb qb)
    {
        this.Qb = qb;
        //BaseInt prefixInt = Qb.PreperiodicPart;
        //BaseInt periodicInt = Qb.PeriodicPart;
        //int firstPeriodicExponent = Qb.FirstExponent + 1 - prefixInt.Length;
        //Console.WriteLine(periodicInt);
        //Prefix = new Q(qb.PreperiodicPart.IntValue).Negation(qb.IsNegative) * Base.Pow(firstPeriodicExponent);
        //Periodic = periodicInt.IsZero ? Q.Zero : new Q(periodicInt.IntValue).Negation(qb.IsNegative) / (Base.Pow(periodicInt.Length) - 1) * Base.Pow(firstPeriodicExponent);
        //Debug.Assert(qb == Prefix + Periodic);
    }

    static Q AssertInteger(Q q) { Debug.Assert(q.IsInteger); return q; }

    public Qb Flip()
    {
      
        BigInteger periodInt = AssertInteger(Qb * (Base.Pow(Qb.Period) - 1)).Numerator;

        Debug.Assert(periodInt != 0);

        int sign = periodInt.Sign;
        BigInteger revInt = BaseInt.ReverseInt(Base.IntValue, periodInt.Abs(), Qb.Period);
        revInt *= -sign; //reverse original sign

        //Console.WriteLine();
        //Console.WriteLine("Revint: " + revInt);
        Qb revQb = (new Q(revInt) / (Base.Pow(Qb.Period) - 1)).InBase(Base);
        //BaseInt prefixInt0 = qb.PreperiodicPart;

        //Console.WriteLine(revQb);
        //Console.WriteLine("Rev Q: " +  revQb.ToStringCanonical(60));

        return revQb;
        //int firstExponent = 1 - qb.FirstExponent;

        //Qb periodicQb = new Qb(Periodic, Base);




    }

    //private QTuple(Q prefix, Q periodic)
    //{
    //    //Prefix = prefix;
    //    //Periodic = periodic;
    //}

    /// <summary>
    /// Returns a <see cref="Q"/> from the given parts of a base-specific expansion.
    /// </summary>
    /// <remarks>
    /// This method derives the <see cref="Numerator"/> and <see cref="Denominator"/> from the given parameters.
    /// </remarks>
    /// <param name="negative">A boolean indicating if the number is negative.</param>
    /// <param name="pAryPreperiodic">The preperiodic part as an integer.</param>
    /// <param name="pAryPeriodic">The periodic part as an integer.</param>
    /// <param name="firstExponent">The exponent index of the first coefficient of the number.</param>
    /// <exception cref="ArgumentException">Thrown when the bases of <paramref name="pAryPreperiodic"/> and <paramref name="pAryPeriodic"/> are not equal.</exception>
    /// <returns>A new <see cref="Q"/> representing the rational number derived from the given parts.</returns>
    public static Q PAryInterpretation(bool negative, BaseInt pAryPreperiodic, BaseInt pAryPeriodic, int firstExponent = -1)
    {
        Base b = pAryPreperiodic.AssertSameBaseAs(pAryPeriodic).Base;
        int firstPeriodicExponent = firstExponent - pAryPreperiodic.Length + 1;

        Q result = new Q(pAryPreperiodic.IntValue);

        if (!pAryPeriodic.IsZero)
            result += new Q(pAryPeriodic.IntValue) / (b.Pow(pAryPeriodic.Length) - 1);

        return result.Negation(negative) * b.Pow(firstPeriodicExponent);

    }

    public static Q PAdicInterpretation(BaseInt pAdicPreperiodic, BaseInt pAdicPeriodic, int firstExponent = 0)
    {
        Base b = pAdicPreperiodic.AssertSameBaseAs(pAdicPeriodic).Base;
        BaseInt pAryPreperiodic = pAdicPreperiodic.Reverse();
        BaseInt pAryPeriodic = pAdicPeriodic.Reverse();

        Q result = new Q(pAryPreperiodic.IntValue);

        if (!pAryPeriodic.IsZero)
            result -= new Q(pAryPeriodic.IntValue) * b.Pow(pAryPreperiodic.Length) / (b.Pow(pAryPeriodic.Length) - 1);

        result *= b.Pow(firstExponent);
        return result;
    }
}
