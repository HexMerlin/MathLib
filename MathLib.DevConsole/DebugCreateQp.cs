using System.Numerics;
namespace MathLib.DevConsole;

public class DebugCreateQp
{
    public static Qp CreateQp(Q q, int baseValue, int maxLen = 9)
    {
        Base base_ = new Base(baseValue);
        int MinLen(int intValue) => new BigInteger(intValue).Length(baseValue);

        for (int len = 0; len <= maxLen; len++)
        {
            for (int preLen = 0; preLen <= 3; preLen++)
            {
                int perLen = len - preLen;
                for (int preInt = 0; ; preInt++)
                {
                    int minLen = MinLen(preInt);
                    if (minLen > preLen)
                        break;
                    BaseInt prePeriodic = preInt == 0 ? BaseInt.Zero(base_, preLen) : new BaseInt(base_, preInt, preLen);
                    for (int perInt = 0; ; perInt++)
                    {
                        minLen = MinLen(perInt);
                        if (minLen > perLen)
                            break;
                        BaseInt periodic = perInt == 0 ? BaseInt.Zero(base_, perLen) : new BaseInt(base_, perInt, perLen);

                        for (int firstExponent = -2; firstExponent <= 0; firstExponent++)
                        {
                            Qp qp = new Qp(prePeriodic, periodic, firstExponent);
                            if (qp.Numerator == q.Numerator && qp.Denominator == q.Denominator)
                                return qp;
                        }
                    }
                }
            }
        }
        throw new Exception("Qp not found");
    }
}
