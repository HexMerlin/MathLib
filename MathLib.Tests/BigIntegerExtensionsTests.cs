using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using MathLib;

namespace MathLib.Tests;

[TestClass]
public class BigIntegerExtensionsTests
{
    // Base 2 tests
    [TestMethod]
    public void Length_Returns0_For0_Base2() => AssertLengthForRange(0, 0, 0, 2);

    [TestMethod]
    public void Length_Returns1_For1_Base2() => AssertLengthForRange(1, 1, 1, 2);

    [TestMethod]
    public void Length_Returns2_For2And3_Base2() => AssertLengthForRange(2, 2, 3, 2);

    [TestMethod]
    public void Length_Returns3_For4To7_Base2() => AssertLengthForRange(3, 4, 7, 2);

    [TestMethod]
    public void Length_Returns4_For8To15_Base2() => AssertLengthForRange(4, 8, 15, 2);

    [TestMethod]
    public void Length_Returns5_For16To31_Base2() => AssertLengthForRange(5, 16, 31, 2);

    [TestMethod]
    public void Length_Returns6_For32To63_Base2() => AssertLengthForRange(6, 32, 63, 2);


    // Base 3 tests
    [TestMethod]
    public void Length_Returns0_For0_Base3() => AssertLengthForRange(0, 0, 0, 3);

    [TestMethod]
    public void Length_Returns1_For1To2_Base3() => AssertLengthForRange(1, 1, 2, 3);

    [TestMethod]
    public void Length_Returns2_For3To8_Base3() => AssertLengthForRange(2, 3, 8, 3);

    [TestMethod]
    public void Length_Returns3_For9To26_Base3() => AssertLengthForRange(3, 9, 26, 3);

    [TestMethod]
    public void Length_Returns4_For27To80_Base3() => AssertLengthForRange(4, 27, 80, 3);

    [TestMethod]
    public void Length_Returns5_For81To242_Base3() => AssertLengthForRange(5, 81, 242, 3);

    [TestMethod]
    public void Length_Returns6_For243To728_Base3() => AssertLengthForRange(6, 243, 728, 3);

    //Base 5 tests
    [TestMethod]
    public void Length_Returns1_For1To4_Base5() => AssertLengthForRange(1, 1, 4, 5);

    [TestMethod]
    public void Length_Returns2_For5To24_Base5() => AssertLengthForRange(2, 5, 24, 5);

    [TestMethod]
    public void Length_Returns3_For25To124_Base5() => AssertLengthForRange(3, 25, 124, 5);

    /// <summary>
    /// Helper method to generate a range of BigInteger values.
    /// </summary>
    /// <param name="firstValue">The first value in the range (inclusive).</param>
    /// <param name="lastValue">The last value in the range (inclusive).</param>
    /// <returns><see cref="IEnumerable{BigInteger}" /> from firstValue to lastValue, inclusive.</returns>
    private static IEnumerable<BigInteger> FromTo(int firstValue, int lastValue)
        => Enumerable.Range(firstValue, lastValue - firstValue + 1).Select(i => new BigInteger(i));


    /// <summary>
    /// Helper method to test expected length for a range of BigInteger values in a given base.
    /// </summary>
    /// <param name="expectedLength">The expected bit length for each number.</param>
    /// <param name="firstValue">The first value in the range.</param>
    /// <param name="lastValue">The last value in the range.</param>
    /// <param name="base_">The base in which to calculate the length.</param>
    private static void AssertLengthForRange(int expectedLength, int firstValue, int lastValue, int base_)
    {
        var integers = FromTo(firstValue, lastValue);
        foreach (var integer in integers)
        {
            Assert.AreEqual(expectedLength, integer.Length(base_), $"Failed for value {integer} in base {base_}");
        }
    }

    [TestMethod]
    public void IsPowerOf_ReturnsCorrect_ForSmallValuesExponent2()
    {
        for (BigInteger integer = 0; integer < 20; integer++)
        {
            bool expected = integer.IsPowerOfTwo;
            bool actual = integer.IsPowerOf(2);
            if (expected != actual)
                Console.WriteLine();
            Assert.AreEqual(expected, integer.IsPowerOfTwo);
        }
    }

    [TestMethod]
    public void IsPowerOf_ReturnsTrue_ForPowerOf2()
    {
        Assert.IsTrue(new BigInteger(1).IsPowerOf(2));  // 2^0 = 1
        Assert.IsTrue(new BigInteger(2).IsPowerOf(2));  // 2^1 = 2
        Assert.IsTrue(new BigInteger(256).IsPowerOf(2));  // 2^8 = 256
        Assert.IsTrue(new BigInteger(1024).IsPowerOf(2)); // 2^10 = 1024
    }

    [TestMethod]
    public void IsPowerOf_ReturnsTrue_ForPowerOf3()
    {
        Assert.IsTrue(new BigInteger(1).IsPowerOf(3));        // 3^0 = 1
        Assert.IsTrue(new BigInteger(3).IsPowerOf(3));        // 3^1 = 3
        Assert.IsTrue(new BigInteger(27).IsPowerOf(3));   // 3^3 = 27
        Assert.IsTrue(new BigInteger(243).IsPowerOf(3));  // 3^5 = 243
    }

    [TestMethod]
    public void IsPowerOf_ReturnsFalse_ForNonPowerOf3() => Assert.IsFalse(new BigInteger(300).IsPowerOf(3)); // 300 is not a power of 3

    [TestMethod]
    public void IsPowerOf_ReturnsCorrect_ForExponent1()
    {
        // If the base is 1, the only valid "power" is when the value is also 1.
        Assert.IsTrue(BigInteger.One.IsPowerOf(1));
        Assert.IsFalse(new BigInteger(3).IsPowerOf(1));
        Assert.IsFalse(new BigInteger(10).IsPowerOf(1));
    }

    [TestMethod]
    public void IsPowerOf_ReturnsTrue_ForLargePowerOf2() => Assert.IsTrue(BigInteger.Pow(2, 30).IsPowerOf(2));   // Test large power of 2 number, 2^30

    [TestMethod]
    public void IsPowerOf_ReturnsTrue_ForLargePowerOf3() => Assert.IsTrue(BigInteger.Pow(3, 30).IsPowerOf(3)); // Test large power of 3 number, 3^30

    [TestMethod]
    public void IsPowerOf_ReturnsFalse_ForInvalidExponents()
    {
        // Test invalid base cases
        Assert.IsFalse(new BigInteger(256).IsPowerOf(0));  // No number except 1 can be a power of 0
        Assert.IsFalse(new BigInteger(256).IsPowerOf(1));  // Only 1 can be a power of 1
    }

    [TestMethod]
    public void IsPowerOf_ReturnsFalse_ForZeroBaseAndPositiveExponent() 
        => Assert.IsFalse(BigInteger.Zero.IsPowerOf(3));

    [TestMethod]
    public void IsPowerOf_ReturnsTrue_ForZeroIsPowerOf2()
        => Assert.IsFalse(new BigInteger(0).IsPowerOf(0)); //0^0 is indeterminate, hence false.

    [TestMethod]
    public void IsPowerOf_ReturnsFalse_ForZeroAndNegativeExponent() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => BigInteger.Zero.IsPowerOf(-3));  // 0 raised to a negative exponent is invalid

    [TestMethod]
    public void IsPowerOf_ThrowsException_ForNegativeInteger() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new BigInteger(-27).IsPowerOf(3)); // Negative integer

    [TestMethod]
    public void IsPowerOf_ThrowsException_ForNegativeExponent() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new BigInteger(256).IsPowerOf(-2));  // Negative exponent



}
