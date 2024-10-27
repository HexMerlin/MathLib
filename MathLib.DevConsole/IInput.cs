
namespace MathLib.DevConsole;

public interface IInput
{
    int this[int index] { get; set; }

    bool Certain(int index);

    void SetCertain(int index);

    public IEnumerable<int> Coeffs { get; }
}
