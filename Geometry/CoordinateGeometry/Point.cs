using MathsLib.LinearAlgebra;

namespace MathsLib.Geometry.CoordinateGeometry
{
    public class Point
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

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public static bool operator == (Point? p1, Point? p2)
        {
            if (p1 == null || p2 == null)
            {
                if (p1 == null && p2 == null)
                    return true;
                return false;
            }
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator != (Point? p1, Point? p2)
        {
            if (p1 == null || p2 == null)
            {
                if (p1 == null && p2 == null)
                    return false;
                return true;
            }
            return !(p1.X == p2.X && p1.Y == p2.Y);
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Point))
                return false;
            else
                return this == (Point)obj;
        }
    }
}