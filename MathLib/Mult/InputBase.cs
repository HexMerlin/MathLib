﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.Mult;
public abstract class InputBase
{

    public abstract int this[int index] { get; set; }

    public abstract int Length { get; }

    public abstract bool IsSet(int index);

    public abstract IEnumerable<int> Coeffs { get; }

    public abstract void Fill(BigInteger number);

    public override string ToString() => Enumerable.Range(0, Length * 2).Select(i => this[i] == -1 ? "?" : this[i].ToString()).Str();

}


