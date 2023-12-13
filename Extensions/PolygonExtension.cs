namespace MathsLib.Extensions
{
    internal class PolygonExtension
    {
        public static bool CheckForExactlyTwoGiven(double a, double b, double c)
        {
            return (a == 0 && b != 0 && c != 0) ||
                (a != 0 && b == 0 && c != 0) ||
                (a != 0 && b != 0 && c == 0);
        }
        public static bool CheckForExactlyOneGiven(double a, double b, double c)
        {
            return (a == 0 && b == 0 && c != 0) ||
                   (a == 0 && b != 0 && c == 0) ||
                   (a != 0 && b == 0 && c == 0);
        }
        public static double TriangleCosA(double a, double b, double c)
        {
            return (a*a - b*b - c*c) / (2 * b * c);
        }
    }
}