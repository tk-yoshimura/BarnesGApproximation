using MultiPrecision;

namespace BarnesGApproximation {
    internal class Program {
        static void Main() {
            MultiPrecision<Pow2.N32> r0 = BarnesGN32.Value(1024);
            MultiPrecision<Pow2.N32> r1 = BarnesGN32.LogValue(1024);

            Console.WriteLine(r0);
            Console.WriteLine(r1);

            MultiPrecision<Pow2.N32> v0 = BarnesGN32.Value(0);
            MultiPrecision<Pow2.N32> v1 = BarnesGN32.Value(1);
            MultiPrecision<Pow2.N32> v2 = BarnesGN32.Value(2);

            Console.WriteLine(v0);
            Console.WriteLine(v1);
            Console.WriteLine(v2);

            MultiPrecision<Pow2.N32> u1 = BarnesGN32.LogValue(1);
            MultiPrecision<Pow2.N32> u2 = BarnesGN32.LogValue(2);

            Console.WriteLine(u1);
            Console.WriteLine(u2);

            MultiPrecision<Pow2.N32> u3 = BarnesGN32.LogValue(1 + 1d / 65536);
            MultiPrecision<Pow2.N32> u4 = BarnesGN32.LogValue(2 + 1d / 65536);

            Console.WriteLine(u3);
            Console.WriteLine(u4);

            MultiPrecision<Pow2.N64> u5 = BarnesGN64.LogValue(1 + 1d / 65536);
            MultiPrecision<Pow2.N64> u6 = BarnesGN64.LogValue(2 + 1d / 65536);

            Console.WriteLine(u5);
            Console.WriteLine(u6);

            MultiPrecision<Pow2.N32> w0 = BarnesGN32.Value(-0.125);
            MultiPrecision<Pow2.N32> w1 = BarnesGN32.Value(-0.25);
            MultiPrecision<Pow2.N32> w2 = BarnesGN32.Value(-2.25);

            Console.WriteLine(w0);
            Console.WriteLine(w1);
            Console.WriteLine(w2);

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}