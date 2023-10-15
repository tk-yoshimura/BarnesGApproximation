using MultiPrecision;

namespace BarnesGApproximation {
    internal class Program {
        static void Main(string[] args) {
            MultiPrecision<Pow2.N32> t = BarnesG<Pow2.N32>.SterlingApprox(1024);

            Console.WriteLine(t);

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}