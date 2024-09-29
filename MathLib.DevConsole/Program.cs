#pragma warning disable CS0162 //Suppresses the CS0162 warning (Unreachable code detected) in this file.
#pragma warning disable CS0219 // Suppresses the Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Suppresses the Unnecessary assignment of a value

using System;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace MathLib.DevConsole;

internal class Program
{


    static void Main()
    {                
        Console.OutputEncoding = Encoding.UTF8;
        Q qD = new Q(-1, 4);
        Qb qbDec = qD.InBase(10);
        
        return;
        //Qb qb= new Qb(-1, 13, new Base(3)); 
        //works
        //Qb qb = new Qb(23, 3, 2);  //?
        //Qb qb = new Qb(-9, 13, new Base(5)); //?
        //var x1 = Qp.FindKQ(new Q(1, 9), 2);
        //Console.WriteLine(x1);
        //var x2 = Qp.FindKQ(new Q(37, 9), 2);
        //Console.WriteLine(x2);
        //return;
        //1011 110110110110  13 -16/3

        return;

        Qp qp1 = new Qp(new Q(1, 1), new Base(2));
        Qp qp2 = new Qp(new Q(-1, 1), new Base(2));

        Console.WriteLine(qp1.Valuation());
        Console.WriteLine(qp2.Valuation());
        return; 

        Qp qp = new Qp(new Q(23, 3), new Base(2)); //.10111010101010101010
        Console.WriteLine(" " + Qp.PadicCoeffs(qp, qp.Base, yieldDelimiters: false).Take(60).Str(""));
        Console.WriteLine(qp.Generator.ToStringCanonical(60));

        ////Console.WriteLine("Cheat: " + new Qb(5, 6, qp.Base));
        Console.WriteLine($"Generator> {qp.Generator.ToStringSimple()}");
        Console.WriteLine($"Generator> {nameof(qp.Generator.FirstExponent)}: {qp.Generator.FirstExponent}");
        Console.WriteLine($"Generator> {nameof(qp.Generator.PreperiodicPart)}: {qp.Generator.PreperiodicPart}");
        Console.WriteLine($"Generator> {nameof(qp.Generator.PeriodicPart)}: {qp.Generator.PeriodicPart}");


        //Qb junk = new Qb(1, 1, new Base(2));
        //Console.WriteLine($"junk> {junk}");
        //Console.WriteLine($"junk> {nameof(junk.FirstExponent)}: {junk.FirstExponent}");
        //Console.WriteLine($"junk> {nameof(junk.PreperiodicLength)}: {junk.PreperiodicLength}");
        //Console.WriteLine($"junk> {nameof(junk.Period)}: {junk.Period}");

        //Qb flip = new QTuple(qb).Flip();


        //Console.WriteLine("flip: " + flip.ToStringSimple() + " Padic: " + flip.ToStringCanonical(60));

        //Qb flip2 = new QTuple(flip).Flip();
        //Console.WriteLine("flip2:" + flip2.ToStringSimple());
        //Console.WriteLine(qb.ToStringCanonical(50));
        //Console.WriteLine(perInt);
        return;

        //foreach (var q in TestQs().Where(q => q == new Q(1,21)))
        //{
        //    Qb qb = q.InBase(2);
        //    Console.WriteLine(qb.ToStringCanonical(30));
        //    var qTuple = new QTuple(qb);
        //    Console.WriteLine($"{qb.ToStringSimple()} => {qTuple.Prefix} + {qTuple.Periodic}");
        //}

        //return;
        //Q q = new Q(79, 220);
        //Q q = new Q(1, 2);
        //Qb qb = q.InBase(10);
        ////foreach ((BigInteger Integer, Q Fraction) in qb.ShiftedFractions().Take(20))
        ////{

        ////    Console.WriteLine(Integer);
        ////}
        //Console.WriteLine($"Base {qb.Base}: {qb.ShiftedFractions().Select(t => t.Integer).Take(40).Str(",")}");
        //Console.WriteLine(qb.ToStringCanonical(30));
        //Q q = new Q(79, 220);
        //for (int b = 2; b <= 220; b++)
        //{
        //    //if (b is 6 or 8 or 10 or 12 or 14 or 15 or 16) continue;
        //    Base base_ = new Base(b);
        //    Qb qb = q.InBase(base_);
        //    Console.WriteLine($"Base {base_}: {ToStringCanonical(qb)} {(base_.IsPurelyPeriodic(qb) ? "Periodic" : "")}");
        //}

        //return;



        //-5 base 2 = 1101111111111... Pre: 110 (6), Per: 1111111111 (1)

        //35/18 base 2 = 1.101001110001110001110001
        //35/9 base 2 = 1101001110001110001110001

        //Console.WriteLine("Expected: 1101001110001110001110001");


        //Base base_ = new Base(2);

        //-7/9 base 2 = 10001110001110001110001110001110…  Qp generator: -5/9
        //BaseInt preperiodicPart = new BaseInt(base_, 0); //0
        //BaseInt periodicPart = new BaseInt(base_, 35); //100011

        //5/9 base 2 = 1011100011100011100011100… //pre: 1, per: 011100  Qp generator: 13/18
        //BaseInt preperiodicPart = new BaseInt(base_, 1); //1
        //BaseInt periodicPart = new BaseInt(base_, 28, 6); //011100

        //-5/9 base 2 = 11000111000111000111000111000111…  Qp generator: -7/9 
        //BaseInt preperiodicPart = new BaseInt(base_, 0); //0
        //BaseInt periodicPart = new BaseInt(base_, 49); //110001



        ////13/18 base 2 = 10100111000111000111000111000111
        ////BaseInt preperiodicPart = new BaseInt(base_, 5); //101
        ////BaseInt periodicPart = new BaseInt(base_, 14, 6); //001110
        ////Qp qp = new Qp(preperiodicPart, periodicPart, -1);

        ////5 base 2 = 1010000000000000000000000
        //Base base_ = new Base(2);
        //BaseInt preperiodicPart = new BaseInt(base_, 5); //101
        //BaseInt periodicPart = new BaseInt(base_, 0); //0

        ////-5 base 2 = 1101111111111... Pre: 110 (6), Per: 1111111111 (1)
        ////BaseInt preperiodicPart = new BaseInt(base_, 6); //110
        ////BaseInt periodicPart = new BaseInt(base_, 1); //1

        //Qp qp = new Qp(preperiodicPart, periodicPart);

        //Console.WriteLine("--------------------");
        //Console.WriteLine("FINAL: " + qp.ToString()); 
        //Console.WriteLine("Qp generator: " + qp.Generator.ToString()); 
  
       
        ////Console.WriteLine("QP ext: first exponent: " + qp.FirstExponent);
        //Console.WriteLine("---------------------");
        //Qp qpTest = new Qp(new Q(qp.Numerator, qp.Denominator), base_);
        ////Qp qpTest = new Qp(qp.Generator.PreperiodicPart, qp.Generator.PeriodicPart);

        //Console.WriteLine("Test: " + qpTest);
        //Console.WriteLine("Test generator: " + qpTest.Generator);

        ////Qb qbGen = qp.Generator; //13/18
        ////BaseInt preperiodicPartNew = qbGen.PreperiodicPart;
        ////BaseInt periodicPartNew = qbGen.PeriodicPart;
        ////Qp qpNew = new Qp(preperiodicPartNew, periodicPartNew); //5/9
        ////Console.WriteLine("Qb gen: " + qbGen); //13/18
        ////Console.WriteLine("Qp new: " + qpNew); //5/9
        ////Console.WriteLine("Generator: "+ qpNew.Generator); //13/18

        ////BaseInt preperiodicPart = new BaseInt(base_, 13); //1101 
        ////BaseInt periodicPart = new BaseInt(base_, 14, 6); //001110
        ////Qp qp = new Qp(preperiodicPart, periodicPart, -1);
        ////Console.WriteLine("Qp generator: " + qp.Generator.ToString());
        ////Console.WriteLine("QP ext: first exponent: " + qp.FirstExponent);
        ////Console.WriteLine("FINAL: " + qp.ToString());
        return;



        //// From P-adic to P-ary
        //35/18 base 2  …100011100011100011100101.1
        //Console.WriteLine("35 / 18 base 2");
        //Console.WriteLine("1101-001110-001110-001110…");
        //Base basePadic = new Base(2);
        //preperiodicPart = new BaseInt(basePadic, 13, 4); // 1101
        //periodicPart = new BaseInt(basePadic, 14, 6); // 001110

        //Console.WriteLine("Preperiodic: " + preperiodicPart); // Int: 13 Length: 4
        //Console.WriteLine("Periodic:     " + periodicPart); //Int: 14 Length: 6

        //Qb qb1 = new Qb(preperiodicPart, periodicPart, -1);
        //Console.WriteLine(qb1);

        ////Qb qb1 = new Qb(q1, new Base(2, NaturalOrder.Descending_P_Ary)); // basePadic);
        //Console.WriteLine("Should be 35/18: " + qb1.ToString());

        //Console.WriteLine(qb1.ToStringSimple() + " == " + qb1.ToStringSimple());
        //Console.WriteLine("Preperiodic: " + qb1.PreperiodicPart);
        //Console.WriteLine("Periodic:     " + qb1.PeriodicPart);


        return;

        ////// From P-ary to P-adic
        //Console.WriteLine("17 / 36 base 2  1001 001110 001110 001110  …");
        //base_ = new Base(2);
        //Qb qb = new Qb(17, 36, base_);
        //Console.WriteLine("Preperiodic: " + qb.PreperiodicPart);
        //Console.WriteLine("Periodic:     " + qb.PeriodicPart);
      
        // Console.WriteLine("-5 base 2 = 1101111111111... Pre: 110, Per: 1111111111");
        //Console.WriteLine("-17 / 36 base 2 : 1110 110001 110001 110001  …");



        //-5 base 2 = 1101111111111... Pre: 110, Per: 1111111111
        //BaseInt minusOnePre = new BaseInt(base_, 3, 3); //110 
        //BaseInt minusOnePer = new BaseInt(base_, 2, 2); //01
        ////Qb qb = new Qb(base_, prePeriodicPart, periodicPart);
        //Qb qb0 = Q.FromParts(minusOnePre, minusOnePer).InBase(base_);
        //Console.WriteLine(qb0 + " => " + qb0.ToStringSimple());

        //Qb what = new Qb(-6, 1, base_);
        //Console.WriteLine(what);
        return;
        //17 / 36 base 2 …10001110001110001110010.01
        //17 / 36 base 2  1001 001110 001110 001110  …

        //-17 / 36 base 2 : …01110001110001110001101.11
        //-17 / 36 base 2 : 1110 110001 110001 110001  …

        //Qb expected = new Qb(17, 36, base_);
        //Console.WriteLine(expected.ToStringSimple());

        //BaseInt prePeriodicPart = new BaseInt(base_, 7); //1110 
        //BaseInt periodicPart = new BaseInt(base_, 49, 6); //110001 
        ////Qb qb = new Qb(base_, prePeriodicPart, periodicPart);
        //Qb qb = Q.FromParts(prePeriodicPart, periodicPart, -1).InBase(base_);
        //Console.WriteLine("Generator: " + qb.ToStringSimple());
        //Console.WriteLine(" 1110110001110001110001  …");

        //Console.WriteLine(qb.ToStringCanonical());
        ////Console.WriteLine(qb.ToStringCanonical(25));
        return;
        //TestCreatorQp.CreateTests();

        ////Console.WriteLine(Qp.Zero(base_));
        ////Console.WriteLine(Qp.One(base_));
        ////Console.WriteLine(Qp.MinusOne(base_));

        ////target QP 1/46 base 5 = "…023243141 0442120130340023243141 1"
        //// Console.WriteLine("Qp 1/46 base 5: …02324314104421201303400232431411");
        //Console.WriteLine("Qp 1/11 base 2: …10111010001011101000101110100011");
        ////Console.WriteLine("Qp 1/2 base 3: …11111111111111111111111111111112");
        //Console.WriteLine("1/11 base 2: " + Qp.ReciprocalCoefficients(11, 2).Select(t => t.coefficient).Take(20).Str(""));
        //Qp qp1 = new Qp(1, 11, 2);
        //Console.WriteLine(qp1.ToStringCanonical());
        //Console.WriteLine(qp1.ReverseGenerator + " Period: " + qp1.Period);
        ////var tuples = Qp.ReciprocalCoefficients(46, 5).Take(30);
        ////foreach ((int coefficient, BigInteger remainder) in tuples)
        ////{
        ////    Console.WriteLine(coefficient + " " + remainder);
        ////}
        return;

        //string actual = "…" + Qp.ReciprocalCoefficients(46, 5).Select(t => t.coefficient).Take(60).Str("");
        //Console.WriteLine(actual);
        //Qb qGen = Qp.Reciprocal(46, 5).ToQb(5);
        //Console.WriteLine(Qp.ReciprocalCoefficients(2, 3).Select(t => t.coefficient).Take(60).Str(""));

        //Qp qp = new Qp(1, 2, 3);
             
        //Console.WriteLine("QP class:" + qp.ToStringCanonical(32));
        //Console.WriteLine("Qp period: " + qp.Period);
        //return;
        //Q[] qs = { new Q(-1, 1), new Q(-2, 1), new Q(1, 1), new Q(1, 3), new Q(2, 3), new Q(12, 5), new Q(12, 7), new Q(13, 5) };
        //foreach (Q q in qs)
        //{
        //    Qb qb = q.ToQb(base_);
        //    (BigInteger PrePeriodicPart, int PrePeriodicLength, BigInteger PeriodicPart, int Period) = qb.ToParts();
        //    //Console.WriteLine($"{q.ToStringSimple()}: PPP:{PrePeriodicPart}({PrePeriodicLength}) PP: {PeriodicPart}({Period}), ");
        //    Console.WriteLine($"{base_}, {PrePeriodicPart}, {PrePeriodicLength}, {PeriodicPart}, {Period}, Q={q.ToStringSimple()}  ");
        //}
    }

    static void MainQ()
    {
        Console.OutputEncoding = Encoding.UTF8;

        //2102342102342102 4/9 base 5
        Qb qb1 = new Qb(4, 9, new Base(5)); 
        Console.WriteLine(qb1.ToStringCanonical(6));
        Console.WriteLine(qb1.ShiftedFractions().Take(16).Str(", "));

        Console.WriteLine($"Forward: {qb1}");
        Console.WriteLine(qb1.Forwards(qb1.Base).Take(16).Str(", "));
        Console.WriteLine(qb1.Forwards(qb1.Base).Select(f => f.Coeff(qb1.Base)).Take(16).Str(", "));
        Console.WriteLine();
        Qb qb2 = qb1;
        Console.WriteLine($"Backward: {qb2} rev ");
        Console.WriteLine(qb2.Backwards(qb2.Base).Take(16).Str(", "));
        Console.WriteLine(qb2.Backwards(qb2.Base).Select(f => f.Coeff(qb2.Base)).Take(16).Str(", "));

        return;

        //Qb qba = new Qb(19, 12, 2);
        //Console.WriteLine(qba.ToStringCanonical());

        //Console.WriteLine("Pre: " + qba.PreperiodicPart);
        //Console.WriteLine("Per: " + qba.PeriodicPart);
        //Console.WriteLine("Pre:" + qba.PreperiodicTerm());
        //Console.WriteLine("Per: " + qba.PeriodicTerm());
        //return;


        SetQ setQ = new SetQ(base_: 2, maxDenominator: 20);
        setQ.WriteOutput();
         return;
        //TestCreator.CreateTestsQbToStringCanonicalAndFullInt();
       // TestCreator.CreateTestsConstructorOnParts_FromQb();

        return;

        //void OutQ(Qb qb)
        //{
        //    string baseS = qb.Base == 2 ? "_₂" : qb.Base == 3 ? "_₃" : qb.Base == 5 ? "_₅" : "XXX";
        //    string preperiodicPart = new Qb(qb.PreperiodicPart, 1, qb.Base).Coefficients().Take(qb.PreperiodicLength).Str("");
        //    string periodicPart = new Qb(qb.PeriodicPart, 1, qb.Base).Coefficients().Take(qb.Period).Str("");
        //    Console.WriteLine($"{qb.ToStringSimple()}{baseS}\t{qb.ToStringCanonical(30)} {qb.PreperiodicPart}({qb.PreperiodicLength}) {qb.PeriodicPart}({qb.Period})");
        //    Console.WriteLine($"First exponent: {qb.FirstExponent}, First Periodic Exponent: {qb.FirstPeriodicExponent}");
        //    Console.WriteLine($"{qb.ShiftedFractions().Take(20).Str(", ")}");


        //}
        //OutQ(new Qb(62, 7, 2));


        // OutQ(new Qb(1, 9, 2));

        //OutQ(new Qb(0, 1, 2));
        //OutQ(new Qb(1, 1, 2));
        //OutQ(new Qb(5, 24, 2));
        //OutQ(new Qb(5, 24, 2));
        //OutQ(new Qb(3, 4, 5));
        //OutQ(new Qb(537, 11, 3));
        return;

        //Console.WriteLine(new BigInteger(0).IsPowerOf(13));
        //return;

  
        //TestCreator.CreateTests();
       


        Qb qb = new Qb(-1, 1, new Base(2));
        foreach (var fraction in qb.ShiftedFractions().Take(20))
        {
            Console.WriteLine(fraction);
        }
        return;

        //Console.WriteLine($"{qb.ToStringSimple()} = {qb.ToStringCanonical(maxRepeatingCoefficient: false)}");
        Console.WriteLine(qb.ToStringSimple() + " = " + qb.ToStringCanonical() + " Fractions: " + qb.ShiftedFractions().Take(20).Str(", "));


    
        //Q_old q2 = new Q_old(22, 3);
        //Console.WriteLine(q2.NumeralSystem.RotationsBin.Select(r => r.ToString()).Take(20).Str(", "));
        //Console.WriteLine(q1.Coefficients().Select(q => q.Numerator).Take(20).Str(", "));

        //Console.WriteLine(q2.NumeralSystem.RotationsBin.Select(r => r.ToString()).Take(10).Str(", "));
        //Console.WriteLine(q.NumeralSystem.RotationsBin.Select(r => r >= Q_old.Half ? 1 : 0).Take(30).Str(""));
        //Console.WriteLine(q.NumeralSystem.ToStringBin());
        //var digits = Sequence.Digits(42, 2);
        //Console.WriteLine(digits.Take(40).Str(""));

        //        n(valuation):  -2
        //…33333333333333.34
        //4 * 5 ^ -2 + 3 * 5 ^ -1 + 3 + 3 * 5 + 3 * 5 ^ 2 + 3 * 5 ^ 3 + 3 * 5 ^ 4 + 3 * 5 ^ 5 + 3 * 5 ^ 6 + 3 * 5 ^ 7 + 3 * 5 ^ 8 + 3 * 5 ^ 9 + 3 * 5 ^ 10 + 3 * 5 ^ 11 + 3 * 5 ^ 12 + 3 * 5 ^ 13 + O(5 ^ 14)

        //Q q1 = new Q(1, 7);
        //Console.WriteLine(q1.NumeralSystem.ToStringBin());
        //PAdic p1 = new PAdicPrefix(1, 7);
        //Console.WriteLine(p1);

    }



}
