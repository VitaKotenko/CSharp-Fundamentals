using System.Runtime.CompilerServices;

namespace HW9_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\C# Fundamentals\HW9\HW9_1\Program.cs";
            List<string> text = new List<string>();
            
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        text.Add(line);
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            List<int> charsInLine= new List<int>();
            for(int i = 0; i < text.Count(); i++)
            {
                int amountOfChars = text[i].Count();
                charsInLine.Add(amountOfChars);
                Console.WriteLine($"The {i + 1}-th line has {amountOfChars} symbols");
            }
            Console.WriteLine("____________________________");

            Console.WriteLine($"The largest line has {charsInLine.Max()} symbols");
            Console.WriteLine($"The shortest line has {charsInLine.Min()} symbols");
            Console.WriteLine("____________________________");

            Console.WriteLine("Lines which consist of word \"var\" :");
            var stringsWithVar = text.Where(l => l.Contains("var"));
            foreach (string line in stringsWithVar)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();
        }
    }
}