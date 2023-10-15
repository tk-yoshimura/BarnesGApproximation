using MultiPrecision;

namespace BarnesGApproximation {
    internal class Program {
        static void Main(string[] args) {
            MultiPrecision<Pow2.N32> t = BarnesG<Pow2.N32>.LogValue(1000.25, n: 128);

            Console.WriteLine(t);

            MultiPrecision<Pow2.N32> v1 = BarnesG<Pow2.N32>.Value(1, n: 128);
            MultiPrecision<Pow2.N32> v2 = BarnesG<Pow2.N32>.Value(2, n: 128);

            Console.WriteLine(v1);
            Console.WriteLine(v2);

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}