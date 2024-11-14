using System;
using System.Numerics;

namespace MathLib;
public static class IntExtensions
{
    public static int Mod(this int integer, int modulus)
    {
        if (modulus == 0)
            throw new DivideByZeroException("The divisor must not be zero.");

        return (integer % modulus + modulus) % modulus;
    }
}
