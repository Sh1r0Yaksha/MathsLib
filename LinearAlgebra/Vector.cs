using MathsLib.Geometry.CoordinateGeometry;

namespace MathsLib.LinearAlgebra
{
    public class Vector
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double magnitude => Math.Sqrt(X*X + Y*Y + Z*Z);

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default: throw new ArgumentException("index out of range");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: X = value;
                        break;
                    case 1: Y = value;
                        break;
                    case 2: Z = value;
                        break;
                    default: throw new ArgumentException("index out of range");
                }
            }
        }
        public Vector normal
        {
            get
            {
                return this / magnitude;
            }
        }


        public static Vector operator / (Vector v, double dividend)
        {
            return new Vector(v.X / dividend, v.Y / dividend, v.Z / dividend);
        }

        public static Vector operator * (Vector v, double multiplicand)
        {
            return new Vector(v.X * multiplicand, v.Y * multiplicand, v.Z * multiplicand);
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator - (Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector (double x)
        {
            X = x;
            Y = x;
            Z = x;
        }

        public static double DotProduct(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            double X = v1.Y * v2.Z - v1.Z * v2.Y;
            double Y = v1.Z * v2.X - v1.X * v2.Z;
            double Z = v1.X * v2.Y - v2.Y * v2.X;
            return new Vector(X, Y, Z);
        }

        public Matrix ToMatrix()
        {
            Matrix v = new Matrix(3,1);
            for (int i = 0; i < 3; i++)
            {
                v[i,0] = this[i];
            }
            return v;
        }

        public Point ToCoordinates()
        {
            return new Point(X, Y, Z);
        }
    }
}