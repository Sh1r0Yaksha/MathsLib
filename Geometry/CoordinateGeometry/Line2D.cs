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

        // TODO: Add ==, != and Equals for Line2D
    }
}