﻿using MultiPrecision;

namespace BarnesGApproximation {
    internal class Program {
        static void Main(string[] args) {
            MultiPrecision<Pow2.N32> t = BarnesG<Pow2.N32>.LogValue(1000.25, n: 128);

            Console.WriteLine(t);

            MultiPrecision<Pow2.N32> v1 = BarnesGN32.Value(1);
            MultiPrecision<Pow2.N32> v2 = BarnesGN32.Value(2);

            Console.WriteLine(v1);
            Console.WriteLine(v2);

            MultiPrecision<Pow2.N32> u1 = BarnesGN32.LogValue(1);
            MultiPrecision<Pow2.N32> u2 = BarnesGN32.LogValue(2);

            Console.WriteLine(u1);
            Console.WriteLine(u2);

            MultiPrecision<Pow2.N32> w = BarnesGN32.LogValue(1000.25);

            Console.WriteLine(w);

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}