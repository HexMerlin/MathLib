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

    public Product(BigInteger x, BigInteger y)
    {
        if (x.Abs() >= y.Abs())
        {
            InputX = new Input(x);
            InputY = new Input(y, InputX.Length);
        }
        else
        {
            InputY = new Input(y);
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

    //public static IEnumerable<(int i1, int i2)> IndexPairs(int xLength, int yLength)
    //{
    //    int min = Math.Min(xLength, yLength);
    //    int length = xLength + yLength - 1;
    //    for (int i1 = 0; i1 < length; i1++)
    //    {
    //        int i2 = BalDigits.Count(i1, xLength, yLength).IsEven() && i1 + 1 < length && BalDigits.Count(i1 + 1, xLength, yLength).IsOdd() ? i1 + 1 : -1;
    //        yield return (i1, i2); 
    //        if (i2 != -1)
    //            i1++;
    //    }
    //}

    //public static IEnumerable<(int i1, int i2)> IndexPairs(int xLength, int yLength)
    //{
    //    int min = Math.Min(xLength, yLength);
    //    int length = xLength + yLength - 1;
    //    int p = min / 2; //number of pairs
    //    int p2 = p * 2; //paired length
    //    int centerLength = length - p2 * 2;

    //    for (int i = 0; i < p2; i += 2)
    //        yield return (i, i + 1);

    //    for (int i = p2; i < p2 + centerLength; i++)
    //        yield return (i, -1);

    //    for (int i = p2 + centerLength; i < length - 1; i += 2)
    //        yield return (i, i + 1);
    //}

    //public IEnumerable<int> PairedSums()
    //{
    //    foreach ((int i1, int i2) in IndexPairs(XLength, YLength))
    //    {
    //        if (i2 == -1)
    //            yield return this[i1];
    //        else
    //            yield return this[i1] + this[i2]*2;
    //    }
    //}

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
