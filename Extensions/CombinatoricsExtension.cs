namespace MathsLib.Extensions
{
    public class CombinatoricsExtension
    {
        public static double[] FactorialArray(int x)
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