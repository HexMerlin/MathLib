using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.BalMult;

//public enum Val3 { NegNeg = 0, NegZero = 1, NegPos = 2, ZeroNeg = 3, ZeroZero = 4, ZeroPos = 5, PosNeg = 6, PosZero = 7, PosPos = 8 };

public enum Val3 { PosPos = 0, NegNeg = 1, PosNeg = 2, NegPos = 3, PosZero = 4, NegZero = 5, ZeroZero = 6, ZeroNeg = 7, ZeroPos = 8,    };

public class Input3 : IEquatable<Input3>
{
    public Val3[] Coeffs;

    public int InputLength => Coeffs.Length;

    public int ProductLength => (Coeffs.Length << 1) - 1;

    public Input3(int length)
    {
        Coeffs = new Val3[length];
    }

    public Input3(int product, int minLength)
    {
        int productLength = product.ToBalancedBits(minLength).Count();
        if (productLength.IsEven()) productLength++;
        productLength += 2;
        int inputLength = (productLength + 1) / 2;
        //int inputLength = (productLength) / 2 + 2;

        Coeffs = new Val3[inputLength];
        //Debug.Assert(ProductLength == productLength);
    }

 
    public IEnumerable<int> InputX => Coeffs.Select(c => X(c));

    public IEnumerable<int> InputY => Coeffs.Select(c => Y(c));

    public (int x, int y) ToFactors()
    {
        int x = 0;
        int y = 0;
        int weight = 1;
        for (int i = 0; i < Coeffs.Length; i++)
        {
            x += X(Coeffs[i]) * weight;
            y += Y(Coeffs[i]) * weight;
            weight <<= 1;
        }
        return (x, y);
    }

    public void TrySolve(Product3 product)
    {
        do
        {

        } while (IncreaseCoeffs());
    }

    public void PrintAllMatches(int product)
    {
        Console.WriteLine("Product: " + product);
        //bool isAltParity(int[] arr) => arr.Select((a, i) => i.IsOdd() != a.IsOdd()).All(b => b);
        Reset();
      
        HashSet<Input3> matchSet = new HashSet<Input3>();

        do
        {
            int sum = 0;
            int i = 0;

            //bool prevIsZero = false;
            Input3 x = this.Clone();
         

            for (; i < ProductLength; i++)
            {
                int productCoeff = ProductCoeff_Pruned(i);
                //if (productCoeff == 0)
                //{
                    //if (prevIsZero)
                        //break;
                    //prevIsZero = true;
                //}
                //else prevIsZero = false;

                if (productCoeff.Abs() > 1)
                    break;

                sum += productCoeff * (1 << i);
            }

            if (i == ProductLength && sum == product)
            {
                if (matchSet.Add(this.Clone()))
                {
                    (int xF, int yF) = ToFactors();
                    Console.WriteLine($"\t{xF} * {yF}");
                    Console.WriteLine("     " + ToStringProductColor(5));
                    Console.WriteLine();
                    Console.WriteLine(ToStringDiagonal(10));
                    Console.WriteLine();
                    Console.WriteLine(ToStringExpanded());
                    Console.WriteLine();
                }
               
                //Console.WriteLine(InputX.Str(", ", 3));
                //Console.WriteLine(InputY.Str(", ", 3));
                //Console.WriteLine();
            }
          
        } while (IncreaseCoeffs());
   
    }

    public void Reset() => Array.Fill(Coeffs, (Val3) 0);

    
    /// <summary>
    /// Increases the coefficients of the Input3 instance.
    /// </summary>
    /// <returns>True if the coefficients were successfully increased; otherwise, false.</returns>
    public bool IncreaseCoeffs()
    {
        static Val3 Inc(Val3 val3) => (int) val3 != 8 ? val3 + 1 : 0;
        for (int i = 0; i < Coeffs.Length; i++)
        {
            Coeffs[i] = Inc(Coeffs[i]);
            if (Coeffs[i] != 0)
                return true;
        }
        return false;
    }

    public int Product => Enumerable.Range(0, ProductLength).Select(i => (1 << i) * ProductCoeff(i)).Sum();

    public IEnumerable<int> ProductCoeffs() => Enumerable.Range(0, ProductLength).Select(i => ProductCoeff(i));
    //static int X(Val3 val) => (int)val / 3 - 1;
    //static int Y(Val3 val) => (int)val % 3 - 1;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int X(Val3 val) => (int)val switch
    {
        <= 2 => -1,
        >= 6 => 1,
        _ => 0
    };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Y(Val3 val) => (int)val switch
    {
        0 or 3 or 6 => -1,
        2 or 5 or 8 => 1,
        _ => 0
    };

    public int ProductCoeff_Pruned(int productIndex)
    {
        static int X(Val3 val) => (int)val / 3 - 1;
        static int Y(Val3 val) => (int)val % 3 - 1;

        int startRow = Math.Max(0, productIndex - InputLength + 1);
        int endRow = Math.Min(productIndex, InputLength - 1);
        int sum = 0;
        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = productIndex - yIndex;
            sum += X(Coeffs[xIndex]) * Y(Coeffs[yIndex]);
            if (sum.Abs() > 1)
                return int.MaxValue;
        }
        return sum;
    }

    public int ProductCoeff(int productIndex)
    {
        static int X(Val3 val) => (int)val / 3 - 1;
        static int Y(Val3 val) => (int)val % 3 - 1;

        int startRow = Math.Max(0, productIndex - InputLength + 1);
        int endRow = Math.Min(productIndex, InputLength - 1);
        int sum = 0;
        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = productIndex - yIndex;
            sum += X(Coeffs[xIndex]) * Y(Coeffs[yIndex]);
        }
        return sum;
    }

    public IEnumerable<(int xIndex, int yIndex)> CoeffPairs(int productIndex)
    {
        int startRow = Math.Max(0, productIndex - InputLength + 1);
        int endRow = Math.Min(productIndex, InputLength - 1);

        for (int yIndex = startRow; yIndex <= endRow; yIndex++)
        {
            int xIndex = productIndex - yIndex;
            yield return (xIndex, yIndex);
        }
    }
    public bool Equals(Input3? other) => other is Input3 input && Coeffs.SequenceEqual(input.Coeffs);

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as Input3);

    public static bool operator ==(Input3 left, Input3 right) => left.Equals(right);
    public static bool operator !=(Input3 left, Input3 right) => !left.Equals(right);

    public override int GetHashCode() => Coeffs.Aggregate(0, (hash, value) => HashCode.Combine(hash, value));

    public Input3 Clone() => new Input3(0) { Coeffs = this.Coeffs.ToArray() };

    public const char PlusChar = '+';
    public const char MinusChar = '-';
    public const char ZeroChar = ' ';
    public const char AnyChar = '■';
    public const string GreenColorCode = "\u001b[32m";
    public const string RedColorCode = "\u001b[31m";
    public const string BlueColorCode = "\u001b[34m";
    public const string ResetColorCode = "\u001b[0m";

    public static string ColorString(int val, int coeffWidth = 0) => $"{(val == 0 ? GreenColorCode : val < 0 ? RedColorCode : BlueColorCode)}{val.ToString().PadLeft(coeffWidth)}{ResetColorCode}";
    private static string BitColorString(int bit, int coeffWidth = 0) => $"{(bit == 0 ? GreenColorCode : bit < 0 ? RedColorCode : BlueColorCode)}{(bit == 0 ? '0' : bit == 1 ? PlusChar : MinusChar).ToString().PadLeft(coeffWidth)}{ResetColorCode}";


    public string ToStringProduct(int coeffWidth = 5) => ProductCoeffs().Select(c => c.ToString().PadLeft(coeffWidth)).Str();
    public string ToStringProductColor(int coeffWidth = 5) => ProductCoeffs().Select(c => ColorString(c, coeffWidth)).Str();

    public string ToStringDiagonal(int coeffWidth = 5) => Enumerable.Range(0, InputLength).Select(i => BitColorString(X(Coeffs[i]) * Y(Coeffs[i]), coeffWidth)).Str();

    public string ToStringExpanded()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < InputLength; y++)
        {
            for (int x = 0; x < InputLength; x++)
            {
                int prod = X(Coeffs[x]) * Y(Coeffs[y]);
                sb.Append(BitColorString(prod));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

}
