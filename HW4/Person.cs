using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    public class Person
    {
        private string name;

        private DateTime birthYear;

        public string Name
        { get {  return name; } }

        public DateTime BirthYear 
        { get { return birthYear; } }

        public Person() { 
            name = "Unknown"; 
            birthYear = new DateTime(2005,1,1); }

        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        public int Age()
        { 
            int age = DateTime.Now.Year - birthYear.Year; 
            return age;
        }

        public static Person Input(int i)
        {
            Console.WriteLine($"Please enter name {i + 1}th person");
            string name = Console.ReadLine();
            Console.WriteLine($"Please enter year of birth {i + 1}th person");
            DateTime birthYear = new DateTime(Convert.ToInt16(Console.ReadLine()),1,1);
            Person person = new Person(name, birthYear);
            return person;
        }

        public string Output()
        {
            return $"{name} was borned in {birthYear.Year}.";
        }

        public void ChangeName(string newName)
        {
            name = newName;
        }

        public override string ToString() {
            return $"{name} was borned in {birthYear.Year}";
        }

        public static bool operator == (Person a, Person b)
        {
            return (a.name == b.name);
        }
        public static bool operator != (Person a, Person b)
        {
            return !(a == b);
            
        }
    }

}
