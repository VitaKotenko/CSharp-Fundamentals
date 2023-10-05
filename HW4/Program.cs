namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Person[] people = new Person[6];
            people[0] = new Person();
            people[1] = new Person("Alex", new DateTime(2002,1,1));
            for (int i = 2; i < people.Length; i++)
            {
                
                people[i] = Person.Input(i);
            }


            for (int i = 0; i < people.Length; i++)
            {
                Console.Write(people[i].Output());
                Console.WriteLine($"She/he is {people[i].Age()} years old.\n");
            }


            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Age() < 16 )
                {
                    people[i].ChangeName("Very Young");
                }
                Console.WriteLine(people[i].Output());
            }

            for (int i = 0;i < people.Length; i++)
            {
                for (int j = i+1; j < people.Length; j++) 
                {
                    if (people[i] == people[j])
                    {
                        Console.WriteLine($"{people[i].ToString()} and {people[j].ToString()} have the same name.\n");
                    }
                    
                }
            }
            
           
            

        }
    }
}