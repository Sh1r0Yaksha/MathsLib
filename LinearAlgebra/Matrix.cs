using MathsLib.Extensions;

namespace MathsLib.LinearAlgebra
{
    public class Matrix
    {
        private double[,] data;
        public int Rows { get; }
        public int Columns { get; }
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            data = new double[rows, columns];
        }

        public double this[int row, int column]
        {
            get { return data[row, column]; }
            set { data[row, column] = value; }
        }
        public bool IsSquare => Rows == Columns;
        public bool IsSymmetric
        {
            get
            {
                if (!IsSquare)
                    return false;

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (data[i,j] != data[j,i])
                            return false;
                    }
                }
                return true;
            }
        }
        public bool IsIdentity
        {
            get
            {
                if (!IsSquare)
                    return false;

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (i == j && data[i,j] != 1)
                            return false;
                        else if (i != j && data[i,j] != 0)
                            return false;
                    }
                }
                return true;

            }
        }
        public Matrix Transpose
        {
            get
            {
                Matrix T = new Matrix(this.Columns, this.Rows);

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        T[j,i] = this[i,j];
                    }
                }

                return T;
            }
        }
        public Matrix Cofactor
        {
            get
            {
                Matrix cofactor = new Matrix(Rows, Columns);
                for (int i = 0; i < this.Rows; i++)
                {
                    for (int j = 0; j < this.Columns; j++)
                    {
                        Matrix minorMatrix = LinearAlgebraExtension.GetSubmatrix(this, i, j);
                        var minor = minorMatrix.Determinant;
                        cofactor[i,j] = Math.Pow(-1, i+j) * minor;
                    }
                }

                return cofactor;
            }
        }
        public Matrix Adjoint
        {
            get
            {
                Matrix cofactor = this.Cofactor;
                return cofactor.Transpose;
            }

        }
        public Matrix? Inverse
        {
            get
            {
                if (this.Determinant == 0)
                    return null;
                else
                {
                    return Adjoint * (1/this.Determinant);
                }
            }

        }
        public Vector ToVector
        {
            get
            {
                Vector m = new Vector(0);
                if (Rows == 1 && Columns == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        m[i] = this[0,i];
                    }
                }
                else if (Rows == 3 && Columns == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        m[i] = this[i,0];
                    }
                }
                else
                {
                    throw new ArgumentException("Vector cannot be constructed from the given dimensions of the matrix");
                }
                return m;
            }
        }
        public double Determinant
        {
            get
            {
                if (!this.IsSquare)
                    return double.NaN;
                int n = Rows;

                // Base case: 2x2 matrix
                if (n == 2)
                {
                    return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
                }

                double result = 0.0;

                // Laplace expansion
                for (int j = 0; j < n; j++)
                {
                    var submatrix = LinearAlgebraExtension.GetSubmatrix(this, 0, j);
                    result += this[0, j] * LinearAlgebraExtension.GetSignForDeterminant(0, j) * submatrix.Determinant;
                }

                return result;
            }
        }
        public double Trace
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < Rows; i++)
                {
                    sum += this[i,i];
                }
                return sum;
            }
        }
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(data[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static Matrix Multiplication(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new ArgumentException("Dimensions of matrices don't match!");

            Matrix matrix = new Matrix(m1.Rows, m2.Columns);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    for (int k = 0; k < m1.Columns; k++)
                    {
                        matrix[i,j] += m1[i,k] * m2[k,j];
                    }
                }
            }

            return matrix;
        }


        public static Matrix operator + (Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows && m1.Columns != m2.Columns)
                throw new ArgumentException("Dimensions of matrices don't match!");

            Matrix matrix = new Matrix(m1.Rows, m1.Columns);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    matrix[i,j] = m1[i,j] + m2[i,j];
                }
            }

            return matrix;
        }

        public static Matrix operator - (Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows && m1.Columns != m2.Columns)
                throw new ArgumentException("Dimensions of matrices don't match!");

            Matrix matrix = new Matrix(m1.Rows, m1.Columns);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    matrix[i,j] = m1[i,j] - m2[i,j];
                }
            }

            return matrix;
        }

        public static Matrix operator * (Matrix m, double num)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    m[i,j] *= num;
                }
            }
            return m;
        }

        public static Matrix operator * (double num, Matrix m)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    m[i,j] *= num;
                }
            }
            return m;
        }
    }
}