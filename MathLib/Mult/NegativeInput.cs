using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace MathLib.Mult;

public class NegativeInput : InputBase
{
    public readonly Input Positive;
    

    public NegativeInput(Input positive) => this.Positive = positive;

    public override int this[int index]
    {
        get => index == 0
                ? Positive[index]
                : 1 - Positive[index];
        set => Positive[index] = 1 - value;
    }

    public override bool IsSet(int index) => Positive.IsSet(index);
    
    public override void Fill(BigInteger number)
    {
        if (number >= 0)
            throw new InvalidOperationException("Cannot fill input with positive number");
        Positive.Fill(-number);
    }

    public override IEnumerable<int> Coeffs => Enumerable.Range(0, Length).Select(i => this[i]);

    public override int Length => Positive.Length;

  
}



