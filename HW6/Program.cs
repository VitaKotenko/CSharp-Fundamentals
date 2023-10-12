using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace HW6
{
    internal class Program
    {
        public static void ReadNumber(int startNumber, int endNumber)
        {
            int[] numbers = new int[10];
            int amountOfNumbers = numbers.Length;
            int previousNumber = startNumber;
            Console.WriteLine($"\nYou should enter 10 numbers between {startNumber} and {endNumber}.");
            for (int i = 0; i < amountOfNumbers; i++)
            {
            a1:
                try
                {
                    Console.WriteLine($"Please enter {i + 1}-th number:");
                    int inputNumber = Int32.Parse(Console.ReadLine());

                    if (inputNumber <= startNumber || inputNumber >= endNumber)
                    {
                        throw new ApplicationException($"Input number should be bigger than {startNumber} and smaller than {endNumber}. Try one more time");
                    }
                    if (inputNumber <= previousNumber)
                    {
                        throw new ApplicationException("Input number should be bigger than previous. Try one more time");
                    }

                    if (endNumber - inputNumber < amountOfNumbers - i)
                    {
                        throw new ApplicationException($"Input number is too big. Remember you should enter {amountOfNumbers - i} more numbers. Try one more time");
                    }

                    numbers[i] = inputNumber;
                    previousNumber = numbers[i];
                }

                catch (ApplicationException ae)
                {
                    Console.WriteLine(ae.Message);
                    goto a1;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    goto a1;
                }   
            }

            Console.WriteLine($"\nCongratulations! You have successfully entered 10 numbers in the range ({startNumber};{endNumber}):");
            
            foreach (int num in numbers)
            { 
                Console.WriteLine($"{num}"); 
            }
        }


        static void Main(string[] args)
        {
        a2:
            try
            {
                Console.WriteLine($"Please enter start number:");
                int startNumber = Int32.Parse(Console.ReadLine());

                Console.WriteLine($"Please enter end number:");
                int endNumber = Int32.Parse(Console.ReadLine());
                
                if (endNumber - startNumber <= 10) 
                {
                    throw new ApplicationException("Your end number is too small. Remember you should enter 10 numbers in the range.");
                }
                ReadNumber(startNumber, endNumber);
            }
            
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                goto a2;
            }
            
            catch (ApplicationException ae)
            {
                Console.WriteLine(ae.Message);
                goto a2;
            }
        }
    }
}
