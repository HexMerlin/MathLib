using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace MathLib.BalMult;
public class Product
{
    public BigInteger Integer => InputX.Integer * InputY.Integer;

    public Input InputX { get; }
    public Input InputY { get; }

    public int Length => XLength + YLength - 1;
    public int XLength => InputX.Length;
    public int YLength => InputY.Length;

    public int this[int index] => InputCells(index).Select(t => InputX[t.xIndex] * InputY[t.yIndex]).Sum();

    public Product(BigInteger x, BigInteger y, int minLength = 0)
    {
        if (x.Abs() >= y.Abs())
        {
            InputX = new Input(x, minLength);
            InputY = new Input(y, InputX.Length);
        }
        else
        {
            InputY = new Input(y,minLength);
            InputX = new Input(x, InputY.Length);
        }
        //InputX = new Input(x);
        //InputY = new Input(y);
    }
 
    public IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    {
        int startRow = Math.Max(0, index - InputX.Length + 1);
        int endRow = Math.Min(index, InputY.Length - 1);

        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = index - yIndex;
            yield return (xIndex, yIndex);
        }
    }

    public IEnumerable<int> Coeffs => Enumerable.Range(0, Length).Select(i => this[i]);

    public int Count(int index) => BalDigits.Count(index, XLength, YLength);

    public bool IsAlternatingParity() => Enumerable.Range(0, Length).All(i => i.IsOdd() != Count(i).IsOdd());

    public Input Diff() => new Input(Enumerable.Range(0, XLength).Select(i => InputX[i] == InputY[i] ? 1 : -1).ToArray());

    public string Reference()
    {
        StringBuilder sb = new StringBuilder();

        for (int y = 0; y < YLength; y++) { 
        
            for (int x = 0; x < XLength; x++)
            {
                //int val = InputX[x] * InputY[y];
                int val = InputX[x] * InputY[y] != InputX[y] * InputY[x]
                    ? 0
                    : InputX[x] * InputY[y];
                sb.Append(val == 0 ? ' ' : val == 1 ? '+' : '-');
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public IEnumerable<int> Base4()
    {
        yield return this[0];
        for (int i = 2; i < Length; i += 2)
        {
            Debug.Assert(this[i - 1].IsEven());
            yield return this[i - 1] / 2 + this[i];
        }
    }

    public IEnumerable<int> BaseX()
    {
        for (int i = 0; i < Length; i ++)
        {
            if (this[i].IsOdd())
                yield return this[i];
            else
            {
                yield return 0;
                yield return this[i] / 2 + this[i + 1];
                i++;
            }
        }
    }

    public IEnumerable<int> Code() => Enumerable.Range(0, XLength).Select(i => InputX[i] == InputY[i] ? 1 : -1); 
    public string CodeString() => Code().BitString(2);

    public IEnumerable<int> Code2() => Enumerable.Range(0, XLength).Select(i => InputX[0] == InputY[i] ? 1 : -1);
    public string Code2String() => Code2().BitString(2);

    public IEnumerable<int> Code3() => Enumerable.Range(0, XLength).Select(i => InputX[i] == InputY[0] ? 1 : -1);
    public string Code3String() => Code3().BitString(2);

    public int Match(AltParity altParity)
    {
        static int Combine(int x, int y) => (x == 1 ? 2 : 0) + (y == 1 ? 1 : 0); //Combines two values that are -1 or 1 into a single unique value [0..3]
        static (int x, int y) Split(int z) => ((z & 2) - 1, (z & 1) * 2 - 1);    //Splits a combined value back into the original two values


        Debug.Assert(Length == altParity.Length);
        InputX.Clear();
        InputY.Clear();
        int[] combinations = new int[Length];
       
        
        for (int i = 0; i < Length;)
        {
            Console.WriteLine($"Trying from comb {combinations[i]} at index {i}");
            combinations[i] = MatchAt(altParity, i, combinations[i]);
            
            if (combinations[i] < 4)
            {
                Console.WriteLine($"Success for combination {combinations[i]} at index {i}");
                combinations[i]++; //add the next combination to try if returning here
                
                i++;
                continue;
            }
            else while (combinations[i] == 4)
            {
                Console.WriteLine("No combs left at index " + i + " - backtracking");
                combinations[i] = 0;
                i--;
                if (i < 0) return -1;
            }
            Console.WriteLine();
        }
        Console.WriteLine("FULL SUCCESS!");
        return Length;
    }

    public int MatchAt(AltParity altParity, int index, int startCombination)
    {
        static int Combine(int x, int y) => (x == 1 ? 2 : 0) + (y == 1 ? 1 : 0); //Combines two values that are -1 or 1 into a single unique value [0..3]
        static (int x, int y) Split(int z) => ((z & 2) - 1, (z & 1) * 2 - 1);    //Splits a combined value back into the original two values

        int refSum = altParity[index];
       
        for (int combination = startCombination; combination < 4; combination++)
        {
            (int x, int y) = Split(combination);
            InputX.Set(index, x);
            InputY.Set(index, y);
            int testSum = this[index];
            if (testSum == refSum)
                return combination; 
        }
        return 4; //failed to find a match
    }

    public string ToExtendedString()
    {

        string xString = InputX.ToString(4);
        string negXSting = new Input(-InputX.Integer, InputX.Length).ToString(4);

        StringBuilder sb = new();
        for (int y = 0; y < YLength; y++)
        {
            sb.Append(' ', y * 4);
            sb.AppendLine(InputY[y] == 1 ? xString : negXSting);
        }
        sb.Append('_', Length*4);
        sb.AppendLine();
        sb.Append(Coeffs.Select(c => c.ToString().PadLeft(4)).Str());
        return sb.ToString();
    }
    public override string ToString() => Coeffs.Str(" ");
}
