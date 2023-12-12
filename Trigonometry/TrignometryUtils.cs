namespace MathsLib.Trigonometry
{
    internal class TrignometryUtils
    {
        public static double TaylorExpansionSine(double x, int precision)
        {
            double[] factorialArray;
            double _ = General.Factorial(2*precision - 1,out factorialArray);
            double result = 0;

            for (int i = 1; i <= precision; i++)
            {
                int currentNum = 2 * i - 1;
                double arithmetics = Math.Pow(x, currentNum)/factorialArray[currentNum];

                result += (i % 2 == 1) ? arithmetics : -arithmetics;
            }

            return result;
        }

        public static double TaylorExpansionCosine(double x, int precision)
        {
            double[] factorialArray;
            double _ = General.Factorial(2 * (precision-1),out factorialArray);
            double result = 0;

            for (int i = 0; i < precision; i++)
            {
                int currentNum = 2 * i;
                double arithmetics = Math.Pow(x, currentNum)/factorialArray[currentNum];

                result += (i % 2 == 1) ? arithmetics : -arithmetics;
            }

            return result;
        }

    }
}