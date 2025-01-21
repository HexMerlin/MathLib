using MathLib.Misc;

namespace MathLib.Experimental.BalMult;

public class Int3
{

    public readonly int Integer;

    public readonly int[] Bits;

    public int Length => Bits.Length;
    public Int3(int integer, int minLength = 0)
    {
        this.Integer = integer;

        if (minLength == 0)
        {
            minLength = Integer.ToBalancedBits(minLength).Count();
            minLength+=1;
        }
        Bits = new int[minLength]; 
    }

    public int this[int index] => Bits[index];

    /// <summary>
    /// Generates the integer as sequences of bits {-1, 1}
    /// </summary>
    public void SetABalBits()
    {
        for (int i = 0; i < Length; i++)
            Bits[i] = BalBits.BalancedBit(Integer, i, i == Length - 1);
    }

    /// <summary>
    /// Generates all sequences of digits {-1, 0, 1} 
    /// such that their weighted sum in base 2 equals <see cref="Integer"/>.
    /// </summary>
    /// <remarks>
    /// Each sequence represents a series of digits, where the weight of each digit is determined by its position 
    /// as a power of 2 (e.g., for position <c>i</c>, the weight is <c>2^i</c>). 
    /// </remarks>
    /// <example>
    /// For <c>N = -5</c> and <c>L = 4</c>, the output is:
    /// <code>
    ///-0-0
    ///-0+-
    ///+--0
    ///+-+-
    ///++0-
    /// </code>
    /// </example>
    /// <returns>
    /// A collection of int[] arrays,
    /// each representing a sequence of integers {-1, 0, 1} satisfying the criteria. 
    /// The returned sequences are views over the same internal array and should 
    /// be consumed or copied immediately if persistent storage is required.
    /// </returns>
    public IEnumerable<int[]> Sequences()
    {
        // Precompute weights (powers of 2) and cumulative sums
        int[] weights = new int[Length];
        int[] remainingWeightsSum = new int[Length + 1];
        int remSum = 0;
        for (int i = Length - 1; i >= 0; i--)
        {
            weights[i] = 1 << i;
            remSum += weights[i];
            remainingWeightsSum[i] = remSum;
        }

        return Backtrack(0, 0);

        IEnumerable<int[]> Backtrack(int pos, int currentSum)
        {
            if (pos == Length)
            {
                if (currentSum == Integer)
                    yield return Bits;
                yield break;
            }

            int weight = weights[pos];
            int remWeightsSum = remainingWeightsSum[pos + 1];

            for (int coeff = -1; coeff <= 1; coeff++)
            {
                int newSum = currentSum + coeff * weight;

                // prune branches, that can't reach the target sum
                if (newSum - remWeightsSum <= Integer && newSum + remWeightsSum >= Integer)
                {
                    Bits[pos] = coeff;
                    foreach (int[] result in Backtrack(pos + 1, newSum))
                        yield return result;
                }
            }
        }
    }


 
    public string ToString(int coeffWidth = 0) => Bits.Select(c => Product.BitColorString(c, coeffWidth)).Str();

    public override string ToString() => ToString(0);
}


//public bool Request(int index, int requested)
//{
//    int cur = Coeffs[index];
//    if (requested == cur) return true;
//    if (requested == 0) return false;

//    int len = 1;
//    for (; len < Coeffs.Length; len++)
//        if (Coeffs[index + len] != cur) break;

//    if (len == Coeffs.Length) 
//        return false;

//    Span<int> span = Coeffs.AsSpan(index, len + 1);

//    span.Fill(0);
//    span[0] = -cur;
//    return true;
//}
