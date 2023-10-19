using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Principal;

namespace HW8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            List<Shape> shapes = new List<Shape>();
            for (int i = 0; i < 10; i++)
            {
            Input:
                try
                {
                    Console.WriteLine($"Please enter your {i + 1}-th figure: C for circle or S for square");
                    string figure = Console.ReadLine();
                    switch (figure.ToLower())
                    {
                        case ("c"):
                            shapes.Add(Circle.Input());
                            break;

                        case ("s"):
                            shapes.Add(Square.Input());
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
            foreach (Shape shape in shapes)
            {
                shape.Output();
            }

            Console.WriteLine("____________________");
            Shape maxPerimeterFigure = shapes[0];
            for (int i = 1; i < shapes.Count; i++)
            {

                if (maxPerimeterFigure.Perimeter() < shapes[i].Perimeter()) 
                {
                    maxPerimeterFigure = shapes[i];
                }
            }
            Console.WriteLine($"Figure with max perimeter is {maxPerimeterFigure.Name}");

            Console.WriteLine("____________________");
            Console.WriteLine("List of figures after sorting:");
            shapes.Sort();
            foreach (Shape shape in shapes)
            {
                shape.Output();
            }

            Console.ReadKey();

        }
    }
}