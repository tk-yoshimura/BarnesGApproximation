using MultiPrecision;

namespace BarnesGApproximation {
    public static class BarnesG<N> where N : struct, IConstant {
        private static readonly List<MultiPrecision<N>> sterling_term_coefs = new() {
            MultiPrecision<N>.NaN
        };

        private static MultiPrecision<N> Rcp12 { get; } =
            MultiPrecision<N>.Div(1, 12);

        private static MultiPrecision<N> LogBias { get; } =
            MultiPrecision<N>.Div(1, 12) - MultiPrecision<N>.Log(GlaisherA);

        private static MultiPrecision<N> LogPI2Half { get; } =
            MultiPrecision<N>.Log(2 * MultiPrecision<N>.PI) / 2;

        public static MultiPrecision<N> Value(MultiPrecision<N> x, long n) {
            if (x <= 0 && MultiPrecision<N>.IsInteger(x)) {
                return 0;
            }
            if (x >= n) {
                return MultiPrecision<N>.Exp(SterlingApprox(x));
            }

            long m = (long)MultiPrecision<N>.Floor(x);
            MultiPrecision<N> f = x - m;
            MultiPrecision<N> y = MultiPrecision<N>.Exp(SterlingApprox(n + f));

            if (MultiPrecision<N>.IsNaN(y)) {
                return MultiPrecision<N>.NaN;
            }

            MultiPrecision<N> g = MultiPrecision<N>.Gamma(n - 1 + f);

            for (long k = n - 1; k >= m; k--) {
                y /= g;
                g /= k - 1 + f;
            }

            return y;
        }

        public static MultiPrecision<N> LogValue(MultiPrecision<N> x, long n) {
            if (x < 0) {
                return MultiPrecision<N>.NaN;
            }
            if (x >= n) {
                return SterlingApprox(x);
            }

            long m = (long)MultiPrecision<N>.Floor(x);
            MultiPrecision<N> f = x - m;
            MultiPrecision<N> y = SterlingApprox(n + f);

            if (MultiPrecision<N>.IsNaN(y)) {
                return MultiPrecision<N>.NaN;
            }

            MultiPrecision<N> d = 1;
            MultiPrecision<N> g = MultiPrecision<N>.Gamma(n - 1 + f);

            for (long k = n - 1; k >= m; k--) {
                d *= g;
                g /= k - 1 + f;
            }

            y -= MultiPrecision<N>.Log(d);

            return y;
        }

        public static MultiPrecision<N> SterlingApprox(MultiPrecision<N> x) {
            x -= 1;

            MultiPrecision<N> b = SterlingTerm(x, max_term: 1024);
            if (MultiPrecision<N>.IsNaN(b)) {
                return MultiPrecision<N>.NaN;
            }

            MultiPrecision<N> x2 = x * x;

            MultiPrecision<N> c = LogBias + x * LogPI2Half + (x2 / 2 - Rcp12) * MultiPrecision<N>.Log(x) - 3 * x2 / 4;

            MultiPrecision<N> y = b + c;

            return y;
        }

        public static MultiPrecision<N> SterlingTerm(MultiPrecision<N> x, int max_term = 1024) {
            MultiPrecision<N> inv_x2 = 1 / (x * x), inv_x4 = inv_x2 * inv_x2;

            MultiPrecision<N> s = 0, w = inv_x2;

            for (int k = 1; k <= max_term; k += 2) {
                MultiPrecision<N> c1 = SterlingTermCoef(k), c2 = SterlingTermCoef(k + 1);

                MultiPrecision<N> ds = w * (c1 + inv_x2 * c2);

                if (ds > 0) {
                    return MultiPrecision<N>.NaN;
                }
                if (ds.Exponent < s.Exponent - MultiPrecision<N>.Bits) {
                    return s;
                }

                w *= inv_x4;
                s += ds;
            }

            throw new ArithmeticException("Not convergence BernoulliTerm.");
        }

        public static MultiPrecision<N> SterlingTermCoef(int n) {
            if (n >= sterling_term_coefs.Count) {
                for (int k = sterling_term_coefs.Count; k <= n; k++) {
                    MultiPrecision<N> c = MultiPrecision<N>.BernoulliSequence(k + 1) / (4 * k * (k + 1));
                    sterling_term_coefs.Add(c);
                }
            }

            return sterling_term_coefs[n];
        }

        private static MultiPrecision<N>? glaisher_a = null;
        public static MultiPrecision<N> GlaisherA {
            get {
                glaisher_a ??=
                      "1.282427129100622636875342568869791727767688927325001192063740" +
                        "021740406308858826461129736491958202374394206461203990007489" +
                        "331577913627752804041590725738617275221433432714343978733506" +
                        "791525736685690787656114668644999778496275451817431239465276" +
                        "128213808180219264516851546143919901083573730703504903888123" +
                        "418813674978133050937708336822224941158748373480643999788300" +
                        "701255670012869941577054320539275854058173158815548176297038" +
                        "474325046777514737460003161602304661329634299155809587929336" +
                        "343887288701988953460725233184702489001091776941712153569193" +
                        "674967261270398013526526688689782188974017293758407501674721" +
                        "148952888159966687431645138903069626455987046954374025309960" +
                        "680084244741755406149018944413938619608912968217352879862988" +
                        "434220366989900606980888785849587494085307347117090132667567" +
                        "503310523405221054141767761563081919199971852370477613123153" +
                        "741353047258198147974517610275408349431438496523413945337306" +
                        "583232567395495760169225642773692635882169215987077585827469" +
                        "575162841550648585890834128227556209547002918593263079373376" +
                        "942077522290940187086951957378071130966735177030019976191628" +
                        "410262375272681637822903373436258049442868053403273204290084" +
                        "638839112144326864590769532215986136634444203355493459547382" +
                        "171159174560410100293049262511276051143616882261783870652005" +
                        "254769631120797365703572826638445789928063169424245195498815" +
                        "132536669216125200170810611601861067100423241841751337740434" +
                        "811769956378082721495002650739796914415950826791401381635589" +
                        "264795001229480477096481671446294713585988310136346175694514" +
                        "927202352832895930381592395542187601929162562738323158490169" +
                        "331039265184899679790321481691023154969803693210911729522488" +
                        "474305055025280949700732256747711039659541713554869284559792" +
                        "934109873753765251251266122540365488003226600293326253795916" +
                        "347346827175861816915046920074083811431586031953317603861712" +
                        "607612298682736641023804848727932173173544629167314474073557" +
                        "595769307525500277628727581209719010080178736211891238992025" +
                        "496631023303097906188395750176089318779507323548959362359103" +
                        "833847624091895330031123168953945418733121648289643965312552" +
                        "0938777622545329416060171577126740091";

                return glaisher_a;
            }
        }

    }
}
