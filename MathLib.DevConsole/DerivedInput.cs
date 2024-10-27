
//namespace MathLib.DevConsole;

//public class DerivedInput : IInput
//{
//    private readonly Input Input;

//    private readonly bool negateB;
//    private readonly bool negateA;

//    public DerivedInput(Input input, bool negateB, bool negateA)
//    {
//        this.Input = input;
//        this.negateB = negateB;
//        this.negateA = negateA;
//    }

//    public int Base => Input.Base;

//    public int Length => Input.Length;

//    public IReadOnlyList<int> ExpectedProduct
//        => negateB == negateA
//        ? Input.ExpectedProduct
//        : Negate(Input.ExpectedProduct, Base).ToArray();

//    public IEnumerable<int> ADigits
//        => negateA ? Negate(Input.ADigits, Base) : Input.ADigits;

//    public IEnumerable<int> BDigits
//        => negateB ? Negate(Input.BDigits, Base) : Input.BDigits;

//    public int ADigit(int position) => ADigits.ElementAt(position);

//    public int BDigit(int position) => BDigits.ElementAt(position);

//    private static IEnumerable<int> Negate(IEnumerable<int> coefficients, int base_)
//    {
//        int maxCoeff = base_ - 1;
//        int carry = 1;
//        foreach (int coeff in coefficients)
//        {
//            int result = maxCoeff - coeff + carry;
//            carry = 0;
//            if (result > maxCoeff)
//            {
//                carry = 1;
//                result = 0;
//            }
//            yield return result;
//        }
//    }
//}
