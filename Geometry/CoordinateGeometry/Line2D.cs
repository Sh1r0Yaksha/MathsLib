namespace MathsLib.Geometry.CoordinateGeometry
{
    public class Line2D
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double Slope { get; set; }

        // TODO Line xCoordinate
        public Coordinate xIntercept;

        public Line2D(Coordinate point1, Coordinate point2)
        {
            Slope = (point2.Y - point1.Y)/(point2.X - point1.X);

        }
    }
}