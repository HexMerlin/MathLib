#pragma warning disable CS0162 //Suppresses the CS0162 warning (Unreachable code detected) in this file.
#pragma warning disable CS0219 // Suppresses the Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Suppresses the Unnecessary assignment of a value

using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;

namespace MathLib.DevConsole;

internal class Program
{

    static string PurePeriodic(Qb qb, bool reverse = false)
    {
        string s = qb.ToStringPeriodic()[1..^1];
        return reverse ? s.Reverse().Str() : s;
    }

    static void Main()
    {
        

        Console.OutputEncoding = Encoding.UTF8;
        Qb xxx = new Q(0, 1).InBase(2);
        Console.WriteLine(xxx.Period);
        return;

        Q a = new Q(4, 5); // -1/5
        Q b = new Q(8, 11); // -1/11
        Console.WriteLine(a.InBase(2).ToStringPeriodic());
        Console.WriteLine(b.InBase(2).ToStringPeriodic());
        var padicProd = Q.PadicProduct(a, b);
        Console.WriteLine(padicProd.Take(60).Str(""));
        return;

        BigInteger number = 13 * 23; //11*23; //299; //253; //667;
        //int b = 2;
        //Base base_ = new Base(b);
        //// for (BigInteger d = number; d <= number; d+=2)
        //BigInteger d = number;
        //{
        //    for (BigInteger n = 1; n < d; n ++)
        //    {
        //        Q q = new Q(n, d).Negation(true);
        //        Qb qb = new Qb(q, base_);
        //        Qp qp = new Qp(q, base_);
        //        Qb generator = qp.Generator;

        //        //string s1 = PurePeriodic(qb);
        //        //string s2 = PurePeriodic(generator);
        //        //if (s1 != s2)
        //        {
        //            var res = (qp / generator);

        //           // Console.WriteLine($"Q: {qb.ToStringCanonical()} {generator.ToStringCanonical()}       {res.ToStringCanonical()} ");
        //            //if (q.Numerator != -n)
        //                Console.WriteLine($"Q: {qb.ToStringCanonical()} {generator.ToStringCanonical()} {res.ToStringCanonical()}");
        //           // Console.WriteLine(res.InBase(base_).ToStringPeriodic());
        //            //Console.WriteLine(s1);
        //            //Console.WriteLine(s2);
        //            //Console.WriteLine();
        //        }
        //    }
        //}

    
        //Console.WriteLine(" " + Qp.PadicCoeffs(qp, qp.Base, yieldDelimiters: false).Take(60).Str(""));
        //Console.WriteLine(qp.Generator.ToStringExpanded(60));
        //return;

        //////Console.WriteLine("Cheat: " + new Qb(5, 6, qp.Base));
        //Console.WriteLine($"Generator> {qp.Generator.ToStringCanonical()}");
        //Console.WriteLine($"Generator> {nameof(qp.Generator.FirstExponent)}: {qp.Generator.FirstExponent}");
        //Console.WriteLine($"Generator> {nameof(qp.Generator.PreperiodicPart)}: {qp.Generator.PreperiodicPart}");
        //Console.WriteLine($"Generator> {nameof(qp.Generator.PeriodicPart)}: {qp.Generator.PeriodicPart}");

        //return;

    }

    
    static void MainQb()
    {
        Console.OutputEncoding = Encoding.UTF8;


        //2102342102342102 4/9 base 5
      
        
     
        return;


        SetQ setQ = new SetQ(base_: 2, maxDenominator: 20);
        setQ.WriteOutput();
         return;

        //TestCreator.CreateTests();
    

    
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
