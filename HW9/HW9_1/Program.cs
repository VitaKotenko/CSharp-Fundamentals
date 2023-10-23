using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace HW9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\C# Fundamentals\HW9\shapes.txt";

            string name;
            List<Shape> shapes = new List<Shape>();
            int counter = 0;
            while (counter < 6)
            {
            Input:
                try
                {
                    Console.WriteLine($"Please enter your {counter + 1}-th figure: C for circle or S for square");
                    string figure = Console.ReadLine();
                    switch (figure.ToLower())
                    {
                        case ("c"):
                            shapes.Add(Circle.Input());
                            counter++;
                            break;

                        case ("s"):
                            shapes.Add(Square.Input());
                            counter++;
                            break;

                        default:
                            Console.WriteLine($"We can't find such figure. You should enter C/S");
                            break;
                    }
                }
                catch (FormatException fe)
                {
                    Console.Write(fe.Message);
                    goto Input;
                }
                catch (ApplicationException ae)
                {
                    Console.Write(ae.Message);
                    goto Input;
                }
            }

            Console.WriteLine("____________________");
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("List of all shapes:");

                foreach (var shape in shapes)
                {
                    sw.WriteLine(shape.Output());
                }


                sw.WriteLine("____________________");
                sw.WriteLine("List of shapes with area from range [10,100]:");
                var shapesWithAreaInRange = from shape in shapes
                                            where shape.Area() >= 10 && shape.Area() <= 100
                                            select shape;
                foreach (var shape in shapesWithAreaInRange)
                {
                    sw.WriteLine(shape.Output());
                }

                sw.WriteLine("____________________");
                sw.WriteLine("List of shapes with letter a in the name:");
                var shapesWithLetterA = from shape in shapes
                                        where shape.Name.ToLower().Contains('a')
                                        select shape;
                foreach (var shape in shapesWithLetterA)
                {
                    sw.WriteLine(shape.Output());
                }
            }

            Console.WriteLine("____________________");

            Console.WriteLine("List of all shapes after removing the shapes with perimeter less than 5.0:");
            shapes.RemoveAll(s => s.Perimeter() < 5.0);
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Output());
            }

        }
    }
}