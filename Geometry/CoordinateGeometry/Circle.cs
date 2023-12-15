namespace MathsLib.Geometry.CoordinateGeometry
{
    public class Circle
    {
        public Coordinate Centre { get; set; }
        public double Radius { get; set; }
        public double Area
        {
             get
             {
                return Math.PI * Radius * Radius;
             }
        }

        public double Circumference
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        public Circle(Coordinate center, double radius)
        {
            Centre = center;
            Radius = radius;
        }
    }
}