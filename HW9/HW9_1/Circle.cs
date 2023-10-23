using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class Circle : Shape
    {
        double pi = Math.PI;
        private double radious;

        public Circle(string name, double radious) : base(name)
        {
            this.radious = radious;
        }

        public override double Area()
        {
            double area = pi * radious * radious;
            return area;
        }

        public override double Perimeter()
        {
            double perimeter = 2.0 * pi * radious;
            return perimeter;
        }

        public static Circle Input()
        {
            Console.WriteLine("Please enter name of your circle:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter radious of your circle:");
            double radious = Double.Parse(Console.ReadLine());
            if (radious < 0)
            {
                throw new ApplicationException("Side must be higher than 0");
            }
            return new Circle(name, radious);
        }

        public override string Output()
        {
            return($"Circle {Name} has area: {Math.Round(Area(), 2)} and perimeter: {Math.Round(Perimeter(), 2)}");
        }
    }

}
