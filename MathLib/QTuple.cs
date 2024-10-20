namespace MathLib;


public class QTuple
{
    public int Base { get; }

    public Q A { get; }

    public Q B { get; }

    public QTuple(Q q, int base_)
    {
        this.Base = base_;
        Qp qp = new Qp(q, base_);

        A = (q + qp.Generator) / 2;
        B = (q - qp.Generator) / 2;
    }


}
