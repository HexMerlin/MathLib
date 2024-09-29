using System.Text;

namespace MathLib;
public partial class Qb 
{
    /// <summary>
    /// Converts the current instance of <see cref="Qb"/> 
    /// to its canonical string representation in the given base.
    /// </summary>
    /// <param name="coefficientCount">The number of coefficients to include, starting from the leftmost. (default=16)</param>
    /// <returns>The canonical string representation of the current instance of <see cref="Qb"/>.</returns>
    /// <remarks>
    /// The sign of a number is not encoded by (kept by) the canonical representation, since some Q and -Q can have the same string representation.
    /// However, negative numbers, completes the generation, by enabling us to generate all ultimately periodic expansions, including those that are not covered by the positive rational numbers.
    /// </remarks>
    /// <example>
    /// <list type="table">
    ///   <listheader>
    ///     <term><see cref="Q"/></term>
    ///     <term>Expansion</term>
    ///     <term>Mode</term>
    ///   </listheader>
    ///   <item>
    ///     <term>0</term>
    ///     <description>.0000000000000000</description>
    ///     <description>FIO=FEO, in any base</description>
    ///   </item>
    ///   <item>
    ///     <term>1₂</term>
    ///     <description>.1111111111111111</description>
    ///     <description>FIO</description>
    ///   </item>
    ///   <item>
    ///     <term>-1₂</term>
    ///     <description>1.000000000000000 </description>
    ///      <description>FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>103/16₂</term>
    ///     <description>110.0110111111111</description>
    ///     <description>FIO</description>
    ///   </item>
    ///   <item>
    ///     <term>-103/16₂</term>
    ///     <description>110.0111000000000</description>
    ///     <description>FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>5/24₂</term>
    ///     <description>.0011010101010101</description>
    ///      <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>-5/24₂</term>
    ///     <description>.0011010101010101</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>3/45₅</term>
    ///     <description>.3333333333333333</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>-3/45₅</term>
    ///     <description>.3333333333333333</description> 
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///   <item>
    ///     <term>537/11₃</term>
    ///     <description>1210.211002110021</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    ///    <item>
    ///     <term>-537/11₃</term>
    ///     <description>1210.211002110021</description>
    ///     <description>FIO=FEO</description>
    ///   </item>
    /// </list>
    /// </example>
    public string ToStringCanonical(int coefficientCount = 16)
    {
        if (IsNaN) return nameof(NaN);
        StringBuilder sb = new StringBuilder();
        int exponent = FirstExponent;

        foreach (int coef in Coefficients().Take(coefficientCount))
        {
            if (exponent == -1) sb.Append('.');
            sb.Append(coef);
            exponent--;
        }
        return sb.ToString();
    }

    ///<summary>Returns the default string representation of the rational number</summary>
    public override string ToString() => $"{base.ToString()} = {ToStringCanonical()}";

}
