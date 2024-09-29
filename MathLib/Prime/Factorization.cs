#nullable enable

using System;
using System.Linq;
using System.Numerics;

namespace MathLib.Prime;


/// <summary>
/// Represents the prime factorization of an integer, which may be partial.
/// Handles composite remainder factors and negative integers.
/// </summary>
/// <remarks>
/// This class is immutable. The factorization is initialized via a primary constructor that accepts
/// the prime factors and the remainder factor.
/// </remarks>
public sealed class Factorization
{
    /// <summary>
    /// The prime factors in ascending order. True primes (meaning all are positive).
    /// </summary>
    public readonly int[] PrimeFactors;

    /// <summary>
    /// The remainder after factoring, which may be composite if the factorization is partial.
    /// If the input was negative, the remainder is also negative.
    /// </summary>
    public readonly BigInteger RemainderFactor;

    /// <summary>
    /// Initializes a new instance of the <see cref="Factorization"/> class.
    /// </summary>
    /// <param name="primeFactors">An array of prime factors in ascending order.</param>
    /// <param name="remainderFactor">
    /// The remainder after factoring, which may be composite or negative.
    /// If the input integer is negative, the remainder factor carries the negative sign.
    /// </param>
    public Factorization(int[] primeFactors, BigInteger remainderFactor)
    {
        PrimeFactors = primeFactors;
        RemainderFactor = remainderFactor;
    }

    /// <summary>
    /// Indicates if the factorization is complete (RemainderFactor is ±1).
    /// </summary>
    public bool IsComplete => RemainderFactor.IsZero || RemainderFactor.Abs().IsOne;

    /// <summary>
    /// Indicates if the factored number is zero.
    /// </summary>
    public bool IsZero => RemainderFactor.IsZero;

    /// <summary>
    /// Indicates if the factored number is one.
    /// </summary>
    public bool IsOne => PrimeFactors.Length == 0 && RemainderFactor.IsOne;

    /// <summary>
    /// The total count of factors, including the remainder if it is not ±1.
    /// </summary>
    public int FactorCount => PrimeFactors.Length + (IsComplete ? 0 : 1);

    /// <summary>
    /// Indicates if this factorization is equal to another.
    /// </summary>
    /// <param name="other">The factorization to compare with.</param>
    /// <returns><see langword="true"/> <c>iff</c> this instance is equal to the <paramref name="other"/>.</returns>
    public bool Equals(Factorization? other)
    => other != null
       && RemainderFactor == other.RemainderFactor
       && PrimeFactors.SequenceEqual(other.PrimeFactors);

    /// <summary>
    /// Indicates if this object is equal to another.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns><see langword="true"/> <c>iff</c> equal to <paramref name="obj"/>.</returns>
    public override bool Equals(object? obj) => obj is Factorization other && Equals(other);

    /// <summary>
    /// Computes the hash code for this factorization.
    /// </summary>
    /// <returns>The hash code.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = RemainderFactor.GetHashCode();
            foreach (int prime in PrimeFactors)
                hash ^= prime.GetHashCode();
            return hash;
        }
    }

    /// <summary>
    /// Recreates the original integer from the prime factors and remainder factor.
    /// </summary>
    public BigInteger FactoredInteger => PrimeFactors.Aggregate(RemainderFactor, (acc, prime) => acc * prime);

    /// <summary>
    /// Returns a string representation of the factorization, including the prime factors and remainder.
    /// </summary>
    /// <returns>A string representing the factorization.</returns>
    public override string ToString()
    {
        string remainderString = PrimeFactors.Length == 0
            ? RemainderFactor.ToString()
            : RemainderFactor == 1
                ? string.Empty
                : " · " + RemainderFactor;
        if (!IsComplete)
            remainderString += '?';

        return string.Join(" · ", PrimeFactors) + remainderString;
    }
}
