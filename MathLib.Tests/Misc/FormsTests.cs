using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace MathLib.Misc.Tests;

[TestClass()]
public class FormsTests
{
    private static void AssertNonAdjacentFormIsExpected(BigInteger expected)
    {
        BigInteger weight = BigInteger.One;
        BigInteger sum = 0;
        bool prevWasZero = true;
        foreach (int c in expected.ToNonAdjacentForm())
        {
            if (c == 0)
                prevWasZero = true;
            else if (c is -1 or 1)
            {
                Assert.IsTrue(prevWasZero, $"Invalid NAF sequence: contains consecutive non-zero digits");
                sum += c * weight;
                prevWasZero = false;
            }
            else
                Assert.Fail($"Invalid NAF digit for number {expected}: {c}");
            weight *= 2;
        }
        Assert.AreEqual(expected, sum, $"The sum of the NAF digits does not equal the expected number {expected}");
    }

    public static void AssertBalancedBinaryIsExpected(BigInteger expected)
    {
        BigInteger weight = BigInteger.One;
        BigInteger sum = 0;

        var debug = expected.ToBalancedBinary().ToArray();

        foreach (int c in expected.ToBalancedBinary())
        {
            if (c is -1 or 1)
                sum += c * weight;
            else Assert.Fail($"Invalid balanced binary digit for number {expected}: {c}");
            weight *= 2;
        }

        Assert.AreEqual(expected, sum, $"The sum of the balanced binary digits does not equal the expected number {expected}");
    }

    public static void AssertToBalancedDigitsHasValidSolution(BigInteger integer, int[] constraints)
    {
        var digits = Forms.ToBalancedDigits(integer, constraints);

        bool lengthCheck = digits.Length == constraints.Length;
        Assert.AreEqual(constraints.Length, digits.Length, $"The number of digits in the balanced representation must be equal to constraints array");

        bool firstLastCheck = digits[0] is -1 or 1 && digits[^1] is -1 or 1;
        Assert.IsTrue(firstLastCheck, $"The first and last digits of the balanced representation must be -1 or 1");

        bool parityCheck = digits.Zip(constraints, (d, c) => d.Mod(2) == c.Mod(2)).All(check => check);
        Assert.IsTrue(parityCheck, $"The parity of each digit must match its corresponding constraint value");

        bool absValueCheck = digits.Zip(constraints, (d, c) => Math.Abs(d) <= Math.Abs(c)).All(check => check);
        Assert.IsTrue(absValueCheck, $"The absolute value of each digits must be <= its corresponding constraint value");

        BigInteger weightedSum = digits.Select((d, i) => d * BigInteger.Pow(2, i)).Aggregate(BigInteger.Zero, (acc, x) => acc + x);
        bool sumCheck = weightedSum == integer;
        Assert.IsTrue(sumCheck, $"The weighted sum of the digits must equal the input integer");
    }

    [TestMethod()]
    public void ToNonAdjacentFormTest_ForRange_ReturnsCorrect()
    {
        for (BigInteger expected = -31; expected <= 31; expected++)
            AssertNonAdjacentFormIsExpected(expected);
    }

    [TestMethod()]
    public void ToBalancedBinary_ForRange_ReturnsCorrect()
    {
        for (BigInteger expected = -31; expected <= 31; expected += 2)
            AssertBalancedBinaryIsExpected(expected);
    }

    [TestMethod()]
    public void ToBalancedDigitsTest()
    {
        (BigInteger integer, int[] constraints)[] testCases = new (BigInteger integer, int[] constraints)[]
        {
            (1, new[] {1, 1}),
            (-1, new[] {1, 1}),
            (9, new[] {1, 2, 1}),
            (-9, new[] {1, 2, 1}),
            (15, new[] {1, 2, 2, 1}),
            (-15, new[] {1, 2, 2, 1}),
            (25, new[] {1, 2, 3, 2, 1}),
            (-25, new[] {1, 2, 3, 2, 1}),
            (2581, new[] {1, 2, 3, 4, 5, 5, 5, 4, 3, 2, 1}),
            (-2581, new[] {1, 2, 3, 4, 5, 5, 5, 4, 3, 2, 1}),
            (20291, new[] {1, 2, 3, 4, 5, 6, 7, 7, 6, 5, 4, 3, 2, 1}),
            (-20291, new[] {1, 2, 3, 4, 5, 6, 7, 7, 6, 5, 4, 3, 2, 1})
        };
        foreach ((BigInteger integer, int[] constraints) in testCases)
        {
            AssertToBalancedDigitsHasValidSolution(integer, constraints);
        }
    }
}