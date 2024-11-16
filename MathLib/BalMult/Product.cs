using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;

namespace MathLib.BalMult;
public class Product
{
    public BigInteger Integer => InputX.Integer * InputY.Integer;

    public Input InputX { get; }
    public Input InputY { get; }

    public int Length => XLength + YLength - 1;
    public int XLength => InputX.Length;
    public int YLength => InputY.Length;

    public Product(BigInteger x, BigInteger y)
    {
        InputX = new Input(x);
        InputY = new Input(y);
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

    public IEnumerable<int> Counts => Enumerable.Range(0, Length).Select(i => InputCells(i).Count());

    public int this[int index] => InputCells(index).Select(t => InputX[t.xIndex] * InputY[t.yIndex]).Sum();

    public IEnumerable<int> Coeffs => Enumerable.Range(0, Length).Select(i => this[i]);


    public string ToExtendedString()
    {

        string xString = InputX.ToString(4);

        StringBuilder sb = new();
        for (int y = 0; y < YLength; y++)
        {
            sb.Append(' ', y * 4);
            sb.AppendLine(xString);
        }
        sb.Append('_', Length*4);
        sb.AppendLine();
        sb.AppendLine(Coeffs.Select(c => c.ToString().PadLeft(4)).Str());
        return sb.ToString();
    }
    public override string ToString() => Coeffs.Str(" ");
}
