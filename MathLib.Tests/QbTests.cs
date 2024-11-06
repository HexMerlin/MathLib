using MathLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLib.Tests;

[TestClass()]
public class QbTests
{

    #region ShiftedFractions
    //base 2 tests
    [TestMethod()]
    public void ShiftedFractions_For0_Base2_ReturnsEmptySequence()
    {
        Q[] expected = [];
        Q[] actual = Q.Zero.InBase(2).ShiftedFractions().Select(t => t.Fraction).Take(expected.Length).ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod()]
    public void ShiftedFractions_ForQ9div7_Base2_ReturnsCorrectSequence()
    {
        Q[] expected = [new(9, 14), new(2, 7), new(4, 7), new(1, 7), new(2, 7), new(4, 7), new(1, 7)];
        Q[] actual = new Q(9, 7).InBase(base_: 2).ShiftedFractions().Select(t => t.Fraction).Take(expected.Length).ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void ShiftedFractions_ForQ22div3_Base2_ReturnsCorrectSequence()
    {
        Q[] expected = [new(11, 12), new(5, 6), new(2, 3), new(1, 3), new(2, 3), new(1, 3), new(2, 3), new(1, 3)];
        Q[] actual = new Q(22, 3).InBase(2).ShiftedFractions().Select(t => t.Fraction).Take(expected.Length).ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }

    //base 3 tests
    [TestMethod()]
    public void ShiftedFractions_For0_Base3_ReturnsEmptySequence()
    {
        Q[] expected = [];
        Q[] actual = Q.Zero.InBase(3).ShiftedFractions().Select(t => t.Fraction).Take(expected.Length).ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }

    #endregion

    #region Coefficients
    [TestMethod()]
    public void Coefficients_ForQ537div11_Base5_ReturnsCorrectSequence()
    {
        int[] expected = [1, 4, 3, 4, 0, 2, 1, 1, 4, 0, 2, 1, 1, 4];
        int[] actual = new Qb(537, 11, 5).Coefficients().Take(expected.Length).ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }
    #endregion

    #region Constructor on parts
    private static void ConstructorOnParts_FromQb_ReturnsSame(Q q, int base_)
    {
        Qb expected = q.InBase(base_);
        Qb actual = new Qb(q.IsNegative, expected.PreperiodicPart, expected.PeriodicPart, expected.FirstExponent);

        Assert.AreEqual(expected.Base, actual.Base, "Base differs");
        Assert.AreEqual(expected.PreperiodicPart, actual.PreperiodicPart, "PreperiodicPart differs");
        Assert.AreEqual(expected.PeriodicPart, actual.PeriodicPart, "PeriodicPart differs");
        Assert.AreEqual(expected.Period, actual.Period, "Period differs");
        Assert.AreEqual(expected.FirstPeriodicExponent, actual.FirstPeriodicExponent, "FirstPeriodicExponent differs");
        Assert.AreEqual(expected.FirstExponent, actual.FirstExponent, "FirstExponent differs");
        Assert.AreEqual(expected.PreperiodicLength, actual.PreperiodicLength, "PreperiodicLength differs");
        Assert.AreEqual(expected, actual, "Rational number differs");

       

    }

    // Integer tests
    [TestMethod()] //0, base 2
    public void ConstructorOnParts_ForInt0_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(0, 1), 2);

    [TestMethod()] //0, base 3
    public void ConstructorOnParts_ForInt0_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(0, 1), 3);

    [TestMethod()] //0, base 5
    public void ConstructorOnParts_ForInt0_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(0, 1), 5);

    [TestMethod()] //1, base 2
    public void ConstructorOnParts_ForInt1_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 1), 2);

    [TestMethod()] //-1, base 2
    public void ConstructorOnParts_ForIntNeg1_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 1), 2);

    [TestMethod()] //1, base 3
    public void ConstructorOnParts_ForInt1_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 1), 3);

    [TestMethod()] //-1, base 3
    public void ConstructorOnParts_ForIntNeg1_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 1), 3);

    [TestMethod()] //1, base 5
    public void ConstructorOnParts_ForInt1_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 1), 5);

    [TestMethod()] //-1, base 5
    public void ConstructorOnParts_ForIntNeg1_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 1), 5);

    [TestMethod()] //2, base 2
    public void ConstructorOnParts_ForInt2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 1), 2);

    [TestMethod()] //-2, base 2
    public void ConstructorOnParts_ForIntNeg2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 1), 2);

    [TestMethod()] //2, base 3
    public void ConstructorOnParts_ForInt2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 1), 3);

    [TestMethod()] //-2, base 3
    public void ConstructorOnParts_ForIntNeg2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 1), 3);

    [TestMethod()] //2, base 5
    public void ConstructorOnParts_ForInt2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 1), 5);

    [TestMethod()] //-2, base 5
    public void ConstructorOnParts_ForIntNeg2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 1), 5);

    [TestMethod()] //3, base 2
    public void ConstructorOnParts_ForInt3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 1), 2);

    [TestMethod()] //-3, base 2
    public void ConstructorOnParts_ForIntNeg3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 1), 2);

    [TestMethod()] //3, base 3
    public void ConstructorOnParts_ForInt3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 1), 3);

    [TestMethod()] //-3, base 3
    public void ConstructorOnParts_ForIntNeg3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 1), 3);

    [TestMethod()] //3, base 5
    public void ConstructorOnParts_ForInt3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 1), 5);

    [TestMethod()] //-3, base 5
    public void ConstructorOnParts_ForIntNeg3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 1), 5);

    [TestMethod()] //4, base 2
    public void ConstructorOnParts_ForInt4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 1), 2);

    [TestMethod()] //-4, base 2
    public void ConstructorOnParts_ForIntNeg4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 1), 2);

    [TestMethod()] //4, base 3
    public void ConstructorOnParts_ForInt4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 1), 3);

    [TestMethod()] //-4, base 3
    public void ConstructorOnParts_ForIntNeg4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 1), 3);

    [TestMethod()] //4, base 5
    public void ConstructorOnParts_ForInt4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 1), 5);

    [TestMethod()] //-4, base 5
    public void ConstructorOnParts_ForIntNeg4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 1), 5);

    [TestMethod()] //5, base 2
    public void ConstructorOnParts_ForInt5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 1), 2);

    [TestMethod()] //-5, base 2
    public void ConstructorOnParts_ForIntNeg5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 1), 2);

    [TestMethod()] //5, base 3
    public void ConstructorOnParts_ForInt5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 1), 3);

    [TestMethod()] //-5, base 3
    public void ConstructorOnParts_ForIntNeg5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 1), 3);

    [TestMethod()] //5, base 5
    public void ConstructorOnParts_ForInt5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 1), 5);

    [TestMethod()] //-5, base 5
    public void ConstructorOnParts_ForIntNeg5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 1), 5);

    [TestMethod()] //6, base 2
    public void ConstructorOnParts_ForInt6_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(6, 1), 2);

    [TestMethod()] //-6, base 2
    public void ConstructorOnParts_ForIntNeg6_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-6, 1), 2);

    [TestMethod()] //6, base 3
    public void ConstructorOnParts_ForInt6_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(6, 1), 3);

    [TestMethod()] //-6, base 3
    public void ConstructorOnParts_ForIntNeg6_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-6, 1), 3);

    [TestMethod()] //6, base 5
    public void ConstructorOnParts_ForInt6_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(6, 1), 5);

    [TestMethod()] //-6, base 5
    public void ConstructorOnParts_ForIntNeg6_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-6, 1), 5);

    // Unit fraction tests
    [TestMethod()] //1/2, base 2
    public void ConstructorOnParts_ForQ1div2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 2), 2);

    [TestMethod()] //-1/2, base 2
    public void ConstructorOnParts_ForQNeg1div2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 2), 2);

    [TestMethod()] //1/2, base 3
    public void ConstructorOnParts_ForQ1div2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 2), 3);

    [TestMethod()] //-1/2, base 3
    public void ConstructorOnParts_ForQNeg1div2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 2), 3);

    [TestMethod()] //1/2, base 5
    public void ConstructorOnParts_ForQ1div2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 2), 5);

    [TestMethod()] //-1/2, base 5
    public void ConstructorOnParts_ForQNeg1div2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 2), 5);

    [TestMethod()] //1/3, base 2
    public void ConstructorOnParts_ForQ1div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 3), 2);

    [TestMethod()] //-1/3, base 2
    public void ConstructorOnParts_ForQNeg1div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 3), 2);

    [TestMethod()] //1/3, base 3
    public void ConstructorOnParts_ForQ1div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 3), 3);

    [TestMethod()] //-1/3, base 3
    public void ConstructorOnParts_ForQNeg1div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 3), 3);

    [TestMethod()] //1/3, base 5
    public void ConstructorOnParts_ForQ1div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 3), 5);

    [TestMethod()] //-1/3, base 5
    public void ConstructorOnParts_ForQNeg1div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 3), 5);

    [TestMethod()] //1/4, base 2
    public void ConstructorOnParts_ForQ1div4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 4), 2);

    [TestMethod()] //-1/4, base 2
    public void ConstructorOnParts_ForQNeg1div4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 4), 2);

    [TestMethod()] //1/4, base 3
    public void ConstructorOnParts_ForQ1div4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 4), 3);

    [TestMethod()] //-1/4, base 3
    public void ConstructorOnParts_ForQNeg1div4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 4), 3);

    [TestMethod()] //1/4, base 5
    public void ConstructorOnParts_ForQ1div4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 4), 5);

    [TestMethod()] //-1/4, base 5
    public void ConstructorOnParts_ForQNeg1div4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 4), 5);

    [TestMethod()] //1/5, base 2
    public void ConstructorOnParts_ForQ1div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 5), 2);

    [TestMethod()] //-1/5, base 2
    public void ConstructorOnParts_ForQNeg1div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 5), 2);

    [TestMethod()] //1/5, base 3
    public void ConstructorOnParts_ForQ1div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 5), 3);

    [TestMethod()] //-1/5, base 3
    public void ConstructorOnParts_ForQNeg1div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 5), 3);

    [TestMethod()] //1/5, base 5
    public void ConstructorOnParts_ForQ1div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 5), 5);

    [TestMethod()] //-1/5, base 5
    public void ConstructorOnParts_ForQNeg1div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 5), 5);

    [TestMethod()] //1/6, base 2
    public void ConstructorOnParts_ForQ1div6_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 6), 2);

    [TestMethod()] //-1/6, base 2
    public void ConstructorOnParts_ForQNeg1div6_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 6), 2);

    [TestMethod()] //1/6, base 3
    public void ConstructorOnParts_ForQ1div6_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 6), 3);

    [TestMethod()] //-1/6, base 3
    public void ConstructorOnParts_ForQNeg1div6_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 6), 3);

    [TestMethod()] //1/6, base 5
    public void ConstructorOnParts_ForQ1div6_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 6), 5);

    [TestMethod()] //-1/6, base 5
    public void ConstructorOnParts_ForQNeg1div6_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 6), 5);

    [TestMethod()] //1/25, base 2
    public void ConstructorOnParts_ForQ1div25_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 25), 2);

    [TestMethod()] //-1/25, base 2
    public void ConstructorOnParts_ForQNeg1div25_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 25), 2);

    [TestMethod()] //1/25, base 3
    public void ConstructorOnParts_ForQ1div25_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 25), 3);

    [TestMethod()] //-1/25, base 3
    public void ConstructorOnParts_ForQNeg1div25_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 25), 3);

    [TestMethod()] //1/25, base 5
    public void ConstructorOnParts_ForQ1div25_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 25), 5);

    [TestMethod()] //-1/25, base 5
    public void ConstructorOnParts_ForQNeg1div25_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 25), 5);

    [TestMethod()] //1/125, base 2
    public void ConstructorOnParts_ForQ1div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 125), 2);

    [TestMethod()] //-1/125, base 2
    public void ConstructorOnParts_ForQNeg1div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 125), 2);

    [TestMethod()] //1/125, base 3
    public void ConstructorOnParts_ForQ1div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 125), 3);

    [TestMethod()] //-1/125, base 3
    public void ConstructorOnParts_ForQNeg1div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 125), 3);

    [TestMethod()] //1/125, base 5
    public void ConstructorOnParts_ForQ1div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 125), 5);

    [TestMethod()] //-1/125, base 5
    public void ConstructorOnParts_ForQNeg1div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 125), 5);

    [TestMethod()] //1/250, base 2
    public void ConstructorOnParts_ForQ1div250_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 250), 2);

    [TestMethod()] //-1/250, base 2
    public void ConstructorOnParts_ForQNeg1div250_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 250), 2);

    [TestMethod()] //1/250, base 3
    public void ConstructorOnParts_ForQ1div250_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 250), 3);

    [TestMethod()] //-1/250, base 3
    public void ConstructorOnParts_ForQNeg1div250_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 250), 3);

    [TestMethod()] //1/250, base 5
    public void ConstructorOnParts_ForQ1div250_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 250), 5);

    [TestMethod()] //-1/250, base 5
    public void ConstructorOnParts_ForQNeg1div250_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 250), 5);

    [TestMethod()] //1/256, base 2
    public void ConstructorOnParts_ForQ1div256_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 256), 2);

    [TestMethod()] //-1/256, base 2
    public void ConstructorOnParts_ForQNeg1div256_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 256), 2);

    [TestMethod()] //1/256, base 3
    public void ConstructorOnParts_ForQ1div256_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 256), 3);

    [TestMethod()] //-1/256, base 3
    public void ConstructorOnParts_ForQNeg1div256_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 256), 3);

    [TestMethod()] //1/256, base 5
    public void ConstructorOnParts_ForQ1div256_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 256), 5);

    [TestMethod()] //-1/256, base 5
    public void ConstructorOnParts_ForQNeg1div256_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 256), 5);

    [TestMethod()] //1/375, base 2
    public void ConstructorOnParts_ForQ1div375_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 375), 2);

    [TestMethod()] //-1/375, base 2
    public void ConstructorOnParts_ForQNeg1div375_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 375), 2);

    [TestMethod()] //1/375, base 3
    public void ConstructorOnParts_ForQ1div375_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 375), 3);

    [TestMethod()] //-1/375, base 3
    public void ConstructorOnParts_ForQNeg1div375_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 375), 3);

    [TestMethod()] //1/375, base 5
    public void ConstructorOnParts_ForQ1div375_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(1, 375), 5);

    [TestMethod()] //-1/375, base 5
    public void ConstructorOnParts_ForQNeg1div375_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-1, 375), 5);

    // 2/x tests
    [TestMethod()] //2/3, base 2
    public void ConstructorOnParts_ForQ2div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 3), 2);

    [TestMethod()] //-2/3, base 2
    public void ConstructorOnParts_ForQNeg2div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 3), 2);

    [TestMethod()] //2/3, base 3
    public void ConstructorOnParts_ForQ2div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 3), 3);

    [TestMethod()] //-2/3, base 3
    public void ConstructorOnParts_ForQNeg2div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 3), 3);

    [TestMethod()] //2/3, base 5
    public void ConstructorOnParts_ForQ2div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 3), 5);

    [TestMethod()] //-2/3, base 5
    public void ConstructorOnParts_ForQNeg2div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 3), 5);

    [TestMethod()] //2/5, base 2
    public void ConstructorOnParts_ForQ2div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 5), 2);

    [TestMethod()] //-2/5, base 2
    public void ConstructorOnParts_ForQNeg2div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 5), 2);

    [TestMethod()] //2/5, base 3
    public void ConstructorOnParts_ForQ2div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 5), 3);

    [TestMethod()] //-2/5, base 3
    public void ConstructorOnParts_ForQNeg2div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 5), 3);

    [TestMethod()] //2/5, base 5
    public void ConstructorOnParts_ForQ2div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 5), 5);

    [TestMethod()] //-2/5, base 5
    public void ConstructorOnParts_ForQNeg2div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 5), 5);

    [TestMethod()] //2/7, base 2
    public void ConstructorOnParts_ForQ2div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 7), 2);

    [TestMethod()] //-2/7, base 2
    public void ConstructorOnParts_ForQNeg2div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 7), 2);

    [TestMethod()] //2/7, base 3
    public void ConstructorOnParts_ForQ2div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 7), 3);

    [TestMethod()] //-2/7, base 3
    public void ConstructorOnParts_ForQNeg2div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 7), 3);

    [TestMethod()] //2/7, base 5
    public void ConstructorOnParts_ForQ2div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 7), 5);

    [TestMethod()] //-2/7, base 5
    public void ConstructorOnParts_ForQNeg2div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 7), 5);

    [TestMethod()] //2/125, base 2
    public void ConstructorOnParts_ForQ2div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 125), 2);

    [TestMethod()] //-2/125, base 2
    public void ConstructorOnParts_ForQNeg2div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 125), 2);

    [TestMethod()] //2/125, base 3
    public void ConstructorOnParts_ForQ2div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 125), 3);

    [TestMethod()] //-2/125, base 3
    public void ConstructorOnParts_ForQNeg2div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 125), 3);

    [TestMethod()] //2/125, base 5
    public void ConstructorOnParts_ForQ2div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(2, 125), 5);

    [TestMethod()] //-2/125, base 5
    public void ConstructorOnParts_ForQNeg2div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-2, 125), 5);

    // 3/x tests
    [TestMethod()] //3/2, base 2
    public void ConstructorOnParts_ForQ3div2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 2), 2);

    [TestMethod()] //-3/2, base 2
    public void ConstructorOnParts_ForQNeg3div2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 2), 2);

    [TestMethod()] //3/2, base 3
    public void ConstructorOnParts_ForQ3div2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 2), 3);

    [TestMethod()] //-3/2, base 3
    public void ConstructorOnParts_ForQNeg3div2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 2), 3);

    [TestMethod()] //3/2, base 5
    public void ConstructorOnParts_ForQ3div2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 2), 5);

    [TestMethod()] //-3/2, base 5
    public void ConstructorOnParts_ForQNeg3div2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 2), 5);

    [TestMethod()] //3/4, base 2
    public void ConstructorOnParts_ForQ3div4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 4), 2);

    [TestMethod()] //-3/4, base 2
    public void ConstructorOnParts_ForQNeg3div4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 4), 2);

    [TestMethod()] //3/4, base 3
    public void ConstructorOnParts_ForQ3div4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 4), 3);

    [TestMethod()] //-3/4, base 3
    public void ConstructorOnParts_ForQNeg3div4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 4), 3);

    [TestMethod()] //3/4, base 5
    public void ConstructorOnParts_ForQ3div4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 4), 5);

    [TestMethod()] //-3/4, base 5
    public void ConstructorOnParts_ForQNeg3div4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 4), 5);

    [TestMethod()] //3/5, base 2
    public void ConstructorOnParts_ForQ3div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 5), 2);

    [TestMethod()] //-3/5, base 2
    public void ConstructorOnParts_ForQNeg3div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 5), 2);

    [TestMethod()] //3/5, base 3
    public void ConstructorOnParts_ForQ3div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 5), 3);

    [TestMethod()] //-3/5, base 3
    public void ConstructorOnParts_ForQNeg3div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 5), 3);

    [TestMethod()] //3/5, base 5
    public void ConstructorOnParts_ForQ3div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 5), 5);

    [TestMethod()] //-3/5, base 5
    public void ConstructorOnParts_ForQNeg3div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 5), 5);

    [TestMethod()] //3/7, base 2
    public void ConstructorOnParts_ForQ3div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 7), 2);

    [TestMethod()] //-3/7, base 2
    public void ConstructorOnParts_ForQNeg3div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 7), 2);

    [TestMethod()] //3/7, base 3
    public void ConstructorOnParts_ForQ3div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 7), 3);

    [TestMethod()] //-3/7, base 3
    public void ConstructorOnParts_ForQNeg3div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 7), 3);

    [TestMethod()] //3/7, base 5
    public void ConstructorOnParts_ForQ3div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 7), 5);

    [TestMethod()] //-3/7, base 5
    public void ConstructorOnParts_ForQNeg3div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 7), 5);

    [TestMethod()] //3/25, base 2
    public void ConstructorOnParts_ForQ3div25_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 25), 2);

    [TestMethod()] //-3/25, base 2
    public void ConstructorOnParts_ForQNeg3div25_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 25), 2);

    [TestMethod()] //3/25, base 3
    public void ConstructorOnParts_ForQ3div25_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 25), 3);

    [TestMethod()] //-3/25, base 3
    public void ConstructorOnParts_ForQNeg3div25_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 25), 3);

    [TestMethod()] //3/25, base 5
    public void ConstructorOnParts_ForQ3div25_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(3, 25), 5);

    [TestMethod()] //-3/25, base 5
    public void ConstructorOnParts_ForQNeg3div25_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-3, 25), 5);

    // 4/x tests
    [TestMethod()] //4/3, base 2
    public void ConstructorOnParts_ForQ4div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 3), 2);

    [TestMethod()] //-4/3, base 2
    public void ConstructorOnParts_ForQNeg4div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 3), 2);

    [TestMethod()] //4/3, base 3
    public void ConstructorOnParts_ForQ4div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 3), 3);

    [TestMethod()] //-4/3, base 3
    public void ConstructorOnParts_ForQNeg4div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 3), 3);

    [TestMethod()] //4/3, base 5
    public void ConstructorOnParts_ForQ4div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 3), 5);

    [TestMethod()] //-4/3, base 5
    public void ConstructorOnParts_ForQNeg4div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 3), 5);

    [TestMethod()] //4/5, base 2
    public void ConstructorOnParts_ForQ4div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 5), 2);

    [TestMethod()] //-4/5, base 2
    public void ConstructorOnParts_ForQNeg4div5_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 5), 2);

    [TestMethod()] //4/5, base 3
    public void ConstructorOnParts_ForQ4div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 5), 3);

    [TestMethod()] //-4/5, base 3
    public void ConstructorOnParts_ForQNeg4div5_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 5), 3);

    [TestMethod()] //4/5, base 5
    public void ConstructorOnParts_ForQ4div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 5), 5);

    [TestMethod()] //-4/5, base 5
    public void ConstructorOnParts_ForQNeg4div5_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 5), 5);

    [TestMethod()] //4/7, base 2
    public void ConstructorOnParts_ForQ4div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 7), 2);

    [TestMethod()] //-4/7, base 2
    public void ConstructorOnParts_ForQNeg4div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 7), 2);

    [TestMethod()] //4/7, base 3
    public void ConstructorOnParts_ForQ4div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 7), 3);

    [TestMethod()] //-4/7, base 3
    public void ConstructorOnParts_ForQNeg4div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 7), 3);

    [TestMethod()] //4/7, base 5
    public void ConstructorOnParts_ForQ4div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 7), 5);

    [TestMethod()] //-4/7, base 5
    public void ConstructorOnParts_ForQNeg4div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 7), 5);

    [TestMethod()] //4/9, base 2
    public void ConstructorOnParts_ForQ4div9_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 9), 2);

    [TestMethod()] //-4/9, base 2
    public void ConstructorOnParts_ForQNeg4div9_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 9), 2);

    [TestMethod()] //4/9, base 3
    public void ConstructorOnParts_ForQ4div9_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 9), 3);

    [TestMethod()] //-4/9, base 3
    public void ConstructorOnParts_ForQNeg4div9_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 9), 3);

    [TestMethod()] //4/9, base 5
    public void ConstructorOnParts_ForQ4div9_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(4, 9), 5);

    [TestMethod()] //-4/9, base 5
    public void ConstructorOnParts_ForQNeg4div9_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-4, 9), 5);

    // 5/x tests
    [TestMethod()] //5/2, base 2
    public void ConstructorOnParts_ForQ5div2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 2), 2);

    [TestMethod()] //-5/2, base 2
    public void ConstructorOnParts_ForQNeg5div2_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 2), 2);

    [TestMethod()] //5/2, base 3
    public void ConstructorOnParts_ForQ5div2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 2), 3);

    [TestMethod()] //-5/2, base 3
    public void ConstructorOnParts_ForQNeg5div2_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 2), 3);

    [TestMethod()] //5/2, base 5
    public void ConstructorOnParts_ForQ5div2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 2), 5);

    [TestMethod()] //-5/2, base 5
    public void ConstructorOnParts_ForQNeg5div2_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 2), 5);

    [TestMethod()] //5/3, base 2
    public void ConstructorOnParts_ForQ5div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 3), 2);

    [TestMethod()] //-5/3, base 2
    public void ConstructorOnParts_ForQNeg5div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 3), 2);

    [TestMethod()] //5/3, base 3
    public void ConstructorOnParts_ForQ5div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 3), 3);

    [TestMethod()] //-5/3, base 3
    public void ConstructorOnParts_ForQNeg5div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 3), 3);

    [TestMethod()] //5/3, base 5
    public void ConstructorOnParts_ForQ5div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 3), 5);

    [TestMethod()] //-5/3, base 5
    public void ConstructorOnParts_ForQNeg5div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 3), 5);

    [TestMethod()] //5/4, base 2
    public void ConstructorOnParts_ForQ5div4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 4), 2);

    [TestMethod()] //-5/4, base 2
    public void ConstructorOnParts_ForQNeg5div4_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 4), 2);

    [TestMethod()] //5/4, base 3
    public void ConstructorOnParts_ForQ5div4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 4), 3);

    [TestMethod()] //-5/4, base 3
    public void ConstructorOnParts_ForQNeg5div4_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 4), 3);

    [TestMethod()] //5/4, base 5
    public void ConstructorOnParts_ForQ5div4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 4), 5);

    [TestMethod()] //-5/4, base 5
    public void ConstructorOnParts_ForQNeg5div4_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 4), 5);

    [TestMethod()] //5/6, base 2
    public void ConstructorOnParts_ForQ5div6_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 6), 2);

    [TestMethod()] //-5/6, base 2
    public void ConstructorOnParts_ForQNeg5div6_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 6), 2);

    [TestMethod()] //5/6, base 3
    public void ConstructorOnParts_ForQ5div6_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 6), 3);

    [TestMethod()] //-5/6, base 3
    public void ConstructorOnParts_ForQNeg5div6_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 6), 3);

    [TestMethod()] //5/6, base 5
    public void ConstructorOnParts_ForQ5div6_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(5, 6), 5);

    [TestMethod()] //-5/6, base 5
    public void ConstructorOnParts_ForQNeg5div6_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-5, 6), 5);

    // Misc Q tests
    [TestMethod()] //16, base 2
    public void ConstructorOnParts_ForInt16_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(16, 1), 2);

    [TestMethod()] //-16, base 2
    public void ConstructorOnParts_ForIntNeg16_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-16, 1), 2);

    [TestMethod()] //16, base 3
    public void ConstructorOnParts_ForInt16_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(16, 1), 3);

    [TestMethod()] //-16, base 3
    public void ConstructorOnParts_ForIntNeg16_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-16, 1), 3);

    [TestMethod()] //16, base 5
    public void ConstructorOnParts_ForInt16_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(16, 1), 5);

    [TestMethod()] //-16, base 5
    public void ConstructorOnParts_ForIntNeg16_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-16, 1), 5);

    [TestMethod()] //25, base 2
    public void ConstructorOnParts_ForInt25_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(25, 1), 2);

    [TestMethod()] //-25, base 2
    public void ConstructorOnParts_ForIntNeg25_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-25, 1), 2);

    [TestMethod()] //25, base 3
    public void ConstructorOnParts_ForInt25_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(25, 1), 3);

    [TestMethod()] //-25, base 3
    public void ConstructorOnParts_ForIntNeg25_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-25, 1), 3);

    [TestMethod()] //25, base 5
    public void ConstructorOnParts_ForInt25_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(25, 1), 5);

    [TestMethod()] //-25, base 5
    public void ConstructorOnParts_ForIntNeg25_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-25, 1), 5);

    [TestMethod()] //124, base 2
    public void ConstructorOnParts_ForInt124_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(124, 1), 2);

    [TestMethod()] //-124, base 2
    public void ConstructorOnParts_ForIntNeg124_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-124, 1), 2);

    [TestMethod()] //124, base 3
    public void ConstructorOnParts_ForInt124_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(124, 1), 3);

    [TestMethod()] //-124, base 3
    public void ConstructorOnParts_ForIntNeg124_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-124, 1), 3);

    [TestMethod()] //124, base 5
    public void ConstructorOnParts_ForInt124_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(124, 1), 5);

    [TestMethod()] //-124, base 5
    public void ConstructorOnParts_ForIntNeg124_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-124, 1), 5);

    [TestMethod()] //125, base 2
    public void ConstructorOnParts_ForInt125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(125, 1), 2);

    [TestMethod()] //-125, base 2
    public void ConstructorOnParts_ForIntNeg125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-125, 1), 2);

    [TestMethod()] //125, base 3
    public void ConstructorOnParts_ForInt125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(125, 1), 3);

    [TestMethod()] //-125, base 3
    public void ConstructorOnParts_ForIntNeg125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-125, 1), 3);

    [TestMethod()] //125, base 5
    public void ConstructorOnParts_ForInt125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(125, 1), 5);

    [TestMethod()] //-125, base 5
    public void ConstructorOnParts_ForIntNeg125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-125, 1), 5);

    [TestMethod()] //126, base 2
    public void ConstructorOnParts_ForInt126_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(126, 1), 2);

    [TestMethod()] //-126, base 2
    public void ConstructorOnParts_ForIntNeg126_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-126, 1), 2);

    [TestMethod()] //126, base 3
    public void ConstructorOnParts_ForInt126_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(126, 1), 3);

    [TestMethod()] //-126, base 3
    public void ConstructorOnParts_ForIntNeg126_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-126, 1), 3);

    [TestMethod()] //126, base 5
    public void ConstructorOnParts_ForInt126_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(126, 1), 5);

    [TestMethod()] //-126, base 5
    public void ConstructorOnParts_ForIntNeg126_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-126, 1), 5);

    [TestMethod()] //153, base 2
    public void ConstructorOnParts_ForInt153_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(153, 1), 2);

    [TestMethod()] //-153, base 2
    public void ConstructorOnParts_ForIntNeg153_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-153, 1), 2);

    [TestMethod()] //153, base 3
    public void ConstructorOnParts_ForInt153_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(153, 1), 3);

    [TestMethod()] //-153, base 3
    public void ConstructorOnParts_ForIntNeg153_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-153, 1), 3);

    [TestMethod()] //153, base 5
    public void ConstructorOnParts_ForInt153_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(153, 1), 5);

    [TestMethod()] //-153, base 5
    public void ConstructorOnParts_ForIntNeg153_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-153, 1), 5);

    [TestMethod()] //255, base 2
    public void ConstructorOnParts_ForInt255_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(255, 1), 2);

    [TestMethod()] //-255, base 2
    public void ConstructorOnParts_ForIntNeg255_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-255, 1), 2);

    [TestMethod()] //255, base 3
    public void ConstructorOnParts_ForInt255_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(255, 1), 3);

    [TestMethod()] //-255, base 3
    public void ConstructorOnParts_ForIntNeg255_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-255, 1), 3);

    [TestMethod()] //255, base 5
    public void ConstructorOnParts_ForInt255_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(255, 1), 5);

    [TestMethod()] //-255, base 5
    public void ConstructorOnParts_ForIntNeg255_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-255, 1), 5);

    [TestMethod()] //256, base 2
    public void ConstructorOnParts_ForInt256_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(256, 1), 2);

    [TestMethod()] //-256, base 2
    public void ConstructorOnParts_ForIntNeg256_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-256, 1), 2);

    [TestMethod()] //256, base 3
    public void ConstructorOnParts_ForInt256_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(256, 1), 3);

    [TestMethod()] //-256, base 3
    public void ConstructorOnParts_ForIntNeg256_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-256, 1), 3);

    [TestMethod()] //256, base 5
    public void ConstructorOnParts_ForInt256_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(256, 1), 5);

    [TestMethod()] //-256, base 5
    public void ConstructorOnParts_ForIntNeg256_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-256, 1), 5);

    [TestMethod()] //9/7, base 2
    public void ConstructorOnParts_ForQ9div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(9, 7), 2);

    [TestMethod()] //-9/7, base 2
    public void ConstructorOnParts_ForQNeg9div7_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-9, 7), 2);

    [TestMethod()] //9/7, base 3
    public void ConstructorOnParts_ForQ9div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(9, 7), 3);

    [TestMethod()] //-9/7, base 3
    public void ConstructorOnParts_ForQNeg9div7_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-9, 7), 3);

    [TestMethod()] //9/7, base 5
    public void ConstructorOnParts_ForQ9div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(9, 7), 5);

    [TestMethod()] //-9/7, base 5
    public void ConstructorOnParts_ForQNeg9div7_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-9, 7), 5);

    [TestMethod()] //22/3, base 2
    public void ConstructorOnParts_ForQ22div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(22, 3), 2);

    [TestMethod()] //-22/3, base 2
    public void ConstructorOnParts_ForQNeg22div3_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-22, 3), 2);

    [TestMethod()] //22/3, base 3
    public void ConstructorOnParts_ForQ22div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(22, 3), 3);

    [TestMethod()] //-22/3, base 3
    public void ConstructorOnParts_ForQNeg22div3_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-22, 3), 3);

    [TestMethod()] //22/3, base 5
    public void ConstructorOnParts_ForQ22div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(22, 3), 5);

    [TestMethod()] //-22/3, base 5
    public void ConstructorOnParts_ForQNeg22div3_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-22, 3), 5);

    [TestMethod()] //12/125, base 2
    public void ConstructorOnParts_ForQ12div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(12, 125), 2);

    [TestMethod()] //-12/125, base 2
    public void ConstructorOnParts_ForQNeg12div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-12, 125), 2);

    [TestMethod()] //12/125, base 3
    public void ConstructorOnParts_ForQ12div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(12, 125), 3);

    [TestMethod()] //-12/125, base 3
    public void ConstructorOnParts_ForQNeg12div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-12, 125), 3);

    [TestMethod()] //12/125, base 5
    public void ConstructorOnParts_ForQ12div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(12, 125), 5);

    [TestMethod()] //-12/125, base 5
    public void ConstructorOnParts_ForQNeg12div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-12, 125), 5);

    [TestMethod()] //37/125, base 2
    public void ConstructorOnParts_ForQ37div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(37, 125), 2);

    [TestMethod()] //-37/125, base 2
    public void ConstructorOnParts_ForQNeg37div125_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-37, 125), 2);

    [TestMethod()] //37/125, base 3
    public void ConstructorOnParts_ForQ37div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(37, 125), 3);

    [TestMethod()] //-37/125, base 3
    public void ConstructorOnParts_ForQNeg37div125_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-37, 125), 3);

    [TestMethod()] //37/125, base 5
    public void ConstructorOnParts_ForQ37div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(37, 125), 5);

    [TestMethod()] //-37/125, base 5
    public void ConstructorOnParts_ForQNeg37div125_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-37, 125), 5);

    [TestMethod()] //23/18, base 2
    public void ConstructorOnParts_ForQ23div18_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(23, 18), 2);

    [TestMethod()] //-23/18, base 2
    public void ConstructorOnParts_ForQNeg23div18_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-23, 18), 2);

    [TestMethod()] //23/18, base 3
    public void ConstructorOnParts_ForQ23div18_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(23, 18), 3);

    [TestMethod()] //-23/18, base 3
    public void ConstructorOnParts_ForQNeg23div18_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-23, 18), 3);

    [TestMethod()] //23/18, base 5
    public void ConstructorOnParts_ForQ23div18_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(23, 18), 5);

    [TestMethod()] //-23/18, base 5
    public void ConstructorOnParts_ForQNeg23div18_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-23, 18), 5);

    [TestMethod()] //537/11, base 2
    public void ConstructorOnParts_ForQ537div11_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(537, 11), 2);

    [TestMethod()] //-537/11, base 2
    public void ConstructorOnParts_ForQNeg537div11_Base2_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-537, 11), 2);

    [TestMethod()] //537/11, base 3
    public void ConstructorOnParts_ForQ537div11_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(537, 11), 3);

    [TestMethod()] //-537/11, base 3
    public void ConstructorOnParts_ForQNeg537div11_Base3_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-537, 11), 3);

    [TestMethod()] //537/11, base 5
    public void ConstructorOnParts_ForQ537div11_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(537, 11), 5);

    [TestMethod()] //-537/11, base 5
    public void ConstructorOnParts_ForQNeg537div11_Base5_ReturnsSame()
            => ConstructorOnParts_FromQb_ReturnsSame(new Q(-537, 11), 5);

    #endregion

    #region ToStringExpanded and FullInt
    private static void ToStringExpandedAndFullInt_ForQb_IsCorrect(string expectedExpanded, Q q, int base_)
    {
        Qb qbActual = q.InBase(base_);

        Assert.AreEqual(expectedExpanded, qbActual.ToStringExpanded());
        string expandedNoDot = expectedExpanded.Replace(".", "");

        string fullIntString = qbActual.FullInteger.ToStringCoefficient();
        if (fullIntString.Length < expandedNoDot.Length)
            StringAssert.StartsWith(expandedNoDot, fullIntString);
        else
            Assert.AreEqual(expandedNoDot, fullIntString[..expandedNoDot.Length]);
    }

    // Integer tests
    [TestMethod()] //0, base 2
    public void ToStringExpandedAndFullInt_ForInt0_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000000000000", new Q(0, 1), 2);

    [TestMethod()] //0, base 3
    public void ToStringExpandedAndFullInt_ForInt0_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000000000000", new Q(0, 1), 3);

    [TestMethod()] //0, base 5
    public void ToStringExpandedAndFullInt_ForInt0_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000000000000", new Q(0, 1), 5);

    [TestMethod()] //1, base 2
    public void ToStringExpandedAndFullInt_ForInt1_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.000000000000000", new Q(1, 1), 2);

    [TestMethod()] //-1, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg1_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1111111111111111", new Q(-1, 1), 2);

    [TestMethod()] //1, base 3
    public void ToStringExpandedAndFullInt_ForInt1_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.000000000000000", new Q(1, 1), 3);

    [TestMethod()] //-1, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg1_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2222222222222222", new Q(-1, 1), 3);

    [TestMethod()] //1, base 5
    public void ToStringExpandedAndFullInt_ForInt1_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.000000000000000", new Q(1, 1), 5);

    [TestMethod()] //-1, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg1_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".4444444444444444", new Q(-1, 1), 5);

    [TestMethod()] //2, base 2
    public void ToStringExpandedAndFullInt_ForInt2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.00000000000000", new Q(2, 1), 2);

    [TestMethod()] //-2, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.111111111111111", new Q(-2, 1), 2);

    [TestMethod()] //2, base 3
    public void ToStringExpandedAndFullInt_ForInt2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.000000000000000", new Q(2, 1), 3);

    [TestMethod()] //-2, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.222222222222222", new Q(-2, 1), 3);

    [TestMethod()] //2, base 5
    public void ToStringExpandedAndFullInt_ForInt2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.000000000000000", new Q(2, 1), 5);

    [TestMethod()] //-2, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.444444444444444", new Q(-2, 1), 5);

    [TestMethod()] //3, base 2
    public void ToStringExpandedAndFullInt_ForInt3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11.00000000000000", new Q(3, 1), 2);

    [TestMethod()] //-3, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.11111111111111", new Q(-3, 1), 2);

    [TestMethod()] //3, base 3
    public void ToStringExpandedAndFullInt_ForInt3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.00000000000000", new Q(3, 1), 3);

    [TestMethod()] //-3, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.222222222222222", new Q(-3, 1), 3);

    [TestMethod()] //3, base 5
    public void ToStringExpandedAndFullInt_ForInt3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("3.000000000000000", new Q(3, 1), 5);

    [TestMethod()] //-3, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.444444444444444", new Q(-3, 1), 5);

    [TestMethod()] //4, base 2
    public void ToStringExpandedAndFullInt_ForInt4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100.0000000000000", new Q(4, 1), 2);

    [TestMethod()] //-4, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11.11111111111111", new Q(-4, 1), 2);

    [TestMethod()] //4, base 3
    public void ToStringExpandedAndFullInt_ForInt4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11.00000000000000", new Q(4, 1), 3);

    [TestMethod()] //-4, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.22222222222222", new Q(-4, 1), 3);

    [TestMethod()] //4, base 5
    public void ToStringExpandedAndFullInt_ForInt4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("4.000000000000000", new Q(4, 1), 5);

    [TestMethod()] //-4, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("3.444444444444444", new Q(-4, 1), 5);

    [TestMethod()] //5, base 2
    public void ToStringExpandedAndFullInt_ForInt5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("101.0000000000000", new Q(5, 1), 2);

    [TestMethod()] //-5, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100.1111111111111", new Q(-5, 1), 2);

    [TestMethod()] //5, base 3
    public void ToStringExpandedAndFullInt_ForInt5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("12.00000000000000", new Q(5, 1), 3);

    [TestMethod()] //-5, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11.22222222222222", new Q(-5, 1), 3);

    [TestMethod()] //5, base 5
    public void ToStringExpandedAndFullInt_ForInt5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.00000000000000", new Q(5, 1), 5);

    [TestMethod()] //-5, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("4.444444444444444", new Q(-5, 1), 5);

    [TestMethod()] //6, base 2
    public void ToStringExpandedAndFullInt_ForInt6_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("110.0000000000000", new Q(6, 1), 2);

    [TestMethod()] //-6, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg6_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("101.1111111111111", new Q(-6, 1), 2);

    [TestMethod()] //6, base 3
    public void ToStringExpandedAndFullInt_ForInt6_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("20.00000000000000", new Q(6, 1), 3);

    [TestMethod()] //-6, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg6_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("12.22222222222222", new Q(-6, 1), 3);

    [TestMethod()] //6, base 5
    public void ToStringExpandedAndFullInt_ForInt6_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11.00000000000000", new Q(6, 1), 5);

    [TestMethod()] //-6, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg6_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.44444444444444", new Q(-6, 1), 5);

    // Unit fraction tests
    [TestMethod()] //1/2, base 2
    public void ToStringExpandedAndFullInt_ForQ1div2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1000000000000000", new Q(1, 2), 2);

    [TestMethod()] //-1/2, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0111111111111111", new Q(-1, 2), 2);

    [TestMethod()] //1/2, base 3
    public void ToStringExpandedAndFullInt_ForQ1div2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1111111111111111", new Q(1, 2), 3);

    [TestMethod()] //-1/2, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1111111111111111", new Q(-1, 2), 3);

    [TestMethod()] //1/2, base 5
    public void ToStringExpandedAndFullInt_ForQ1div2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2222222222222222", new Q(1, 2), 5);

    [TestMethod()] //-1/2, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2222222222222222", new Q(-1, 2), 5);

    [TestMethod()] //1/3, base 2
    public void ToStringExpandedAndFullInt_ForQ1div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0101010101010101", new Q(1, 3), 2);

    [TestMethod()] //-1/3, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0101010101010101", new Q(-1, 3), 2);

    [TestMethod()] //1/3, base 3
    public void ToStringExpandedAndFullInt_ForQ1div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1000000000000000", new Q(1, 3), 3);

    [TestMethod()] //-1/3, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0222222222222222", new Q(-1, 3), 3);

    [TestMethod()] //1/3, base 5
    public void ToStringExpandedAndFullInt_ForQ1div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1313131313131313", new Q(1, 3), 5);

    [TestMethod()] //-1/3, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1313131313131313", new Q(-1, 3), 5);

    [TestMethod()] //1/4, base 2
    public void ToStringExpandedAndFullInt_ForQ1div4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100000000000000", new Q(1, 4), 2);

    [TestMethod()] //-1/4, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0011111111111111", new Q(-1, 4), 2);

    [TestMethod()] //1/4, base 3
    public void ToStringExpandedAndFullInt_ForQ1div4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0202020202020202", new Q(1, 4), 3);

    [TestMethod()] //-1/4, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0202020202020202", new Q(-1, 4), 3);

    [TestMethod()] //1/4, base 5
    public void ToStringExpandedAndFullInt_ForQ1div4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1111111111111111", new Q(1, 4), 5);

    [TestMethod()] //-1/4, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1111111111111111", new Q(-1, 4), 5);

    [TestMethod()] //1/5, base 2
    public void ToStringExpandedAndFullInt_ForQ1div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0011001100110011", new Q(1, 5), 2);

    [TestMethod()] //-1/5, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0011001100110011", new Q(-1, 5), 2);

    [TestMethod()] //1/5, base 3
    public void ToStringExpandedAndFullInt_ForQ1div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0121012101210121", new Q(1, 5), 3);

    [TestMethod()] //-1/5, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0121012101210121", new Q(-1, 5), 3);

    [TestMethod()] //1/5, base 5
    public void ToStringExpandedAndFullInt_ForQ1div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1000000000000000", new Q(1, 5), 5);

    [TestMethod()] //-1/5, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0444444444444444", new Q(-1, 5), 5);

    [TestMethod()] //1/6, base 2
    public void ToStringExpandedAndFullInt_ForQ1div6_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0010101010101010", new Q(1, 6), 2);

    [TestMethod()] //-1/6, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div6_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0010101010101010", new Q(-1, 6), 2);

    [TestMethod()] //1/6, base 3
    public void ToStringExpandedAndFullInt_ForQ1div6_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0111111111111111", new Q(1, 6), 3);

    [TestMethod()] //-1/6, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div6_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0111111111111111", new Q(-1, 6), 3);

    [TestMethod()] //1/6, base 5
    public void ToStringExpandedAndFullInt_ForQ1div6_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0404040404040404", new Q(1, 6), 5);

    [TestMethod()] //-1/6, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div6_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0404040404040404", new Q(-1, 6), 5);

    [TestMethod()] //1/25, base 2
    public void ToStringExpandedAndFullInt_ForQ1div25_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000101000111101", new Q(1, 25), 2);

    [TestMethod()] //-1/25, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div25_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000101000111101", new Q(-1, 25), 2);

    [TestMethod()] //1/25, base 3
    public void ToStringExpandedAndFullInt_ForQ1div25_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0010020110221220", new Q(1, 25), 3);

    [TestMethod()] //-1/25, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div25_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0010020110221220", new Q(-1, 25), 3);

    [TestMethod()] //1/25, base 5
    public void ToStringExpandedAndFullInt_ForQ1div25_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100000000000000", new Q(1, 25), 5);

    [TestMethod()] //-1/25, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div25_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0044444444444444", new Q(-1, 25), 5);

    [TestMethod()] //1/125, base 2
    public void ToStringExpandedAndFullInt_ForQ1div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000001000001100", new Q(1, 125), 2);

    [TestMethod()] //-1/125, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000001000001100", new Q(-1, 125), 2);

    [TestMethod()] //1/125, base 3
    public void ToStringExpandedAndFullInt_ForQ1div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000122111101120", new Q(1, 125), 3);

    [TestMethod()] //-1/125, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000122111101120", new Q(-1, 125), 3);

    [TestMethod()] //1/125, base 5
    public void ToStringExpandedAndFullInt_ForQ1div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0010000000000000", new Q(1, 125), 5);

    [TestMethod()] //-1/125, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0004444444444444", new Q(-1, 125), 5);

    [TestMethod()] //1/250, base 2
    public void ToStringExpandedAndFullInt_ForQ1div250_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000100000110", new Q(1, 250), 2);

    [TestMethod()] //-1/250, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div250_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000100000110", new Q(-1, 250), 2);

    [TestMethod()] //1/250, base 3
    public void ToStringExpandedAndFullInt_ForQ1div250_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000022202012021", new Q(1, 250), 3);

    [TestMethod()] //-1/250, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div250_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000022202012021", new Q(-1, 250), 3);

    [TestMethod()] //1/250, base 5
    public void ToStringExpandedAndFullInt_ForQ1div250_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0002222222222222", new Q(1, 250), 5);

    [TestMethod()] //-1/250, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div250_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0002222222222222", new Q(-1, 250), 5);

    [TestMethod()] //1/256, base 2
    public void ToStringExpandedAndFullInt_ForQ1div256_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000100000000", new Q(1, 256), 2);

    [TestMethod()] //-1/256, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div256_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000011111111", new Q(-1, 256), 2);

    [TestMethod()] //1/256, base 3
    public void ToStringExpandedAndFullInt_ForQ1div256_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000022112122211", new Q(1, 256), 3);

    [TestMethod()] //-1/256, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div256_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000022112122211", new Q(-1, 256), 3);

    [TestMethod()] //1/256, base 5
    public void ToStringExpandedAndFullInt_ForQ1div256_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0002210041441242", new Q(1, 256), 5);

    [TestMethod()] //-1/256, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div256_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0002210041441242", new Q(-1, 256), 5);

    [TestMethod()] //1/375, base 2
    public void ToStringExpandedAndFullInt_ForQ1div375_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000010101110", new Q(1, 375), 2);

    [TestMethod()] //-1/375, base 2
    public void ToStringExpandedAndFullInt_ForQNeg1div375_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000000010101110", new Q(-1, 375), 2);

    [TestMethod()] //1/375, base 3
    public void ToStringExpandedAndFullInt_ForQ1div375_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000012211110112", new Q(1, 375), 3);

    [TestMethod()] //-1/375, base 3
    public void ToStringExpandedAndFullInt_ForQNeg1div375_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000012211110112", new Q(-1, 375), 3);

    [TestMethod()] //1/375, base 5
    public void ToStringExpandedAndFullInt_ForQ1div375_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001313131313131", new Q(1, 375), 5);

    [TestMethod()] //-1/375, base 5
    public void ToStringExpandedAndFullInt_ForQNeg1div375_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001313131313131", new Q(-1, 375), 5);

    // 2/x tests
    [TestMethod()] //2/3, base 2
    public void ToStringExpandedAndFullInt_ForQ2div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1010101010101010", new Q(2, 3), 2);

    [TestMethod()] //-2/3, base 2
    public void ToStringExpandedAndFullInt_ForQNeg2div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1010101010101010", new Q(-2, 3), 2);

    [TestMethod()] //2/3, base 3
    public void ToStringExpandedAndFullInt_ForQ2div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2000000000000000", new Q(2, 3), 3);

    [TestMethod()] //-2/3, base 3
    public void ToStringExpandedAndFullInt_ForQNeg2div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1222222222222222", new Q(-2, 3), 3);

    [TestMethod()] //2/3, base 5
    public void ToStringExpandedAndFullInt_ForQ2div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".3131313131313131", new Q(2, 3), 5);

    [TestMethod()] //-2/3, base 5
    public void ToStringExpandedAndFullInt_ForQNeg2div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".3131313131313131", new Q(-2, 3), 5);

    [TestMethod()] //2/5, base 2
    public void ToStringExpandedAndFullInt_ForQ2div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0110011001100110", new Q(2, 5), 2);

    [TestMethod()] //-2/5, base 2
    public void ToStringExpandedAndFullInt_ForQNeg2div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0110011001100110", new Q(-2, 5), 2);

    [TestMethod()] //2/5, base 3
    public void ToStringExpandedAndFullInt_ForQ2div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1012101210121012", new Q(2, 5), 3);

    [TestMethod()] //-2/5, base 3
    public void ToStringExpandedAndFullInt_ForQNeg2div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1012101210121012", new Q(-2, 5), 3);

    [TestMethod()] //2/5, base 5
    public void ToStringExpandedAndFullInt_ForQ2div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2000000000000000", new Q(2, 5), 5);

    [TestMethod()] //-2/5, base 5
    public void ToStringExpandedAndFullInt_ForQNeg2div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1444444444444444", new Q(-2, 5), 5);

    [TestMethod()] //2/7, base 2
    public void ToStringExpandedAndFullInt_ForQ2div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100100100100100", new Q(2, 7), 2);

    [TestMethod()] //-2/7, base 2
    public void ToStringExpandedAndFullInt_ForQNeg2div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100100100100100", new Q(-2, 7), 2);

    [TestMethod()] //2/7, base 3
    public void ToStringExpandedAndFullInt_ForQ2div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0212010212010212", new Q(2, 7), 3);

    [TestMethod()] //-2/7, base 3
    public void ToStringExpandedAndFullInt_ForQNeg2div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0212010212010212", new Q(-2, 7), 3);

    [TestMethod()] //2/7, base 5
    public void ToStringExpandedAndFullInt_ForQ2div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1203241203241203", new Q(2, 7), 5);

    [TestMethod()] //-2/7, base 5
    public void ToStringExpandedAndFullInt_ForQNeg2div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1203241203241203", new Q(-2, 7), 5);

    [TestMethod()] //2/125, base 2
    public void ToStringExpandedAndFullInt_ForQ2div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000010000011000", new Q(2, 125), 2);

    [TestMethod()] //-2/125, base 2
    public void ToStringExpandedAndFullInt_ForQNeg2div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0000010000011000", new Q(-2, 125), 2);

    [TestMethod()] //2/125, base 3
    public void ToStringExpandedAndFullInt_ForQ2div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001021222210011", new Q(2, 125), 3);

    [TestMethod()] //-2/125, base 3
    public void ToStringExpandedAndFullInt_ForQNeg2div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001021222210011", new Q(-2, 125), 3);

    [TestMethod()] //2/125, base 5
    public void ToStringExpandedAndFullInt_ForQ2div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0020000000000000", new Q(2, 125), 5);

    [TestMethod()] //-2/125, base 5
    public void ToStringExpandedAndFullInt_ForQNeg2div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0014444444444444", new Q(-2, 125), 5);

    // 3/x tests
    [TestMethod()] //3/2, base 2
    public void ToStringExpandedAndFullInt_ForQ3div2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.100000000000000", new Q(3, 2), 2);

    [TestMethod()] //-3/2, base 2
    public void ToStringExpandedAndFullInt_ForQNeg3div2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.011111111111111", new Q(-3, 2), 2);

    [TestMethod()] //3/2, base 3
    public void ToStringExpandedAndFullInt_ForQ3div2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.111111111111111", new Q(3, 2), 3);

    [TestMethod()] //-3/2, base 3
    public void ToStringExpandedAndFullInt_ForQNeg3div2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.111111111111111", new Q(-3, 2), 3);

    [TestMethod()] //3/2, base 5
    public void ToStringExpandedAndFullInt_ForQ3div2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.222222222222222", new Q(3, 2), 5);

    [TestMethod()] //-3/2, base 5
    public void ToStringExpandedAndFullInt_ForQNeg3div2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.222222222222222", new Q(-3, 2), 5);

    [TestMethod()] //3/4, base 2
    public void ToStringExpandedAndFullInt_ForQ3div4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1100000000000000", new Q(3, 4), 2);

    [TestMethod()] //-3/4, base 2
    public void ToStringExpandedAndFullInt_ForQNeg3div4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1011111111111111", new Q(-3, 4), 2);

    [TestMethod()] //3/4, base 3
    public void ToStringExpandedAndFullInt_ForQ3div4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2020202020202020", new Q(3, 4), 3);

    [TestMethod()] //-3/4, base 3
    public void ToStringExpandedAndFullInt_ForQNeg3div4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2020202020202020", new Q(-3, 4), 3);

    [TestMethod()] //3/4, base 5
    public void ToStringExpandedAndFullInt_ForQ3div4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".3333333333333333", new Q(3, 4), 5);

    [TestMethod()] //-3/4, base 5
    public void ToStringExpandedAndFullInt_ForQNeg3div4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".3333333333333333", new Q(-3, 4), 5);

    [TestMethod()] //3/5, base 2
    public void ToStringExpandedAndFullInt_ForQ3div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1001100110011001", new Q(3, 5), 2);

    [TestMethod()] //-3/5, base 2
    public void ToStringExpandedAndFullInt_ForQNeg3div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1001100110011001", new Q(-3, 5), 2);

    [TestMethod()] //3/5, base 3
    public void ToStringExpandedAndFullInt_ForQ3div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1210121012101210", new Q(3, 5), 3);

    [TestMethod()] //-3/5, base 3
    public void ToStringExpandedAndFullInt_ForQNeg3div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1210121012101210", new Q(-3, 5), 3);

    [TestMethod()] //3/5, base 5
    public void ToStringExpandedAndFullInt_ForQ3div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".3000000000000000", new Q(3, 5), 5);

    [TestMethod()] //-3/5, base 5
    public void ToStringExpandedAndFullInt_ForQNeg3div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2444444444444444", new Q(-3, 5), 5);

    [TestMethod()] //3/7, base 2
    public void ToStringExpandedAndFullInt_ForQ3div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0110110110110110", new Q(3, 7), 2);

    [TestMethod()] //-3/7, base 2
    public void ToStringExpandedAndFullInt_ForQNeg3div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0110110110110110", new Q(-3, 7), 2);

    [TestMethod()] //3/7, base 3
    public void ToStringExpandedAndFullInt_ForQ3div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1021201021201021", new Q(3, 7), 3);

    [TestMethod()] //-3/7, base 3
    public void ToStringExpandedAndFullInt_ForQNeg3div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1021201021201021", new Q(-3, 7), 3);

    [TestMethod()] //3/7, base 5
    public void ToStringExpandedAndFullInt_ForQ3div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2032412032412032", new Q(3, 7), 5);

    [TestMethod()] //-3/7, base 5
    public void ToStringExpandedAndFullInt_ForQNeg3div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2032412032412032", new Q(-3, 7), 5);

    [TestMethod()] //3/25, base 2
    public void ToStringExpandedAndFullInt_ForQ3div25_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001111010111000", new Q(3, 25), 2);

    [TestMethod()] //-3/25, base 2
    public void ToStringExpandedAndFullInt_ForQNeg3div25_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001111010111000", new Q(-3, 25), 2);

    [TestMethod()] //3/25, base 3
    public void ToStringExpandedAndFullInt_ForQ3div25_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100201102212202", new Q(3, 25), 3);

    [TestMethod()] //-3/25, base 3
    public void ToStringExpandedAndFullInt_ForQNeg3div25_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100201102212202", new Q(-3, 25), 3);

    [TestMethod()] //3/25, base 5
    public void ToStringExpandedAndFullInt_ForQ3div25_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0300000000000000", new Q(3, 25), 5);

    [TestMethod()] //-3/25, base 5
    public void ToStringExpandedAndFullInt_ForQNeg3div25_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0244444444444444", new Q(-3, 25), 5);

    // 4/x tests
    [TestMethod()] //4/3, base 2
    public void ToStringExpandedAndFullInt_ForQ4div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010101010101010", new Q(4, 3), 2);

    [TestMethod()] //-4/3, base 2
    public void ToStringExpandedAndFullInt_ForQNeg4div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010101010101010", new Q(-4, 3), 2);

    [TestMethod()] //4/3, base 3
    public void ToStringExpandedAndFullInt_ForQ4div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.100000000000000", new Q(4, 3), 3);

    [TestMethod()] //-4/3, base 3
    public void ToStringExpandedAndFullInt_ForQNeg4div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.022222222222222", new Q(-4, 3), 3);

    [TestMethod()] //4/3, base 5
    public void ToStringExpandedAndFullInt_ForQ4div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.131313131313131", new Q(4, 3), 5);

    [TestMethod()] //-4/3, base 5
    public void ToStringExpandedAndFullInt_ForQNeg4div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.131313131313131", new Q(-4, 3), 5);

    [TestMethod()] //4/5, base 2
    public void ToStringExpandedAndFullInt_ForQ4div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1100110011001100", new Q(4, 5), 2);

    [TestMethod()] //-4/5, base 2
    public void ToStringExpandedAndFullInt_ForQNeg4div5_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1100110011001100", new Q(-4, 5), 2);

    [TestMethod()] //4/5, base 3
    public void ToStringExpandedAndFullInt_ForQ4div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2101210121012101", new Q(4, 5), 3);

    [TestMethod()] //-4/5, base 3
    public void ToStringExpandedAndFullInt_ForQNeg4div5_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2101210121012101", new Q(-4, 5), 3);

    [TestMethod()] //4/5, base 5
    public void ToStringExpandedAndFullInt_ForQ4div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".4000000000000000", new Q(4, 5), 5);

    [TestMethod()] //-4/5, base 5
    public void ToStringExpandedAndFullInt_ForQNeg4div5_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".3444444444444444", new Q(-4, 5), 5);

    [TestMethod()] //4/7, base 2
    public void ToStringExpandedAndFullInt_ForQ4div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1001001001001001", new Q(4, 7), 2);

    [TestMethod()] //-4/7, base 2
    public void ToStringExpandedAndFullInt_ForQNeg4div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1001001001001001", new Q(-4, 7), 2);

    [TestMethod()] //4/7, base 3
    public void ToStringExpandedAndFullInt_ForQ4div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1201021201021201", new Q(4, 7), 3);

    [TestMethod()] //-4/7, base 3
    public void ToStringExpandedAndFullInt_ForQNeg4div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1201021201021201", new Q(-4, 7), 3);

    [TestMethod()] //4/7, base 5
    public void ToStringExpandedAndFullInt_ForQ4div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2412032412032412", new Q(4, 7), 5);

    [TestMethod()] //-4/7, base 5
    public void ToStringExpandedAndFullInt_ForQNeg4div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2412032412032412", new Q(-4, 7), 5);

    [TestMethod()] //4/9, base 2
    public void ToStringExpandedAndFullInt_ForQ4div9_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0111000111000111", new Q(4, 9), 2);

    [TestMethod()] //-4/9, base 2
    public void ToStringExpandedAndFullInt_ForQNeg4div9_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0111000111000111", new Q(-4, 9), 2);

    [TestMethod()] //4/9, base 3
    public void ToStringExpandedAndFullInt_ForQ4div9_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1100000000000000", new Q(4, 9), 3);

    [TestMethod()] //-4/9, base 3
    public void ToStringExpandedAndFullInt_ForQNeg4div9_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1022222222222222", new Q(-4, 9), 3);

    [TestMethod()] //4/9, base 5
    public void ToStringExpandedAndFullInt_ForQ4div9_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2102342102342102", new Q(4, 9), 5);

    [TestMethod()] //-4/9, base 5
    public void ToStringExpandedAndFullInt_ForQNeg4div9_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2102342102342102", new Q(-4, 9), 5);

    // 5/x tests
    [TestMethod()] //5/2, base 2
    public void ToStringExpandedAndFullInt_ForQ5div2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.10000000000000", new Q(5, 2), 2);

    [TestMethod()] //-5/2, base 2
    public void ToStringExpandedAndFullInt_ForQNeg5div2_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10.01111111111111", new Q(-5, 2), 2);

    [TestMethod()] //5/2, base 3
    public void ToStringExpandedAndFullInt_ForQ5div2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.111111111111111", new Q(5, 2), 3);

    [TestMethod()] //-5/2, base 3
    public void ToStringExpandedAndFullInt_ForQNeg5div2_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.111111111111111", new Q(-5, 2), 3);

    [TestMethod()] //5/2, base 5
    public void ToStringExpandedAndFullInt_ForQ5div2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.222222222222222", new Q(5, 2), 5);

    [TestMethod()] //-5/2, base 5
    public void ToStringExpandedAndFullInt_ForQNeg5div2_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2.222222222222222", new Q(-5, 2), 5);

    [TestMethod()] //5/3, base 2
    public void ToStringExpandedAndFullInt_ForQ5div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.101010101010101", new Q(5, 3), 2);

    [TestMethod()] //-5/3, base 2
    public void ToStringExpandedAndFullInt_ForQNeg5div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.101010101010101", new Q(-5, 3), 2);

    [TestMethod()] //5/3, base 3
    public void ToStringExpandedAndFullInt_ForQ5div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.200000000000000", new Q(5, 3), 3);

    [TestMethod()] //-5/3, base 3
    public void ToStringExpandedAndFullInt_ForQNeg5div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.122222222222222", new Q(-5, 3), 3);

    [TestMethod()] //5/3, base 5
    public void ToStringExpandedAndFullInt_ForQ5div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.313131313131313", new Q(5, 3), 5);

    [TestMethod()] //-5/3, base 5
    public void ToStringExpandedAndFullInt_ForQNeg5div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.313131313131313", new Q(-5, 3), 5);

    [TestMethod()] //5/4, base 2
    public void ToStringExpandedAndFullInt_ForQ5div4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010000000000000", new Q(5, 4), 2);

    [TestMethod()] //-5/4, base 2
    public void ToStringExpandedAndFullInt_ForQNeg5div4_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.001111111111111", new Q(-5, 4), 2);

    [TestMethod()] //5/4, base 3
    public void ToStringExpandedAndFullInt_ForQ5div4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.020202020202020", new Q(5, 4), 3);

    [TestMethod()] //-5/4, base 3
    public void ToStringExpandedAndFullInt_ForQNeg5div4_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.020202020202020", new Q(-5, 4), 3);

    [TestMethod()] //5/4, base 5
    public void ToStringExpandedAndFullInt_ForQ5div4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.111111111111111", new Q(5, 4), 5);

    [TestMethod()] //-5/4, base 5
    public void ToStringExpandedAndFullInt_ForQNeg5div4_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.111111111111111", new Q(-5, 4), 5);

    [TestMethod()] //5/6, base 2
    public void ToStringExpandedAndFullInt_ForQ5div6_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1101010101010101", new Q(5, 6), 2);

    [TestMethod()] //-5/6, base 2
    public void ToStringExpandedAndFullInt_ForQNeg5div6_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1101010101010101", new Q(-5, 6), 2);

    [TestMethod()] //5/6, base 3
    public void ToStringExpandedAndFullInt_ForQ5div6_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2111111111111111", new Q(5, 6), 3);

    [TestMethod()] //-5/6, base 3
    public void ToStringExpandedAndFullInt_ForQNeg5div6_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".2111111111111111", new Q(-5, 6), 3);

    [TestMethod()] //5/6, base 5
    public void ToStringExpandedAndFullInt_ForQ5div6_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".4040404040404040", new Q(5, 6), 5);

    [TestMethod()] //-5/6, base 5
    public void ToStringExpandedAndFullInt_ForQNeg5div6_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".4040404040404040", new Q(-5, 6), 5);

    // Misc Q tests
    [TestMethod()] //16, base 2
    public void ToStringExpandedAndFullInt_ForInt16_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10000.00000000000", new Q(16, 1), 2);

    [TestMethod()] //-16, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg16_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111.111111111111", new Q(-16, 1), 2);

    [TestMethod()] //16, base 3
    public void ToStringExpandedAndFullInt_ForInt16_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("121.0000000000000", new Q(16, 1), 3);

    [TestMethod()] //-16, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg16_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("120.2222222222222", new Q(-16, 1), 3);

    [TestMethod()] //16, base 5
    public void ToStringExpandedAndFullInt_ForInt16_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("31.00000000000000", new Q(16, 1), 5);

    [TestMethod()] //-16, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg16_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("30.44444444444444", new Q(-16, 1), 5);

    [TestMethod()] //25, base 2
    public void ToStringExpandedAndFullInt_ForInt25_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11001.00000000000", new Q(25, 1), 2);

    [TestMethod()] //-25, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg25_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11000.11111111111", new Q(-25, 1), 2);

    [TestMethod()] //25, base 3
    public void ToStringExpandedAndFullInt_ForInt25_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("221.0000000000000", new Q(25, 1), 3);

    [TestMethod()] //-25, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg25_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("220.2222222222222", new Q(-25, 1), 3);

    [TestMethod()] //25, base 5
    public void ToStringExpandedAndFullInt_ForInt25_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100.0000000000000", new Q(25, 1), 5);

    [TestMethod()] //-25, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg25_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("44.44444444444444", new Q(-25, 1), 5);

    [TestMethod()] //124, base 2
    public void ToStringExpandedAndFullInt_ForInt124_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111100.000000000", new Q(124, 1), 2);

    [TestMethod()] //-124, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg124_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111011.111111111", new Q(-124, 1), 2);

    [TestMethod()] //124, base 3
    public void ToStringExpandedAndFullInt_ForInt124_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11121.00000000000", new Q(124, 1), 3);

    [TestMethod()] //-124, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg124_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11120.22222222222", new Q(-124, 1), 3);

    [TestMethod()] //124, base 5
    public void ToStringExpandedAndFullInt_ForInt124_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("444.0000000000000", new Q(124, 1), 5);

    [TestMethod()] //-124, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg124_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("443.4444444444444", new Q(-124, 1), 5);

    [TestMethod()] //125, base 2
    public void ToStringExpandedAndFullInt_ForInt125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111101.000000000", new Q(125, 1), 2);

    [TestMethod()] //-125, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111100.111111111", new Q(-125, 1), 2);

    [TestMethod()] //125, base 3
    public void ToStringExpandedAndFullInt_ForInt125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11122.00000000000", new Q(125, 1), 3);

    [TestMethod()] //-125, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11121.22222222222", new Q(-125, 1), 3);

    [TestMethod()] //125, base 5
    public void ToStringExpandedAndFullInt_ForInt125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1000.000000000000", new Q(125, 1), 5);

    [TestMethod()] //-125, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("444.4444444444444", new Q(-125, 1), 5);

    [TestMethod()] //126, base 2
    public void ToStringExpandedAndFullInt_ForInt126_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111110.000000000", new Q(126, 1), 2);

    [TestMethod()] //-126, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg126_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1111101.111111111", new Q(-126, 1), 2);

    [TestMethod()] //126, base 3
    public void ToStringExpandedAndFullInt_ForInt126_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11200.00000000000", new Q(126, 1), 3);

    [TestMethod()] //-126, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg126_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11122.22222222222", new Q(-126, 1), 3);

    [TestMethod()] //126, base 5
    public void ToStringExpandedAndFullInt_ForInt126_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1001.000000000000", new Q(126, 1), 5);

    [TestMethod()] //-126, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg126_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1000.444444444444", new Q(-126, 1), 5);

    [TestMethod()] //153, base 2
    public void ToStringExpandedAndFullInt_ForInt153_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10011001.00000000", new Q(153, 1), 2);

    [TestMethod()] //-153, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg153_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("10011000.11111111", new Q(-153, 1), 2);

    [TestMethod()] //153, base 3
    public void ToStringExpandedAndFullInt_ForInt153_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("12200.00000000000", new Q(153, 1), 3);

    [TestMethod()] //-153, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg153_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("12122.22222222222", new Q(-153, 1), 3);

    [TestMethod()] //153, base 5
    public void ToStringExpandedAndFullInt_ForInt153_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1103.000000000000", new Q(153, 1), 5);

    [TestMethod()] //-153, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg153_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1102.444444444444", new Q(-153, 1), 5);

    [TestMethod()] //255, base 2
    public void ToStringExpandedAndFullInt_ForInt255_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11111111.00000000", new Q(255, 1), 2);

    [TestMethod()] //-255, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg255_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11111110.11111111", new Q(-255, 1), 2);

    [TestMethod()] //255, base 3
    public void ToStringExpandedAndFullInt_ForInt255_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100110.0000000000", new Q(255, 1), 3);

    [TestMethod()] //-255, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg255_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100102.2222222222", new Q(-255, 1), 3);

    [TestMethod()] //255, base 5
    public void ToStringExpandedAndFullInt_ForInt255_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2010.000000000000", new Q(255, 1), 5);

    [TestMethod()] //-255, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg255_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2004.444444444444", new Q(-255, 1), 5);

    [TestMethod()] //256, base 2
    public void ToStringExpandedAndFullInt_ForInt256_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100000000.0000000", new Q(256, 1), 2);

    [TestMethod()] //-256, base 2
    public void ToStringExpandedAndFullInt_ForIntNeg256_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("11111111.11111111", new Q(-256, 1), 2);

    [TestMethod()] //256, base 3
    public void ToStringExpandedAndFullInt_ForInt256_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100111.0000000000", new Q(256, 1), 3);

    [TestMethod()] //-256, base 3
    public void ToStringExpandedAndFullInt_ForIntNeg256_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("100110.2222222222", new Q(-256, 1), 3);

    [TestMethod()] //256, base 5
    public void ToStringExpandedAndFullInt_ForInt256_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2011.000000000000", new Q(256, 1), 5);

    [TestMethod()] //-256, base 5
    public void ToStringExpandedAndFullInt_ForIntNeg256_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("2010.444444444444", new Q(-256, 1), 5);

    [TestMethod()] //9/7, base 2
    public void ToStringExpandedAndFullInt_ForQ9div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010010010010010", new Q(9, 7), 2);

    [TestMethod()] //-9/7, base 2
    public void ToStringExpandedAndFullInt_ForQNeg9div7_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010010010010010", new Q(-9, 7), 2);

    [TestMethod()] //9/7, base 3
    public void ToStringExpandedAndFullInt_ForQ9div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.021201021201021", new Q(9, 7), 3);

    [TestMethod()] //-9/7, base 3
    public void ToStringExpandedAndFullInt_ForQNeg9div7_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.021201021201021", new Q(-9, 7), 3);

    [TestMethod()] //9/7, base 5
    public void ToStringExpandedAndFullInt_ForQ9div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.120324120324120", new Q(9, 7), 5);

    [TestMethod()] //-9/7, base 5
    public void ToStringExpandedAndFullInt_ForQNeg9div7_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.120324120324120", new Q(-9, 7), 5);

    [TestMethod()] //22/3, base 2
    public void ToStringExpandedAndFullInt_ForQ22div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("111.0101010101010", new Q(22, 3), 2);

    [TestMethod()] //-22/3, base 2
    public void ToStringExpandedAndFullInt_ForQNeg22div3_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("111.0101010101010", new Q(-22, 3), 2);

    [TestMethod()] //22/3, base 3
    public void ToStringExpandedAndFullInt_ForQ22div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("21.10000000000000", new Q(22, 3), 3);

    [TestMethod()] //-22/3, base 3
    public void ToStringExpandedAndFullInt_ForQNeg22div3_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("21.02222222222222", new Q(-22, 3), 3);

    [TestMethod()] //22/3, base 5
    public void ToStringExpandedAndFullInt_ForQ22div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("12.13131313131313", new Q(22, 3), 5);

    [TestMethod()] //-22/3, base 5
    public void ToStringExpandedAndFullInt_ForQNeg22div3_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("12.13131313131313", new Q(-22, 3), 5);

    [TestMethod()] //12/125, base 2
    public void ToStringExpandedAndFullInt_ForQ12div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001100010010011", new Q(12, 125), 2);

    [TestMethod()] //-12/125, base 2
    public void ToStringExpandedAndFullInt_ForQNeg12div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0001100010010011", new Q(-12, 125), 2);

    [TestMethod()] //12/125, base 3
    public void ToStringExpandedAndFullInt_ForQ12div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0021202221201000", new Q(12, 125), 3);

    [TestMethod()] //-12/125, base 3
    public void ToStringExpandedAndFullInt_ForQNeg12div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0021202221201000", new Q(-12, 125), 3);

    [TestMethod()] //12/125, base 5
    public void ToStringExpandedAndFullInt_ForQ12div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0220000000000000", new Q(12, 125), 5);

    [TestMethod()] //-12/125, base 5
    public void ToStringExpandedAndFullInt_ForQNeg12div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0214444444444444", new Q(-12, 125), 5);

    [TestMethod()] //37/125, base 2
    public void ToStringExpandedAndFullInt_ForQ37div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100101111000110", new Q(37, 125), 2);

    [TestMethod()] //-37/125, base 2
    public void ToStringExpandedAndFullInt_ForQNeg37div125_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0100101111000110", new Q(-37, 125), 2);

    [TestMethod()] //37/125, base 3
    public void ToStringExpandedAndFullInt_ForQ37div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0212222100111121", new Q(37, 125), 3);

    [TestMethod()] //-37/125, base 3
    public void ToStringExpandedAndFullInt_ForQNeg37div125_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".0212222100111121", new Q(-37, 125), 3);

    [TestMethod()] //37/125, base 5
    public void ToStringExpandedAndFullInt_ForQ37div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1220000000000000", new Q(37, 125), 5);

    [TestMethod()] //-37/125, base 5
    public void ToStringExpandedAndFullInt_ForQNeg37div125_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect(".1214444444444444", new Q(-37, 125), 5);

    [TestMethod()] //23/18, base 2
    public void ToStringExpandedAndFullInt_ForQ23div18_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010001110001110", new Q(23, 18), 2);

    [TestMethod()] //-23/18, base 2
    public void ToStringExpandedAndFullInt_ForQNeg23div18_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.010001110001110", new Q(-23, 18), 2);

    [TestMethod()] //23/18, base 3
    public void ToStringExpandedAndFullInt_ForQ23div18_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.021111111111111", new Q(23, 18), 3);

    [TestMethod()] //-23/18, base 3
    public void ToStringExpandedAndFullInt_ForQNeg23div18_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.021111111111111", new Q(-23, 18), 3);

    [TestMethod()] //23/18, base 5
    public void ToStringExpandedAndFullInt_ForQ23div18_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.114330114330114", new Q(23, 18), 5);

    [TestMethod()] //-23/18, base 5
    public void ToStringExpandedAndFullInt_ForQNeg23div18_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1.114330114330114", new Q(-23, 18), 5);

    [TestMethod()] //537/11, base 2
    public void ToStringExpandedAndFullInt_ForQ537div11_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("110000.1101000101", new Q(537, 11), 2);

    [TestMethod()] //-537/11, base 2
    public void ToStringExpandedAndFullInt_ForQNeg537div11_Base2_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("110000.1101000101", new Q(-537, 11), 2);

    [TestMethod()] //537/11, base 3
    public void ToStringExpandedAndFullInt_ForQ537div11_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1210.211002110021", new Q(537, 11), 3);

    [TestMethod()] //-537/11, base 3
    public void ToStringExpandedAndFullInt_ForQNeg537div11_Base3_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("1210.211002110021", new Q(-537, 11), 3);

    [TestMethod()] //537/11, base 5
    public void ToStringExpandedAndFullInt_ForQ537div11_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("143.4021140211402", new Q(537, 11), 5);

    [TestMethod()] //-537/11, base 5
    public void ToStringExpandedAndFullInt_ForQNeg537div11_Base5_IsCorrect() => ToStringExpandedAndFullInt_ForQb_IsCorrect("143.4021140211402", new Q(-537, 11), 5);

    #endregion
}