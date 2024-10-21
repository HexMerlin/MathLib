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

        A = (qp.Generator + q) / 2;
        B = (qp.Generator - q) / 2;
    }


}
