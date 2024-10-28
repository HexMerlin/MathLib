using System.Collections.Generic;
using System.Linq;
namespace MathLib.Mult;

public class NegativeInput : IInput
{
    public readonly Input Positive;
   
    public NegativeInput(Input positive) => this.Positive = positive;

    public int this[int index]
    {
        get => index == 0
                ? 1
                : 1 - Positive.Coeffs[index];
        set => Positive.Coeffs[index] = 1 - value;
    }

    public bool Locked(int index) => Positive.Locked(index);

    public void SetLocked(int index, bool locked) => Positive.SetLocked(index, locked);

    public IEnumerable<int> Coeffs => Enumerable.Range(0, Length).Select(i => this[i]);

    public int Length => Positive.Length;
}



