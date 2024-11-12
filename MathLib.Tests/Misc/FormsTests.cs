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

    [TestMethod()]
    public void ToNonAdjacentFormTest_ForRange_ReturnsCorrect()
    {
        for (BigInteger expected = -31; expected <= 31; expected++)
            AssertNonAdjacentFormIsExpected(expected);
    }

    [TestMethod()]
    public void ToBalancedBinary_ForRange_ReturnsCorrect()
    {
        for (BigInteger expected = -31; expected <= 31; expected+=2)
            AssertBalancedBinaryIsExpected(expected);
    }
  
}  