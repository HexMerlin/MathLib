using System.Numerics;
using MathLib;
namespace MathLib.DevConsole;

public class SetQ
{
    public Base Base { get; }

    public int MaxDenominator { get; }

    public SortedSet<Q> AllQs { get; }

    public SetQ(int base_, int maxDenominator = 20)
    {
        this.Base = new Base(base_);
        this.MaxDenominator = maxDenominator;

        AllQs = new();
        for (int denominator = 2; denominator < maxDenominator; denominator++)
        {
            for (int numerator = 1; numerator < denominator; numerator++)
            {
                Q q = new(numerator, denominator);
                if (q.Numerator != numerator)
                    continue; // skip if reduced
                AllQs.Add(q);
            }
        }
    }

    public void WriteOutput()
    {      
        foreach (var q in AllQs)
        {
            Qb qb = q.InBase(Base);

            Console.WriteLine($"{qb.ToStringCanonical()}\t{qb.FullInteger} {qb.ToStringSimple()}\tPeriod:{qb.Period}\tLength:{qb.Length}");
        }
    }
}
