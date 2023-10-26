using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10_1
{
    public struct Point
    {
        double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Distance(Point p)
        {

            return Math.Sqrt(Math.Pow(p.x - x, 2) + Math.Pow(p.y - y, 2));

        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

    }

    public class Triangle
    {
        public Point Vertex1 { get; }
        public Point Vertex2 { get; }
        public Point Vertex3 { get; }

        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;

            if (!IsValid())
            {
                throw new ApplicationException("Triangle doesn't exist!");
            }

        }

        public bool IsValid()
        {
            double side1 = Vertex1.Distance(Vertex2);
            double side2 = Vertex2.Distance(Vertex3);
            double side3 = Vertex1.Distance(Vertex3);
            // Console.WriteLine($"{side1}, {side2}, {side3}");

            return side1 + side2 > side3 && side2 + side3 > side1 && side1 + side3 > side2;
        }
        public double Perimeter()
        {
            double perimeter = Vertex1.Distance(Vertex2) + Vertex2.Distance(Vertex3) + Vertex1.Distance(Vertex3);
            return perimeter;

        }

        public double Square()
        {
            double p = Perimeter() / 2.0;
            double square = Math.Sqrt(p * (p - Vertex1.Distance(Vertex2)) * (p - Vertex2.Distance(Vertex3)) * (p - Vertex1.Distance(Vertex3)));
            return square;
        }

        public void Print()
        {
            Console.WriteLine($"Triangle({Vertex1.ToString()},{Vertex2.ToString()},{Vertex3.ToString()}) has perimeter {Math.Round(Perimeter(), 2)} and square {Math.Round(Square(), 2)}");
        }


    }
}
