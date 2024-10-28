
namespace MathLib.DevConsole;

public interface IInput
{
    int this[int index] { get; set; }

    public bool Locked(int index);

    public void SetLocked(int index, bool locked);

    public int Length { get; }

    public IEnumerable<int> Coeffs { get; }
}
