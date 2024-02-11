using MathsLib.Extensions;

namespace MathsLib.ExponentsLogarithms
{
    public class Logarithm
    {
        public static double Log10(double number)
        {
            return ExponentLogExtensions.NewtonLog(10, number, 1E-12, 200);
        }

        public static double Log2(double number)
        {
            return ExponentLogExtensions.NewtonLog(2, number, 1E-12, 200);
        }

        public static double Ln(double number)
        {
            return ExponentLogExtensions.NewtonLn(number, 1E-12, 1000);
        }

        public static double Log(double baseValue, double number)
        {
            return ExponentLogExtensions.NewtonLog(baseValue, number);
        }
    }
}