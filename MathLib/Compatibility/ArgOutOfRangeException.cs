using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.Compatibility;
internal class ArgOutOfRangeException
{

    internal static void ThrowIfZero(BigInteger value, string paramName)
    {
        if (value.IsZero) throw new ArgumentOutOfRangeException(paramName, "Value must be non-zero.");
    }

    internal static void ThrowIfNegative(BigInteger value, string paramName)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(paramName, "Value must be non-negative.");
    }

    internal static void ThrowIfLessThan(BigInteger value, BigInteger other,  string paramName)
    {
        if (value < other) throw new ArgumentOutOfRangeException(paramName, $"Value must not be less than {other}");
    }

    internal static void ThrowIfGreaterThan(BigInteger value, BigInteger other, string paramName)
    {
        if (value > other) throw new ArgumentOutOfRangeException(paramName, $"Value must not be less than {other}");
    }
    


}
