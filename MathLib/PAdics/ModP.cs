using System;
using System.Numerics;

namespace MathLib.PAdics;

/// <summary>
/// Represents an element in the finite field GF(p), where p is a prime number.
/// This class supports arithmetic operations modulo p, including addition, subtraction,
/// multiplication, and division. These operations are performed in the context of a 
/// Galois field, ensuring that the results stay within the finite field.
/// </summary>
public class ModP
{
    /// <summary>
    /// The value of the element in the finite field GF(p).
    /// </summary>
    public BigInteger N { get; private set; }

    /// <summary>
    /// The prime modulus p defining the finite field GF(p).
    /// </summary>
    public BigInteger P { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModP"/> class, representing
    /// an element in the finite field GF(p).
    /// </summary>
    /// <param name="n">The value of the element.</param>
    /// <param name="p">The prime modulus p that defines the finite field GF(p).</param>
    /// <exception cref="ArgumentException">Thrown when p is not a prime number.</exception>
    public ModP(BigInteger n, BigInteger p)
    {
        if (!IsPrime(p))
            throw new ArgumentException("The modulus p must be a prime number.");

        N = (n % p + p) % p;  // Ensure N is within the range [0, p-1]
        P = p;
    }

    /// <summary>
    /// Adds two elements in the finite field GF(p).
    /// </summary>
    /// <param name="a">An element in the finite field GF(p).</param>
    /// <param name="b">Another element in the finite field GF(p).</param>
    /// <returns>The sum of the two elements, also an element of GF(p).</returns>
    /// <example>
    /// <code>
    /// var a = new ModP(3, 5);
    /// var b = new ModP(4, 5);
    /// var result = a + b; // result is 2 in GF(5)
    /// </code>
    /// </example>
    public static ModP operator +(ModP a, ModP b)
    {
        if (a.P != b.P) throw new ArgumentException("Elements must be from the same finite field.");
        return new ModP(a.N + b.N, a.P);
    }

    /// <summary>
    /// Subtracts one element from another in the finite field GF(p).
    /// </summary>
    /// <param name="a">An element in the finite field GF(p).</param>
    /// <param name="b">Another element in the finite field GF(p).</param>
    /// <returns>The difference of the two elements, also an element of GF(p).</returns>
    /// <example>
    /// <code>
    /// var a = new ModP(3, 5);
    /// var b = new ModP(4, 5);
    /// var result = a - b; // result is 4 in GF(5)
    /// </code>
    /// </example>
    public static ModP operator -(ModP a, ModP b)
    {
        if (a.P != b.P) throw new ArgumentException("Elements must be from the same finite field.");
        return new ModP(a.N - b.N, a.P);
    }

    /// <summary>
    /// Multiplies two elements in the finite field GF(p).
    /// </summary>
    /// <param name="a">Ab element in the finite field GF(p).</param>
    /// <param name="b">Another element in the finite field GF(p).</param>
    /// <returns>The product of the two elements, also an element of GF(p).</returns>
    /// <example>
    /// <code>
    /// var a = new ModP(3, 5);
    /// var b = new ModP(4, 5);
    /// var result = a * b; // result is 2 in GF(5)
    /// </code>
    /// </example>
    public static ModP operator *(ModP a, ModP b)
    {
        if (a.P != b.P) throw new ArgumentException("Elements must be from the same finite field.");
        return new ModP(a.N * b.N, a.P);
    }

    /// <summary>
    /// Divides one element by another in the finite field GF(p).
    /// </summary>
    /// <param name="a">Ab element in the finite field GF(p).</param>
    /// <param name="b">Another element in the finite field GF(p).</param>
    /// <returns>The quotient of the two elements, also an element of GF(p).</returns>
    /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero.</exception>
    /// <example>
    /// <code>
    /// var a = new ModP(3, 5);
    /// var b = new ModP(4, 5);
    /// var result = a / b; // result is 2 in GF(5)
    /// </code>
    /// </example>
    public static ModP operator /(ModP a, ModP b)
    {
        if (a.P != b.P) throw new ArgumentException("Elements must be from the same finite field.");
        return a * b.Inverse();
    }

    /// <summary>
    /// Computes the multiplicative inverse of this element in the finite field GF(p).
    /// </summary>
    /// <returns>The multiplicative inverse of this element, which, when multiplied by the original element, 
    /// results in 1 in the finite field GF(p). This operation is essential in division within the field.
    /// </returns>
    /// <exception cref="DivideByZeroException">
    /// Thrown when the element is zero because zero does not have a multiplicative inverse.
    /// </exception>
    /// <example>
    /// <code>
    /// var a = new ModP(3, 5);
    /// var inverse = a.Inverse(); // inverse is 2 in GF(5) because 3 * 2 % 5 = 1
    /// </code>
    /// </example>
    /// <remarks>
    /// The multiplicative inverse of an element "a" in a finite field GF(p) is another element "b" such that 
    /// the product of "a" and "b" is congruent to 1 modulo p. For example, in GF(5), the multiplicative inverse 
    /// of 3 is 2 because (3 * 2) % 5 = 1. This method uses the Extended Euclidean Algorithm to find such an element.
    /// </remarks>
    public ModP Inverse()
    {
        if (N == 0) throw new DivideByZeroException("Zero has no multiplicative inverse.");

        BigInteger t = 0, newT = 1;
        BigInteger r = P, newR = N;

        // Extended Euclidean Algorithm to find the inverse
        while (newR != 0)
        {
            BigInteger quotient = r / newR;
            (t, newT) = (newT, t - quotient * newT);
            (r, newR) = (newR, r - quotient * newR);
        }

        // If the greatest common divisor is greater than 1, inverse doesn't exist
        if (r > 1) throw new DivideByZeroException("The element has no multiplicative inverse.");

        // Ensure the result is positive
        if (t < 0) t += P;

        return new ModP(t, P);
    }


    /// <summary>
    /// Indicates whether the specified element is equal to the current element.
    /// </summary>
    /// <param name="obj">Another element to compare with.</param>
    /// <returns><see langword="true"/> <c>iff</c> the elements are equal.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is ModP other)
            return N == other.N && P == other.P;
        return false;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>A hash code for this instance.</returns>
    public override int GetHashCode() => HashCode.Combine(N, P);

    /// <summary>
    /// Returns a string that represents the current element.
    /// </summary>
    /// <returns>A string that represents the current element in the format "n % p".</returns>
    /// <example>
    /// <code>
    /// var a = new ModP(3, 5);
    /// Console.WriteLine(a); // Outputs "3 % 5"
    /// </code>
    /// </example>
    public override string ToString() => $"{N} % {P}";

    /// <summary>
    /// Indicates whether a given number is prime.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><see langword="true"/> <c>iff</c> the number is prime.</returns>
    private static bool IsPrime(BigInteger number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        for (BigInteger i = 5; i * i <= number; i += 6)
            if (number % i == 0 || number % (i + 2) == 0)
                return false;

        return true;
    }
}