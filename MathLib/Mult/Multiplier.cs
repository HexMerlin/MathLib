
//using System.Linq;
//using System.Collections.Generic;
//using System.Numerics;
//using System.Text;

//namespace MathLib.Mult;

//public class Multiplier
//{
//    private readonly InputBase InputA;
//    private readonly InputBase InputB;

//    public readonly int[] ProdDigits;
//    private readonly int[] Carries;

//    public int[] ExpectedProduct { get; }


//    public Multiplier(IInput inputA, IInput inputB, int[] expectedProduct)
//    {
//        this.InputA = inputA;
//        this.InputB = inputB;

//        this.ExpectedProduct = expectedProduct;
//        this.ProdDigits = new int[ExpectedProduct.Length];
//        this.Carries = new int[ExpectedProduct.Length];
//        //ToBitArray(new Qp(expectedProduct, new Base(base_)), length);

//    }

//    public bool ComputeProdDigit(int index)
//    {
//        const int base_ = 2;
//        int sum = ComputeSum(index);
//        int prodDigit = sum % base_;
//        if (this.ExpectedProduct[index] != prodDigit)
//            return false;

//        ProdDigits[index] = prodDigit;
//        Carries[index] = sum / base_;

//        return true;
//    }

//    private int ComputeSum(int index)
//    {
//        int sum = index > 0
//            ? Carries[index - 1]
//            : 0;
//        for (int i = 0; i <= index; i++)
//            sum += InputA[i] * InputB[index - i];
//        return sum;
//    }

//    public static int[] ToBitArray(Qp qp, int length) => qp.Generator.Coefficients().Take(length).ToArray();


//    public override string ToString()
//    {
//        StringBuilder sb = new();
//        int len = 30;
//        string aString = InputA.Coeffs.Take(len).Str();


//        for (int i = 0; i < len; i++)
//        {

//            if (InputB[i] == 1)
//                sb.AppendLine(new string(' ', i) + aString);
//            //else
//            //    sb.AppendLine(zeroString);
//        }
//        sb.AppendLine(new string('_', len));
//        sb.AppendLine(ProdDigits.Str() + "  <== Product");
//        return sb.ToString();
//    }
//}
