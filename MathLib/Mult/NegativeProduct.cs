﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathLib.Mult;

public class NegativeProduct : ProductBase
{
    #region Data
    
    public Product Positive { get; }   
    public override IInput InputX { get; }

    #endregion Data

    public override IInput InputY => Positive.InputY;

    public override BigInteger Integer => -Positive.Integer;
   
    public NegativeProduct(Product positive)
    {
        this.Positive = positive;
        this.InputX = ((Input) positive.InputX).Negative();
        
    }

    private static bool IsOdd(int index) => (index & 1) != 0;

    public override int[] GetCoeffs()
    {
        int[] givenCoeffs = Input.ToBitArray(Integer); //this can be 1 longer than Length

        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, int max) = MinMax(i);
            if (givenCoeffs[i] < min)
            {
                int add = min - givenCoeffs[i];
                if (IsOdd(add))
                    add++;
                givenCoeffs[i] += add;
                givenCoeffs[i + 1] -= add / 2;
            }

        }
        int[] coeffs = new int[Length];
        Array.Copy(givenCoeffs, coeffs, Length);

        return IsCoeffsValid(coeffs) ? coeffs : Array.Empty<int>();
    }

    private bool IsCoeffsValid(int[] coeffs)
    {
        int[] reference = Input.ToBitArray(Integer);
      
        for (int i = 0; i < Length; i++)
        {
            int move = (coeffs[i] / 2);
            coeffs[i] -= move * 2;
            if (i < Length - 1) coeffs[i + 1] += move;
        }
        for (int i = 0; i < Length; i++)
            if (coeffs[i] != reference[i]) return false;
        
        return true;
    }

 
}
