
#pragma warning disable CS0162 //Suppresses the CS0162 warning (Unreachable code detected) in this file.
#pragma warning disable CS0219 // Suppresses the Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Suppresses the Unnecessary assignment of a value
#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable IDE0060 // Remove unused parameter
using System.Numerics;
using System.Text;
using System.Diagnostics;
using MathLib;
using MathLib.Prime;
using MathLib.BalMult;
using MathLib.Misc;

namespace MathLib.DevConsole;

internal class Program
{





    // ConsoleWindow cw = ConsoleWindow.Create();
    static void Main()
    {

#if SEARCH
        int[] primes = PrimeGenerator.GeneratePrimes().Skip(1).Take(120).ToArray();
        for (int p1 = 0; p1 < primes.Length; p1++)
        {
            for (int p2 = 0; p2 < primes.Length; p2++)
            {
                Product prodX = new Product(primes[p1], primes[p2]);


                if (!prodX.Matrices().Any())
                {
                    Console.WriteLine(primes[p1] + " * " + primes[p2]);
                    Console.WriteLine(prodX.Integer.ToBalancedBits(prodX.ProductLength).Select(c => c == 1 ? '+' : '-').Str("  "));

                    Console.WriteLine();

                }
                //if (prodX.Matrices().Count() <= 2)
                //{
                //    Console.WriteLine(primes[p1] + " * " + primes[p2]);
                //}
            }
        }
        return;
#endif
        //new Product(811, 139); //both factors === 3 (mod 8)
        Product prod = new Product(17, 11); //new Product(431, 79); //// //new Product(577, 229);  // new Product(19, 11); // new Product(151, 23);//new Product(43, 19); //new Product(29, 3); //new Product(811, 139); //new Product(23, 17);  ////new Product(71, 173);  //new Product(23, 13); //   // // //new Product(7321, 6553);  //new Product(3187, 2543);  //new Product(7151, 241);   //  //new Product(47, 41); //new Product(541, 53);
        //AltParity ap = new AltParity(prod.X.Integer * prod.Y.Integer, prod.ProductLength);
        //Console.WriteLine(ap.ToString(3));
        string prodBits = prod.Integer.ToBalancedBits(prod.ProductLength).Select(c => c == 1 ? '+' : '-').Str("  ");
        Console.WriteLine(prodBits);
        Console.WriteLine(prod.Integer);
        Console.WriteLine();
        foreach (var prodVersion in prod.Matrices())
        {
            // Debug.Assert(prodVersion.ProductCoeffs().Count() == ap.Coeffs.Length);    



            Console.WriteLine(prodVersion.ToStringExpanded());
            Console.WriteLine();
            Console.WriteLine(prodVersion.ToStringProduct(3));
            Console.WriteLine(prodVersion.ToStringX(3));
            Console.WriteLine(prodVersion.ToStringY(3));
            Console.WriteLine();
            Console.WriteLine(prodVersion.ToStringDiag(3));
            Console.WriteLine();

        }

        

        return;

        //Int3 x = new Int3(181, 9);
        //x.PrintSequencesForInteger();
        //return;

        int product =  227 * 199; //433 * 359; // 181 * 151; // 211 * 107; // 83 * 79; // 83 * 79; //331 * 463; //227 * 199; //83 * 79; //331 * 463; //83 * 79; //331 * 463; // //227 * 199; //   331 * 463;  //227 * 199; /// 331 * 463; //251 * 149; // 83 * 79; //23 * 19; // 13 * 17; // 83 * 79; // 227 * 199;
        Input3 input3 = new Input3(product, 0);
        Int3 product3 = new Int3(product, 0);

        //input3.TrySolve(product3);
        //return;

        //product3.PrintSequencesForInteger(); // -31, 8); // -31, 8);
        //Console.WriteLine(product3);
        //product3.Request(0, 1);
        //product3.Request(3, -1);
        //Console.WriteLine(product3);
        //return;

        //input3.Coeffs = [Val3.PosPos, Val3.NegPos, Val3.NegNeg, Val3.NegNeg, Val3.PosNeg, Val3.PosPos, Val3.PosPos, Val3.PosPos];
        //Console.WriteLine(input3.ToStringProduct());
        //Console.WriteLine(input3.Product);
        //return;

        Console.WriteLine(input3.InputLength);
        Console.WriteLine(input3.ProductLength);
        
        input3.PrintAllMatches(product);
        Console.WriteLine("Done!");
        return;


        //Input input = new Input(227, 199);
        //Console.WriteLine("AP:");
        //AltParity ap = new AltParity(227 * 199, MinFluctuation.Yes);
        //Console.WriteLine(ap.ToString(7));

        //Console.WriteLine(input.ToString());
        //Console.WriteLine("-----");
        //Console.WriteLine(input.ToStringExpanded());
        //Console.WriteLine();
        //Console.WriteLine(input.ToStringProduct(7));

       // Input unknown = new Input(input.InputLength);
        //Console.WriteLine(unknown.ToString());
        //Console.WriteLine("-----");
        //Console.WriteLine(unknown.ToStringExpanded());
        //Console.WriteLine();
        //Console.WriteLine(unknown.ToStringProduct(3));

        //unknown.Signs[0] = Sign.Plus;
        //unknown.Signs[^1] = Sign.Plus;
        //unknown.Colors[1] = Color.Red;
        //unknown.Colors[4] = Color.Red;
        //Console.WriteLine(unknown.ToString());
        //Console.WriteLine("-----");
        //Console.WriteLine(unknown.ToStringExpanded());
        //Console.WriteLine();
        //Console.WriteLine(unknown.ToStringProduct(7));
        //return;
        //AltParity altParity1 = new AltParity(227 * 199, 15);
        //cw.WriteLine(altParity1.Length.ToString());
        //cw.WriteLine(altParity1.ToString(3));
        //cw.WriteLine(altParity1.ToStringMinMax());
        //return;

        // Write some colored text output to the console window
        //cw.WriteLine("Creating graph...", System.Drawing.Color.Blue);

        //var primes = PrimeGenerator.GeneratePrimes().Skip(1).Take(40).ToArray();
        
        //List<string[]> sequences = new();

        //for (int yi = 0; yi < primes.Length; yi++)
        //{
        //    int y = primes[yi];

        //    for (int xi = 0; xi < primes.Length; xi++)
        //    {
        //        int x = primes[xi];
        //        if (x <= y)
        //            continue;
        //        SymProduct symP = new SymProduct(x, y);
              
        //        if (symP.ProductLength.IsEven() || symP.ProductLength < 9)
        //            continue;
        //        var prodCoeffs = symP.ProductCoeffs().Reverse().ToArray();
        //        if (prodCoeffs[0] != 1 || prodCoeffs[1] != 2 || prodCoeffs[2] != 3)
        //            continue;
        //        sequences.Add(prodCoeffs.Take(5).Select(c => c.ToString()).ToArray());
        //    }
        //}

        //var graph = GraphFactory.CreateGraph(sequences, minimize: true);

        //cw.ShowGraph(graph);
        //cw.WriteLine("Graph created.", System.Drawing.Color.Green);

        //return;

        //Console.OutputEncoding = Encoding.UTF8;

        //SymProduct correct = new SymProduct(23, 19);
        //Console.WriteLine(correct.ToStringExpanded());
        //Console.WriteLine();


        //BigInteger prod = 23 * 19; // 13 * 17; // 83 * 79; // 227 * 199;
        //AltParity ap = new AltParity(correct);
       // AltParity ap = new AltParity(prod, MinFluctuation.Yes);
       //// AltParity ap = new AltParity(prod, new int[] { 1, 0, -3, -2, 1, 6, 3, 0, -5, -4, -1, 2, 3, 2, 1 });
       // Console.WriteLine($"AP: (product len: {ap.Length})");
       // Console.WriteLine(ap.ToString(3));
       // SymProduct sp = new SymProduct(ap);
       // int progress = sp.TrySolve(ap);
      
       // Console.WriteLine("Solve progress: " + progress + "\n");
       // Console.WriteLine(sp.ToString());
       // Console.WriteLine(sp.ProductString(3));
       // Console.WriteLine();
       // Console.WriteLine(sp.ToStringExpanded());
        //return;

        //SymProduct symProd = new SymProduct(227, 199, 17);
       
        //Console.WriteLine(symProd);
        //Console.WriteLine();
        //Console.WriteLine(symProd.ToStringExpanded());
        //Console.WriteLine();
        //Console.WriteLine("Correct:");
        //Console.WriteLine(symProd.ProductString(3));
        //Console.WriteLine(symProd.ToString());

        //AltParity altParity = new AltParity(symProd.Product, symProd.ProductLength);
        ////AltParity altParity = new AltParity(symProd);
        //Console.WriteLine("AltParity: " + altParity);
        //Console.WriteLine(altParity.ToString(3));
        //int solveProgress = symProd.TrySolve(altParity);
        //Console.WriteLine("Solve progress: " + solveProgress);
        //Console.WriteLine(symProd.ToString());
        //Console.WriteLine(symProd.ProductString(3));
        //Console.WriteLine(symProd.ToStringExpanded());
        return;

        //Console.WriteLine(Forms.ToBalancedBits(5, 0).Select(c => c > 0 ? '+' : '-').Str(""));
        //Console.WriteLine(Forms.ToBalancedBits(5, 3).Select(c => c > 0 ? '+' : '-').Str(""));
        //Console.WriteLine(Forms.ToBalancedBits(5, 4).Select(c => c > 0 ? '+' : '-').Str(""));
        //Console.WriteLine(Forms.ToBalancedBits(5, 5).Select(c => c > 0 ? '+' : '-').Str(""));
        //Console.WriteLine(Forms.ToBalancedBits(5, 6).Select(c => c > 0 ? '+' : '-').Str(""));
        //return;

        //static void Test(int xLen, int yLen)
        //{
        //    var counts = BalDigits.Counts(xLen, yLen);
        //    Console.WriteLine($"xLen:{xLen} yLen:{yLen}");
        //    Console.WriteLine(counts.Str(" "));
        //    Console.WriteLine(Product.IndexPairs(xLen, yLen).Str(", "));
        //    Console.WriteLine();
        //}

        //Test(5, 7);
        //Test(8, 6);
        //Test(8, 7);
        //Test(10, 7);
        //return;


        //Product debug = new Product(7, 3);
        //Console.WriteLine("X: " + debug.InputX.ToString());
        //Console.WriteLine("Y: " + debug.InputY.ToString());
        //Console.WriteLine(debug.ToExtendedString());
        //return;




        //AltParity altParity = new AltParity(product.Integer, product.Length);
        //var result = product.Match(altParity);
        //Console.WriteLine("failed at: " + result);
        //Console.WriteLine(product.ToExtendedString());
        //Console.WriteLine("Result sum: " + product[result]);



        //Product product3 = new Product(1, 79 * 83);
        //Print(product3);

        //Product product4 = new Product(-1, -79 * 83);
        //Print(product4);
        //return;

        //int prodLen = 15;
        //int xLen = 7;
        //int yLen = 6;

        //SortedSet<int>[] counts = new SortedSet<int>[30];
        //for (int i = 0; i < counts.Length; i++)
        //    counts[i] = new SortedSet<int>();

        //var primes = PrimeGenerator.GeneratePrimes().Skip(31).Take(200).ToArray();

        //int countSame = 0;
        //int countTotal = 0;

        //for (int yi = 0; yi < primes.Length; yi++)
        //{
        //    int y = primes[yi];
          
        //    for (int xi = 0; xi < primes.Length; xi++)
        //    {
        //        int x = primes[xi];
        //        if (x <= y)
        //            continue;
        //      // if (Math.Abs(x-y) < 5) continue;

        //        product = new Product(x, y);
        //        //Console.WriteLine(product.Length + " " + BalBits.ToBalancedBits(product.Integer).Count());

        //        //continue;
        //        //if (product.Integer != 227 * 199)
        //        //    continue;
        //        //if (product.Length != prodLen)
        //        //    continue;

        //        //if (product.XLength != xLen || product.YLength != yLen)
        //        //    continue;
        //        //if (product.IsAlternatingParity())
        //        //    continue;

        //        //var pairedSums = product.PairedSums().ToArray();
        //        //for (int i = 0; i < product.Length; i++)
        //        //    counts[i].Add(product[i]);

        //        //var baseX = product.BaseX().ToArray();
        //        //var base4 = product.Base4().ToArray();
        //        //for (int i = 0; i < base4.Length; i++)
        //        //    counts[i].Add(base4[i]);

        //        // var base4 = product.Base4().ToArray();
        //        //if (base4[base4.Length - 1] != 1)
        //        //
        //        //    continue;
        //        //}
        //        //Print(product);
             
        //        //product2 = new Product(product.InputY.Integer, product.InputX.Integer);
        //        //Print(product2);
         
        //    }
        //}
   
        //Console.WriteLine();
        //Console.WriteLine("Sets: ");
        //int setIndex = 0;
        //foreach (var set in counts)
        //{
        //    if (set.Count > 0 && set.Last() != 0)
        //        Console.WriteLine($"{setIndex}: {set.Str(" ")}");
        //    setIndex++;
        //}

        //return;
        //BigInteger x = 197;
        //BigInteger y = 103;
        //Product product = new Product(x, y);
        //Console.WriteLine(product.ToExtendedString());


        //int xLen = product.XLength;
        //int yLen = product.YLength;
        //Console.WriteLine(x*y + " == " + product.Integer);
        //Console.WriteLine("X: " + product.InputX + " Len: " + xLen);
        //Console.WriteLine("Y: " + product.InputY + " Len: " + yLen);

        //Console.WriteLine(BalDigits.Counts(product.XLength, product.YLength).Str(" "));
        //return;

        //Console.WriteLine(product);     
        //var balCoeffs = BalDigits.ToBalancedDigits(product.Integer, xLen, yLen);
        //Console.WriteLine(balCoeffs.Str(" "));
        //var balCoeffs2 = BalDigits.ToBalancedDigits(-product.Integer, yLen, xLen);
        //Console.WriteLine(balCoeffs2.Str(" "));


        TestToBalancedDigits();
        return;
    

        //BigInteger x = 97; // 137; // 97;
        //BigInteger y = 59; // 181; // 59;
        //x = 137; // 137; // 97;
        //y = 181; // 181; // 59;
        //x = 7841; // 137; // 97;
        //y = 6857; // 181; // 59;
        //int[] coeffs = Input.ToBitArray(x*y);
        //int[] coeffsRev = Input.ToBitArrayFactors(x, y);

        //Console.WriteLine(coeffs.Str());
        //Console.WriteLine(Input.BalancedCoeffs(coeffs).Select(c => c > 0 ? '+' : '-').Str());
        //Console.WriteLine(" " + Input.BalancedCoeffs(coeffsRev).Select(c => c > 0 ? '+' : '-').Str());
        //Console.WriteLine(coeffsRev.Str());
        //return;

     
        //Console.WriteLine(rev.GetSetNumber());
        //Qb qb = new Qb(-1, 1, 2);
        //Console.WriteLine(qb);
        //return;

        //QTuple qTuple = new QTuple(new Q(77, 1), 2);

        //var pb = new PyramidBase(7, 3, 3);

        //for (int i = 0; i < 20; i++)
        //{    
        //    Console.Write(pb.MinCoeff(i) + " ");
        //}
        //Console.WriteLine();

        //return;

        //static void Print(string title, Product product, int trail)
        //{
        //    //if (trail == -1)
        //    //    trail = product.Negative.Trail;

        //    Console.WriteLine($"******** {title} ********");
        //    Console.WriteLine("Trail: " + trail);
        //    Console.WriteLine($"Coeffs:     {product.ToString()}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
        //    Console.WriteLine($"Coeffs NEG: {product.Negative.ToString()}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
        //    Console.WriteLine($"Coeffs NEG+:{product.Negative.GetCoeffs(trail).Str(", ")}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");

        //    Console.WriteLine($"Min:        {product.ToStringMinValues()}");
        //    Console.WriteLine($"Min NEG:    {product.Negative.ToStringMinValues()}");
        //    Console.WriteLine($"Max:        {product.ToStringMaxValues()}");
        //    Console.WriteLine($"Max NEG:    {product.Negative.ToStringMaxValues()}");

        //    Console.WriteLine($"PosNeg sum: {product.PosNegSum().Str(", ")}    Sum: {product.PosNegSum().Sum()}");

        //    Console.WriteLine($"PosNeg sum+:{product.PosNegSum(trail).Str(", ")}");
        //    //Console.WriteLine($"Coeffs sum: {product.CoeffsSum()}");
        //    Console.WriteLine();

        //}

        //Random random = new Random(17);
        //        BigInteger GetOddRandom() => random.Next(100, 1000) * 2 + 1;

        //        BigInteger NegativeXNumber(Product product)
        //        {
        //            Qb qp0 = new Qp(product.Integer, 1, 2).Generator;
        //            Qb qp1 = new Qp(qp0, 2).Generator;
        //            Debug.Assert(qp1.IsInteger);
        //            return qp1.Numerator;
        //        }

        //for (int c = 0; c < 100; c++)
        //{
        //    BigInteger x = GetOddRandom();
        //    BigInteger y = GetOddRandom();
        //    //x = 107; // 23; //1611;
        //    //y = 11; // 19; //1215;
        //    if (x < y)
        //    {
        //        (x, y) = (y, x);
        //    }
        //    int xLen = Input.ToBitArray(x).Length;
        //    int yLen = Input.ToBitArray(y).Length;
        //    //  int xyLength = Input.ToBitArray(x*y).Length;
        //    Product reference = new Product(x * y, xLen, yLen);
        //    reference.FillX(x);
        //    reference.FillY(y);
        //    //Console.WriteLine("Input number: " + reference.NegativeX.Integer);

        //    Product negX = reference.NegativeX;
        //    BigInteger setNumber = negX.GetSetNumber();
        //    BigInteger preComputedNegativeX = NegativeXNumber(reference);

        //    //if (setNumber - preComputedNegativeX != 0)
        //    //    continue;

        //    // int lenDiff = xyLength - reference.Length;
        //    var lastCoeffVal = negX.GetSetCoeff(negX.Length - 1); // * Product.Weight(negX.Length - 1);

        //    Console.WriteLine($"{x} * {y}:  Set:{setNumber} Pre:{preComputedNegativeX} Diff:{setNumber - preComputedNegativeX} XLen:{xLen} YLen:{yLen} Len:{negX.Length}");

        //    Console.WriteLine("LastVal: " + lastCoeffVal);
        //    Console.WriteLine("PosSetNumber: " + reference.GetSetNumber() + " Sub: " + (setNumber - reference.GetSetNumber()));
        //   // reference.DebugPrint();
        //    negX.DebugPrint();
        //    Console.WriteLine(Input.ToBitArray(preComputedNegativeX).Str(""));
        //    Console.WriteLine(Input.ToBitArray(setNumber).Str(""));
        //    Console.WriteLine();



        //}
        //return;

        //BigInteger x = 53; // 29; // 23; // 92048139692281; // 53; // 92048139692281; //25478993; ; // 53; // 6199;  // 23; // 29;//6199; // 7853; // 4297; //1123; //29;  // 1439;  //541;// 29;
        //BigInteger y = 43; // 11; // 19; // 47695699980083; // 43; // 47695699980083; // 43; // 3779; //  19; //37; // 1123; // 3779; // 1801; // 13; // 23;  //1123; // 347; // 23;
        //int xLen = Input.ToBitArray(x).Length;
        //int yLen = Input.ToBitArray(y).Length;

        //Product reference = new Product(x * y, xLen, yLen);
        //reference.FillX(x);
        //reference.FillY(y);
        //int secondOneXIndex = reference.InputX.SecondOneXIndex;
        //reference.DebugPrint();
        //Console.WriteLine();
        //reference.NegativeX.DebugPrint();
        //var posNeg = Enumerable.Range(0, reference.Length).Select(i => reference.GetSetCoeff(i) + reference.NegativeX.GetSetCoeff(i)).ToArray();
        //Console.WriteLine("PosNegSum: " + posNeg.Str(""));

        //Product test = new Product(x * y, xLen, yLen);
        ////CHEAT!
        //for (int i = 0; i < 4; i++)
        //{
        //    test.InputX[i] = reference.InputX[i];
        //    test.InputY[i] = reference.InputY[i];
        //}


        //Console.WriteLine($"TEST Coeffs:     {test.Try(secondOneXIndex).Str(", ")}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");

        //Console.WriteLine();
        //test.DebugPrint();

        //Console.WriteLine("Input number: " + reference.NegativeX.Integer);
        //Console.WriteLine("Set number: " + reference.NegativeX.GetSetNumber());

        return;

        //   int secondOneXIndex = reference.InputX.SecondOneXIndex;
        //   Console.WriteLine("SecondOneXIndex: " + secondOneXIndex);

        //// int trail = product.Negative.InputY.Sum();


        //   Product test = new Product(x * y, xLen, yLen);
        //   Console.WriteLine("Pos InputX: " + reference.InputX);
        //   Console.WriteLine("Pos InputY: " + reference.InputY);
        //   //Console.WriteLine("Neg InputX: " + product.Negative.InputX);
        //   //Console.WriteLine("Neg InputY: " + product.Negative.InputY);
        //   Console.WriteLine("");

        //   //Print("REF          ", product, trail);
        //   //    Print("REF  Swap    ", product.Swapped);

        //   //  Print("REF  Neg     ", product.Negative);
        //   //  Print("REF  SwapNeg ", product.Swapped.Negative);

        //   // Print("TEST         ", test, trail);
        //   int[] givenCoeffs = Input.ToBitArray(-reference.Integer); //this can be 1 longer than Length
        //   //Console.WriteLine($"DEBUG :     {(givenCoeffs.Str(", "))}");


        //   // Console.WriteLine($"Adj PosNeg: {test.AdjustedPosNegSum().Str(", ")}    Sum: {test.AdjustedPosNegSum().Sum()}");


        //   //Console.WriteLine($"Coeffs:     {product.ToString()}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
        //   //Console.WriteLine($"Coeffs NEG+:{product.Negative.GetCoeffs(trail).Str(", ")}  XLen {product.XLength} YLen {product.YLength} Len:{product.Length}");
        //   //Console.WriteLine($"PosNeg sum+:{product.PosNegSum(trail).Str(", ")}");

        //   //Console.WriteLine();
        //   //Console.WriteLine($"Coeffs:     {test.ToString()}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");
        //   //Console.WriteLine($"Coeffs NEG+:{test.Negative.GetCoeffs(trail).Str(", ")}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");
        //   //Console.WriteLine($"PosNeg sum+:{test.PosNegSum(trail).Str(", ")}");


        //   //CHEAT!
        //   //for (int i = 0; i < 2; i++)
        //   //{
        //   //    test.InputX[i] = reference.InputX[i];
        //   //    test.InputY[i] = reference.InputY[i];
        //   //}
        //   Console.WriteLine("\nREFERENCE POS:");
        //   reference.DebugPrint();
        //   Console.WriteLine("\nREFERENCE NEG-X:");
        //   reference.NegativeX.DebugPrint();
        //   Console.WriteLine("\nREFERENCE NEG-Y:");
        //   reference.NegativeY.DebugPrint();
        //   Console.WriteLine("\nREFERENCE NEG-XY:");
        //   reference.NegativeXY.DebugPrint();

        //   Console.WriteLine("\n---------------");
        //   Console.WriteLine($"TEST Coeffs:     {test.Try(secondOneXIndex).Str(", ")}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");

        //   //Console.WriteLine("Ref  InputX: " + reference.InputX);
        //   //Console.WriteLine("Test InputX: " + test.InputX);

        //Console.WriteLine("Ref  InputY: " + reference.InputX);
        //Console.WriteLine("Test Input:  " + test.InputX);


        //Console.WriteLine("NegX InputX:  " + reference.NegativeX.InputX);
        //Console.WriteLine("NegY InputX:  " + reference.NegativeY.InputX);
        //Console.WriteLine("NegXY InputX: " + reference.NegativeXY.InputX);
        //Console.WriteLine();
        //Console.WriteLine("Pos InputY:   " + reference.InputY);
        //Console.WriteLine("NegX InputY:  " + reference.NegativeX.InputY);            
        //Console.WriteLine("NegY InputY:  " + reference.NegativeY.InputY);    
        //Console.WriteLine("NegXY InputY: " + reference.NegativeXY.InputY);

        //Console.WriteLine($"REF Coeffs :     {reference.ToString()}  XLen {reference.XLength} YLen {reference.YLength} Len:{reference.Length}");
        //Console.WriteLine($"TEST Coeffs:     {test.Try(secondOneXIndex).Str(", ")}  XLen {test.XLength} YLen {test.YLength} Len:{test.Length}");

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
    public static void TestToBalancedDigits()
    {
        var testCases = new List<(BigInteger integer, int[] constraints)>
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

        foreach (var (integer, constraints) in testCases)
        {
            var digits = BalDigits.ToBalancedDigits(integer, constraints);
            bool lengthCheck = digits.Length == constraints.Length;
            bool firstLastCheck = digits.First() is -1 or 1 && digits.Last() is -1 or 1;
            bool digitsCheck = digits.Zip(constraints, (d, c) => Math.Abs(d) <= Math.Abs(c) && d.Mod(2) == c.Mod(2)).All(check => check);
            BigInteger weightedSum = digits.Select((d, i) => d * BigInteger.Pow(2, i)).Aggregate(BigInteger.Zero, (acc, x) => acc + x);
            bool sumCheck = weightedSum == integer;

            bool testPassed = lengthCheck && firstLastCheck && digitsCheck && sumCheck;
            Console.WriteLine($"Input: {integer}, Constraints: [{string.Join(", ", constraints)}]");
            Console.WriteLine($"Output Digits: [{string.Join(", ", digits)}]");
            Console.WriteLine($"Test Passed: {(testPassed ? "Yes" : "No")}\n");
        }
    }
}


