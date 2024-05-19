using System;
using System.Collections.Generic;

namespace MathsLib.Calculus
{
    public class Function
    {
        public Function(){}
        public delegate double UserDefinedFunction(double input);
        private UserDefinedFunction f;
        public double Invoke(double input)
        {
            if (f == null)
            {
                throw new InvalidOperationException("User-defined function is not set.");
            }
            return f(input);
        }
        public double this[double input]
        {
            get { return f(input); }
        }
        public void SetFunction(UserDefinedFunction function)
        {
            f = function;

            if (f == null)
            {
                throw new InvalidOperationException("User-defined function is not set.");
            }
        }

        /// <summary>
        /// Five-point method for first Derivative
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public double Derivative(double x, double h = 1e-3)
        {
            double df = (f(x-2*h) + 8*f(x+h) - 8*f(x-h) - f(x+2*h)) / (12*h);
            if (df == double.NaN)
            {
                throw new Exception($"The function is not differentiable at the given point {x}");
            }
            return df;
        }

        /// <summary>
        /// Finds the root of function between given inputs a and b using Brent's Method, note that f(a) and f(b) should be of opposite signs
        /// </summary>
        /// <param name="a">lower bound of the root</param>
        /// <param name="b">upper bound of the root</param>
        /// <param name="tol">tolerance value for the root</param>
        /// <param name="maxIter">maximum number of iterations for convergence</param>
        /// <returns>root of the function</returns>
        public double Root(double a, double b, double tol = 1e-6, int maxIter = 500)
        {
            if (f(a) * f(b) >= 0)
            {
                throw new ArgumentException("The function must have different signs at the endpoints a and b.");
            }
            double c = a, d = double.MaxValue, e = double.MaxValue;
            double fa = f(a), fb = f(b), fc = fa;

            for (int iter = 0; iter < maxIter; iter++)
            {
                if (Math.Abs(fa) < Math.Abs(fb))
                {
                    // Swap a and b
                    (a, b) = (b, a);
                    (fa, fb) = (fb, fa);
                }

                double m = 0.5 * (a - b);
                double tolerance = 2.0 * tol * Math.Max(Math.Abs(b), 1.0);
                if (Math.Abs(m) <= tolerance || fb == 0)
                {
                    // Root is found
                    return b;
                }

                if (Math.Abs(e) < tolerance || Math.Abs(fc) <= Math.Abs(fb))
                {
                    // Bisection method
                    d = e = m;
                }
                else
                {
                    double s = fb / fc;
                    double p, q;

                    if (a == c)
                    {
                        // Secant method
                        p = 2.0 * m * s;
                        q = 1.0 - s;
                    }
                    else
                    {
                        // Inverse quadratic interpolation
                        q = fc / fa;
                        double r = fb / fa;
                        p = s * (2.0 * m * q * (q - r) - (b - c) * (r - 1.0));
                        q = (q - 1.0) * (r - 1.0) * (s - 1.0);
                    }

                    if (p > 0)
                    {
                        q = -q;
                    }
                    else
                    {
                        p = -p;
                    }

                    if (2.0 * p < 3.0 * m * q - Math.Abs(tolerance * q) && p < Math.Abs(0.5 * e * q))
                    {
                        e = d;
                        d = p / q;
                    }
                    else
                    {
                        d = e = m;
                    }
                }

                a = b;
                fa = fb;

                if (Math.Abs(d) > tolerance)
                {
                    b += d;
                }
                else
                {
                    b += Math.Sign(m) * tolerance;
                }

                fb = f(b);

                if ((fb > 0 && fc > 0) || (fb < 0 && fc < 0))
                {
                    c = a;
                    fc = fa;
                    d = e = b - a;
                }
            }

            throw new Exception("Maximum number of iterations reached.");
        }
    }
}