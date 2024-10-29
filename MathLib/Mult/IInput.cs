using System.Collections.Generic;
using System.Numerics;

namespace MathLib.Mult;

public interface IInput
{
    int this[int index] { get; set; }

    public int Length { get; }

    bool IsSet(int index);

    public IEnumerable<int> Coeffs { get; }
    public void Fill(BigInteger number);
}
