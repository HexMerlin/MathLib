using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Buffers.Text;

namespace MathLib.Tests;

[TestClass]
public class BaseIntTests
{


    [TestMethod]
    public void Constructor_For0_Base10_ReturnsCorrectProperties()
    {
        Base base_ = new(10);
        BaseInt bs = new(base_, 0);
        Assert.AreEqual(0, bs.IntValue);
        Assert.AreEqual(0, bs.Length);
        Assert.AreEqual(10, bs.Base.IntValue);
    }


    [TestMethod]
    public void Constructor_For0_Len1_Base10_ThrowsException()
    {
        Base base_ = new(10);
        Assert.ThrowsException<ArgumentException>(() => new BaseInt(base_, 0, 1), "For clarity and robustness, to create value 0 with a non-zero length use BaseInt.Zero() instead.");
    }

    [TestMethod]
    public void Constructor_For1_Base10_ReturnsCorrectProperties()
    {
        Base base_ = new(10);
        BaseInt bs = new(base_, 1);
        Assert.AreEqual(1, bs.IntValue);
        Assert.AreEqual(1, bs.Length);
        Assert.AreEqual(10, bs.Base.IntValue);
    }

    [TestMethod]
    public void Constructor_For1_Len0_Base10_ReturnsCorrectProperties() 
        => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new BaseInt(new Base(10), 1, 0));

    [TestMethod]
    public void Constructor_For54321_Base10_ReturnsCorrectProperties()
    {
        Base base_ = new(10);
        BaseInt bs = new(base_, 54321);
        Assert.AreEqual(54321, bs.IntValue);
        Assert.AreEqual(5, bs.Length);
        Assert.AreEqual(10, bs.Base.IntValue);
    }

    [TestMethod]
    public void First_For54321_Base10_Returns5()
    {
        Base base_ = new(10);
        int expected = 5;
        int actual = new BaseInt(base_, 54321).First;
        Assert.AreEqual(expected, actual); 
    }

    [TestMethod]
    public void Last_For12345_Base10_Returns5()
    {
        Base base_ = new(10);
        int expected = 5;
        int actual = new BaseInt(base_, 12345).Last;
        Assert.AreEqual(expected, actual); 
    }

    [TestMethod]
    public void ShiftRight_For54321_Base10_Returns05432()
    {
        Base base_ = new(10);
        BaseInt expected = new BaseInt(base_, 05432, 5);
        Assert.AreEqual(5, expected.Length);
        BaseInt actual = new BaseInt(base_, 54321) >> 1;
        Assert.AreEqual(5, actual.Length);
        Assert.AreEqual(expected, actual); //, $"Expected: {expected}, Actual {actual}");
    }

    [TestMethod]
    public void ShiftLeft_For54321_Base10_Returns43210()
    {
        Base base_ = new(10);
        BaseInt expected = new BaseInt(base_, 43210, 5);
        Assert.AreEqual(5, expected.Length);
        BaseInt actual = new BaseInt(base_, 54321) << 1;
        Assert.AreEqual(5, actual.Length);
        Assert.AreEqual(expected, actual); //Actual is "138", with length: 5, base: 10
    }
    

    [TestMethod]
    public void Coefficients_For12345_Base10_ReturnsCorrectSequence()
    {
        Base base_ = new(10);
        int[] expected = [1, 2, 3, 4, 5];
        int[] actual = new BaseInt(base_, 12345).Coefficients().ToArray();
        CollectionAssert.AreEqual(expected, actual, $"Expected: {expected.Str()}, Actual {actual.Str()}");
    }

    [TestMethod]
    public void Reverse_For12345_Base10_PAdic_ReturnsCorrect()
    {
        BaseInt actual = new BaseInt(new Base(10), 12345, 5).Reverse();
        Assert.AreEqual(5, actual.Length);
        Assert.AreEqual(54321, actual.IntValue);
    }

    [TestMethod]
    public void Reverse_For12340_Base10_PAry_ReturnsCorrect()
    {
        BaseInt actual = new BaseInt(new Base(10), 12340, 5).Reverse();
        Assert.AreEqual(5, actual.Length);
        Assert.AreEqual(4321, actual.IntValue);
    }

}
