using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MathLib.BalMult;

public class Product3
{

    public readonly int Product; 
    public readonly int[] Coeffs;

    public Product3(int product, int minLength)
    {
        int productLength = product.ToBalancedBits(minLength).Count();
        if (productLength.IsEven()) productLength++;
        productLength += 2;

        Coeffs = product.ToBalancedBits(productLength).ToArray(); 
    }

    public bool Request(int index, int requested)
    {
        int cur = Coeffs[index];
        if (requested == cur) return true;
        if (requested == 0) return false;

        int len = 1;
        for (; len < Coeffs.Length; len++)
            if (Coeffs[index + len] != cur) break;
        
        if (len == Coeffs.Length) 
            return false;

        Span<int> span = Coeffs.AsSpan(index, len + 1);
        
        span.Fill(0);
        span[0] = -cur;
        return true;
    }

    public void PrintSequencesForInteger(int N, int L)
    {
        foreach (var seq in SequencesForInteger(N, L))
        {
            Console.WriteLine(seq.Select(c => BitColorString(c)).Str());    
        }

    }

    /// <summary>
    /// Generates all sequences of digits {-1, 0, 1} of length <paramref name="sequenceLength"/> 
    /// such that their weighted sum in base 2 equals <paramref name="integer"/>.
    /// </summary>
    /// <param name="integer">
    /// The target sum to achieve by summing the weighted sequence of digits.
    /// </param>
    /// <param name="sequenceLength">
    /// The length of the sequences to generate.
    /// </param>
    /// <remarks>
    /// Each sequence represents a series of digits, where the weight of each digit is determined by its position 
    /// as a power of 2 (e.g., for position <c>i</c>, the weight is <c>2^i</c>). 
    /// <para>If the length is not large enough to represent the target sum, the method will return an empty sequence.</para>
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
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="sequenceLength"/> is negative, as sequences of negative length are not meaningful.
    /// </exception>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of immutable <see cref="ReadOnlyCollection{T}"/> instances, 
    /// each representing a sequence of integers {-1, 0, 1} satisfying the criteria. 
    /// The returned sequences are views over the same internal array and should 
    /// be consumed or copied immediately if persistent storage is required.
    /// </returns>
    public static IEnumerable<ReadOnlyCollection<int>> SequencesForInteger(int integer, int sequenceLength)
    {
        // Precompute weights (powers of 2) and cumulative sums
        int[] weights = new int[sequenceLength];
        int[] remainingWeightsSum = new int[sequenceLength + 1];
        int remSum = 0;
        for (int i = sequenceLength - 1; i >= 0; i--)
        {
            weights[i] = 1 << i;
            remSum += weights[i];
            remainingWeightsSum[i] = remSum;
        }

        var sequence = new int[sequenceLength];

        return Backtrack(0, 0);

        IEnumerable<ReadOnlyCollection<int>> Backtrack(int pos, int currentSum)
        {
            if (pos == sequenceLength)
            {
                if (currentSum == integer)
                    yield return sequence.AsReadOnly();
                yield break;
            }

            int weight = weights[pos];
            int remWeightsSum = remainingWeightsSum[pos + 1];

            for (int coeff = -1; coeff <= 1; coeff++)
            {
                int newSum = currentSum + coeff * weight;

                // prune branches, that can't reach the target sum
                if (newSum - remWeightsSum <= integer && newSum + remWeightsSum >= integer)
                {
                    sequence[pos] = coeff;
                    foreach (ReadOnlyCollection<int> result in Backtrack(pos + 1, newSum))
                        yield return result;
                }
            }
        }
    }


   

    public string ToString(int coeffWidth) => Coeffs.Select(c => BitColorString(c, coeffWidth)).Str();

    private static string BitColorString(int bit, int coeffWidth = 0) => $"{(bit == 0 ? Input3.GreenColorCode : bit < 0 ? Input3.RedColorCode : Input3.BlueColorCode)}{(bit == 0 ? '0' : bit == 1 ? Input3.PlusChar : Input3.MinusChar).ToString().PadLeft(coeffWidth)}{Input3.ResetColorCode}";


    public override string ToString() => ToString(1);

}
