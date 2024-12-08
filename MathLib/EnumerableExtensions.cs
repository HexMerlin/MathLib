using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathLib;
/// <summary>
/// Provides extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{

    /// <summary>
    /// Joins the elements of the enumerable into a string, separated by the specified delimiter.
    /// Each element is left-padded to meet a specified total width.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable. Must not be null.</typeparam>
    /// <param name="source">The enumerable to join.</param>
    /// <param name="delimiter">The delimiter to insert between each element. Defaults to an empty string.</param>
    /// <param name="totalWidth">The total width of each element in the joined string. Defaults to 0 (no padding).</param>
    /// <returns>A string with the joined elements, padded to the specified total width.</returns>
    public static string Str<T>(
        this IEnumerable<T> source,
        string delimiter = "",
        int totalWidth = 0)
        where T : notnull =>
        string.Join(delimiter, source.Select(e => e.ToString()!.PadLeft(totalWidth)));

    /// <summary>
    /// Sum of all elements in the specified <paramref name="source"/>.
    /// </summary>
    /// <param name="source">Collection of <see cref="BigInteger"/> elements.</param>
    /// <returns>Total sum as <see cref="BigInteger"/>.</returns>
    public static BigInteger Sum(this IEnumerable<BigInteger> source) =>
        source.Aggregate(BigInteger.Zero, (total, value) => total + value);
}
