
namespace MathLib.DevConsole;

public class NegativeInput : IInput
{
    public readonly Input Positive;

    public NegativeInput(Input positive)
    {
        Positive = positive;
    }

    public int this[int index]
    {
        get => index == 0 ? 1 : 1 - Positive.Coeffs[index];
        set => Positive.Coeffs[index] = 1 - value;
    }

    public IEnumerable<int> Coeffs
    {
        get
        {
            for (int i = 0; ; i++)
                yield return this[i];
        }
    }

    public bool Certain(int index) => Positive.Certain(index);

    public void SetCertain(int index) => Positive.SetCertain(index);

}


//public void CheatAddAll(Q qB, Q qA)
//{
//    aDigits.AddRange(ToBitArray(new Qp(qA, new Base(Base))));
//    bDigits.AddRange(ToBitArray(new Qp(qB, new Base(Base))));
//}




