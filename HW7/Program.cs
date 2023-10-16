using System;
using System.IO;

namespace HW7
{
    internal class Program
    {
        static void ReadPhones(string path, Dictionary<string,string> phonebook) 
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] phone = line.Split(',');
                        phonebook.Add(phone[0], phone[1]);
                    }
                }

                catch (ArgumentException ae) 
                { 
                    Console.WriteLine(ae.Message);
                }
            }
        }


        static void SavePhones(string path, Dictionary<string, string> phonebook)
        {
            foreach (KeyValuePair<string, string> kvp in phonebook)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(kvp.Key);
                }
            }
        }


        static void FormatPhones(string path, Dictionary<string, string> phonebook)
        {
            Dictionary<string, string> updatedPhonebook = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> kvp in phonebook)
            {
                string key = kvp.Key;
                string value = kvp.Value;

                if (kvp.Key.StartsWith("80"))
                {
                    key = "+3" + kvp.Key;
                }

                updatedPhonebook.Add(key, value);

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(key);
                }
            }
        }


        static void FindNumber(string name, Dictionary<string, string> phonebook)
        {
            bool found = false;
            
            foreach (KeyValuePair<string, string> kvp in phonebook)
            {
                if (name == kvp.Value)
                {
                    Console.WriteLine($"{name}'s phonenumber is {kvp.Key}");
                    found = true;
                }
                
            }
            if (!found)
            { 
                Console.WriteLine("Such a subscriber doesn't exist in your phonebook!"); 
            }
        }


        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string readPath = @"D:\C# Fundamentals\HW7\phones\phones.txt";
            string writePathPhones = @"D:\C# Fundamentals\HW7\Phones.txt";
            string writePathNewPhones = @"D:\C# Fundamentals\HW7\New.txt";

            ReadPhones(readPath, phonebook);

            SavePhones(writePathPhones, phonebook);

            FormatPhones(writePathNewPhones, phonebook);

            Console.WriteLine("Please enter name");
            string name = Console.ReadLine();
            FindNumber(name, phonebook);

            Console.ReadKey();
        }
    }
}