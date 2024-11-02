#pragma warning disable CS0162 //Suppresses the CS0162 warning (Unreachable code detected) in this file.
#pragma warning disable CS0219 // Suppresses the Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Suppresses the Unnecessary assignment of a value

using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using MathLib;
using MathLib.Mult;

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
        //QTuple qTuple = new QTuple(new Q(77, 1), 2);

        //var pb = new PyramidBase(7, 3, 3);

        //for (int i = 0; i < 20; i++)
        //{    
        //    Console.Write(pb.MinCoeff(i) + " ");
        //}
        //Console.WriteLine();

        //return;
        static void Print(string title, Product product, int trail)
        {
            //if (trail == -1)
            //    trail = product.Negative.Trail;

            Console.WriteLine($"******** {title} ********");
            Console.WriteLine("Trail: " + trail);
            Console.WriteLine($"Coeffs:     {product.ToString()}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
            Console.WriteLine($"Coeffs NEG: {product.Negative.ToString()}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
            Console.WriteLine($"Coeffs NEG+:{product.Negative.GetCoeffs(trail).Str(", ")}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");

            Console.WriteLine($"Min:        {product.ToStringMinValues()}");
            Console.WriteLine($"Min NEG:    {product.Negative.ToStringMinValues()}");
            Console.WriteLine($"Max:        {product.ToStringMaxValues()}");
            Console.WriteLine($"Max NEG:    {product.Negative.ToStringMaxValues()}");

            Console.WriteLine($"PosNeg sum: {product.PosNegSum().Str(", ")}    Sum: {product.PosNegSum().Sum()}");

            Console.WriteLine($"PosNeg sum+:{product.PosNegSum(trail).Str(", ")}");
            //Console.WriteLine($"Coeffs sum: {product.CoeffsSum()}");
            Console.WriteLine();

        }

        int x = 53; // 6199;  // 23; // 29;//6199; // 7853; // 4297; //1123; //29;  // 1439;  //541;// 29;
        int y = 43; // 3779; //  19; //37; // 1123; // 3779; // 1801; // 13; // 23;  //1123; // 347; // 23;
        int xLen = Input.ToBitArray(x).Length;
        int yLen = Input.ToBitArray(y).Length;

        Product product = new Product(x * y, xLen, yLen);
        product.FillX(x);
        product.FillY(y);
        int trail = product.Negative.InputY.Sum();


        Product test = new Product(x * y, xLen, yLen);

        Console.WriteLine("InputX: " + product.Negative.InputX);
        Console.WriteLine("InputY: " + product.Negative.InputY);

        Print("REF          ", product, trail);
    //    Print("REF  Swap    ", product.Swapped);

      //  Print("REF  Neg     ", product.Negative);
      //  Print("REF  SwapNeg ", product.Swapped.Negative);

        Print("TEST         ", test, trail);
        int[] givenCoeffs = Input.ToBitArray(-product.Integer); //this can be 1 longer than Length
        Console.WriteLine($"DEBUG :     {(givenCoeffs.Str(", "))}");

        Console.WriteLine("---------------");
        // Console.WriteLine($"Adj PosNeg: {test.AdjustedPosNegSum().Str(", ")}    Sum: {test.AdjustedPosNegSum().Sum()}");


        Console.WriteLine($"Coeffs:     {product.ToString()}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
        Console.WriteLine($"Coeffs NEG+:{product.Negative.GetCoeffs(trail).Str(", ")}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
        Console.WriteLine($"PosNeg sum+:{product.PosNegSum(trail).Str(", ")}");

        Console.WriteLine();
        Console.WriteLine($"Coeffs:     {test.ToString()}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");
        Console.WriteLine($"Coeffs NEG+:{test.Negative.GetCoeffs(trail).Str(", ")}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");
        Console.WriteLine($"PosNeg sum+:{test.PosNegSum(trail).Str(", ")}");

        //Console.WriteLine($"PosNeg MIN :{test.MinMax().Select(t => t.min PosNegSum(trail).Str(", ")}"););
        
        //Console.WriteLine("0, 1");
        //test.InputX[^2] = 0;
        //test.InputY[^2] = 1;
        //Console.WriteLine();
        //Console.WriteLine($"Coeffs:     {test.ToString()}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");
        //Console.WriteLine($"Coeffs NEG+:{test.Negative.GetCoeffs(trail).Str(", ")}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");
        //Console.WriteLine($"PosNeg sum+:{test.PosNegSum(trail).Str(", ")}");

        return;

        //var base_ = new Base(5);
        //for (int i = -50; i <= 50; i++)
        //{

        //    Q q = new Q(i, 1);
        //    Qp qp = new Qp(q, base_);
        //    var coeffs = qp.Generator.Coefficients().Take(30).Str();
        //    Qp qpNeg = new Qp(-q, base_);
        //    var coeffsNeg = DerivedInput.Negate(qpNeg.Generator.Coefficients().Take(30), base_.IntValue).Str();

        //    if (coeffs != coeffsNeg)
        //    {
        //        Console.WriteLine(i);
        //        Console.WriteLine(coeffs);
        //        Console.WriteLine(coeffsNeg);
        //    }

        //}
        //return;



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


        //SetQ setQ = new SetQ(base_: 2, maxDenominator: 20);
        //setQ.WriteOutput();
        // return;

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
