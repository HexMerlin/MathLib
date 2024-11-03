using System;
using System.Numerics;
using System.Collections.Generic;
using MathLib;
using System.Linq;
using System.Buffers.Text;

namespace MathLib.Mult;




public class Input : InputBase
{
    public override InputBase Negative => negative;

    private readonly NegativeInput negative;

    private int[] coeffs { get; }
    public override int Length => coeffs.Length;

    public NegativeInput CreateNegative() => new NegativeInput(this);

    public Input(int length) 
    {
        this.coeffs = new int[length];
        Array.Fill(coeffs, -1);
        this.coeffs[0] = 1;
        this.coeffs[^1] = 1;
        this.negative = new NegativeInput(this);
    }

    public override IEnumerable<int> Coeffs => coeffs;

   
    public override bool IsSet(int index) => index >= Length || coeffs[index] != -1;

    public override int this[int index]
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

    public override void Fill(BigInteger number)
    {
        if (number <= 0)
            throw new InvalidOperationException("Cannot fill input with non-positive number");
        int[] coeffs = ToBitArray(number);
        if (coeffs.Length != Length)
            throw new InvalidOperationException("Cannot fill input with non-matching length");
        Array.Copy(coeffs, this.coeffs, Length);
    }

  

    public static int[] ToBitArray(BigInteger integer) 
    {
        Qp qp = new Qp(integer, 1, 2);
        return qp.Generator.Coefficients().Take(qp.Generator.Length).ToArray();
    }
 
}

