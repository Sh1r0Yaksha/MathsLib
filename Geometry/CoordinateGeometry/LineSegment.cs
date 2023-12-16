namespace MathsLib.Geometry.CoordinateGeometry
{
    public class LineSegment
    {
        public Line Line { get; set; }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public LineSegment(Point p1, Point p2)
        {
            Point1 = p1;
            Point2 = p2;
            Line = new Line(Point1, Point2);
        }
    }
}