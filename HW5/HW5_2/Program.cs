namespace HW5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, string> people = new Dictionary<uint, string>();

            int lengthOfPeopleDictionary = 7;
            for (int i = 0; i < lengthOfPeopleDictionary; i++)
            {
                Console.WriteLine($"Please enter {i + 1}-th user's name:");
                uint id = Convert.ToUInt32(i);
                string name = Console.ReadLine();
                people.Add(id, name);
            }

            Console.WriteLine("Please enter ID: ");
            uint inputId = Convert.ToUInt32(Console.ReadLine());

            if (people.TryGetValue(inputId, out string foundedName))
            {
                Console.WriteLine($"The user with ID={inputId} has name {foundedName}");
            }
            else
            {
                Console.WriteLine($"The user with ID={inputId} doesn't exist");
            }
        }
    }
}