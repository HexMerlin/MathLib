using System.Numerics;
using System.Text;

namespace MathLib.DevConsole;

public static class TestCreatorQp
{
    public static void CreateTests()
    {
        Console.WriteLine(CreateTests(2));
    }

    public static string CreateTests(int base_)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("    #region Qp FromQ Q");
        sb.AppendLine(StaticTestHelper());
        foreach (Qp qp in TestSetQp())
           sb.AppendLine(CreateTest(qp, base_));
        
        
        sb.AppendLine("\n    #endregion Qp FromQ Q");
        return sb.ToString();
    }   

    public static string StaticTestHelper() => @"
    private static void QpFromQ_IsCorrect(Qp qp, int expBase, BigInteger expNumerator, BigInteger expDenominator, BigInteger expGeneratorNumerator, BigInteger expectedGeneratorDenominator)
    {
        Assert.AreEqual(new Base(expBase), qp.Base, nameof(qp.Base));
        Assert.AreEqual(expNumerator, qp.Numerator, nameof(qp.Numerator));
        Assert.AreEqual(expDenominator, qp.Denominator, nameof(qp.Denominator));
        Assert.AreEqual(expGeneratorNumerator, qp.Generator.Numerator, nameof(qp.Generator.Numerator));
        Assert.AreEqual(expectedGeneratorDenominator, qp.Generator.Denominator, nameof(qp.Generator.Denominator));
    }";

    public static string CreateTest(Qp qp, int base_ = 2)
    {
        string qpDescr = $"{(qp.IsNegative ? "Neg" : "")}{qp.Numerator.Abs()}{(qp.Denominator > 0 ? "Div" + qp.Denominator : "" )}";
        return 
$@"   [TestMethod()] public void QpFromQ_For{qpDescr}_Base{base_}_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q({qp.Numerator}, {qp.Denominator}), new Base({base_})), {base_}, {qp.Numerator}, {qp.Denominator}, {qp.Generator.Numerator}, {qp.Generator.Denominator});";

    }

    public static Qp[] TestSetQp(int baseValue = 2)
    {
        int base_ = baseValue;
        int MinLen(int intValue) => new BigInteger(intValue).Length(baseValue);

        HashSet<Qp> qps = new HashSet<Qp>();

        for (int len = 0; len <= 9; len++)
        {
            for (int preLen = 0; preLen <= 3; preLen++)
            {
                int perLen = len - preLen;
                for (int preInt = 0; preInt < 100; preInt++)
                {
                    int minLen = MinLen(preInt);
                    if (minLen > preLen)
                        break;
                    BaseInt prePeriodic = preInt == 0 ? BaseInt.Zero(base_, preLen) : new BaseInt(base_, preInt, preLen);
                    for (int perInt = 0; perInt < 100; perInt++)
                    {
                        if (perInt is > 30 and < 85) continue; //Skip some

                        minLen = MinLen(perInt);
                        if (minLen > perLen)
                            break;
                        BaseInt periodic = perInt == 0 ? BaseInt.Zero(base_, perLen) : new BaseInt(base_, perInt, perLen);

                        for (int firstExponent = -2; firstExponent <= 0; firstExponent++)
                        {
                            Qp qpX = new Qp(prePeriodic, periodic, firstExponent);
                            qps.Add(qpX);
                        }
                    }
                }
            }
        }
        return qps.OrderBy(qp => qp.Numerator.Abs()).ThenBy(qp => qp.Denominator).ThenBy(qp => qp).ToArray();
    }
}
