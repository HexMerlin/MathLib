using System;
using System.Numerics;
using System.Collections.Generic;
using MathLib;
using System.Linq;
using System.Buffers.Text;
using System.Diagnostics;

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

    public static Input Create(BigInteger number, bool reverse)
    {
        int[] coeffs = ToBitArray(number);
        if (reverse)
            Array.Reverse(coeffs);

        Input input = new Input(coeffs.Length);
        Array.Copy(coeffs, input.coeffs, coeffs.Length);
        return input;
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


    public static int[] ToBitArrayFactors(BigInteger x, BigInteger y)
    {
        Q qX = new Qp(x, 1, 2).Generator;
        Q qY = new Qp(y, 1, 2).Generator;
        //var p = new Qp(qX * qY, 2);
        //return p.Generator.Coefficients().Take(p.Generator.Length).ToArray();
        var p = new Qb(qX * qY, 2);
        return p.Coefficients().Take(p.Length).ToArray();
    }

    public static int[] ToBitArray(BigInteger integer) 
    {
        Qp qp = new Qp(integer, 1, 2);
        return qp.Generator.Coefficients().Take(qp.Generator.Length).ToArray();
    }

    public static int[] BalancedCoeffs(int[] coeffs)
    {
        int[] result = new int[coeffs.Length];

        bool carry = false;
        for (int i = coeffs.Length - 1; i >= 0; i--)
        {
            if (!carry)
            {
                if (coeffs[i] == 1)
                    result[i] = 1;
                else
                {
                    result[i] = 1;
                    carry = true;
                }
            }
            else
            {
                if (coeffs[i] == 1)
                {
                    result[i] = -1;
                    carry = false;
                }
                else
                    result[i] = -1;


            }
        }
        return result;
    }
}

