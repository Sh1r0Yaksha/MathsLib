namespace MathsLib.ComplexNumbers
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public double Absolute { get; set; }
        public double Argument { get; set; }

        public Complex Conjugate => new Complex(Real, - Imaginary);
        public Complex Reciprocal => new Complex(Real/(Absolute * Absolute), Imaginary/(Absolute * Absolute));

        /// <summary>
        /// Returns a complex number in cartesian (a + ib) form or polar(r,0) form
        /// </summary>
        /// <param name="re">If cartesian is true, sets Real value of complex number, otherwise sets the absolute value</param>
        /// <param name="im">If cartesian is true, sets Imaginary value of complex number, otherwise sets the Argument in Degrees</param>
        /// <param name="cartesian">Defines wether the given parameters are in cartesian or polar form, cartesian by default</param>
        public Complex(double re, double im, bool cartesian = true)
        {
            if (cartesian)
            {
                Real = re;
                Imaginary = im;

                Absolute = Math.Sqrt(Real * Real + Imaginary * Imaginary);
                Argument = Trigonometry.ATan2(Imaginary, Real);
            }
            else
            {
                Absolute = re;
                Argument = im;

                Real = Absolute * Trigonometry.Cos(Argument);
                Imaginary = Absolute * Trigonometry.Sin(Argument);
            }
        }

        public static Complex operator + (Complex z1, Complex z2)
        {
            return new Complex(z1.Real + z2.Real, z1.Imaginary + z2.Imaginary);
        }

        public static Complex operator - (Complex z1, Complex z2)
        {
            return new Complex(z1.Real - z2.Real, z1.Imaginary - z2.Imaginary);
        }

        public static Complex operator * (Complex z1, Complex z2)
        {
            var re = z1.Real * z2.Real - z1.Imaginary * z2.Imaginary;
            var im = z1.Real * z2.Imaginary + z1.Imaginary * z2.Real;
            return new Complex(re, im);
        }

        public static Complex operator / (Complex z1, Complex z2)
        {

            return z1 * z2.Reciprocal;
        }

        public static bool operator == (Complex z1, Complex z2)
        {
            return z1.Real == z2.Real && z1.Imaginary == z2.Imaginary;
        }

        public static bool operator != (Complex z1, Complex z2)
        {
            return !(z1 == z2);
        }
    }
}