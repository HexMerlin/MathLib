using System;

namespace MathLib.Experimental.BalMult;

public readonly struct ProdCoeff
{
    public readonly int Min;
    public readonly int Max;
    public bool IsEven => Min.IsEven();

    public ProdCoeff(int min, int max)
    {
        if (min.IsEven() != max.IsEven())
            throw new ArgumentException("Min and Max must have the same parity");
        this.Min = min;
        this.Max = max;
    }
    
    public ProdCoeff ShiftRange(bool lift) => lift ? new ProdCoeff(Min + 1, Max + 1) : new ProdCoeff(Min - 1, Max - 1);

    public ProdCoeff Widen() => new ProdCoeff(Min - 1, Max + 1);

    public static ProdCoeff TheoreticalLimit(int productIndex, int productLength)
    {
        int max = productIndex <= productLength / 2 ? productIndex + 1 : productLength - productIndex;
        int min = -max;
        return new ProdCoeff(min, max);
    }

    public override string ToString() => Min == Max ? Min.ToString() : $"[{Min},{Max}]";
}
