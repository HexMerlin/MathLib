using MathLib.Prime;
using System.Numerics;
using System.Text;
using System;
using System.Linq;

namespace MathLib;

public partial class Q
{
    /// <summary>
    /// Returns the rational number as a simple canonical representation in base 10.
    /// </summary>
    /// <example>
    /// <code>
    /// Console.WriteLine(new Q(-4,5).ToStringCanonical()); 
    /// //outputs "-4/5"
    /// </code>
    /// </example>
    /// <remarks>An <see cref="NaN"/> rational number will yield the string <c>NaN</c> </remarks>
    /// <returns>A string representing the rational number (in base 10) in the format "numerator/denominator" or just "numerator" if the denominator is 1.</returns>
    public string ToStringCanonical()
      => IsNaN
          ? nameof(NaN)
          : Denominator.IsOne
              ? Numerator.ToString()
              : $"{Numerator}/{Denominator}";

    ///<summary>Returns the default string representation of the rational number</summary>
    public override string ToString() => ToStringCanonical();

    /// <summary>
    /// Converts the factorization of the rational number to a string representation.
    /// </summary>
    /// <returns>A string representing the factorization of the rational number.</returns>
    public string ToStringFactorization()
    {
        string str = Primes.Factorization(Numerator).ToString();
        if (!IsInteger)
        {
            Factorization denFact = Primes.Factorization(Denominator);
            str += denFact.FactorCount == 1 ? $" / {denFact}" : $" / ({denFact})";
        }
        return str;
    }

    public string ToStringFinite(int base_)
    {
        if (IsNaN) return nameof(NaN);
        if (IsZero) return "0";
                
        StringBuilder sb = new StringBuilder();
        if (IsNegative) sb.Append('-');

        var qFIO = -(this.Abs);

        int firstExponent = qFIO.IntegralPart.Length(base_) - 1;
        int exponent = firstExponent;
        foreach ((BigInteger Integer, Q fraction) in qFIO.ShiftedFractions(base_).Take(1000))
        {
            if (exponent < 0 && fraction.IsZero)
                break;
            if (exponent == -1) sb.Append('.');
            sb.Append(Integer);
            

            exponent--;
            

        }
        return sb.ToString();
    }
}
