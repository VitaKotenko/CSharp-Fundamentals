using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Square : Shape
    {
        private double side;

        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            double area = side * side;
            return area;
        }

        public override double Perimeter()
        {
            double perimeter = side * 4.0;
            return perimeter;
        }

        public static Square Input()
        {
            Console.WriteLine("Please enter name of your square:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter side of your square:");
            double side = Double.Parse(Console.ReadLine());
            if (side < 0)
            {
                throw new ApplicationException("Side must be higher than 0");
            }
            return new Square(name, side);
        }

        public override string Output()
        {
            return($"Square {Name} has area: {Math.Round(Area(), 2)} and perimeter: {Math.Round(Perimeter(), 2)}");
        }
    }
}

