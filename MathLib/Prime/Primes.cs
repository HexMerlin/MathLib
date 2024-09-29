#nullable enable
using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace MathLib.Prime;

/// <summary>
/// Provides operations related to primes, such as factorization
/// </summary>
/// <remarks>
/// The method <see cref="Factorization"/> uses a highly parallelized algorithm. 
/// Since it will utilize all available cores, it will (for reduced context-switching and maximum performance) enforce only serial
/// execution between separate calls to the method. 
/// 
/// The class does not consume any memory before being activated. This happens if either one of the main operations are called, 
/// or via an explicit call to <see cref="Prepare(Action?)"/>
/// </remarks>
public sealed class Primes
{
    private static readonly Lazy<Primes> instance = new Lazy<Primes>(() => new Primes(), LazyThreadSafetyMode.ExecutionAndPublication);
       
    /// <summary>
    /// Lock to enforce only one factorization method running at a time
    /// </summary>
    private static readonly object factorizationLock = new object();

    private readonly int[][] primeArrays;

    /// <summary>
    /// The maximum prime supported in factorization.
    /// </summary>
    public const int MaxSupportedPrime = 2000000000;

    /// <summary>
    /// Initializes a new instance of the <see cref="Primes"/> class.
    /// </summary>
    /// <param name="maxPrime">The maximum prime number supported. Default value is <see cref="MaxSupportedPrime"/>.</param>
    /// <param name="threadCount">The number of threads to use for generating prime numbers. Default value is -1, which means it will use the number of processors available in the system.</param>
    private Primes(int maxPrime = MaxSupportedPrime, int threadCount = -1)
    {
        if (threadCount <= 0)
            threadCount = Environment.ProcessorCount;
        maxPrime = Math.Min(maxPrime, MaxSupportedPrime);

        this.primeArrays = PrimeArrayChunks(maxPrime, threadCount);
    }

    /// <summary>
    /// Gets a value indicating whether the Primes instance is ready. All calls to this class will be queued until instance is ready
    /// </summary>
    public static bool IsReady => instance.IsValueCreated;

    private static int[][] PrimeArrayChunks(int maxPrime, int chunkCount)
    {
        List<int>[] primeLists = Enumerable.Range(0, chunkCount).Select(_ => new List<int>()).ToArray();

        int primeCount = 0;

        foreach (int prime in PrimeGenerator.GeneratePrimes())
        {
            primeCount++;
            primeLists[primeCount % chunkCount].Add(prime);
            if (prime >= maxPrime) //stop when we have a prime >= maxPrime
                break;
        }

        int[][] primeArrays = new int[chunkCount][];
        for (int i = 0; i < chunkCount; i++)
            primeArrays[i] = primeLists[i].ToArray();
        return primeArrays;
    }

    /// <summary>
    /// Prepares the Primes instance for use in the background. 
    /// </summary>
    /// <remarks>
    /// This method returns instantly.
    /// If <see cref="Prepare(Action?)"/> is not called, everything will still work perfectly, 
    /// but the first operation could take longer to complete.
    /// 
    /// </remarks>
    /// <param name="instanceReadyCallback">An optional callback to be invoked when the instance is ready.</param>
    public static void Prepare(Action? instanceReadyCallback = null)
    {
        if (instance.IsValueCreated)
            instanceReadyCallback?.Invoke();
        else
            _ = Task.Run(() =>
            {
                Primes _ = instance.Value; // Force creation of the instance
                instanceReadyCallback?.Invoke(); // Signal that creation is complete
            });
    }

    /// <summary>
    /// Performs the prime factorization of a given integer.
    /// </summary>
    /// <param name="integer">The integer to be factorized.</param>
    /// <returns>A <see cref="Factorization"/> object containing the prime factors and a remaining factor (that can be 1).</returns>
    /// <seealso cref="Factorization"/>

    public static Factorization Factorization(BigInteger integer)
    {
        lock (factorizationLock)
        {
            Factorization factorization = instance.Value.InternalFactorization(integer);
            return factorization;
        }
    }

    private Factorization InternalFactorization(BigInteger dividend)
    {
        if (dividend == 0)
            return new Factorization(new int[0], 0);

        int sign = dividend.Sign;
        dividend = BigInteger.Abs(dividend);

        List<int> primeFactors = new();

        using ReaderWriterLockSlim dividendAndResultLock = new ReaderWriterLockSlim();

        Parallel.ForEach(primeArrays, primeArray =>
        {
            BigInteger localDividend = -1; //will be updated inside the inner loop
            List<int> localPrimeFactors = new();

            for (int index = 0; index < primeArray.Length; index++)
            {
                if (index % 1024 == 0)
                {
                    dividendAndResultLock.EnterReadLock();
                    localDividend = dividend; //update dividend integer occasionally
                    dividendAndResultLock.ExitReadLock();
                }
                int prime = primeArray[index];
                if (prime > localDividend)
                    break; //no need to continue

                if (localDividend % prime == 0) //found a prime factor
                {
                    dividendAndResultLock.EnterWriteLock();
                    dividend /= prime;
                    localDividend = dividend;
                    dividendAndResultLock.ExitWriteLock();

                    localPrimeFactors.Add(prime);
                    index--; //stay on the same prime, as it may divide multiple times
                    continue;
                }
            }
            dividendAndResultLock.EnterWriteLock();
            primeFactors.AddRange(localPrimeFactors);
            dividendAndResultLock.ExitWriteLock();
        });

        return new Factorization(primeFactors.OrderBy(p => p).ToArray(), dividend * sign);
    }
}

