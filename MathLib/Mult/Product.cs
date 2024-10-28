using System;
using System.Linq;
using System.Diagnostics;
using System.Numerics;


namespace MathLib.Mult;

public class Product
{
    public readonly BigInteger Integer;

    private readonly IInput InputX;
    private readonly IInput InputY;

    public readonly int[] Coeffs;
   
    public int XLength => InputX.Length;
    public int YLength => InputY.Length;

    public int Length => Coeffs.Length;
    
    public bool IsInvalid => XLength == 0;

    private bool IsPositive => Integer >= 0;

    public Product(BigInteger integer, IInput inputX, IInput inputY)
    {
        this.Integer = integer;
        this.InputX = inputX;
        this.InputY = inputY;

        int length = XLength + YLength - 1;
        Coeffs = new int[length];
       
        Coeffs[0] = 1;
        Coeffs[^1] = IsPositive ? 1 : YLength - 1;
    
        if (!SetUnlockedCoeffs())
        {
            Coeffs = Array.Empty<int>();
        }
    }

    private BigInteger LockedSum() => Coeffs.Select((c, i) => Locked(i) ? c * Weight(i) : BigInteger.Zero).Sum();

    //private bool SetIndex(int index, int value)
    //{
    //    if (Locked[index]) throw new InvalidOperationException($"Cannot change locked value at index {index}");
    //    if (value == Coeffs[index]) return true; //no change
    //    Debug.Assert(value >= MinCoeff(index) && value <= MaxCoeff(index));
    //    int delta
    //    return SetUnlockedCoeffs();
    //}

    private bool SetUnlockedCoeffs()
    {
        BigInteger rem = Integer - LockedSum();
        if (rem < 0) return false;
        for (int i = Length - 1; i >= 0; i--)
        {
            if (Locked(i)) continue;
            int coeff = (int)BigInteger.Min(MaxCoeff(i), rem / Weight(i));
            Coeffs[i] = coeff;
            rem -= coeff * Weight(i);
        }

        //if (rem.IsZero) AssertMinCoeffs(); //this check should always pass
        return rem.IsZero;
    }

    private void AssertMinCoeffs()
    {
        for (int i = 0; i < Length; i++)
        {
            Debug.Assert(Coeffs[i] >= MinCoeff(i));
        }
    }

    public int MinCoeff(int xIndex)
    {
        int firstRow = xIndex == 0 || xIndex == XLength - 1 ? 1 : 0;
        int lastRow = xIndex == YLength - 1 || xIndex == XLength + YLength - 2 ? 1 : 0;
        return firstRow + lastRow;
    }

    public int ValueCount(int xIndex)
    {
        int startRow = Math.Max(0, xIndex - XLength + 1);
        int endRow = Math.Min(xIndex, YLength - 1);

        return startRow <= endRow ? endRow - startRow + 1 : 0;
    }

    public int MaxCoeff(int xIndex)
    {
        return ValueCount(xIndex); //this will not be same for negative numbers
    }

    public bool Locked(int index)
    {
        for (int i = 0; i <= index; i++)
        {
            if (!InputX.Locked(index - i) || !InputY.Locked(i)) return false;
        }
           
        return true;
    }

    /// <summary>
    /// Computes the column sum at a specified <paramref name="columnIndex"/>.
    /// </summary>
    /// <param name="columnIndex">Column index for which the sum is calculated.</param>
    /// <returns>Sum of values in the specified column.</returns>
    public int ColumnSum(int columnIndex)
    {
        int columnSum = 0;
      
        // Calculate range of rows where InputY[r] affects columnIndex
        int startRow = Math.Max(0, columnIndex - InputX.Length + 1);
        int endRow = Math.Min(columnIndex, InputY.Length - 1);

        for (int r = startRow; r <= endRow; r++)
        {
            if (InputY[r] == 1)
            {
                int xIndex = columnIndex - r;
                columnSum += InputX[xIndex];
            }
        }

        return columnSum;
    }



    private static BigInteger Weight(int index) => BigInteger.One << index;

    public BigInteger Number => Coeffs.Select((c, i) => c * Weight(i)).Sum();

    public override string ToString() => IsInvalid ? "Invalid" : $"[{Coeffs.Str(", ")}]";

    public string ToStringColumnSums() => $"[{Enumerable.Range(0, Length).Select(ColumnSum).Str(", ")}]";
    //public string ToStringLockedValues() => $"[{Enumerable.Range(0, Length).Select(i => $"{Coeffs[i]}{(Locked(i) ? "L" : "")}").Str(", ")}]";

    public string ToStringLockedValues() => $"[{Enumerable.Range(0, Length).Select(i => Locked(i) ? "L" : "U").Str(", ")}]";

    public string ToStringMinValues() => $"[{Enumerable.Range(0, Length).Select(MinCoeff).Str(", ")}]";

    public string ToStringMaxValues() => $"[{Enumerable.Range(0, Length).Select(MaxCoeff).Str(", ")}]";
}
