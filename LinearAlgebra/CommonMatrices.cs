using MathsLib.Trigonometry;

namespace MathsLib.LinearAlgebra
{
    /// <summary>
    /// Contains various matrices commonly used like Rotation Matrix, Identity Matrix etc.
    /// </summary>
    public abstract class CommonMatrices
    {
        /// <summary>
        /// Returns a 2D rotation matrix with given angle of rotation
        /// </summary>
        /// <param name="angleDegrees">Angle of rotation in degrees</param>
        /// <returns>2D rotation matrix with given angle of rotation</returns>
        public static Matrix Rotation2D(double angleDegrees)
        {
            Matrix matrix = new Matrix(2,2);
            double cos = Trig.Cos(angleDegrees);
            double sin = Trig.Sin(angleDegrees);
            matrix[0,0] = cos;
            matrix[0,1] = sin == 0 ? 0 : -sin;
            matrix[1,0] = sin;
            matrix[1,1] = cos;

            return matrix;
        }

        /// <summary>
        /// Returns a 3D rotation matrix with given angle of rotation about the x-axis
        /// </summary>
        /// <param name="angleDegrees">Angle of rotation in degrees</param>
        /// <returns>3D rotation matrix with given angle of rotation about the x-axis</returns>
        public static Matrix Rotation3Dx(double angleDegrees)
        {
            Matrix matrix = new Matrix(3,3);
            double cos = Trig.Cos(angleDegrees);
            double sin = Trig.Sin(angleDegrees);
            matrix[0,0] = 1;
            matrix[0,1] = 0;
            matrix[0,2] = 0;

            matrix[1,0] = 0;
            matrix[1,1] = cos;
            matrix[1,2] = sin == 0 ? 0 : -sin;

            matrix[2,0] = 0;
            matrix[2,1] = sin;
            matrix[2,2] = cos;

            return matrix;
        }

        
        /// <summary>
        /// Returns a 3D rotation matrix with given angle of rotation about the y-axis
        /// </summary>
        /// <param name="angleDegrees">Angle of rotation in degrees</param>
        /// <returns>3D rotation matrix with given angle of rotation about the y-axis</returns>
        public static Matrix Rotation3Dy(double angleDegrees)
        {
            Matrix matrix = new Matrix(3,3);
            double cos = Trig.Cos(angleDegrees);
            double sin = Trig.Sin(angleDegrees);
            matrix[0,0] = cos;
            matrix[0,1] = 0;
            matrix[0,2] = sin;

            matrix[1,0] = 0;
            matrix[1,1] = 1;
            matrix[1,2] = 0;

            matrix[2,0] = sin == 0 ? 0 : -sin;
            matrix[2,1] = 0;
            matrix[2,2] = cos;

            return matrix;
        }


        /// <summary>
        /// Returns a 3D rotation matrix with given angle of rotation about the z-axis
        /// </summary>
        /// <param name="angleDegrees">Angle of rotation in degrees</param>
        /// <returns>3D rotation matrix with given angle of rotation about the z-axis</returns>
        public static Matrix Rotation3Dz(double angleDegrees)
        {
            Matrix matrix = new Matrix(3,3);
            double cos = Trig.Cos(angleDegrees);
            double sin = Trig.Sin(angleDegrees);
            matrix[0,0] = cos;
            matrix[0,1] = sin == 0 ? 0 : -sin;
            matrix[0,2] = 0;

            matrix[1,0] = sin;
            matrix[1,1] = cos;
            matrix[1,2] = 0;

            matrix[2,0] = 0;
            matrix[2,1] = 0;
            matrix[2,2] = 1;

            return matrix;
        }

        /// <summary>
        /// Returns a 3D rotation matrix with given intrinsic angles of rotation (yaw, pitch and roll)
        /// </summary>
        /// <param name="alphaDegrees">Yaw angle</param>
        /// <param name="betaDegrees">Pitch angle</param>
        /// <param name="gammaDegrees">Roll angle</param>
        /// <returns>3D rotation matrix with given intrinsic angles of rotation (yaw, pitch and roll)</returns>
        public static Matrix IntrinsicRotation3D(double alphaDegrees, double betaDegrees, double gammaDegrees)
        {
            Matrix RzRy = Matrix.Multiplication(Rotation3Dz(alphaDegrees), Rotation3Dy(betaDegrees));
            Matrix R = Matrix.Multiplication(RzRy, Rotation3Dx(gammaDegrees));

            return R;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="angleDegrees">Angle of rotation in degrees</param>
        /// <returns></returns>
        public static Matrix ExtrinsicRotation3D(double alphaDegrees, double betaDegrees, double gammaDegrees)
        {
            Matrix RzRy = Matrix.Multiplication(Rotation3Dz(gammaDegrees), Rotation3Dy(betaDegrees));
            Matrix R = Matrix.Multiplication(RzRy, Rotation3Dx(alphaDegrees));

            return R;
        }

        /// <summary>
        /// Returns an identity matrix with given number of rows
        /// </summary>
        /// <param name="rows">Number of Rows of the matrix</param>
        /// <returns>Identity matrix with given number of rows</returns>
        public static Matrix Identity(int rows)
        {
            Matrix id = new Matrix(rows, rows);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i == j)
                        id[i,j] = 1;
                    else
                        id[i,j] = 0;
                }
            }

            return id;
        }
    }
}