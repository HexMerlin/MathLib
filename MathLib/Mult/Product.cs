using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Text;


namespace MathLib.Mult;

public class Product
{    
    public BigInteger Integer { get; }

    public InputBase InputX { get; }
    public InputBase InputY { get; }
    
    public Product NegativeX { get; private set; }

    public Product NegativeY { get; private set; }

    public Product NegativeXY { get; private set; }

    public int Length => XLength + YLength - 1;
    public int XLength => InputX.Length;
    public int YLength => InputY.Length;

    public Product(BigInteger xInteger, BigInteger yInteger, bool reverse = false)
    {
        if (xInteger.Abs() < yInteger.Abs())
            (xInteger, yInteger) = (yInteger, xInteger);
        InputX = Input.Create(xInteger, reverse);
        InputY = Input.Create(yInteger, reverse);
        Integer = GetSetNumber();

        InputBase negInputX = InputX.Negative;
        InputBase negInputY = InputY.Negative;

        Product[] p = new Product[] {
                this,
                new Product(-Integer, negInputX, InputY),
                new Product(-Integer, InputX, negInputY),
                new Product(Integer, negInputX, negInputY)
        };

        p[0].SetNegativeX(p[1]);
        p[0].SetNegativeY(p[2]);
        p[0].SetNegativeXY(p[3]);
        p[1].SetNegativeY(p[3]);
        p[1].SetNegativeXY(p[2]);
        p[2].SetNegativeX(p[3]);
    }




    public Product(BigInteger integer, int xLength, int yLength) :
        this(integer, new Input(xLength), new Input(yLength))

    {
        InputBase negInputX = InputX.Negative;
        InputBase negInputY = InputY.Negative;

        Product[] p = new Product[] {
                this,
                new Product(-Integer, negInputX, InputY),
                new Product(-Integer, InputX, negInputY),
                new Product(Integer, negInputX, negInputY)
        };

        p[0].SetNegativeX(p[1]);
        p[0].SetNegativeY(p[2]);
        p[0].SetNegativeXY(p[3]);
        p[1].SetNegativeY(p[3]);
        p[1].SetNegativeXY(p[2]);
        p[2].SetNegativeX(p[3]);

    }

    private void SetNegativeX(Product negativeX)
    {
        NegativeX = negativeX;
        negativeX.NegativeX = this;
    }

    private void SetNegativeY(Product negativeY)
    {
        NegativeY = negativeY;
        negativeY.NegativeY = this;
    }

    private void SetNegativeXY(Product negativeXY)
    {
        NegativeXY = negativeXY;
        negativeXY.NegativeXY = this;
    }

    private Product(BigInteger integer, InputBase inputX, InputBase inputY)
    {
        Integer = integer;
        if (Integer < 0)
            Integer = NegativeXNumber(-Integer);

        InputX = inputX;
        InputY = inputY;
    }

    public static BigInteger NegativeXNumber(BigInteger positiveInteger)
    {
        Qb qp0 = new Qp(positiveInteger, 1, 2).Generator;
        Qb qp1 = new Qp(qp0, 2).Generator;
        Debug.Assert(qp1.IsInteger);
        return qp1.Numerator;
    }
    public int[] Try(int secondOneXIndex = 0)
    {
        BigInteger pos = this.Integer;
        BigInteger negX = this.NegativeX.Integer;
        //BigInteger negY = this.NegativeY.Integer;
        //BigInteger negXY = this.NegativeXY.Integer;

        (int, int)[] variants = new[] { (0, 0), (0, 1), (1, 0), (1, 1) };

        bool[] variantMatched = new bool[variants.Length];

        BigInteger posDelta;
        BigInteger negXDelta;
        //BigInteger negYDelta;
        //BigInteger negXYDelta;

        for (int i = 0; i < InputY.Length - 1; i++)
        {
            Array.Fill(variantMatched, false);

            for (int variant = 0; variant < variants.Length; variant++)
            {
                (int x, int y) = variants[variant];
                if (InputX[i] != -1 && InputX[i] != x)
                    continue;
                if (InputY[i] != -1 && InputY[i] != y)
                    continue;


                //if (i == secondOneXIndex)
                //{
                //    if (x != 1)
                //        continue;

                //}

                var restoreX = InputX[i];
                var restoreY = InputY[i];

                InputX[i] = x;
                InputY[i] = y;
                posDelta = GetSetCoeff(i);
                negXDelta = NegativeX.GetSetCoeff(i);
                //negYDelta = NegativeY.GetSetCoeff(i);
                //negXYDelta = NegativeXY.GetSetCoeff(i);

                if ((pos - posDelta).IsEven &&
                    (negX - negXDelta).IsEven)
                    //(negY - negYDelta).IsEven &&
                    //(negXY - negXYDelta).IsEven)
                {
                    variantMatched[variant] = true;
                }
                InputX[i] = restoreX;
                InputY[i] = restoreY;

            }

            int variantIndex = Array.IndexOf(variantMatched, true);
            if (variantIndex == -1)
                throw new InvalidOperationException($"Should not be reached. No variant matched at index {i}.");
            if (variantMatched.Count(x => x) > 1)
            {
                Console.WriteLine($"ERROR: Should not be reached. More than one variant matched at index {i}.");
            }

            var (xM, yM) = variants[variantIndex];
            InputX[i] = xM;
            InputY[i] = yM;
            posDelta = GetSetCoeff(i);
            negXDelta = NegativeX.GetSetCoeff(i);
            //negYDelta = NegativeY.MinMax(i).min;
            //negXYDelta = NegativeXY.MinMax(i).min;

            pos = (pos - posDelta) / 2;
            negX = (negX - negXDelta) / 2;
            //negY = (negY - negYDelta) / 2;
            //negXY = (negXY - negXYDelta) / 2;
        }
        return MinMax().Select(x => x.min).ToArray();
    }

    //public int[] Try(int secondOneXIndex = 0)
    //{
    //    BigInteger pos = this.Integer;
    //    BigInteger negX = this.NegativeX.Integer; 
    //    BigInteger negY = this.NegativeY.Integer;
    //    BigInteger negXY = this.NegativeXY.Integer;

    //    (int, int)[] variants = [(0, 0), (0, 1), (1, 0), (1, 1)];

    //    bool[] variantMatched = new bool[variants.Length];

    //    BigInteger posDelta;
    //    BigInteger negXDelta;
    //    BigInteger negYDelta;
    //    BigInteger negXYDelta;

    //    for (int i = 0; i < InputY.Length - 1; i++)
    //    {
    //        Array.Fill(variantMatched, false);

    //        for (int variant = 0; variant < variants.Length; variant++)
    //        {
    //            (int x, int y) = variants[variant];
    //            if (InputX[i] != -1 && InputX[i] != x)
    //                continue;
    //            if (InputY[i] != -1 && InputY[i] != y)
    //                continue;


    //            //if (i == secondOneXIndex)
    //            //{
    //            //    if (x != 1)
    //            //        continue;

    //            //}

    //            var restoreX = InputX[i];
    //            var restoreY = InputY[i];

    //            InputX[i] = x;
    //            InputY[i] = y;
    //            posDelta = GetSetCoeff(i);
    //            negXDelta = NegativeX.GetSetCoeff(i);
    //            negYDelta = NegativeY.GetSetCoeff(i);
    //            negXYDelta = NegativeXY.GetSetCoeff(i);

    //            if ((pos - posDelta).IsEven &&
    //                (negX - negXDelta).IsEven &&
    //                (negY - negYDelta).IsEven &&
    //                (negXY - negXYDelta).IsEven)
    //            {
    //                variantMatched[variant] = true;
    //            }
    //            InputX[i] = restoreX;
    //            InputY[i] = restoreY;

    //        }

    //        int variantIndex = Array.IndexOf(variantMatched, true);
    //        if (variantIndex == -1)
    //            throw new InvalidOperationException($"Should not be reached. No variant matched at index {i}.");
    //        if (variantMatched.Count(x => x) > 1)
    //        {
    //            Console.WriteLine($"ERROR: Should not be reached. More than one variant matched at index {i}.");
    //        }

    //        var (xM, yM) = variants[variantIndex];
    //        InputX[i] = xM;
    //        InputY[i] = yM;
    //        posDelta = MinMax(i).min;
    //        negXDelta = NegativeX.MinMax(i).min;
    //        negYDelta = NegativeY.MinMax(i).min;
    //        negXYDelta = NegativeXY.MinMax(i).min;

    //        pos = (pos - posDelta) / 2;
    //        negX = (negX - negXDelta) / 2;
    //        negY = (negY - negYDelta) / 2;
    //        negXY = (negXY - negXYDelta) / 2;
    //    }
    //    return MinMax().Select(x => x.min).ToArray();
    //}


    public int[] GetCoeffs()
    {
        BigInteger rem = Integer;

        int[] coeffs = new int[Length];
        //distribute so all get min values 
        for (int i = 0; i < Length; i++)
        {
            (int min, int max) = MinMax(i);
            coeffs[i] = min;
            rem -= min * Weight(i);
        }
        //distribute as much as possible up to max
        for (int i = Length - 1; i >= 0; i--)
        {
            int add = (int)BigInteger.Min(MinMax(i).max - coeffs[i], rem / Weight(i));
            coeffs[i] += add;
            rem -= add * Weight(i);
        }
        //if (!rem.IsZero)
        //    throw new InvalidOperationException("GetCoeffs failed to distribute all values");
        return rem.IsZero
            ? coeffs
            : Array.Empty<int>();
    }


    // public abstract IEnumerable<(int xIndex, int yIndex)> InputCells(int index);

    public void FillX(BigInteger number) => InputX.Fill(number);

    public void FillY(BigInteger number) => InputY.Fill(number);


    public IEnumerable<(int xIndex, int yIndex)> InputCells(int index)
    {
        for (int i = 0; i <= index; i++)
            yield return (index - i, i);
    }

 
    public BigInteger MinSum()
    {
        BigInteger result = BigInteger.Zero;
        for (int i = 0; i < Length; i++)
        {
            result *= 2;
            int min = MinMax(i).min;
            result += min;
        }
        return result;
    }

    public BigInteger GetSetNumber()
    {
        BigInteger sum = 0;
        for (int i = 0; i < Length; i++)
        {
            
            int coeffSum = GetSetCoeff(i);
            sum += coeffSum * Weight(i);
        }
        return sum;
    }

    public int GetSetCoeff(int index)
    {
        (int min, int max) = MinMax(index);
        Debug.Assert(min == max);
        return min;
    }

    public (int min, int max) MinMax(int index)
    {
        int notSetCount = 0;
        int oneCount = 0;

        foreach (var (xIndex, yIndex) in InputCells(index))
        {
            int x = InputX[xIndex];
            int y = InputY[yIndex];
            if (x == 0 || y == 0)
                continue; //zero value (not counted)
            else if (x == 1 && y == 1)
                oneCount++;
            else
                notSetCount++;
        }
        return (oneCount, oneCount + notSetCount);
    }

    public int CoeffsSum() => GetCoeffs().Sum();

    public IEnumerable<int> PosNegSum()
    {
        throw new NotImplementedException();
        //var pos = GetCoeffs();
        //var neg = Negative.GetCoeffs();
        //for (int i = 0; i < Length; i++)
        //    yield return pos[i] + neg[i];
    }


    public IEnumerable<int> SetCoeffs() => Enumerable.Range(0, Length).Select(GetSetCoeff);

    public IEnumerable<(int min, int max)> MinMax() => Enumerable.Range(0, Length).Select(MinMax);

    public string ToStringMinValues() => $"{Enumerable.Range(0, Length).Select(i => MinMax(i).min).Str(", ")}";

    public string ToStringMaxValues() => $"{Enumerable.Range(0, Length).Select(i => MinMax(i).max).Str(", ")}";

    public static BigInteger Weight(int index) => BigInteger.One << index;

    public int[] AdjustedPosNegSum(int targetTrail = 7)
    {
        int[] coeffs = PosNegSum().ToArray();

        while (true)
        {
            int trail = coeffs[^1] + 1;
            
            coeffs[^1] += 2;
            for (int i = coeffs.Length - 1; i >= YLength; i--)
            {
                int move = coeffs[i] - trail;
                if (move > 0)
                {
                    coeffs[i] -= move;
                    coeffs[i - 1] += move * 2;
                }
            }
            Console.WriteLine("DEBUG: " + coeffs.Str("")) ;
            if (trail >= targetTrail)
                break;
        }


        return coeffs;

    }

    public void DebugPrint()
    {
        StringBuilder sb = new StringBuilder();
        string ZeroString(int len) => new string('0', len);

        // string setString = Enumerable.Range(0, XLength).TakeWhile(i => InputX[i] != -1).Select(i => InputX[i].ToString()).Str("");

        string XString(int len) 
            => Enumerable.Range(0, len).Select(i => InputX[i] == -1 ? "?" : InputX[i].ToString()).Str();

        string lineEntry(int y) => new string(' ', y) + (InputY[y] == 1 ? XString(Length - y) : ZeroString(Length - y));

        for (int y = 0; y < YLength; y++)
        {
            if (InputY[y] == -1) break;
            sb.AppendLine(lineEntry(y));
        }
        sb.Append('-', Length);
        sb.AppendLine();
        sb.Append(this.MinMax().Select(t => t.min).Str(""));
        sb.Append($"\tSet number:{GetSetNumber()}");
        Console.WriteLine(sb.ToString());
    }


    //public int[] Try(int secondOneXIndex = 0)
    //{
    //    throw new NotImplementedException();
    //BigInteger pos = (Integer - 1) / 2;
    //BigInteger neg = (Negative.Integer - 1) / 2;
    //Console.WriteLine(Integer + "   ----   " + Negative.Integer);
    //for (int i = 1; i < InputY.Length - 1; i++)
    //{
    //    for (int variant = 0; variant < 4; variant++)
    //    {
    //        int x = variant <= 1 ? 0 : 1;

    //        int y = variant % 2 == 0 ? 1 : 0;
    //        if (i == secondOneXIndex)
    //        {
    //            if (x != 1)
    //                continue;

    //        }

    //        InputX[i] = x;
    //        InputY[i] = y;
    //        var (posDelta, _posDeltaMax) = MinMax(i);
    //        var (negDelta, _negDeltaMax) = Negative.MinMax(i);

    //        Debug.Assert(posDelta == _posDeltaMax);
    //        Debug.Assert(negDelta == _negDeltaMax);

    //        if ((pos - posDelta).IsEven && (neg - negDelta).IsEven)
    //        {
    //            pos -= posDelta;
    //            pos /= 2;
    //            neg -= negDelta;
    //            neg /= 2;
    //            break;
    //        }
    //        InputX[i] = -1;
    //        InputY[i] = -1;
    //        if (variant == 3)
    //            throw new InvalidOperationException("Should not be reached. Wrong path turned.");
    //    }
    //}
    //Console.WriteLine("X:     " + this.InputX);
    //Console.WriteLine("Y:     " + this.InputY);
    //Console.WriteLine("NEG X: " + this.Negative.InputX);
    //Console.WriteLine("NEG Y: " + this.InputY);
    //Console.WriteLine();
    //return MinMax().Select(x => x.min).ToArray();
    // }

    public int[] PosNegSum(int trail)
    {
        throw new NotImplementedException();
        //int[] coeffs = new int[Length];
        //Array.Fill(coeffs, trail, YLength, Length - YLength);

        //coeffs[YLength - 2] = (trail - 1) * 2;
        //coeffs[YLength - 1] = trail + 1;

        //Product pos = (Product)this;
        //NegativeProduct neg = pos.Negative;
        //int[] posMin = pos.MinMax().Select(t => t.min).ToArray();
        //int[] negMin = neg.MinMax().Select(t => t.min).ToArray();
        //for (int i = 0; i <= YLength - 1; i++)
        //{
        //    int min = posMin[i] + negMin[i];
        //    if (coeffs[i] < min)
        //    {
        //        int add = min - coeffs[i];
        //        if (add % 2 == 1)
        //            add++;
        //        coeffs[i] += add;
        //        coeffs[i + 1] -= add / 2;
        //    }
        //}

        //return coeffs;
    }

   

    public override string ToString() 
    {
        int[] coeffs = GetCoeffs();
        return coeffs.Length == 0 ? "Invalid" : $"{coeffs.Str(", ")} \tSum: {coeffs.Sum()}";
    }
     
}
