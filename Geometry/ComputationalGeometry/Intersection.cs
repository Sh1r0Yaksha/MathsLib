using MathsLib.Geometry.CoordinateGeometry;

namespace MathsLib.Geometry.ComputationalGeometry
{
    public class Intersection
    {
        public static Point? Line2DIntersection(Line2D line1, Line2D line2, out bool areOverlapping)
        {
            if (line1 == line2)
            {
                areOverlapping = true;
                return null;
            }
            else if ((line1.a * line2.b - line2.a * line1.b) != 0)
            {
                double x = (line1.b * line2.c - line2.b * line1.c) / (line1.a * line2.b - line2.a * line1.b);
                double y = (line2.a * line1.c - line1.a * line2.c) / (line1.a * line2.b - line2.a * line1.b);
                areOverlapping = false;
                return new Point(x, y);
            }
            else
            {
                areOverlapping = false;
                return null;
            }
        }
        // TODO: Line Intersection
        // public static Point? Lineintersection(Line line1, Line line2, out bool areOverlapping)
        // {
        //     if ()
        //     return new Point(0,0);
        // }
    }
}