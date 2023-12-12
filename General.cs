namespace MathsLib
{
    public class General
    {
        public static double Factorial(int x)
        {
            return FactorialExtension(x)[x];
        }

        public static double Factorial(int x, out double[] factorials)
        {
            factorials = FactorialExtension(x);
            return factorials[x];
        }

        public static double[] FactorialExtension(int x)
        {
            double[] fact = new double[x+1];
            fact[0] = 1;
            for (int i = 1; i <= x; i++)
            {
                fact[i] = i * fact[i-1];
            }
            return fact;
        }
    }
}