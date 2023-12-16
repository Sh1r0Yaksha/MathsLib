using MathsLib.LinearAlgebra;

namespace MathsLib.Geometry.CoordinateGeometry
{
    public class Line
    {
        public Point PassingPoint { get; set; }
        public Vector ParallelVector { get; set; }
        public double DirCosineL { get; set; }
        public double DirCosineM { get; set; }
        public double DirCoisneN { get; set; }
        public Point? xIntercept
        {
            get
            {
                if ( PassingPoint.Y / DirCosineM != PassingPoint.Z / DirCoisneN)
                    return null;
                return new Point(PassingPoint.X - (DirCosineL / DirCosineM) * PassingPoint.Y , 0, 0);
            }
        }
        public Point? yIntercept
        {
            get
            {
                if ( PassingPoint.X / DirCosineL != PassingPoint.Z / DirCoisneN)
                    return null;
                return new Point(0, PassingPoint.Y - (DirCosineM / DirCosineL) * PassingPoint.X, 0);
            }
        }
        public Point? zIntercept
        {
            get
            {
                if (PassingPoint.X / DirCosineL != PassingPoint.Y / DirCosineM)
                    return null;
                return new Point(0, 0, PassingPoint.Z - (DirCoisneN / DirCosineL) * PassingPoint.X);
            }
        }
        public Line(Point point1, Point point2)
        {
            PassingPoint = point1;
            ParallelVector = point2.Vector - point1.Vector;

            DirCosineL = (point2.X - point1.X) / ParallelVector.magnitude;
            DirCosineM = (point2.Y - point1.Y) / ParallelVector.magnitude;
            DirCoisneN = (point2.Z - point1.Z) / ParallelVector.magnitude;
        }

        public static bool operator == (Line l1, Line l2)
        {
            return l1.xIntercept == l2.xIntercept && l1.yIntercept == l2.yIntercept && l1.zIntercept == l2.zIntercept;
        }
        public static bool operator != (Line l1, Line l2)
        {
            return !(l1.xIntercept == l2.xIntercept && l1.yIntercept == l2.yIntercept && l1.zIntercept == l2.zIntercept);
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Line))
                return false;
            else
                return this == (Line)obj;
        }
    }
}