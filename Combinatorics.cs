using MathsLib.Extensions;

namespace MathsLib
{
    public class Combinatorics
    {
        public static double Factorial(int x)
        {
            return CombinatoricsExtension.FactorialArray(x)[x];
        }

        public static double Factorial(int x, out double[] factorials)
        {
            factorials = CombinatoricsExtension.FactorialArray(x);
            return factorials[x];
        }

        public static int nCr(int n, int r)
        {
            double[] factArray;
            var nFact = Factorial(n, out factArray);

            return n < r ? throw new ArgumentException("Wrong values are provided!") : (int) (nFact / (factArray[r] * factArray[n-r]));
        }

        public static int nPr(int n, int r)
        {
            double[] factArray;
            var nFact = Factorial(n, out factArray);
            return n < r ? throw new ArgumentException("Wrong values are provided!") : (int) (nFact / factArray[n-r]);
        }
    }
}