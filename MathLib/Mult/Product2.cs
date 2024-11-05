//using MathLib.Compatibility;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Numerics;

//namespace MathLib.Mult;

//public class Product : ProductBase
//{
//    #region Data
//    public NegativeProduct Negative { get; }

//    public override BigInteger Integer { get; }

//    public override InputBase InputX { get; }
//    public override InputBase InputY { get; }


//    #endregion Data

//    public Product(BigInteger integer, int xLength, int yLength) :
//        this(integer, new Input(xLength), new Input(yLength))

//    {
//        InputBase negInputX = InputX.Negative;
//        InputBase negInputY = InputY.Negative;

//        this.NegativeX = new Product(-Integer, negInputX, InputY);
//        this.NegativeY = new Product(-Integer, InputX, negInputY);
//        this.NegativeXY = new Product(Integer, negInputX, negInputY);

        
//        //Product negativeXY = new Product(Integer, negInputX, negInputY);
//    }

//    private Product(BigInteger integer, InputBase inputX, InputBase inputY)
//    {
//        Integer = integer;
//        InputX = inputX;
//        InputY = inputY;
//    }

//    private Product(BigInteger integer, InputBase inputX, InputBase inputY, ProductBase? negativeX = null, ProductBase? negativeY = null, ProductBase? negativeXY = null)
//    {
//        if (integer.IsEven)
//            throw new ArgumentException("Integer must be odd", nameof(integer));
//        this.Integer = integer;
//        this.InputX = inputX;
//        this.InputY = inputY;
//        this.Negative = new NegativeProduct(this);
       
//        this.NegativeX = negativeX ?? new Product(-Integer, inputX.Negative, InputY, this, negativeY, null);
//        this.NegativeY = negativeY ?? new Product(-Integer, inputX, InputY.Negative, negativeY, this, null);
//        this.NegativeXY = negativeXY ?? new Product(Integer, inputX.Negative, inputY.Negative, null);
//    }

//    private Product(ProductBase negativeX, ProductBase negativeY)
//    {
//        this.Integer = -negativeX.Integer;
//        this.InputX = negativeY.InputX;
//        this.InputY = negativeX.InputY;
//        this.NegativeX = negativeX;
//        this.NegativeY = negativeY;
//    }






//    public void FillX(BigInteger number) => InputX.Fill(number);

//    public void FillY(BigInteger number) => InputY.Fill(number);



//    private static bool ParityEqual(BigInteger i1, int  i2)
//    {
//        return i1.IsEven == ((i2 & 1) == 0);
//    }

//    public int[] Try(int secondOneXIndex = 0)
//    {
//        BigInteger pos = Integer;
//        BigInteger neg = Negative.Integer;

//        Console.WriteLine(Integer + "   ----   " + Negative.Integer);
//        for (int i = 0; i < InputY.Length - 1; i++)
//        {
//            for (int variant = 0; variant < 4; variant++)
//            {
//                int x = variant <= 1 ? 0 : 1;

//                int y = variant % 2 == 0 ? 1 : 0;
//                if (i == secondOneXIndex)
//                {
//                    if (x != 1)
//                        continue;

//                }

//                InputX[i] = x;
//                InputY[i] = y;
//                var (posDelta, _posDeltaMax) = MinMax(i);
//                var (negDelta, _negDeltaMax) = Negative.MinMax(i);

//                Debug.Assert(posDelta == _posDeltaMax);
//                Debug.Assert(negDelta == _negDeltaMax);

//                if ((pos - posDelta).IsEven && (neg - negDelta).IsEven)
//                {
//                    pos -= posDelta;
//                    pos /= 2;
//                    neg -= negDelta;
//                    neg /= 2;
//                    break;
//                }
//                InputX[i] = -1;
//                InputY[i] = -1;
//                if (variant == 3)
//                    throw new InvalidOperationException("Should not be reached. Wrong path turned.");
//            }
//        }
//        Console.WriteLine("X:     " + this.InputX);
//        Console.WriteLine("Y:     " + this.InputY);
//        Console.WriteLine("NEG X: " + this.Negative.InputX);
//        Console.WriteLine("NEG Y: " + this.InputY);
//        Console.WriteLine();
//        return MinMax().Select(x => x.min).ToArray();
//    }

//    //public int[] Try(int secondOneXIndex = 0)
//    //{
//    //    BigInteger pos = (Integer - 1) / 2;
//    //    BigInteger neg = (Negative.Integer - 1) / 2;
//    //    Console.WriteLine(Integer + "   ----   " + Negative.Integer);
//    //    for (int i = 1; i < InputY.Length - 1; i++)
//    //    {
//    //        for (int variant = 0; variant < 4; variant++)
//    //        {
//    //            int x = variant <= 1 ? 0 : 1;

//    //            int y = variant % 2 == 0 ? 1 : 0;
//    //            if (i == secondOneXIndex)
//    //            {
//    //                if (x != 1)
//    //                    continue;

//    //            }

//    //            InputX[i] = x;
//    //            InputY[i] = y;
//    //            var (posDelta, _posDeltaMax) = MinMax(i);
//    //            var (negDelta, _negDeltaMax) = Negative.MinMax(i);

//    //            Debug.Assert(posDelta == _posDeltaMax);
//    //            Debug.Assert(negDelta == _negDeltaMax);

//    //            if ((pos - posDelta).IsEven && (neg - negDelta).IsEven)
//    //            {
//    //                pos -= posDelta;
//    //                pos /= 2;
//    //                neg -= negDelta;
//    //                neg /= 2;
//    //                break;
//    //            }
//    //            InputX[i] = -1;
//    //            InputY[i] = -1;
//    //            if (variant == 3)
//    //                throw new InvalidOperationException("Should not be reached. Wrong path turned.");
//    //        }
//    //    }
//    //    Console.WriteLine("X:     " + this.InputX);
//    //    Console.WriteLine("Y:     " + this.InputY);
//    //    Console.WriteLine("NEG X: " + this.Negative.InputX);
//    //    Console.WriteLine("NEG Y: " + this.InputY);
//    //    Console.WriteLine();
//    //    return MinMax().Select(x => x.min).ToArray();
//    //}

//    public IEnumerable<(int posDelta, int negDelta)> Variants(int index)
//    {
//        for (int i = 0; i < 4; i++)
//        {
//            int x = i <= 1 ? 0 : 1;
//            int y = i % 2 == 0 ? 1 : 0;
//            InputX[index] = x;
//            InputY[index] = y;
//            Debug.Assert(MinMax(index).min == MinMax(index).max);
//            Debug.Assert(Negative.MinMax(index).min == Negative.MinMax(index).max);
//            yield return (MinMax(index).min, Negative.MinMax(index).min);
//        }
//    }
//    //public IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
//    //{
//    //    for (int i = 0; i <= index; i++)
//    //        yield return (index - i, i);
//    //}

//    //public override IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
//    //{
//    //    int yFirst = Math.Max(0, index - InputX.Length + 1);
//    //    int yLast = Math.Min(index, InputY.Length - 1);

//    //    for (int yIndex = yFirst; yIndex <= yLast; yIndex++)
//    //        yield return (index - yIndex, yIndex);
//    //}

//    public override int[] GetCoeffs()
//    {
//        BigInteger rem = Integer;
        
//        int[] coeffs = new int[Length];
//        //distribute so all get min values 
//        for (int i = 0; i < Length; i++)
//        {
//            (int min, int max) = MinMax(i);
//            coeffs[i] = min;
//            rem -= min * Weight(i); 
//        }
//        //distribute as much as possible up to max
//        for (int i = Length - 1; i >= 0; i--)
//        {
//            int add = (int)BigInteger.Min(MinMax(i).max - coeffs[i], rem / Weight(i));
//            coeffs[i] += add;
//            rem -= add * Weight(i);
//        }
//        //if (!rem.IsZero)
//        //    throw new InvalidOperationException("GetCoeffs failed to distribute all values");
//        return rem.IsZero 
//            ? coeffs 
//            : Array.Empty<int>();
//    }

    

//    public void AssertPosNegSumValid()
//    {
//        var pos = GetCoeffs();
//        var neg = Negative.GetCoeffs();
//        int sameVal = pos[YLength] + neg[YLength];
//        for (int i = YLength; i < Length; i++)
//            if (pos[i] + neg[i] != sameVal)
//                throw new InvalidOperationException("PosNegSum is not valid");

//    }

//    public override IEnumerable<int> PosNegSum()
//    {
//        var pos = GetCoeffs();
//        var neg = Negative.GetCoeffs();
//        for (int i = 0; i < Length; i++)
//            yield return pos[i] + neg[i];
//    }

   
//}
