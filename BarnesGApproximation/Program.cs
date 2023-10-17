using MultiPrecision;

namespace BarnesGApproximation {
    internal class Program {
        static void Main() {
            using StreamWriter sw = new("../../../../results/barnes_g_n32.csv");
            sw.WriteLine($"x,barnes_g(x),log(barnes_g(x))");

            for (double x = -4; x < 0; x += 1 / 8192d) {
                MultiPrecision<Pow2.N32> y = BarnesGN32.Value(x);

                sw.WriteLine($"{x},{y}");

                Console.WriteLine($"{x}\n{y:e40}");
            }

            for (double x = 0; x < 4; x += 1 / 8192d) { 
                MultiPrecision<Pow2.N32> y = BarnesGN32.Value(x);
                MultiPrecision<Pow2.N32> lny = BarnesGN32.LogValue(x);

                sw.WriteLine($"{x},{y},{lny}");

                Console.WriteLine($"{x}\n{y:e40}\n{lny:e40}");
            }

            for (double x = 4; x <= 8; x += 1 / 4096d) { 
                MultiPrecision<Pow2.N32> y = BarnesGN32.Value(x);
                MultiPrecision<Pow2.N32> lny = BarnesGN32.LogValue(x);

                sw.WriteLine($"{x},{y},{lny}");

                Console.WriteLine($"{x}\n{y:e40}\n{lny:e40}");
            }

            sw.Close();

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}