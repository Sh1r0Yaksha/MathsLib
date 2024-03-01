using MathsLib.Geometry.CoordinateGeometry;

namespace MathsLib.LinearAlgebra
{
    public class Vector3 : Vector
    {
        public Vector3(double x, double y, double z)
        {
            data = new double[3];
            Dimension = 3;
            X = x;
            Y = y;
            Z = z;
        }
        public double X
        {
            get
            {
                return this[0];
            }
            set
            {
                this[0] = value;
            }
        }
        public double Y
        {
            get
            {
                return this[1];
            }
            set
            {
                this[1] = value;
            }
        }
        public double Z
        {
            get
            {
                return this[2];
            }
            set
            {
                this[2] = value;
            }
        }

        public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            double x = v1.Y * v2.Z - v1.Z * v2.Y;
            double y = v1.Z * v2.X - v1.X * v2.Z;
            double z = v1.X * v2.Y - v2.Y * v2.X;
            return new Vector3(x, y, z);
        }

        public Point ToCoordinates()
        {
            return new Point(X, Y, Z);
        }
    }
}