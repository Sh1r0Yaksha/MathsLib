using MathsLib.Geometry.CoordinateGeometry;

namespace MathsLib.LinearAlgebra
{
    public class Vector
    {

        protected double[] data;
        // public double X { get; set; }
        // public double Y { get; set; }
        // public double Z { get; set; }
        public int Dimension { get; set; }
        public double this[int dim]
        {
            get { return data[dim]; }
            set { data[dim] = value; }
        }

        public double magnitude
        {
            get
            {
                double mag = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    mag += this[i] * this[i];
                }
                return Math.Sqrt(mag);
            }
        }

        public Vector(params double[] data)
        {
            this.data = data;
            Dimension = data.Length;
        }

        public Vector(int dim)
        {
            this.data = new double[dim];
            Dimension = dim;
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
            for (int i = 0; i < v.Dimension; i++)
            {
                v[i] /= dividend;
            }
            return v;
        }

        public static Vector operator * (Vector v, double multiplicand)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v[i] *= multiplicand;
            }
            return v;
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            if (v1.Dimension > v2.Dimension)
            {
                Vector sum = new Vector(v1.Dimension);
                for (int i = 0; i < v2.Dimension; i++)
                {
                    sum[i] = v1[i] + v2[i];
                }
                for (int i = v2.Dimension; i < v1.Dimension; i++)
                {
                    sum[i] = v1[i];
                }
                return sum;
            }
            else
            {
                Vector sum = new Vector(v2.Dimension);
                for (int i = 0; i < v1.Dimension; i++)
                {
                    sum[i] = v1[i] + v2[i];
                }
                for (int i = v1.Dimension; i < v2.Dimension; i++)
                {
                    sum[i] = v2[i];
                }
                return sum;
            }
            // return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator - (Vector v1, Vector v2)
        {
            if (v1.Dimension > v2.Dimension)
            {
                Vector diff = new Vector(v1.Dimension);
                for (int i = 0; i < v2.Dimension; i++)
                {
                    diff[i] = v1[i] - v2[i];
                }
                for (int i = v2.Dimension; i < v1.Dimension; i++)
                {
                    diff[i] = v1[i];
                }
                return diff;
            }
            else
            {
                Vector diff = new Vector(v2.Dimension);
                for (int i = 0; i < v1.Dimension; i++)
                {
                    diff[i] = v1[i] - v2[i];
                }
                for (int i = v1.Dimension; i < v2.Dimension; i++)
                {
                    diff[i] = - v2[i];
                }
                return diff;
            }
            // return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }


        public static double DotProduct(Vector v1, Vector v2)
        {
            double dot = 0;
            for (int i = 0; i < Math.Min(v1.Dimension, v2.Dimension); i++)
            {
                dot += v1[i] * v2[i];
            }
            return dot;
        }

        // public static Vector CrossProduct(Vector v1, Vector v2)
        // {
        //     // double X = v1.Y * v2.Z - v1.Z * v2.Y;
        //     // double Y = v1.Z * v2.X - v1.X * v2.Z;
        //     // double Z = v1.X * v2.Y - v2.Y * v2.X;
        //     // return new Vector(X, Y, Z);
        // }

        public Matrix ToMatrix()
        {
            Matrix v = new Matrix(Dimension,1);
            for (int i = 0; i < Dimension; i++)
            {
                v[i,0] = this[i];
            }
            return v;
        }

        // public Point ToCoordinates()
        // {
        //     return new Point(X, Y, Z);
        // }
    }
}