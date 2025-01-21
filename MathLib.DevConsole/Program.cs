
#pragma warning disable CS0162 //Suppresses the CS0162 warning (Unreachable code detected) in this file.
#pragma warning disable CS0219 // Suppresses the Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Suppresses the Unnecessary assignment of a value
#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable IDE0060 // Remove unused parameter
using System.Numerics;
using System.Text;

namespace MathLib.DevConsole;

internal class Program
{


    static void Main()
    {
        Console.WriteLine("Test.");

#if SEARCH
        int[] primes = PrimeGenerator.GeneratePrimes().Skip(1).Take(50).ToArray();
        for (int p1 = 0; p1 < primes.Length; p1++)
        {
            int x = -primes[p1];
            if ((x + 1).IsPowerOfTwo()) continue; //skip powers of 2 
            for (int p2 = 0; p2 < primes.Length; p2++)
            {
                if (p1 == p2) continue; //skip perfect squares
                int y = primes[p2];
                if ((y + 1).IsPowerOfTwo()) continue; //skip powers of 2
                Product prod = new Product(x, y);
                //if (prod[0] != -1)
                //    continue;
                if (prod.Matrices().Any())
                {
                    //Console.WriteLine(prod.ToString());
                    //foreach (var version in prod.Matrices())
                    //{
                    //    Console.WriteLine(version.ToStringX());
                    //    Console.WriteLine(version.ToStringY());
                    //    Console.WriteLine();
                    //}
                    //Console.WriteLine();

                }
                else {


                    Console.WriteLine("FAIL: " + prod);
                }
                //Console.WriteLine(prod.ToStringExpanded());
                //Console.WriteLine(prod.ToString());
           
            }
        }
        return;
#endif



    }



}



