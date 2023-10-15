using MultiPrecision;

namespace BarnesGApproximation {
    public static class BarnesGN64 {
        public static MultiPrecision<Pow2.N64> Value(MultiPrecision<Pow2.N64> x) {
            MultiPrecision<Plus1<Pow2.N64>> logg = BarnesG<Plus1<Pow2.N64>>.LogValue(x.Convert<Plus1<Pow2.N64>>(), n: 256);
            MultiPrecision<Plus1<Pow2.N64>> g = MultiPrecision<Plus1<Pow2.N64>>.Exp(logg);

            return g.Convert<Pow2.N64>();
        }

        public static MultiPrecision<Pow2.N64> LogValue(MultiPrecision<Pow2.N64> x) {
            MultiPrecision<Plus4<Pow2.N64>> logg = BarnesG<Plus4<Pow2.N64>>.LogValue(x.Convert<Plus4<Pow2.N64>>(), n: 320);

            MultiPrecision<Plus4<Pow2.N64>> logg_rounded = MultiPrecision<Plus4<Pow2.N64>>.Ldexp(
                MultiPrecision<Plus4<Pow2.N64>>.Truncate(
                    MultiPrecision<Plus4<Pow2.N64>>.Ldexp(logg, MultiPrecision<Pow2.N64>.Bits)
                ), -MultiPrecision<Pow2.N64>.Bits
            );

            return logg_rounded.Convert<Pow2.N64>();
        }
    }
}
