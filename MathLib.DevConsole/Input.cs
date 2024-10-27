using System.Numerics;
using MathLib;

namespace MathLib.DevConsole;


public class Input : IInput
{
    public readonly int[] Coeffs;
    private readonly bool[] certain;

    IEnumerable<int> IInput.Coeffs => Coeffs;

    public int this[int index]
    {
        get => Coeffs[index];
        set
        {
            //if (index >= 10 && value == 1)
            //{
            //    Console.WriteLine("Here! " + certain[index]);
            //}
            if (Coeffs[index] != value)
                Coeffs[index] = 
                    certain[index]
                    ? throw new InvalidOperationException("Cannot change certain value")
                    : Coeffs[index] = value;
        }
    }

    public Input(int maxLength)
    {
        Coeffs = new int[1000];
        certain = new bool[1000];
        Coeffs[0] = 1;
        certain[0] = true;
        for (int i = maxLength; i < certain.Length; i++) 
        { 
            Coeffs[i] = 0;
            certain[i] = true;
        }
    }

    public bool Certain(int index) => certain[index];

    public void SetCertain(int index) => this.certain[index] = true;

}


//public void CheatAddAll(Q qB, Q qA)
//{
//    aDigits.AddRange(ToBitArray(new Qp(qA, new Base(Base))));
//    bDigits.AddRange(ToBitArray(new Qp(qB, new Base(Base))));
//}




