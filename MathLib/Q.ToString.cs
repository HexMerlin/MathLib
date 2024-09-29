namespace MathLib;

public partial class Q
{
    /// <summary>
    /// Returns the rational number as a simple quotient representation in base 10.
    /// </summary>
    /// <example>
    /// <code>
    /// Console.WriteLine(new Q(-4,5).ToStringSimple()); 
    /// //outputs "-4/5"
    /// </code>
    /// </example>
    /// <remarks>An <see cref="NaN"/> rational number will yield the string <c>NaN</c> </remarks>
    /// <returns>A string representing the rational number (in base 10) in the format "numerator/denominator" or just "numerator" if the denominator is 1.</returns>
    public partial string ToStringSimple();

    ///<summary>Returns the default string representation of the rational number</summary>
    public override string ToString() => ToStringSimple();


}
