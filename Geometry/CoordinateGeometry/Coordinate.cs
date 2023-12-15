using MathsLib.LinearAlgebra;

namespace MathsLib.Geometry.CoordinateGeometry
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector Vector
        {
            get
            {
                return new Vector(X, Y, Z);
            }
        }

        public Coordinate(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

    }
}