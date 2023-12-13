using MathsLib.LinearAlgebra;

namespace MathsLib.Extensions
{
    internal class LinearAlgebraExtension
    {
        public static double GetSignForDeterminant(int i, int j)
        {
            // Returns the sign for the Laplace expansion
            return (i + j) % 2 == 0 ? 1 : -1;
        }
        public static Matrix GetSubmatrix(Matrix matrix, int rowToRemove, int colToRemove)
        {
            // Returns the submatrix obtained by removing the specified row and column
            int n = matrix.Rows;
            Matrix submatrix = new Matrix(n - 1, n - 1);

            int rowIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == rowToRemove)
                    continue;

                int colIndex = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == colToRemove)
                        continue;

                    submatrix[rowIndex, colIndex] = matrix[i, j];
                    colIndex++;
                }

                rowIndex++;
            }

            return submatrix;
        }
    }
}