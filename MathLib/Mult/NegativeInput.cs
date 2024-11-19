//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//namespace MathLib.Mult;

//public class NegativeInput : InputBase
//{
//    private readonly Input negative;

//    public override InputBase Negative => negative;

//    public NegativeInput(Input negative) => this.negative = negative;

//    public override int this[int index]
//    {
//        get => Negative[index] == -1
//                ? -1
//                : index == 0
//                    ? Negative[index]
//                    : 1 - Negative[index];
//        set => Negative[index] = value != -1 ? 1 - value : -1;
//    }

//    public override bool IsSet(int index) => Negative.IsSet(index);
    
//    public override void Fill(BigInteger number)
//    {
//        if (number >= 0)
//            throw new InvalidOperationException("Cannot fill input with positive number");
//        Negative.Fill(-number);
//    }

//    public override IEnumerable<int> Coeffs => Enumerable.Range(0, Length).Select(i => this[i]);

//    public override int Length => Negative.Length;

  
//}



