using System.Numerics;
using MathLib;

namespace MathLib.DevConsole;

public enum LockState
{
    Permanent,
    Locked,
    Free,
}

public class Input : IInput
{
    public int[] Coeffs { get; }
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

    public int Length => Coeffs.Length;

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

    public Input(int length)
    {
        Coeffs = new int[length];
        locked = new LockState[length];
        
        Array.Fill(locked, LockState.Free, 0, length);

        Coeffs[0] = 1;
        locked[0] = LockState.Permanent;
        Coeffs[^1] = 1;
        locked[^1] = LockState.Permanent;

    }

}




