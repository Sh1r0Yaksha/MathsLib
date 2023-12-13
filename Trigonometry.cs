namespace MathsLib
{
    public class Trigonometry
    {
        const double tolerance = 1E-12;
        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180 ;
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI ;
        }

        public static double Sin(double angleDegrees)
        {
            return Math.Sin(DegreesToRadians(angleDegrees));
        }

        public static double Cos(double angleDegrees)
        {
            return Math.Cos(DegreesToRadians(angleDegrees));
        }

        public static double Tan(double angleDegrees)
        {
            return Math.Tan(DegreesToRadians(angleDegrees));
        }

        public static double Sec(double angleDegrees)
        {
            var cos = Cos(angleDegrees);
            return cos == 0 ? double.NaN : 1 / cos;
        }

        public static double Cosec(double angleDegrees)
        {
            var sin = Sin(angleDegrees);
            return sin == 0 ? double.NaN : 1 / sin;
        }

        public static double Cot(double angleDegrees)
        {

            var tan = Tan(angleDegrees);
            return tan == 0 ? double.NaN : 1 / tan;
        }

        public static double ASin(double x)
        {
            return RadiansToDegrees(Math.Asin(x));
        }

        public static double ACos(double x)
        {
            return RadiansToDegrees(Math.Acos(x));
        }

        public static double ATan(double x)
        {
            return RadiansToDegrees(Math.Atan(x));
        }

        public static double ASec(double x)
        {
            return x == 0 ? double.NaN : RadiansToDegrees(Math.Acos(1/x));
        }

        public static double ACosec(double x)
        {
            return x == 0 ? double.NaN : RadiansToDegrees(Math.Asin(1/x));
        }

        public static double ACot(double x)
        {
            return x == 0 ? double.NaN : RadiansToDegrees(Math.Atan(1/x));
        }
    }
}