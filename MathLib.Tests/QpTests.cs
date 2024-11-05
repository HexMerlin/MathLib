using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace MathLib.Tests;

[TestClass()]
public class QpTests
{

    //#region Qp FromQ Q
    //private static void QpFromQ_IsCorrect(Qp qp, int expBase, BigInteger expNumerator, BigInteger expDenominator, BigInteger expGeneratorNumerator, BigInteger expectedGeneratorDenominator)
    //{
    //    Assert.AreEqual(new Base(expBase), qp.Base, nameof(qp.Base));
    //    Assert.AreEqual(expNumerator, qp.Numerator, nameof(qp.Numerator));
    //    Assert.AreEqual(expDenominator, qp.Denominator, nameof(qp.Denominator));
    //    Assert.AreEqual(expGeneratorNumerator, qp.Generator.Numerator, nameof(qp.Generator.Numerator));
    //    Assert.AreEqual(expectedGeneratorDenominator, qp.Generator.Denominator, nameof(qp.Generator.Denominator));
    //}

    //[TestMethod()] public void QpFromQ_For0Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(0, 1), new Base(2)), 2, 0, 1, 0, 1);
    //[TestMethod()] public void QpFromQ_ForNeg1Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 1), new Base(2)), 2, -1, 1, 1, 1);
    //[TestMethod()] public void QpFromQ_For1Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 1), new Base(2)), 2, 1, 1, 1, 2);
    //[TestMethod()] public void QpFromQ_ForNeg1Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 2), new Base(2)), 2, -1, 2, -2, 1);
    //[TestMethod()] public void QpFromQ_For1Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 2), new Base(2)), 2, 1, 2, 1, 1);
    //[TestMethod()] public void QpFromQ_ForNeg1Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 3), new Base(2)), 2, -1, 3, -2, 3);
    //[TestMethod()] public void QpFromQ_For1Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 3), new Base(2)), 2, 1, 3, 5, 6);
    //[TestMethod()] public void QpFromQ_ForNeg1Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 4), new Base(2)), 2, -1, 4, -4, 1);
    //[TestMethod()] public void QpFromQ_For1Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 4), new Base(2)), 2, 1, 4, 2, 1);
    //[TestMethod()] public void QpFromQ_ForNeg1Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 5), new Base(2)), 2, -1, 5, -4, 5);
    //[TestMethod()] public void QpFromQ_For1Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 5), new Base(2)), 2, 1, 5, 7, 10);
    //[TestMethod()] public void QpFromQ_ForNeg1Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 6), new Base(2)), 2, -1, 6, -4, 3);
    //[TestMethod()] public void QpFromQ_For1Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 6), new Base(2)), 2, 1, 6, 5, 3);
    //[TestMethod()] public void QpFromQ_ForNeg1Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 7), new Base(2)), 2, -1, 7, -4, 7);
    //[TestMethod()] public void QpFromQ_For1Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 7), new Base(2)), 2, 1, 7, 13, 14);
    //[TestMethod()] public void QpFromQ_ForNeg1Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 9), new Base(2)), 2, -1, 9, -8, 9);
    //[TestMethod()] public void QpFromQ_For1Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 9), new Base(2)), 2, 1, 9, 11, 18);
    //[TestMethod()] public void QpFromQ_ForNeg1Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 10), new Base(2)), 2, -1, 10, -8, 5);
    //[TestMethod()] public void QpFromQ_For1Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 10), new Base(2)), 2, 1, 10, 7, 5);
    //[TestMethod()] public void QpFromQ_ForNeg1Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 12), new Base(2)), 2, -1, 12, -8, 3);
    //[TestMethod()] public void QpFromQ_For1Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 12), new Base(2)), 2, 1, 12, 10, 3);
    //[TestMethod()] public void QpFromQ_ForNeg1Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 14), new Base(2)), 2, -1, 14, -8, 7);
    //[TestMethod()] public void QpFromQ_For1Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 14), new Base(2)), 2, 1, 14, 13, 7);
    //[TestMethod()] public void QpFromQ_ForNeg1Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 15), new Base(2)), 2, -1, 15, -8, 15);
    //[TestMethod()] public void QpFromQ_For1Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 15), new Base(2)), 2, 1, 15, 29, 30);
    //[TestMethod()] public void QpFromQ_For1Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 17), new Base(2)), 2, 1, 17, 19, 34);
    //[TestMethod()] public void QpFromQ_ForNeg1Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 18), new Base(2)), 2, -1, 18, -16, 9);
    //[TestMethod()] public void QpFromQ_For1Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 18), new Base(2)), 2, 1, 18, 11, 9);
    //[TestMethod()] public void QpFromQ_ForNeg1Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 20), new Base(2)), 2, -1, 20, -16, 5);
    //[TestMethod()] public void QpFromQ_For1Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 20), new Base(2)), 2, 1, 20, 14, 5);
    //[TestMethod()] public void QpFromQ_ForNeg1Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 21), new Base(2)), 2, -1, 21, -16, 21);
    //[TestMethod()] public void QpFromQ_For1Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 21), new Base(2)), 2, 1, 21, 31, 42);
    //[TestMethod()] public void QpFromQ_ForNeg1Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 28), new Base(2)), 2, -1, 28, -16, 7);
    //[TestMethod()] public void QpFromQ_For1Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 28), new Base(2)), 2, 1, 28, 26, 7);
    //[TestMethod()] public void QpFromQ_ForNeg1Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 30), new Base(2)), 2, -1, 30, -16, 15);
    //[TestMethod()] public void QpFromQ_For1Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 30), new Base(2)), 2, 1, 30, 29, 15);
    //[TestMethod()] public void QpFromQ_ForNeg1Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 31), new Base(2)), 2, -1, 31, -16, 31);
    //[TestMethod()] public void QpFromQ_For1Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 31), new Base(2)), 2, 1, 31, 61, 62);
    //[TestMethod()] public void QpFromQ_For1Div34_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 34), new Base(2)), 2, 1, 34, 19, 17);
    //[TestMethod()] public void QpFromQ_ForNeg1Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 36), new Base(2)), 2, -1, 36, -32, 9);
    //[TestMethod()] public void QpFromQ_For1Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 36), new Base(2)), 2, 1, 36, 22, 9);
    //[TestMethod()] public void QpFromQ_ForNeg1Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 42), new Base(2)), 2, -1, 42, -32, 21);
    //[TestMethod()] public void QpFromQ_For1Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 42), new Base(2)), 2, 1, 42, 31, 21);
    //[TestMethod()] public void QpFromQ_ForNeg1Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 60), new Base(2)), 2, -1, 60, -32, 15);
    //[TestMethod()] public void QpFromQ_For1Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 60), new Base(2)), 2, 1, 60, 58, 15);
    //[TestMethod()] public void QpFromQ_ForNeg1Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 62), new Base(2)), 2, -1, 62, -32, 31);
    //[TestMethod()] public void QpFromQ_For1Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 62), new Base(2)), 2, 1, 62, 61, 31);
    //[TestMethod()] public void QpFromQ_ForNeg1Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 63), new Base(2)), 2, -1, 63, -32, 63);
    //[TestMethod()] public void QpFromQ_For1Div68_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 68), new Base(2)), 2, 1, 68, 38, 17);
    //[TestMethod()] public void QpFromQ_ForNeg1Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 84), new Base(2)), 2, -1, 84, -64, 21);
    //[TestMethod()] public void QpFromQ_For1Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 84), new Base(2)), 2, 1, 84, 62, 21);
    //[TestMethod()] public void QpFromQ_ForNeg1Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 85), new Base(2)), 2, -1, 85, -64, 85);
    //[TestMethod()] public void QpFromQ_ForNeg1Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 124), new Base(2)), 2, -1, 124, -64, 31);
    //[TestMethod()] public void QpFromQ_For1Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(1, 124), new Base(2)), 2, 1, 124, 122, 31);
    //[TestMethod()] public void QpFromQ_ForNeg1Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 126), new Base(2)), 2, -1, 126, -64, 63);
    //[TestMethod()] public void QpFromQ_ForNeg1Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 127), new Base(2)), 2, -1, 127, -64, 127);
    //[TestMethod()] public void QpFromQ_ForNeg1Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 170), new Base(2)), 2, -1, 170, -128, 85);
    //[TestMethod()] public void QpFromQ_ForNeg1Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 252), new Base(2)), 2, -1, 252, -128, 63);
    //[TestMethod()] public void QpFromQ_ForNeg1Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 254), new Base(2)), 2, -1, 254, -128, 127);
    //[TestMethod()] public void QpFromQ_ForNeg1Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 255), new Base(2)), 2, -1, 255, -128, 255);
    //[TestMethod()] public void QpFromQ_ForNeg1Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 508), new Base(2)), 2, -1, 508, -256, 127);
    //[TestMethod()] public void QpFromQ_ForNeg1Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 510), new Base(2)), 2, -1, 510, -256, 255);
    //[TestMethod()] public void QpFromQ_ForNeg1Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-1, 1020), new Base(2)), 2, -1, 1020, -512, 255);
    //[TestMethod()] public void QpFromQ_ForNeg2Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 1), new Base(2)), 2, -2, 1, -1, 2);
    //[TestMethod()] public void QpFromQ_For2Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 1), new Base(2)), 2, 2, 1, 1, 4);
    //[TestMethod()] public void QpFromQ_ForNeg2Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 3), new Base(2)), 2, -2, 3, -1, 3);
    //[TestMethod()] public void QpFromQ_For2Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 3), new Base(2)), 2, 2, 3, 5, 12);
    //[TestMethod()] public void QpFromQ_ForNeg2Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 5), new Base(2)), 2, -2, 5, -2, 5);
    //[TestMethod()] public void QpFromQ_For2Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 5), new Base(2)), 2, 2, 5, 7, 20);
    //[TestMethod()] public void QpFromQ_ForNeg2Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 7), new Base(2)), 2, -2, 7, -2, 7);
    //[TestMethod()] public void QpFromQ_For2Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 7), new Base(2)), 2, 2, 7, 13, 28);
    //[TestMethod()] public void QpFromQ_ForNeg2Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 9), new Base(2)), 2, -2, 9, -4, 9);
    //[TestMethod()] public void QpFromQ_For2Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 9), new Base(2)), 2, 2, 9, 11, 36);
    //[TestMethod()] public void QpFromQ_ForNeg2Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 15), new Base(2)), 2, -2, 15, -4, 15);
    //[TestMethod()] public void QpFromQ_For2Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 15), new Base(2)), 2, 2, 15, 29, 60);
    //[TestMethod()] public void QpFromQ_ForNeg2Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 17), new Base(2)), 2, -2, 17, -8, 17);
    //[TestMethod()] public void QpFromQ_ForNeg2Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 21), new Base(2)), 2, -2, 21, -8, 21);
    //[TestMethod()] public void QpFromQ_For2Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 21), new Base(2)), 2, 2, 21, 31, 84);
    //[TestMethod()] public void QpFromQ_ForNeg2Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 31), new Base(2)), 2, -2, 31, -8, 31);
    //[TestMethod()] public void QpFromQ_For2Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(2, 31), new Base(2)), 2, 2, 31, 61, 124);
    //[TestMethod()] public void QpFromQ_ForNeg2Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 51), new Base(2)), 2, -2, 51, -16, 51);
    //[TestMethod()] public void QpFromQ_ForNeg2Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 63), new Base(2)), 2, -2, 63, -16, 63);
    //[TestMethod()] public void QpFromQ_ForNeg2Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 85), new Base(2)), 2, -2, 85, -32, 85);
    //[TestMethod()] public void QpFromQ_ForNeg2Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 127), new Base(2)), 2, -2, 127, -32, 127);
    //[TestMethod()] public void QpFromQ_ForNeg2Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-2, 255), new Base(2)), 2, -2, 255, -64, 255);
    //[TestMethod()] public void QpFromQ_ForNeg3Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 1), new Base(2)), 2, -3, 1, -3, 4);
    //[TestMethod()] public void QpFromQ_For3Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 1), new Base(2)), 2, 3, 1, 3, 4);
    //[TestMethod()] public void QpFromQ_ForNeg3Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 2), new Base(2)), 2, -3, 2, -3, 2);
    //[TestMethod()] public void QpFromQ_For3Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 2), new Base(2)), 2, 3, 2, 3, 2);
    //[TestMethod()] public void QpFromQ_ForNeg3Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 4), new Base(2)), 2, -3, 4, -3, 1);
    //[TestMethod()] public void QpFromQ_For3Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 4), new Base(2)), 2, 3, 4, 3, 1);
    //[TestMethod()] public void QpFromQ_ForNeg3Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 5), new Base(2)), 2, -3, 5, -3, 5);
    //[TestMethod()] public void QpFromQ_For3Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 5), new Base(2)), 2, 3, 5, 9, 10);
    //[TestMethod()] public void QpFromQ_ForNeg3Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 7), new Base(2)), 2, -3, 7, -6, 7);
    //[TestMethod()] public void QpFromQ_For3Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 7), new Base(2)), 2, 3, 7, 9, 14);
    //[TestMethod()] public void QpFromQ_ForNeg3Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 10), new Base(2)), 2, -3, 10, -6, 5);
    //[TestMethod()] public void QpFromQ_For3Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 10), new Base(2)), 2, 3, 10, 9, 5);
    //[TestMethod()] public void QpFromQ_ForNeg3Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 14), new Base(2)), 2, -3, 14, -12, 7);
    //[TestMethod()] public void QpFromQ_For3Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 14), new Base(2)), 2, 3, 14, 9, 7);
    //[TestMethod()] public void QpFromQ_ForNeg3Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 17), new Base(2)), 2, -3, 17, -12, 17);
    //[TestMethod()] public void QpFromQ_ForNeg3Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 20), new Base(2)), 2, -3, 20, -12, 5);
    //[TestMethod()] public void QpFromQ_For3Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 20), new Base(2)), 2, 3, 20, 18, 5);
    //[TestMethod()] public void QpFromQ_ForNeg3Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 28), new Base(2)), 2, -3, 28, -24, 7);
    //[TestMethod()] public void QpFromQ_For3Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 28), new Base(2)), 2, 3, 28, 18, 7);
    //[TestMethod()] public void QpFromQ_ForNeg3Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 31), new Base(2)), 2, -3, 31, -24, 31);
    //[TestMethod()] public void QpFromQ_For3Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 31), new Base(2)), 2, 3, 31, 45, 62);
    //[TestMethod()] public void QpFromQ_ForNeg3Div34_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 34), new Base(2)), 2, -3, 34, -24, 17);
    //[TestMethod()] public void QpFromQ_ForNeg3Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 62), new Base(2)), 2, -3, 62, -48, 31);
    //[TestMethod()] public void QpFromQ_For3Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 62), new Base(2)), 2, 3, 62, 45, 31);
    //[TestMethod()] public void QpFromQ_ForNeg3Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 124), new Base(2)), 2, -3, 124, -96, 31);
    //[TestMethod()] public void QpFromQ_For3Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(3, 124), new Base(2)), 2, 3, 124, 90, 31);
    //[TestMethod()] public void QpFromQ_ForNeg3Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 127), new Base(2)), 2, -3, 127, -96, 127);
    //[TestMethod()] public void QpFromQ_ForNeg3Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 254), new Base(2)), 2, -3, 254, -192, 127);
    //[TestMethod()] public void QpFromQ_ForNeg3Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 508), new Base(2)), 2, -3, 508, -384, 127);
    //[TestMethod()] public void QpFromQ_ForNeg3Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-3, 511), new Base(2)), 2, -3, 511, -384, 511);
    //[TestMethod()] public void QpFromQ_ForNeg4Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 1), new Base(2)), 2, -4, 1, -1, 4);
    //[TestMethod()] public void QpFromQ_For4Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 1), new Base(2)), 2, 4, 1, 1, 8);
    //[TestMethod()] public void QpFromQ_ForNeg4Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 3), new Base(2)), 2, -4, 3, -1, 6);
    //[TestMethod()] public void QpFromQ_For4Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 3), new Base(2)), 2, 4, 3, 5, 24);
    //[TestMethod()] public void QpFromQ_ForNeg4Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 5), new Base(2)), 2, -4, 5, -1, 5);
    //[TestMethod()] public void QpFromQ_For4Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 5), new Base(2)), 2, 4, 5, 7, 40);
    //[TestMethod()] public void QpFromQ_ForNeg4Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 7), new Base(2)), 2, -4, 7, -1, 7);
    //[TestMethod()] public void QpFromQ_For4Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 7), new Base(2)), 2, 4, 7, 13, 56);
    //[TestMethod()] public void QpFromQ_ForNeg4Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 9), new Base(2)), 2, -4, 9, -2, 9);
    //[TestMethod()] public void QpFromQ_For4Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 9), new Base(2)), 2, 4, 9, 11, 72);
    //[TestMethod()] public void QpFromQ_ForNeg4Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 15), new Base(2)), 2, -4, 15, -2, 15);
    //[TestMethod()] public void QpFromQ_For4Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 15), new Base(2)), 2, 4, 15, 29, 120);
    //[TestMethod()] public void QpFromQ_ForNeg4Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 17), new Base(2)), 2, -4, 17, -4, 17);
    //[TestMethod()] public void QpFromQ_ForNeg4Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 21), new Base(2)), 2, -4, 21, -4, 21);
    //[TestMethod()] public void QpFromQ_For4Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 21), new Base(2)), 2, 4, 21, 31, 168);
    //[TestMethod()] public void QpFromQ_ForNeg4Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 31), new Base(2)), 2, -4, 31, -4, 31);
    //[TestMethod()] public void QpFromQ_For4Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(4, 31), new Base(2)), 2, 4, 31, 61, 248);
    //[TestMethod()] public void QpFromQ_ForNeg4Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 51), new Base(2)), 2, -4, 51, -8, 51);
    //[TestMethod()] public void QpFromQ_ForNeg4Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 63), new Base(2)), 2, -4, 63, -8, 63);
    //[TestMethod()] public void QpFromQ_ForNeg4Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 73), new Base(2)), 2, -4, 73, -16, 73);
    //[TestMethod()] public void QpFromQ_ForNeg4Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 85), new Base(2)), 2, -4, 85, -16, 85);
    //[TestMethod()] public void QpFromQ_ForNeg4Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 127), new Base(2)), 2, -4, 127, -16, 127);
    //[TestMethod()] public void QpFromQ_ForNeg4Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 255), new Base(2)), 2, -4, 255, -32, 255);
    //[TestMethod()] public void QpFromQ_ForNeg4Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-4, 511), new Base(2)), 2, -4, 511, -64, 511);
    //[TestMethod()] public void QpFromQ_ForNeg5Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 1), new Base(2)), 2, -5, 1, -7, 8);
    //[TestMethod()] public void QpFromQ_For5Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 1), new Base(2)), 2, 5, 1, 5, 8);
    //[TestMethod()] public void QpFromQ_ForNeg5Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 2), new Base(2)), 2, -5, 2, -7, 4);
    //[TestMethod()] public void QpFromQ_For5Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 2), new Base(2)), 2, 5, 2, 5, 4);
    //[TestMethod()] public void QpFromQ_ForNeg5Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 3), new Base(2)), 2, -5, 3, -7, 12);
    //[TestMethod()] public void QpFromQ_For5Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 3), new Base(2)), 2, 5, 3, 11, 12);
    //[TestMethod()] public void QpFromQ_ForNeg5Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 4), new Base(2)), 2, -5, 4, -7, 2);
    //[TestMethod()] public void QpFromQ_For5Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 4), new Base(2)), 2, 5, 4, 5, 2);
    //[TestMethod()] public void QpFromQ_ForNeg5Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 6), new Base(2)), 2, -5, 6, -7, 6);
    //[TestMethod()] public void QpFromQ_For5Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 6), new Base(2)), 2, 5, 6, 11, 6);
    //[TestMethod()] public void QpFromQ_ForNeg5Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 7), new Base(2)), 2, -5, 7, -5, 7);
    //[TestMethod()] public void QpFromQ_For5Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 7), new Base(2)), 2, 5, 7, 11, 14);
    //[TestMethod()] public void QpFromQ_ForNeg5Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 9), new Base(2)), 2, -5, 9, -7, 9);
    //[TestMethod()] public void QpFromQ_For5Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 9), new Base(2)), 2, 5, 9, 13, 18);
    //[TestMethod()] public void QpFromQ_ForNeg5Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 12), new Base(2)), 2, -5, 12, -7, 3);
    //[TestMethod()] public void QpFromQ_For5Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 12), new Base(2)), 2, 5, 12, 11, 3);
    //[TestMethod()] public void QpFromQ_ForNeg5Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 14), new Base(2)), 2, -5, 14, -10, 7);
    //[TestMethod()] public void QpFromQ_For5Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 14), new Base(2)), 2, 5, 14, 11, 7);
    //[TestMethod()] public void QpFromQ_For5Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 17), new Base(2)), 2, 5, 17, 23, 34);
    //[TestMethod()] public void QpFromQ_ForNeg5Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 18), new Base(2)), 2, -5, 18, -14, 9);
    //[TestMethod()] public void QpFromQ_For5Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 18), new Base(2)), 2, 5, 18, 13, 9);
    //[TestMethod()] public void QpFromQ_ForNeg5Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 21), new Base(2)), 2, -5, 21, -20, 21);
    //[TestMethod()] public void QpFromQ_For5Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 21), new Base(2)), 2, 5, 21, 23, 42);
    //[TestMethod()] public void QpFromQ_ForNeg5Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 28), new Base(2)), 2, -5, 28, -20, 7);
    //[TestMethod()] public void QpFromQ_For5Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 28), new Base(2)), 2, 5, 28, 22, 7);
    //[TestMethod()] public void QpFromQ_ForNeg5Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 31), new Base(2)), 2, -5, 31, -20, 31);
    //[TestMethod()] public void QpFromQ_For5Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 31), new Base(2)), 2, 5, 31, 53, 62);
    //[TestMethod()] public void QpFromQ_For5Div34_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 34), new Base(2)), 2, 5, 34, 23, 17);
    //[TestMethod()] public void QpFromQ_ForNeg5Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 36), new Base(2)), 2, -5, 36, -28, 9);
    //[TestMethod()] public void QpFromQ_For5Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 36), new Base(2)), 2, 5, 36, 26, 9);
    //[TestMethod()] public void QpFromQ_ForNeg5Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 42), new Base(2)), 2, -5, 42, -40, 21);
    //[TestMethod()] public void QpFromQ_For5Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 42), new Base(2)), 2, 5, 42, 23, 21);
    //[TestMethod()] public void QpFromQ_ForNeg5Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 62), new Base(2)), 2, -5, 62, -40, 31);
    //[TestMethod()] public void QpFromQ_For5Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 62), new Base(2)), 2, 5, 62, 53, 31);
    //[TestMethod()] public void QpFromQ_ForNeg5Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 63), new Base(2)), 2, -5, 63, -40, 63);
    //[TestMethod()] public void QpFromQ_For5Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 63), new Base(2)), 2, 5, 63, 109, 126);
    //[TestMethod()] public void QpFromQ_For5Div68_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 68), new Base(2)), 2, 5, 68, 46, 17);
    //[TestMethod()] public void QpFromQ_ForNeg5Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 73), new Base(2)), 2, -5, 73, -56, 73);
    //[TestMethod()] public void QpFromQ_For5Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 84), new Base(2)), 2, 5, 84, 46, 21);
    //[TestMethod()] public void QpFromQ_ForNeg5Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 124), new Base(2)), 2, -5, 124, -80, 31);
    //[TestMethod()] public void QpFromQ_For5Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 124), new Base(2)), 2, 5, 124, 106, 31);
    //[TestMethod()] public void QpFromQ_ForNeg5Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 126), new Base(2)), 2, -5, 126, -80, 63);
    //[TestMethod()] public void QpFromQ_For5Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 126), new Base(2)), 2, 5, 126, 109, 63);
    //[TestMethod()] public void QpFromQ_ForNeg5Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 127), new Base(2)), 2, -5, 127, -80, 127);
    //[TestMethod()] public void QpFromQ_For5Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 127), new Base(2)), 2, 5, 127, 221, 254);
    //[TestMethod()] public void QpFromQ_ForNeg5Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-5, 252), new Base(2)), 2, -5, 252, -160, 63);
    //[TestMethod()] public void QpFromQ_For5Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 252), new Base(2)), 2, 5, 252, 218, 63);
    //[TestMethod()] public void QpFromQ_For5Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 254), new Base(2)), 2, 5, 254, 221, 127);
    //[TestMethod()] public void QpFromQ_For5Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(5, 508), new Base(2)), 2, 5, 508, 442, 127);
    //[TestMethod()] public void QpFromQ_ForNeg6Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 1), new Base(2)), 2, -6, 1, -3, 8);
    //[TestMethod()] public void QpFromQ_For6Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(6, 1), new Base(2)), 2, 6, 1, 3, 8);
    //[TestMethod()] public void QpFromQ_ForNeg6Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 5), new Base(2)), 2, -6, 5, -3, 10);
    //[TestMethod()] public void QpFromQ_For6Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(6, 5), new Base(2)), 2, 6, 5, 9, 20);
    //[TestMethod()] public void QpFromQ_ForNeg6Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 7), new Base(2)), 2, -6, 7, -3, 7);
    //[TestMethod()] public void QpFromQ_For6Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(6, 7), new Base(2)), 2, 6, 7, 9, 28);
    //[TestMethod()] public void QpFromQ_ForNeg6Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 17), new Base(2)), 2, -6, 17, -6, 17);
    //[TestMethod()] public void QpFromQ_ForNeg6Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 31), new Base(2)), 2, -6, 31, -12, 31);
    //[TestMethod()] public void QpFromQ_For6Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(6, 31), new Base(2)), 2, 6, 31, 45, 124);
    //[TestMethod()] public void QpFromQ_ForNeg6Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 85), new Base(2)), 2, -6, 85, -24, 85);
    //[TestMethod()] public void QpFromQ_ForNeg6Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 127), new Base(2)), 2, -6, 127, -48, 127);
    //[TestMethod()] public void QpFromQ_ForNeg6Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-6, 511), new Base(2)), 2, -6, 511, -192, 511);
    //[TestMethod()] public void QpFromQ_ForNeg7Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 1), new Base(2)), 2, -7, 1, -5, 8);
    //[TestMethod()] public void QpFromQ_For7Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 1), new Base(2)), 2, 7, 1, 7, 8);
    //[TestMethod()] public void QpFromQ_ForNeg7Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 2), new Base(2)), 2, -7, 2, -5, 4);
    //[TestMethod()] public void QpFromQ_For7Div2_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 2), new Base(2)), 2, 7, 2, 7, 4);
    //[TestMethod()] public void QpFromQ_ForNeg7Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 3), new Base(2)), 2, -7, 3, -19, 24);
    //[TestMethod()] public void QpFromQ_For7Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 3), new Base(2)), 2, 7, 3, 17, 24);
    //[TestMethod()] public void QpFromQ_ForNeg7Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 4), new Base(2)), 2, -7, 4, -5, 2);
    //[TestMethod()] public void QpFromQ_For7Div4_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 4), new Base(2)), 2, 7, 4, 7, 2);
    //[TestMethod()] public void QpFromQ_ForNeg7Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 5), new Base(2)), 2, -7, 5, -13, 20);
    //[TestMethod()] public void QpFromQ_For7Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 5), new Base(2)), 2, 7, 5, 17, 20);
    //[TestMethod()] public void QpFromQ_ForNeg7Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 6), new Base(2)), 2, -7, 6, -19, 12);
    //[TestMethod()] public void QpFromQ_For7Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 6), new Base(2)), 2, 7, 6, 17, 12);
    //[TestMethod()] public void QpFromQ_ForNeg7Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 9), new Base(2)), 2, -7, 9, -5, 9);
    //[TestMethod()] public void QpFromQ_ForNeg7Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 10), new Base(2)), 2, -7, 10, -13, 10);
    //[TestMethod()] public void QpFromQ_For7Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 10), new Base(2)), 2, 7, 10, 17, 10);
    //[TestMethod()] public void QpFromQ_ForNeg7Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 12), new Base(2)), 2, -7, 12, -19, 6);
    //[TestMethod()] public void QpFromQ_For7Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 12), new Base(2)), 2, 7, 12, 17, 6);
    //[TestMethod()] public void QpFromQ_ForNeg7Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 15), new Base(2)), 2, -7, 15, -14, 15);
    //[TestMethod()] public void QpFromQ_For7Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 15), new Base(2)), 2, 7, 15, 17, 30);
    //[TestMethod()] public void QpFromQ_ForNeg7Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 18), new Base(2)), 2, -7, 18, -10, 9);
    //[TestMethod()] public void QpFromQ_ForNeg7Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 20), new Base(2)), 2, -7, 20, -13, 5);
    //[TestMethod()] public void QpFromQ_For7Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 20), new Base(2)), 2, 7, 20, 17, 5);
    //[TestMethod()] public void QpFromQ_ForNeg7Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 30), new Base(2)), 2, -7, 30, -28, 15);
    //[TestMethod()] public void QpFromQ_For7Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 30), new Base(2)), 2, 7, 30, 17, 15);
    //[TestMethod()] public void QpFromQ_ForNeg7Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 31), new Base(2)), 2, -7, 31, -28, 31);
    //[TestMethod()] public void QpFromQ_For7Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 31), new Base(2)), 2, 7, 31, 37, 62);
    //[TestMethod()] public void QpFromQ_ForNeg7Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 36), new Base(2)), 2, -7, 36, -20, 9);
    //[TestMethod()] public void QpFromQ_ForNeg7Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 51), new Base(2)), 2, -7, 51, -196, 255);
    //[TestMethod()] public void QpFromQ_ForNeg7Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 60), new Base(2)), 2, -7, 60, -56, 15);
    //[TestMethod()] public void QpFromQ_For7Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 60), new Base(2)), 2, 7, 60, 34, 15);
    //[TestMethod()] public void QpFromQ_ForNeg7Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 62), new Base(2)), 2, -7, 62, -56, 31);
    //[TestMethod()] public void QpFromQ_For7Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 62), new Base(2)), 2, 7, 62, 37, 31);
    //[TestMethod()] public void QpFromQ_ForNeg7Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 102), new Base(2)), 2, -7, 102, -392, 255);
    //[TestMethod()] public void QpFromQ_ForNeg7Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 124), new Base(2)), 2, -7, 124, -112, 31);
    //[TestMethod()] public void QpFromQ_For7Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 124), new Base(2)), 2, 7, 124, 74, 31);
    //[TestMethod()] public void QpFromQ_ForNeg7Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 127), new Base(2)), 2, -7, 127, -112, 127);
    //[TestMethod()] public void QpFromQ_For7Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 127), new Base(2)), 2, 7, 127, 157, 254);
    //[TestMethod()] public void QpFromQ_ForNeg7Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 254), new Base(2)), 2, -7, 254, -224, 127);
    //[TestMethod()] public void QpFromQ_For7Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 254), new Base(2)), 2, 7, 254, 157, 127);
    //[TestMethod()] public void QpFromQ_ForNeg7Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-7, 508), new Base(2)), 2, -7, 508, -448, 127);
    //[TestMethod()] public void QpFromQ_For7Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(7, 508), new Base(2)), 2, 7, 508, 314, 127);
    //[TestMethod()] public void QpFromQ_ForNeg8Div1_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 1), new Base(2)), 2, -8, 1, -1, 8);
    //[TestMethod()] public void QpFromQ_ForNeg8Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 3), new Base(2)), 2, -8, 3, -1, 12);
    //[TestMethod()] public void QpFromQ_ForNeg8Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 5), new Base(2)), 2, -8, 5, -1, 10);
    //[TestMethod()] public void QpFromQ_ForNeg8Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 7), new Base(2)), 2, -8, 7, -1, 14);
    //[TestMethod()] public void QpFromQ_ForNeg8Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 9), new Base(2)), 2, -8, 9, -1, 9);
    //[TestMethod()] public void QpFromQ_ForNeg8Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 15), new Base(2)), 2, -8, 15, -1, 15);
    //[TestMethod()] public void QpFromQ_ForNeg8Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 17), new Base(2)), 2, -8, 17, -2, 17);
    //[TestMethod()] public void QpFromQ_ForNeg8Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 21), new Base(2)), 2, -8, 21, -2, 21);
    //[TestMethod()] public void QpFromQ_ForNeg8Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 31), new Base(2)), 2, -8, 31, -2, 31);
    //[TestMethod()] public void QpFromQ_ForNeg8Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 51), new Base(2)), 2, -8, 51, -4, 51);
    //[TestMethod()] public void QpFromQ_ForNeg8Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 63), new Base(2)), 2, -8, 63, -4, 63);
    //[TestMethod()] public void QpFromQ_ForNeg8Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 73), new Base(2)), 2, -8, 73, -8, 73);
    //[TestMethod()] public void QpFromQ_ForNeg8Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 85), new Base(2)), 2, -8, 85, -8, 85);
    //[TestMethod()] public void QpFromQ_ForNeg8Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 127), new Base(2)), 2, -8, 127, -8, 127);
    //[TestMethod()] public void QpFromQ_ForNeg8Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 255), new Base(2)), 2, -8, 255, -16, 255);
    //[TestMethod()] public void QpFromQ_ForNeg8Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-8, 511), new Base(2)), 2, -8, 511, -32, 511);
    //[TestMethod()] public void QpFromQ_ForNeg9Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 5), new Base(2)), 2, -9, 5, -33, 40);
    //[TestMethod()] public void QpFromQ_For9Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 5), new Base(2)), 2, 9, 5, 27, 40);
    //[TestMethod()] public void QpFromQ_ForNeg9Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 7), new Base(2)), 2, -9, 7, -15, 28);
    //[TestMethod()] public void QpFromQ_For9Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 7), new Base(2)), 2, 9, 7, 27, 28);
    //[TestMethod()] public void QpFromQ_ForNeg9Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 10), new Base(2)), 2, -9, 10, -33, 20);
    //[TestMethod()] public void QpFromQ_For9Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 10), new Base(2)), 2, 9, 10, 27, 20);
    //[TestMethod()] public void QpFromQ_ForNeg9Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 14), new Base(2)), 2, -9, 14, -15, 14);
    //[TestMethod()] public void QpFromQ_For9Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 14), new Base(2)), 2, 9, 14, 27, 14);
    //[TestMethod()] public void QpFromQ_ForNeg9Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 20), new Base(2)), 2, -9, 20, -33, 10);
    //[TestMethod()] public void QpFromQ_For9Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 20), new Base(2)), 2, 9, 20, 27, 10);
    //[TestMethod()] public void QpFromQ_ForNeg9Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 28), new Base(2)), 2, -9, 28, -15, 7);
    //[TestMethod()] public void QpFromQ_For9Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 28), new Base(2)), 2, 9, 28, 27, 7);
    //[TestMethod()] public void QpFromQ_ForNeg9Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 31), new Base(2)), 2, -9, 31, -18, 31);
    //[TestMethod()] public void QpFromQ_For9Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 31), new Base(2)), 2, 9, 31, 57, 62);
    //[TestMethod()] public void QpFromQ_ForNeg9Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 62), new Base(2)), 2, -9, 62, -36, 31);
    //[TestMethod()] public void QpFromQ_For9Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 62), new Base(2)), 2, 9, 62, 57, 31);
    //[TestMethod()] public void QpFromQ_ForNeg9Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 124), new Base(2)), 2, -9, 124, -72, 31);
    //[TestMethod()] public void QpFromQ_For9Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 124), new Base(2)), 2, 9, 124, 114, 31);
    //[TestMethod()] public void QpFromQ_ForNeg9Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 127), new Base(2)), 2, -9, 127, -72, 127);
    //[TestMethod()] public void QpFromQ_For9Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 127), new Base(2)), 2, 9, 127, 237, 254);
    //[TestMethod()] public void QpFromQ_ForNeg9Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 254), new Base(2)), 2, -9, 254, -144, 127);
    //[TestMethod()] public void QpFromQ_For9Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 254), new Base(2)), 2, 9, 254, 237, 127);
    //[TestMethod()] public void QpFromQ_ForNeg9Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-9, 508), new Base(2)), 2, -9, 508, -288, 127);
    //[TestMethod()] public void QpFromQ_For9Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(9, 508), new Base(2)), 2, 9, 508, 474, 127);
    //[TestMethod()] public void QpFromQ_ForNeg10Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 3), new Base(2)), 2, -10, 3, -7, 24);
    //[TestMethod()] public void QpFromQ_For10Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 3), new Base(2)), 2, 10, 3, 11, 24);
    //[TestMethod()] public void QpFromQ_ForNeg10Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 7), new Base(2)), 2, -10, 7, -5, 14);
    //[TestMethod()] public void QpFromQ_For10Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 7), new Base(2)), 2, 10, 7, 11, 28);
    //[TestMethod()] public void QpFromQ_ForNeg10Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 9), new Base(2)), 2, -10, 9, -7, 18);
    //[TestMethod()] public void QpFromQ_For10Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 9), new Base(2)), 2, 10, 9, 13, 36);
    //[TestMethod()] public void QpFromQ_ForNeg10Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 21), new Base(2)), 2, -10, 21, -10, 21);
    //[TestMethod()] public void QpFromQ_For10Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 21), new Base(2)), 2, 10, 21, 23, 84);
    //[TestMethod()] public void QpFromQ_ForNeg10Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 31), new Base(2)), 2, -10, 31, -10, 31);
    //[TestMethod()] public void QpFromQ_For10Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 31), new Base(2)), 2, 10, 31, 53, 124);
    //[TestMethod()] public void QpFromQ_ForNeg10Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 51), new Base(2)), 2, -10, 51, -76, 255);
    //[TestMethod()] public void QpFromQ_ForNeg10Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 63), new Base(2)), 2, -10, 63, -20, 63);
    //[TestMethod()] public void QpFromQ_For10Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 63), new Base(2)), 2, 10, 63, 109, 252);
    //[TestMethod()] public void QpFromQ_ForNeg10Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 73), new Base(2)), 2, -10, 73, -28, 73);
    //[TestMethod()] public void QpFromQ_ForNeg10Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-10, 127), new Base(2)), 2, -10, 127, -40, 127);
    //[TestMethod()] public void QpFromQ_For10Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(10, 127), new Base(2)), 2, 10, 127, 221, 508);
    //[TestMethod()] public void QpFromQ_ForNeg11Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 5), new Base(2)), 2, -11, 5, -11, 20);
    //[TestMethod()] public void QpFromQ_For11Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 5), new Base(2)), 2, 11, 5, 19, 20);
    //[TestMethod()] public void QpFromQ_ForNeg11Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 7), new Base(2)), 2, -11, 7, -43, 56);
    //[TestMethod()] public void QpFromQ_For11Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 7), new Base(2)), 2, 11, 7, 41, 56);
    //[TestMethod()] public void QpFromQ_For11Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 9), new Base(2)), 2, 11, 9, 29, 36);
    //[TestMethod()] public void QpFromQ_ForNeg11Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 10), new Base(2)), 2, -11, 10, -11, 10);
    //[TestMethod()] public void QpFromQ_For11Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 10), new Base(2)), 2, 11, 10, 19, 10);
    //[TestMethod()] public void QpFromQ_ForNeg11Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 14), new Base(2)), 2, -11, 14, -43, 28);
    //[TestMethod()] public void QpFromQ_For11Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 14), new Base(2)), 2, 11, 14, 41, 28);
    //[TestMethod()] public void QpFromQ_ForNeg11Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 15), new Base(2)), 2, -11, 15, -13, 15);
    //[TestMethod()] public void QpFromQ_For11Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 15), new Base(2)), 2, 11, 15, 19, 30);
    //[TestMethod()] public void QpFromQ_For11Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 18), new Base(2)), 2, 11, 18, 29, 18);
    //[TestMethod()] public void QpFromQ_ForNeg11Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 20), new Base(2)), 2, -11, 20, -11, 5);
    //[TestMethod()] public void QpFromQ_For11Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 20), new Base(2)), 2, 11, 20, 19, 5);
    //[TestMethod()] public void QpFromQ_ForNeg11Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 21), new Base(2)), 2, -11, 21, -11, 21);
    //[TestMethod()] public void QpFromQ_ForNeg11Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 28), new Base(2)), 2, -11, 28, -43, 14);
    //[TestMethod()] public void QpFromQ_For11Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 28), new Base(2)), 2, 11, 28, 41, 14);
    //[TestMethod()] public void QpFromQ_ForNeg11Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 30), new Base(2)), 2, -11, 30, -26, 15);
    //[TestMethod()] public void QpFromQ_For11Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 30), new Base(2)), 2, 11, 30, 19, 15);
    //[TestMethod()] public void QpFromQ_ForNeg11Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 31), new Base(2)), 2, -11, 31, -26, 31);
    //[TestMethod()] public void QpFromQ_For11Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 31), new Base(2)), 2, 11, 31, 41, 62);
    //[TestMethod()] public void QpFromQ_For11Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 36), new Base(2)), 2, 11, 36, 29, 9);
    //[TestMethod()] public void QpFromQ_ForNeg11Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 42), new Base(2)), 2, -11, 42, -22, 21);
    //[TestMethod()] public void QpFromQ_ForNeg11Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 60), new Base(2)), 2, -11, 60, -52, 15);
    //[TestMethod()] public void QpFromQ_For11Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 60), new Base(2)), 2, 11, 60, 38, 15);
    //[TestMethod()] public void QpFromQ_ForNeg11Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 62), new Base(2)), 2, -11, 62, -52, 31);
    //[TestMethod()] public void QpFromQ_For11Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 62), new Base(2)), 2, 11, 62, 41, 31);
    //[TestMethod()] public void QpFromQ_ForNeg11Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 63), new Base(2)), 2, -11, 63, -52, 63);
    //[TestMethod()] public void QpFromQ_For11Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 63), new Base(2)), 2, 11, 63, 85, 126);
    //[TestMethod()] public void QpFromQ_ForNeg11Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 73), new Base(2)), 2, -11, 73, -356, 511);
    //[TestMethod()] public void QpFromQ_ForNeg11Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 84), new Base(2)), 2, -11, 84, -44, 21);
    //[TestMethod()] public void QpFromQ_ForNeg11Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 85), new Base(2)), 2, -11, 85, -44, 85);
    //[TestMethod()] public void QpFromQ_ForNeg11Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 124), new Base(2)), 2, -11, 124, -104, 31);
    //[TestMethod()] public void QpFromQ_For11Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 124), new Base(2)), 2, 11, 124, 82, 31);
    //[TestMethod()] public void QpFromQ_ForNeg11Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 126), new Base(2)), 2, -11, 126, -104, 63);
    //[TestMethod()] public void QpFromQ_For11Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 126), new Base(2)), 2, 11, 126, 85, 63);
    //[TestMethod()] public void QpFromQ_ForNeg11Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 127), new Base(2)), 2, -11, 127, -104, 127);
    //[TestMethod()] public void QpFromQ_For11Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 127), new Base(2)), 2, 11, 127, 173, 254);
    //[TestMethod()] public void QpFromQ_ForNeg11Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 170), new Base(2)), 2, -11, 170, -88, 85);
    //[TestMethod()] public void QpFromQ_ForNeg11Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 252), new Base(2)), 2, -11, 252, -208, 63);
    //[TestMethod()] public void QpFromQ_For11Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 252), new Base(2)), 2, 11, 252, 170, 63);
    //[TestMethod()] public void QpFromQ_For11Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 254), new Base(2)), 2, 11, 254, 173, 127);
    //[TestMethod()] public void QpFromQ_For11Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 255), new Base(2)), 2, 11, 255, 349, 510);
    //[TestMethod()] public void QpFromQ_ForNeg11Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-11, 340), new Base(2)), 2, -11, 340, -176, 85);
    //[TestMethod()] public void QpFromQ_For11Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 508), new Base(2)), 2, 11, 508, 346, 127);
    //[TestMethod()] public void QpFromQ_For11Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 510), new Base(2)), 2, 11, 510, 349, 255);
    //[TestMethod()] public void QpFromQ_For11Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(11, 1020), new Base(2)), 2, 11, 1020, 698, 255);
    //[TestMethod()] public void QpFromQ_ForNeg12Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 5), new Base(2)), 2, -12, 5, -3, 20);
    //[TestMethod()] public void QpFromQ_For12Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(12, 5), new Base(2)), 2, 12, 5, 9, 40);
    //[TestMethod()] public void QpFromQ_ForNeg12Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 7), new Base(2)), 2, -12, 7, -3, 14);
    //[TestMethod()] public void QpFromQ_For12Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(12, 7), new Base(2)), 2, 12, 7, 9, 56);
    //[TestMethod()] public void QpFromQ_ForNeg12Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 17), new Base(2)), 2, -12, 17, -3, 17);
    //[TestMethod()] public void QpFromQ_ForNeg12Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 31), new Base(2)), 2, -12, 31, -6, 31);
    //[TestMethod()] public void QpFromQ_For12Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(12, 31), new Base(2)), 2, 12, 31, 45, 248);
    //[TestMethod()] public void QpFromQ_ForNeg12Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 73), new Base(2)), 2, -12, 73, -12, 73);
    //[TestMethod()] public void QpFromQ_ForNeg12Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 85), new Base(2)), 2, -12, 85, -12, 85);
    //[TestMethod()] public void QpFromQ_ForNeg12Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 127), new Base(2)), 2, -12, 127, -24, 127);
    //[TestMethod()] public void QpFromQ_ForNeg12Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-12, 511), new Base(2)), 2, -12, 511, -96, 511);
    //[TestMethod()] public void QpFromQ_ForNeg13Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 3), new Base(2)), 2, -13, 3, -13, 24);
    //[TestMethod()] public void QpFromQ_For13Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 3), new Base(2)), 2, 13, 3, 23, 24);
    //[TestMethod()] public void QpFromQ_ForNeg13Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 6), new Base(2)), 2, -13, 6, -13, 12);
    //[TestMethod()] public void QpFromQ_For13Div6_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 6), new Base(2)), 2, 13, 6, 23, 12);
    //[TestMethod()] public void QpFromQ_ForNeg13Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 7), new Base(2)), 2, -13, 7, -19, 28);
    //[TestMethod()] public void QpFromQ_For13Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 7), new Base(2)), 2, 13, 7, 23, 28);
    //[TestMethod()] public void QpFromQ_For13Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 9), new Base(2)), 2, 13, 9, 47, 72);
    //[TestMethod()] public void QpFromQ_ForNeg13Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 12), new Base(2)), 2, -13, 12, -13, 6);
    //[TestMethod()] public void QpFromQ_For13Div12_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 12), new Base(2)), 2, 13, 12, 23, 6);
    //[TestMethod()] public void QpFromQ_ForNeg13Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 14), new Base(2)), 2, -13, 14, -19, 14);
    //[TestMethod()] public void QpFromQ_For13Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 14), new Base(2)), 2, 13, 14, 23, 14);
    //[TestMethod()] public void QpFromQ_ForNeg13Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 15), new Base(2)), 2, -13, 15, -11, 15);
    //[TestMethod()] public void QpFromQ_For13Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 15), new Base(2)), 2, 13, 15, 23, 30);
    //[TestMethod()] public void QpFromQ_For13Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 18), new Base(2)), 2, 13, 18, 47, 36);
    //[TestMethod()] public void QpFromQ_ForNeg13Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 21), new Base(2)), 2, -13, 21, -19, 21);
    //[TestMethod()] public void QpFromQ_For13Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 21), new Base(2)), 2, 13, 21, 25, 42);
    //[TestMethod()] public void QpFromQ_ForNeg13Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 28), new Base(2)), 2, -13, 28, -19, 7);
    //[TestMethod()] public void QpFromQ_For13Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 28), new Base(2)), 2, 13, 28, 23, 7);
    //[TestMethod()] public void QpFromQ_ForNeg13Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 30), new Base(2)), 2, -13, 30, -22, 15);
    //[TestMethod()] public void QpFromQ_For13Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 30), new Base(2)), 2, 13, 30, 23, 15);
    //[TestMethod()] public void QpFromQ_ForNeg13Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 31), new Base(2)), 2, -13, 31, -22, 31);
    //[TestMethod()] public void QpFromQ_For13Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 31), new Base(2)), 2, 13, 31, 49, 62);
    //[TestMethod()] public void QpFromQ_For13Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 36), new Base(2)), 2, 13, 36, 47, 18);
    //[TestMethod()] public void QpFromQ_ForNeg13Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 42), new Base(2)), 2, -13, 42, -38, 21);
    //[TestMethod()] public void QpFromQ_For13Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 42), new Base(2)), 2, 13, 42, 25, 21);
    //[TestMethod()] public void QpFromQ_ForNeg13Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 51), new Base(2)), 2, -13, 51, -26, 51);
    //[TestMethod()] public void QpFromQ_ForNeg13Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 60), new Base(2)), 2, -13, 60, -44, 15);
    //[TestMethod()] public void QpFromQ_For13Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 60), new Base(2)), 2, 13, 60, 46, 15);
    //[TestMethod()] public void QpFromQ_ForNeg13Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 62), new Base(2)), 2, -13, 62, -44, 31);
    //[TestMethod()] public void QpFromQ_For13Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 62), new Base(2)), 2, 13, 62, 49, 31);
    //[TestMethod()] public void QpFromQ_ForNeg13Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 63), new Base(2)), 2, -13, 63, -44, 63);
    //[TestMethod()] public void QpFromQ_For13Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 63), new Base(2)), 2, 13, 63, 101, 126);
    //[TestMethod()] public void QpFromQ_ForNeg13Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 84), new Base(2)), 2, -13, 84, -76, 21);
    //[TestMethod()] public void QpFromQ_For13Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 84), new Base(2)), 2, 13, 84, 50, 21);
    //[TestMethod()] public void QpFromQ_ForNeg13Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 102), new Base(2)), 2, -13, 102, -52, 51);
    //[TestMethod()] public void QpFromQ_ForNeg13Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 124), new Base(2)), 2, -13, 124, -88, 31);
    //[TestMethod()] public void QpFromQ_For13Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 124), new Base(2)), 2, 13, 124, 98, 31);
    //[TestMethod()] public void QpFromQ_ForNeg13Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 126), new Base(2)), 2, -13, 126, -88, 63);
    //[TestMethod()] public void QpFromQ_For13Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 126), new Base(2)), 2, 13, 126, 101, 63);
    //[TestMethod()] public void QpFromQ_ForNeg13Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 127), new Base(2)), 2, -13, 127, -88, 127);
    //[TestMethod()] public void QpFromQ_For13Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 127), new Base(2)), 2, 13, 127, 205, 254);
    //[TestMethod()] public void QpFromQ_ForNeg13Div204_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 204), new Base(2)), 2, -13, 204, -104, 51);
    //[TestMethod()] public void QpFromQ_ForNeg13Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 252), new Base(2)), 2, -13, 252, -176, 63);
    //[TestMethod()] public void QpFromQ_For13Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 252), new Base(2)), 2, 13, 252, 202, 63);
    //[TestMethod()] public void QpFromQ_ForNeg13Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 254), new Base(2)), 2, -13, 254, -176, 127);
    //[TestMethod()] public void QpFromQ_For13Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 254), new Base(2)), 2, 13, 254, 205, 127);
    //[TestMethod()] public void QpFromQ_ForNeg13Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 255), new Base(2)), 2, -13, 255, -176, 255);
    //[TestMethod()] public void QpFromQ_ForNeg13Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 508), new Base(2)), 2, -13, 508, -352, 127);
    //[TestMethod()] public void QpFromQ_For13Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(13, 508), new Base(2)), 2, 13, 508, 410, 127);
    //[TestMethod()] public void QpFromQ_ForNeg13Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 510), new Base(2)), 2, -13, 510, -352, 255);
    //[TestMethod()] public void QpFromQ_ForNeg13Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 511), new Base(2)), 2, -13, 511, -352, 511);
    //[TestMethod()] public void QpFromQ_ForNeg13Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-13, 1020), new Base(2)), 2, -13, 1020, -704, 255);
    //[TestMethod()] public void QpFromQ_ForNeg14Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 5), new Base(2)), 2, -14, 5, -13, 40);
    //[TestMethod()] public void QpFromQ_For14Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(14, 5), new Base(2)), 2, 14, 5, 17, 40);
    //[TestMethod()] public void QpFromQ_ForNeg14Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 9), new Base(2)), 2, -14, 9, -5, 18);
    //[TestMethod()] public void QpFromQ_ForNeg14Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 15), new Base(2)), 2, -14, 15, -7, 15);
    //[TestMethod()] public void QpFromQ_For14Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(14, 15), new Base(2)), 2, 14, 15, 17, 60);
    //[TestMethod()] public void QpFromQ_ForNeg14Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 31), new Base(2)), 2, -14, 31, -14, 31);
    //[TestMethod()] public void QpFromQ_For14Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(14, 31), new Base(2)), 2, 14, 31, 37, 124);
    //[TestMethod()] public void QpFromQ_ForNeg14Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 51), new Base(2)), 2, -14, 51, -98, 255);
    //[TestMethod()] public void QpFromQ_ForNeg14Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 85), new Base(2)), 2, -14, 85, -28, 85);
    //[TestMethod()] public void QpFromQ_ForNeg14Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 127), new Base(2)), 2, -14, 127, -56, 127);
    //[TestMethod()] public void QpFromQ_For14Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(14, 127), new Base(2)), 2, 14, 127, 157, 508);
    //[TestMethod()] public void QpFromQ_ForNeg14Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-14, 255), new Base(2)), 2, -14, 255, -112, 255);
    //[TestMethod()] public void QpFromQ_ForNeg15Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 17), new Base(2)), 2, -15, 17, -9, 17);
    //[TestMethod()] public void QpFromQ_ForNeg15Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 31), new Base(2)), 2, -15, 31, -30, 31);
    //[TestMethod()] public void QpFromQ_For15Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(15, 31), new Base(2)), 2, 15, 31, 33, 62);
    //[TestMethod()] public void QpFromQ_ForNeg15Div34_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 34), new Base(2)), 2, -15, 34, -18, 17);
    //[TestMethod()] public void QpFromQ_ForNeg15Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 62), new Base(2)), 2, -15, 62, -60, 31);
    //[TestMethod()] public void QpFromQ_For15Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(15, 62), new Base(2)), 2, 15, 62, 33, 31);
    //[TestMethod()] public void QpFromQ_ForNeg15Div68_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 68), new Base(2)), 2, -15, 68, -36, 17);
    //[TestMethod()] public void QpFromQ_ForNeg15Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 124), new Base(2)), 2, -15, 124, -120, 31);
    //[TestMethod()] public void QpFromQ_For15Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(15, 124), new Base(2)), 2, 15, 124, 66, 31);
    //[TestMethod()] public void QpFromQ_ForNeg15Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 127), new Base(2)), 2, -15, 127, -120, 127);
    //[TestMethod()] public void QpFromQ_For15Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(15, 127), new Base(2)), 2, 15, 127, 141, 254);
    //[TestMethod()] public void QpFromQ_ForNeg15Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 254), new Base(2)), 2, -15, 254, -240, 127);
    //[TestMethod()] public void QpFromQ_For15Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(15, 254), new Base(2)), 2, 15, 254, 141, 127);
    //[TestMethod()] public void QpFromQ_ForNeg15Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-15, 508), new Base(2)), 2, -15, 508, -480, 127);
    //[TestMethod()] public void QpFromQ_For15Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(15, 508), new Base(2)), 2, 15, 508, 282, 127);
    //[TestMethod()] public void QpFromQ_ForNeg16Div3_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 3), new Base(2)), 2, -16, 3, -1, 24);
    //[TestMethod()] public void QpFromQ_ForNeg16Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 5), new Base(2)), 2, -16, 5, -1, 20);
    //[TestMethod()] public void QpFromQ_ForNeg16Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 7), new Base(2)), 2, -16, 7, -1, 28);
    //[TestMethod()] public void QpFromQ_ForNeg16Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 9), new Base(2)), 2, -16, 9, -1, 18);
    //[TestMethod()] public void QpFromQ_ForNeg16Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 15), new Base(2)), 2, -16, 15, -1, 30);
    //[TestMethod()] public void QpFromQ_ForNeg16Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 17), new Base(2)), 2, -16, 17, -1, 17);
    //[TestMethod()] public void QpFromQ_ForNeg16Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 21), new Base(2)), 2, -16, 21, -1, 21);
    //[TestMethod()] public void QpFromQ_ForNeg16Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 31), new Base(2)), 2, -16, 31, -1, 31);
    //[TestMethod()] public void QpFromQ_ForNeg16Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 51), new Base(2)), 2, -16, 51, -2, 51);
    //[TestMethod()] public void QpFromQ_ForNeg16Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 63), new Base(2)), 2, -16, 63, -2, 63);
    //[TestMethod()] public void QpFromQ_ForNeg16Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 73), new Base(2)), 2, -16, 73, -4, 73);
    //[TestMethod()] public void QpFromQ_ForNeg16Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 85), new Base(2)), 2, -16, 85, -4, 85);
    //[TestMethod()] public void QpFromQ_ForNeg16Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 127), new Base(2)), 2, -16, 127, -4, 127);
    //[TestMethod()] public void QpFromQ_ForNeg16Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 255), new Base(2)), 2, -16, 255, -8, 255);
    //[TestMethod()] public void QpFromQ_ForNeg16Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-16, 511), new Base(2)), 2, -16, 511, -16, 511);
    //[TestMethod()] public void QpFromQ_ForNeg17Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 5), new Base(2)), 2, -17, 5, -31, 40);
    //[TestMethod()] public void QpFromQ_For17Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 5), new Base(2)), 2, 17, 5, 29, 40);
    //[TestMethod()] public void QpFromQ_ForNeg17Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 7), new Base(2)), 2, -17, 7, -17, 28);
    //[TestMethod()] public void QpFromQ_For17Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 7), new Base(2)), 2, 17, 7, 25, 28);
    //[TestMethod()] public void QpFromQ_ForNeg17Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 10), new Base(2)), 2, -17, 10, -31, 20);
    //[TestMethod()] public void QpFromQ_For17Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 10), new Base(2)), 2, 17, 10, 29, 20);
    //[TestMethod()] public void QpFromQ_ForNeg17Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 14), new Base(2)), 2, -17, 14, -17, 14);
    //[TestMethod()] public void QpFromQ_For17Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 14), new Base(2)), 2, 17, 14, 25, 14);
    //[TestMethod()] public void QpFromQ_ForNeg17Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 15), new Base(2)), 2, -17, 15, -31, 60);
    //[TestMethod()] public void QpFromQ_For17Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 15), new Base(2)), 2, 17, 15, 59, 60);
    //[TestMethod()] public void QpFromQ_ForNeg17Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 20), new Base(2)), 2, -17, 20, -31, 10);
    //[TestMethod()] public void QpFromQ_For17Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 20), new Base(2)), 2, 17, 20, 29, 10);
    //[TestMethod()] public void QpFromQ_ForNeg17Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 21), new Base(2)), 2, -17, 21, -17, 21);
    //[TestMethod()] public void QpFromQ_For17Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 21), new Base(2)), 2, 17, 21, 29, 42);
    //[TestMethod()] public void QpFromQ_ForNeg17Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 28), new Base(2)), 2, -17, 28, -17, 7);
    //[TestMethod()] public void QpFromQ_For17Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 28), new Base(2)), 2, 17, 28, 25, 7);
    //[TestMethod()] public void QpFromQ_ForNeg17Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 30), new Base(2)), 2, -17, 30, -31, 30);
    //[TestMethod()] public void QpFromQ_For17Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 30), new Base(2)), 2, 17, 30, 59, 30);
    //[TestMethod()] public void QpFromQ_ForNeg17Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 31), new Base(2)), 2, -17, 31, -17, 31);
    //[TestMethod()] public void QpFromQ_For17Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 31), new Base(2)), 2, 17, 31, 59, 62);
    //[TestMethod()] public void QpFromQ_ForNeg17Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 42), new Base(2)), 2, -17, 42, -34, 21);
    //[TestMethod()] public void QpFromQ_For17Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 42), new Base(2)), 2, 17, 42, 29, 21);
    //[TestMethod()] public void QpFromQ_ForNeg17Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 60), new Base(2)), 2, -17, 60, -31, 15);
    //[TestMethod()] public void QpFromQ_For17Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 60), new Base(2)), 2, 17, 60, 59, 15);
    //[TestMethod()] public void QpFromQ_ForNeg17Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 62), new Base(2)), 2, -17, 62, -34, 31);
    //[TestMethod()] public void QpFromQ_For17Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 62), new Base(2)), 2, 17, 62, 59, 31);
    //[TestMethod()] public void QpFromQ_ForNeg17Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 63), new Base(2)), 2, -17, 63, -34, 63);
    //[TestMethod()] public void QpFromQ_ForNeg17Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 84), new Base(2)), 2, -17, 84, -68, 21);
    //[TestMethod()] public void QpFromQ_For17Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 84), new Base(2)), 2, 17, 84, 58, 21);
    //[TestMethod()] public void QpFromQ_ForNeg17Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 124), new Base(2)), 2, -17, 124, -68, 31);
    //[TestMethod()] public void QpFromQ_For17Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(17, 124), new Base(2)), 2, 17, 124, 118, 31);
    //[TestMethod()] public void QpFromQ_ForNeg17Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 126), new Base(2)), 2, -17, 126, -68, 63);
    //[TestMethod()] public void QpFromQ_ForNeg17Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 127), new Base(2)), 2, -17, 127, -68, 127);
    //[TestMethod()] public void QpFromQ_ForNeg17Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 252), new Base(2)), 2, -17, 252, -136, 63);
    //[TestMethod()] public void QpFromQ_ForNeg17Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 254), new Base(2)), 2, -17, 254, -136, 127);
    //[TestMethod()] public void QpFromQ_ForNeg17Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-17, 508), new Base(2)), 2, -17, 508, -272, 127);
    //[TestMethod()] public void QpFromQ_ForNeg18Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-18, 7), new Base(2)), 2, -18, 7, -15, 56);
    //[TestMethod()] public void QpFromQ_For18Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(18, 7), new Base(2)), 2, 18, 7, 27, 56);
    //[TestMethod()] public void QpFromQ_ForNeg18Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-18, 31), new Base(2)), 2, -18, 31, -9, 31);
    //[TestMethod()] public void QpFromQ_For18Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(18, 31), new Base(2)), 2, 18, 31, 57, 124);
    //[TestMethod()] public void QpFromQ_ForNeg18Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-18, 85), new Base(2)), 2, -18, 85, -36, 85);
    //[TestMethod()] public void QpFromQ_ForNeg18Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-18, 127), new Base(2)), 2, -18, 127, -36, 127);
    //[TestMethod()] public void QpFromQ_ForNeg19Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 5), new Base(2)), 2, -19, 5, -23, 40);
    //[TestMethod()] public void QpFromQ_For19Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 5), new Base(2)), 2, 19, 5, 37, 40);
    //[TestMethod()] public void QpFromQ_ForNeg19Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 7), new Base(2)), 2, -19, 7, -47, 56);
    //[TestMethod()] public void QpFromQ_For19Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 7), new Base(2)), 2, 19, 7, 37, 56);
    //[TestMethod()] public void QpFromQ_ForNeg19Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 9), new Base(2)), 2, -19, 9, -23, 36);
    //[TestMethod()] public void QpFromQ_For19Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 9), new Base(2)), 2, 19, 9, 31, 36);
    //[TestMethod()] public void QpFromQ_ForNeg19Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 10), new Base(2)), 2, -19, 10, -23, 20);
    //[TestMethod()] public void QpFromQ_For19Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 10), new Base(2)), 2, 19, 10, 37, 20);
    //[TestMethod()] public void QpFromQ_ForNeg19Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 14), new Base(2)), 2, -19, 14, -47, 28);
    //[TestMethod()] public void QpFromQ_For19Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 14), new Base(2)), 2, 19, 14, 37, 28);
    //[TestMethod()] public void QpFromQ_ForNeg19Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 15), new Base(2)), 2, -19, 15, -91, 120);
    //[TestMethod()] public void QpFromQ_For19Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 15), new Base(2)), 2, 19, 15, 89, 120);
    //[TestMethod()] public void QpFromQ_ForNeg19Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 18), new Base(2)), 2, -19, 18, -23, 18);
    //[TestMethod()] public void QpFromQ_For19Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 18), new Base(2)), 2, 19, 18, 31, 18);
    //[TestMethod()] public void QpFromQ_ForNeg19Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 20), new Base(2)), 2, -19, 20, -23, 10);
    //[TestMethod()] public void QpFromQ_For19Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 20), new Base(2)), 2, 19, 20, 37, 10);
    //[TestMethod()] public void QpFromQ_ForNeg19Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 21), new Base(2)), 2, -19, 21, -13, 21);
    //[TestMethod()] public void QpFromQ_For19Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 21), new Base(2)), 2, 19, 21, 37, 42);
    //[TestMethod()] public void QpFromQ_ForNeg19Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 28), new Base(2)), 2, -19, 28, -47, 14);
    //[TestMethod()] public void QpFromQ_For19Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 28), new Base(2)), 2, 19, 28, 37, 14);
    //[TestMethod()] public void QpFromQ_ForNeg19Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 30), new Base(2)), 2, -19, 30, -91, 60);
    //[TestMethod()] public void QpFromQ_For19Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 30), new Base(2)), 2, 19, 30, 89, 60);
    //[TestMethod()] public void QpFromQ_ForNeg19Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 31), new Base(2)), 2, -19, 31, -25, 31);
    //[TestMethod()] public void QpFromQ_For19Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 31), new Base(2)), 2, 19, 31, 43, 62);
    //[TestMethod()] public void QpFromQ_ForNeg19Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 36), new Base(2)), 2, -19, 36, -23, 9);
    //[TestMethod()] public void QpFromQ_For19Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 36), new Base(2)), 2, 19, 36, 31, 9);
    //[TestMethod()] public void QpFromQ_ForNeg19Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 42), new Base(2)), 2, -19, 42, -26, 21);
    //[TestMethod()] public void QpFromQ_For19Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 42), new Base(2)), 2, 19, 42, 37, 21);
    //[TestMethod()] public void QpFromQ_For19Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 51), new Base(2)), 2, 19, 51, 53, 102);
    //[TestMethod()] public void QpFromQ_ForNeg19Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 60), new Base(2)), 2, -19, 60, -91, 30);
    //[TestMethod()] public void QpFromQ_For19Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 60), new Base(2)), 2, 19, 60, 89, 30);
    //[TestMethod()] public void QpFromQ_ForNeg19Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 62), new Base(2)), 2, -19, 62, -50, 31);
    //[TestMethod()] public void QpFromQ_For19Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 62), new Base(2)), 2, 19, 62, 43, 31);
    //[TestMethod()] public void QpFromQ_ForNeg19Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 63), new Base(2)), 2, -19, 63, -50, 63);
    //[TestMethod()] public void QpFromQ_For19Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 63), new Base(2)), 2, 19, 63, 89, 126);
    //[TestMethod()] public void QpFromQ_ForNeg19Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 84), new Base(2)), 2, -19, 84, -52, 21);
    //[TestMethod()] public void QpFromQ_For19Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 84), new Base(2)), 2, 19, 84, 74, 21);
    //[TestMethod()] public void QpFromQ_For19Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 102), new Base(2)), 2, 19, 102, 53, 51);
    //[TestMethod()] public void QpFromQ_ForNeg19Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 124), new Base(2)), 2, -19, 124, -100, 31);
    //[TestMethod()] public void QpFromQ_For19Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 124), new Base(2)), 2, 19, 124, 86, 31);
    //[TestMethod()] public void QpFromQ_ForNeg19Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 126), new Base(2)), 2, -19, 126, -100, 63);
    //[TestMethod()] public void QpFromQ_For19Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 126), new Base(2)), 2, 19, 126, 89, 63);
    //[TestMethod()] public void QpFromQ_ForNeg19Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 127), new Base(2)), 2, -19, 127, -100, 127);
    //[TestMethod()] public void QpFromQ_For19Div204_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 204), new Base(2)), 2, 19, 204, 106, 51);
    //[TestMethod()] public void QpFromQ_ForNeg19Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 252), new Base(2)), 2, -19, 252, -200, 63);
    //[TestMethod()] public void QpFromQ_For19Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(19, 252), new Base(2)), 2, 19, 252, 178, 63);
    //[TestMethod()] public void QpFromQ_ForNeg19Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 254), new Base(2)), 2, -19, 254, -200, 127);
    //[TestMethod()] public void QpFromQ_ForNeg19Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-19, 508), new Base(2)), 2, -19, 508, -400, 127);
    //[TestMethod()] public void QpFromQ_ForNeg20Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 7), new Base(2)), 2, -20, 7, -5, 28);
    //[TestMethod()] public void QpFromQ_For20Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(20, 7), new Base(2)), 2, 20, 7, 11, 56);
    //[TestMethod()] public void QpFromQ_For20Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(20, 9), new Base(2)), 2, 20, 9, 13, 72);
    //[TestMethod()] public void QpFromQ_ForNeg20Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 21), new Base(2)), 2, -20, 21, -5, 21);
    //[TestMethod()] public void QpFromQ_For20Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(20, 21), new Base(2)), 2, 20, 21, 23, 168);
    //[TestMethod()] public void QpFromQ_ForNeg20Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 31), new Base(2)), 2, -20, 31, -5, 31);
    //[TestMethod()] public void QpFromQ_For20Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(20, 31), new Base(2)), 2, 20, 31, 53, 248);
    //[TestMethod()] public void QpFromQ_ForNeg20Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 51), new Base(2)), 2, -20, 51, -38, 255);
    //[TestMethod()] public void QpFromQ_ForNeg20Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 63), new Base(2)), 2, -20, 63, -10, 63);
    //[TestMethod()] public void QpFromQ_ForNeg20Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 73), new Base(2)), 2, -20, 73, -14, 73);
    //[TestMethod()] public void QpFromQ_ForNeg20Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 127), new Base(2)), 2, -20, 127, -20, 127);
    //[TestMethod()] public void QpFromQ_ForNeg20Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-20, 511), new Base(2)), 2, -20, 511, -80, 511);
    //[TestMethod()] public void QpFromQ_ForNeg21Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-21, 31), new Base(2)), 2, -21, 31, -21, 31);
    //[TestMethod()] public void QpFromQ_For21Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 31), new Base(2)), 2, 21, 31, 51, 62);
    //[TestMethod()] public void QpFromQ_ForNeg21Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-21, 62), new Base(2)), 2, -21, 62, -42, 31);
    //[TestMethod()] public void QpFromQ_For21Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 62), new Base(2)), 2, 21, 62, 51, 31);
    //[TestMethod()] public void QpFromQ_For21Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 85), new Base(2)), 2, 21, 85, 87, 170);
    //[TestMethod()] public void QpFromQ_ForNeg21Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-21, 124), new Base(2)), 2, -21, 124, -84, 31);
    //[TestMethod()] public void QpFromQ_For21Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 124), new Base(2)), 2, 21, 124, 102, 31);
    //[TestMethod()] public void QpFromQ_ForNeg21Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-21, 127), new Base(2)), 2, -21, 127, -84, 127);
    //[TestMethod()] public void QpFromQ_For21Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 127), new Base(2)), 2, 21, 127, 213, 254);
    //[TestMethod()] public void QpFromQ_For21Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 170), new Base(2)), 2, 21, 170, 87, 85);
    //[TestMethod()] public void QpFromQ_For21Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 254), new Base(2)), 2, 21, 254, 213, 127);
    //[TestMethod()] public void QpFromQ_For21Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 340), new Base(2)), 2, 21, 340, 174, 85);
    //[TestMethod()] public void QpFromQ_For21Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(21, 508), new Base(2)), 2, 21, 508, 426, 127);
    //[TestMethod()] public void QpFromQ_ForNeg22Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 5), new Base(2)), 2, -22, 5, -11, 40);
    //[TestMethod()] public void QpFromQ_For22Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(22, 5), new Base(2)), 2, 22, 5, 19, 40);
    //[TestMethod()] public void QpFromQ_For22Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(22, 9), new Base(2)), 2, 22, 9, 29, 72);
    //[TestMethod()] public void QpFromQ_ForNeg22Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 15), new Base(2)), 2, -22, 15, -13, 30);
    //[TestMethod()] public void QpFromQ_For22Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(22, 15), new Base(2)), 2, 22, 15, 19, 60);
    //[TestMethod()] public void QpFromQ_ForNeg22Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 21), new Base(2)), 2, -22, 21, -11, 42);
    //[TestMethod()] public void QpFromQ_ForNeg22Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 31), new Base(2)), 2, -22, 31, -13, 31);
    //[TestMethod()] public void QpFromQ_For22Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(22, 31), new Base(2)), 2, 22, 31, 41, 124);
    //[TestMethod()] public void QpFromQ_ForNeg22Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 63), new Base(2)), 2, -22, 63, -26, 63);
    //[TestMethod()] public void QpFromQ_For22Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(22, 63), new Base(2)), 2, 22, 63, 85, 252);
    //[TestMethod()] public void QpFromQ_ForNeg22Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 73), new Base(2)), 2, -22, 73, -178, 511);
    //[TestMethod()] public void QpFromQ_ForNeg22Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 127), new Base(2)), 2, -22, 127, -52, 127);
    //[TestMethod()] public void QpFromQ_ForNeg22Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-22, 255), new Base(2)), 2, -22, 255, -104, 255);
    //[TestMethod()] public void QpFromQ_ForNeg23Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 9), new Base(2)), 2, -23, 9, -19, 36);
    //[TestMethod()] public void QpFromQ_ForNeg23Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 18), new Base(2)), 2, -23, 18, -19, 18);
    //[TestMethod()] public void QpFromQ_ForNeg23Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 21), new Base(2)), 2, -23, 21, -53, 84);
    //[TestMethod()] public void QpFromQ_For23Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 21), new Base(2)), 2, 23, 21, 73, 84);
    //[TestMethod()] public void QpFromQ_ForNeg23Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 31), new Base(2)), 2, -23, 31, -29, 31);
    //[TestMethod()] public void QpFromQ_For23Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 31), new Base(2)), 2, 23, 31, 35, 62);
    //[TestMethod()] public void QpFromQ_ForNeg23Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 36), new Base(2)), 2, -23, 36, -19, 9);
    //[TestMethod()] public void QpFromQ_ForNeg23Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 42), new Base(2)), 2, -23, 42, -53, 42);
    //[TestMethod()] public void QpFromQ_For23Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 42), new Base(2)), 2, 23, 42, 73, 42);
    //[TestMethod()] public void QpFromQ_For23Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 51), new Base(2)), 2, 23, 51, 353, 510);
    //[TestMethod()] public void QpFromQ_ForNeg23Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 62), new Base(2)), 2, -23, 62, -58, 31);
    //[TestMethod()] public void QpFromQ_For23Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 62), new Base(2)), 2, 23, 62, 35, 31);
    //[TestMethod()] public void QpFromQ_ForNeg23Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 63), new Base(2)), 2, -23, 63, -58, 63);
    //[TestMethod()] public void QpFromQ_For23Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 63), new Base(2)), 2, 23, 63, 73, 126);
    //[TestMethod()] public void QpFromQ_ForNeg23Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 84), new Base(2)), 2, -23, 84, -53, 21);
    //[TestMethod()] public void QpFromQ_For23Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 84), new Base(2)), 2, 23, 84, 73, 21);
    //[TestMethod()] public void QpFromQ_For23Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 102), new Base(2)), 2, 23, 102, 353, 255);
    //[TestMethod()] public void QpFromQ_ForNeg23Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 124), new Base(2)), 2, -23, 124, -116, 31);
    //[TestMethod()] public void QpFromQ_For23Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 124), new Base(2)), 2, 23, 124, 70, 31);
    //[TestMethod()] public void QpFromQ_ForNeg23Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 126), new Base(2)), 2, -23, 126, -116, 63);
    //[TestMethod()] public void QpFromQ_For23Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 126), new Base(2)), 2, 23, 126, 73, 63);
    //[TestMethod()] public void QpFromQ_ForNeg23Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 127), new Base(2)), 2, -23, 127, -116, 127);
    //[TestMethod()] public void QpFromQ_For23Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 127), new Base(2)), 2, 23, 127, 149, 254);
    //[TestMethod()] public void QpFromQ_For23Div204_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 204), new Base(2)), 2, 23, 204, 706, 255);
    //[TestMethod()] public void QpFromQ_ForNeg23Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-23, 252), new Base(2)), 2, -23, 252, -232, 63);
    //[TestMethod()] public void QpFromQ_For23Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 252), new Base(2)), 2, 23, 252, 146, 63);
    //[TestMethod()] public void QpFromQ_For23Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 254), new Base(2)), 2, 23, 254, 149, 127);
    //[TestMethod()] public void QpFromQ_For23Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(23, 508), new Base(2)), 2, 23, 508, 298, 127);
    //[TestMethod()] public void QpFromQ_ForNeg24Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 5), new Base(2)), 2, -24, 5, -3, 40);
    //[TestMethod()] public void QpFromQ_ForNeg24Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 7), new Base(2)), 2, -24, 7, -3, 28);
    //[TestMethod()] public void QpFromQ_ForNeg24Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 31), new Base(2)), 2, -24, 31, -3, 31);
    //[TestMethod()] public void QpFromQ_ForNeg24Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 73), new Base(2)), 2, -24, 73, -6, 73);
    //[TestMethod()] public void QpFromQ_ForNeg24Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 85), new Base(2)), 2, -24, 85, -6, 85);
    //[TestMethod()] public void QpFromQ_ForNeg24Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 127), new Base(2)), 2, -24, 127, -12, 127);
    //[TestMethod()] public void QpFromQ_ForNeg24Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-24, 511), new Base(2)), 2, -24, 511, -48, 511);
    //[TestMethod()] public void QpFromQ_ForNeg25Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 7), new Base(2)), 2, -25, 7, -29, 56);
    //[TestMethod()] public void QpFromQ_For25Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 7), new Base(2)), 2, 25, 7, 55, 56);
    //[TestMethod()] public void QpFromQ_ForNeg25Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 14), new Base(2)), 2, -25, 14, -29, 28);
    //[TestMethod()] public void QpFromQ_For25Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 14), new Base(2)), 2, 25, 14, 55, 28);
    //[TestMethod()] public void QpFromQ_For25Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 21), new Base(2)), 2, 25, 21, 115, 168);
    //[TestMethod()] public void QpFromQ_ForNeg25Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 28), new Base(2)), 2, -25, 28, -29, 14);
    //[TestMethod()] public void QpFromQ_For25Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 28), new Base(2)), 2, 25, 28, 55, 14);
    //[TestMethod()] public void QpFromQ_ForNeg25Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 31), new Base(2)), 2, -25, 31, -19, 31);
    //[TestMethod()] public void QpFromQ_For25Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 31), new Base(2)), 2, 25, 31, 55, 62);
    //[TestMethod()] public void QpFromQ_For25Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 42), new Base(2)), 2, 25, 42, 115, 84);
    //[TestMethod()] public void QpFromQ_ForNeg25Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 51), new Base(2)), 2, -25, 51, -38, 51);
    //[TestMethod()] public void QpFromQ_ForNeg25Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 62), new Base(2)), 2, -25, 62, -38, 31);
    //[TestMethod()] public void QpFromQ_For25Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 62), new Base(2)), 2, 25, 62, 55, 31);
    //[TestMethod()] public void QpFromQ_ForNeg25Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 63), new Base(2)), 2, -25, 63, -38, 63);
    //[TestMethod()] public void QpFromQ_For25Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 63), new Base(2)), 2, 25, 63, 113, 126);
    //[TestMethod()] public void QpFromQ_For25Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 84), new Base(2)), 2, 25, 84, 115, 42);
    //[TestMethod()] public void QpFromQ_ForNeg25Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 102), new Base(2)), 2, -25, 102, -76, 51);
    //[TestMethod()] public void QpFromQ_ForNeg25Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 124), new Base(2)), 2, -25, 124, -76, 31);
    //[TestMethod()] public void QpFromQ_For25Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 124), new Base(2)), 2, 25, 124, 110, 31);
    //[TestMethod()] public void QpFromQ_ForNeg25Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 126), new Base(2)), 2, -25, 126, -76, 63);
    //[TestMethod()] public void QpFromQ_For25Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 126), new Base(2)), 2, 25, 126, 113, 63);
    //[TestMethod()] public void QpFromQ_ForNeg25Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 127), new Base(2)), 2, -25, 127, -76, 127);
    //[TestMethod()] public void QpFromQ_ForNeg25Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 252), new Base(2)), 2, -25, 252, -152, 63);
    //[TestMethod()] public void QpFromQ_For25Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(25, 252), new Base(2)), 2, 25, 252, 226, 63);
    //[TestMethod()] public void QpFromQ_ForNeg25Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 254), new Base(2)), 2, -25, 254, -152, 127);
    //[TestMethod()] public void QpFromQ_ForNeg25Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-25, 508), new Base(2)), 2, -25, 508, -304, 127);
    //[TestMethod()] public void QpFromQ_ForNeg26Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 7), new Base(2)), 2, -26, 7, -19, 56);
    //[TestMethod()] public void QpFromQ_For26Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(26, 7), new Base(2)), 2, 26, 7, 23, 56);
    //[TestMethod()] public void QpFromQ_ForNeg26Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 15), new Base(2)), 2, -26, 15, -11, 30);
    //[TestMethod()] public void QpFromQ_For26Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(26, 15), new Base(2)), 2, 26, 15, 23, 60);
    //[TestMethod()] public void QpFromQ_For26Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(26, 21), new Base(2)), 2, 26, 21, 25, 84);
    //[TestMethod()] public void QpFromQ_ForNeg26Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 31), new Base(2)), 2, -26, 31, -11, 31);
    //[TestMethod()] public void QpFromQ_For26Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(26, 31), new Base(2)), 2, 26, 31, 49, 124);
    //[TestMethod()] public void QpFromQ_ForNeg26Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 63), new Base(2)), 2, -26, 63, -22, 63);
    //[TestMethod()] public void QpFromQ_For26Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(26, 63), new Base(2)), 2, 26, 63, 101, 252);
    //[TestMethod()] public void QpFromQ_ForNeg26Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 127), new Base(2)), 2, -26, 127, -44, 127);
    //[TestMethod()] public void QpFromQ_ForNeg26Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 255), new Base(2)), 2, -26, 255, -88, 255);
    //[TestMethod()] public void QpFromQ_ForNeg26Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-26, 511), new Base(2)), 2, -26, 511, -176, 511);
    //[TestMethod()] public void QpFromQ_ForNeg27Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 5), new Base(2)), 2, -27, 5, -21, 40);
    //[TestMethod()] public void QpFromQ_For27Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 5), new Base(2)), 2, 27, 5, 39, 40);
    //[TestMethod()] public void QpFromQ_ForNeg27Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 7), new Base(2)), 2, -27, 7, -45, 56);
    //[TestMethod()] public void QpFromQ_For27Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 7), new Base(2)), 2, 27, 7, 39, 56);
    //[TestMethod()] public void QpFromQ_ForNeg27Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 10), new Base(2)), 2, -27, 10, -21, 20);
    //[TestMethod()] public void QpFromQ_For27Div10_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 10), new Base(2)), 2, 27, 10, 39, 20);
    //[TestMethod()] public void QpFromQ_ForNeg27Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 14), new Base(2)), 2, -27, 14, -45, 28);
    //[TestMethod()] public void QpFromQ_For27Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 14), new Base(2)), 2, 27, 14, 39, 28);
    //[TestMethod()] public void QpFromQ_ForNeg27Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 20), new Base(2)), 2, -27, 20, -21, 10);
    //[TestMethod()] public void QpFromQ_For27Div20_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 20), new Base(2)), 2, 27, 20, 39, 10);
    //[TestMethod()] public void QpFromQ_ForNeg27Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 28), new Base(2)), 2, -27, 28, -45, 14);
    //[TestMethod()] public void QpFromQ_For27Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 28), new Base(2)), 2, 27, 28, 39, 14);
    //[TestMethod()] public void QpFromQ_ForNeg27Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 31), new Base(2)), 2, -27, 31, -27, 31);
    //[TestMethod()] public void QpFromQ_For27Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 31), new Base(2)), 2, 27, 31, 39, 62);
    //[TestMethod()] public void QpFromQ_ForNeg27Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 62), new Base(2)), 2, -27, 62, -54, 31);
    //[TestMethod()] public void QpFromQ_For27Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 62), new Base(2)), 2, 27, 62, 39, 31);
    //[TestMethod()] public void QpFromQ_ForNeg27Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 85), new Base(2)), 2, -27, 85, -46, 85);
    //[TestMethod()] public void QpFromQ_ForNeg27Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 124), new Base(2)), 2, -27, 124, -108, 31);
    //[TestMethod()] public void QpFromQ_For27Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(27, 124), new Base(2)), 2, 27, 124, 78, 31);
    //[TestMethod()] public void QpFromQ_ForNeg27Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 127), new Base(2)), 2, -27, 127, -108, 127);
    //[TestMethod()] public void QpFromQ_ForNeg27Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 170), new Base(2)), 2, -27, 170, -92, 85);
    //[TestMethod()] public void QpFromQ_ForNeg27Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 254), new Base(2)), 2, -27, 254, -216, 127);
    //[TestMethod()] public void QpFromQ_ForNeg27Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 340), new Base(2)), 2, -27, 340, -184, 85);
    //[TestMethod()] public void QpFromQ_ForNeg27Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-27, 508), new Base(2)), 2, -27, 508, -432, 127);
    //[TestMethod()] public void QpFromQ_ForNeg28Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 9), new Base(2)), 2, -28, 9, -5, 36);
    //[TestMethod()] public void QpFromQ_ForNeg28Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 15), new Base(2)), 2, -28, 15, -7, 30);
    //[TestMethod()] public void QpFromQ_For28Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(28, 15), new Base(2)), 2, 28, 15, 17, 120);
    //[TestMethod()] public void QpFromQ_ForNeg28Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 31), new Base(2)), 2, -28, 31, -7, 31);
    //[TestMethod()] public void QpFromQ_For28Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(28, 31), new Base(2)), 2, 28, 31, 37, 248);
    //[TestMethod()] public void QpFromQ_ForNeg28Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 51), new Base(2)), 2, -28, 51, -49, 255);
    //[TestMethod()] public void QpFromQ_ForNeg28Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 85), new Base(2)), 2, -28, 85, -14, 85);
    //[TestMethod()] public void QpFromQ_ForNeg28Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 127), new Base(2)), 2, -28, 127, -28, 127);
    //[TestMethod()] public void QpFromQ_ForNeg28Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-28, 255), new Base(2)), 2, -28, 255, -56, 255);
    //[TestMethod()] public void QpFromQ_For29Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 9), new Base(2)), 2, 29, 9, 49, 72);
    //[TestMethod()] public void QpFromQ_ForNeg29Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 15), new Base(2)), 2, -29, 15, -43, 60);
    //[TestMethod()] public void QpFromQ_For29Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 15), new Base(2)), 2, 29, 15, 47, 60);
    //[TestMethod()] public void QpFromQ_For29Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 18), new Base(2)), 2, 29, 18, 49, 36);
    //[TestMethod()] public void QpFromQ_ForNeg29Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 30), new Base(2)), 2, -29, 30, -43, 30);
    //[TestMethod()] public void QpFromQ_For29Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 30), new Base(2)), 2, 29, 30, 47, 30);
    //[TestMethod()] public void QpFromQ_ForNeg29Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 31), new Base(2)), 2, -29, 31, -23, 31);
    //[TestMethod()] public void QpFromQ_For29Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 31), new Base(2)), 2, 29, 31, 47, 62);
    //[TestMethod()] public void QpFromQ_For29Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 36), new Base(2)), 2, 29, 36, 49, 18);
    //[TestMethod()] public void QpFromQ_ForNeg29Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 51), new Base(2)), 2, -29, 51, -137, 255);
    //[TestMethod()] public void QpFromQ_ForNeg29Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 60), new Base(2)), 2, -29, 60, -43, 15);
    //[TestMethod()] public void QpFromQ_For29Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 60), new Base(2)), 2, 29, 60, 47, 15);
    //[TestMethod()] public void QpFromQ_ForNeg29Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 62), new Base(2)), 2, -29, 62, -46, 31);
    //[TestMethod()] public void QpFromQ_For29Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 62), new Base(2)), 2, 29, 62, 47, 31);
    //[TestMethod()] public void QpFromQ_ForNeg29Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 63), new Base(2)), 2, -29, 63, -46, 63);
    //[TestMethod()] public void QpFromQ_For29Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 63), new Base(2)), 2, 29, 63, 97, 126);
    //[TestMethod()] public void QpFromQ_ForNeg29Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 102), new Base(2)), 2, -29, 102, -274, 255);
    //[TestMethod()] public void QpFromQ_ForNeg29Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 124), new Base(2)), 2, -29, 124, -92, 31);
    //[TestMethod()] public void QpFromQ_For29Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 124), new Base(2)), 2, 29, 124, 94, 31);
    //[TestMethod()] public void QpFromQ_ForNeg29Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 126), new Base(2)), 2, -29, 126, -92, 63);
    //[TestMethod()] public void QpFromQ_For29Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 126), new Base(2)), 2, 29, 126, 97, 63);
    //[TestMethod()] public void QpFromQ_ForNeg29Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 127), new Base(2)), 2, -29, 127, -92, 127);
    //[TestMethod()] public void QpFromQ_For29Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 127), new Base(2)), 2, 29, 127, 197, 254);
    //[TestMethod()] public void QpFromQ_ForNeg29Div204_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 204), new Base(2)), 2, -29, 204, -548, 255);
    //[TestMethod()] public void QpFromQ_ForNeg29Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 252), new Base(2)), 2, -29, 252, -184, 63);
    //[TestMethod()] public void QpFromQ_For29Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 252), new Base(2)), 2, 29, 252, 194, 63);
    //[TestMethod()] public void QpFromQ_ForNeg29Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 254), new Base(2)), 2, -29, 254, -184, 127);
    //[TestMethod()] public void QpFromQ_For29Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 254), new Base(2)), 2, 29, 254, 197, 127);
    //[TestMethod()] public void QpFromQ_ForNeg29Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 255), new Base(2)), 2, -29, 255, -184, 255);
    //[TestMethod()] public void QpFromQ_ForNeg29Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 508), new Base(2)), 2, -29, 508, -368, 127);
    //[TestMethod()] public void QpFromQ_For29Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(29, 508), new Base(2)), 2, 29, 508, 394, 127);
    //[TestMethod()] public void QpFromQ_ForNeg29Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 510), new Base(2)), 2, -29, 510, -368, 255);
    //[TestMethod()] public void QpFromQ_ForNeg29Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-29, 511), new Base(2)), 2, -29, 511, -368, 511);
    //[TestMethod()] public void QpFromQ_ForNeg30Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-30, 31), new Base(2)), 2, -30, 31, -15, 31);
    //[TestMethod()] public void QpFromQ_For30Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(30, 31), new Base(2)), 2, 30, 31, 33, 124);
    //[TestMethod()] public void QpFromQ_ForNeg30Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-30, 127), new Base(2)), 2, -30, 127, -60, 127);
    //[TestMethod()] public void QpFromQ_For30Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(30, 127), new Base(2)), 2, 30, 127, 141, 508);
    //[TestMethod()] public void QpFromQ_For31Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 9), new Base(2)), 2, 31, 9, 65, 72);
    //[TestMethod()] public void QpFromQ_For31Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 18), new Base(2)), 2, 31, 18, 65, 36);
    //[TestMethod()] public void QpFromQ_For31Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 21), new Base(2)), 2, 31, 21, 65, 84);
    //[TestMethod()] public void QpFromQ_For31Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 36), new Base(2)), 2, 31, 36, 65, 18);
    //[TestMethod()] public void QpFromQ_For31Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 42), new Base(2)), 2, 31, 42, 65, 42);
    //[TestMethod()] public void QpFromQ_For31Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 63), new Base(2)), 2, 31, 63, 65, 126);
    //[TestMethod()] public void QpFromQ_For31Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 84), new Base(2)), 2, 31, 84, 65, 21);
    //[TestMethod()] public void QpFromQ_ForNeg31Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-31, 85), new Base(2)), 2, -31, 85, -62, 85);
    //[TestMethod()] public void QpFromQ_For31Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 126), new Base(2)), 2, 31, 126, 65, 63);
    //[TestMethod()] public void QpFromQ_For31Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 127), new Base(2)), 2, 31, 127, 133, 254);
    //[TestMethod()] public void QpFromQ_ForNeg31Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-31, 170), new Base(2)), 2, -31, 170, -124, 85);
    //[TestMethod()] public void QpFromQ_For31Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 252), new Base(2)), 2, 31, 252, 130, 63);
    //[TestMethod()] public void QpFromQ_For31Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 254), new Base(2)), 2, 31, 254, 133, 127);
    //[TestMethod()] public void QpFromQ_For31Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 255), new Base(2)), 2, 31, 255, 269, 510);
    //[TestMethod()] public void QpFromQ_For31Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 508), new Base(2)), 2, 31, 508, 266, 127);
    //[TestMethod()] public void QpFromQ_For31Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 510), new Base(2)), 2, 31, 510, 269, 255);
    //[TestMethod()] public void QpFromQ_For31Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(31, 1020), new Base(2)), 2, 31, 1020, 538, 255);
    //[TestMethod()] public void QpFromQ_ForNeg32Div5_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 5), new Base(2)), 2, -32, 5, -1, 40);
    //[TestMethod()] public void QpFromQ_ForNeg32Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 7), new Base(2)), 2, -32, 7, -1, 56);
    //[TestMethod()] public void QpFromQ_ForNeg32Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 9), new Base(2)), 2, -32, 9, -1, 36);
    //[TestMethod()] public void QpFromQ_ForNeg32Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 15), new Base(2)), 2, -32, 15, -1, 60);
    //[TestMethod()] public void QpFromQ_ForNeg32Div17_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 17), new Base(2)), 2, -32, 17, -1, 34);
    //[TestMethod()] public void QpFromQ_ForNeg32Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 21), new Base(2)), 2, -32, 21, -1, 42);
    //[TestMethod()] public void QpFromQ_ForNeg32Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 31), new Base(2)), 2, -32, 31, -1, 62);
    //[TestMethod()] public void QpFromQ_ForNeg32Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 51), new Base(2)), 2, -32, 51, -1, 51);
    //[TestMethod()] public void QpFromQ_ForNeg32Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 63), new Base(2)), 2, -32, 63, -1, 63);
    //[TestMethod()] public void QpFromQ_ForNeg32Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 73), new Base(2)), 2, -32, 73, -2, 73);
    //[TestMethod()] public void QpFromQ_ForNeg32Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 85), new Base(2)), 2, -32, 85, -2, 85);
    //[TestMethod()] public void QpFromQ_ForNeg32Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 127), new Base(2)), 2, -32, 127, -2, 127);
    //[TestMethod()] public void QpFromQ_ForNeg32Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 255), new Base(2)), 2, -32, 255, -4, 255);
    //[TestMethod()] public void QpFromQ_ForNeg32Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-32, 511), new Base(2)), 2, -32, 511, -8, 511);
    //[TestMethod()] public void QpFromQ_ForNeg33Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 7), new Base(2)), 2, -33, 7, -33, 56);
    //[TestMethod()] public void QpFromQ_For33Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(33, 7), new Base(2)), 2, 33, 7, 51, 56);
    //[TestMethod()] public void QpFromQ_ForNeg33Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 14), new Base(2)), 2, -33, 14, -33, 28);
    //[TestMethod()] public void QpFromQ_For33Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(33, 14), new Base(2)), 2, 33, 14, 51, 28);
    //[TestMethod()] public void QpFromQ_ForNeg33Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 28), new Base(2)), 2, -33, 28, -33, 14);
    //[TestMethod()] public void QpFromQ_For33Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(33, 28), new Base(2)), 2, 33, 28, 51, 14);
    //[TestMethod()] public void QpFromQ_ForNeg33Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 31), new Base(2)), 2, -33, 31, -63, 124);
    //[TestMethod()] public void QpFromQ_For33Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(33, 31), new Base(2)), 2, 33, 31, 123, 124);
    //[TestMethod()] public void QpFromQ_ForNeg33Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 62), new Base(2)), 2, -33, 62, -63, 62);
    //[TestMethod()] public void QpFromQ_For33Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(33, 62), new Base(2)), 2, 33, 62, 123, 62);
    //[TestMethod()] public void QpFromQ_ForNeg33Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 85), new Base(2)), 2, -33, 85, -66, 85);
    //[TestMethod()] public void QpFromQ_ForNeg33Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 124), new Base(2)), 2, -33, 124, -63, 31);
    //[TestMethod()] public void QpFromQ_For33Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(33, 124), new Base(2)), 2, 33, 124, 123, 31);
    //[TestMethod()] public void QpFromQ_ForNeg33Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 127), new Base(2)), 2, -33, 127, -66, 127);
    //[TestMethod()] public void QpFromQ_ForNeg33Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 170), new Base(2)), 2, -33, 170, -132, 85);
    //[TestMethod()] public void QpFromQ_ForNeg33Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 254), new Base(2)), 2, -33, 254, -132, 127);
    //[TestMethod()] public void QpFromQ_ForNeg33Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-33, 508), new Base(2)), 2, -33, 508, -264, 127);
    //[TestMethod()] public void QpFromQ_ForNeg34Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-34, 7), new Base(2)), 2, -34, 7, -17, 56);
    //[TestMethod()] public void QpFromQ_For34Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(34, 7), new Base(2)), 2, 34, 7, 25, 56);
    //[TestMethod()] public void QpFromQ_ForNeg34Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-34, 15), new Base(2)), 2, -34, 15, -31, 120);
    //[TestMethod()] public void QpFromQ_For34Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(34, 15), new Base(2)), 2, 34, 15, 59, 120);
    //[TestMethod()] public void QpFromQ_ForNeg34Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-34, 21), new Base(2)), 2, -34, 21, -17, 42);
    //[TestMethod()] public void QpFromQ_For34Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(34, 21), new Base(2)), 2, 34, 21, 29, 84);
    //[TestMethod()] public void QpFromQ_ForNeg34Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-34, 31), new Base(2)), 2, -34, 31, -17, 62);
    //[TestMethod()] public void QpFromQ_For34Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(34, 31), new Base(2)), 2, 34, 31, 59, 124);
    //[TestMethod()] public void QpFromQ_ForNeg34Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-34, 63), new Base(2)), 2, -34, 63, -17, 63);
    //[TestMethod()] public void QpFromQ_ForNeg34Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-34, 127), new Base(2)), 2, -34, 127, -34, 127);
    //[TestMethod()] public void QpFromQ_ForNeg35Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-35, 31), new Base(2)), 2, -35, 31, -187, 248);
    //[TestMethod()] public void QpFromQ_For35Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(35, 31), new Base(2)), 2, 35, 31, 185, 248);
    //[TestMethod()] public void QpFromQ_For35Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(35, 51), new Base(2)), 2, 35, 51, 55, 102);
    //[TestMethod()] public void QpFromQ_ForNeg35Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-35, 62), new Base(2)), 2, -35, 62, -187, 124);
    //[TestMethod()] public void QpFromQ_For35Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(35, 62), new Base(2)), 2, 35, 62, 185, 124);
    //[TestMethod()] public void QpFromQ_For35Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(35, 102), new Base(2)), 2, 35, 102, 55, 51);
    //[TestMethod()] public void QpFromQ_ForNeg35Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-35, 124), new Base(2)), 2, -35, 124, -187, 62);
    //[TestMethod()] public void QpFromQ_For35Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(35, 124), new Base(2)), 2, 35, 124, 185, 62);
    //[TestMethod()] public void QpFromQ_ForNeg35Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-35, 127), new Base(2)), 2, -35, 127, -98, 127);
    //[TestMethod()] public void QpFromQ_For35Div204_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(35, 204), new Base(2)), 2, 35, 204, 110, 51);
    //[TestMethod()] public void QpFromQ_ForNeg35Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-35, 254), new Base(2)), 2, -35, 254, -196, 127);
    //[TestMethod()] public void QpFromQ_ForNeg35Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-35, 508), new Base(2)), 2, -35, 508, -392, 127);
    //[TestMethod()] public void QpFromQ_ForNeg36Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-36, 31), new Base(2)), 2, -36, 31, -9, 62);
    //[TestMethod()] public void QpFromQ_For36Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(36, 31), new Base(2)), 2, 36, 31, 57, 248);
    //[TestMethod()] public void QpFromQ_ForNeg36Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-36, 85), new Base(2)), 2, -36, 85, -18, 85);
    //[TestMethod()] public void QpFromQ_ForNeg36Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-36, 127), new Base(2)), 2, -36, 127, -18, 127);
    //[TestMethod()] public void QpFromQ_ForNeg36Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-36, 511), new Base(2)), 2, -36, 511, -72, 511);
    //[TestMethod()] public void QpFromQ_ForNeg37Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 9), new Base(2)), 2, -37, 9, -55, 72);
    //[TestMethod()] public void QpFromQ_ForNeg37Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 15), new Base(2)), 2, -37, 15, -41, 60);
    //[TestMethod()] public void QpFromQ_For37Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 15), new Base(2)), 2, 37, 15, 49, 60);
    //[TestMethod()] public void QpFromQ_ForNeg37Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 18), new Base(2)), 2, -37, 18, -55, 36);
    //[TestMethod()] public void QpFromQ_ForNeg37Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 30), new Base(2)), 2, -37, 30, -41, 30);
    //[TestMethod()] public void QpFromQ_For37Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 30), new Base(2)), 2, 37, 30, 49, 30);
    //[TestMethod()] public void QpFromQ_ForNeg37Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 31), new Base(2)), 2, -37, 31, -79, 124);
    //[TestMethod()] public void QpFromQ_For37Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 31), new Base(2)), 2, 37, 31, 107, 124);
    //[TestMethod()] public void QpFromQ_ForNeg37Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 36), new Base(2)), 2, -37, 36, -55, 18);
    //[TestMethod()] public void QpFromQ_ForNeg37Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 60), new Base(2)), 2, -37, 60, -41, 15);
    //[TestMethod()] public void QpFromQ_For37Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 60), new Base(2)), 2, 37, 60, 49, 15);
    //[TestMethod()] public void QpFromQ_ForNeg37Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 62), new Base(2)), 2, -37, 62, -79, 62);
    //[TestMethod()] public void QpFromQ_For37Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 62), new Base(2)), 2, 37, 62, 107, 62);
    //[TestMethod()] public void QpFromQ_ForNeg37Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 63), new Base(2)), 2, -37, 63, -41, 63);
    //[TestMethod()] public void QpFromQ_For37Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 63), new Base(2)), 2, 37, 63, 107, 126);
    //[TestMethod()] public void QpFromQ_For37Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 85), new Base(2)), 2, 37, 85, 91, 170);
    //[TestMethod()] public void QpFromQ_ForNeg37Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 124), new Base(2)), 2, -37, 124, -79, 31);
    //[TestMethod()] public void QpFromQ_For37Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 124), new Base(2)), 2, 37, 124, 107, 31);
    //[TestMethod()] public void QpFromQ_ForNeg37Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 126), new Base(2)), 2, -37, 126, -82, 63);
    //[TestMethod()] public void QpFromQ_For37Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 126), new Base(2)), 2, 37, 126, 107, 63);
    //[TestMethod()] public void QpFromQ_For37Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 127), new Base(2)), 2, 37, 127, 217, 254);
    //[TestMethod()] public void QpFromQ_For37Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 170), new Base(2)), 2, 37, 170, 91, 85);
    //[TestMethod()] public void QpFromQ_ForNeg37Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-37, 252), new Base(2)), 2, -37, 252, -164, 63);
    //[TestMethod()] public void QpFromQ_For37Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 252), new Base(2)), 2, 37, 252, 214, 63);
    //[TestMethod()] public void QpFromQ_For37Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 254), new Base(2)), 2, 37, 254, 217, 127);
    //[TestMethod()] public void QpFromQ_For37Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 340), new Base(2)), 2, 37, 340, 182, 85);
    //[TestMethod()] public void QpFromQ_For37Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(37, 508), new Base(2)), 2, 37, 508, 434, 127);
    //[TestMethod()] public void QpFromQ_For38Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(38, 9), new Base(2)), 2, 38, 9, 31, 72);
    //[TestMethod()] public void QpFromQ_ForNeg38Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-38, 21), new Base(2)), 2, -38, 21, -13, 42);
    //[TestMethod()] public void QpFromQ_ForNeg38Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-38, 31), new Base(2)), 2, -38, 31, -25, 62);
    //[TestMethod()] public void QpFromQ_For38Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(38, 31), new Base(2)), 2, 38, 31, 43, 124);
    //[TestMethod()] public void QpFromQ_ForNeg38Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-38, 63), new Base(2)), 2, -38, 63, -25, 63);
    //[TestMethod()] public void QpFromQ_For38Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(38, 63), new Base(2)), 2, 38, 63, 89, 252);
    //[TestMethod()] public void QpFromQ_ForNeg38Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-38, 127), new Base(2)), 2, -38, 127, -50, 127);
    //[TestMethod()] public void QpFromQ_ForNeg38Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-38, 255), new Base(2)), 2, -38, 255, -20, 51);
    //[TestMethod()] public void QpFromQ_ForNeg39Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-39, 85), new Base(2)), 2, -39, 85, -58, 85);
    //[TestMethod()] public void QpFromQ_For39Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(39, 127), new Base(2)), 2, 39, 127, 153, 254);
    //[TestMethod()] public void QpFromQ_ForNeg39Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-39, 170), new Base(2)), 2, -39, 170, -116, 85);
    //[TestMethod()] public void QpFromQ_For39Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(39, 254), new Base(2)), 2, 39, 254, 153, 127);
    //[TestMethod()] public void QpFromQ_ForNeg39Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-39, 340), new Base(2)), 2, -39, 340, -232, 85);
    //[TestMethod()] public void QpFromQ_For39Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(39, 508), new Base(2)), 2, 39, 508, 306, 127);
    //[TestMethod()] public void QpFromQ_ForNeg40Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 7), new Base(2)), 2, -40, 7, -5, 56);
    //[TestMethod()] public void QpFromQ_ForNeg40Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 21), new Base(2)), 2, -40, 21, -5, 42);
    //[TestMethod()] public void QpFromQ_ForNeg40Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 31), new Base(2)), 2, -40, 31, -5, 62);
    //[TestMethod()] public void QpFromQ_ForNeg40Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 51), new Base(2)), 2, -40, 51, -19, 255);
    //[TestMethod()] public void QpFromQ_ForNeg40Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 63), new Base(2)), 2, -40, 63, -5, 63);
    //[TestMethod()] public void QpFromQ_ForNeg40Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 127), new Base(2)), 2, -40, 127, -10, 127);
    //[TestMethod()] public void QpFromQ_ForNeg40Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-40, 511), new Base(2)), 2, -40, 511, -40, 511);
    //[TestMethod()] public void QpFromQ_ForNeg41Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 7), new Base(2)), 2, -41, 7, -31, 56);
    //[TestMethod()] public void QpFromQ_For41Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 7), new Base(2)), 2, 41, 7, 53, 56);
    //[TestMethod()] public void QpFromQ_ForNeg41Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 14), new Base(2)), 2, -41, 14, -31, 28);
    //[TestMethod()] public void QpFromQ_For41Div14_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 14), new Base(2)), 2, 41, 14, 53, 28);
    //[TestMethod()] public void QpFromQ_ForNeg41Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 15), new Base(2)), 2, -41, 15, -37, 60);
    //[TestMethod()] public void QpFromQ_For41Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 15), new Base(2)), 2, 41, 15, 53, 60);
    //[TestMethod()] public void QpFromQ_For41Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 21), new Base(2)), 2, 41, 21, 107, 168);
    //[TestMethod()] public void QpFromQ_ForNeg41Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 28), new Base(2)), 2, -41, 28, -31, 14);
    //[TestMethod()] public void QpFromQ_For41Div28_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 28), new Base(2)), 2, 41, 28, 53, 14);
    //[TestMethod()] public void QpFromQ_ForNeg41Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 30), new Base(2)), 2, -41, 30, -37, 30);
    //[TestMethod()] public void QpFromQ_For41Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 30), new Base(2)), 2, 41, 30, 53, 30);
    //[TestMethod()] public void QpFromQ_ForNeg41Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 31), new Base(2)), 2, -41, 31, -71, 124);
    //[TestMethod()] public void QpFromQ_For41Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 31), new Base(2)), 2, 41, 31, 115, 124);
    //[TestMethod()] public void QpFromQ_For41Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 42), new Base(2)), 2, 41, 42, 107, 84);
    //[TestMethod()] public void QpFromQ_ForNeg41Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 60), new Base(2)), 2, -41, 60, -37, 15);
    //[TestMethod()] public void QpFromQ_For41Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 60), new Base(2)), 2, 41, 60, 53, 15);
    //[TestMethod()] public void QpFromQ_ForNeg41Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 62), new Base(2)), 2, -41, 62, -71, 62);
    //[TestMethod()] public void QpFromQ_For41Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 62), new Base(2)), 2, 41, 62, 115, 62);
    //[TestMethod()] public void QpFromQ_ForNeg41Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 63), new Base(2)), 2, -41, 63, -37, 63);
    //[TestMethod()] public void QpFromQ_For41Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 63), new Base(2)), 2, 41, 63, 115, 126);
    //[TestMethod()] public void QpFromQ_For41Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 84), new Base(2)), 2, 41, 84, 107, 42);
    //[TestMethod()] public void QpFromQ_ForNeg41Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 124), new Base(2)), 2, -41, 124, -71, 31);
    //[TestMethod()] public void QpFromQ_For41Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 124), new Base(2)), 2, 41, 124, 115, 31);
    //[TestMethod()] public void QpFromQ_ForNeg41Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 126), new Base(2)), 2, -41, 126, -74, 63);
    //[TestMethod()] public void QpFromQ_For41Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 126), new Base(2)), 2, 41, 126, 115, 63);
    //[TestMethod()] public void QpFromQ_ForNeg41Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 127), new Base(2)), 2, -41, 127, -74, 127);
    //[TestMethod()] public void QpFromQ_For41Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 127), new Base(2)), 2, 41, 127, 233, 254);
    //[TestMethod()] public void QpFromQ_ForNeg41Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 252), new Base(2)), 2, -41, 252, -148, 63);
    //[TestMethod()] public void QpFromQ_For41Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 252), new Base(2)), 2, 41, 252, 230, 63);
    //[TestMethod()] public void QpFromQ_ForNeg41Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 254), new Base(2)), 2, -41, 254, -148, 127);
    //[TestMethod()] public void QpFromQ_For41Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 254), new Base(2)), 2, 41, 254, 233, 127);
    //[TestMethod()] public void QpFromQ_ForNeg41Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-41, 508), new Base(2)), 2, -41, 508, -296, 127);
    //[TestMethod()] public void QpFromQ_For41Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(41, 508), new Base(2)), 2, 41, 508, 466, 127);
    //[TestMethod()] public void QpFromQ_ForNeg42Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-42, 31), new Base(2)), 2, -42, 31, -21, 62);
    //[TestMethod()] public void QpFromQ_For42Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(42, 31), new Base(2)), 2, 42, 31, 51, 124);
    //[TestMethod()] public void QpFromQ_ForNeg42Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-42, 127), new Base(2)), 2, -42, 127, -42, 127);
    //[TestMethod()] public void QpFromQ_For42Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(42, 127), new Base(2)), 2, 42, 127, 213, 508);
    //[TestMethod()] public void QpFromQ_ForNeg43Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 15), new Base(2)), 2, -43, 15, -103, 120);
    //[TestMethod()] public void QpFromQ_For43Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 15), new Base(2)), 2, 43, 15, 77, 120);
    //[TestMethod()] public void QpFromQ_ForNeg43Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 21), new Base(2)), 2, -43, 21, -43, 84);
    //[TestMethod()] public void QpFromQ_ForNeg43Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 30), new Base(2)), 2, -43, 30, -103, 60);
    //[TestMethod()] public void QpFromQ_For43Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 30), new Base(2)), 2, 43, 30, 77, 60);
    //[TestMethod()] public void QpFromQ_ForNeg43Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 31), new Base(2)), 2, -43, 31, -203, 248);
    //[TestMethod()] public void QpFromQ_For43Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 31), new Base(2)), 2, 43, 31, 169, 248);
    //[TestMethod()] public void QpFromQ_ForNeg43Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 42), new Base(2)), 2, -43, 42, -43, 42);
    //[TestMethod()] public void QpFromQ_ForNeg43Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 60), new Base(2)), 2, -43, 60, -103, 30);
    //[TestMethod()] public void QpFromQ_For43Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 60), new Base(2)), 2, 43, 60, 77, 30);
    //[TestMethod()] public void QpFromQ_ForNeg43Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 62), new Base(2)), 2, -43, 62, -203, 124);
    //[TestMethod()] public void QpFromQ_For43Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 62), new Base(2)), 2, 43, 62, 169, 124);
    //[TestMethod()] public void QpFromQ_ForNeg43Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 63), new Base(2)), 2, -43, 63, -53, 63);
    //[TestMethod()] public void QpFromQ_For43Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 63), new Base(2)), 2, 43, 63, 83, 126);
    //[TestMethod()] public void QpFromQ_ForNeg43Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 84), new Base(2)), 2, -43, 84, -43, 21);
    //[TestMethod()] public void QpFromQ_ForNeg43Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 85), new Base(2)), 2, -43, 85, -43, 85);
    //[TestMethod()] public void QpFromQ_ForNeg43Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 124), new Base(2)), 2, -43, 124, -203, 62);
    //[TestMethod()] public void QpFromQ_For43Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 124), new Base(2)), 2, 43, 124, 169, 62);
    //[TestMethod()] public void QpFromQ_ForNeg43Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 126), new Base(2)), 2, -43, 126, -106, 63);
    //[TestMethod()] public void QpFromQ_For43Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 126), new Base(2)), 2, 43, 126, 83, 63);
    //[TestMethod()] public void QpFromQ_ForNeg43Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 127), new Base(2)), 2, -43, 127, -106, 127);
    //[TestMethod()] public void QpFromQ_ForNeg43Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 170), new Base(2)), 2, -43, 170, -86, 85);
    //[TestMethod()] public void QpFromQ_ForNeg43Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 252), new Base(2)), 2, -43, 252, -212, 63);
    //[TestMethod()] public void QpFromQ_For43Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 252), new Base(2)), 2, 43, 252, 166, 63);
    //[TestMethod()] public void QpFromQ_ForNeg43Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 254), new Base(2)), 2, -43, 254, -212, 127);
    //[TestMethod()] public void QpFromQ_For43Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 255), new Base(2)), 2, 43, 255, 341, 510);
    //[TestMethod()] public void QpFromQ_ForNeg43Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 340), new Base(2)), 2, -43, 340, -172, 85);
    //[TestMethod()] public void QpFromQ_ForNeg43Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-43, 508), new Base(2)), 2, -43, 508, -424, 127);
    //[TestMethod()] public void QpFromQ_For43Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 510), new Base(2)), 2, 43, 510, 341, 255);
    //[TestMethod()] public void QpFromQ_For43Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(43, 1020), new Base(2)), 2, 43, 1020, 682, 255);
    //[TestMethod()] public void QpFromQ_ForNeg44Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 15), new Base(2)), 2, -44, 15, -13, 60);
    //[TestMethod()] public void QpFromQ_For44Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(44, 15), new Base(2)), 2, 44, 15, 19, 120);
    //[TestMethod()] public void QpFromQ_ForNeg44Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 21), new Base(2)), 2, -44, 21, -11, 84);
    //[TestMethod()] public void QpFromQ_ForNeg44Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 31), new Base(2)), 2, -44, 31, -13, 62);
    //[TestMethod()] public void QpFromQ_For44Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(44, 31), new Base(2)), 2, 44, 31, 41, 248);
    //[TestMethod()] public void QpFromQ_ForNeg44Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 63), new Base(2)), 2, -44, 63, -13, 63);
    //[TestMethod()] public void QpFromQ_For44Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(44, 63), new Base(2)), 2, 44, 63, 85, 504);
    //[TestMethod()] public void QpFromQ_ForNeg44Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 73), new Base(2)), 2, -44, 73, -89, 511);
    //[TestMethod()] public void QpFromQ_ForNeg44Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 127), new Base(2)), 2, -44, 127, -26, 127);
    //[TestMethod()] public void QpFromQ_ForNeg44Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 255), new Base(2)), 2, -44, 255, -52, 255);
    //[TestMethod()] public void QpFromQ_ForNeg44Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-44, 511), new Base(2)), 2, -44, 511, -104, 511);
    //[TestMethod()] public void QpFromQ_ForNeg45Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 31), new Base(2)), 2, -45, 31, -87, 124);
    //[TestMethod()] public void QpFromQ_For45Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(45, 31), new Base(2)), 2, 45, 31, 99, 124);
    //[TestMethod()] public void QpFromQ_ForNeg45Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 62), new Base(2)), 2, -45, 62, -87, 62);
    //[TestMethod()] public void QpFromQ_For45Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(45, 62), new Base(2)), 2, 45, 62, 99, 62);
    //[TestMethod()] public void QpFromQ_ForNeg45Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 124), new Base(2)), 2, -45, 124, -87, 31);
    //[TestMethod()] public void QpFromQ_For45Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(45, 124), new Base(2)), 2, 45, 124, 99, 31);
    //[TestMethod()] public void QpFromQ_ForNeg45Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 127), new Base(2)), 2, -45, 127, -90, 127);
    //[TestMethod()] public void QpFromQ_For45Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(45, 127), new Base(2)), 2, 45, 127, 201, 254);
    //[TestMethod()] public void QpFromQ_ForNeg45Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 254), new Base(2)), 2, -45, 254, -180, 127);
    //[TestMethod()] public void QpFromQ_For45Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(45, 254), new Base(2)), 2, 45, 254, 201, 127);
    //[TestMethod()] public void QpFromQ_ForNeg45Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 508), new Base(2)), 2, -45, 508, -360, 127);
    //[TestMethod()] public void QpFromQ_For45Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(45, 508), new Base(2)), 2, 45, 508, 402, 127);
    //[TestMethod()] public void QpFromQ_ForNeg45Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-45, 511), new Base(2)), 2, -45, 511, -360, 511);
    //[TestMethod()] public void QpFromQ_ForNeg46Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-46, 9), new Base(2)), 2, -46, 9, -19, 72);
    //[TestMethod()] public void QpFromQ_For46Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(46, 21), new Base(2)), 2, 46, 21, 73, 168);
    //[TestMethod()] public void QpFromQ_ForNeg46Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-46, 31), new Base(2)), 2, -46, 31, -29, 62);
    //[TestMethod()] public void QpFromQ_For46Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(46, 31), new Base(2)), 2, 46, 31, 35, 124);
    //[TestMethod()] public void QpFromQ_ForNeg46Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-46, 63), new Base(2)), 2, -46, 63, -29, 63);
    //[TestMethod()] public void QpFromQ_For46Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(46, 63), new Base(2)), 2, 46, 63, 73, 252);
    //[TestMethod()] public void QpFromQ_ForNeg46Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-46, 127), new Base(2)), 2, -46, 127, -58, 127);
    //[TestMethod()] public void QpFromQ_For46Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(46, 127), new Base(2)), 2, 46, 127, 149, 508);
    //[TestMethod()] public void QpFromQ_ForNeg46Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-46, 255), new Base(2)), 2, -46, 255, -116, 255);
    //[TestMethod()] public void QpFromQ_For47Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 9), new Base(2)), 2, 47, 9, 67, 72);
    //[TestMethod()] public void QpFromQ_For47Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 18), new Base(2)), 2, 47, 18, 67, 36);
    //[TestMethod()] public void QpFromQ_For47Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 21), new Base(2)), 2, 47, 21, 67, 84);
    //[TestMethod()] public void QpFromQ_For47Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 36), new Base(2)), 2, 47, 36, 67, 18);
    //[TestMethod()] public void QpFromQ_For47Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 42), new Base(2)), 2, 47, 42, 67, 42);
    //[TestMethod()] public void QpFromQ_For47Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 63), new Base(2)), 2, 47, 63, 67, 126);
    //[TestMethod()] public void QpFromQ_For47Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 84), new Base(2)), 2, 47, 84, 67, 21);
    //[TestMethod()] public void QpFromQ_ForNeg47Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-47, 85), new Base(2)), 2, -47, 85, -59, 85);
    //[TestMethod()] public void QpFromQ_For47Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 126), new Base(2)), 2, 47, 126, 67, 63);
    //[TestMethod()] public void QpFromQ_For47Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 127), new Base(2)), 2, 47, 127, 137, 254);
    //[TestMethod()] public void QpFromQ_ForNeg47Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-47, 170), new Base(2)), 2, -47, 170, -118, 85);
    //[TestMethod()] public void QpFromQ_For47Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 252), new Base(2)), 2, 47, 252, 134, 63);
    //[TestMethod()] public void QpFromQ_For47Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 254), new Base(2)), 2, 47, 254, 137, 127);
    //[TestMethod()] public void QpFromQ_For47Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 255), new Base(2)), 2, 47, 255, 277, 510);
    //[TestMethod()] public void QpFromQ_ForNeg47Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-47, 340), new Base(2)), 2, -47, 340, -236, 85);
    //[TestMethod()] public void QpFromQ_For47Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 508), new Base(2)), 2, 47, 508, 274, 127);
    //[TestMethod()] public void QpFromQ_For47Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 510), new Base(2)), 2, 47, 510, 277, 255);
    //[TestMethod()] public void QpFromQ_For47Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(47, 1020), new Base(2)), 2, 47, 1020, 554, 255);
    //[TestMethod()] public void QpFromQ_ForNeg48Div7_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-48, 7), new Base(2)), 2, -48, 7, -3, 56);
    //[TestMethod()] public void QpFromQ_ForNeg48Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-48, 31), new Base(2)), 2, -48, 31, -3, 62);
    //[TestMethod()] public void QpFromQ_ForNeg48Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-48, 73), new Base(2)), 2, -48, 73, -3, 73);
    //[TestMethod()] public void QpFromQ_ForNeg48Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-48, 85), new Base(2)), 2, -48, 85, -3, 85);
    //[TestMethod()] public void QpFromQ_ForNeg48Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-48, 127), new Base(2)), 2, -48, 127, -6, 127);
    //[TestMethod()] public void QpFromQ_ForNeg48Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-48, 511), new Base(2)), 2, -48, 511, -24, 511);
    //[TestMethod()] public void QpFromQ_ForNeg49Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 15), new Base(2)), 2, -49, 15, -61, 120);
    //[TestMethod()] public void QpFromQ_For49Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(49, 15), new Base(2)), 2, 49, 15, 119, 120);
    //[TestMethod()] public void QpFromQ_ForNeg49Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 30), new Base(2)), 2, -49, 30, -61, 60);
    //[TestMethod()] public void QpFromQ_For49Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(49, 30), new Base(2)), 2, 49, 30, 119, 60);
    //[TestMethod()] public void QpFromQ_ForNeg49Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 31), new Base(2)), 2, -49, 31, -67, 124);
    //[TestMethod()] public void QpFromQ_For49Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(49, 31), new Base(2)), 2, 49, 31, 119, 124);
    //[TestMethod()] public void QpFromQ_ForNeg49Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 51), new Base(2)), 2, -49, 51, -35, 51);
    //[TestMethod()] public void QpFromQ_ForNeg49Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 60), new Base(2)), 2, -49, 60, -61, 30);
    //[TestMethod()] public void QpFromQ_For49Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(49, 60), new Base(2)), 2, 49, 60, 119, 30);
    //[TestMethod()] public void QpFromQ_ForNeg49Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 62), new Base(2)), 2, -49, 62, -67, 62);
    //[TestMethod()] public void QpFromQ_For49Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(49, 62), new Base(2)), 2, 49, 62, 119, 62);
    //[TestMethod()] public void QpFromQ_ForNeg49Div102_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 102), new Base(2)), 2, -49, 102, -70, 51);
    //[TestMethod()] public void QpFromQ_ForNeg49Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 124), new Base(2)), 2, -49, 124, -67, 31);
    //[TestMethod()] public void QpFromQ_For49Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(49, 124), new Base(2)), 2, 49, 124, 119, 31);
    //[TestMethod()] public void QpFromQ_ForNeg49Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 127), new Base(2)), 2, -49, 127, -70, 127);
    //[TestMethod()] public void QpFromQ_ForNeg49Div204_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 204), new Base(2)), 2, -49, 204, -140, 51);
    //[TestMethod()] public void QpFromQ_ForNeg49Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 254), new Base(2)), 2, -49, 254, -140, 127);
    //[TestMethod()] public void QpFromQ_ForNeg49Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 255), new Base(2)), 2, -49, 255, -28, 51);
    //[TestMethod()] public void QpFromQ_ForNeg49Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 508), new Base(2)), 2, -49, 508, -280, 127);
    //[TestMethod()] public void QpFromQ_ForNeg49Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 510), new Base(2)), 2, -49, 510, -56, 51);
    //[TestMethod()] public void QpFromQ_ForNeg49Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-49, 1020), new Base(2)), 2, -49, 1020, -112, 51);
    //[TestMethod()] public void QpFromQ_ForNeg50Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-50, 31), new Base(2)), 2, -50, 31, -19, 62);
    //[TestMethod()] public void QpFromQ_For50Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(50, 31), new Base(2)), 2, 50, 31, 55, 124);
    //[TestMethod()] public void QpFromQ_ForNeg50Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-50, 51), new Base(2)), 2, -50, 51, -19, 51);
    //[TestMethod()] public void QpFromQ_ForNeg50Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-50, 63), new Base(2)), 2, -50, 63, -19, 63);
    //[TestMethod()] public void QpFromQ_ForNeg50Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-50, 127), new Base(2)), 2, -50, 127, -38, 127);
    //[TestMethod()] public void QpFromQ_ForNeg51Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-51, 31), new Base(2)), 2, -51, 31, -195, 248);
    //[TestMethod()] public void QpFromQ_For51Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(51, 31), new Base(2)), 2, 51, 31, 177, 248);
    //[TestMethod()] public void QpFromQ_ForNeg51Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-51, 62), new Base(2)), 2, -51, 62, -195, 124);
    //[TestMethod()] public void QpFromQ_For51Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(51, 62), new Base(2)), 2, 51, 62, 177, 124);
    //[TestMethod()] public void QpFromQ_ForNeg51Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-51, 124), new Base(2)), 2, -51, 124, -195, 62);
    //[TestMethod()] public void QpFromQ_For51Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(51, 124), new Base(2)), 2, 51, 124, 177, 62);
    //[TestMethod()] public void QpFromQ_ForNeg51Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-51, 127), new Base(2)), 2, -51, 127, -102, 127);
    //[TestMethod()] public void QpFromQ_ForNeg51Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-51, 254), new Base(2)), 2, -51, 254, -204, 127);
    //[TestMethod()] public void QpFromQ_ForNeg51Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-51, 508), new Base(2)), 2, -51, 508, -408, 127);
    //[TestMethod()] public void QpFromQ_ForNeg52Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-52, 15), new Base(2)), 2, -52, 15, -11, 60);
    //[TestMethod()] public void QpFromQ_For52Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(52, 15), new Base(2)), 2, 52, 15, 23, 120);
    //[TestMethod()] public void QpFromQ_For52Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(52, 21), new Base(2)), 2, 52, 21, 25, 168);
    //[TestMethod()] public void QpFromQ_ForNeg52Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-52, 31), new Base(2)), 2, -52, 31, -11, 62);
    //[TestMethod()] public void QpFromQ_For52Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(52, 31), new Base(2)), 2, 52, 31, 49, 248);
    //[TestMethod()] public void QpFromQ_ForNeg52Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-52, 63), new Base(2)), 2, -52, 63, -11, 63);
    //[TestMethod()] public void QpFromQ_ForNeg52Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-52, 127), new Base(2)), 2, -52, 127, -22, 127);
    //[TestMethod()] public void QpFromQ_ForNeg52Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-52, 255), new Base(2)), 2, -52, 255, -44, 255);
    //[TestMethod()] public void QpFromQ_ForNeg52Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-52, 511), new Base(2)), 2, -52, 511, -88, 511);
    //[TestMethod()] public void QpFromQ_ForNeg53Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 31), new Base(2)), 2, -53, 31, -83, 124);
    //[TestMethod()] public void QpFromQ_For53Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 31), new Base(2)), 2, 53, 31, 103, 124);
    //[TestMethod()] public void QpFromQ_ForNeg53Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 62), new Base(2)), 2, -53, 62, -83, 62);
    //[TestMethod()] public void QpFromQ_For53Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 62), new Base(2)), 2, 53, 62, 103, 62);
    //[TestMethod()] public void QpFromQ_ForNeg53Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 63), new Base(2)), 2, -53, 63, -43, 63);
    //[TestMethod()] public void QpFromQ_For53Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 63), new Base(2)), 2, 53, 63, 103, 126);
    //[TestMethod()] public void QpFromQ_For53Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 85), new Base(2)), 2, 53, 85, 89, 170);
    //[TestMethod()] public void QpFromQ_ForNeg53Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 124), new Base(2)), 2, -53, 124, -83, 31);
    //[TestMethod()] public void QpFromQ_For53Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 124), new Base(2)), 2, 53, 124, 103, 31);
    //[TestMethod()] public void QpFromQ_ForNeg53Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 126), new Base(2)), 2, -53, 126, -86, 63);
    //[TestMethod()] public void QpFromQ_For53Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 126), new Base(2)), 2, 53, 126, 103, 63);
    //[TestMethod()] public void QpFromQ_ForNeg53Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 127), new Base(2)), 2, -53, 127, -86, 127);
    //[TestMethod()] public void QpFromQ_For53Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 170), new Base(2)), 2, 53, 170, 89, 85);
    //[TestMethod()] public void QpFromQ_ForNeg53Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 252), new Base(2)), 2, -53, 252, -172, 63);
    //[TestMethod()] public void QpFromQ_For53Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 252), new Base(2)), 2, 53, 252, 206, 63);
    //[TestMethod()] public void QpFromQ_ForNeg53Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 254), new Base(2)), 2, -53, 254, -172, 127);
    //[TestMethod()] public void QpFromQ_ForNeg53Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 255), new Base(2)), 2, -53, 255, -172, 255);
    //[TestMethod()] public void QpFromQ_For53Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(53, 340), new Base(2)), 2, 53, 340, 178, 85);
    //[TestMethod()] public void QpFromQ_ForNeg53Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 508), new Base(2)), 2, -53, 508, -344, 127);
    //[TestMethod()] public void QpFromQ_ForNeg53Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 510), new Base(2)), 2, -53, 510, -344, 255);
    //[TestMethod()] public void QpFromQ_ForNeg53Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 511), new Base(2)), 2, -53, 511, -344, 511);
    //[TestMethod()] public void QpFromQ_ForNeg53Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-53, 1020), new Base(2)), 2, -53, 1020, -688, 255);
    //[TestMethod()] public void QpFromQ_ForNeg54Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-54, 31), new Base(2)), 2, -54, 31, -27, 62);
    //[TestMethod()] public void QpFromQ_For54Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(54, 31), new Base(2)), 2, 54, 31, 39, 124);
    //[TestMethod()] public void QpFromQ_ForNeg54Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-54, 127), new Base(2)), 2, -54, 127, -54, 127);
    //[TestMethod()] public void QpFromQ_ForNeg55Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 9), new Base(2)), 2, -55, 9, -37, 72);
    //[TestMethod()] public void QpFromQ_ForNeg55Div18_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 18), new Base(2)), 2, -55, 18, -37, 36);
    //[TestMethod()] public void QpFromQ_ForNeg55Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 21), new Base(2)), 2, -55, 21, -55, 84);
    //[TestMethod()] public void QpFromQ_For55Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 21), new Base(2)), 2, 55, 21, 71, 84);
    //[TestMethod()] public void QpFromQ_ForNeg55Div36_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 36), new Base(2)), 2, -55, 36, -37, 18);
    //[TestMethod()] public void QpFromQ_ForNeg55Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 42), new Base(2)), 2, -55, 42, -55, 42);
    //[TestMethod()] public void QpFromQ_For55Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 42), new Base(2)), 2, 55, 42, 71, 42);
    //[TestMethod()] public void QpFromQ_For55Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 63), new Base(2)), 2, 55, 63, 71, 126);
    //[TestMethod()] public void QpFromQ_ForNeg55Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 84), new Base(2)), 2, -55, 84, -55, 21);
    //[TestMethod()] public void QpFromQ_For55Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 84), new Base(2)), 2, 55, 84, 71, 21);
    //[TestMethod()] public void QpFromQ_For55Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 126), new Base(2)), 2, 55, 126, 71, 63);
    //[TestMethod()] public void QpFromQ_ForNeg55Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 127), new Base(2)), 2, -55, 127, -118, 127);
    //[TestMethod()] public void QpFromQ_For55Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 127), new Base(2)), 2, 55, 127, 145, 254);
    //[TestMethod()] public void QpFromQ_For55Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 252), new Base(2)), 2, 55, 252, 142, 63);
    //[TestMethod()] public void QpFromQ_ForNeg55Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 254), new Base(2)), 2, -55, 254, -236, 127);
    //[TestMethod()] public void QpFromQ_For55Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 254), new Base(2)), 2, 55, 254, 145, 127);
    //[TestMethod()] public void QpFromQ_ForNeg55Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-55, 508), new Base(2)), 2, -55, 508, -472, 127);
    //[TestMethod()] public void QpFromQ_For55Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(55, 508), new Base(2)), 2, 55, 508, 290, 127);
    //[TestMethod()] public void QpFromQ_ForNeg56Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-56, 15), new Base(2)), 2, -56, 15, -7, 60);
    //[TestMethod()] public void QpFromQ_ForNeg56Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-56, 31), new Base(2)), 2, -56, 31, -7, 62);
    //[TestMethod()] public void QpFromQ_ForNeg56Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-56, 85), new Base(2)), 2, -56, 85, -7, 85);
    //[TestMethod()] public void QpFromQ_ForNeg56Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-56, 127), new Base(2)), 2, -56, 127, -14, 127);
    //[TestMethod()] public void QpFromQ_ForNeg56Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-56, 255), new Base(2)), 2, -56, 255, -28, 255);
    //[TestMethod()] public void QpFromQ_ForNeg57Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-57, 31), new Base(2)), 2, -57, 31, -75, 124);
    //[TestMethod()] public void QpFromQ_For57Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(57, 31), new Base(2)), 2, 57, 31, 111, 124);
    //[TestMethod()] public void QpFromQ_ForNeg57Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-57, 62), new Base(2)), 2, -57, 62, -75, 62);
    //[TestMethod()] public void QpFromQ_For57Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(57, 62), new Base(2)), 2, 57, 62, 111, 62);
    //[TestMethod()] public void QpFromQ_ForNeg57Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-57, 124), new Base(2)), 2, -57, 124, -75, 31);
    //[TestMethod()] public void QpFromQ_For57Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(57, 124), new Base(2)), 2, 57, 124, 111, 31);
    //[TestMethod()] public void QpFromQ_ForNeg57Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-57, 127), new Base(2)), 2, -57, 127, -78, 127);
    //[TestMethod()] public void QpFromQ_For57Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(57, 127), new Base(2)), 2, 57, 127, 225, 254);
    //[TestMethod()] public void QpFromQ_ForNeg57Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-57, 254), new Base(2)), 2, -57, 254, -156, 127);
    //[TestMethod()] public void QpFromQ_For57Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(57, 254), new Base(2)), 2, 57, 254, 225, 127);
    //[TestMethod()] public void QpFromQ_ForNeg57Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-57, 508), new Base(2)), 2, -57, 508, -312, 127);
    //[TestMethod()] public void QpFromQ_For57Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(57, 508), new Base(2)), 2, 57, 508, 450, 127);
    //[TestMethod()] public void QpFromQ_ForNeg58Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-58, 15), new Base(2)), 2, -58, 15, -43, 120);
    //[TestMethod()] public void QpFromQ_For58Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(58, 15), new Base(2)), 2, 58, 15, 47, 120);
    //[TestMethod()] public void QpFromQ_ForNeg58Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-58, 31), new Base(2)), 2, -58, 31, -23, 62);
    //[TestMethod()] public void QpFromQ_For58Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(58, 31), new Base(2)), 2, 58, 31, 47, 124);
    //[TestMethod()] public void QpFromQ_ForNeg58Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-58, 63), new Base(2)), 2, -58, 63, -23, 63);
    //[TestMethod()] public void QpFromQ_For58Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(58, 63), new Base(2)), 2, 58, 63, 97, 252);
    //[TestMethod()] public void QpFromQ_ForNeg58Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-58, 127), new Base(2)), 2, -58, 127, -46, 127);
    //[TestMethod()] public void QpFromQ_ForNeg58Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-58, 255), new Base(2)), 2, -58, 255, -92, 255);
    //[TestMethod()] public void QpFromQ_ForNeg58Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-58, 511), new Base(2)), 2, -58, 511, -184, 511);
    //[TestMethod()] public void QpFromQ_ForNeg59Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 15), new Base(2)), 2, -59, 15, -101, 120);
    //[TestMethod()] public void QpFromQ_For59Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 15), new Base(2)), 2, 59, 15, 79, 120);
    //[TestMethod()] public void QpFromQ_ForNeg59Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 21), new Base(2)), 2, -59, 21, -47, 84);
    //[TestMethod()] public void QpFromQ_ForNeg59Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 30), new Base(2)), 2, -59, 30, -101, 60);
    //[TestMethod()] public void QpFromQ_For59Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 30), new Base(2)), 2, 59, 30, 79, 60);
    //[TestMethod()] public void QpFromQ_ForNeg59Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 31), new Base(2)), 2, -59, 31, -211, 248);
    //[TestMethod()] public void QpFromQ_For59Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 31), new Base(2)), 2, 59, 31, 161, 248);
    //[TestMethod()] public void QpFromQ_ForNeg59Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 42), new Base(2)), 2, -59, 42, -47, 42);
    //[TestMethod()] public void QpFromQ_ForNeg59Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 60), new Base(2)), 2, -59, 60, -101, 30);
    //[TestMethod()] public void QpFromQ_For59Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 60), new Base(2)), 2, 59, 60, 79, 30);
    //[TestMethod()] public void QpFromQ_ForNeg59Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 62), new Base(2)), 2, -59, 62, -211, 124);
    //[TestMethod()] public void QpFromQ_For59Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 62), new Base(2)), 2, 59, 62, 161, 124);
    //[TestMethod()] public void QpFromQ_For59Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 63), new Base(2)), 2, 59, 63, 79, 126);
    //[TestMethod()] public void QpFromQ_ForNeg59Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 84), new Base(2)), 2, -59, 84, -47, 21);
    //[TestMethod()] public void QpFromQ_ForNeg59Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 85), new Base(2)), 2, -59, 85, -47, 85);
    //[TestMethod()] public void QpFromQ_ForNeg59Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 124), new Base(2)), 2, -59, 124, -211, 62);
    //[TestMethod()] public void QpFromQ_For59Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 124), new Base(2)), 2, 59, 124, 161, 62);
    //[TestMethod()] public void QpFromQ_For59Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 126), new Base(2)), 2, 59, 126, 79, 63);
    //[TestMethod()] public void QpFromQ_ForNeg59Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 127), new Base(2)), 2, -59, 127, -110, 127);
    //[TestMethod()] public void QpFromQ_ForNeg59Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 170), new Base(2)), 2, -59, 170, -94, 85);
    //[TestMethod()] public void QpFromQ_For59Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(59, 252), new Base(2)), 2, 59, 252, 158, 63);
    //[TestMethod()] public void QpFromQ_ForNeg59Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 254), new Base(2)), 2, -59, 254, -220, 127);
    //[TestMethod()] public void QpFromQ_ForNeg59Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 340), new Base(2)), 2, -59, 340, -188, 85);
    //[TestMethod()] public void QpFromQ_ForNeg59Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-59, 508), new Base(2)), 2, -59, 508, -440, 127);
    //[TestMethod()] public void QpFromQ_ForNeg60Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-60, 31), new Base(2)), 2, -60, 31, -15, 62);
    //[TestMethod()] public void QpFromQ_For60Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(60, 31), new Base(2)), 2, 60, 31, 33, 248);
    //[TestMethod()] public void QpFromQ_ForNeg60Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-60, 127), new Base(2)), 2, -60, 127, -30, 127);
    //[TestMethod()] public void QpFromQ_ForNeg60Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-60, 511), new Base(2)), 2, -60, 511, -120, 511);
    //[TestMethod()] public void QpFromQ_ForNeg61Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 31), new Base(2)), 2, -61, 31, -91, 124);
    //[TestMethod()] public void QpFromQ_For61Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 31), new Base(2)), 2, 61, 31, 95, 124);
    //[TestMethod()] public void QpFromQ_ForNeg61Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 62), new Base(2)), 2, -61, 62, -91, 62);
    //[TestMethod()] public void QpFromQ_For61Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 62), new Base(2)), 2, 61, 62, 95, 62);
    //[TestMethod()] public void QpFromQ_For61Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 63), new Base(2)), 2, 61, 63, 95, 126);
    //[TestMethod()] public void QpFromQ_ForNeg61Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 124), new Base(2)), 2, -61, 124, -91, 31);
    //[TestMethod()] public void QpFromQ_For61Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 124), new Base(2)), 2, 61, 124, 95, 31);
    //[TestMethod()] public void QpFromQ_For61Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 126), new Base(2)), 2, 61, 126, 95, 63);
    //[TestMethod()] public void QpFromQ_ForNeg61Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 127), new Base(2)), 2, -61, 127, -94, 127);
    //[TestMethod()] public void QpFromQ_For61Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 127), new Base(2)), 2, 61, 127, 193, 254);
    //[TestMethod()] public void QpFromQ_For61Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 252), new Base(2)), 2, 61, 252, 190, 63);
    //[TestMethod()] public void QpFromQ_ForNeg61Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 254), new Base(2)), 2, -61, 254, -188, 127);
    //[TestMethod()] public void QpFromQ_For61Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 254), new Base(2)), 2, 61, 254, 193, 127);
    //[TestMethod()] public void QpFromQ_ForNeg61Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 255), new Base(2)), 2, -61, 255, -188, 255);
    //[TestMethod()] public void QpFromQ_ForNeg61Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 508), new Base(2)), 2, -61, 508, -376, 127);
    //[TestMethod()] public void QpFromQ_For61Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(61, 508), new Base(2)), 2, 61, 508, 386, 127);
    //[TestMethod()] public void QpFromQ_ForNeg61Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 510), new Base(2)), 2, -61, 510, -376, 255);
    //[TestMethod()] public void QpFromQ_ForNeg61Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-61, 511), new Base(2)), 2, -61, 511, -376, 511);
    //[TestMethod()] public void QpFromQ_For62Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(62, 21), new Base(2)), 2, 62, 21, 65, 168);
    //[TestMethod()] public void QpFromQ_For62Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(62, 63), new Base(2)), 2, 62, 63, 65, 252);
    //[TestMethod()] public void QpFromQ_ForNeg62Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-62, 85), new Base(2)), 2, -62, 85, -31, 85);
    //[TestMethod()] public void QpFromQ_For62Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(62, 127), new Base(2)), 2, 62, 127, 133, 508);
    //[TestMethod()] public void QpFromQ_For63Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(63, 127), new Base(2)), 2, 63, 127, 129, 254);
    //[TestMethod()] public void QpFromQ_For63Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(63, 254), new Base(2)), 2, 63, 254, 129, 127);
    //[TestMethod()] public void QpFromQ_For63Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(63, 508), new Base(2)), 2, 63, 508, 258, 127);
    //[TestMethod()] public void QpFromQ_ForNeg64Div9_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 9), new Base(2)), 2, -64, 9, -1, 72);
    //[TestMethod()] public void QpFromQ_ForNeg64Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 15), new Base(2)), 2, -64, 15, -1, 120);
    //[TestMethod()] public void QpFromQ_ForNeg64Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 21), new Base(2)), 2, -64, 21, -1, 84);
    //[TestMethod()] public void QpFromQ_ForNeg64Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 31), new Base(2)), 2, -64, 31, -1, 124);
    //[TestMethod()] public void QpFromQ_ForNeg64Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 51), new Base(2)), 2, -64, 51, -1, 102);
    //[TestMethod()] public void QpFromQ_ForNeg64Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 63), new Base(2)), 2, -64, 63, -1, 126);
    //[TestMethod()] public void QpFromQ_ForNeg64Div73_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 73), new Base(2)), 2, -64, 73, -1, 73);
    //[TestMethod()] public void QpFromQ_ForNeg64Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 85), new Base(2)), 2, -64, 85, -1, 85);
    //[TestMethod()] public void QpFromQ_ForNeg64Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 127), new Base(2)), 2, -64, 127, -1, 127);
    //[TestMethod()] public void QpFromQ_ForNeg64Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 255), new Base(2)), 2, -64, 255, -2, 255);
    //[TestMethod()] public void QpFromQ_ForNeg64Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-64, 511), new Base(2)), 2, -64, 511, -4, 511);
    //[TestMethod()] public void QpFromQ_ForNeg65Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 21), new Base(2)), 2, -65, 21, -127, 168);
    //[TestMethod()] public void QpFromQ_ForNeg65Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 31), new Base(2)), 2, -65, 31, -65, 124);
    //[TestMethod()] public void QpFromQ_For65Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(65, 31), new Base(2)), 2, 65, 31, 121, 124);
    //[TestMethod()] public void QpFromQ_ForNeg65Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 42), new Base(2)), 2, -65, 42, -127, 84);
    //[TestMethod()] public void QpFromQ_ForNeg65Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 62), new Base(2)), 2, -65, 62, -65, 62);
    //[TestMethod()] public void QpFromQ_For65Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(65, 62), new Base(2)), 2, 65, 62, 121, 62);
    //[TestMethod()] public void QpFromQ_ForNeg65Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 63), new Base(2)), 2, -65, 63, -127, 252);
    //[TestMethod()] public void QpFromQ_ForNeg65Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 84), new Base(2)), 2, -65, 84, -127, 42);
    //[TestMethod()] public void QpFromQ_ForNeg65Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 124), new Base(2)), 2, -65, 124, -65, 31);
    //[TestMethod()] public void QpFromQ_For65Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(65, 124), new Base(2)), 2, 65, 124, 121, 31);
    //[TestMethod()] public void QpFromQ_ForNeg65Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 126), new Base(2)), 2, -65, 126, -127, 126);
    //[TestMethod()] public void QpFromQ_ForNeg65Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 127), new Base(2)), 2, -65, 127, -65, 127);
    //[TestMethod()] public void QpFromQ_ForNeg65Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 252), new Base(2)), 2, -65, 252, -127, 63);
    //[TestMethod()] public void QpFromQ_ForNeg65Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 254), new Base(2)), 2, -65, 254, -130, 127);
    //[TestMethod()] public void QpFromQ_ForNeg65Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-65, 508), new Base(2)), 2, -65, 508, -260, 127);
    //[TestMethod()] public void QpFromQ_ForNeg66Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-66, 31), new Base(2)), 2, -66, 31, -63, 248);
    //[TestMethod()] public void QpFromQ_For66Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(66, 31), new Base(2)), 2, 66, 31, 123, 248);
    //[TestMethod()] public void QpFromQ_ForNeg66Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-66, 85), new Base(2)), 2, -66, 85, -33, 85);
    //[TestMethod()] public void QpFromQ_ForNeg66Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-66, 127), new Base(2)), 2, -66, 127, -33, 127);
    //[TestMethod()] public void QpFromQ_ForNeg67Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 15), new Base(2)), 2, -67, 15, -97, 120);
    //[TestMethod()] public void QpFromQ_For67Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 15), new Base(2)), 2, 67, 15, 83, 120);
    //[TestMethod()] public void QpFromQ_For67Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 21), new Base(2)), 2, 67, 21, 157, 168);
    //[TestMethod()] public void QpFromQ_ForNeg67Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 30), new Base(2)), 2, -67, 30, -97, 60);
    //[TestMethod()] public void QpFromQ_For67Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 30), new Base(2)), 2, 67, 30, 83, 60);
    //[TestMethod()] public void QpFromQ_ForNeg67Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 31), new Base(2)), 2, -67, 31, -191, 248);
    //[TestMethod()] public void QpFromQ_For67Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 31), new Base(2)), 2, 67, 31, 181, 248);
    //[TestMethod()] public void QpFromQ_For67Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 42), new Base(2)), 2, 67, 42, 157, 84);
    //[TestMethod()] public void QpFromQ_ForNeg67Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 60), new Base(2)), 2, -67, 60, -97, 30);
    //[TestMethod()] public void QpFromQ_For67Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 60), new Base(2)), 2, 67, 60, 83, 30);
    //[TestMethod()] public void QpFromQ_ForNeg67Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 62), new Base(2)), 2, -67, 62, -191, 124);
    //[TestMethod()] public void QpFromQ_For67Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 62), new Base(2)), 2, 67, 62, 181, 124);
    //[TestMethod()] public void QpFromQ_ForNeg67Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 63), new Base(2)), 2, -67, 63, -379, 504);
    //[TestMethod()] public void QpFromQ_For67Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 84), new Base(2)), 2, 67, 84, 157, 42);
    //[TestMethod()] public void QpFromQ_ForNeg67Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 124), new Base(2)), 2, -67, 124, -191, 62);
    //[TestMethod()] public void QpFromQ_For67Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(67, 124), new Base(2)), 2, 67, 124, 181, 62);
    //[TestMethod()] public void QpFromQ_ForNeg67Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 126), new Base(2)), 2, -67, 126, -379, 252);
    //[TestMethod()] public void QpFromQ_ForNeg67Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 127), new Base(2)), 2, -67, 127, -97, 127);
    //[TestMethod()] public void QpFromQ_ForNeg67Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 252), new Base(2)), 2, -67, 252, -379, 126);
    //[TestMethod()] public void QpFromQ_ForNeg67Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 254), new Base(2)), 2, -67, 254, -194, 127);
    //[TestMethod()] public void QpFromQ_ForNeg67Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 255), new Base(2)), 2, -67, 255, -194, 255);
    //[TestMethod()] public void QpFromQ_ForNeg67Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 508), new Base(2)), 2, -67, 508, -388, 127);
    //[TestMethod()] public void QpFromQ_ForNeg67Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 510), new Base(2)), 2, -67, 510, -388, 255);
    //[TestMethod()] public void QpFromQ_ForNeg67Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-67, 511), new Base(2)), 2, -67, 511, -388, 511);
    //[TestMethod()] public void QpFromQ_For68Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(68, 21), new Base(2)), 2, 68, 21, 29, 168);
    //[TestMethod()] public void QpFromQ_ForNeg68Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-68, 31), new Base(2)), 2, -68, 31, -17, 124);
    //[TestMethod()] public void QpFromQ_For68Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(68, 31), new Base(2)), 2, 68, 31, 59, 248);
    //[TestMethod()] public void QpFromQ_ForNeg68Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-68, 63), new Base(2)), 2, -68, 63, -17, 126);
    //[TestMethod()] public void QpFromQ_ForNeg68Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-68, 127), new Base(2)), 2, -68, 127, -17, 127);
    //[TestMethod()] public void QpFromQ_ForNeg68Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-68, 511), new Base(2)), 2, -68, 511, -68, 511);
    //[TestMethod()] public void QpFromQ_ForNeg69Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-69, 31), new Base(2)), 2, -69, 31, -81, 124);
    //[TestMethod()] public void QpFromQ_For69Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 31), new Base(2)), 2, 69, 31, 105, 124);
    //[TestMethod()] public void QpFromQ_ForNeg69Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-69, 62), new Base(2)), 2, -69, 62, -81, 62);
    //[TestMethod()] public void QpFromQ_For69Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 62), new Base(2)), 2, 69, 62, 105, 62);
    //[TestMethod()] public void QpFromQ_For69Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 85), new Base(2)), 2, 69, 85, 93, 170);
    //[TestMethod()] public void QpFromQ_ForNeg69Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-69, 124), new Base(2)), 2, -69, 124, -81, 31);
    //[TestMethod()] public void QpFromQ_For69Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 124), new Base(2)), 2, 69, 124, 105, 31);
    //[TestMethod()] public void QpFromQ_For69Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 127), new Base(2)), 2, 69, 127, 219, 254);
    //[TestMethod()] public void QpFromQ_For69Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 170), new Base(2)), 2, 69, 170, 93, 85);
    //[TestMethod()] public void QpFromQ_For69Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 254), new Base(2)), 2, 69, 254, 219, 127);
    //[TestMethod()] public void QpFromQ_For69Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 340), new Base(2)), 2, 69, 340, 186, 85);
    //[TestMethod()] public void QpFromQ_For69Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(69, 508), new Base(2)), 2, 69, 508, 438, 127);
    //[TestMethod()] public void QpFromQ_ForNeg70Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-70, 127), new Base(2)), 2, -70, 127, -49, 127);
    //[TestMethod()] public void QpFromQ_ForNeg71Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-71, 85), new Base(2)), 2, -71, 85, -57, 85);
    //[TestMethod()] public void QpFromQ_ForNeg71Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-71, 127), new Base(2)), 2, -71, 127, -113, 127);
    //[TestMethod()] public void QpFromQ_For71Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(71, 127), new Base(2)), 2, 71, 127, 155, 254);
    //[TestMethod()] public void QpFromQ_ForNeg71Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-71, 170), new Base(2)), 2, -71, 170, -114, 85);
    //[TestMethod()] public void QpFromQ_ForNeg71Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-71, 254), new Base(2)), 2, -71, 254, -226, 127);
    //[TestMethod()] public void QpFromQ_For71Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(71, 254), new Base(2)), 2, 71, 254, 155, 127);
    //[TestMethod()] public void QpFromQ_ForNeg71Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-71, 340), new Base(2)), 2, -71, 340, -228, 85);
    //[TestMethod()] public void QpFromQ_ForNeg71Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-71, 508), new Base(2)), 2, -71, 508, -452, 127);
    //[TestMethod()] public void QpFromQ_For71Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(71, 508), new Base(2)), 2, 71, 508, 310, 127);
    //[TestMethod()] public void QpFromQ_ForNeg72Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-72, 31), new Base(2)), 2, -72, 31, -9, 124);
    //[TestMethod()] public void QpFromQ_ForNeg72Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-72, 85), new Base(2)), 2, -72, 85, -9, 85);
    //[TestMethod()] public void QpFromQ_ForNeg72Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-72, 127), new Base(2)), 2, -72, 127, -9, 127);
    //[TestMethod()] public void QpFromQ_ForNeg72Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-72, 511), new Base(2)), 2, -72, 511, -36, 511);
    //[TestMethod()] public void QpFromQ_ForNeg73Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 15), new Base(2)), 2, -73, 15, -73, 120);
    //[TestMethod()] public void QpFromQ_For73Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 15), new Base(2)), 2, 73, 15, 107, 120);
    //[TestMethod()] public void QpFromQ_For73Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 21), new Base(2)), 2, 73, 21, 109, 168);
    //[TestMethod()] public void QpFromQ_ForNeg73Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 30), new Base(2)), 2, -73, 30, -73, 60);
    //[TestMethod()] public void QpFromQ_For73Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 30), new Base(2)), 2, 73, 30, 107, 60);
    //[TestMethod()] public void QpFromQ_ForNeg73Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 31), new Base(2)), 2, -73, 31, -73, 124);
    //[TestMethod()] public void QpFromQ_For73Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 31), new Base(2)), 2, 73, 31, 113, 124);
    //[TestMethod()] public void QpFromQ_For73Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 42), new Base(2)), 2, 73, 42, 109, 84);
    //[TestMethod()] public void QpFromQ_ForNeg73Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 60), new Base(2)), 2, -73, 60, -73, 30);
    //[TestMethod()] public void QpFromQ_For73Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 60), new Base(2)), 2, 73, 60, 107, 30);
    //[TestMethod()] public void QpFromQ_ForNeg73Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 62), new Base(2)), 2, -73, 62, -73, 62);
    //[TestMethod()] public void QpFromQ_For73Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 62), new Base(2)), 2, 73, 62, 113, 62);
    //[TestMethod()] public void QpFromQ_ForNeg73Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 63), new Base(2)), 2, -73, 63, -143, 252);
    //[TestMethod()] public void QpFromQ_For73Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 63), new Base(2)), 2, 73, 63, 235, 252);
    //[TestMethod()] public void QpFromQ_For73Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 84), new Base(2)), 2, 73, 84, 109, 42);
    //[TestMethod()] public void QpFromQ_ForNeg73Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 124), new Base(2)), 2, -73, 124, -73, 31);
    //[TestMethod()] public void QpFromQ_For73Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 124), new Base(2)), 2, 73, 124, 113, 31);
    //[TestMethod()] public void QpFromQ_ForNeg73Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 126), new Base(2)), 2, -73, 126, -143, 126);
    //[TestMethod()] public void QpFromQ_For73Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 126), new Base(2)), 2, 73, 126, 235, 126);
    //[TestMethod()] public void QpFromQ_ForNeg73Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 127), new Base(2)), 2, -73, 127, -73, 127);
    //[TestMethod()] public void QpFromQ_For73Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 127), new Base(2)), 2, 73, 127, 235, 254);
    //[TestMethod()] public void QpFromQ_ForNeg73Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 252), new Base(2)), 2, -73, 252, -143, 63);
    //[TestMethod()] public void QpFromQ_For73Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 252), new Base(2)), 2, 73, 252, 235, 63);
    //[TestMethod()] public void QpFromQ_ForNeg73Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 254), new Base(2)), 2, -73, 254, -146, 127);
    //[TestMethod()] public void QpFromQ_For73Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 254), new Base(2)), 2, 73, 254, 235, 127);
    //[TestMethod()] public void QpFromQ_ForNeg73Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-73, 508), new Base(2)), 2, -73, 508, -292, 127);
    //[TestMethod()] public void QpFromQ_For73Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(73, 508), new Base(2)), 2, 73, 508, 470, 127);
    //[TestMethod()] public void QpFromQ_ForNeg74Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-74, 15), new Base(2)), 2, -74, 15, -41, 120);
    //[TestMethod()] public void QpFromQ_For74Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(74, 15), new Base(2)), 2, 74, 15, 49, 120);
    //[TestMethod()] public void QpFromQ_ForNeg74Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-74, 31), new Base(2)), 2, -74, 31, -79, 248);
    //[TestMethod()] public void QpFromQ_For74Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(74, 31), new Base(2)), 2, 74, 31, 107, 248);
    //[TestMethod()] public void QpFromQ_ForNeg74Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-74, 63), new Base(2)), 2, -74, 63, -41, 126);
    //[TestMethod()] public void QpFromQ_For74Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(74, 63), new Base(2)), 2, 74, 63, 107, 252);
    //[TestMethod()] public void QpFromQ_For74Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(74, 127), new Base(2)), 2, 74, 127, 217, 508);
    //[TestMethod()] public void QpFromQ_ForNeg75Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-75, 31), new Base(2)), 2, -75, 31, -207, 248);
    //[TestMethod()] public void QpFromQ_For75Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(75, 31), new Base(2)), 2, 75, 31, 165, 248);
    //[TestMethod()] public void QpFromQ_ForNeg75Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-75, 62), new Base(2)), 2, -75, 62, -207, 124);
    //[TestMethod()] public void QpFromQ_For75Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(75, 62), new Base(2)), 2, 75, 62, 165, 124);
    //[TestMethod()] public void QpFromQ_ForNeg75Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-75, 124), new Base(2)), 2, -75, 124, -207, 62);
    //[TestMethod()] public void QpFromQ_For75Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(75, 124), new Base(2)), 2, 75, 124, 165, 62);
    //[TestMethod()] public void QpFromQ_For75Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(75, 127), new Base(2)), 2, 75, 127, 171, 254);
    //[TestMethod()] public void QpFromQ_For75Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(75, 254), new Base(2)), 2, 75, 254, 171, 127);
    //[TestMethod()] public void QpFromQ_For75Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(75, 508), new Base(2)), 2, 75, 508, 342, 127);
    //[TestMethod()] public void QpFromQ_ForNeg76Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-76, 21), new Base(2)), 2, -76, 21, -13, 84);
    //[TestMethod()] public void QpFromQ_ForNeg76Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-76, 31), new Base(2)), 2, -76, 31, -25, 124);
    //[TestMethod()] public void QpFromQ_For76Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(76, 31), new Base(2)), 2, 76, 31, 43, 248);
    //[TestMethod()] public void QpFromQ_ForNeg76Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-76, 63), new Base(2)), 2, -76, 63, -25, 126);
    //[TestMethod()] public void QpFromQ_For76Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(76, 63), new Base(2)), 2, 76, 63, 89, 504);
    //[TestMethod()] public void QpFromQ_ForNeg76Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-76, 127), new Base(2)), 2, -76, 127, -25, 127);
    //[TestMethod()] public void QpFromQ_ForNeg76Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-76, 255), new Base(2)), 2, -76, 255, -10, 51);
    //[TestMethod()] public void QpFromQ_ForNeg76Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-76, 511), new Base(2)), 2, -76, 511, -100, 511);
    //[TestMethod()] public void QpFromQ_ForNeg77Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 31), new Base(2)), 2, -77, 31, -89, 124);
    //[TestMethod()] public void QpFromQ_For77Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(77, 31), new Base(2)), 2, 77, 31, 97, 124);
    //[TestMethod()] public void QpFromQ_ForNeg77Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 62), new Base(2)), 2, -77, 62, -89, 62);
    //[TestMethod()] public void QpFromQ_For77Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(77, 62), new Base(2)), 2, 77, 62, 97, 62);
    //[TestMethod()] public void QpFromQ_ForNeg77Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 124), new Base(2)), 2, -77, 124, -89, 31);
    //[TestMethod()] public void QpFromQ_For77Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(77, 124), new Base(2)), 2, 77, 124, 97, 31);
    //[TestMethod()] public void QpFromQ_ForNeg77Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 127), new Base(2)), 2, -77, 127, -89, 127);
    //[TestMethod()] public void QpFromQ_For77Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(77, 127), new Base(2)), 2, 77, 127, 203, 254);
    //[TestMethod()] public void QpFromQ_ForNeg77Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 254), new Base(2)), 2, -77, 254, -178, 127);
    //[TestMethod()] public void QpFromQ_For77Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(77, 254), new Base(2)), 2, 77, 254, 203, 127);
    //[TestMethod()] public void QpFromQ_ForNeg77Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 255), new Base(2)), 2, -77, 255, -178, 255);
    //[TestMethod()] public void QpFromQ_ForNeg77Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 508), new Base(2)), 2, -77, 508, -356, 127);
    //[TestMethod()] public void QpFromQ_For77Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(77, 508), new Base(2)), 2, 77, 508, 406, 127);
    //[TestMethod()] public void QpFromQ_ForNeg77Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-77, 510), new Base(2)), 2, -77, 510, -356, 255);
    //[TestMethod()] public void QpFromQ_ForNeg78Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-78, 85), new Base(2)), 2, -78, 85, -29, 85);
    //[TestMethod()] public void QpFromQ_For78Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(78, 127), new Base(2)), 2, 78, 127, 153, 508);
    //[TestMethod()] public void QpFromQ_For79Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(79, 127), new Base(2)), 2, 79, 127, 139, 254);
    //[TestMethod()] public void QpFromQ_For79Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(79, 254), new Base(2)), 2, 79, 254, 139, 127);
    //[TestMethod()] public void QpFromQ_For79Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(79, 255), new Base(2)), 2, 79, 255, 281, 510);
    //[TestMethod()] public void QpFromQ_For79Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(79, 508), new Base(2)), 2, 79, 508, 278, 127);
    //[TestMethod()] public void QpFromQ_For79Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(79, 510), new Base(2)), 2, 79, 510, 281, 255);
    //[TestMethod()] public void QpFromQ_For79Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(79, 1020), new Base(2)), 2, 79, 1020, 562, 255);
    //[TestMethod()] public void QpFromQ_ForNeg80Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-80, 21), new Base(2)), 2, -80, 21, -5, 84);
    //[TestMethod()] public void QpFromQ_ForNeg80Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-80, 31), new Base(2)), 2, -80, 31, -5, 124);
    //[TestMethod()] public void QpFromQ_ForNeg80Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-80, 51), new Base(2)), 2, -80, 51, -19, 510);
    //[TestMethod()] public void QpFromQ_ForNeg80Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-80, 63), new Base(2)), 2, -80, 63, -5, 126);
    //[TestMethod()] public void QpFromQ_ForNeg80Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-80, 127), new Base(2)), 2, -80, 127, -5, 127);
    //[TestMethod()] public void QpFromQ_ForNeg80Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-80, 511), new Base(2)), 2, -80, 511, -20, 511);
    //[TestMethod()] public void QpFromQ_ForNeg81Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-81, 31), new Base(2)), 2, -81, 31, -69, 124);
    //[TestMethod()] public void QpFromQ_For81Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(81, 31), new Base(2)), 2, 81, 31, 117, 124);
    //[TestMethod()] public void QpFromQ_ForNeg81Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-81, 62), new Base(2)), 2, -81, 62, -69, 62);
    //[TestMethod()] public void QpFromQ_For81Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(81, 62), new Base(2)), 2, 81, 62, 117, 62);
    //[TestMethod()] public void QpFromQ_For81Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(81, 85), new Base(2)), 2, 81, 85, 117, 170);
    //[TestMethod()] public void QpFromQ_ForNeg81Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-81, 124), new Base(2)), 2, -81, 124, -69, 31);
    //[TestMethod()] public void QpFromQ_For81Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(81, 124), new Base(2)), 2, 81, 124, 117, 31);
    //[TestMethod()] public void QpFromQ_ForNeg81Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-81, 127), new Base(2)), 2, -81, 127, -69, 127);
    //[TestMethod()] public void QpFromQ_For81Div170_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(81, 170), new Base(2)), 2, 81, 170, 117, 85);
    //[TestMethod()] public void QpFromQ_ForNeg81Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-81, 254), new Base(2)), 2, -81, 254, -138, 127);
    //[TestMethod()] public void QpFromQ_For81Div340_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(81, 340), new Base(2)), 2, 81, 340, 234, 85);
    //[TestMethod()] public void QpFromQ_ForNeg81Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-81, 508), new Base(2)), 2, -81, 508, -276, 127);
    //[TestMethod()] public void QpFromQ_ForNeg82Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-82, 15), new Base(2)), 2, -82, 15, -37, 120);
    //[TestMethod()] public void QpFromQ_For82Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(82, 15), new Base(2)), 2, 82, 15, 53, 120);
    //[TestMethod()] public void QpFromQ_ForNeg82Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-82, 31), new Base(2)), 2, -82, 31, -71, 248);
    //[TestMethod()] public void QpFromQ_For82Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(82, 31), new Base(2)), 2, 82, 31, 115, 248);
    //[TestMethod()] public void QpFromQ_ForNeg82Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-82, 63), new Base(2)), 2, -82, 63, -37, 126);
    //[TestMethod()] public void QpFromQ_ForNeg82Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-82, 127), new Base(2)), 2, -82, 127, -37, 127);
    //[TestMethod()] public void QpFromQ_For83Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(83, 21), new Base(2)), 2, 83, 21, 149, 168);
    //[TestMethod()] public void QpFromQ_ForNeg83Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 31), new Base(2)), 2, -83, 31, -199, 248);
    //[TestMethod()] public void QpFromQ_For83Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(83, 31), new Base(2)), 2, 83, 31, 173, 248);
    //[TestMethod()] public void QpFromQ_For83Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(83, 42), new Base(2)), 2, 83, 42, 149, 84);
    //[TestMethod()] public void QpFromQ_ForNeg83Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 62), new Base(2)), 2, -83, 62, -199, 124);
    //[TestMethod()] public void QpFromQ_For83Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(83, 62), new Base(2)), 2, 83, 62, 173, 124);
    //[TestMethod()] public void QpFromQ_ForNeg83Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 63), new Base(2)), 2, -83, 63, -395, 504);
    //[TestMethod()] public void QpFromQ_For83Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(83, 84), new Base(2)), 2, 83, 84, 149, 42);
    //[TestMethod()] public void QpFromQ_ForNeg83Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 124), new Base(2)), 2, -83, 124, -199, 62);
    //[TestMethod()] public void QpFromQ_For83Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(83, 124), new Base(2)), 2, 83, 124, 173, 62);
    //[TestMethod()] public void QpFromQ_ForNeg83Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 126), new Base(2)), 2, -83, 126, -395, 252);
    //[TestMethod()] public void QpFromQ_ForNeg83Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 127), new Base(2)), 2, -83, 127, -101, 127);
    //[TestMethod()] public void QpFromQ_ForNeg83Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 252), new Base(2)), 2, -83, 252, -395, 126);
    //[TestMethod()] public void QpFromQ_ForNeg83Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 254), new Base(2)), 2, -83, 254, -202, 127);
    //[TestMethod()] public void QpFromQ_ForNeg83Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-83, 508), new Base(2)), 2, -83, 508, -404, 127);
    //[TestMethod()] public void QpFromQ_ForNeg84Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-84, 31), new Base(2)), 2, -84, 31, -21, 124);
    //[TestMethod()] public void QpFromQ_For84Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(84, 31), new Base(2)), 2, 84, 31, 51, 248);
    //[TestMethod()] public void QpFromQ_ForNeg84Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-84, 127), new Base(2)), 2, -84, 127, -21, 127);
    //[TestMethod()] public void QpFromQ_ForNeg85Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 31), new Base(2)), 2, -85, 31, -85, 124);
    //[TestMethod()] public void QpFromQ_For85Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(85, 31), new Base(2)), 2, 85, 31, 101, 124);
    //[TestMethod()] public void QpFromQ_ForNeg85Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 62), new Base(2)), 2, -85, 62, -85, 62);
    //[TestMethod()] public void QpFromQ_For85Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(85, 62), new Base(2)), 2, 85, 62, 101, 62);
    //[TestMethod()] public void QpFromQ_ForNeg85Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 63), new Base(2)), 2, -85, 63, -167, 252);
    //[TestMethod()] public void QpFromQ_For85Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(85, 63), new Base(2)), 2, 85, 63, 211, 252);
    //[TestMethod()] public void QpFromQ_ForNeg85Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 124), new Base(2)), 2, -85, 124, -85, 31);
    //[TestMethod()] public void QpFromQ_For85Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(85, 124), new Base(2)), 2, 85, 124, 101, 31);
    //[TestMethod()] public void QpFromQ_ForNeg85Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 126), new Base(2)), 2, -85, 126, -167, 126);
    //[TestMethod()] public void QpFromQ_For85Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(85, 126), new Base(2)), 2, 85, 126, 211, 126);
    //[TestMethod()] public void QpFromQ_ForNeg85Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 127), new Base(2)), 2, -85, 127, -85, 127);
    //[TestMethod()] public void QpFromQ_ForNeg85Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 252), new Base(2)), 2, -85, 252, -167, 63);
    //[TestMethod()] public void QpFromQ_For85Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(85, 252), new Base(2)), 2, 85, 252, 211, 63);
    //[TestMethod()] public void QpFromQ_ForNeg85Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 254), new Base(2)), 2, -85, 254, -170, 127);
    //[TestMethod()] public void QpFromQ_ForNeg85Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 508), new Base(2)), 2, -85, 508, -340, 127);
    //[TestMethod()] public void QpFromQ_ForNeg85Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-85, 511), new Base(2)), 2, -85, 511, -340, 511);
    //[TestMethod()] public void QpFromQ_ForNeg86Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-86, 21), new Base(2)), 2, -86, 21, -43, 168);
    //[TestMethod()] public void QpFromQ_ForNeg86Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-86, 63), new Base(2)), 2, -86, 63, -53, 126);
    //[TestMethod()] public void QpFromQ_For86Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(86, 63), new Base(2)), 2, 86, 63, 83, 252);
    //[TestMethod()] public void QpFromQ_ForNeg86Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-86, 127), new Base(2)), 2, -86, 127, -53, 127);
    //[TestMethod()] public void QpFromQ_ForNeg87Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-87, 127), new Base(2)), 2, -87, 127, -117, 127);
    //[TestMethod()] public void QpFromQ_For87Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(87, 127), new Base(2)), 2, 87, 127, 147, 254);
    //[TestMethod()] public void QpFromQ_ForNeg87Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-87, 254), new Base(2)), 2, -87, 254, -234, 127);
    //[TestMethod()] public void QpFromQ_For87Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(87, 254), new Base(2)), 2, 87, 254, 147, 127);
    //[TestMethod()] public void QpFromQ_ForNeg87Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-87, 508), new Base(2)), 2, -87, 508, -468, 127);
    //[TestMethod()] public void QpFromQ_For87Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(87, 508), new Base(2)), 2, 87, 508, 294, 127);
    //[TestMethod()] public void QpFromQ_ForNeg88Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-88, 15), new Base(2)), 2, -88, 15, -13, 120);
    //[TestMethod()] public void QpFromQ_ForNeg88Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-88, 31), new Base(2)), 2, -88, 31, -13, 124);
    //[TestMethod()] public void QpFromQ_ForNeg88Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-88, 63), new Base(2)), 2, -88, 63, -13, 126);
    //[TestMethod()] public void QpFromQ_ForNeg88Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-88, 127), new Base(2)), 2, -88, 127, -13, 127);
    //[TestMethod()] public void QpFromQ_ForNeg88Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-88, 255), new Base(2)), 2, -88, 255, -26, 255);
    //[TestMethod()] public void QpFromQ_ForNeg88Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-88, 511), new Base(2)), 2, -88, 511, -52, 511);
    //[TestMethod()] public void QpFromQ_ForNeg89Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 15), new Base(2)), 2, -89, 15, -71, 120);
    //[TestMethod()] public void QpFromQ_For89Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 15), new Base(2)), 2, 89, 15, 109, 120);
    //[TestMethod()] public void QpFromQ_For89Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 21), new Base(2)), 2, 89, 21, 113, 168);
    //[TestMethod()] public void QpFromQ_ForNeg89Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 30), new Base(2)), 2, -89, 30, -71, 60);
    //[TestMethod()] public void QpFromQ_For89Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 30), new Base(2)), 2, 89, 30, 109, 60);
    //[TestMethod()] public void QpFromQ_ForNeg89Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 31), new Base(2)), 2, -89, 31, -77, 124);
    //[TestMethod()] public void QpFromQ_For89Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 31), new Base(2)), 2, 89, 31, 109, 124);
    //[TestMethod()] public void QpFromQ_For89Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 42), new Base(2)), 2, 89, 42, 113, 84);
    //[TestMethod()] public void QpFromQ_ForNeg89Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 60), new Base(2)), 2, -89, 60, -71, 30);
    //[TestMethod()] public void QpFromQ_For89Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 60), new Base(2)), 2, 89, 60, 109, 30);
    //[TestMethod()] public void QpFromQ_ForNeg89Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 62), new Base(2)), 2, -89, 62, -77, 62);
    //[TestMethod()] public void QpFromQ_For89Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 62), new Base(2)), 2, 89, 62, 109, 62);
    //[TestMethod()] public void QpFromQ_ForNeg89Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 63), new Base(2)), 2, -89, 63, -151, 252);
    //[TestMethod()] public void QpFromQ_For89Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 63), new Base(2)), 2, 89, 63, 227, 252);
    //[TestMethod()] public void QpFromQ_For89Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 84), new Base(2)), 2, 89, 84, 113, 42);
    //[TestMethod()] public void QpFromQ_ForNeg89Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 124), new Base(2)), 2, -89, 124, -77, 31);
    //[TestMethod()] public void QpFromQ_For89Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 124), new Base(2)), 2, 89, 124, 109, 31);
    //[TestMethod()] public void QpFromQ_ForNeg89Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 126), new Base(2)), 2, -89, 126, -151, 126);
    //[TestMethod()] public void QpFromQ_For89Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 126), new Base(2)), 2, 89, 126, 227, 126);
    //[TestMethod()] public void QpFromQ_ForNeg89Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 127), new Base(2)), 2, -89, 127, -77, 127);
    //[TestMethod()] public void QpFromQ_ForNeg89Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 252), new Base(2)), 2, -89, 252, -151, 63);
    //[TestMethod()] public void QpFromQ_For89Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(89, 252), new Base(2)), 2, 89, 252, 227, 63);
    //[TestMethod()] public void QpFromQ_ForNeg89Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 254), new Base(2)), 2, -89, 254, -154, 127);
    //[TestMethod()] public void QpFromQ_ForNeg89Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-89, 508), new Base(2)), 2, -89, 508, -308, 127);
    //[TestMethod()] public void QpFromQ_ForNeg90Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-90, 31), new Base(2)), 2, -90, 31, -87, 248);
    //[TestMethod()] public void QpFromQ_For90Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(90, 31), new Base(2)), 2, 90, 31, 99, 248);
    //[TestMethod()] public void QpFromQ_ForNeg90Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-90, 127), new Base(2)), 2, -90, 127, -45, 127);
    //[TestMethod()] public void QpFromQ_ForNeg90Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-90, 511), new Base(2)), 2, -90, 511, -180, 511);
    //[TestMethod()] public void QpFromQ_ForNeg91Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-91, 31), new Base(2)), 2, -91, 31, -215, 248);
    //[TestMethod()] public void QpFromQ_For91Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(91, 31), new Base(2)), 2, 91, 31, 157, 248);
    //[TestMethod()] public void QpFromQ_ForNeg91Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-91, 62), new Base(2)), 2, -91, 62, -215, 124);
    //[TestMethod()] public void QpFromQ_For91Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(91, 62), new Base(2)), 2, 91, 62, 157, 124);
    //[TestMethod()] public void QpFromQ_ForNeg91Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-91, 124), new Base(2)), 2, -91, 124, -215, 62);
    //[TestMethod()] public void QpFromQ_For91Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(91, 124), new Base(2)), 2, 91, 124, 157, 62);
    //[TestMethod()] public void QpFromQ_ForNeg91Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-91, 127), new Base(2)), 2, -91, 127, -109, 127);
    //[TestMethod()] public void QpFromQ_ForNeg91Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-91, 254), new Base(2)), 2, -91, 254, -218, 127);
    //[TestMethod()] public void QpFromQ_ForNeg91Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-91, 508), new Base(2)), 2, -91, 508, -436, 127);
    //[TestMethod()] public void QpFromQ_ForNeg92Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-92, 31), new Base(2)), 2, -92, 31, -29, 124);
    //[TestMethod()] public void QpFromQ_For92Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(92, 31), new Base(2)), 2, 92, 31, 35, 248);
    //[TestMethod()] public void QpFromQ_ForNeg92Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-92, 63), new Base(2)), 2, -92, 63, -29, 126);
    //[TestMethod()] public void QpFromQ_For92Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(92, 63), new Base(2)), 2, 92, 63, 73, 504);
    //[TestMethod()] public void QpFromQ_ForNeg92Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-92, 127), new Base(2)), 2, -92, 127, -29, 127);
    //[TestMethod()] public void QpFromQ_ForNeg92Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-92, 255), new Base(2)), 2, -92, 255, -58, 255);
    //[TestMethod()] public void QpFromQ_ForNeg92Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-92, 511), new Base(2)), 2, -92, 511, -116, 511);
    //[TestMethod()] public void QpFromQ_ForNeg93Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-93, 127), new Base(2)), 2, -93, 127, -93, 127);
    //[TestMethod()] public void QpFromQ_For93Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(93, 127), new Base(2)), 2, 93, 127, 195, 254);
    //[TestMethod()] public void QpFromQ_ForNeg93Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-93, 254), new Base(2)), 2, -93, 254, -186, 127);
    //[TestMethod()] public void QpFromQ_For93Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(93, 254), new Base(2)), 2, 93, 254, 195, 127);
    //[TestMethod()] public void QpFromQ_ForNeg93Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-93, 508), new Base(2)), 2, -93, 508, -372, 127);
    //[TestMethod()] public void QpFromQ_For93Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(93, 508), new Base(2)), 2, 93, 508, 390, 127);
    //[TestMethod()] public void QpFromQ_ForNeg93Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-93, 511), new Base(2)), 2, -93, 511, -372, 511);
    //[TestMethod()] public void QpFromQ_For94Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(94, 21), new Base(2)), 2, 94, 21, 67, 168);
    //[TestMethod()] public void QpFromQ_For94Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(94, 63), new Base(2)), 2, 94, 63, 67, 252);
    //[TestMethod()] public void QpFromQ_For94Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(94, 127), new Base(2)), 2, 94, 127, 137, 508);
    //[TestMethod()] public void QpFromQ_For95Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(95, 127), new Base(2)), 2, 95, 127, 131, 254);
    //[TestMethod()] public void QpFromQ_For95Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(95, 254), new Base(2)), 2, 95, 254, 131, 127);
    //[TestMethod()] public void QpFromQ_For95Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(95, 508), new Base(2)), 2, 95, 508, 262, 127);
    //[TestMethod()] public void QpFromQ_ForNeg96Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-96, 31), new Base(2)), 2, -96, 31, -3, 124);
    //[TestMethod()] public void QpFromQ_ForNeg96Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-96, 85), new Base(2)), 2, -96, 85, -3, 170);
    //[TestMethod()] public void QpFromQ_ForNeg96Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-96, 127), new Base(2)), 2, -96, 127, -3, 127);
    //[TestMethod()] public void QpFromQ_ForNeg96Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-96, 511), new Base(2)), 2, -96, 511, -12, 511);
    //[TestMethod()] public void QpFromQ_ForNeg97Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 15), new Base(2)), 2, -97, 15, -67, 120);
    //[TestMethod()] public void QpFromQ_For97Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(97, 15), new Base(2)), 2, 97, 15, 113, 120);
    //[TestMethod()] public void QpFromQ_ForNeg97Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 21), new Base(2)), 2, -97, 21, -131, 168);
    //[TestMethod()] public void QpFromQ_ForNeg97Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 30), new Base(2)), 2, -97, 30, -67, 60);
    //[TestMethod()] public void QpFromQ_For97Div30_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(97, 30), new Base(2)), 2, 97, 30, 113, 60);
    //[TestMethod()] public void QpFromQ_ForNeg97Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 31), new Base(2)), 2, -97, 31, -125, 248);
    //[TestMethod()] public void QpFromQ_For97Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(97, 31), new Base(2)), 2, 97, 31, 247, 248);
    //[TestMethod()] public void QpFromQ_ForNeg97Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 42), new Base(2)), 2, -97, 42, -131, 84);
    //[TestMethod()] public void QpFromQ_ForNeg97Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 60), new Base(2)), 2, -97, 60, -67, 30);
    //[TestMethod()] public void QpFromQ_For97Div60_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(97, 60), new Base(2)), 2, 97, 60, 113, 30);
    //[TestMethod()] public void QpFromQ_ForNeg97Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 62), new Base(2)), 2, -97, 62, -125, 124);
    //[TestMethod()] public void QpFromQ_For97Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(97, 62), new Base(2)), 2, 97, 62, 247, 124);
    //[TestMethod()] public void QpFromQ_ForNeg97Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 63), new Base(2)), 2, -97, 63, -131, 252);
    //[TestMethod()] public void QpFromQ_ForNeg97Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 84), new Base(2)), 2, -97, 84, -131, 42);
    //[TestMethod()] public void QpFromQ_ForNeg97Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 124), new Base(2)), 2, -97, 124, -125, 62);
    //[TestMethod()] public void QpFromQ_For97Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(97, 124), new Base(2)), 2, 97, 124, 247, 62);
    //[TestMethod()] public void QpFromQ_ForNeg97Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 126), new Base(2)), 2, -97, 126, -131, 126);
    //[TestMethod()] public void QpFromQ_ForNeg97Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 127), new Base(2)), 2, -97, 127, -67, 127);
    //[TestMethod()] public void QpFromQ_ForNeg97Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 252), new Base(2)), 2, -97, 252, -131, 63);
    //[TestMethod()] public void QpFromQ_ForNeg97Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 254), new Base(2)), 2, -97, 254, -134, 127);
    //[TestMethod()] public void QpFromQ_ForNeg97Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 255), new Base(2)), 2, -97, 255, -134, 255);
    //[TestMethod()] public void QpFromQ_ForNeg97Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 508), new Base(2)), 2, -97, 508, -268, 127);
    //[TestMethod()] public void QpFromQ_ForNeg97Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 510), new Base(2)), 2, -97, 510, -268, 255);
    //[TestMethod()] public void QpFromQ_ForNeg97Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-97, 1020), new Base(2)), 2, -97, 1020, -536, 255);
    //[TestMethod()] public void QpFromQ_ForNeg98Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-98, 31), new Base(2)), 2, -98, 31, -67, 248);
    //[TestMethod()] public void QpFromQ_For98Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(98, 31), new Base(2)), 2, 98, 31, 119, 248);
    //[TestMethod()] public void QpFromQ_ForNeg98Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-98, 127), new Base(2)), 2, -98, 127, -35, 127);
    //[TestMethod()] public void QpFromQ_ForNeg99Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 31), new Base(2)), 2, -99, 31, -189, 248);
    //[TestMethod()] public void QpFromQ_For99Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(99, 31), new Base(2)), 2, 99, 31, 183, 248);
    //[TestMethod()] public void QpFromQ_ForNeg99Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 62), new Base(2)), 2, -99, 62, -189, 124);
    //[TestMethod()] public void QpFromQ_For99Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(99, 62), new Base(2)), 2, 99, 62, 183, 124);
    //[TestMethod()] public void QpFromQ_ForNeg99Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 124), new Base(2)), 2, -99, 124, -189, 62);
    //[TestMethod()] public void QpFromQ_For99Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(99, 124), new Base(2)), 2, 99, 124, 183, 62);
    //[TestMethod()] public void QpFromQ_ForNeg99Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 127), new Base(2)), 2, -99, 127, -99, 127);
    //[TestMethod()] public void QpFromQ_ForNeg99Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 254), new Base(2)), 2, -99, 254, -198, 127);
    //[TestMethod()] public void QpFromQ_ForNeg99Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 508), new Base(2)), 2, -99, 508, -396, 127);
    //[TestMethod()] public void QpFromQ_ForNeg99Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-99, 511), new Base(2)), 2, -99, 511, -396, 511);
    //[TestMethod()] public void QpFromQ_ForNeg100Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-100, 31), new Base(2)), 2, -100, 31, -19, 124);
    //[TestMethod()] public void QpFromQ_For100Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(100, 31), new Base(2)), 2, 100, 31, 55, 248);
    //[TestMethod()] public void QpFromQ_ForNeg100Div51_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-100, 51), new Base(2)), 2, -100, 51, -19, 102);
    //[TestMethod()] public void QpFromQ_ForNeg100Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-100, 63), new Base(2)), 2, -100, 63, -19, 126);
    //[TestMethod()] public void QpFromQ_ForNeg100Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-100, 127), new Base(2)), 2, -100, 127, -19, 127);
    //[TestMethod()] public void QpFromQ_ForNeg100Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-100, 511), new Base(2)), 2, -100, 511, -76, 511);
    //[TestMethod()] public void QpFromQ_ForNeg101Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-101, 63), new Base(2)), 2, -101, 63, -163, 252);
    //[TestMethod()] public void QpFromQ_For101Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(101, 63), new Base(2)), 2, 101, 63, 215, 252);
    //[TestMethod()] public void QpFromQ_ForNeg101Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-101, 126), new Base(2)), 2, -101, 126, -163, 126);
    //[TestMethod()] public void QpFromQ_For101Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(101, 126), new Base(2)), 2, 101, 126, 215, 126);
    //[TestMethod()] public void QpFromQ_For101Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(101, 127), new Base(2)), 2, 101, 127, 215, 254);
    //[TestMethod()] public void QpFromQ_ForNeg101Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-101, 252), new Base(2)), 2, -101, 252, -163, 63);
    //[TestMethod()] public void QpFromQ_For101Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(101, 252), new Base(2)), 2, 101, 252, 215, 63);
    //[TestMethod()] public void QpFromQ_For101Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(101, 254), new Base(2)), 2, 101, 254, 215, 127);
    //[TestMethod()] public void QpFromQ_For101Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(101, 508), new Base(2)), 2, 101, 508, 430, 127);
    //[TestMethod()] public void QpFromQ_For103Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(103, 127), new Base(2)), 2, 103, 127, 151, 254);
    //[TestMethod()] public void QpFromQ_For103Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(103, 254), new Base(2)), 2, 103, 254, 151, 127);
    //[TestMethod()] public void QpFromQ_For103Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(103, 508), new Base(2)), 2, 103, 508, 302, 127);
    //[TestMethod()] public void QpFromQ_ForNeg104Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-104, 15), new Base(2)), 2, -104, 15, -11, 120);
    //[TestMethod()] public void QpFromQ_ForNeg104Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-104, 31), new Base(2)), 2, -104, 31, -11, 124);
    //[TestMethod()] public void QpFromQ_ForNeg104Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-104, 63), new Base(2)), 2, -104, 63, -11, 126);
    //[TestMethod()] public void QpFromQ_ForNeg104Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-104, 127), new Base(2)), 2, -104, 127, -11, 127);
    //[TestMethod()] public void QpFromQ_ForNeg104Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-104, 255), new Base(2)), 2, -104, 255, -22, 255);
    //[TestMethod()] public void QpFromQ_ForNeg104Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-104, 511), new Base(2)), 2, -104, 511, -44, 511);
    //[TestMethod()] public void QpFromQ_ForNeg105Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-105, 31), new Base(2)), 2, -105, 31, -141, 248);
    //[TestMethod()] public void QpFromQ_For105Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(105, 31), new Base(2)), 2, 105, 31, 231, 248);
    //[TestMethod()] public void QpFromQ_ForNeg105Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-105, 62), new Base(2)), 2, -105, 62, -141, 124);
    //[TestMethod()] public void QpFromQ_For105Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(105, 62), new Base(2)), 2, 105, 62, 231, 124);
    //[TestMethod()] public void QpFromQ_ForNeg105Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-105, 124), new Base(2)), 2, -105, 124, -141, 62);
    //[TestMethod()] public void QpFromQ_For105Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(105, 124), new Base(2)), 2, 105, 124, 231, 62);
    //[TestMethod()] public void QpFromQ_ForNeg105Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-105, 127), new Base(2)), 2, -105, 127, -75, 127);
    //[TestMethod()] public void QpFromQ_ForNeg105Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-105, 254), new Base(2)), 2, -105, 254, -150, 127);
    //[TestMethod()] public void QpFromQ_ForNeg105Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-105, 508), new Base(2)), 2, -105, 508, -300, 127);
    //[TestMethod()] public void QpFromQ_ForNeg106Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-106, 31), new Base(2)), 2, -106, 31, -83, 248);
    //[TestMethod()] public void QpFromQ_For106Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(106, 31), new Base(2)), 2, 106, 31, 103, 248);
    //[TestMethod()] public void QpFromQ_ForNeg106Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-106, 63), new Base(2)), 2, -106, 63, -43, 126);
    //[TestMethod()] public void QpFromQ_For106Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(106, 63), new Base(2)), 2, 106, 63, 103, 252);
    //[TestMethod()] public void QpFromQ_ForNeg106Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-106, 127), new Base(2)), 2, -106, 127, -43, 127);
    //[TestMethod()] public void QpFromQ_ForNeg106Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-106, 255), new Base(2)), 2, -106, 255, -86, 255);
    //[TestMethod()] public void QpFromQ_ForNeg106Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-106, 511), new Base(2)), 2, -106, 511, -172, 511);
    //[TestMethod()] public void QpFromQ_ForNeg107Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 21), new Base(2)), 2, -107, 21, -85, 168);
    //[TestMethod()] public void QpFromQ_ForNeg107Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 31), new Base(2)), 2, -107, 31, -205, 248);
    //[TestMethod()] public void QpFromQ_For107Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(107, 31), new Base(2)), 2, 107, 31, 167, 248);
    //[TestMethod()] public void QpFromQ_ForNeg107Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 42), new Base(2)), 2, -107, 42, -85, 84);
    //[TestMethod()] public void QpFromQ_ForNeg107Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 62), new Base(2)), 2, -107, 62, -205, 124);
    //[TestMethod()] public void QpFromQ_For107Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(107, 62), new Base(2)), 2, 107, 62, 167, 124);
    //[TestMethod()] public void QpFromQ_For107Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(107, 63), new Base(2)), 2, 107, 63, 337, 504);
    //[TestMethod()] public void QpFromQ_ForNeg107Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 84), new Base(2)), 2, -107, 84, -85, 42);
    //[TestMethod()] public void QpFromQ_ForNeg107Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 124), new Base(2)), 2, -107, 124, -205, 62);
    //[TestMethod()] public void QpFromQ_For107Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(107, 124), new Base(2)), 2, 107, 124, 167, 62);
    //[TestMethod()] public void QpFromQ_For107Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(107, 126), new Base(2)), 2, 107, 126, 337, 252);
    //[TestMethod()] public void QpFromQ_ForNeg107Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 127), new Base(2)), 2, -107, 127, -107, 127);
    //[TestMethod()] public void QpFromQ_For107Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(107, 252), new Base(2)), 2, 107, 252, 337, 126);
    //[TestMethod()] public void QpFromQ_ForNeg107Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 254), new Base(2)), 2, -107, 254, -214, 127);
    //[TestMethod()] public void QpFromQ_ForNeg107Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-107, 508), new Base(2)), 2, -107, 508, -428, 127);
    //[TestMethod()] public void QpFromQ_ForNeg108Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-108, 31), new Base(2)), 2, -108, 31, -27, 124);
    //[TestMethod()] public void QpFromQ_For108Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(108, 31), new Base(2)), 2, 108, 31, 39, 248);
    //[TestMethod()] public void QpFromQ_ForNeg108Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-108, 127), new Base(2)), 2, -108, 127, -27, 127);
    //[TestMethod()] public void QpFromQ_ForNeg108Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-108, 511), new Base(2)), 2, -108, 511, -108, 511);
    //[TestMethod()] public void QpFromQ_For109Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(109, 63), new Base(2)), 2, 109, 63, 199, 252);
    //[TestMethod()] public void QpFromQ_For109Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(109, 126), new Base(2)), 2, 109, 126, 199, 126);
    //[TestMethod()] public void QpFromQ_ForNeg109Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-109, 127), new Base(2)), 2, -109, 127, -91, 127);
    //[TestMethod()] public void QpFromQ_For109Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(109, 127), new Base(2)), 2, 109, 127, 199, 254);
    //[TestMethod()] public void QpFromQ_For109Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(109, 252), new Base(2)), 2, 109, 252, 199, 63);
    //[TestMethod()] public void QpFromQ_ForNeg109Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-109, 254), new Base(2)), 2, -109, 254, -182, 127);
    //[TestMethod()] public void QpFromQ_For109Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(109, 254), new Base(2)), 2, 109, 254, 199, 127);
    //[TestMethod()] public void QpFromQ_ForNeg109Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-109, 255), new Base(2)), 2, -109, 255, -182, 255);
    //[TestMethod()] public void QpFromQ_ForNeg109Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-109, 508), new Base(2)), 2, -109, 508, -364, 127);
    //[TestMethod()] public void QpFromQ_For109Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(109, 508), new Base(2)), 2, 109, 508, 398, 127);
    //[TestMethod()] public void QpFromQ_ForNeg109Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-109, 510), new Base(2)), 2, -109, 510, -364, 255);
    //[TestMethod()] public void QpFromQ_ForNeg109Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-109, 511), new Base(2)), 2, -109, 511, -52, 73);
    //[TestMethod()] public void QpFromQ_For110Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(110, 21), new Base(2)), 2, 110, 21, 71, 168);
    //[TestMethod()] public void QpFromQ_For110Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(110, 63), new Base(2)), 2, 110, 63, 71, 252);
    //[TestMethod()] public void QpFromQ_For110Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(110, 127), new Base(2)), 2, 110, 127, 145, 508);
    //[TestMethod()] public void QpFromQ_For111Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(111, 127), new Base(2)), 2, 111, 127, 135, 254);
    //[TestMethod()] public void QpFromQ_For111Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(111, 254), new Base(2)), 2, 111, 254, 135, 127);
    //[TestMethod()] public void QpFromQ_For111Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(111, 508), new Base(2)), 2, 111, 508, 270, 127);
    //[TestMethod()] public void QpFromQ_ForNeg112Div15_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-112, 15), new Base(2)), 2, -112, 15, -7, 120);
    //[TestMethod()] public void QpFromQ_ForNeg112Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-112, 31), new Base(2)), 2, -112, 31, -7, 124);
    //[TestMethod()] public void QpFromQ_ForNeg112Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-112, 85), new Base(2)), 2, -112, 85, -7, 170);
    //[TestMethod()] public void QpFromQ_ForNeg112Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-112, 127), new Base(2)), 2, -112, 127, -7, 127);
    //[TestMethod()] public void QpFromQ_ForNeg112Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-112, 255), new Base(2)), 2, -112, 255, -14, 255);
    //[TestMethod()] public void QpFromQ_ForNeg113Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 31), new Base(2)), 2, -113, 31, -133, 248);
    //[TestMethod()] public void QpFromQ_For113Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(113, 31), new Base(2)), 2, 113, 31, 239, 248);
    //[TestMethod()] public void QpFromQ_ForNeg113Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 62), new Base(2)), 2, -113, 62, -133, 124);
    //[TestMethod()] public void QpFromQ_For113Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(113, 62), new Base(2)), 2, 113, 62, 239, 124);
    //[TestMethod()] public void QpFromQ_ForNeg113Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 63), new Base(2)), 2, -113, 63, -139, 252);
    //[TestMethod()] public void QpFromQ_ForNeg113Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 124), new Base(2)), 2, -113, 124, -133, 62);
    //[TestMethod()] public void QpFromQ_For113Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(113, 124), new Base(2)), 2, 113, 124, 239, 62);
    //[TestMethod()] public void QpFromQ_ForNeg113Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 126), new Base(2)), 2, -113, 126, -139, 126);
    //[TestMethod()] public void QpFromQ_ForNeg113Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 127), new Base(2)), 2, -113, 127, -71, 127);
    //[TestMethod()] public void QpFromQ_For113Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(113, 127), new Base(2)), 2, 113, 127, 239, 254);
    //[TestMethod()] public void QpFromQ_ForNeg113Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 252), new Base(2)), 2, -113, 252, -139, 63);
    //[TestMethod()] public void QpFromQ_ForNeg113Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 254), new Base(2)), 2, -113, 254, -142, 127);
    //[TestMethod()] public void QpFromQ_For113Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(113, 254), new Base(2)), 2, 113, 254, 239, 127);
    //[TestMethod()] public void QpFromQ_ForNeg113Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 255), new Base(2)), 2, -113, 255, -142, 255);
    //[TestMethod()] public void QpFromQ_ForNeg113Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 508), new Base(2)), 2, -113, 508, -284, 127);
    //[TestMethod()] public void QpFromQ_For113Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(113, 508), new Base(2)), 2, 113, 508, 478, 127);
    //[TestMethod()] public void QpFromQ_ForNeg113Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 510), new Base(2)), 2, -113, 510, -284, 255);
    //[TestMethod()] public void QpFromQ_ForNeg113Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-113, 1020), new Base(2)), 2, -113, 1020, -568, 255);
    //[TestMethod()] public void QpFromQ_ForNeg114Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-114, 31), new Base(2)), 2, -114, 31, -75, 248);
    //[TestMethod()] public void QpFromQ_For114Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(114, 31), new Base(2)), 2, 114, 31, 111, 248);
    //[TestMethod()] public void QpFromQ_ForNeg114Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-114, 127), new Base(2)), 2, -114, 127, -39, 127);
    //[TestMethod()] public void QpFromQ_For114Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(114, 127), new Base(2)), 2, 114, 127, 225, 508);
    //[TestMethod()] public void QpFromQ_For115Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 21), new Base(2)), 2, 115, 21, 151, 168);
    //[TestMethod()] public void QpFromQ_ForNeg115Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-115, 31), new Base(2)), 2, -115, 31, -197, 248);
    //[TestMethod()] public void QpFromQ_For115Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 31), new Base(2)), 2, 115, 31, 175, 248);
    //[TestMethod()] public void QpFromQ_For115Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 42), new Base(2)), 2, 115, 42, 151, 84);
    //[TestMethod()] public void QpFromQ_ForNeg115Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-115, 62), new Base(2)), 2, -115, 62, -197, 124);
    //[TestMethod()] public void QpFromQ_For115Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 62), new Base(2)), 2, 115, 62, 175, 124);
    //[TestMethod()] public void QpFromQ_ForNeg115Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-115, 63), new Base(2)), 2, -115, 63, -403, 504);
    //[TestMethod()] public void QpFromQ_For115Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 84), new Base(2)), 2, 115, 84, 151, 42);
    //[TestMethod()] public void QpFromQ_ForNeg115Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-115, 124), new Base(2)), 2, -115, 124, -197, 62);
    //[TestMethod()] public void QpFromQ_For115Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 124), new Base(2)), 2, 115, 124, 175, 62);
    //[TestMethod()] public void QpFromQ_ForNeg115Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-115, 126), new Base(2)), 2, -115, 126, -403, 252);
    //[TestMethod()] public void QpFromQ_For115Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 127), new Base(2)), 2, 115, 127, 175, 254);
    //[TestMethod()] public void QpFromQ_ForNeg115Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-115, 252), new Base(2)), 2, -115, 252, -403, 126);
    //[TestMethod()] public void QpFromQ_For115Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 254), new Base(2)), 2, 115, 254, 175, 127);
    //[TestMethod()] public void QpFromQ_For115Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(115, 508), new Base(2)), 2, 115, 508, 350, 127);
    //[TestMethod()] public void QpFromQ_ForNeg116Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-116, 31), new Base(2)), 2, -116, 31, -23, 124);
    //[TestMethod()] public void QpFromQ_For116Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(116, 31), new Base(2)), 2, 116, 31, 47, 248);
    //[TestMethod()] public void QpFromQ_ForNeg116Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-116, 63), new Base(2)), 2, -116, 63, -23, 126);
    //[TestMethod()] public void QpFromQ_ForNeg116Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-116, 127), new Base(2)), 2, -116, 127, -23, 127);
    //[TestMethod()] public void QpFromQ_ForNeg116Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-116, 255), new Base(2)), 2, -116, 255, -46, 255);
    //[TestMethod()] public void QpFromQ_ForNeg116Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-116, 511), new Base(2)), 2, -116, 511, -92, 511);
    //[TestMethod()] public void QpFromQ_ForNeg117Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-117, 127), new Base(2)), 2, -117, 127, -87, 127);
    //[TestMethod()] public void QpFromQ_ForNeg117Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-117, 254), new Base(2)), 2, -117, 254, -174, 127);
    //[TestMethod()] public void QpFromQ_ForNeg117Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-117, 508), new Base(2)), 2, -117, 508, -348, 127);
    //[TestMethod()] public void QpFromQ_ForNeg117Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-117, 511), new Base(2)), 2, -117, 511, -348, 511);
    //[TestMethod()] public void QpFromQ_ForNeg118Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-118, 21), new Base(2)), 2, -118, 21, -47, 168);
    //[TestMethod()] public void QpFromQ_For118Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(118, 63), new Base(2)), 2, 118, 63, 79, 252);
    //[TestMethod()] public void QpFromQ_ForNeg118Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-118, 127), new Base(2)), 2, -118, 127, -55, 127);
    //[TestMethod()] public void QpFromQ_ForNeg119Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-119, 127), new Base(2)), 2, -119, 127, -119, 127);
    //[TestMethod()] public void QpFromQ_For119Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(119, 127), new Base(2)), 2, 119, 127, 143, 254);
    //[TestMethod()] public void QpFromQ_ForNeg119Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-119, 254), new Base(2)), 2, -119, 254, -238, 127);
    //[TestMethod()] public void QpFromQ_For119Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(119, 254), new Base(2)), 2, 119, 254, 143, 127);
    //[TestMethod()] public void QpFromQ_ForNeg119Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-119, 508), new Base(2)), 2, -119, 508, -476, 127);
    //[TestMethod()] public void QpFromQ_For119Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(119, 508), new Base(2)), 2, 119, 508, 286, 127);
    //[TestMethod()] public void QpFromQ_ForNeg120Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-120, 31), new Base(2)), 2, -120, 31, -15, 124);
    //[TestMethod()] public void QpFromQ_ForNeg120Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-120, 127), new Base(2)), 2, -120, 127, -15, 127);
    //[TestMethod()] public void QpFromQ_ForNeg120Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-120, 511), new Base(2)), 2, -120, 511, -60, 511);
    //[TestMethod()] public void QpFromQ_ForNeg121Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-121, 31), new Base(2)), 2, -121, 31, -149, 248);
    //[TestMethod()] public void QpFromQ_For121Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 31), new Base(2)), 2, 121, 31, 223, 248);
    //[TestMethod()] public void QpFromQ_ForNeg121Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-121, 62), new Base(2)), 2, -121, 62, -149, 124);
    //[TestMethod()] public void QpFromQ_For121Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 62), new Base(2)), 2, 121, 62, 223, 124);
    //[TestMethod()] public void QpFromQ_ForNeg121Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-121, 63), new Base(2)), 2, -121, 63, -155, 252);
    //[TestMethod()] public void QpFromQ_For121Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 63), new Base(2)), 2, 121, 63, 223, 252);
    //[TestMethod()] public void QpFromQ_ForNeg121Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-121, 124), new Base(2)), 2, -121, 124, -149, 62);
    //[TestMethod()] public void QpFromQ_For121Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 124), new Base(2)), 2, 121, 124, 223, 62);
    //[TestMethod()] public void QpFromQ_ForNeg121Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-121, 126), new Base(2)), 2, -121, 126, -155, 126);
    //[TestMethod()] public void QpFromQ_For121Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 126), new Base(2)), 2, 121, 126, 223, 126);
    //[TestMethod()] public void QpFromQ_For121Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 127), new Base(2)), 2, 121, 127, 223, 254);
    //[TestMethod()] public void QpFromQ_ForNeg121Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-121, 252), new Base(2)), 2, -121, 252, -155, 63);
    //[TestMethod()] public void QpFromQ_For121Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 252), new Base(2)), 2, 121, 252, 223, 63);
    //[TestMethod()] public void QpFromQ_For121Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 254), new Base(2)), 2, 121, 254, 223, 127);
    //[TestMethod()] public void QpFromQ_For121Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(121, 508), new Base(2)), 2, 121, 508, 446, 127);
    //[TestMethod()] public void QpFromQ_ForNeg122Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-122, 31), new Base(2)), 2, -122, 31, -91, 248);
    //[TestMethod()] public void QpFromQ_For122Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(122, 31), new Base(2)), 2, 122, 31, 95, 248);
    //[TestMethod()] public void QpFromQ_For122Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(122, 63), new Base(2)), 2, 122, 63, 95, 252);
    //[TestMethod()] public void QpFromQ_ForNeg122Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-122, 127), new Base(2)), 2, -122, 127, -47, 127);
    //[TestMethod()] public void QpFromQ_ForNeg122Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-122, 255), new Base(2)), 2, -122, 255, -94, 255);
    //[TestMethod()] public void QpFromQ_ForNeg122Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-122, 511), new Base(2)), 2, -122, 511, -188, 511);
    //[TestMethod()] public void QpFromQ_ForNeg123Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-123, 31), new Base(2)), 2, -123, 31, -213, 248);
    //[TestMethod()] public void QpFromQ_For123Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(123, 31), new Base(2)), 2, 123, 31, 159, 248);
    //[TestMethod()] public void QpFromQ_ForNeg123Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-123, 62), new Base(2)), 2, -123, 62, -213, 124);
    //[TestMethod()] public void QpFromQ_For123Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(123, 62), new Base(2)), 2, 123, 62, 159, 124);
    //[TestMethod()] public void QpFromQ_ForNeg123Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-123, 124), new Base(2)), 2, -123, 124, -213, 62);
    //[TestMethod()] public void QpFromQ_For123Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(123, 124), new Base(2)), 2, 123, 124, 159, 62);
    //[TestMethod()] public void QpFromQ_ForNeg123Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-123, 127), new Base(2)), 2, -123, 127, -111, 127);
    //[TestMethod()] public void QpFromQ_ForNeg123Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-123, 254), new Base(2)), 2, -123, 254, -222, 127);
    //[TestMethod()] public void QpFromQ_ForNeg123Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-123, 508), new Base(2)), 2, -123, 508, -444, 127);
    //[TestMethod()] public void QpFromQ_For124Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(124, 63), new Base(2)), 2, 124, 63, 65, 504);
    //[TestMethod()] public void QpFromQ_ForNeg124Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-124, 85), new Base(2)), 2, -124, 85, -31, 170);
    //[TestMethod()] public void QpFromQ_For125Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(125, 63), new Base(2)), 2, 125, 63, 191, 252);
    //[TestMethod()] public void QpFromQ_For125Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(125, 126), new Base(2)), 2, 125, 126, 191, 126);
    //[TestMethod()] public void QpFromQ_ForNeg125Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-125, 127), new Base(2)), 2, -125, 127, -95, 127);
    //[TestMethod()] public void QpFromQ_For125Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(125, 127), new Base(2)), 2, 125, 127, 191, 254);
    //[TestMethod()] public void QpFromQ_For125Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(125, 252), new Base(2)), 2, 125, 252, 191, 63);
    //[TestMethod()] public void QpFromQ_ForNeg125Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-125, 254), new Base(2)), 2, -125, 254, -190, 127);
    //[TestMethod()] public void QpFromQ_For125Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(125, 254), new Base(2)), 2, 125, 254, 191, 127);
    //[TestMethod()] public void QpFromQ_ForNeg125Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-125, 508), new Base(2)), 2, -125, 508, -380, 127);
    //[TestMethod()] public void QpFromQ_For125Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(125, 508), new Base(2)), 2, 125, 508, 382, 127);
    //[TestMethod()] public void QpFromQ_ForNeg125Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-125, 511), new Base(2)), 2, -125, 511, -380, 511);
    //[TestMethod()] public void QpFromQ_For126Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(126, 127), new Base(2)), 2, 126, 127, 129, 508);
    //[TestMethod()] public void QpFromQ_For127Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(127, 255), new Base(2)), 2, 127, 255, 257, 510);
    //[TestMethod()] public void QpFromQ_For127Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(127, 510), new Base(2)), 2, 127, 510, 257, 255);
    //[TestMethod()] public void QpFromQ_For127Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(127, 1020), new Base(2)), 2, 127, 1020, 514, 255);
    //[TestMethod()] public void QpFromQ_ForNeg128Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 21), new Base(2)), 2, -128, 21, -1, 168);
    //[TestMethod()] public void QpFromQ_ForNeg128Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 31), new Base(2)), 2, -128, 31, -1, 248);
    //[TestMethod()] public void QpFromQ_ForNeg128Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 63), new Base(2)), 2, -128, 63, -1, 252);
    //[TestMethod()] public void QpFromQ_ForNeg128Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 85), new Base(2)), 2, -128, 85, -1, 170);
    //[TestMethod()] public void QpFromQ_ForNeg128Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 127), new Base(2)), 2, -128, 127, -1, 254);
    //[TestMethod()] public void QpFromQ_ForNeg128Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 255), new Base(2)), 2, -128, 255, -1, 255);
    //[TestMethod()] public void QpFromQ_ForNeg128Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-128, 511), new Base(2)), 2, -128, 511, -2, 511);
    //[TestMethod()] public void QpFromQ_ForNeg129Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-129, 31), new Base(2)), 2, -129, 31, -129, 248);
    //[TestMethod()] public void QpFromQ_For129Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(129, 31), new Base(2)), 2, 129, 31, 243, 248);
    //[TestMethod()] public void QpFromQ_ForNeg129Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-129, 62), new Base(2)), 2, -129, 62, -129, 124);
    //[TestMethod()] public void QpFromQ_For129Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(129, 62), new Base(2)), 2, 129, 62, 243, 124);
    //[TestMethod()] public void QpFromQ_ForNeg129Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-129, 124), new Base(2)), 2, -129, 124, -129, 62);
    //[TestMethod()] public void QpFromQ_For129Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(129, 124), new Base(2)), 2, 129, 124, 243, 62);
    //[TestMethod()] public void QpFromQ_ForNeg129Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-129, 127), new Base(2)), 2, -129, 127, -255, 508);
    //[TestMethod()] public void QpFromQ_ForNeg129Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-129, 254), new Base(2)), 2, -129, 254, -255, 254);
    //[TestMethod()] public void QpFromQ_ForNeg129Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-129, 508), new Base(2)), 2, -129, 508, -255, 127);
    //[TestMethod()] public void QpFromQ_ForNeg130Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-130, 31), new Base(2)), 2, -130, 31, -65, 248);
    //[TestMethod()] public void QpFromQ_For130Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(130, 31), new Base(2)), 2, 130, 31, 121, 248);
    //[TestMethod()] public void QpFromQ_ForNeg130Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-130, 63), new Base(2)), 2, -130, 63, -127, 504);
    //[TestMethod()] public void QpFromQ_ForNeg130Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-130, 127), new Base(2)), 2, -130, 127, -65, 254);
    //[TestMethod()] public void QpFromQ_For131Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(131, 21), new Base(2)), 2, 131, 21, 155, 168);
    //[TestMethod()] public void QpFromQ_ForNeg131Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-131, 31), new Base(2)), 2, -131, 31, -193, 248);
    //[TestMethod()] public void QpFromQ_For131Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(131, 31), new Base(2)), 2, 131, 31, 179, 248);
    //[TestMethod()] public void QpFromQ_For131Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(131, 42), new Base(2)), 2, 131, 42, 155, 84);
    //[TestMethod()] public void QpFromQ_ForNeg131Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-131, 62), new Base(2)), 2, -131, 62, -193, 124);
    //[TestMethod()] public void QpFromQ_For131Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(131, 62), new Base(2)), 2, 131, 62, 179, 124);
    //[TestMethod()] public void QpFromQ_ForNeg131Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-131, 63), new Base(2)), 2, -131, 63, -383, 504);
    //[TestMethod()] public void QpFromQ_For131Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(131, 84), new Base(2)), 2, 131, 84, 155, 42);
    //[TestMethod()] public void QpFromQ_ForNeg131Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-131, 124), new Base(2)), 2, -131, 124, -193, 62);
    //[TestMethod()] public void QpFromQ_For131Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(131, 124), new Base(2)), 2, 131, 124, 179, 62);
    //[TestMethod()] public void QpFromQ_ForNeg131Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-131, 126), new Base(2)), 2, -131, 126, -383, 252);
    //[TestMethod()] public void QpFromQ_ForNeg131Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-131, 252), new Base(2)), 2, -131, 252, -383, 126);
    //[TestMethod()] public void QpFromQ_ForNeg132Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-132, 85), new Base(2)), 2, -132, 85, -33, 170);
    //[TestMethod()] public void QpFromQ_ForNeg134Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-134, 127), new Base(2)), 2, -134, 127, -97, 254);
    //[TestMethod()] public void QpFromQ_ForNeg134Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-134, 255), new Base(2)), 2, -134, 255, -97, 255);
    //[TestMethod()] public void QpFromQ_ForNeg134Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-134, 511), new Base(2)), 2, -134, 511, -194, 511);
    //[TestMethod()] public void QpFromQ_ForNeg136Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-136, 31), new Base(2)), 2, -136, 31, -17, 248);
    //[TestMethod()] public void QpFromQ_ForNeg136Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-136, 63), new Base(2)), 2, -136, 63, -17, 252);
    //[TestMethod()] public void QpFromQ_ForNeg136Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-136, 127), new Base(2)), 2, -136, 127, -17, 254);
    //[TestMethod()] public void QpFromQ_ForNeg136Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-136, 511), new Base(2)), 2, -136, 511, -34, 511);
    //[TestMethod()] public void QpFromQ_ForNeg137Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-137, 31), new Base(2)), 2, -137, 31, -145, 248);
    //[TestMethod()] public void QpFromQ_For137Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 31), new Base(2)), 2, 137, 31, 227, 248);
    //[TestMethod()] public void QpFromQ_ForNeg137Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-137, 62), new Base(2)), 2, -137, 62, -145, 124);
    //[TestMethod()] public void QpFromQ_For137Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 62), new Base(2)), 2, 137, 62, 227, 124);
    //[TestMethod()] public void QpFromQ_ForNeg137Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-137, 63), new Base(2)), 2, -137, 63, -145, 252);
    //[TestMethod()] public void QpFromQ_For137Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 63), new Base(2)), 2, 137, 63, 233, 252);
    //[TestMethod()] public void QpFromQ_ForNeg137Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-137, 124), new Base(2)), 2, -137, 124, -145, 62);
    //[TestMethod()] public void QpFromQ_For137Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 124), new Base(2)), 2, 137, 124, 227, 62);
    //[TestMethod()] public void QpFromQ_ForNeg137Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-137, 126), new Base(2)), 2, -137, 126, -145, 126);
    //[TestMethod()] public void QpFromQ_For137Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 126), new Base(2)), 2, 137, 126, 233, 126);
    //[TestMethod()] public void QpFromQ_For137Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 127), new Base(2)), 2, 137, 127, 475, 508);
    //[TestMethod()] public void QpFromQ_ForNeg137Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-137, 252), new Base(2)), 2, -137, 252, -145, 63);
    //[TestMethod()] public void QpFromQ_For137Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 252), new Base(2)), 2, 137, 252, 233, 63);
    //[TestMethod()] public void QpFromQ_For137Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 254), new Base(2)), 2, 137, 254, 475, 254);
    //[TestMethod()] public void QpFromQ_For137Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(137, 508), new Base(2)), 2, 137, 508, 475, 127);
    //[TestMethod()] public void QpFromQ_ForNeg138Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-138, 31), new Base(2)), 2, -138, 31, -81, 248);
    //[TestMethod()] public void QpFromQ_For138Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(138, 31), new Base(2)), 2, 138, 31, 105, 248);
    //[TestMethod()] public void QpFromQ_For138Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(138, 127), new Base(2)), 2, 138, 127, 219, 508);
    //[TestMethod()] public void QpFromQ_ForNeg139Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-139, 21), new Base(2)), 2, -139, 21, -89, 168);
    //[TestMethod()] public void QpFromQ_ForNeg139Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-139, 31), new Base(2)), 2, -139, 31, -209, 248);
    //[TestMethod()] public void QpFromQ_For139Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 31), new Base(2)), 2, 139, 31, 163, 248);
    //[TestMethod()] public void QpFromQ_ForNeg139Div42_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-139, 42), new Base(2)), 2, -139, 42, -89, 84);
    //[TestMethod()] public void QpFromQ_ForNeg139Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-139, 62), new Base(2)), 2, -139, 62, -209, 124);
    //[TestMethod()] public void QpFromQ_For139Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 62), new Base(2)), 2, 139, 62, 163, 124);
    //[TestMethod()] public void QpFromQ_For139Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 63), new Base(2)), 2, 139, 63, 341, 504);
    //[TestMethod()] public void QpFromQ_ForNeg139Div84_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-139, 84), new Base(2)), 2, -139, 84, -89, 42);
    //[TestMethod()] public void QpFromQ_ForNeg139Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-139, 124), new Base(2)), 2, -139, 124, -209, 62);
    //[TestMethod()] public void QpFromQ_For139Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 124), new Base(2)), 2, 139, 124, 163, 62);
    //[TestMethod()] public void QpFromQ_For139Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 126), new Base(2)), 2, 139, 126, 341, 252);
    //[TestMethod()] public void QpFromQ_For139Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 252), new Base(2)), 2, 139, 252, 341, 126);
    //[TestMethod()] public void QpFromQ_For139Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 255), new Base(2)), 2, 139, 255, 347, 510);
    //[TestMethod()] public void QpFromQ_For139Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 510), new Base(2)), 2, 139, 510, 347, 255);
    //[TestMethod()] public void QpFromQ_For139Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(139, 1020), new Base(2)), 2, 139, 1020, 694, 255);
    //[TestMethod()] public void QpFromQ_ForNeg140Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-140, 127), new Base(2)), 2, -140, 127, -49, 254);
    //[TestMethod()] public void QpFromQ_ForNeg141Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-141, 127), new Base(2)), 2, -141, 127, -351, 508);
    //[TestMethod()] public void QpFromQ_For141Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(141, 127), new Base(2)), 2, 141, 127, 411, 508);
    //[TestMethod()] public void QpFromQ_ForNeg141Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-141, 254), new Base(2)), 2, -141, 254, -351, 254);
    //[TestMethod()] public void QpFromQ_For141Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(141, 254), new Base(2)), 2, 141, 254, 411, 254);
    //[TestMethod()] public void QpFromQ_ForNeg141Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-141, 508), new Base(2)), 2, -141, 508, -351, 127);
    //[TestMethod()] public void QpFromQ_For141Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(141, 508), new Base(2)), 2, 141, 508, 411, 127);
    //[TestMethod()] public void QpFromQ_ForNeg142Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-142, 127), new Base(2)), 2, -142, 127, -113, 254);
    //[TestMethod()] public void QpFromQ_For142Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(142, 127), new Base(2)), 2, 142, 127, 155, 508);
    //[TestMethod()] public void QpFromQ_For143Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(143, 255), new Base(2)), 2, 143, 255, 283, 510);
    //[TestMethod()] public void QpFromQ_For143Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(143, 510), new Base(2)), 2, 143, 510, 283, 255);
    //[TestMethod()] public void QpFromQ_For143Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(143, 1020), new Base(2)), 2, 143, 1020, 566, 255);
    //[TestMethod()] public void QpFromQ_ForNeg144Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-144, 31), new Base(2)), 2, -144, 31, -9, 248);
    //[TestMethod()] public void QpFromQ_ForNeg144Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-144, 85), new Base(2)), 2, -144, 85, -9, 170);
    //[TestMethod()] public void QpFromQ_ForNeg144Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-144, 127), new Base(2)), 2, -144, 127, -9, 254);
    //[TestMethod()] public void QpFromQ_ForNeg144Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-144, 511), new Base(2)), 2, -144, 511, -18, 511);
    //[TestMethod()] public void QpFromQ_ForNeg145Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 31), new Base(2)), 2, -145, 31, -137, 248);
    //[TestMethod()] public void QpFromQ_For145Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(145, 31), new Base(2)), 2, 145, 31, 235, 248);
    //[TestMethod()] public void QpFromQ_ForNeg145Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 62), new Base(2)), 2, -145, 62, -137, 124);
    //[TestMethod()] public void QpFromQ_For145Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(145, 62), new Base(2)), 2, 145, 62, 235, 124);
    //[TestMethod()] public void QpFromQ_ForNeg145Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 63), new Base(2)), 2, -145, 63, -137, 252);
    //[TestMethod()] public void QpFromQ_ForNeg145Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 124), new Base(2)), 2, -145, 124, -137, 62);
    //[TestMethod()] public void QpFromQ_For145Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(145, 124), new Base(2)), 2, 145, 124, 235, 62);
    //[TestMethod()] public void QpFromQ_ForNeg145Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 126), new Base(2)), 2, -145, 126, -137, 126);
    //[TestMethod()] public void QpFromQ_ForNeg145Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 127), new Base(2)), 2, -145, 127, -271, 508);
    //[TestMethod()] public void QpFromQ_ForNeg145Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 252), new Base(2)), 2, -145, 252, -137, 63);
    //[TestMethod()] public void QpFromQ_ForNeg145Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 254), new Base(2)), 2, -145, 254, -271, 254);
    //[TestMethod()] public void QpFromQ_ForNeg145Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-145, 508), new Base(2)), 2, -145, 508, -271, 127);
    //[TestMethod()] public void QpFromQ_ForNeg146Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-146, 31), new Base(2)), 2, -146, 31, -73, 248);
    //[TestMethod()] public void QpFromQ_For146Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(146, 31), new Base(2)), 2, 146, 31, 113, 248);
    //[TestMethod()] public void QpFromQ_ForNeg146Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-146, 63), new Base(2)), 2, -146, 63, -143, 504);
    //[TestMethod()] public void QpFromQ_ForNeg146Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-146, 127), new Base(2)), 2, -146, 127, -73, 254);
    //[TestMethod()] public void QpFromQ_ForNeg147Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-147, 31), new Base(2)), 2, -147, 31, -201, 248);
    //[TestMethod()] public void QpFromQ_For147Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(147, 31), new Base(2)), 2, 147, 31, 171, 248);
    //[TestMethod()] public void QpFromQ_ForNeg147Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-147, 62), new Base(2)), 2, -147, 62, -201, 124);
    //[TestMethod()] public void QpFromQ_For147Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(147, 62), new Base(2)), 2, 147, 62, 171, 124);
    //[TestMethod()] public void QpFromQ_ForNeg147Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-147, 124), new Base(2)), 2, -147, 124, -201, 62);
    //[TestMethod()] public void QpFromQ_For147Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(147, 124), new Base(2)), 2, 147, 124, 171, 62);
    //[TestMethod()] public void QpFromQ_ForNeg148Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-148, 63), new Base(2)), 2, -148, 63, -41, 252);
    //[TestMethod()] public void QpFromQ_ForNeg149Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-149, 63), new Base(2)), 2, -149, 63, -169, 252);
    //[TestMethod()] public void QpFromQ_For149Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(149, 63), new Base(2)), 2, 149, 63, 209, 252);
    //[TestMethod()] public void QpFromQ_ForNeg149Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-149, 126), new Base(2)), 2, -149, 126, -169, 126);
    //[TestMethod()] public void QpFromQ_For149Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(149, 126), new Base(2)), 2, 149, 126, 209, 126);
    //[TestMethod()] public void QpFromQ_ForNeg149Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-149, 252), new Base(2)), 2, -149, 252, -169, 63);
    //[TestMethod()] public void QpFromQ_For149Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(149, 252), new Base(2)), 2, 149, 252, 209, 63);
    //[TestMethod()] public void QpFromQ_ForNeg152Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-152, 31), new Base(2)), 2, -152, 31, -25, 248);
    //[TestMethod()] public void QpFromQ_ForNeg152Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-152, 63), new Base(2)), 2, -152, 63, -25, 252);
    //[TestMethod()] public void QpFromQ_ForNeg152Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-152, 127), new Base(2)), 2, -152, 127, -25, 254);
    //[TestMethod()] public void QpFromQ_ForNeg152Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-152, 255), new Base(2)), 2, -152, 255, -5, 51);
    //[TestMethod()] public void QpFromQ_ForNeg152Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-152, 511), new Base(2)), 2, -152, 511, -50, 511);
    //[TestMethod()] public void QpFromQ_ForNeg153Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-153, 31), new Base(2)), 2, -153, 31, -153, 248);
    //[TestMethod()] public void QpFromQ_For153Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(153, 31), new Base(2)), 2, 153, 31, 219, 248);
    //[TestMethod()] public void QpFromQ_ForNeg153Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-153, 62), new Base(2)), 2, -153, 62, -153, 124);
    //[TestMethod()] public void QpFromQ_For153Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(153, 62), new Base(2)), 2, 153, 62, 219, 124);
    //[TestMethod()] public void QpFromQ_ForNeg153Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-153, 124), new Base(2)), 2, -153, 124, -153, 62);
    //[TestMethod()] public void QpFromQ_For153Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(153, 124), new Base(2)), 2, 153, 124, 219, 62);
    //[TestMethod()] public void QpFromQ_ForNeg154Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-154, 31), new Base(2)), 2, -154, 31, -89, 248);
    //[TestMethod()] public void QpFromQ_For154Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(154, 31), new Base(2)), 2, 154, 31, 97, 248);
    //[TestMethod()] public void QpFromQ_ForNeg154Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-154, 127), new Base(2)), 2, -154, 127, -89, 254);
    //[TestMethod()] public void QpFromQ_ForNeg154Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-154, 255), new Base(2)), 2, -154, 255, -89, 255);
    //[TestMethod()] public void QpFromQ_For155Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(155, 63), new Base(2)), 2, 155, 63, 325, 504);
    //[TestMethod()] public void QpFromQ_For155Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(155, 126), new Base(2)), 2, 155, 126, 325, 252);
    //[TestMethod()] public void QpFromQ_For155Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(155, 252), new Base(2)), 2, 155, 252, 325, 126);
    //[TestMethod()] public void QpFromQ_ForNeg156Div85_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-156, 85), new Base(2)), 2, -156, 85, -29, 170);
    //[TestMethod()] public void QpFromQ_For157Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(157, 63), new Base(2)), 2, 157, 63, 193, 252);
    //[TestMethod()] public void QpFromQ_For157Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(157, 126), new Base(2)), 2, 157, 126, 193, 126);
    //[TestMethod()] public void QpFromQ_For157Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(157, 127), new Base(2)), 2, 157, 127, 395, 508);
    //[TestMethod()] public void QpFromQ_For157Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(157, 252), new Base(2)), 2, 157, 252, 193, 63);
    //[TestMethod()] public void QpFromQ_For157Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(157, 254), new Base(2)), 2, 157, 254, 395, 254);
    //[TestMethod()] public void QpFromQ_For157Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(157, 508), new Base(2)), 2, 157, 508, 395, 127);
    //[TestMethod()] public void QpFromQ_For158Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(158, 127), new Base(2)), 2, 158, 127, 139, 508);
    //[TestMethod()] public void QpFromQ_ForNeg160Div21_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-160, 21), new Base(2)), 2, -160, 21, -5, 168);
    //[TestMethod()] public void QpFromQ_ForNeg160Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-160, 31), new Base(2)), 2, -160, 31, -5, 248);
    //[TestMethod()] public void QpFromQ_ForNeg160Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-160, 63), new Base(2)), 2, -160, 63, -5, 252);
    //[TestMethod()] public void QpFromQ_ForNeg160Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-160, 127), new Base(2)), 2, -160, 127, -5, 254);
    //[TestMethod()] public void QpFromQ_ForNeg160Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-160, 511), new Base(2)), 2, -160, 511, -10, 511);
    //[TestMethod()] public void QpFromQ_ForNeg161Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 31), new Base(2)), 2, -161, 31, -127, 248);
    //[TestMethod()] public void QpFromQ_For161Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(161, 31), new Base(2)), 2, 161, 31, 245, 248);
    //[TestMethod()] public void QpFromQ_ForNeg161Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 62), new Base(2)), 2, -161, 62, -127, 124);
    //[TestMethod()] public void QpFromQ_For161Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(161, 62), new Base(2)), 2, 161, 62, 245, 124);
    //[TestMethod()] public void QpFromQ_ForNeg161Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 124), new Base(2)), 2, -161, 124, -127, 62);
    //[TestMethod()] public void QpFromQ_For161Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(161, 124), new Base(2)), 2, 161, 124, 245, 62);
    //[TestMethod()] public void QpFromQ_ForNeg161Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 127), new Base(2)), 2, -161, 127, -263, 508);
    //[TestMethod()] public void QpFromQ_ForNeg161Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 254), new Base(2)), 2, -161, 254, -263, 254);
    //[TestMethod()] public void QpFromQ_ForNeg161Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 255), new Base(2)), 2, -161, 255, -133, 255);
    //[TestMethod()] public void QpFromQ_ForNeg161Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 508), new Base(2)), 2, -161, 508, -263, 127);
    //[TestMethod()] public void QpFromQ_ForNeg161Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 510), new Base(2)), 2, -161, 510, -266, 255);
    //[TestMethod()] public void QpFromQ_ForNeg161Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-161, 1020), new Base(2)), 2, -161, 1020, -532, 255);
    //[TestMethod()] public void QpFromQ_ForNeg162Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-162, 31), new Base(2)), 2, -162, 31, -69, 248);
    //[TestMethod()] public void QpFromQ_For162Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(162, 31), new Base(2)), 2, 162, 31, 117, 248);
    //[TestMethod()] public void QpFromQ_ForNeg162Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-162, 127), new Base(2)), 2, -162, 127, -69, 254);
    //[TestMethod()] public void QpFromQ_ForNeg163Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-163, 63), new Base(2)), 2, -163, 63, -391, 504);
    //[TestMethod()] public void QpFromQ_ForNeg163Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-163, 126), new Base(2)), 2, -163, 126, -391, 252);
    //[TestMethod()] public void QpFromQ_ForNeg163Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-163, 252), new Base(2)), 2, -163, 252, -391, 126);
    //[TestMethod()] public void QpFromQ_ForNeg164Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-164, 63), new Base(2)), 2, -164, 63, -37, 252);
    //[TestMethod()] public void QpFromQ_ForNeg168Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-168, 31), new Base(2)), 2, -168, 31, -21, 248);
    //[TestMethod()] public void QpFromQ_ForNeg168Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-168, 127), new Base(2)), 2, -168, 127, -21, 254);
    //[TestMethod()] public void QpFromQ_ForNeg169Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-169, 31), new Base(2)), 2, -169, 31, -143, 248);
    //[TestMethod()] public void QpFromQ_For169Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 31), new Base(2)), 2, 169, 31, 229, 248);
    //[TestMethod()] public void QpFromQ_ForNeg169Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-169, 62), new Base(2)), 2, -169, 62, -143, 124);
    //[TestMethod()] public void QpFromQ_For169Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 62), new Base(2)), 2, 169, 62, 229, 124);
    //[TestMethod()] public void QpFromQ_ForNeg169Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-169, 63), new Base(2)), 2, -169, 63, -149, 252);
    //[TestMethod()] public void QpFromQ_For169Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 63), new Base(2)), 2, 169, 63, 229, 252);
    //[TestMethod()] public void QpFromQ_ForNeg169Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-169, 124), new Base(2)), 2, -169, 124, -143, 62);
    //[TestMethod()] public void QpFromQ_For169Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 124), new Base(2)), 2, 169, 124, 229, 62);
    //[TestMethod()] public void QpFromQ_ForNeg169Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-169, 126), new Base(2)), 2, -169, 126, -149, 126);
    //[TestMethod()] public void QpFromQ_For169Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 126), new Base(2)), 2, 169, 126, 229, 126);
    //[TestMethod()] public void QpFromQ_For169Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 127), new Base(2)), 2, 169, 127, 467, 508);
    //[TestMethod()] public void QpFromQ_ForNeg169Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-169, 252), new Base(2)), 2, -169, 252, -149, 63);
    //[TestMethod()] public void QpFromQ_For169Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 252), new Base(2)), 2, 169, 252, 229, 63);
    //[TestMethod()] public void QpFromQ_For169Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 254), new Base(2)), 2, 169, 254, 467, 254);
    //[TestMethod()] public void QpFromQ_For169Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(169, 508), new Base(2)), 2, 169, 508, 467, 127);
    //[TestMethod()] public void QpFromQ_ForNeg170Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-170, 31), new Base(2)), 2, -170, 31, -85, 248);
    //[TestMethod()] public void QpFromQ_For170Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(170, 31), new Base(2)), 2, 170, 31, 101, 248);
    //[TestMethod()] public void QpFromQ_For170Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(170, 63), new Base(2)), 2, 170, 63, 211, 504);
    //[TestMethod()] public void QpFromQ_ForNeg170Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-170, 127), new Base(2)), 2, -170, 127, -85, 254);
    //[TestMethod()] public void QpFromQ_ForNeg170Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-170, 511), new Base(2)), 2, -170, 511, -170, 511);
    //[TestMethod()] public void QpFromQ_For172Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(172, 63), new Base(2)), 2, 172, 63, 83, 504);
    //[TestMethod()] public void QpFromQ_For173Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(173, 63), new Base(2)), 2, 173, 63, 197, 252);
    //[TestMethod()] public void QpFromQ_For173Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(173, 126), new Base(2)), 2, 173, 126, 197, 126);
    //[TestMethod()] public void QpFromQ_For173Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(173, 127), new Base(2)), 2, 173, 127, 403, 508);
    //[TestMethod()] public void QpFromQ_For173Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(173, 252), new Base(2)), 2, 173, 252, 197, 63);
    //[TestMethod()] public void QpFromQ_For173Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(173, 254), new Base(2)), 2, 173, 254, 403, 254);
    //[TestMethod()] public void QpFromQ_For173Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(173, 508), new Base(2)), 2, 173, 508, 403, 127);
    //[TestMethod()] public void QpFromQ_For174Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(174, 127), new Base(2)), 2, 174, 127, 147, 508);
    //[TestMethod()] public void QpFromQ_ForNeg176Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-176, 31), new Base(2)), 2, -176, 31, -13, 248);
    //[TestMethod()] public void QpFromQ_ForNeg176Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-176, 63), new Base(2)), 2, -176, 63, -13, 252);
    //[TestMethod()] public void QpFromQ_ForNeg176Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-176, 127), new Base(2)), 2, -176, 127, -13, 254);
    //[TestMethod()] public void QpFromQ_ForNeg176Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-176, 255), new Base(2)), 2, -176, 255, -13, 255);
    //[TestMethod()] public void QpFromQ_ForNeg176Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-176, 511), new Base(2)), 2, -176, 511, -26, 511);
    //[TestMethod()] public void QpFromQ_ForNeg177Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-177, 31), new Base(2)), 2, -177, 31, -135, 248);
    //[TestMethod()] public void QpFromQ_For177Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(177, 31), new Base(2)), 2, 177, 31, 237, 248);
    //[TestMethod()] public void QpFromQ_ForNeg177Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-177, 62), new Base(2)), 2, -177, 62, -135, 124);
    //[TestMethod()] public void QpFromQ_For177Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(177, 62), new Base(2)), 2, 177, 62, 237, 124);
    //[TestMethod()] public void QpFromQ_ForNeg177Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-177, 124), new Base(2)), 2, -177, 124, -135, 62);
    //[TestMethod()] public void QpFromQ_For177Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(177, 124), new Base(2)), 2, 177, 124, 237, 62);
    //[TestMethod()] public void QpFromQ_ForNeg177Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-177, 127), new Base(2)), 2, -177, 127, -279, 508);
    //[TestMethod()] public void QpFromQ_ForNeg177Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-177, 254), new Base(2)), 2, -177, 254, -279, 254);
    //[TestMethod()] public void QpFromQ_ForNeg177Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-177, 508), new Base(2)), 2, -177, 508, -279, 127);
    //[TestMethod()] public void QpFromQ_ForNeg178Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-178, 31), new Base(2)), 2, -178, 31, -77, 248);
    //[TestMethod()] public void QpFromQ_For178Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(178, 31), new Base(2)), 2, 178, 31, 109, 248);
    //[TestMethod()] public void QpFromQ_ForNeg178Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-178, 63), new Base(2)), 2, -178, 63, -151, 504);
    //[TestMethod()] public void QpFromQ_ForNeg178Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-178, 127), new Base(2)), 2, -178, 127, -77, 254);
    //[TestMethod()] public void QpFromQ_ForNeg179Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-179, 63), new Base(2)), 2, -179, 63, -407, 504);
    //[TestMethod()] public void QpFromQ_ForNeg179Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-179, 126), new Base(2)), 2, -179, 126, -407, 252);
    //[TestMethod()] public void QpFromQ_ForNeg179Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-179, 252), new Base(2)), 2, -179, 252, -407, 126);
    //[TestMethod()] public void QpFromQ_ForNeg180Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-180, 127), new Base(2)), 2, -180, 127, -45, 254);
    //[TestMethod()] public void QpFromQ_ForNeg180Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-180, 511), new Base(2)), 2, -180, 511, -90, 511);
    //[TestMethod()] public void QpFromQ_For181Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(181, 63), new Base(2)), 2, 181, 63, 205, 252);
    //[TestMethod()] public void QpFromQ_For181Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(181, 126), new Base(2)), 2, 181, 126, 205, 126);
    //[TestMethod()] public void QpFromQ_ForNeg181Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-181, 127), new Base(2)), 2, -181, 127, -343, 508);
    //[TestMethod()] public void QpFromQ_For181Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(181, 252), new Base(2)), 2, 181, 252, 205, 63);
    //[TestMethod()] public void QpFromQ_ForNeg181Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-181, 254), new Base(2)), 2, -181, 254, -343, 254);
    //[TestMethod()] public void QpFromQ_ForNeg181Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-181, 255), new Base(2)), 2, -181, 255, -173, 255);
    //[TestMethod()] public void QpFromQ_ForNeg181Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-181, 508), new Base(2)), 2, -181, 508, -343, 127);
    //[TestMethod()] public void QpFromQ_ForNeg181Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-181, 510), new Base(2)), 2, -181, 510, -346, 255);
    //[TestMethod()] public void QpFromQ_ForNeg181Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-181, 1020), new Base(2)), 2, -181, 1020, -692, 255);
    //[TestMethod()] public void QpFromQ_ForNeg182Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-182, 127), new Base(2)), 2, -182, 127, -109, 254);
    //[TestMethod()] public void QpFromQ_ForNeg184Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-184, 31), new Base(2)), 2, -184, 31, -29, 248);
    //[TestMethod()] public void QpFromQ_ForNeg184Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-184, 63), new Base(2)), 2, -184, 63, -29, 252);
    //[TestMethod()] public void QpFromQ_ForNeg184Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-184, 127), new Base(2)), 2, -184, 127, -29, 254);
    //[TestMethod()] public void QpFromQ_ForNeg184Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-184, 255), new Base(2)), 2, -184, 255, -29, 255);
    //[TestMethod()] public void QpFromQ_ForNeg184Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-184, 511), new Base(2)), 2, -184, 511, -58, 511);
    //[TestMethod()] public void QpFromQ_ForNeg185Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-185, 31), new Base(2)), 2, -185, 31, -151, 248);
    //[TestMethod()] public void QpFromQ_For185Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(185, 31), new Base(2)), 2, 185, 31, 221, 248);
    //[TestMethod()] public void QpFromQ_ForNeg185Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-185, 62), new Base(2)), 2, -185, 62, -151, 124);
    //[TestMethod()] public void QpFromQ_For185Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(185, 62), new Base(2)), 2, 185, 62, 221, 124);
    //[TestMethod()] public void QpFromQ_For185Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(185, 63), new Base(2)), 2, 185, 63, 221, 252);
    //[TestMethod()] public void QpFromQ_ForNeg185Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-185, 124), new Base(2)), 2, -185, 124, -151, 62);
    //[TestMethod()] public void QpFromQ_For185Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(185, 124), new Base(2)), 2, 185, 124, 221, 62);
    //[TestMethod()] public void QpFromQ_For185Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(185, 126), new Base(2)), 2, 185, 126, 221, 126);
    //[TestMethod()] public void QpFromQ_For185Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(185, 252), new Base(2)), 2, 185, 252, 221, 63);
    //[TestMethod()] public void QpFromQ_ForNeg186Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-186, 127), new Base(2)), 2, -186, 127, -93, 254);
    //[TestMethod()] public void QpFromQ_ForNeg186Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-186, 511), new Base(2)), 2, -186, 511, -186, 511);
    //[TestMethod()] public void QpFromQ_For187Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(187, 63), new Base(2)), 2, 187, 63, 317, 504);
    //[TestMethod()] public void QpFromQ_For187Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(187, 126), new Base(2)), 2, 187, 126, 317, 252);
    //[TestMethod()] public void QpFromQ_For187Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(187, 252), new Base(2)), 2, 187, 252, 317, 126);
    //[TestMethod()] public void QpFromQ_For188Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(188, 63), new Base(2)), 2, 188, 63, 67, 504);
    //[TestMethod()] public void QpFromQ_For189Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(189, 127), new Base(2)), 2, 189, 127, 387, 508);
    //[TestMethod()] public void QpFromQ_For189Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(189, 254), new Base(2)), 2, 189, 254, 387, 254);
    //[TestMethod()] public void QpFromQ_For189Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(189, 508), new Base(2)), 2, 189, 508, 387, 127);
    //[TestMethod()] public void QpFromQ_For190Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(190, 127), new Base(2)), 2, 190, 127, 131, 508);
    //[TestMethod()] public void QpFromQ_For191Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(191, 255), new Base(2)), 2, 191, 255, 259, 510);
    //[TestMethod()] public void QpFromQ_For191Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(191, 510), new Base(2)), 2, 191, 510, 259, 255);
    //[TestMethod()] public void QpFromQ_For191Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(191, 1020), new Base(2)), 2, 191, 1020, 518, 255);
    //[TestMethod()] public void QpFromQ_ForNeg192Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-192, 31), new Base(2)), 2, -192, 31, -3, 248);
    //[TestMethod()] public void QpFromQ_ForNeg192Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-192, 127), new Base(2)), 2, -192, 127, -3, 254);
    //[TestMethod()] public void QpFromQ_ForNeg192Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-192, 511), new Base(2)), 2, -192, 511, -6, 511);
    //[TestMethod()] public void QpFromQ_ForNeg193Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 31), new Base(2)), 2, -193, 31, -131, 248);
    //[TestMethod()] public void QpFromQ_For193Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(193, 31), new Base(2)), 2, 193, 31, 241, 248);
    //[TestMethod()] public void QpFromQ_ForNeg193Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 62), new Base(2)), 2, -193, 62, -131, 124);
    //[TestMethod()] public void QpFromQ_For193Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(193, 62), new Base(2)), 2, 193, 62, 241, 124);
    //[TestMethod()] public void QpFromQ_ForNeg193Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 63), new Base(2)), 2, -193, 63, -253, 504);
    //[TestMethod()] public void QpFromQ_ForNeg193Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 124), new Base(2)), 2, -193, 124, -131, 62);
    //[TestMethod()] public void QpFromQ_For193Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(193, 124), new Base(2)), 2, 193, 124, 241, 62);
    //[TestMethod()] public void QpFromQ_ForNeg193Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 126), new Base(2)), 2, -193, 126, -253, 252);
    //[TestMethod()] public void QpFromQ_ForNeg193Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 127), new Base(2)), 2, -193, 127, -259, 508);
    //[TestMethod()] public void QpFromQ_ForNeg193Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 252), new Base(2)), 2, -193, 252, -253, 126);
    //[TestMethod()] public void QpFromQ_ForNeg193Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 254), new Base(2)), 2, -193, 254, -259, 254);
    //[TestMethod()] public void QpFromQ_ForNeg193Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 255), new Base(2)), 2, -193, 255, -131, 255);
    //[TestMethod()] public void QpFromQ_ForNeg193Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 508), new Base(2)), 2, -193, 508, -259, 127);
    //[TestMethod()] public void QpFromQ_ForNeg193Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 510), new Base(2)), 2, -193, 510, -262, 255);
    //[TestMethod()] public void QpFromQ_ForNeg193Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-193, 1020), new Base(2)), 2, -193, 1020, -524, 255);
    //[TestMethod()] public void QpFromQ_ForNeg194Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-194, 63), new Base(2)), 2, -194, 63, -131, 504);
    //[TestMethod()] public void QpFromQ_ForNeg194Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-194, 127), new Base(2)), 2, -194, 127, -67, 254);
    //[TestMethod()] public void QpFromQ_ForNeg198Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-198, 127), new Base(2)), 2, -198, 127, -99, 254);
    //[TestMethod()] public void QpFromQ_ForNeg198Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-198, 511), new Base(2)), 2, -198, 511, -198, 511);
    //[TestMethod()] public void QpFromQ_ForNeg200Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-200, 31), new Base(2)), 2, -200, 31, -19, 248);
    //[TestMethod()] public void QpFromQ_ForNeg200Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-200, 63), new Base(2)), 2, -200, 63, -19, 252);
    //[TestMethod()] public void QpFromQ_ForNeg200Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-200, 127), new Base(2)), 2, -200, 127, -19, 254);
    //[TestMethod()] public void QpFromQ_ForNeg200Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-200, 511), new Base(2)), 2, -200, 511, -38, 511);
    //[TestMethod()] public void QpFromQ_ForNeg201Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-201, 31), new Base(2)), 2, -201, 31, -147, 248);
    //[TestMethod()] public void QpFromQ_For201Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(201, 31), new Base(2)), 2, 201, 31, 225, 248);
    //[TestMethod()] public void QpFromQ_ForNeg201Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-201, 62), new Base(2)), 2, -201, 62, -147, 124);
    //[TestMethod()] public void QpFromQ_For201Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(201, 62), new Base(2)), 2, 201, 62, 225, 124);
    //[TestMethod()] public void QpFromQ_ForNeg201Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-201, 124), new Base(2)), 2, -201, 124, -147, 62);
    //[TestMethod()] public void QpFromQ_For201Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(201, 124), new Base(2)), 2, 201, 124, 225, 62);
    //[TestMethod()] public void QpFromQ_For201Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(201, 127), new Base(2)), 2, 201, 127, 471, 508);
    //[TestMethod()] public void QpFromQ_For201Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(201, 254), new Base(2)), 2, 201, 254, 471, 254);
    //[TestMethod()] public void QpFromQ_For201Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(201, 508), new Base(2)), 2, 201, 508, 471, 127);
    //[TestMethod()] public void QpFromQ_For202Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(202, 63), new Base(2)), 2, 202, 63, 215, 504);
    //[TestMethod()] public void QpFromQ_For202Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(202, 127), new Base(2)), 2, 202, 127, 215, 508);
    //[TestMethod()] public void QpFromQ_For203Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(203, 255), new Base(2)), 2, 203, 255, 343, 510);
    //[TestMethod()] public void QpFromQ_For203Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(203, 510), new Base(2)), 2, 203, 510, 343, 255);
    //[TestMethod()] public void QpFromQ_For203Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(203, 1020), new Base(2)), 2, 203, 1020, 686, 255);
    //[TestMethod()] public void QpFromQ_For205Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(205, 127), new Base(2)), 2, 205, 127, 407, 508);
    //[TestMethod()] public void QpFromQ_For205Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(205, 254), new Base(2)), 2, 205, 254, 407, 254);
    //[TestMethod()] public void QpFromQ_For205Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(205, 508), new Base(2)), 2, 205, 508, 407, 127);
    //[TestMethod()] public void QpFromQ_For206Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(206, 127), new Base(2)), 2, 206, 127, 151, 508);
    //[TestMethod()] public void QpFromQ_ForNeg208Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-208, 31), new Base(2)), 2, -208, 31, -11, 248);
    //[TestMethod()] public void QpFromQ_ForNeg208Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-208, 63), new Base(2)), 2, -208, 63, -11, 252);
    //[TestMethod()] public void QpFromQ_ForNeg208Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-208, 127), new Base(2)), 2, -208, 127, -11, 254);
    //[TestMethod()] public void QpFromQ_ForNeg208Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-208, 255), new Base(2)), 2, -208, 255, -11, 255);
    //[TestMethod()] public void QpFromQ_ForNeg208Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-208, 511), new Base(2)), 2, -208, 511, -22, 511);
    //[TestMethod()] public void QpFromQ_ForNeg209Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 31), new Base(2)), 2, -209, 31, -139, 248);
    //[TestMethod()] public void QpFromQ_For209Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(209, 31), new Base(2)), 2, 209, 31, 233, 248);
    //[TestMethod()] public void QpFromQ_ForNeg209Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 62), new Base(2)), 2, -209, 62, -139, 124);
    //[TestMethod()] public void QpFromQ_For209Div62_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(209, 62), new Base(2)), 2, 209, 62, 233, 124);
    //[TestMethod()] public void QpFromQ_ForNeg209Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 63), new Base(2)), 2, -209, 63, -269, 504);
    //[TestMethod()] public void QpFromQ_ForNeg209Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 124), new Base(2)), 2, -209, 124, -139, 62);
    //[TestMethod()] public void QpFromQ_For209Div124_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(209, 124), new Base(2)), 2, 209, 124, 233, 62);
    //[TestMethod()] public void QpFromQ_ForNeg209Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 126), new Base(2)), 2, -209, 126, -269, 252);
    //[TestMethod()] public void QpFromQ_ForNeg209Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 127), new Base(2)), 2, -209, 127, -275, 508);
    //[TestMethod()] public void QpFromQ_ForNeg209Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 252), new Base(2)), 2, -209, 252, -269, 126);
    //[TestMethod()] public void QpFromQ_ForNeg209Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 254), new Base(2)), 2, -209, 254, -275, 254);
    //[TestMethod()] public void QpFromQ_ForNeg209Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 255), new Base(2)), 2, -209, 255, -139, 255);
    //[TestMethod()] public void QpFromQ_ForNeg209Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 508), new Base(2)), 2, -209, 508, -275, 127);
    //[TestMethod()] public void QpFromQ_ForNeg209Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 510), new Base(2)), 2, -209, 510, -278, 255);
    //[TestMethod()] public void QpFromQ_ForNeg209Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-209, 1020), new Base(2)), 2, -209, 1020, -556, 255);
    //[TestMethod()] public void QpFromQ_ForNeg210Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-210, 127), new Base(2)), 2, -210, 127, -75, 254);
    //[TestMethod()] public void QpFromQ_ForNeg211Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-211, 63), new Base(2)), 2, -211, 63, -397, 504);
    //[TestMethod()] public void QpFromQ_ForNeg211Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-211, 126), new Base(2)), 2, -211, 126, -397, 252);
    //[TestMethod()] public void QpFromQ_ForNeg211Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-211, 252), new Base(2)), 2, -211, 252, -397, 126);
    //[TestMethod()] public void QpFromQ_ForNeg212Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-212, 63), new Base(2)), 2, -212, 63, -43, 252);
    //[TestMethod()] public void QpFromQ_ForNeg212Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-212, 127), new Base(2)), 2, -212, 127, -43, 254);
    //[TestMethod()] public void QpFromQ_ForNeg212Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-212, 255), new Base(2)), 2, -212, 255, -43, 255);
    //[TestMethod()] public void QpFromQ_ForNeg212Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-212, 511), new Base(2)), 2, -212, 511, -86, 511);
    //[TestMethod()] public void QpFromQ_ForNeg213Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-213, 127), new Base(2)), 2, -213, 127, -339, 508);
    //[TestMethod()] public void QpFromQ_ForNeg213Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-213, 254), new Base(2)), 2, -213, 254, -339, 254);
    //[TestMethod()] public void QpFromQ_ForNeg213Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-213, 508), new Base(2)), 2, -213, 508, -339, 127);
    //[TestMethod()] public void QpFromQ_ForNeg214Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-214, 127), new Base(2)), 2, -214, 127, -107, 254);
    //[TestMethod()] public void QpFromQ_ForNeg216Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-216, 31), new Base(2)), 2, -216, 31, -27, 248);
    //[TestMethod()] public void QpFromQ_ForNeg216Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-216, 127), new Base(2)), 2, -216, 127, -27, 254);
    //[TestMethod()] public void QpFromQ_ForNeg216Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-216, 511), new Base(2)), 2, -216, 511, -54, 511);
    //[TestMethod()] public void QpFromQ_For218Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(218, 63), new Base(2)), 2, 218, 63, 199, 504);
    //[TestMethod()] public void QpFromQ_ForNeg218Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-218, 127), new Base(2)), 2, -218, 127, -91, 254);
    //[TestMethod()] public void QpFromQ_ForNeg218Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-218, 255), new Base(2)), 2, -218, 255, -91, 255);
    //[TestMethod()] public void QpFromQ_ForNeg218Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-218, 511), new Base(2)), 2, -218, 511, -26, 73);
    //[TestMethod()] public void QpFromQ_For220Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(220, 63), new Base(2)), 2, 220, 63, 71, 504);
    //[TestMethod()] public void QpFromQ_For221Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(221, 127), new Base(2)), 2, 221, 127, 391, 508);
    //[TestMethod()] public void QpFromQ_For221Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(221, 254), new Base(2)), 2, 221, 254, 391, 254);
    //[TestMethod()] public void QpFromQ_For221Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(221, 508), new Base(2)), 2, 221, 508, 391, 127);
    //[TestMethod()] public void QpFromQ_For222Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(222, 127), new Base(2)), 2, 222, 127, 135, 508);
    //[TestMethod()] public void QpFromQ_For223Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(223, 255), new Base(2)), 2, 223, 255, 263, 510);
    //[TestMethod()] public void QpFromQ_For223Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(223, 510), new Base(2)), 2, 223, 510, 263, 255);
    //[TestMethod()] public void QpFromQ_For223Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(223, 1020), new Base(2)), 2, 223, 1020, 526, 255);
    //[TestMethod()] public void QpFromQ_ForNeg224Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-224, 31), new Base(2)), 2, -224, 31, -7, 248);
    //[TestMethod()] public void QpFromQ_ForNeg224Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-224, 127), new Base(2)), 2, -224, 127, -7, 254);
    //[TestMethod()] public void QpFromQ_ForNeg224Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-224, 255), new Base(2)), 2, -224, 255, -7, 255);
    //[TestMethod()] public void QpFromQ_ForNeg225Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-225, 127), new Base(2)), 2, -225, 127, -267, 508);
    //[TestMethod()] public void QpFromQ_ForNeg225Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-225, 254), new Base(2)), 2, -225, 254, -267, 254);
    //[TestMethod()] public void QpFromQ_ForNeg225Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-225, 508), new Base(2)), 2, -225, 508, -267, 127);
    //[TestMethod()] public void QpFromQ_ForNeg226Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-226, 63), new Base(2)), 2, -226, 63, -139, 504);
    //[TestMethod()] public void QpFromQ_ForNeg226Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-226, 127), new Base(2)), 2, -226, 127, -71, 254);
    //[TestMethod()] public void QpFromQ_ForNeg227Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-227, 63), new Base(2)), 2, -227, 63, -389, 504);
    //[TestMethod()] public void QpFromQ_ForNeg227Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-227, 126), new Base(2)), 2, -227, 126, -389, 252);
    //[TestMethod()] public void QpFromQ_ForNeg227Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-227, 252), new Base(2)), 2, -227, 252, -389, 126);
    //[TestMethod()] public void QpFromQ_ForNeg232Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-232, 31), new Base(2)), 2, -232, 31, -23, 248);
    //[TestMethod()] public void QpFromQ_ForNeg232Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-232, 63), new Base(2)), 2, -232, 63, -23, 252);
    //[TestMethod()] public void QpFromQ_ForNeg232Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-232, 127), new Base(2)), 2, -232, 127, -23, 254);
    //[TestMethod()] public void QpFromQ_ForNeg232Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-232, 255), new Base(2)), 2, -232, 255, -23, 255);
    //[TestMethod()] public void QpFromQ_ForNeg232Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-232, 511), new Base(2)), 2, -232, 511, -46, 511);
    //[TestMethod()] public void QpFromQ_For233Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(233, 63), new Base(2)), 2, 233, 63, 463, 504);
    //[TestMethod()] public void QpFromQ_For233Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(233, 126), new Base(2)), 2, 233, 126, 463, 252);
    //[TestMethod()] public void QpFromQ_For233Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(233, 252), new Base(2)), 2, 233, 252, 463, 126);
    //[TestMethod()] public void QpFromQ_ForNeg234Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-234, 127), new Base(2)), 2, -234, 127, -87, 254);
    //[TestMethod()] public void QpFromQ_ForNeg234Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-234, 511), new Base(2)), 2, -234, 511, -174, 511);
    //[TestMethod()] public void QpFromQ_For235Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(235, 63), new Base(2)), 2, 235, 63, 335, 504);
    //[TestMethod()] public void QpFromQ_For235Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(235, 126), new Base(2)), 2, 235, 126, 335, 252);
    //[TestMethod()] public void QpFromQ_For235Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(235, 252), new Base(2)), 2, 235, 252, 335, 126);
    //[TestMethod()] public void QpFromQ_For236Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(236, 63), new Base(2)), 2, 236, 63, 79, 504);
    //[TestMethod()] public void QpFromQ_For237Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(237, 127), new Base(2)), 2, 237, 127, 399, 508);
    //[TestMethod()] public void QpFromQ_For237Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(237, 254), new Base(2)), 2, 237, 254, 399, 254);
    //[TestMethod()] public void QpFromQ_For237Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(237, 508), new Base(2)), 2, 237, 508, 399, 127);
    //[TestMethod()] public void QpFromQ_For238Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(238, 127), new Base(2)), 2, 238, 127, 143, 508);
    //[TestMethod()] public void QpFromQ_For239Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(239, 255), new Base(2)), 2, 239, 255, 271, 510);
    //[TestMethod()] public void QpFromQ_For239Div510_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(239, 510), new Base(2)), 2, 239, 510, 271, 255);
    //[TestMethod()] public void QpFromQ_For239Div1020_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(239, 1020), new Base(2)), 2, 239, 1020, 542, 255);
    //[TestMethod()] public void QpFromQ_ForNeg240Div31_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-240, 31), new Base(2)), 2, -240, 31, -15, 248);
    //[TestMethod()] public void QpFromQ_ForNeg240Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-240, 127), new Base(2)), 2, -240, 127, -15, 254);
    //[TestMethod()] public void QpFromQ_ForNeg240Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-240, 511), new Base(2)), 2, -240, 511, -30, 511);
    //[TestMethod()] public void QpFromQ_ForNeg241Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-241, 63), new Base(2)), 2, -241, 63, -277, 504);
    //[TestMethod()] public void QpFromQ_ForNeg241Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-241, 126), new Base(2)), 2, -241, 126, -277, 252);
    //[TestMethod()] public void QpFromQ_ForNeg241Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-241, 127), new Base(2)), 2, -241, 127, -283, 508);
    //[TestMethod()] public void QpFromQ_For241Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(241, 127), new Base(2)), 2, 241, 127, 479, 508);
    //[TestMethod()] public void QpFromQ_ForNeg241Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-241, 252), new Base(2)), 2, -241, 252, -277, 126);
    //[TestMethod()] public void QpFromQ_ForNeg241Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-241, 254), new Base(2)), 2, -241, 254, -283, 254);
    //[TestMethod()] public void QpFromQ_For241Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(241, 254), new Base(2)), 2, 241, 254, 479, 254);
    //[TestMethod()] public void QpFromQ_ForNeg241Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-241, 508), new Base(2)), 2, -241, 508, -283, 127);
    //[TestMethod()] public void QpFromQ_For241Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(241, 508), new Base(2)), 2, 241, 508, 479, 127);
    //[TestMethod()] public void QpFromQ_ForNeg242Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-242, 63), new Base(2)), 2, -242, 63, -155, 504);
    //[TestMethod()] public void QpFromQ_For242Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(242, 127), new Base(2)), 2, 242, 127, 223, 508);
    //[TestMethod()] public void QpFromQ_ForNeg244Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-244, 127), new Base(2)), 2, -244, 127, -47, 254);
    //[TestMethod()] public void QpFromQ_ForNeg244Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-244, 255), new Base(2)), 2, -244, 255, -47, 255);
    //[TestMethod()] public void QpFromQ_ForNeg244Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-244, 511), new Base(2)), 2, -244, 511, -94, 511);
    //[TestMethod()] public void QpFromQ_ForNeg245Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-245, 127), new Base(2)), 2, -245, 127, -347, 508);
    //[TestMethod()] public void QpFromQ_ForNeg245Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-245, 254), new Base(2)), 2, -245, 254, -347, 254);
    //[TestMethod()] public void QpFromQ_ForNeg245Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-245, 508), new Base(2)), 2, -245, 508, -347, 127);
    //[TestMethod()] public void QpFromQ_ForNeg246Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-246, 127), new Base(2)), 2, -246, 127, -111, 254);
    //[TestMethod()] public void QpFromQ_For250Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(250, 63), new Base(2)), 2, 250, 63, 191, 504);
    //[TestMethod()] public void QpFromQ_ForNeg250Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-250, 127), new Base(2)), 2, -250, 127, -95, 254);
    //[TestMethod()] public void QpFromQ_ForNeg250Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-250, 511), new Base(2)), 2, -250, 511, -190, 511);
    //[TestMethod()] public void QpFromQ_For251Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(251, 63), new Base(2)), 2, 251, 63, 319, 504);
    //[TestMethod()] public void QpFromQ_For251Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(251, 126), new Base(2)), 2, 251, 126, 319, 252);
    //[TestMethod()] public void QpFromQ_For251Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(251, 252), new Base(2)), 2, 251, 252, 319, 126);
    //[TestMethod()] public void QpFromQ_For253Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(253, 127), new Base(2)), 2, 253, 127, 383, 508);
    //[TestMethod()] public void QpFromQ_For253Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(253, 254), new Base(2)), 2, 253, 254, 383, 254);
    //[TestMethod()] public void QpFromQ_For253Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(253, 508), new Base(2)), 2, 253, 508, 383, 127);
    //[TestMethod()] public void QpFromQ_ForNeg256Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-256, 63), new Base(2)), 2, -256, 63, -1, 504);
    //[TestMethod()] public void QpFromQ_ForNeg256Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-256, 127), new Base(2)), 2, -256, 127, -1, 508);
    //[TestMethod()] public void QpFromQ_ForNeg256Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-256, 255), new Base(2)), 2, -256, 255, -1, 510);
    //[TestMethod()] public void QpFromQ_ForNeg256Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-256, 511), new Base(2)), 2, -256, 511, -1, 511);
    //[TestMethod()] public void QpFromQ_ForNeg257Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-257, 63), new Base(2)), 2, -257, 63, -257, 504);
    //[TestMethod()] public void QpFromQ_ForNeg257Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-257, 126), new Base(2)), 2, -257, 126, -257, 252);
    //[TestMethod()] public void QpFromQ_ForNeg257Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-257, 127), new Base(2)), 2, -257, 127, -257, 508);
    //[TestMethod()] public void QpFromQ_ForNeg257Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-257, 252), new Base(2)), 2, -257, 252, -257, 126);
    //[TestMethod()] public void QpFromQ_ForNeg257Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-257, 254), new Base(2)), 2, -257, 254, -257, 254);
    //[TestMethod()] public void QpFromQ_ForNeg257Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-257, 508), new Base(2)), 2, -257, 508, -257, 127);
    //[TestMethod()] public void QpFromQ_For265Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(265, 63), new Base(2)), 2, 265, 63, 467, 504);
    //[TestMethod()] public void QpFromQ_For265Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(265, 126), new Base(2)), 2, 265, 126, 467, 252);
    //[TestMethod()] public void QpFromQ_For265Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(265, 127), new Base(2)), 2, 265, 127, 473, 508);
    //[TestMethod()] public void QpFromQ_For265Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(265, 252), new Base(2)), 2, 265, 252, 467, 126);
    //[TestMethod()] public void QpFromQ_For265Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(265, 254), new Base(2)), 2, 265, 254, 473, 254);
    //[TestMethod()] public void QpFromQ_For265Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(265, 508), new Base(2)), 2, 265, 508, 473, 127);
    //[TestMethod()] public void QpFromQ_ForNeg268Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-268, 127), new Base(2)), 2, -268, 127, -97, 508);
    //[TestMethod()] public void QpFromQ_ForNeg268Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-268, 255), new Base(2)), 2, -268, 255, -97, 510);
    //[TestMethod()] public void QpFromQ_ForNeg268Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-268, 511), new Base(2)), 2, -268, 511, -97, 511);
    //[TestMethod()] public void QpFromQ_ForNeg269Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-269, 127), new Base(2)), 2, -269, 127, -353, 508);
    //[TestMethod()] public void QpFromQ_For269Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(269, 127), new Base(2)), 2, 269, 127, 409, 508);
    //[TestMethod()] public void QpFromQ_ForNeg269Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-269, 254), new Base(2)), 2, -269, 254, -353, 254);
    //[TestMethod()] public void QpFromQ_For269Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(269, 254), new Base(2)), 2, 269, 254, 409, 254);
    //[TestMethod()] public void QpFromQ_ForNeg269Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-269, 508), new Base(2)), 2, -269, 508, -353, 127);
    //[TestMethod()] public void QpFromQ_For269Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(269, 508), new Base(2)), 2, 269, 508, 409, 127);
    //[TestMethod()] public void QpFromQ_ForNeg272Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-272, 63), new Base(2)), 2, -272, 63, -17, 504);
    //[TestMethod()] public void QpFromQ_ForNeg272Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-272, 127), new Base(2)), 2, -272, 127, -17, 508);
    //[TestMethod()] public void QpFromQ_ForNeg272Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-272, 511), new Base(2)), 2, -272, 511, -17, 511);
    //[TestMethod()] public void QpFromQ_ForNeg273Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-273, 127), new Base(2)), 2, -273, 127, -273, 508);
    //[TestMethod()] public void QpFromQ_ForNeg273Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-273, 254), new Base(2)), 2, -273, 254, -273, 254);
    //[TestMethod()] public void QpFromQ_ForNeg273Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-273, 508), new Base(2)), 2, -273, 508, -273, 127);
    //[TestMethod()] public void QpFromQ_ForNeg274Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-274, 63), new Base(2)), 2, -274, 63, -145, 504);
    //[TestMethod()] public void QpFromQ_ForNeg275Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-275, 63), new Base(2)), 2, -275, 63, -401, 504);
    //[TestMethod()] public void QpFromQ_ForNeg275Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-275, 126), new Base(2)), 2, -275, 126, -401, 252);
    //[TestMethod()] public void QpFromQ_ForNeg275Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-275, 252), new Base(2)), 2, -275, 252, -401, 126);
    //[TestMethod()] public void QpFromQ_For281Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(281, 63), new Base(2)), 2, 281, 63, 451, 504);
    //[TestMethod()] public void QpFromQ_For281Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(281, 126), new Base(2)), 2, 281, 126, 451, 252);
    //[TestMethod()] public void QpFromQ_For281Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(281, 252), new Base(2)), 2, 281, 252, 451, 126);
    //[TestMethod()] public void QpFromQ_For283Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(283, 63), new Base(2)), 2, 283, 63, 323, 504);
    //[TestMethod()] public void QpFromQ_For283Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(283, 126), new Base(2)), 2, 283, 126, 323, 252);
    //[TestMethod()] public void QpFromQ_For283Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(283, 252), new Base(2)), 2, 283, 252, 323, 126);
    //[TestMethod()] public void QpFromQ_For285Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(285, 127), new Base(2)), 2, 285, 127, 393, 508);
    //[TestMethod()] public void QpFromQ_For285Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(285, 254), new Base(2)), 2, 285, 254, 393, 254);
    //[TestMethod()] public void QpFromQ_For285Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(285, 508), new Base(2)), 2, 285, 508, 393, 127);
    //[TestMethod()] public void QpFromQ_ForNeg288Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-288, 127), new Base(2)), 2, -288, 127, -9, 508);
    //[TestMethod()] public void QpFromQ_ForNeg288Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-288, 511), new Base(2)), 2, -288, 511, -9, 511);
    //[TestMethod()] public void QpFromQ_ForNeg289Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-289, 63), new Base(2)), 2, -289, 63, -265, 504);
    //[TestMethod()] public void QpFromQ_ForNeg289Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-289, 126), new Base(2)), 2, -289, 126, -265, 252);
    //[TestMethod()] public void QpFromQ_ForNeg289Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-289, 127), new Base(2)), 2, -289, 127, -265, 508);
    //[TestMethod()] public void QpFromQ_ForNeg289Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-289, 252), new Base(2)), 2, -289, 252, -265, 126);
    //[TestMethod()] public void QpFromQ_ForNeg289Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-289, 254), new Base(2)), 2, -289, 254, -265, 254);
    //[TestMethod()] public void QpFromQ_ForNeg289Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-289, 508), new Base(2)), 2, -289, 508, -265, 127);
    //[TestMethod()] public void QpFromQ_ForNeg290Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-290, 63), new Base(2)), 2, -290, 63, -137, 504);
    //[TestMethod()] public void QpFromQ_For298Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(298, 63), new Base(2)), 2, 298, 63, 209, 504);
    //[TestMethod()] public void QpFromQ_For299Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(299, 63), new Base(2)), 2, 299, 63, 331, 504);
    //[TestMethod()] public void QpFromQ_For299Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(299, 126), new Base(2)), 2, 299, 126, 331, 252);
    //[TestMethod()] public void QpFromQ_For299Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(299, 252), new Base(2)), 2, 299, 252, 331, 126);
    //[TestMethod()] public void QpFromQ_For301Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(301, 127), new Base(2)), 2, 301, 127, 401, 508);
    //[TestMethod()] public void QpFromQ_For301Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(301, 254), new Base(2)), 2, 301, 254, 401, 254);
    //[TestMethod()] public void QpFromQ_For301Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(301, 508), new Base(2)), 2, 301, 508, 401, 127);
    //[TestMethod()] public void QpFromQ_ForNeg304Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-304, 63), new Base(2)), 2, -304, 63, -25, 504);
    //[TestMethod()] public void QpFromQ_ForNeg304Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-304, 127), new Base(2)), 2, -304, 127, -25, 508);
    //[TestMethod()] public void QpFromQ_ForNeg304Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-304, 255), new Base(2)), 2, -304, 255, -5, 102);
    //[TestMethod()] public void QpFromQ_ForNeg304Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-304, 511), new Base(2)), 2, -304, 511, -25, 511);
    //[TestMethod()] public void QpFromQ_ForNeg305Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-305, 63), new Base(2)), 2, -305, 63, -281, 504);
    //[TestMethod()] public void QpFromQ_ForNeg305Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-305, 126), new Base(2)), 2, -305, 126, -281, 252);
    //[TestMethod()] public void QpFromQ_ForNeg305Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-305, 127), new Base(2)), 2, -305, 127, -281, 508);
    //[TestMethod()] public void QpFromQ_ForNeg305Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-305, 252), new Base(2)), 2, -305, 252, -281, 126);
    //[TestMethod()] public void QpFromQ_ForNeg305Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-305, 254), new Base(2)), 2, -305, 254, -281, 254);
    //[TestMethod()] public void QpFromQ_ForNeg305Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-305, 508), new Base(2)), 2, -305, 508, -281, 127);
    //[TestMethod()] public void QpFromQ_ForNeg308Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-308, 127), new Base(2)), 2, -308, 127, -89, 508);
    //[TestMethod()] public void QpFromQ_ForNeg308Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-308, 255), new Base(2)), 2, -308, 255, -89, 510);
    //[TestMethod()] public void QpFromQ_ForNeg309Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-309, 127), new Base(2)), 2, -309, 127, -345, 508);
    //[TestMethod()] public void QpFromQ_ForNeg309Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-309, 254), new Base(2)), 2, -309, 254, -345, 254);
    //[TestMethod()] public void QpFromQ_ForNeg309Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-309, 508), new Base(2)), 2, -309, 508, -345, 127);
    //[TestMethod()] public void QpFromQ_For313Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(313, 63), new Base(2)), 2, 313, 63, 443, 504);
    //[TestMethod()] public void QpFromQ_For313Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(313, 126), new Base(2)), 2, 313, 126, 443, 252);
    //[TestMethod()] public void QpFromQ_For313Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(313, 252), new Base(2)), 2, 313, 252, 443, 126);
    //[TestMethod()] public void QpFromQ_For314Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(314, 63), new Base(2)), 2, 314, 63, 193, 504);
    //[TestMethod()] public void QpFromQ_For317Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(317, 127), new Base(2)), 2, 317, 127, 385, 508);
    //[TestMethod()] public void QpFromQ_For317Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(317, 254), new Base(2)), 2, 317, 254, 385, 254);
    //[TestMethod()] public void QpFromQ_For317Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(317, 508), new Base(2)), 2, 317, 508, 385, 127);
    //[TestMethod()] public void QpFromQ_ForNeg320Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-320, 63), new Base(2)), 2, -320, 63, -5, 504);
    //[TestMethod()] public void QpFromQ_ForNeg320Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-320, 127), new Base(2)), 2, -320, 127, -5, 508);
    //[TestMethod()] public void QpFromQ_ForNeg320Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-320, 511), new Base(2)), 2, -320, 511, -5, 511);
    //[TestMethod()] public void QpFromQ_ForNeg321Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-321, 127), new Base(2)), 2, -321, 127, -261, 508);
    //[TestMethod()] public void QpFromQ_ForNeg321Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-321, 254), new Base(2)), 2, -321, 254, -261, 254);
    //[TestMethod()] public void QpFromQ_ForNeg321Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-321, 508), new Base(2)), 2, -321, 508, -261, 127);
    //[TestMethod()] public void QpFromQ_For329Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(329, 127), new Base(2)), 2, 329, 127, 469, 508);
    //[TestMethod()] public void QpFromQ_For329Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(329, 254), new Base(2)), 2, 329, 254, 469, 254);
    //[TestMethod()] public void QpFromQ_For329Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(329, 508), new Base(2)), 2, 329, 508, 469, 127);
    //[TestMethod()] public void QpFromQ_For333Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(333, 127), new Base(2)), 2, 333, 127, 405, 508);
    //[TestMethod()] public void QpFromQ_For333Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(333, 254), new Base(2)), 2, 333, 254, 405, 254);
    //[TestMethod()] public void QpFromQ_For333Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(333, 508), new Base(2)), 2, 333, 508, 405, 127);
    //[TestMethod()] public void QpFromQ_ForNeg336Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-336, 127), new Base(2)), 2, -336, 127, -21, 508);
    //[TestMethod()] public void QpFromQ_ForNeg337Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-337, 63), new Base(2)), 2, -337, 63, -271, 504);
    //[TestMethod()] public void QpFromQ_ForNeg337Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-337, 126), new Base(2)), 2, -337, 126, -271, 252);
    //[TestMethod()] public void QpFromQ_ForNeg337Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-337, 127), new Base(2)), 2, -337, 127, -277, 508);
    //[TestMethod()] public void QpFromQ_ForNeg337Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-337, 252), new Base(2)), 2, -337, 252, -271, 126);
    //[TestMethod()] public void QpFromQ_ForNeg337Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-337, 254), new Base(2)), 2, -337, 254, -277, 254);
    //[TestMethod()] public void QpFromQ_ForNeg337Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-337, 508), new Base(2)), 2, -337, 508, -277, 127);
    //[TestMethod()] public void QpFromQ_ForNeg338Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-338, 63), new Base(2)), 2, -338, 63, -149, 504);
    //[TestMethod()] public void QpFromQ_ForNeg340Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-340, 127), new Base(2)), 2, -340, 127, -85, 508);
    //[TestMethod()] public void QpFromQ_ForNeg340Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-340, 511), new Base(2)), 2, -340, 511, -85, 511);
    //[TestMethod()] public void QpFromQ_ForNeg341Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-341, 127), new Base(2)), 2, -341, 127, -341, 508);
    //[TestMethod()] public void QpFromQ_ForNeg341Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-341, 254), new Base(2)), 2, -341, 254, -341, 254);
    //[TestMethod()] public void QpFromQ_ForNeg341Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-341, 508), new Base(2)), 2, -341, 508, -341, 127);
    //[TestMethod()] public void QpFromQ_For346Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(346, 63), new Base(2)), 2, 346, 63, 197, 504);
    //[TestMethod()] public void QpFromQ_For349Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(349, 127), new Base(2)), 2, 349, 127, 389, 508);
    //[TestMethod()] public void QpFromQ_For349Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(349, 254), new Base(2)), 2, 349, 254, 389, 254);
    //[TestMethod()] public void QpFromQ_For349Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(349, 508), new Base(2)), 2, 349, 508, 389, 127);
    //[TestMethod()] public void QpFromQ_ForNeg352Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-352, 63), new Base(2)), 2, -352, 63, -13, 504);
    //[TestMethod()] public void QpFromQ_ForNeg352Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-352, 127), new Base(2)), 2, -352, 127, -13, 508);
    //[TestMethod()] public void QpFromQ_ForNeg352Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-352, 255), new Base(2)), 2, -352, 255, -13, 510);
    //[TestMethod()] public void QpFromQ_ForNeg352Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-352, 511), new Base(2)), 2, -352, 511, -13, 511);
    //[TestMethod()] public void QpFromQ_ForNeg353Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-353, 63), new Base(2)), 2, -353, 63, -263, 504);
    //[TestMethod()] public void QpFromQ_ForNeg353Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-353, 126), new Base(2)), 2, -353, 126, -263, 252);
    //[TestMethod()] public void QpFromQ_ForNeg353Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-353, 127), new Base(2)), 2, -353, 127, -269, 508);
    //[TestMethod()] public void QpFromQ_ForNeg353Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-353, 252), new Base(2)), 2, -353, 252, -263, 126);
    //[TestMethod()] public void QpFromQ_ForNeg353Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-353, 254), new Base(2)), 2, -353, 254, -269, 254);
    //[TestMethod()] public void QpFromQ_ForNeg353Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-353, 508), new Base(2)), 2, -353, 508, -269, 127);
    //[TestMethod()] public void QpFromQ_For361Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(361, 63), new Base(2)), 2, 361, 63, 461, 504);
    //[TestMethod()] public void QpFromQ_For361Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(361, 126), new Base(2)), 2, 361, 126, 461, 252);
    //[TestMethod()] public void QpFromQ_For361Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(361, 252), new Base(2)), 2, 361, 252, 461, 126);
    //[TestMethod()] public void QpFromQ_For362Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(362, 63), new Base(2)), 2, 362, 63, 205, 504);
    //[TestMethod()] public void QpFromQ_For365Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(365, 127), new Base(2)), 2, 365, 127, 397, 508);
    //[TestMethod()] public void QpFromQ_For365Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(365, 254), new Base(2)), 2, 365, 254, 397, 254);
    //[TestMethod()] public void QpFromQ_For365Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(365, 508), new Base(2)), 2, 365, 508, 397, 127);
    //[TestMethod()] public void QpFromQ_ForNeg368Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-368, 63), new Base(2)), 2, -368, 63, -29, 504);
    //[TestMethod()] public void QpFromQ_ForNeg368Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-368, 127), new Base(2)), 2, -368, 127, -29, 508);
    //[TestMethod()] public void QpFromQ_ForNeg368Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-368, 255), new Base(2)), 2, -368, 255, -29, 510);
    //[TestMethod()] public void QpFromQ_ForNeg368Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-368, 511), new Base(2)), 2, -368, 511, -29, 511);
    //[TestMethod()] public void QpFromQ_For369Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(369, 127), new Base(2)), 2, 369, 127, 477, 508);
    //[TestMethod()] public void QpFromQ_For369Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(369, 254), new Base(2)), 2, 369, 254, 477, 254);
    //[TestMethod()] public void QpFromQ_For369Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(369, 508), new Base(2)), 2, 369, 508, 477, 127);
    //[TestMethod()] public void QpFromQ_ForNeg372Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-372, 127), new Base(2)), 2, -372, 127, -93, 508);
    //[TestMethod()] public void QpFromQ_ForNeg372Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-372, 511), new Base(2)), 2, -372, 511, -93, 511);
    //[TestMethod()] public void QpFromQ_ForNeg373Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-373, 127), new Base(2)), 2, -373, 127, -349, 508);
    //[TestMethod()] public void QpFromQ_ForNeg373Div254_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-373, 254), new Base(2)), 2, -373, 254, -349, 254);
    //[TestMethod()] public void QpFromQ_ForNeg373Div508_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-373, 508), new Base(2)), 2, -373, 508, -349, 127);
    //[TestMethod()] public void QpFromQ_For377Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(377, 63), new Base(2)), 2, 377, 63, 445, 504);
    //[TestMethod()] public void QpFromQ_For377Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(377, 126), new Base(2)), 2, 377, 126, 445, 252);
    //[TestMethod()] public void QpFromQ_For377Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(377, 252), new Base(2)), 2, 377, 252, 445, 126);
    //[TestMethod()] public void QpFromQ_ForNeg384Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-384, 127), new Base(2)), 2, -384, 127, -3, 508);
    //[TestMethod()] public void QpFromQ_ForNeg384Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-384, 511), new Base(2)), 2, -384, 511, -3, 511);
    //[TestMethod()] public void QpFromQ_ForNeg396Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-396, 127), new Base(2)), 2, -396, 127, -99, 508);
    //[TestMethod()] public void QpFromQ_ForNeg396Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-396, 511), new Base(2)), 2, -396, 511, -99, 511);
    //[TestMethod()] public void QpFromQ_ForNeg400Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-400, 63), new Base(2)), 2, -400, 63, -19, 504);
    //[TestMethod()] public void QpFromQ_ForNeg400Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-400, 127), new Base(2)), 2, -400, 127, -19, 508);
    //[TestMethod()] public void QpFromQ_ForNeg400Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-400, 511), new Base(2)), 2, -400, 511, -19, 511);
    //[TestMethod()] public void QpFromQ_ForNeg401Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-401, 63), new Base(2)), 2, -401, 63, -275, 504);
    //[TestMethod()] public void QpFromQ_ForNeg401Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-401, 126), new Base(2)), 2, -401, 126, -275, 252);
    //[TestMethod()] public void QpFromQ_ForNeg401Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-401, 252), new Base(2)), 2, -401, 252, -275, 126);
    //[TestMethod()] public void QpFromQ_For409Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(409, 63), new Base(2)), 2, 409, 63, 449, 504);
    //[TestMethod()] public void QpFromQ_For409Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(409, 126), new Base(2)), 2, 409, 126, 449, 252);
    //[TestMethod()] public void QpFromQ_For409Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(409, 252), new Base(2)), 2, 409, 252, 449, 126);
    //[TestMethod()] public void QpFromQ_ForNeg416Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-416, 63), new Base(2)), 2, -416, 63, -11, 504);
    //[TestMethod()] public void QpFromQ_ForNeg416Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-416, 127), new Base(2)), 2, -416, 127, -11, 508);
    //[TestMethod()] public void QpFromQ_ForNeg416Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-416, 255), new Base(2)), 2, -416, 255, -11, 510);
    //[TestMethod()] public void QpFromQ_ForNeg416Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-416, 511), new Base(2)), 2, -416, 511, -11, 511);
    //[TestMethod()] public void QpFromQ_For425Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(425, 63), new Base(2)), 2, 425, 63, 457, 504);
    //[TestMethod()] public void QpFromQ_For425Div126_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(425, 126), new Base(2)), 2, 425, 126, 457, 252);
    //[TestMethod()] public void QpFromQ_For425Div252_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(425, 252), new Base(2)), 2, 425, 252, 457, 126);
    //[TestMethod()] public void QpFromQ_ForNeg432Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-432, 127), new Base(2)), 2, -432, 127, -27, 508);
    //[TestMethod()] public void QpFromQ_ForNeg432Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-432, 511), new Base(2)), 2, -432, 511, -27, 511);
    //[TestMethod()] public void QpFromQ_ForNeg436Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-436, 127), new Base(2)), 2, -436, 127, -91, 508);
    //[TestMethod()] public void QpFromQ_ForNeg436Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-436, 255), new Base(2)), 2, -436, 255, -91, 510);
    //[TestMethod()] public void QpFromQ_ForNeg436Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-436, 511), new Base(2)), 2, -436, 511, -13, 73);
    //[TestMethod()] public void QpFromQ_ForNeg448Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-448, 127), new Base(2)), 2, -448, 127, -7, 508);
    //[TestMethod()] public void QpFromQ_ForNeg448Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-448, 255), new Base(2)), 2, -448, 255, -7, 510);
    //[TestMethod()] public void QpFromQ_ForNeg464Div63_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-464, 63), new Base(2)), 2, -464, 63, -23, 504);
    //[TestMethod()] public void QpFromQ_ForNeg464Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-464, 127), new Base(2)), 2, -464, 127, -23, 508);
    //[TestMethod()] public void QpFromQ_ForNeg464Div255_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-464, 255), new Base(2)), 2, -464, 255, -23, 510);
    //[TestMethod()] public void QpFromQ_ForNeg464Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-464, 511), new Base(2)), 2, -464, 511, -23, 511);
    //[TestMethod()] public void QpFromQ_ForNeg468Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-468, 127), new Base(2)), 2, -468, 127, -87, 508);
    //[TestMethod()] public void QpFromQ_ForNeg468Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-468, 511), new Base(2)), 2, -468, 511, -87, 511);
    //[TestMethod()] public void QpFromQ_ForNeg480Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-480, 127), new Base(2)), 2, -480, 127, -15, 508);
    //[TestMethod()] public void QpFromQ_ForNeg480Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-480, 511), new Base(2)), 2, -480, 511, -15, 511);
    //[TestMethod()] public void QpFromQ_ForNeg500Div127_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-500, 127), new Base(2)), 2, -500, 127, -95, 508);
    //[TestMethod()] public void QpFromQ_ForNeg500Div511_Base2_IsCorrect() => QpFromQ_IsCorrect(new Qp(new Q(-500, 511), new Base(2)), 2, -500, 511, -95, 511);

    //#endregion Qp FromQ Q


    #region Qp From Q

    private static void AssertQpFromQ_ReturnsCorrectQp(string expStringExpanded, BigInteger expNumerator, BigInteger expDenominator, BigInteger expGeneratorNumerator, BigInteger expectedGeneratorDenominator, int expFirstExponent, Qp actual)
    {
        Assert.AreEqual(expNumerator, actual.Numerator);
        Assert.AreEqual(expDenominator, actual.Denominator);
        Assert.AreEqual(expStringExpanded, actual.ToStringExpanded(32));
        Assert.AreEqual(expFirstExponent, actual.FirstExponent);
        Assert.AreEqual(expGeneratorNumerator, actual.Generator.Numerator);
        Assert.AreEqual(expectedGeneratorDenominator, actual.Generator.Denominator);
        Assert.AreEqual(actual.Sign, -actual.Generator.Sign);
    }

    [TestMethod()]
    public void QpFromQ_For0_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(0, 1, 2);
        AssertQpFromQ_ReturnsCorrectQp(".00000000000000000000000000000000", 0, 1, 0, 1, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_For1_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(1, 1, 2);  
        AssertQpFromQ_ReturnsCorrectQp(".10000000000000000000000000000000", 1, 1, 1, 1, 0, actual);
    }

    [TestMethod()]
    public void QpFromQForNeg1_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-1, 1, 2);
        AssertQpFromQ_ReturnsCorrectQp(".11111111111111111111111111111111", -1, 1, 1, 1, 0, actual);

    }

    [TestMethod()]
    public void QpFromQ_For1Div2_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(1, 2, 2);
        AssertQpFromQ_ReturnsCorrectQp("1.0000000000000000000000000000000", 1, 2, -1, 1, -1, actual);
    }

    [TestMethod()]
    public void QpFromQ_ForNeg1Div2_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-1, 2, 2);
        AssertQpFromQ_ReturnsCorrectQp("1.1111111111111111111111111111111", -1, 2, 2, 1, -1, actual);
    }

    [TestMethod()]
    public void QpFromQ_For2_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(2, 1, 2);
        AssertQpFromQ_ReturnsCorrectQp(".01000000000000000000000000000000", 2, 1, -1, 4, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_ForNeg2_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-2, 1, 2);
        AssertQpFromQ_ReturnsCorrectQp(".01111111111111111111111111111111", -2, 1, 1, 2, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_For5_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(5, 1, 2);
        AssertQpFromQ_ReturnsCorrectQp(".10100000000000000000000000000000", 5, 1, -5, 8, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_ForNeg5_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-5, 1, 2);
        AssertQpFromQ_ReturnsCorrectQp(".11011111111111111111111111111111", -5, 1, 7, 8, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_For1Div3_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(1, 3, 2);
        AssertQpFromQ_ReturnsCorrectQp(".11010101010101010101010101010101", 1, 3, -5, 6, 0, actual);

    }

    [TestMethod()]
    public void QpFromQ_ForNeg1Div3_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-1, 3, 2);
        AssertQpFromQ_ReturnsCorrectQp(".10101010101010101010101010101010", -1, 3, 2, 3, 0, actual);
    }


    [TestMethod()]
    public void QpFromQ_For5Div2_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(5, 2, 2);
        AssertQpFromQ_ReturnsCorrectQp("1.0100000000000000000000000000000", 5, 2, -5, 4, -1, actual);
    }


    [TestMethod()]
    public void QpFromQ_ForNeg5Div2_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-5, 2, 2);
        AssertQpFromQ_ReturnsCorrectQp("1.1011111111111111111111111111111", -5, 2, 7, 4, -1, actual);
    }

    [TestMethod()]
    public void QpFromQ_For5Div9_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(5, 9, 2);
        AssertQpFromQ_ReturnsCorrectQp(".10111000111000111000111000111000", 5, 9, -13, 18, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_ForNeg5Div9_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-5, 9, 2);
        AssertQpFromQ_ReturnsCorrectQp(".11000111000111000111000111000111", -5, 9, 7, 9, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_For35Div9_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(35, 9, 2);
        AssertQpFromQ_ReturnsCorrectQp(".11010011100011100011100011100011", 35, 9, -119, 144, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_For35Div18_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(35, 18, 2);
        AssertQpFromQ_ReturnsCorrectQp("1.1010011100011100011100011100011", 35, 18, -119, 72, -1, actual);
    }

    [TestMethod()]
    public void QpFromQ_For23Div3_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(23, 3, 2);
        AssertQpFromQ_ReturnsCorrectQp(".10111010101010101010101010101010", 23, 3, -35, 48, 0, actual);
    }

    [TestMethod()]
    public void QpFromQ_ForNeg23Div3_Base2_ReturnsCorrectQp()
    {
        Qp actual = new Qp(-23, 3, 2);
        AssertQpFromQ_ReturnsCorrectQp(".11000101010101010101010101010101", -23, 3, 37, 48, 0, actual);
    }

    #endregion Qp From Q


    #region Qp From parts

    private static void AssertQpFromParts_ReturnsCorrectQp(BigInteger expectedNumerator, BigInteger expectedDenominator, int firstExponent, Qp actual)
    {
        Assert.AreEqual(expectedNumerator, actual.Numerator);
        Assert.AreEqual(expectedDenominator, actual.Denominator);
        Assert.AreEqual(firstExponent, actual.FirstExponent);
    }
    
    [TestMethod()]
    public void QpFromParts_For0_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 0); //empty
        BaseInt periodicPart = new BaseInt(base_, 0); //empty
        Qp actual = new Qp(preperiodicPart, periodicPart);
        AssertQpFromParts_ReturnsCorrectQp(0, 1, 0, actual);
    }

    [TestMethod()]
    public void QpFromParts_For1_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 1); //1
        BaseInt periodicPart = new BaseInt(base_, 0); //empty
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(1, 1, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg1_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 0); //empty
        BaseInt periodicPart = new BaseInt(base_, 1); //1
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart);
        AssertQpFromParts_ReturnsCorrectQp(-1, 1, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For1Div2_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 1); //1
        BaseInt periodicPart = new BaseInt(base_, 0); //empty
        int firstExponent = -1;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(1, 2, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg1Div2_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 0); //empty
        BaseInt periodicPart = new BaseInt(base_, 1); //1
        int firstExponent = -1;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-1, 2, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For2_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 01, 2); //01
        BaseInt periodicPart = new BaseInt(base_, 0); //empty
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(2, 1, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg2_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = BaseInt.Zero(base_, 1); //0
        BaseInt periodicPart = new BaseInt(base_, 1); //1
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-2, 1, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For5_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 5); //101
        BaseInt periodicPart = new BaseInt(base_, 0); //empty
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(5, 1, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg5_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 6); //110
        BaseInt periodicPart = new BaseInt(base_, 1); //1
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-5, 1, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For1Div3_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 1); //1
        BaseInt periodicPart = new BaseInt(base_, 2); //10
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(1, 3, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg1Div3_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 0); //empty
        BaseInt periodicPart = new BaseInt(base_, 2); //10
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-1, 3, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For5Div2_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 5); //101
        BaseInt periodicPart = new BaseInt(base_, 0); //empty
        int firstExponent = -1;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(5, 2, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg5Div2_Base2_ReturnsCorrectQp()
    {
        int base_ = 2; 
        BaseInt preperiodicPart = new BaseInt(base_, 6); //110
        BaseInt periodicPart = new BaseInt(base_, 1); //1
        int firstExponent = -1;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-5, 2, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For5Div9_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 1); //1
        BaseInt periodicPart = new BaseInt(base_, 28, 6); //011100
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(5, 9, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg5Div9_Base2_ReturnsCorrectQp()
    {
        int base_ = 2; 
        BaseInt preperiodicPart = new BaseInt(base_, 1); //1
        BaseInt periodicPart = new BaseInt(base_, 35); //100011
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-5, 9, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For35Div9_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 13); //1101
        BaseInt periodicPart = new BaseInt(base_, 14, 6); //001110
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(35, 9, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For35Div18_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 13); //1101
        BaseInt periodicPart = new BaseInt(base_, 14, 6); //001110
        int firstExponent = -1;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(35, 18, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_For23Div3_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 11); //1011
        BaseInt periodicPart = new BaseInt(base_, 2); //10
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(23, 3, firstExponent, actual);
    }

    [TestMethod()]
    public void QpFromParts_ForNeg23Div3_Base2_ReturnsCorrectQp()
    {
        int base_ = 2;
        BaseInt preperiodicPart = new BaseInt(base_, 12); //1100
        BaseInt periodicPart = new BaseInt(base_, 1, 2); //01
        int firstExponent = 0;
        Qp actual = new Qp(preperiodicPart, periodicPart, firstExponent);
        AssertQpFromParts_ReturnsCorrectQp(-23, 3, firstExponent, actual);
    }

    #endregion Qp From parts

    #region Reciprocal Coefficients
    //private static void Coefficients_ForReciprocal_ReturnsCorrectSequence(string expected, BigInteger integer, int base_)
    //{
    //    string actual = new Qp(1, integer, base_).ToStringExpanded(coefficientCount: 32);
    //    Assert.AreEqual(expected, actual);
    //}


    //[TestMethod()]
    //public void Coefficients_ForQ1div2_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11111111111111111111111111111112", 2, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div2_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22222222222222222222222222222223", 2, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div3_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10101010101010101010101010101011", 3, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div3_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…31313131313131313131313131313132", 3, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div4_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20202020202020202020202020202021", 4, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div4_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…33333333333333333333333333333334", 4, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div5_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11001100110011001100110011001101", 5, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div5_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21012101210121012101210121012102", 5, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div6_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…40404040404040404040404040404041", 6, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div7_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10110110110110110110110110110111", 7, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div7_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10212010212010212010212010212011", 7, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div7_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…32412032412032412032412032412033", 7, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div8_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21212121212121212121212121212122", 8, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div8_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…41414141414141414141414141414142", 8, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div9_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00111000111000111000111000111001", 9, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div9_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…23421023421023421023421023421024", 9, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div10_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22002200220022002200220022002201", 10, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div11_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10111010001011101000101110100011", 11, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div11_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11220112201122011220112201122012", 11, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div11_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…30423304233042330423304233042331", 11, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div12_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…42424242424242424242424242424243", 12, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div13_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11000100111011000100111011000101", 13, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div13_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20220220220220220220220220220221", 13, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div13_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…43014301430143014301430143014302", 13, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div14_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…01221001221001221001221001221002", 14, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div14_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…13431013431013431013431013431014", 14, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div15_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11101110111011101110111011101111", 15, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div16_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22102210221022102210221022102211", 16, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div16_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…43204320432043204320432043204321", 16, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div17_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11110000111100001111000011110001", 17, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div17_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22110201001120212211020100112022", 17, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div17_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…43231042012134024323104201213403", 17, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div18_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11433011433011433011433011433012", 18, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div19_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00101000011010111100101000011011", 19, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div19_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20122001102100221120122001102101", 19, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div19_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…02303433202303433202303433202304", 19, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div20_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22112211221122112211221122112212", 20, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div21_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00111100111100111100111100111101", 21, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div21_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10434010434010434010434010434011", 21, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div22_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20221202212022120221202212022121", 22, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div22_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…12434124341243412434124341243413", 22, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div23_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11101001101111010011011110100111", 23, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div23_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21211022012212110220122121102202", 23, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div23_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10204133214342403112301020413322", 23, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div24_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…43434343434343434343434343434344", 24, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div25_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11000010100011110101110000101001", 25, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div25_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…12001002011022122021120010020111", 25, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div26_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21221221221221221221221221221222", 26, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div26_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44004400440044004400440044004401", 26, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div27_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…01101000010010111101101000010011", 27, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div27_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…41122004303322440141122004303323", 27, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div28_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00222000222000222000222000222001", 28, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div28_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…31440231440231440231440231440232", 28, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div29_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…01001111011100101100001000110101", 29, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div29_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…01112220012120211100022101020112", 29, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div29_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…12334403211004123344032110041234", 29, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div31_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10111101111011110111101111011111", 31, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div31_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20222010111001202000212111221021", 31, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div31_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…40440440440440440440440440440441", 31, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div32_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22201101222011012220110122201102", 32, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div32_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44102132441021324410213244102133", 32, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div33_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00111110000011111000001111100001", 33, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div33_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…41441101224144110122414411012242", 33, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div34_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22201212000210102220121200021011", 34, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div34_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44113021003314234411302100331424", 34, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div35_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10001010111110001010111110001011", 35, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div35_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20011121222020011121222020011122", 35, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div36_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…30441230441230441230441230441231", 36, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div37_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10010001010011000001101110101101", 37, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div37_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21022000201200222021022000201201", 37, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div37_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…02322404331102003142122040113343", 37, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div38_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21211000201011222021211000201012", 38, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div38_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…23401441323401441323401441323402", 38, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div39_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10010110111110010110111110010111", 39, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div39_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44134413441344134413441344134414", 39, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div40_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22202220222022202220222022202221", 40, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div41_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11000001100011111001110000011001", 41, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div41_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22210001222100012221000122210002", 41, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div41_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…24003011022044143342240030110221", 41, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div42_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…02442002442002442002442002442003", 42, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div43_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00101111101000001011111010000011", 43, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div43_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20220111012000121221202002111211", 43, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div43_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21010401333002423141223434043112", 43, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div44_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21222101102122210110212221011022", 44, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div44_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…03442034420344203442034420344204", 44, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div45_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10100100111110100100111110100101", 45, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div46_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22102011002221020110022210201101", 46, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div46_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…02324314104421201303400232431411", 46, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div47_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…01100111011111010100011011001111", 47, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div47_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20022121122210211101220200221212", 47, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div47_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20304343200231221041114241401013", 47, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div48_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44214421442144214421442144214422", 48, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div49_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00011010000111110101100011010001", 49, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div49_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…22021011102000112212200201211121", 49, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div49_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…23113040201002233414321331404244", 49, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div50_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21000112120122211010210001121202", 50, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div51_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11111010111110101111101011111011", 51, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div51_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44223330320343004422333032034301", 51, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div52_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10222110222110222110222110222111", 52, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div52_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…44224422442244224422442244224423", 52, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div53_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10001100000100110101001000011101", 53, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div53_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00200100011120210101200211220222", 53, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div53_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…32211300213440120142041103122332", 53, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div54_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20311002124133442320311002124134", 54, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div55_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…01011000011011111011010110000111", 55, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div55_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…20101022100022211120201010221001", 55, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div56_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11222111222111222111222111222112", 56, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div56_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…40442340442340442340442340442341", 56, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div57_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10111000001000111110111000001001", 57, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div57_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00414311032232442400414311032233", 57, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div58_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…00202221121021220200011012010021", 58, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div58_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…03414424103002034144241030020342", 58, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div59_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10100000100010101101100011110011", 59, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div59_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10122211212210111201200022020102", 59, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div59_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…32344242004104312303143331022324", 59, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div61_Base2_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…11000001000011001001011100010101", 61, 2);


    //[TestMethod()]
    //public void Coefficients_ForQ1div61_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…10222120001022212000102221200011", 61, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div61_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…30442433411234314002011033210131", 61, 5);


    //[TestMethod()]
    //public void Coefficients_ForQ1div62_Base3_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…21222120020112101000102202110122", 62, 3);


    //[TestMethod()]
    //public void Coefficients_ForQ1div62_Base5_ReturnsCorrectSequence()
    //    => Coefficients_ForReciprocal_ReturnsCorrectSequence("…42442442442442442442442442442443", 62, 5);

    //[TestMethod()]
    //public void Coefficients_ForQ1div697_Base5_ReturnsCorrectSequence()
    //=> Coefficients_ForReciprocal_ReturnsCorrectSequence("…44134122030202423040210244203113", 697, 5);

    #endregion


}