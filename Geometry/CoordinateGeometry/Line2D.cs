using System.Drawing;
using System.Numerics;

namespace MathsLib.Geometry.CoordinateGeometry
{
    public class Line2D
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double Slope { get; set; }

        public Point xIntercept { get { return new Point(- c / a, 0); } }
        public Point yIntercept { get { return new Point( 0, -c / b); } }
        public Line Line
        {
            get
            {
                return new Line(xIntercept, yIntercept);
            }
        }
        public Line2D(Point point1, Point point2)
        {
            Slope = (point2.Y - point1.Y)/(point2.X - point1.X);
            a = Slope;
            b = -1;
            c = (- Slope * point1.X) + point1.Y;
        }
        public Line2D(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Slope = - a / b;
        }

        public static bool operator == (Line2D l1, Line2D l2)
        {
            return l1.a == l2.a && l1.b == l2.b && l1.c == l2.c;
        }
        public static bool operator != (Line2D l1, Line2D l2)
        {
            return !(l1 == l2);
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Line2D))
                return false;
            else
                return this == (Line2D)obj;
        }
    }
}