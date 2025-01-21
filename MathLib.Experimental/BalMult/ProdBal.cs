using System.Text;


namespace MathLib.Experimental.BalMult;

public class ProdBal
{
    public readonly int[] X;
    public readonly int[] Y;

    public int InputLength => X.Length;

    public int ProductLength => (X.Length << 1) - 1;

    public ProdBal(int x, int y)
    {
        (x, y) = x.Abs() >= y.Abs() ? (x, y) : (y, x);
        this.X = x.ToBalancedBits().ToArray();
        this.Y = y.ToBalancedBits(X.Length).ToArray();
    }
    
    public int this[int x, int y] => X[x] == Y[y] ? 1 : -1;

    /// <summary>
    /// Gets the product balance at the specified index.
    /// </summary>
    /// <param name="productIndex">The index of the product balance to get.</param>
    /// <returns>The product balance at the specified index.</returns>
    public int this[int productIndex]
    {
        get
        {
            int startRow = Math.Max(0, productIndex - InputLength + 1);
            int endRow = Math.Min(productIndex, InputLength - 1);
            int sum = 0;
            for (int yIndex = startRow; yIndex <= endRow; yIndex++)
            {
                int xIndex = productIndex - yIndex;
                sum += this[yIndex, xIndex];
            }
            return sum;
        }
    }

    public IEnumerable<int> ProdCoeffs()
    {
        for (int i = 0; i < ProductLength; i++)
            yield return this[i];
    }

    public static string Colorize(int val, int coeffWidth = 0) => val switch
    {
        -1 => $"\u001b[31m{"-".PadLeft(coeffWidth)}\u001b[0m",
        1 => $"\u001b[34m{"+".PadLeft(coeffWidth)}\u001b[0m",
        0 => $"\u001b[32m{"0".PadLeft(coeffWidth)}\u001b[0m",
        _ => val.ToString().PadLeft(coeffWidth)
    };

    public string ToStringExpanded()
    {
        StringBuilder sb = new();
        for (int y = 0; y < InputLength; y++)
        {
            for (int x = 0; x < InputLength; x++)
            {
                int val = this[x, y];
                sb.Append(Colorize(val));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public string ToString(int coeffWidth = 5) => ProdCoeffs().Select(c => Colorize(c, coeffWidth)).Str();

    public override string ToString() => ProdCoeffs().Select(Colorize).Str();

}
