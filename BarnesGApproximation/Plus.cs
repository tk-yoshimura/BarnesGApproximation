﻿using MultiPrecision;

namespace BarnesGApproximation {
    internal struct Plus2<N> : IConstant where N : struct, IConstant {
        public readonly int Value => checked(default(N).Value + 2);
    }

    internal struct Plus4<N> : IConstant where N : struct, IConstant {
        public readonly int Value => checked(default(N).Value + 4);
    }
}
