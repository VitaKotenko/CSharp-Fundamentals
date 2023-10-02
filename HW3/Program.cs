using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hometask 1
            char[] characters = { 'a', 'o', 'e', 'i' };

            Console.WriteLine("Please enter string: ");
            string myString = Console.ReadLine();

            int sum = 0;
            foreach (char c in myString) 
            {
                if (characters.Contains(c))
                    sum++;
            }
            Console.WriteLine($"Your string has {sum} specific characters.");


            //Hometask 2
            Console.WriteLine("Please enter number of month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("The month has 31 days");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("The month has 30 days");
                    break;
                case 2:
                    Console.WriteLine("Please enter the year of Fabruary which you want to know: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                        Console.WriteLine("The month has 29 days");
                    else Console.WriteLine("The month has 28 days");
                    break;
                default: 
                    Console.WriteLine("The month doesn't exist!");
                    break;
            }


            // Hometask 3
            int[] numbers = new int[10];
            int result = 0;
            bool firstFiveElementsIsPositive = true;
            
            Console.WriteLine("Please enter 10 numbers: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
                if (numbers[i] < 0 && i < 5)
                {
                    firstFiveElementsIsPositive = false;
                    result = 1;
                }               
            }

            if (firstFiveElementsIsPositive) // sum of the first five elements
                for (int i = 0; i < numbers.Length/2; i++)
                {
                    result += numbers[i];
                }
            else
                for (int i = 5; i < numbers.Length; i++) // product of the elements from 6th
                {
                    result *= numbers[i];
                }
            Console.WriteLine(result);
        }
    }
}