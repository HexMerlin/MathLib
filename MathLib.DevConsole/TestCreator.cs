using System.Text;
using MathLib;

namespace MathLib.DevConsole;



public class TestCreator
{
    public static void CreateTests()
    {
        CreateTestsQbToStringExpandedAndFullInt();
        //CreateTestsConstructorOnParts_FromQb();
    }

    public static void CreateTestsQbToStringExpandedAndFullInt()
    {
        string staticHelper =
@"  private static void ToStringExpandedAndFullInt_ForQb_IsCorrect(string expectedExpanded, Q q, int base_)
    {
        Qb qbActual = q.InBase(base_);

        Assert.AreEqual(expectedExpanded, qbActual.ToStringExpanded());
        string expandedNoDot = expectedExpanded.Replace(""."", """");

        string fullIntString = qbActual.FullInteger.ToStringCoefficient();
        if (fullIntString.Length < expandedNoDot.Length)
            StringAssert.StartsWith(expandedNoDot, fullIntString);
        else
            Assert.AreEqual(expandedNoDot, fullIntString[..expandedNoDot.Length]);
    }
";
        Console.WriteLine($"#region ToStringExpanded and FullInt");
        Console.WriteLine(staticHelper);
        CreateTests(CreateTests_Qb_ToStringExpandedAndFullInt);
        Console.WriteLine($"#endregion");
    }

    public static void CreateTestsConstructorOnParts_FromQb()
    {
        string staticHelper =
@"  private static void ConstructorOnParts_FromQb_ReturnsSame(Q q, int base_)
    {
        if (q < 0)
            return; //TODO: WARNING! TESTS FOR NEGATIVE VALUE ARE CURRENTLY SKIPPED!
        Qb expected = q.InBase(base_);
        Qb actual = new Qb(expected.PreperiodicPart, expected.PeriodicPart, expected.FirstExponent);

        Assert.AreEqual(expected.Base, actual.Base, ""Base differs"");
        Assert.AreEqual(expected.PreperiodicPart, actual.PreperiodicPart, ""PreperiodicPart differs"");
        Assert.AreEqual(expected.PeriodicPart, actual.PeriodicPart, ""PeriodicPart differs"");
        Assert.AreEqual(expected.Period, actual.Period, ""Period differs"");
        Assert.AreEqual(expected.FirstPeriodicExponent, actual.FirstPeriodicExponent, ""FirstPeriodicExponent differs"");
        Assert.AreEqual(expected.FirstExponent, actual.FirstExponent, ""FirstExponent differs"");
        Assert.AreEqual(expected.PreperiodicLength, actual.PreperiodicLength, ""PreperiodicLength differs"");
        Assert.AreEqual(expected, actual, ""Rational number differs"");
    }
";
        Console.WriteLine($"#region Constructor on parts");
        Console.WriteLine(staticHelper);
        CreateTests(Constructor_OnParts_FromQb);
        Console.WriteLine($"#endregion");
    }

   
    private static void Constructor_OnParts_FromQb(Q q, int base_)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"[TestMethod()]");
        sb.AppendLine($" //{q.ToStringCanonical()}, base {(int)base_}");
        string numeratorString = q.Numerator >= 0 ? q.Numerator.ToString() : $"Neg{q.Numerator.Abs()}";

        string numString = q.IsInteger ? $"Int{numeratorString}" : $"Q{numeratorString}div{q.Denominator}";
        sb.AppendLine($"public void ConstructorOnParts_For{numString}_Base{(int) base_}_ReturnsSame()");
        sb.Append($"\t=> ConstructorOnParts_FromQb_ReturnsSame(new Q({q.Numerator}, {q.Denominator}), {(int)base_});");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
    }

    private static void CreateTests_Qb_ToStringExpandedAndFullInt(Q q, int base_)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"[TestMethod()]");
        sb.AppendLine($" //{q.ToStringCanonical()}, base {base_}");
        string numeratorString = q.Numerator >= 0 ? q.Numerator.ToString() : $"Neg{q.Numerator.Abs()}";

        string numString = q.IsInteger ? $"Int{numeratorString}" : $"Q{numeratorString}div{q.Denominator}";
        sb.Append($"public void ToStringExpandedAndFullInt_For{numString}_Base{base_}_IsCorrect()");

        Qb qb = new Qb(q, base_);
        string expected = qb.ToStringExpanded();
        sb.Append($"=> ToStringExpandedAndFullInt_ForQb_IsCorrect(\"{expected}\", new Q({qb.Numerator}, {qb.Denominator}), {(int)base_});");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
    }

    private static void CreateTestsForQAndNegativeQ_Bases235(Q q, Action<Q, int> TestCreationMethod)
    {
        for (int base_ = 2; base_ <= 5; base_++)
        {
            if (base_ == 4) continue;
            
            TestCreationMethod(q, base_);
            if (!q.IsZero)
                TestCreationMethod(-q, base_);
        }
    }

    private static void CreateTests(Action<Q, int> TestCreationMethod)
    {
        TestData td = new TestData();

        Console.WriteLine("// Integer tests");
        foreach (var q in td.posIntegers) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
        Console.WriteLine("// Unit fraction tests");
        foreach (var q in td.posUnitFractions) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
        Console.WriteLine("// 2/x tests");
        foreach (var q in td.posTwoNumeratorQ) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
        Console.WriteLine("// 3/x tests");
        foreach (var q in td.posThreeNumeratorQ) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
        Console.WriteLine("// 4/x tests");
        foreach (var q in td.posFourNumeratorQ) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
        Console.WriteLine("// 5/x tests");
        foreach (var q in td.posFiveNumeratorQ) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
        Console.WriteLine("// Misc Q tests");
        foreach (var q in td.miscPosQ) CreateTestsForQAndNegativeQ_Bases235(q, TestCreationMethod);
    }

}

public class TestData
{
    public Q[] posIntegers = new Q[] {
    new Q(0, 1), new Q(1, 1), new Q(2, 1), new Q(3, 1), new Q(4, 1), new Q(5, 1), new Q(6, 1)
};

    public Q[] posUnitFractions = new Q[] {
    new Q(1, 2), new Q(1, 3), new Q(1, 4), new Q(1, 5), new Q(1, 6),
    new Q(1, 25), new Q(1, 125), new Q(1, 250), new Q(1, 256), new Q(1, 375)
};

    public Q[] posTwoNumeratorQ = new Q[] {
    new Q(2, 3), new Q(2, 5), new Q(2, 7), new Q(2, 125)
};
    public Q[] posThreeNumeratorQ = new Q[] {
    new Q(3, 2), new Q(3, 4), new Q(3, 5), new Q(3, 7), new Q(3, 25)
};

    public Q[] posFourNumeratorQ = new Q[] {
    new Q(4, 3), new Q(4, 5), new Q(4, 7), new Q(4, 9)
};

    public Q[] posFiveNumeratorQ = new Q[] {
    new Q(5, 2), new Q(5, 3), new Q(5, 4), new Q(5, 6)
};

    public Q[] miscPosQ = new Q[] {
    new Q(16, 1), new Q(25, 1), new Q(124, 1), new Q(125, 1), new Q(126, 1),
    new Q(153, 1), new Q(255, 1), new Q(256, 1),
    new Q(9, 7), new Q(22, 3), new Q(12, 125), new Q(37, 125), new Q(23, 18), new Q(537, 11)
    };
}

