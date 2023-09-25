namespace HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            // Hometask 1
            Console.WriteLine("Please enter side of the square in centimeters:");
            int sideOfSquare = Convert.ToInt32(Console.ReadLine());
            int area = sideOfSquare * sideOfSquare;
            int perimeter = sideOfSquare * 4;
            Console.WriteLine($"Area of the square is {area} cm² and perimeter is {perimeter} cm\n");


            // Hometask 2
            string name;
            int age;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("How old are you?");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Hello, {name}! You are {age} years old.\n");

            // Hometask 3
            Console.WriteLine("Please enter radius of the circle in centimeters:"); ;
            double r = Convert.ToDouble(Console.ReadLine());
            double pi = Math.PI;
            double length =2 * r * pi;
            double areaOfCircle = pi * Math.Pow(r,2);
            double volume = 4 / 3 * Math.Pow(r, 3);
            Console.WriteLine($"Length of the circle {length :F2} cm, area {areaOfCircle:F2} cm² and volume {volume:F2} cm³");


        }
    }
}