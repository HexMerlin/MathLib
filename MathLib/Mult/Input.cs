using System;
using System.Numerics;
using System.Collections.Generic;
using MathLib;
using System.Linq;
using System.Buffers.Text;

namespace MathLib.Mult;



public class Input : IInput
{
    private int[] coeffs { get; }
    public int Length => coeffs.Length;

    public NegativeInput Negative() => new NegativeInput(this);

    IEnumerable<int> IInput.Coeffs => coeffs;

    public bool IsSet(int index) => index >= Length || coeffs[index] != -1;

    public int this[int index]
    {
        get => index < Length ? coeffs[index] : 0;
        set
        {
            if (value == coeffs[index]) return;
            if (index == 0 || index == Length - 1)
                throw new InvalidOperationException("Cannot change the first or last coefficient");
            coeffs[index] = value;
        }
    }

    public void Fill(BigInteger number)
    {
        if (number <= 0)
            throw new InvalidOperationException("Cannot fill input with non-positive number");
        int[] coeffs = ToBitArray(number);
        if (coeffs.Length != Length)
            throw new InvalidOperationException("Cannot fill input with unmatching length");
        Array.Copy(coeffs, this.coeffs, Length);
    }

    private Input(int[] coeffs) => this.coeffs = coeffs;

    public Input(int length) 
    {
        this.coeffs = new int[length];
        Array.Fill(coeffs, -1);
        this.coeffs[0] = 1;
        this.coeffs[^1] = 1;
    }

    public static int[] ToBitArray(BigInteger integer) 
    {
        Qp qp = new Qp(integer, 1, 2);
        return qp.Generator.Coefficients().Take(qp.Generator.Length).ToArray();
    }
    public override string ToString() => Enumerable.Range(0, Length).Select(i => this[i] == -1 ? "?" : this[i].ToString()).Str();

}



//public void SetLocked(int index, bool locked)
//{
//    if (index < 0 || index >= Length)
//        throw new IndexOutOfRangeException($"Index {index} for {nameof(SetLocked)} is out of range");
//    if (this.locked[index] == LockState.Permanent)
//        throw new InvalidOperationException("Cannot modify a permanent lock");
//    this.locked[index] = locked ? LockState.Locked : LockState.Free;
//}


