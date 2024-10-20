using System.Diagnostics;
using System.Numerics;

namespace MathLib;

public partial class Q
{

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
        int b = pAryPreperiodic.AssertSameBaseAs(pAryPeriodic).Base;
        int firstPeriodicExponent = firstExponent - pAryPreperiodic.Length + 1;

        Q result = new Q(pAryPreperiodic.IntValue);

        if (!pAryPeriodic.IsZero)
           result += new Q(pAryPeriodic.IntValue) / (b.Pow(pAryPeriodic.Length) - 1);

        return result.Negation(negative) * b.Pow(firstPeriodicExponent);

    }

    public static Q PAdicInterpretation(BaseInt pAdicPreperiodic, BaseInt pAdicPeriodic, int firstExponent = 0)
    {
        int b = pAdicPreperiodic.AssertSameBaseAs(pAdicPeriodic).Base;
        BaseInt pAryPreperiodic = pAdicPreperiodic.Reverse();
        BaseInt pAryPeriodic = pAdicPeriodic.Reverse();

        Q result = new Q(pAryPreperiodic.IntValue);

        if (!pAryPeriodic.IsZero)
            result -= new Q(pAryPeriodic.IntValue) * b.Pow(pAryPreperiodic.Length) / (b.Pow(pAryPeriodic.Length) - 1);

        result *= b.Pow(firstExponent);
        return result;
    }


    //Original
    //public static Q PAryInterpretation(bool negative, BaseInt pAryPreperiodic, BaseInt pAryPeriodic, int firstExponent = -1)
    //{
    //    _ = pAryPreperiodic.AssertSameBaseAs(pAryPeriodic);
    //    Q preQ = PAryPreperiodic(negative, pAryPreperiodic, firstExponent);
    //    Q perQ = PAryPeriodic(negative, pAryPeriodic, firstExponent - pAryPreperiodic.Length);
    //    return preQ + perQ;
    //}

    //Original
    //public static Q PAdicInterpretation(BaseInt pAdicPreperiodic, BaseInt pAdicPeriodic, int firstExponent = 0)
    //{
    //    _ = pAdicPreperiodic.AssertSameBaseAs(pAdicPeriodic);
    //    Q preQ = PAdicPreperiodic(pAdicPreperiodic, firstExponent);
    //    Q perQ = PAdicPeriodic(pAdicPeriodic, firstExponent + pAdicPreperiodic.Length);
    //    return preQ + perQ;
    //}




    public static Q PAryPreperiodic(bool negative, BaseInt pAryPreperiodic, int firstExponent = -1)
        => new Q(pAryPreperiodic.IntValue).Negation(negative) * pAryPreperiodic.Base.Pow(firstExponent + 1 - pAryPreperiodic.Length);

    public static Q PAdicPreperiodic(BaseInt pAdicPreperiodic, int firstExponent = 0)
    {
        BaseInt pAryPreperiodic = pAdicPreperiodic.Reverse();
        return (new Q(pAryPreperiodic.IntValue)) * pAryPreperiodic.Base.Pow(firstExponent);
    }


    public static Q PAryPeriodic(bool negative, BaseInt pAryPeriodic, int firstPeriodicExponent)
    {
        int base_ = pAryPeriodic.Base;

        Q qPeriodic = pAryPeriodic.IsZero ? Q.Zero : new Q(pAryPeriodic.IntValue, BigInteger.Pow(pAryPeriodic.Base, pAryPeriodic.Length) - 1);

        return qPeriodic.Negation(negative) * pAryPeriodic.Base.Pow(firstPeriodicExponent + 1);
    }

    public static Q PAdicPeriodic(BaseInt pAdicPeriodic, int firstPeriodicExponent)
    {
        BaseInt pAryPeriodic  = pAdicPeriodic.Reverse();

        Q qPeriodic = pAryPeriodic.IsZero ? Q.Zero : new Q(pAryPeriodic.IntValue, BigInteger.Pow(pAryPeriodic.Base, pAryPeriodic.Length) - 1);
        return -qPeriodic * pAryPeriodic.Base.Pow(firstPeriodicExponent);
    }

    public static BaseInt GetPAdicPreperiodic(Q pAdicPreperiodicQ, BaseInt pAryPreperiodic, int firstExponent)
    {
        int base_ = pAryPreperiodic.Base;
        pAdicPreperiodicQ /= base_.Pow(firstExponent);
        Qb qb = pAdicPreperiodicQ.InBase(base_);
        return qb.PreperiodicPart.Reverse();
    }

}
