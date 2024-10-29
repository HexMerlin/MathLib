using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace MathLib.Mult;

public interface IProduct
{
    BigInteger Integer { get; }

    IInput InputX { get; }
    IInput InputY { get; }
    int Length { get; }

    int XLength { get; }
    int YLength { get; }
    
    bool IsInvalid { get; } 
  
    bool DistributeIntegerWithinMinMax();

    IEnumerable<(int xIndex, int yIndex)> InputCells(int index);
    (int min, int max) MinMax(int index);

    string ToStringMinValues() => $"[{Enumerable.Range(0, Length).Select(i => MinMax(i).min).Str(", ")}]";

    string ToStringMaxValues() => $"[{Enumerable.Range(0, Length).Select(i => MinMax(i).max).Str(", ")}]";

    static BigInteger Weight(int index) => BigInteger.One << index;
}
