using MathsLib.Extensions;

namespace MathsLib.Geometry
{
    public class Triangle : Polygon
    {
        public double InRadius { get; set; }
        public double CircumRadius { get; set; }
        public Triangle(double a = 0, double b = 0, double c = 0,
                        double A = 0,double B = 0, double C = 0)
        {

            // All three sides given
            if (a != 0 && b != 0 && c != 0)
            {
                A = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(a, b, c));
                B = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(b, a, c));
                C = 180 - A - B;
            }

            // Two Angles and a side is given
            else if (PolygonExtension.CheckForExactlyTwoGiven(A, B, C) && PolygonExtension.CheckForExactlyOneGiven(a, b, c))
            {
                if (A == 0)
                    A = 180 - (B + C);
                else if (B == 0)
                    B = 180 - (A + C);
                else if (C == 0)
                    C = 180 - (B + A);

                if (a != 0)
                {
                    b = Trigonometry.Sin(B) * a /  Trigonometry.Sin(A);
                    c = Trigonometry.Sin(C) * a /  Trigonometry.Sin(A);
                }
                else if (b != 0)
                {
                    a = Trigonometry.Sin(A) * b /  Trigonometry.Sin(B);
                    c = Trigonometry.Sin(C) * b /  Trigonometry.Sin(B);
                }
                else if (c != 0)
                {
                    a = Trigonometry.Sin(A) * c /  Trigonometry.Sin(C);
                    b = Trigonometry.Sin(B) * c /  Trigonometry.Sin(C);
                }
                else
                {
                    throw new ArgumentException("Wrong Dimensions are given");
                }
            }

            // Two Sides and an Angle is given
            else if (PolygonExtension.CheckForExactlyTwoGiven(a, b, c) && PolygonExtension.CheckForExactlyOneGiven(A, B, C))
            {
                if (a == 0 && A != 0)
                {
                    a = Math.Sqrt(b*b + c*c - 2*b*c*Trigonometry.Cos(A));
                    B = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(b, a, c));
                    C = 180 - A - B;
                }
                else if (b == 0 && B != 0)
                {
                    b = Math.Sqrt(a*a + c*c - 2*a*c*Trigonometry.Cos(B));
                    A = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(a, b, c));
                    C = 180 - A - B;
                }
                else if (c == 0 && C != 0)
                {
                    c = Math.Sqrt(a*a + b*b - 2*a*b*Trigonometry.Cos(C));
                    A = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(a, b, c));
                    B = 180 - A - C;
                }
                else if (A == 90)
                {
                    if (b == 0)
                        b = Math.Sqrt(a*a - c*c);
                    if (c == 0)
                        c = Math.Sqrt(a*a - b*b);
                    B = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(b, a, c));
                    C = 90 - B;
                }
                else if (B == 90)
                {
                    if (a == 0)
                        a = Math.Sqrt(b*b - c*c);
                    if (c == 0)
                        c = Math.Sqrt(b*b - a*a);
                    C = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(c, b, a));
                    A = 90 - C;
                }
                else if (C == 90)
                {
                    if (b == 0)
                        a = Math.Sqrt(c*c - a*a);
                    if (a == 0)
                        a = Math.Sqrt(c*c - b*b);
                    B = 180 - Trigonometry.ACos(PolygonExtension.TriangleCosA(b, a, c));
                    A = 90 - B;
                }
                else
                {
                    throw new ArgumentException("Wrong Dimensions are given");
                }
            }
            else
            {
                throw new ArgumentException("Wrong Dimensions are given");
            }

            var numEdges = 3;

            this.Edges = new double[numEdges];
            this.Angles = new double[numEdges];

            Edges[0] = a;
            Edges[1] = b;
            Edges[2] = c;

            Angles[0] = A;
            Angles[1] = B;
            Angles[2] = C;

            for (int i = 0; i < numEdges; i++)
            {
                if (Edges[i] <= 0)
                    throw new ArgumentException($"Wrong edge length of {i} are given");

                if (Angles[i] <= 0)
                    throw new ArgumentException($"Wrong Angle of {i} are given");
            }

            this.Perimeter = a+b+c;
            var s = Perimeter / 2;
            this.Area = Math.Sqrt(s * (s-a) * (s-b) * (s-c));;

            this.InRadius = Area / s;
            this.CircumRadius = a*b*c/Math.Sqrt((a+b+c)*(b+c-a)*(c+a-b)*(a+b-c));
        }

        public override void PrintProperties()
        {
            base.PrintProperties();

            Console.WriteLine($"Inradius: {InRadius}");
            Console.WriteLine($"Circumradius: {CircumRadius}");
        }

    }
}