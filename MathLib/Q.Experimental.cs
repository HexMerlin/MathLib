using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathLib;
public partial class Q
{

    public static IEnumerable<int> PadicProduct(Q a, Q b)
    {
        throw new NotImplementedException();
        //int base_ = 2;
        //int[] aCoeffs = a.Coefficients(base_).Take(1000).ToArray();
        //int[] bCoeffs = b.Coefficients(base_).Take(1000).ToArray();


        //int carry = 0;  
        //while (true)
        //{
        //    if (!aCoeffs.MoveNext() || !bCoeffs.MoveNext())
        //        break;
        //    int aCoeff = aCoeffs.Current;
        //    int bCoeff = bCoeffs.Current;


        //    int product = aCoeff * bCoeff + carry;
        //    yield return product % base_;

        //    if (product >= base_)
        //    {
        //        carry = product / base_;
        //    }

        //}

    }

}