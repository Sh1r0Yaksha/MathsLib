namespace MathsLib.Extensions
{
    public class ExponentLogExtensions
    {
        public static double NewtonLn(double number, double tolerance = 1E-10, int maxIterations = 100)
        {
            double xn = 1;

            for (int i = 0; i < maxIterations; i++)
            {
                double ex = Math.Pow(Math.E, xn);
                double f = ex - number;
                double fPrime = ex;
                var xn1 = xn - f/fPrime;

                if (Math.Abs(xn1 - xn) < tolerance)
                {
                    return xn1;
                }

                xn = xn1;
            }

            return xn;
        }
        public static double NewtonLog(double baseValue, double number, double tolerance = 1E-10, int maxIterations = 100)
        {
            double xn = 1;

            var lnk = NewtonLn(baseValue);

            for (int i = 0; i < maxIterations; i++)
            {
                var numerator = Math.Pow(baseValue, xn) - number;
                var denominator = Math.Pow(baseValue, xn) * lnk;

                var xn1 = xn - numerator/denominator;

                if (Math.Abs(xn1 - xn) <= tolerance)
                    return xn1;
                xn = xn1;
            }

            return xn;
        }
    }
}