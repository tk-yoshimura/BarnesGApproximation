using MultiPrecision;

namespace BarnesGApproximation {
    public static class BarnesGN32 {
        public static MultiPrecision<Pow2.N32> Value(MultiPrecision<Pow2.N32> x) {
            MultiPrecision<Plus2<Pow2.N32>> g = BarnesG<Plus2<Pow2.N32>>.Value(x.Convert<Plus2<Pow2.N32>>(), n: 128);

            if (g.Exponent > MultiPrecision<Pow2.N32>.Bits) {
                return g.Convert<Pow2.N32>();
            }

            MultiPrecision<Plus2<Pow2.N32>> g_rounded = MultiPrecision<Plus2<Pow2.N32>>.Ldexp(
                MultiPrecision<Plus2<Pow2.N32>>.Truncate(
                    MultiPrecision<Plus2<Pow2.N32>>.Ldexp(g, MultiPrecision<Pow2.N32>.Bits)
                ), -MultiPrecision<Pow2.N32>.Bits
            );

            return g_rounded.Convert<Pow2.N32>();
        }

        public static MultiPrecision<Pow2.N32> LogValue(MultiPrecision<Pow2.N32> x) {
            MultiPrecision<Plus4<Pow2.N32>> logg = BarnesG<Plus4<Pow2.N32>>.LogValue(x.Convert<Plus4<Pow2.N32>>(), n: 160);

            MultiPrecision<Plus4<Pow2.N32>> logg_rounded = MultiPrecision<Plus4<Pow2.N32>>.Ldexp(
                MultiPrecision<Plus4<Pow2.N32>>.Truncate(
                    MultiPrecision<Plus4<Pow2.N32>>.Ldexp(logg, MultiPrecision<Pow2.N32>.Bits)
                ), -MultiPrecision<Pow2.N32>.Bits
            );

            return logg_rounded.Convert<Pow2.N32>();
        }
    }
}
