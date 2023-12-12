using System;
using System.Collections.Generic;
using MathsLib.Trigonometry;

namespace MathsLib.Geometry
{

    public abstract class Polygon
    {
        public double Perimeter { get; set; }
        public double Area { get; set; }
        public int NumEdges { get; set; }
        public double[] Edges{ get; protected set; }
        public double[] Angles { get; protected set; }

        public Polygon()
        {
            Edges = new double[NumEdges];
            Angles = new double[NumEdges];
        }
        public virtual void PrintProperties()
        {
            for (int i = 0; i < Edges.Length; i++)
            {
                Console.WriteLine($"Edge number {i+1}: {Edges[i]}" );
            }

            for (int i = 0; i < Angles.Length; i++)
            {
                Console.WriteLine($"Angle number {i+1}: {Angles[i]}" );
            }

            Console.WriteLine("Perimeter: " + Perimeter);
            Console.WriteLine("Area: " + Area);
        }
    }
}