using System.Runtime.InteropServices;

namespace HW2
{
    internal class Program
    {

        enum HTTPError
        {
            BadRequest = 400,
            Unautorhized = 401,
            PaymentRequired = 402,
            Forbidden = 403,
            NotFound = 404
        }

        struct Dog
        {
            public string name;
            public string mark;
            public int age;
            public override string ToString()
            {
                return string.Format($"Your dog {name} is {mark} and is {age} years old.");
            }
        }


        static void Main(string[] args)
        {
            // Hometask 1
            Console.WriteLine("Please enter three float numbers:");
            float num1 = float.Parse(Console.ReadLine());
            float num2 = float.Parse(Console.ReadLine());
            float num3 = float.Parse(Console.ReadLine());

            bool allInRange = ((num1 >= -5) && (num1 <= 5)) && ((num2 >= -5) && (num2 <= 5)) && ((num3 >= -5) && (num3 <= 5));
            Console.WriteLine(allInRange ? "All Numbers are in the range [-5.5]\n" : "Numbers are not in the range [-5.5]\n");


            // Hometask 2
            Console.WriteLine("Please enter three integer numbers:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            int number2 = Convert.ToInt32(Console.ReadLine());
            int number3 = Convert.ToInt32(Console.ReadLine());

            int minOfNumbers = Math.Min(number1, Math.Min(number2, number3));
            int maxOfNumbers = Math.Max(number1, Math.Max(number2, number3));

            Console.WriteLine($"A minimum number is {minOfNumbers} and a maximum number is {maxOfNumbers}.\n");


            // Hometask 3
            Console.WriteLine("Please enter HTTP status code:");
            int inputError = Convert.ToInt32(Console.ReadLine());
            HTTPError name = (HTTPError)inputError;
            string formattedName = string.Concat(name.ToString().Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            Console.WriteLine(formattedName);
            Console.WriteLine("\n");


            // Hometask 4
            Dog myDog;
            Console.WriteLine("Please enter name of your dog:");
            myDog.name = Console.ReadLine();
            Console.WriteLine("Please enter mark of your dog:");
            myDog.mark = Console.ReadLine(); ;
            Console.WriteLine("Please enter age of your dog:");
            myDog.age = Convert.ToInt32(Console.ReadLine()); ;
            Console.WriteLine(myDog);
        }
    }
}