using System;
using System.Numerics;
using System.Collections.Generic;
using MathLib;
using System.Linq;
using System.Buffers.Text;

namespace MathLib.Mult;

public enum LockState
{
    Permanent,
    Locked,
    Free,
}

public class Input : IInput
{
    public int[] Coeffs { get; }
    public int Length => Coeffs.Length;

    private LockState[] locked { get; }

    public bool Locked(int index) => index >= Length || locked[index] != LockState.Free;

    public void SetLocked(int index, bool locked)
    {
        if (index < 0 || index >= Length)
            throw new IndexOutOfRangeException($"Index {index} for {nameof(SetLocked)} is out of range");
        if (this.locked[index] == LockState.Permanent)
            throw new InvalidOperationException("Cannot modify a permanent lock");
        this.locked[index] = locked ? LockState.Locked : LockState.Free;
    }

    IEnumerable<int> IInput.Coeffs => Coeffs;

   
    public int this[int index]
    {
        get => index < Length ? Coeffs[index] : 0;
        set
        {
            if (value == Coeffs[index]) return;

            Coeffs[index] = 
                Locked(index)
                ? throw new InvalidOperationException("Cannot change a locked value")
                : Coeffs[index] = value;
        }
    }

    public static Input Fill(BigInteger number)
    {
        int[] coeffs = ToBitArray(number);
        return new Input(coeffs);
    }

    public Input(int length) : this(new int[length])
    {

    }
    
    public Input(int[] coeffs)
    {
        Coeffs = coeffs;
        locked = new LockState[Length];
        
        Array.Fill(locked, LockState.Free, 0, Length);

        Coeffs[0] = 1;
        Coeffs[^1] = 1;
        locked[0] = LockState.Permanent;
        locked[^1] = LockState.Permanent;

    }
 
    public static int[] ToBitArray(BigInteger integer) 
    {
        Qp qp = new Qp(integer, 1, 2);
        return qp.Generator.Coefficients().Take(qp.Generator.Length).ToArray();
    }
    public override string ToString() => Enumerable.Range(0, Length).Select(i => Coeffs[i]).Str();

    public string ToStringLocked() => Enumerable.Range(0, Length).Select(i => $"{Coeffs[i]}{(Locked(i) ? "L" : "")}").Str();

}




