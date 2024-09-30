using System.Collections.Generic;

namespace MathLib;
/// <summary>
/// Provides extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Joins the elements of the enumerable into a string, separated by the specified delimiter.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable.</typeparam>
    /// <param name="source">The enumerable to join.</param>
    /// <param name="delimiter">The delimiter to insert between each element. Defaults to an empty string.</param>
    /// <returns>A string with the joined elements.</returns>
    public static string Str<T>(this IEnumerable<T> source, string delimiter = "") =>
        string.Join(delimiter, source);
}