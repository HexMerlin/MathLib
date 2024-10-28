
using System;
using System.Numerics;

namespace MathLib.DevConsole;

public class Solver
{
    private readonly Input InputA;
    private readonly Input InputB;

    private readonly Multiplier MultiplierA;
    private readonly Multiplier MultiplierB;

    public readonly int[] TryArray;


    public Solver(BigInteger product)
    {
        const int base_ = 2;
        const int length = 100;
        int[] expectedProductA = Multiplier.ToBitArray(new Qp(product, 1, base_), length);
        int[] expectedProductB = Multiplier.ToBitArray(new Qp(-product, 1, base_), length);
        InputA = new Input(8);
        InputB = new Input(8);

        IInput inputANeg = new NegativeInput(InputA);
        
        MultiplierA = new Multiplier(InputA, InputB, expectedProductA);
        MultiplierB = new Multiplier(inputANeg, InputB, expectedProductB);

        TryArray = new int[length];
    }

    public static void Run()
    {
       
        Solver solver = new Solver(101 * 149);
        solver.Solve();

    }

    private int RetryIndex(int[] tryArray, int index)
    {
        while (tryArray[index] == 3)
        {
            tryArray[index] = 0;
            index--;
        }
        tryArray[index]++;

        return index;
    }

    public void Solve()
    {
        Array.Fill(TryArray, 0);

        for (int index = 0; index < TryArray.Length; index++)
        {
            int tryVariant = TryArray[index];
            
            if (!InputA.Locked(index))
                InputA[index] = 1 - (tryVariant % 2);
            
            if (!InputB.Locked(index))
                InputB[index] = tryVariant / 2;
                        
            if (!ComputeProdDigit(index))
            {
                index = RetryIndex(TryArray, index) - 1; // -1 because the for loop will increment it
                if (index == -1) 
                    throw new InvalidOperationException("Bug somewhere");
            }

            Console.WriteLine("Index: " + index);
            Console.WriteLine(MultiplierA);
            Console.WriteLine();
            //Console.WriteLine(MultiplierB);
            Console.WriteLine("*******");
        }
    }

    public bool ComputeProdDigit(int index)
    {
        //if (index == 3 && InputB[1] == 0 && InputB[2] == 0 && InputB[3] == 0)
        //{
        //    return false;
        //}

        bool ok = MultiplierA.ComputeProdDigit(index);
        if (!ok) 
            return false;
        ok = MultiplierB.ComputeProdDigit(index);
        if (!ok) 
            return false;
        return true;
    }


}
