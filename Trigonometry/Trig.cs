namespace MathsLib.Trigonometry
{
    public class Trig
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
            angleDegrees = angleDegrees % 360;
            var sin = Math.Sin(DegreesToRadians(angleDegrees)) ;
            return  Math.Abs(sin) < tolerance ? 0 : sin ;
        }

        public static double Cos(double angleDegrees)
        {
            var cos = Math.Cos(DegreesToRadians(angleDegrees));
            return Math.Abs(cos) < tolerance ? 0 : cos;
        }

        public static double Tan(double angleDegrees)
        {
            var tan = Math.Tan(DegreesToRadians(angleDegrees));
            return Math.Abs(tan) < tolerance ? 0 : tan;
        }

        public static double Sec(double angleDegrees)
        {
            var cos = Cos(angleDegrees);
            var sec = cos == 0 ? double.NaN : 1 / cos;
            return sec;
        }

        public static double Cosec(double angleDegrees)
        {
            var sin = Sin(angleDegrees);
            var cosec = sin == 0 ? double.NaN : 1 / sin;
            return cosec;
        }

        public static double Cot(double angleDegrees)
        {

            var tan = Tan(angleDegrees);
            var cot = tan == 0 ? double.NaN : 1 / tan;
            return cot;
        }
    }
}