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


    static void MainQp()
    {
        Console.OutputEncoding = Encoding.UTF8;


        Qp qp = new Qp(new Q(23, 3), new Base(2)); //.10111010101010101010
        Console.WriteLine(" " + Qp.PadicCoeffs(qp, qp.Base, yieldDelimiters: false).Take(60).Str(""));
        Console.WriteLine(qp.Generator.ToStringExpanded(60));

        ////Console.WriteLine("Cheat: " + new Qb(5, 6, qp.Base));
        Console.WriteLine($"Generator> {qp.Generator.ToStringCanonical()}");
        Console.WriteLine($"Generator> {nameof(qp.Generator.FirstExponent)}: {qp.Generator.FirstExponent}");
        Console.WriteLine($"Generator> {nameof(qp.Generator.PreperiodicPart)}: {qp.Generator.PreperiodicPart}");
        Console.WriteLine($"Generator> {nameof(qp.Generator.PeriodicPart)}: {qp.Generator.PeriodicPart}");

        return;

    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        //2102342102342102 4/9 base 5
        Qb qb1 = new Qb(60, 13, new Base(2)); 
        Console.WriteLine(qb1.ToStringExpanded(20));
        //Console.WriteLine(qb1.ToStringFactorization());
        Console.WriteLine(qb1.ToStringPeriodic());
        Console.WriteLine(qb1.ToStringRepetend());
        //Console.WriteLine($"Forward: {qb1}");
        //Console.WriteLine(qb1.Forwards(qb1.Base).Take(16).Str(", "));
        //Console.WriteLine(qb1.Forwards(qb1.Base).Select(f => f.Coeff(qb1.Base)).Take(16).Str(", "));
        //Console.WriteLine();
        //Qb qb2 = qb1;
        //Console.WriteLine($"Backward: {qb2} rev ");
        //Console.WriteLine(qb2.Backwards(qb2.Base).Take(16).Str(", "));
        //Console.WriteLine(qb2.Backwards(qb2.Base).Select(f => f.Coeff(qb2.Base)).Take(16).Str(", "));

        return;


        SetQ setQ = new SetQ(base_: 2, maxDenominator: 20);
        setQ.WriteOutput();
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

        Console.WriteLine(qb.ToStringCanonical() + " = " + qb.ToStringExpanded() + " Fractions: " + qb.ShiftedFractions().Take(20).Str(", "));


    
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
