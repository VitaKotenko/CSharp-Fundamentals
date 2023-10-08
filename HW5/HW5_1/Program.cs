namespace HW5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IDeveloper> developers = new List<IDeveloper>();
            IDeveloper builder1 = new Builder("a hammer");

            developers.Add(builder1);
            developers.Add(new Builder("a screwdriver"));
            developers.Add(new Builder("a handsaw"));
            developers.Add(new Programmer("C#"));
            developers.Add(new Programmer("Python"));
            developers.Add(new Programmer("Java"));


            for (int i = 0; i < developers.Count; i++)
            {
                developers[i].Create();
            }

            Console.WriteLine("______________");

            for (int i = 0; i < developers.Count; i++)
            {
                developers[i].Destroy();
            }

            Console.WriteLine("______________");

            developers.Sort();

            Console.WriteLine("Sorted list of developers:");
            foreach (IDeveloper developer in developers)
            {
                Console.WriteLine($"Tool: {developer.Tool}");
            }
        }
    }
}